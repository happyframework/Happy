using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Utils.Collections.Generic
{
    /// <summary>
    /// 集合工具。
    /// </summary>
    public static class EnumerableUtil
    {
        /// <summary>
        /// 将<paramref name="list"/>转换为列长度为<paramref name="columnLength"/>的行集合。
        /// </summary>
        public static IEnumerable<Row<T>> ToRows<T>(this IEnumerable<T> list,
                                                    int columnLength)
        {
            Check.MustGreaterThan(columnLength, "columnLength", 0);

            if (list != null)
            {
                var count = list.Count();
                var rowLength = Math.Ceiling((count / (columnLength * 1.0)));
                for (var i = 0; i < rowLength; i++)
                {
                    yield return new Row<T>
                    {
                        RowIndex = i,
                        Values = list.Skip(i * columnLength).Take(columnLength)
                    };
                }
            }
        }

        /// <summary>
        /// 代表一行数据，因为外部多数情况下用 var 声明此类型的变量，因此将其定义为内部类。
        /// </summary>
        public sealed class Row<T> : IEnumerable<T>
        {
            /// <summary>
            /// 第几行。
            /// </summary>
            public int RowIndex { get; internal set; }

            internal IEnumerable<T> Values { get; set; }

            /// <inheritdoc />
            public IEnumerator<T> GetEnumerator()
            {
                return this.Values.GetEnumerator();
            }

            /// <inheritdoc />
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.Values.GetEnumerator();
            }
        }
    }
}
