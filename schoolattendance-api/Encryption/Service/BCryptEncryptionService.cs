namespace Encryption.Service
{
    public class BCryptEncryptionService : IEncryption
    {
        public string? Encrypt(string plainText)
            => BCrypt.Net.BCrypt.HashPassword(plainText);

        public bool Verify(string textObtained, string originalText)
            => BCrypt.Net.BCrypt.Verify(textObtained, originalText);

        public string Decrypt(string textEncrypt)
        {
            throw new NotImplementedException();
        }
    }
}
