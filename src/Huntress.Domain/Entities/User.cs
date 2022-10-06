using System.Collections.Generic;
using System.Security.Cryptography;

namespace Huntress.Domain.Entities;

public class User
{
    public Guid UserId { get; private set; }
    public string Username { get; private set; } = "";
    public string Password { get; private set; } = "";
    public byte[] Salt { get; private set; } = null!;
    public List<Role> Roles { get; private set; } = new();

    public User(string username, string password, IPasswordHasher passwordHasher)
    {

        Salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(Salt);
        }
        Username = username;
        Password = passwordHasher.HashPassword(Salt, password);
    }

    private User()
    {

    }
}
