using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Happy.Utils.Reflection
{
    /// <summary>
    /// 属性工具。
    /// </summary>
    public static class AttributeUtil
    {
        /// <summary>
        /// 返回<paramref name="provider"/>上应用的第一个<typeparamref name="TAttribute"/>
        /// 实例，如果没有定义就返回null。
        /// </summary>
        public static TAttribute GetAttribute<TAttribute>(
                                                this ICustomAttributeProvider provider,
                                                bool inherit = true)
            where TAttribute : Attribute
        {
            Check.MustNotNull(provider, "provider");

            return provider.IsDefined(typeof(TAttribute), inherit)
                            ? GetAttributes<TAttribute>(provider, inherit)[0]
                            : default(TAttribute);
        }

        /// <summary>
        /// 返回<paramref name="provider"/>上应用的<typeparamref name="TAttribute"/>实例数
        /// 组，如果没有定义就返回空数组。
        /// </summary>
        public static TAttribute[] GetAttributes<TAttribute>(
                                                this ICustomAttributeProvider provider,
                                                bool inherit = true)
            where TAttribute : Attribute
        {
            Check.MustNotNull(provider, "provider");

            return provider
                    .GetCustomAttributes(typeof(TAttribute), inherit)
                    .Cast<TAttribute>()
                    .ToArray();
        }
    }
}
