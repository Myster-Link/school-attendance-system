namespace Encryption.Service
{
    public interface IEncryption
    {
        string? Encrypt(string plainText);
        string Decrypt(string textEncrypt);
        bool Verify(string textObtained, string originalText);

    }
}
