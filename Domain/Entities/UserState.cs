using Api.Contracts.Dtos;

namespace Domain.Entities;

public class UserState
{
    public int Id { get; set; }

    public StateCode StateCode { get; set; } = StateCode.Active;

    public string? Description { get; set; }
}