using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Nova.Common.Helper
{
    public static class AesHelper
    {
        /// <summary>
        /// AES-256-CBC 加密 + HMAC-SHA256 签名（防篡改）
        /// </summary>
        /// <param name="plaintext">明文</param>
        /// <param name="key">32字节密钥（AES-256）</param>
        /// <returns>加密结果：IV(16) + 密文 + HMAC(32)</returns>
        public static byte[] Encrypt(byte[] plaintext, byte[] key)
        {
            if (plaintext == null) throw new ArgumentNullException(nameof(plaintext));
            if (key == null || key.Length != 32)
                throw new ArgumentException("密钥必须是32字节（AES-256）", nameof(key));

            // 拆分密钥：前16字节用于AES，后16字节用于HMAC
            var aesKey = new byte[16];
            var hmacKey = new byte[16];
            Buffer.BlockCopy(key, 0, aesKey, 0, 16);
            Buffer.BlockCopy(key, 16, hmacKey, 0, 16);

            using (var aes = Aes.Create())
            {
                aes.Key = aesKey;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.GenerateIV();

                byte[] ciphertext;
                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(plaintext, 0, plaintext.Length);
                    cs.FlushFinalBlock();
                    ciphertext = ms.ToArray();
                }

                // 计算 HMAC（IV + 密文）
                byte[] hmac;
                using (var hmacAlg = new HMACSHA256(hmacKey))
                {
                    var dataToMac = new byte[aes.IV.Length + ciphertext.Length];
                    Buffer.BlockCopy(aes.IV, 0, dataToMac, 0, aes.IV.Length);
                    Buffer.BlockCopy(ciphertext, 0, dataToMac, aes.IV.Length, ciphertext.Length);
                    hmac = hmacAlg.ComputeHash(dataToMac);
                }

                // 组合：IV + 密文 + HMAC
                var result = new byte[aes.IV.Length + ciphertext.Length + hmac.Length];
                Buffer.BlockCopy(aes.IV, 0, result, 0, aes.IV.Length);
                Buffer.BlockCopy(ciphertext, 0, result, aes.IV.Length, ciphertext.Length);
                Buffer.BlockCopy(hmac, 0, result, aes.IV.Length + ciphertext.Length, hmac.Length);

                return result;
            }
        }

        /// <summary>
        /// AES-256-CBC 解密（验证HMAC）
        /// </summary>
        /// <param name="combined">加密结果</param>
        /// <param name="key">32字节密钥</param>
        /// <returns>明文</returns>
        public static byte[] Decrypt(byte[] combined, byte[] key)
        {
            if (combined == null) throw new ArgumentNullException(nameof(combined));
            if (key == null || key.Length != 32)
                throw new ArgumentException("密钥必须是32字节（AES-256）", nameof(key));
            if (combined.Length < 48) // IV(16) + HMAC(32) 至少48字节
                throw new ArgumentException("数据太短", nameof(combined));

            // 拆分密钥
            var aesKey = new byte[16];
            var hmacKey = new byte[16];
            Buffer.BlockCopy(key, 0, aesKey, 0, 16);
            Buffer.BlockCopy(key, 16, hmacKey, 0, 16);

            // 解析数据
            int ivSize = 16;
            int hmacSize = 32;
            var iv = new byte[ivSize];
            var ciphertext = new byte[combined.Length - ivSize - hmacSize];
            var receivedHmac = new byte[hmacSize];

            Buffer.BlockCopy(combined, 0, iv, 0, ivSize);
            Buffer.BlockCopy(combined, ivSize, ciphertext, 0, ciphertext.Length);
            Buffer.BlockCopy(combined, ivSize + ciphertext.Length, receivedHmac, 0, hmacSize);

            // 验证 HMAC
            using (var hmacAlg = new HMACSHA256(hmacKey))
            {
                var dataToMac = new byte[iv.Length + ciphertext.Length];
                Buffer.BlockCopy(iv, 0, dataToMac, 0, iv.Length);
                Buffer.BlockCopy(ciphertext, 0, dataToMac, iv.Length, ciphertext.Length);
                var computedHmac = hmacAlg.ComputeHash(dataToMac);

                if (!computedHmac.SequenceEqual(receivedHmac))
                    throw new CryptographicException("数据已被篡改或密钥错误");
            }

            // 解密
            using (var aes = Aes.Create())
            {
                aes.Key = aesKey;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var ms = new MemoryStream(ciphertext))
                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (var result = new MemoryStream())
                {
                    cs.CopyTo(result);
                    return result.ToArray();
                }
            }
        }

        /// <summary>
        /// 生成随机32字节密钥
        /// </summary>
        public static byte[] GenerateKey()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var key = new byte[32];
                rng.GetBytes(key);
                return key;
            }
        }

        /// <summary>
        /// 从密码生成密钥（PBKDF2，用于密码加密场景）
        /// </summary>
        public static byte[] DeriveKeyFromPassword(string password, byte[] salt, int iterations = 10000)
        {
            using (var derive = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return derive.GetBytes(32);
            }
        }

        /// <summary>
        /// 字符串扩展：加密返回Base64
        /// </summary>
        public static string EncryptToString(string plaintext, byte[] key)
        {
            var plainBytes = Encoding.UTF8.GetBytes(plaintext);
            var encrypted = Encrypt(plainBytes, key);
            return Convert.ToBase64String(encrypted);
        }

        /// <summary>
        /// 字符串扩展：从Base64解密
        /// </summary>
        public static string DecryptFromString(string ciphertextBase64, byte[] key)
        {
            var combined = Convert.FromBase64String(ciphertextBase64);
            var decrypted = Decrypt(combined, key);
            return Encoding.UTF8.GetString(decrypted);
        }
    }
}