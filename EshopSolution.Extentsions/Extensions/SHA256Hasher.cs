using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Text;

namespace EshopSolution.Extensions.Extensions
{
    public class SHA256Hasher
    {
        //public string Salt { get; private set; }
        //public string PasswordHashed { get; private set; }
        Salt salter;

        public SHA256Hasher()
        {
            salter = new Salt();
        }

        public static string Create(string password, string salt)
        {
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.UTF8.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            //Salt = Convert.ToBase64String(salt);
            //PasswordHashed = hashed;

            return hashed;
        }

        public  GenerateHashResponse Create(string password)
        {
            var salt = salter.Create();

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Create(password, salt);

            return new GenerateHashResponse()
            {
                Salt = salt,
                PasswordHashed = hashed
            };
        }

        public static bool Validate(string password, string salt, string hash) => Create(password, salt) == hash;

        public class Salt
        {
            public string Create()
            {
                byte[] randomBytes = new byte[128 / 8];
                using (var generator = RandomNumberGenerator.Create())
                {
                    generator.GetBytes(randomBytes);
                    return Convert.ToBase64String(randomBytes);
                }
            }
        }

        public class GenerateHashResponse
        {
            public string Salt { get; set; }
            public string PasswordHashed { get; set; }
        }
    }
}
