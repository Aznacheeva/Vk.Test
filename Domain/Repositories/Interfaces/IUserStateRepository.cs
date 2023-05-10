using Api.Contracts.Dtos;
using Domain.Entities;

namespace Domain.Repositories.Interfaces;

public interface IUserStateRepository
{
    Task<UserState> GetUserStateByCode(StateCode stateCode);
}