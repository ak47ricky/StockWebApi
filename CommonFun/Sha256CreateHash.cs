using System.Security.Cryptography;
using System.Text;

namespace StockWebApi.CommonFun
{
    public static class Sha256CreateHash
    {
        public static string GenerateSalt(int size = 16)
        {
            byte[] saltByte = new byte[size];

            RandomNumberGenerator.Fill(saltByte);

            return Convert.ToBase64String(saltByte);
        }

        public static string GetHashCode(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var combined = password + salt;

                var bytes = Encoding.UTF8.GetBytes(combined);

                var hash = sha256.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }
    }
}
