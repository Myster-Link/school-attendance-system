using Encryption.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Encryption.Extension
{
    public static class EncryptionExtension
    {
        public static IServiceCollection AddEncryptionExtension(this IServiceCollection services, string keyEncrypt, string vectorEncrypt)
        {

            services.AddScoped<IEncryption, AesEncryptionService>(provider =>
                new AesEncryptionService(keyEncrypt, vectorEncrypt));

            services.AddKeyedScoped<IEncryption, BCryptEncryptionService>("BCrypt");

            services.AddScoped<IEncryptionStrategy, EncryptionStrategy>();

            return services;
        }
    }
}
