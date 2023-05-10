using Api.Contracts.Dtos;

namespace Domain.Entities;

public class UserGroup
{
    public int Id { get; set; }

    public GroupCode GroupCode { get; set; } = GroupCode.User;

    public string? Description { get; set; }
}