using Security;
using System.Security.Cryptography;

namespace IdentityService.Core.Entities;

public class User
{
    public User(string username, string password, IPasswordHasher passwordHasher)
    {
        Roles = new List<Role>();
        Salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(Salt);
        }
        Username = username;
        Password = passwordHasher.HashPassword(Salt, password);
    }

    public Guid UserId { get; init; }
    public string Username { get; init; }
    public string Password { get; init; }
    public byte[] Salt { get; init; }
    public List<Role> Roles { get; init; }
}
