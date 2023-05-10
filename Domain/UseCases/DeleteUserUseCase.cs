using Domain.Entities;
using Domain.Repositories.Interfaces;
using Domain.UseCases.Interfaces;
using OneOf;
using OneOf.Types;

namespace Domain.UseCases;

public class DeleteUserUseCase : IDeleteUserUseCase
{
    private readonly IUserRepository _userRepository;

    public DeleteUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OneOf<User, NotFound>> DeleteUser(long id)
    {
        var user = await _userRepository.GetUser(id);
        
        return user is null ?
            new NotFound()
            : await _userRepository.SetUserDeleted(user);
    }
}