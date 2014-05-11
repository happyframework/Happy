using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Happy.Utils.Linq.Expressions
{
    /// <summary>
    /// 表达式工具。
    /// </summary>
    public static class ExpressionUtil
    {
        /// <summary>
        /// 创建属性访问（<paramref name="property"/>）表达式。
        /// </summary>
        public static Expression<Func<T, TProperty>> CreatePropertyExpression
                                                        <T, TProperty>(string property)
        {
            Check.MustNotNullAndNotWhiteSpace(property, "property");

            var parameter = Expression.Parameter(typeof(T));

            return Expression.Lambda<Func<T, TProperty>>(
                                                Expression.Property(parameter, property),
                                                parameter);
        }

        /// <summary>
        /// 获取<paramref name="expression"/>代表的成员名称。
        /// </summary>
        public static string GeMemberName<T, TProperty>(
                                            Expression<Func<T, TProperty>> expression)
        {
            Check.MustNotNull(expression, "expression");
            Check.MustIsType<MemberExpression>(expression.Body, "expression.Body");

            return (expression.Body as MemberExpression).Member.Name;
        }
    }
}