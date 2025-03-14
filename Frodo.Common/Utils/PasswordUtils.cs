﻿using System.Security.Cryptography;
using System.Text;

namespace Frodo.Common.Utils;

public static class PasswordUtils
{
    public static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }
}
