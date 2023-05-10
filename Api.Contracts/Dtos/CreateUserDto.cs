namespace Api.Contracts.Dtos;

public class CreateUserDto
{
    public string Login { get; set; } = default!;

    public string Password { get; set; } = default!;

    public GroupCode UserGroupCode { get; set; } = GroupCode.User;
}