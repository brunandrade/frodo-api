using System.Security.Cryptography;

namespace Frodo.Common.Utils;

public static class PasswordUtils
{
    public static string GenerateSalt(int size = 32)
    {
        var saltBytes = new byte[size];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(saltBytes);
        return Convert.ToBase64String(saltBytes);
    }

    public static string HashPassword(string password, string salt)
    {
        var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 10000, HashAlgorithmName.SHA256);
        return Convert.ToBase64String(pbkdf2.GetBytes(32));
    }
}