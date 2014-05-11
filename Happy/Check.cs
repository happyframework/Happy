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
        /// 参数名或变量名为<paramref name="variableName"/>的字符串的值（
        /// <paramref name="directory"/>）对应的路径必须存在。
        /// </summary>
        /// <exception cref="CheckException"></exception>
        public static void DirectoryMustExist(string directory, string variableName)
        {
            var message = string.Format(
                                        Resource.Messages.Error_DirectoryMustExistxist,
                                        variableName, directory);
            Require(Directory.Exists(directory), message);
        }

        /// <summary>
        /// 参数名或变量名为<paramref name="variableName"/>的值（<paramref name="str"/>）
        /// 必须是类型<paramref name="T"/>。
        /// </summary>
        /// <exception cref="CheckException"></exception>
        public static void MustIsType<T>(object obj, string variableName)
        {
            var message = string.Format(
                                    Resource.Messages.Error_MustIsType,
                                    variableName, typeof(T));
            Require(obj is T, message);
        }

        /// <summary>
        /// 参数名或变量名为<paramref name="variableName"/>的字符串的值（
        /// <paramref name="str"/>）不能是空引用且不能是空白字符串。
        /// </summary>
        /// <exception cref="CheckException"></exception>
        public static void MustNotNullAndNotWhiteSpace(string str, string variableName)
        {
            var message = string.Format(
                                    Resource.Messages.Error_MustNotNullAndNotWhiteSpace,
                                    variableName);
            Require(!string.IsNullOrWhiteSpace(str), message);
        }

        /// <summary>
        /// 参数名或变量名为<paramref name="variableName"/>的集合的值（
        /// <paramref name="collection"/>）必须包含元素。
        /// </summary>
        /// <exception cref="CheckException"></exception>
        public static void MustNotEmpty<T>(IEnumerable<T> collection,
                                           string variableName)
        {
            MustNotNull(collection, variableName);

            var message = string.Format(Resource.Messages.Error_MustNotEmpty,
                                        variableName);
            Require(collection.Any(), message);
        }

        /// <summary>
        /// 参数名或变量名为<paramref name="variableName"/>的值（<paramref name="obj"/>）不
        /// 能是空引用。
        /// </summary>
        /// <exception cref="CheckException"></exception>
        public static void MustNotNull(object obj, string variableName)
        {
            var message = string.Format(Resource.Messages.Error_MustNotNull,
                                        variableName);
            Require(obj != null, message);
        }

        /// <summary>
        /// 参数名或变量名为<paramref name="variableName"/>的值（<paramref name="value"/>）
        /// 必须在某个范围（[<paramref name="start"/>, <paramref name="end"/>]）。
        /// </summary>
        /// <exception cref="CheckException"></exception>
        public static void MustBetween<T>(T value, string variableName, T start, T end)
            where T : IComparable<T>
        {
            var message = string.Format(Resource.Messages.Error_MustBetween,
                                        variableName, start, end);
            Require(value.CompareTo(start) >= 0 && value.CompareTo(end) <= 0, message);
        }

        /// <summary>
        /// 参数名或变量名为<paramref name="variableName"/>的值（<paramref name="value"/>）
        /// 必须大于<paramref name="target"/>/>。
        /// </summary>
        /// <exception cref="CheckException"></exception>
        public static void MustGreaterThan<T>(T value, string variableName, T target)
            where T : IComparable<T>
        {
            var message = string.Format(Resource.Messages.Error_MustGreaterThan,
                                        variableName, target);
            Require(value.CompareTo(target) > 0, message);
        }

        /// <summary>
        /// 参数名或变量名为<paramref name="variableName"/>的值（<paramref name="value"/>）
        /// 必须大于等于<paramref name="target"/>。
        /// </summary>
        /// <exception cref="CheckException"></exception>
        public static void MustGreaterThanEqual<T>(T value, string variableName,
                                                   T target)
            where T : IComparable<T>
        {
            var message = string.Format(Resource.Messages.Error_MustGreaterThanEqual,
                                        variableName, target);
            Require(value.CompareTo(target) >= 0, message);
        }

        /// <summary>
        /// <paramref name="assertion"/>必须为<code>true</code>，否则抛出使用
        /// <paramref name="message"/>实例化的<see cref="CheckException"/>。
        /// </summary>
        /// <exception cref="CheckException"></exception>
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
