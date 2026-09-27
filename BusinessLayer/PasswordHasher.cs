using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace ClsBusinessLayer
{
    // PBKDF2-HMAC-SHA256 password hashing.
    // Stored format: PBKDF2-SHA256$<iterations>$<salt-base64>$<hash-base64>
    public static class PasswordHasher
    {
        private const string FormatId = "PBKDF2-SHA256";

        // The iteration count is stored with every hash, so it can be raised later
        // without breaking verification of existing hashes.
        public const int Iterations = 100000;

        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int MaxHashSize = 64;
        private const int MaxIterations = 10000000;

        public static string HashPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hash = DeriveKey(password, salt, Iterations, HashSize);

            return string.Join("$", FormatId, Iterations.ToString(CultureInfo.InvariantCulture),
                Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        // Returns false (never throws) for a missing, malformed or unsupported stored value.
        public static bool VerifyPassword(string password, string encodedHash)
        {
            if (password == null || string.IsNullOrEmpty(encodedHash))
            {
                return false;
            }

            string[] parts = encodedHash.Split('$');
            if (parts.Length != 4 || parts[0] != FormatId)
            {
                return false;
            }

            int iterations;
            if (!int.TryParse(parts[1], NumberStyles.None, CultureInfo.InvariantCulture, out iterations)
                || iterations < 1 || iterations > MaxIterations)
            {
                return false;
            }

            byte[] salt;
            byte[] expectedHash;
            try
            {
                salt = Convert.FromBase64String(parts[2]);
                expectedHash = Convert.FromBase64String(parts[3]);
            }
            catch (FormatException)
            {
                return false;
            }

            if (salt.Length < SaltSize || expectedHash.Length < HashSize || expectedHash.Length > MaxHashSize)
            {
                return false;
            }

            byte[] actualHash = DeriveKey(password, salt, iterations, expectedHash.Length);
            return FixedTimeEquals(actualHash, expectedHash);
        }

        private static byte[] DeriveKey(string password, byte[] salt, int iterations, int length)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(password), salt, iterations, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(length);
            }
        }

        // Compares every byte regardless of where the first difference is.
        private static bool FixedTimeEquals(byte[] left, byte[] right)
        {
            if (left.Length != right.Length)
            {
                return false;
            }

            int diff = 0;
            for (int i = 0; i < left.Length; i++)
            {
                diff |= left[i] ^ right[i];
            }

            return diff == 0;
        }
    }
}
