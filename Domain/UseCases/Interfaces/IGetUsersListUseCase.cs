using Api.Contracts.Dtos;
using Domain.Entities;
using OneOf;
using OneOf.Types;

namespace Domain.UseCases.Interfaces;

public interface IGetUsersListUseCase
{
    Task<OneOf<User[], BadRequest>> GetUsers(PaginationDto paginationDto);
}