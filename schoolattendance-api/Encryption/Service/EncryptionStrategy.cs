using Microsoft.Extensions.DependencyInjection;

namespace Encryption.Service
{
    public class EncryptionStrategy : IEncryptionStrategy
    {
        private readonly IEncryption _aesEncryptionStrategy;
        private readonly IEncryption _bcryptEncryptionStrategy;
        private IEncryption _encryption;


        public EncryptionStrategy(IEncryption aesEncryptionStrategy,
                                  [FromKeyedServices("BCrypt")] IEncryption bcryptEncryptionStrategy)
        {
            _aesEncryptionStrategy = aesEncryptionStrategy;
            _bcryptEncryptionStrategy = bcryptEncryptionStrategy;
        }

        public void SetStrategyAes()
            => _encryption = _aesEncryptionStrategy;

        public void SetStrategyBcrypt()
           => _encryption = _bcryptEncryptionStrategy;

        public string? Encrypt(string data)
            => _encryption.Encrypt(data);


        public string Decrypt(string data)
            => _encryption.Decrypt(data);

        public bool Verify(string textObtained, string originalText)
            => _encryption.Verify(textObtained, originalText);
    }
}
