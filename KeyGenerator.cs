using System.Security.Cryptography;
using System.Text;

namespace FileEncryptorThingy
{
    public static class KeyGenerator
    {
        public static byte[] GenerateKey(byte[] password, int iteration, HashAlgorithmName algorithm, string salt, int keysize)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            return GenerateKey(password, iteration, algorithm, saltBytes, keysize);
        }
        public static byte[] GenerateKey(string password, int iteration, HashAlgorithmName algorithm, byte[] salt,int keysize)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            return GenerateKey(passwordBytes,iteration,algorithm,salt, keysize);
        }
        public static byte[] GenerateKey(byte[] passwordBytes, int iteration, HashAlgorithmName algorithm, byte[] saltBytes,int keysize)
        {
            using Rfc2898DeriveBytes pbkdf2 = new(
                passwordBytes,
                saltBytes,
                iteration,
                algorithm);
            //key should match algorithm 
            return pbkdf2.GetBytes(keysize);
        }
        public static string ByteToHex(byte[] bytes)
        {
            StringBuilder Sb = new();

            foreach (byte b in bytes)
                Sb.Append(b.ToString("x2"));

            return Sb.ToString();
        }
    }
}
