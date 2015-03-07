using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace SCSD
{
    public static class EllipticAsymmetric
    {
        public static void KeyGenerator(out byte[] SecretA, out byte[] SecretB)
        {
            SecretA = null;
            SecretB = null;

            byte[] SecretAPublic;
            byte[] SecretBPublic;

            ECDiffieHellmanCng A = new ECDiffieHellmanCng();
            A.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
            A.HashAlgorithm = CngAlgorithm.Sha256;
            SecretAPublic = A.PublicKey.ToByteArray();


            ECDiffieHellmanCng B = new ECDiffieHellmanCng();
            B.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
            B.HashAlgorithm = CngAlgorithm.Sha256;
            SecretBPublic = B.PublicKey.ToByteArray();
            SecretB = B.DeriveKeyMaterial(CngKey.Import(SecretAPublic, CngKeyBlobFormat.EccPublicBlob));

            CngKey k = CngKey.Import(SecretBPublic, CngKeyBlobFormat.EccPublicBlob);
            SecretA = A.DeriveKeyMaterial(CngKey.Import(SecretBPublic, CngKeyBlobFormat.EccPublicBlob));
        }

        public static byte[] Encrypte(byte[] key, string secretMessage)
        {
            byte[] encryptedMessage = null;
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            string EncryptionKey = ByteConverter.GetString(key);
            using (Aes aes = new AesCryptoServiceProvider())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = pdb.GetBytes(32);
                aes.IV = pdb.GetBytes(16);

                // Encrypt the message 
                using (MemoryStream ciphertext = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ciphertext, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] plaintextMessage = Encoding.UTF8.GetBytes(secretMessage);
                    cs.Write(plaintextMessage, 0, plaintextMessage.Length);
                    cs.Close();
                    encryptedMessage = ciphertext.ToArray();
                }
            }
            return encryptedMessage;
        }

        public static string Decrypte(byte[] encryptedMessage, byte[] key)
        {
            string decryptedMessage = string.Empty;
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            string DecriptionKey = ByteConverter.GetString(key);

            using (Aes aes = new AesCryptoServiceProvider())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(DecriptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = pdb.GetBytes(32);
                aes.IV = pdb.GetBytes(16);

                // Decrypt the message 
                using (MemoryStream plaintext = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(plaintext, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(encryptedMessage, 0, encryptedMessage.Length);
                        cs.Close();
                        decryptedMessage = Encoding.UTF8.GetString(plaintext.ToArray());
                    }
                }
            }
            return decryptedMessage;
        }

    }
}
