using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Happy.Utils.IO
{
    /// <summary>
    /// 文件工具。
    /// </summary>
    public static class FileUtil
    {
        /// <summary>
        /// 如果文件<paramref name="path"/>不存在就使用<paramref name="defaultContent"/>
        /// 作为默认内容创建一个，返回文件路径。
        /// </summary>
        public static string CreateFile(string path, string defaultContent)
        {
            Check.MustNotNullAndNotWhiteSpace(path, "path");
            Check.MustNotNullAndNotWhiteSpace(defaultContent, "defaultContent");

            if (!File.Exists(path))
            {
                File.WriteAllText(path, defaultContent);
            }

            return path;
        }
    }
}
