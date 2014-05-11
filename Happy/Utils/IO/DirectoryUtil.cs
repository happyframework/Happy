using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Happy.Utils.IO
{
    /// <summary>
    /// 目录工具。
    /// </summary>
    public static class DirectoryUtil
    {
        /// <summary>
        /// 如果目录<paramref name="path"/>不存在就创建一个目录，返回
        /// <paramref name="path"/>。
        /// </summary>
        public static string CreateDirectoryIfNotExists(string path)
        {
            Check.MustNotEmpty(path, "path");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }
    }
}
