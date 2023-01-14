namespace Security;

public interface IPasswordHasher
{
    string HashPassword(byte[] salt, string plainText);
}
