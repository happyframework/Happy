using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy
{
    /// <summary>
    /// 校验异常。
    /// </summary>
    public sealed class CheckException : ApplicationException
    {
        /// <summary>
        /// 构造方法。
        /// </summary>
        public CheckException(string message)
            : base(message)
        {

        }
    }
}
