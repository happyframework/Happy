using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Happy.Utils.Encryption
{
    /// <summary>
    /// 哈希工具。
    /// </summary>
    public static class HashUtil
    {
        /// <summary>
        /// 随机生成一个长度为<paramref name="size"/>的盐度。
        /// </summary>
        public static byte[] GenerateSalt(int size)
        {
            Check.MustGreaterThan(size, "size", 0);

            var salt = new byte[size];
            using (var cryptoProvider = new RNGCryptoServiceProvider())
            {
                cryptoProvider.GetNonZeroBytes(salt);
            }

            return salt;
        }

        /// <summary>
        /// 使用<paramref name="hashName"/>指定的哈希算法计算<paramref name="bytes"/>
        /// 的哈希值。
        /// </summary>
        public static byte[] Hash(byte[] bytes, string hashName = "SHA1")
        {
            Check.MustNotNullAndNotWhiteSpace(hashName, "hashName");

            if (bytes == null)
            {
                return null;
            }

            using (var algorithm = HashAlgorithm.Create(hashName))
            {
                return algorithm.ComputeHash(bytes);
            }
        }

        /// <summary>
        /// 使用<paramref name="hashName"/>指定的哈希算法计算和
        /// <paramref name="encodingName"/>指定的编码计算<paramref name="str"/>的哈希值。
        /// </summary>
        public static string Hash(string str, string hashName = "SHA1", 
                                  string encodingName = "UTF-8")
        {
            Check.MustNotNullAndNotWhiteSpace(hashName, "hashName");
            Check.MustNotNullAndNotWhiteSpace(encodingName, "encodingName");

            if (string.IsNullOrEmpty(str))
            {
                return String.Empty;
            }

            var hashedBytes = Hash(str.ToBytes(encodingName), hashName);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }

        /// <summary>
        /// 使用MD5算法计算和<paramref name="encodingName"/>指定的编码计算
        /// <paramref name="str"/>的哈希值。
        /// </summary>
        public static string MD5(string str, string salt = "HAPPY", string encodingName = "UTF-8")
        {
            return Hash(salt + str, "MD5");
        }
    }
}
