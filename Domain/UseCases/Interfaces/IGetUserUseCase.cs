using Domain.Entities;
using OneOf;
using OneOf.Types;

namespace Domain.UseCases.Interfaces;

public interface IGetUserUseCase
{
    Task<OneOf<User, NotFound>> GetUser(long id);
}