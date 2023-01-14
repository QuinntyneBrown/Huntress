namespace IdentityService.Core.Entities;

public class Role
{
    public Guid RoleId { get; init; }
    public string Name { get; init; }
    public List<User> Users { get; init; } = new();
    public List<Privilege> Privileges { get; init; } = new();
    public Role(string name)
    {
        Name = name;
    }

    private Role()
    {

    }
}