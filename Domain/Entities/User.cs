namespace Domain.Entities;

public class User
{
    public long Id { get; set; }

    public string Login { get; set; } = default!;
    public string Password { get; set; } = default!;
    
    public DateTime CreatedDate { get; set; }
    
    public int UserGroupId { get; set; }
    public UserGroup UserGroup { get; set; } = default!;
    
    public int UserStateId { get; set; }
    public UserState UserState { get; set; } = default!;
}

