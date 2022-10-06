namespace Kaell.Security;

public interface IPasswordHasher
{
    string HashPassword(byte[] salt, string plainText);
}
