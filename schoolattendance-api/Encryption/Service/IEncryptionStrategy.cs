namespace Encryption.Service
{
    public interface IEncryptionStrategy
    {
        void SetStrategyAes();
        void SetStrategyBcrypt();
        string? Encrypt(string plainText);
        string Decrypt(string textEncrypt);
        bool Verify(string textObtained, string originalText);
    }
}
