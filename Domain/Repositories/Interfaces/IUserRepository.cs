using Api.Contracts.Dtos;
using Domain.Entities;

namespace Domain.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUser(long id);
    Task<User?> GetUserByLogin(string login);
    Task<User[]> GetUsers();
    Task<User[]> GetUsers(int skippedCount, int pageSize);
    Task<User[]> GetUsersWithGroupCode(GroupCode groupCode);
    Task<User> SetUserDeleted(User user);
    Task<long> CreateUser(User user);
}