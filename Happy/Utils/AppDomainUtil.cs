using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Happy.Utils.Reflection;

namespace Happy.Utils
{
    /// <summary>
    /// 应用程序域工具。
    /// </summary>
    public static class AppDomainUtil
    {
        /// <summary>
        /// 创建<paramref name="appDomain"/>中第一个实现或继承了
        /// <typeparamref name="TBaseType"/>的具体类型的实例。
        /// </summary>
        public static TBaseType CreateConcreteDescendentInstance<TBaseType>(
                                                                this AppDomain appDomain)
        {
            Check.MustNotNull(appDomain, "appDomain");

            return appDomain.GetConcreteDescendentTypes<TBaseType>()
                           .Where(type => !type.IsGenericType)
                           .Select(type => type.CreateInstance<TBaseType>())
                           .FirstOrDefault();
        }

        /// <summary>
        /// 创建<paramref name="appDomain"/>中第一个实现或继承了
        /// <paramref name="baseType"/>的具体类型的实例。
        /// </summary>
        public static object CreateConcreteDescendentInstance(this AppDomain appDomain,
                                                              Type baseType)
        {
            Check.MustNotNull(appDomain, "appDomain");

            return appDomain.GetConcreteDescendentTypes(baseType)
                           .Where(type => !type.IsGenericType)
                           .Select(type => type.CreateInstance())
                           .FirstOrDefault();
        }

        /// <summary>
        /// 创建<paramref name="appDomain"/>中所有实现或继承了
        /// <typeparamref name="TBaseType"/>的具体类型的实例。
        /// </summary>
        public static IEnumerable<TBaseType> CreateConcreteDescendentInstances<TBaseType>
                                                         (this AppDomain appDomain)
        {
            Check.MustNotNull(appDomain, "appDomain");

            return appDomain.GetConcreteDescendentTypes<TBaseType>()
                           .Where(type => !type.IsGenericType)
                           .Select(type => type.CreateInstance<TBaseType>())
                           .ToList();
        }

        /// <summary>
        /// 创建<paramref name="appDomain"/>中所有实现或继承了
        /// <paramref name="baseType"/>的具体类型的实例。
        /// </summary>
        public static IEnumerable<object> CreateConcreteDescendentInstances(
                                                            this AppDomain appDomain,
                                                            Type baseType)
        {
            Check.MustNotNull(appDomain, "appDomain");
            Check.MustNotNull(baseType, "baseType");

            return appDomain.GetConcreteDescendentTypes(baseType)
                           .Where(type => !type.IsGenericType)
                           .Select(type => type.CreateInstance())
                           .ToList();
        }

        /// <summary>
        /// 返回<paramref name="appDomain"/>中所有实现或继承了
        /// <typeparamref name="TBaseType"/>的具体类型。
        /// </summary>
        public static IEnumerable<Type> GetConcreteDescendentTypes<TBaseType>(
                                                                this AppDomain appDomain)
        {
            Check.MustNotNull(appDomain, "appDomain");

            return appDomain.GetConcreteDescendentTypes(typeof(TBaseType));
        }

        /// <summary>
        /// 返回<paramref name="appDomain"/>中所有实现或继承了<paramref name="baseType"/>的具
        /// 体类型。
        /// </summary>
        public static IEnumerable<Type> GetConcreteDescendentTypes(
                                                                this AppDomain appDomain,
                                                                Type baseType)
        {
            Check.MustNotNull(appDomain, "appDomain");
            Check.MustNotNull(baseType, "baseType");

            return appDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                            .Where(type => baseType.IsAssignableFrom(type)
                                           && type.IsConcreteType());
        }
    }
}
