using System.Security.Cryptography;

namespace Encryption.Service
{
    public class AesEncryptionService : IEncryption
    {
        private byte[] _keyEncrypt;
        private byte[] _vectorEncrypt;

        public AesEncryptionService(string keyEncrypt,
                                    string vectorEncrypt)
        {
            _keyEncrypt = StringToByteArray(keyEncrypt);
            _vectorEncrypt = StringToByteArray(vectorEncrypt);
        }

        public string? Encrypt(string plainText)
        {
            byte[] encrypted = EncryptStringToBytes_Aes(plainText);
            return BitConverter.ToString(encrypted).Replace("-", "");
        }

        public string Decrypt(string textEncrypt)
        {
            if (IsHexString(textEncrypt))
            {
                string plaintext = null;

                byte[] cipherText = StringToByteArray(textEncrypt);

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = _keyEncrypt;
                    aesAlg.IV = _vectorEncrypt;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }

                return plaintext;
            }
            return textEncrypt;
        }

        private byte[]? EncryptStringToBytes_Aes(string plainText)
        {
            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _keyEncrypt;
                aesAlg.IV = _vectorEncrypt;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;
        }

        private byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        private bool IsHexString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            if (input.Length % 2 != 0)
                return false;

            if (int.TryParse(input, out _))
                return false;

            foreach (char c in input)
            {
                if (!((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F')))
                    return false;
            }

            return true;
        }

        public bool Verify(string textObtained, string originalText)
        {
            throw new NotImplementedException();
        }
    }
}
