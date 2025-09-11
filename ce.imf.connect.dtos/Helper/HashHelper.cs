using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.comon.Helper
{
    public static class HashHelper
    {
        // Hash password with salt using PBKDF2
        public static string HashPassword(this string password)
        {
            // Generate salt
            byte[] salt = RandomNumberGenerator.GetBytes(16); // 128-bit salt

            // Derive key
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32); // 256-bit hash

            // Return salt + hash as Base64
            return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
        }

        // Verify password
        public static bool VerifyPassword(this string password, string storedHash)
        {
            var parts = storedHash.Split(':');
            if (parts.Length != 2) return false;

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] hash = Convert.FromBase64String(parts[1]);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
            byte[] newHash = pbkdf2.GetBytes(32);

            return CryptographicOperations.FixedTimeEquals(hash, newHash);
        }
    }
}
