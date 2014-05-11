using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Happy.Utils
{
    /// <summary>
    /// 字符串工具。
    /// </summary>
    public static class StringUtil
    {
        /// <summary>
        /// 返回<paramref name="str"/>的省略号（<paramref name="ellipsis"/>）形式，返回的字
        /// 符串长度不会大于<paramref name="len"/>。
        /// </summary>
        public static string Ellipsis(this string str, int len, string ellipsis = "...")
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            if (str.Length <= len)
            {
                return str;
            }

            return str.Substring(0, len - ellipsis.Length) + ellipsis;
        }

        /// <summary>
        /// 将<paramref name="str"/>以<paramref name="encodingName"/>编码格式转换为字节数
        /// 组。
        /// </summary>
        public static byte[] ToBytes(this string str, string encodingName = "UTF-8")
        {
            if (string.IsNullOrEmpty(str))
            {
                return new byte[] { };
            }

            return Encoding.GetEncoding(encodingName).GetBytes(str);
        }
    }
}
