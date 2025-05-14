using System.Security.Cryptography;
using System.Text;

namespace Libre_ERP_API.Helpers
{
    public class PasswordHelper
    {
        private readonly string _secretKey;

        public PasswordHelper(IConfiguration configuration)
        {
            _secretKey = configuration["PasswordSettings:SecretKey"]!;

            if (string.IsNullOrEmpty(_secretKey))
                throw new Exception("Secret key for password hashing is missing.");
        }

        public string HashPassword(string plainPassword)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_secretKey));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(plainPassword));
            return Convert.ToBase64String(hash);
        }

    }
}
