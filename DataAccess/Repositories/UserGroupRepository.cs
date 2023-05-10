using Api.Contracts.Dtos;
using DataAccess.DbContext;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public sealed class UserGroupRepository : IUserGroupRepository
{
    private readonly ApplicationContext _context;

    public UserGroupRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<UserGroup> GetUserGroupByCode(GroupCode groupCode)
    {
        return await _context
            .UserGroups
            .FirstAsync(group => group.GroupCode == groupCode);
    }
}