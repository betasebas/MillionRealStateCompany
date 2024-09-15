using MillionRealStateCompany.Application.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace MillionRealStateCompany.Application.Service
{
    public class HashPasswordService : IHashPasswordService
    {
        public string GenerateHash(string source)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string hash = GetHash(sha256Hash, source);

                return VerifyHash(sha256Hash, source, hash) ? hash : throw new InvalidOperationException("An error occurred while generating hash");
            }
        }

        public bool ValidateHash(string input, string hash)
        {
            using (SHA384 sha384Hash = SHA384.Create())
            {
                return VerifyHash(sha384Hash, input, hash);
            }
        }

        private static string GetHash(HashAlgorithm hashAlgorithm, string source)
        {

            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(source));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            var hashOfInput = GetHash(hashAlgorithm, input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }
}
