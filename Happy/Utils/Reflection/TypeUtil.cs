using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Utils.Reflection
{
    /// <summary>
    /// 类型工具。
    /// </summary>
    public static class TypeUtil
    {
        /// <summary>
        /// 创建<typeparamref name="type"/>的实例，返回类型为<paramref name="TBaseType"/>。
        /// </summary>
        public static TBaseType CreateInstance<TBaseType>(this Type type,
                                                          params object[] args)
        {
            return (TBaseType)type.CreateInstance(args);
        }

        /// <summary>
        /// 创建<typeparamref name="T"/>的实例。
        /// </summary>
        public static T CreateInstance<T>(params object[] args)
        {
            return (T)typeof(T).CreateInstance(args);
        }

        /// <summary>
        /// 创建<paramref name="type"/>的实例。
        /// </summary>
        public static object CreateInstance(this Type type, params object[] args)
        {
            Check.MustNotNull(type, "type");

            return Activator.CreateInstance(type, args);
        }

        /// <summary>
        /// 判断<paramref name="type"/>是否是具体类型。
        /// </summary>
        /// <remarks>
        /// 凡是能直接实例化的类型都是具体类型。
        /// </remarks>
        public static bool IsConcreteType(this Type type)
        {
            Check.MustNotNull(type, "type");

            return !type.IsGenericTypeDefinition
                   && !type.IsAbstract
                   && !type.IsInterface;
        }

        /// <summary>
        /// 在<paramref name="type"/>的实现的所有接口中，是否有一个接口是泛型且其泛型定义类型
        /// 是：<paramref name="genericInterfaceTypeDefinition"/> 。
        /// </summary>
        public static bool HasInterfaceMakeFromGenericInterfaceTypeDefinition(
                                                    this Type type,
                                                    Type genericInterfaceTypeDefinition)
        {
            Check.MustNotNull(type, "type");

            foreach (var item in type.GetInterfaces())
            {
                if (item.IsGenericType
                    && item.GetGenericTypeDefinition() == genericInterfaceTypeDefinition)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
