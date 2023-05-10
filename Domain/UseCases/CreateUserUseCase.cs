using System.Security.Cryptography;
using System.Text;
using Api.Contracts.Dtos;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Domain.UseCases.Interfaces;
using OneOf;
using OneOf.Types;

namespace Domain.UseCases;

public class CreateUserUseCase : ICreateUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IUserGroupRepository _userGroupRepository;
    private readonly IUserStateRepository _userStateRepository;

    public CreateUserUseCase(IUserRepository userRepository, IUserGroupRepository userGroupRepository, IUserStateRepository userStateRepository)
    {
        _userRepository = userRepository;
        _userGroupRepository = userGroupRepository;
        _userStateRepository = userStateRepository;
    }

    public async Task<OneOf<long, BadRequest>> CreateUser(CreateUserDto userDto)
    {
        var isDefined = Enum.IsDefined(userDto.UserGroupCode);
        if (!isDefined)
        {
            return new BadRequest("Unknown group code");
        }

        var isLoginBusy = await _userRepository.GetUserByLogin(userDto.Login) is not null;
        if (isLoginBusy)
        {
            return new BadRequest("Login is busy");
        }
        
        if (userDto.UserGroupCode == GroupCode.Admin && await IsAdminExists())
        {
            return new BadRequest("Admin already exists");
        }
        
        
        var user = new User
        {
            Login = userDto.Login,
            Password = GetHash(userDto.Password),
            CreatedDate = DateTime.UtcNow,
            UserGroup = await _userGroupRepository.GetUserGroupByCode(userDto.UserGroupCode),
            UserState = await _userStateRepository.GetUserStateByCode(StateCode.Active),
        };

        await _userRepository.CreateUser(user);

        return user.Id;
    }

    private async Task<bool> IsAdminExists()
    {
        return (await _userRepository.GetUsersWithGroupCode(GroupCode.Admin)).Any();
    }

    private static string GetHash(string password)
    {
        var bytes = Encoding.ASCII.GetBytes(password);
        var hashData = MD5.HashData(bytes);
        
        return Convert.ToHexString(hashData);
    }
}