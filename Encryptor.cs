using System.Security.Cryptography;
using System.Text;

namespace FileEncryptorThingy
{
    public class Encryptor
    {
        public byte[] Iv { get; }
        public byte[] Km { get; }
        public byte[] KeyEncryption { get; }
        public byte[] KeyHmac { get; }
        private int HashKeySize { get; }
        private int EncryptionKeySize { get; }
        private HashAlgorithmName HashAlgorithmName { get; }
        private SymmetricAlgorithm EncryptAlgorithm { get; }
        private HMAC Hmac { get; }
        public Encryptor(string pw, Metadata metadata) : this(pw, metadata.EncryptionAlgorithm, metadata.HashingAlgorithm, metadata.Iterations) { }
        public Encryptor(string pw, string encryptionAlgorithm, string hashAlgorithm, int iterations = 100000) 
        {
            byte[] salt = Encoding.UTF8.GetBytes("Salt"); //RandomNumberGenerator.GetBytes(16);
            HashAlgorithmName = HashFactory(hashAlgorithm);
            HashKeySize = GetKeySize(hashAlgorithm);

            // the app must work with 3DES, AES128 and AES256 algorithms.
            EncryptAlgorithm = EncryptionAlgoritmFactory(encryptionAlgorithm);
            EncryptionKeySize = GetKeySize(encryptionAlgorithm)/8;


            // 1) Create a master key using PBKDF#2
            // Use a suitable number of iterations to deter password cracking.
            Km = KeyGenerator.GenerateKey(pw, iterations, HashAlgorithmName, salt, HashKeySize);

            // 2) Derive an encryption key and an HMAC key from the master key using PBKDF#2 and one iteration. 
            // A fixed string can be used in place of the 'salt' argument as long as it is a different fixed string. 
            KeyEncryption = KeyGenerator.GenerateKey(Km,1, HashAlgorithmName, "Encryption Key", EncryptionKeySize);
            KeyHmac = KeyGenerator.GenerateKey(Km, 1, HashAlgorithmName, "HMAC Key", EncryptionKeySize);

            Hmac = HmacFactory(hashAlgorithm, KeyHmac);
            
            // Use a randomly generated IV that is one block in size.
            Iv = RandomNumberGenerator.GetBytes(EncryptAlgorithm.IV.Length);

            EncryptAlgorithm.Key = KeyEncryption;
            EncryptAlgorithm.IV = Iv;
            EncryptAlgorithm.Padding = PaddingMode.None;
            EncryptAlgorithm.Mode = CipherMode.CBC;
        }
        public static HMAC HmacFactory(string algorithm, byte[] key)
        {
            algorithm = algorithm.ToUpper().Replace(" ", "");
            return algorithm switch
            {
                "SHA256" => new HMACSHA256(key),
                "SHA512" => new HMACSHA512(key),
                _ => throw new ArgumentException("Algorithm submitted not supported."),
            };
        }
        public static SymmetricAlgorithm EncryptionAlgoritmFactory(string algorithm)
        {
            algorithm = algorithm.ToUpper().Split(" ")[0];
            return algorithm switch
            {
                "AES" => Aes.Create(),
                "TRIPLE" => TripleDES.Create(),
                _ => throw new ArgumentException("Algorithm submitted not supported.")
            };
        }
        public static int GetKeySize(string algorithm)
        {
            var parts = algorithm.ToUpper().Split(' ');
            string name = parts[0];
            string size = parts[1];
            int key = 128;
            if(name != "TRIPLE")
            {
                key = int.TryParse(size, out int result) ? result : 0;
            }
            return key;
        }
        public static HashAlgorithmName HashFactory(string algorithm)
        {
            // The program must be able to support both sha256 and sha512 hashes.
            algorithm = algorithm.ToUpper().Replace(" ", "");
            return algorithm switch
            {
                "SHA256" => HashAlgorithmName.SHA256,
                "SHA512" => HashAlgorithmName.SHA512,
                _ => throw new ArgumentException("Algorithm submitted not supported."),
            };
        }

        // 3) Encrypt your data using CBC chaining mode,
        public byte[] Encrypt(string plaintext)
        {
            // Convert the string to bytes
            byte[] plaintext_bytes = Encoding.UTF8.GetBytes(plaintext);

            return Encrypt(plaintext_bytes);
        }
        public byte[] Encrypt(byte[] plaintext_bytes)
        {
            byte[] bytesToEncrypt = new byte[Iv.Length + plaintext_bytes.Length];
            Iv.CopyTo(bytesToEncrypt, 0);
            plaintext_bytes.CopyTo(bytesToEncrypt, Iv.Length);

            return EncryptAlgorithm.EncryptCbc(bytesToEncrypt, Iv);
        }
        // You also need to be able to decrypt the data
        public string Decrypt(byte[] enc_data)
        {
            byte[] iv = new byte[EncryptAlgorithm.IV.Length];
            Array.Copy(enc_data, iv, iv.Length);

            byte[] enc_msg = new byte[enc_data.Length - iv.Length];
            Array.Copy(enc_data, iv.Length, enc_msg, 0, enc_msg.Length);
            
            return Encoding.UTF8.GetString(EncryptAlgorithm.DecryptCbc(enc_msg, iv));
        }
        // 4) Create an HMAC of the IV and the encrypted data.
        public byte[] CreateHmac(byte[] cipherText)
        {
            byte[] bytesToHash = new byte[Iv.Length + cipherText.Length];
            Iv.CopyTo(bytesToHash, 0);
            cipherText.CopyTo(bytesToHash, Iv.Length);

            return Hmac.ComputeHash(bytesToHash);
        }
        public bool VerifyHmac(byte[] enc_data, byte[] iv, byte[] hmac)
        {
            byte[] bytesToHash = new byte[iv.Length + enc_data.Length];
            iv.CopyTo(bytesToHash, 0);
            enc_data.CopyTo(bytesToHash, Iv.Length);

            var hash = Hmac.ComputeHash(bytesToHash);
            if(hash.SequenceEqual(hmac))
            {
                return true;
            }
            return false;
        }
    }
}
