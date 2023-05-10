using Domain.Entities;
using OneOf;
using OneOf.Types;

namespace Domain.UseCases.Interfaces;

public interface IDeleteUserUseCase
{
    Task<OneOf<User, NotFound>> DeleteUser(long id);
}