using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace Happy.Utils.Reflection
{
    /// <summary>
    /// 方法工具。
    /// </summary>
    public static class MethodInfoUtil
    {
        /// <summary>
        /// <paramref name="method"/>和<paramref name="target"/>的签名是否一致。
        /// </summary>
        /// <returns></returns>
        public static bool Match(this MethodInfo method, MethodInfo target)
        {
            return method.Name == target.Name
                   && method.ReturnType == target.ReturnType
                   && method.GetParameters().Zip(target.GetParameters(), (p1, p2) =>
                   {
                       return new Tuple<ParameterInfo, ParameterInfo>(p1, p2);
                   })
                   .All(t => t.Item1.Name == t.Item2.Name
                             && t.Item1.ParameterType == t.Item2.ParameterType);
        }
    }
}
