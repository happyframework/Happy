using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Happy
{
    /// <summary>
    /// 针对参数或变量的校验器，如果校验失败就抛出<see cref="CheckException"/>异常。
    /// </summary>
    /// 设计理念：
    /// <list type="number">
    ///     <item>防御式编程。</item>
    ///     <item>显式的表达意图。</item>
    /// </list>
    /// </remarks>
    public static class Check
    {
        /// <summary>
        /// 参数名或变量名为<paramref name="variableName"/>的字符串的值（<paramref name="directory"/>）对应的路径必须存在。
        /// </summary>
        public static void DirectoryMustExist(string directory, string variableName)
        {
            Require(Directory.Exists(directory), string.Format(Resource.Messages.Error_TheCorrespondingDirectoryMustExist, variableName, directory));
        }

        /// <summary>
        /// 参数名或变量名为<paramref name="variableName"/>的字符串的值（<paramref name="str"/>）不能是空引用且不能是空白字符串。
        /// </summary>
        public static void MustNotNullAndNotWhiteSpace(string str, string variableName)
        {
            Require(!string.IsNullOrWhiteSpace(str), string.Format(Resource.Messages.Error_MustNotNullAndNotWhiteSpace, variableName));
        }

        /// <summary>
        /// 参数名或变量名为<paramref name="variableName"/>的集合的值（<paramref name="collection"/>）必须包含元素。
        /// </summary>
        public static void MustNotEmpty<T>(IEnumerable<T> collection, string variableName)
        {
            MustNotNull(collection, variableName);

            Require(collection.Any(), string.Format(Resource.Messages.Error_MustNotEmpty, variableName));
        }

        /// <summary>
        /// 参数名或变量名为<paramref name="variableName"/>的值（<paramref name="obj"/>）不能是空引用。
        /// </summary>
        public static void MustNotNull(object obj, string variableName)
        {
            Require(obj != null, string.Format(Resource.Messages.Error_MustNotNull, variableName));
        }

        /// <summary>
        /// 参数名或变量名为<paramref name="variableName"/>的值（<paramref name="value"/>）必须在某个范围。
        /// </summary>
        public static void MustBetween<T>(T value, string variableName, T start, T end)
            where T : IComparable<T>
        {
            Require(value.CompareTo(start) >= 0 && value.CompareTo(end) <= 0, string.Format(Resource.Messages.Error_MustBetween, variableName, start, end));
        }

        /// <summary>
        /// 参数名或变量名为<paramref name="variableName"/>的值（<paramref name="value"/>）必须大于指定的值。
        /// </summary>
        public static void MustGreaterThan<T>(T value, string variableName, T target)
            where T : IComparable<T>
        {
            Require(value.CompareTo(target) > 0, string.Format(Resource.Messages.Error_MustGreaterThan, variableName, target));
        }

        /// <summary>
        /// 参数名或变量名为<paramref name="variableName"/>的值（<paramref name="value"/>）必须大于等于指定的值。
        /// </summary>
        public static void MustGreaterThanEqual<T>(T value, string variableName, T target)
            where T : IComparable<T>
        {
            Require(value.CompareTo(target) >= 0, string.Format(Resource.Messages.Error_MustGreaterThanEqual, variableName, target));
        }

        /// <summary>
        /// <paramref name="assertion"/>必须为true。
        /// </summary>
        public static void Require(bool assertion, string message)
        {
            if (assertion)
            {
                return;
            }

            throw new CheckException(message);
        }
    }
}
