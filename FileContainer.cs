using System.Text.Json.Serialization;

namespace FileEncryptorThingy
{
    public class FileContainer
    {
        public Metadata Metadata { get; set; }
        public byte[] HMAC { get; set; }
        public byte[] Iv {  get; set; }
        public byte[] Data { get; set; }
        public FileContainer(string password, string encryptionAlgorithm, string hashAlgorithm, string textToEncrypt) //constructor for text to encrypt and decrypt
        {
            if(string.IsNullOrEmpty(password)) throw new ArgumentException("password cannot be empty");

            Metadata = new Metadata(encryptionAlgorithm, hashAlgorithm);
            Encryptor encryptor = new(password, Metadata);
            Iv = encryptor.Iv;
            Data = encryptor.Encrypt(textToEncrypt);
            HMAC = encryptor.CreateHmac(Data);
        }
        public FileContainer(string password, string encryptionAlgorithm, string hashAlgorithm, byte[] bytesToEncrypt) //constructor for bytes to encrypt and decrypt
        {
            if (string.IsNullOrEmpty(password)) throw new ArgumentException("password cannot be empty");

            Metadata = new Metadata(encryptionAlgorithm, hashAlgorithm);
            Encryptor encryptor = new(password, Metadata);
            Iv = encryptor.Iv;
            Data = encryptor.Encrypt(bytesToEncrypt);
            HMAC = encryptor.CreateHmac(Data);
        }
        [JsonConstructor]
        public FileContainer(Metadata metadata, byte[] hmac, byte[] iv, byte[] data)
        {
            Metadata = metadata;
            HMAC = hmac;
            Iv = iv;
            Data = data;
        }
    }
}
