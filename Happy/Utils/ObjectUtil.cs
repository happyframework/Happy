using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Utils
{
    /// <summary>
    /// 对象工具。
    /// </summary>
    public static class ObjectUtil
    {
        /// <summary>
        /// 浅拷贝<paramref name="obj"/>到一个字典，如果<paramref name="obj"/>为null，就返回
        /// 空字典。
        /// </summary>
        public static Dictionary<string, object> ShallowCopyToDictionary(object obj,
                                                    params string[] excludeProperties)
        {
            var dic = new Dictionary<string, object>();
            if (obj == null)
            {
                return dic;
            }

            foreach (var property in obj.GetType().GetProperties())
            {
                if (excludeProperties != null
                    && excludeProperties.Contains(property.Name))
                {
                    continue;
                }
                if (!property.CanRead)
                {
                    continue;
                }

                dic[property.Name] = property.GetValue(obj, null);
            }

            return dic;
        }
    }
}
