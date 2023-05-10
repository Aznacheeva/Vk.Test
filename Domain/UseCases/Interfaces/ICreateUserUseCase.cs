using Api.Contracts.Dtos;
using OneOf;
using OneOf.Types;

namespace Domain.UseCases.Interfaces;

public interface ICreateUserUseCase
{
    Task<OneOf<long, BadRequest>> CreateUser(CreateUserDto userDto);
}