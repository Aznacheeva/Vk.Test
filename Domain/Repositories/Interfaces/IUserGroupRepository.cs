using Api.Contracts.Dtos;
using Domain.Entities;

namespace Domain.Repositories.Interfaces;

public interface IUserGroupRepository
{
    Task<UserGroup> GetUserGroupByCode(GroupCode groupCode);
}