using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Happy.Utils;

namespace Happy.Test.Utils
{
    [TestFixture]
    public sealed class StringUtilTest
    {
        [Test]
        public void Ellipsis_Test()
        {
            var result = "啊啊啊啊啊啊".Ellipsis(5);

            Assert.AreEqual("啊啊...", result);
        }
    }
}
