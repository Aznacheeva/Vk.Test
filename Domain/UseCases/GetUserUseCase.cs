using Domain.Entities;
using Domain.Repositories.Interfaces;
using Domain.UseCases.Interfaces;
using OneOf;
using OneOf.Types;

namespace Domain.UseCases;

public class GetUserUseCase : IGetUserUseCase
{
    private readonly IUserRepository _userRepository;

    public GetUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OneOf<User, NotFound>> GetUser(long id)
    {
        var user = await _userRepository.GetUser(id);

        return user is null ?
            new NotFound()
            : user;
    }
}