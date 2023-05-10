using Api.Contracts.Dtos;
using DataAccess.DbContext;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public sealed class UserStateRepository : IUserStateRepository
{
    private readonly ApplicationContext _context;

    public UserStateRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<UserState> GetUserStateByCode(StateCode stateCode)
    {
        return await _context
            .UserStates
            .FirstAsync(state => state.StateCode == stateCode);
    }
}