using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Happy.Utils.IO
{
    /// <summary>
    /// 流工具。
    /// </summary>
    public static class StreamUtil
    {
        /// <summary>
        /// 将<paramref name="stream"/>存为指定的文件。
        /// </summary>
        public static void SaveAs(Stream stream, string filename)
        {
            Check.MustNotNull(stream, "stream");
            Check.MustNotNullAndNotWhiteSpace(filename, "filename");

            DirectoryUtil.CreateDirectoryIfNotExists(Path.GetDirectoryName(filename));

            var targetStream = new FileStream(filename, FileMode.Create);
            try
            {
                WriteTo(stream, targetStream);
                targetStream.Flush();
            }
            finally
            {
                targetStream.Close();
            }
        }

        private static void WriteTo(Stream source, Stream target)
        {
            var data = source.ReadByte();
            while (data != -1)
            {
                target.WriteByte((byte)data);
                data = source.ReadByte();
            }
        }
    }
}
