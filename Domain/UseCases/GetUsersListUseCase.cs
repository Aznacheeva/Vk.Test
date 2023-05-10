using Api.Contracts.Dtos;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Domain.UseCases.Interfaces;
using OneOf;
using OneOf.Types;

namespace Domain.UseCases;

public class GetUsersListUseCase : IGetUsersListUseCase
{
    private readonly IUserRepository _userRepository;

    public GetUsersListUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OneOf<User[], BadRequest>> GetUsers(PaginationDto paginationDto)
    {
        if (paginationDto is {Page: 0, PageSize: 0})
        {
            return await _userRepository.GetUsers();
        }

        if (paginationDto.PageSize == 0 || paginationDto.Page == 0)
        {
            return new BadRequest("Not all fields are filled in");
        }

        return await _userRepository.GetUsers(
            GetSkippedCount(paginationDto.Page, paginationDto.PageSize),
            paginationDto.PageSize);
    }

    private static int GetSkippedCount(int page, int pageSize)
    {
        return (page - 1) * pageSize;
    }
}