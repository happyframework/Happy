using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Happy.Utils.Collections.Generic;

namespace Happy.Test.Utils.Collections.Generic
{
    [TestFixture]
    public sealed class EnumerableUtilTest
    {
        [Test]
        public void ToRows_Test()
        {
            var rows = Enumerable.Range(1, 100).ToRows(10);

            Assert.AreEqual(10, rows.Count());
        }
    }
}
