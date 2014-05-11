using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Happy.Utils.Reflection
{
    /// <summary>
    /// 程序集工具。
    /// </summary>
    public static class AssemblyUtil
    {
        /// <summary>
        /// 创建<paramref name="assembly"/>中所有实现或继承了
        /// <typeparamref name="TBaseType"/>的具体类型的实例。
        /// </summary>
        public static IEnumerable<TBaseType> CreateConcreteDescendentInstances<TBaseType>
                                                                (this Assembly assembly)
        {
            Check.MustNotNull(assembly, "assembly");

            return assembly.GetConcreteDescendentTypes<TBaseType>()
                           .Where(type => !type.IsGenericType)
                           .Select(type => type.CreateInstance<TBaseType>())
                           .ToList();
        }

        /// <summary>
        /// 创建<paramref name="assembly"/>中所有实现或继承了
        /// <paramref name="baseType"/>的具体类型的实例。
        /// </summary>
        public static IEnumerable<object> CreateConcreteDescendentInstances(
                                                                this Assembly assembly,
                                                                Type baseType)
        {
            Check.MustNotNull(assembly, "assembly");
            Check.MustNotNull(baseType, "baseType");

            return assembly.GetConcreteDescendentTypes(baseType)
                           .Where(type => !type.IsGenericType)
                           .Select(type => type.CreateInstance())
                           .ToList();
        }

        /// <summary>
        /// 返回<paramref name="assembly"/>中所有实现或继承了
        /// <typeparamref name="TBaseType"/>的具体类型。
        /// </summary>
        public static IEnumerable<Type> GetConcreteDescendentTypes<TBaseType>(
                                                                this Assembly assembly)
        {
            Check.MustNotNull(assembly, "assembly");

            return assembly.GetConcreteDescendentTypes(typeof(TBaseType));
        }

        /// <summary>
        /// 返回<paramref name="assembly"/>中所有实现或继承了<paramref name="baseType"/>的具
        /// 体类型。
        /// </summary>
        public static IEnumerable<Type> GetConcreteDescendentTypes(this Assembly assembly,
                                                                   Type baseType)
        {
            Check.MustNotNull(assembly, "assembly");
            Check.MustNotNull(baseType, "baseType");

            return assembly.GetTypes().Where(type => baseType.IsAssignableFrom(type)
                                                     && type.IsConcreteType());
        }
    }
}
