using Api.Contracts.Dtos;
using DataAccess.DbContext;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public sealed class UserRepository : IUserRepository
{
    private const string UserGroup = "UserGroup";
    private const string UserState = "UserState";
    
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUser(long id)
    {
        var user = await _context
            .Users
            .Include(UserGroup)
            .Include(UserState)
            .FirstOrDefaultAsync(user => user.Id == id);

        return user;
    }

    public async Task<User?> GetUserByLogin(string login)
    {
        return await _context
            .Users
            .Include(UserGroup)
            .Include(UserState)
            .FirstOrDefaultAsync(user => user.Login.Equals(login));
    }

    public async Task<User[]> GetUsers()
    {
        var users = await _context
            .Users
            .Include(UserGroup)
            .Include(UserState)
            .ToArrayAsync(); 
        
        return users;
    }

    public async Task<User[]> GetUsers(int skippedCount, int pageSize)
    {
        var users = await _context
            .Users
            .Include(UserGroup)
            .Include(UserState)
            .Skip(skippedCount)
            .Take(pageSize)
            .ToArrayAsync();
        
        return users;
    }

    public async Task<User[]> GetUsersWithGroupCode(GroupCode groupCode)
    {
        var users = await _context
            .Users
            .Include(UserGroup)
            .Include(UserState)
            .Where(user => user.UserGroup.GroupCode == groupCode)
            .ToArrayAsync();

        return users;
    }

    public async Task<User> SetUserDeleted(User user)
    {
        user.UserStateId = (int)StateCode.Blocked;
        await _context.SaveChangesAsync();

        return (await GetUser(user.Id))!;
    }

    public async Task<long> CreateUser(User user)
    {
        var entry = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return entry.Entity.Id;
    }
}