namespace Kaell.Security;

internal class PasswordHasher : IPasswordHasher
{
    public string HashPassword(byte[] salt, string plainText)
    {
        return plainText;
    }
}
