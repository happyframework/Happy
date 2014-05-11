using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Happy.Utils;

namespace Happy.Test.Utils
{
    [TestFixture]
    public sealed class ObjectUtilTest
    {
        [Test]
        public void ShallowCopyToDictionary_Test()
        {
            var dic = ObjectUtil.ShallowCopyToDictionary(new
            {
                X = 1,
                Y = 2,
                Z = 3
            }, "Z");

            Assert.AreEqual(2, dic.Count);
        }
    }
}
