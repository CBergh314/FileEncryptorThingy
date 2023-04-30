namespace FileEncryptorThingy
{
    public class Metadata
    {
        /*
         * The following parameters may be specified in a config file, or from the command line, as you'd like:
         * 1) Encryption algorithm
         * 2) hashing algorithm (assume same for KDF and HMAC)
         * 3) iterations for KDF
         * 
         * In order to be able to decrypt the file later, the metadata must also contain the above parameters, and should also contain an indicator of which KDF was used.
         */
        public string EncryptionAlgorithm { get; set; }
        public string HashingAlgorithm { get; set; }
        public int Iterations { get; set; }
        public string KDF { get; set; }
        public Metadata(string EncryptionAlgorithm, string HashingAlgorithm, int Iterations = 100000)
        {
            this.EncryptionAlgorithm = EncryptionAlgorithm;
            this.HashingAlgorithm = HashingAlgorithm;
            this.Iterations = Iterations;
            KDF = "PBKDF2";
        }
    }
}
