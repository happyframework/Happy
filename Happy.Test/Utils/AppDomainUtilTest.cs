using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using Happy.Utils;
using Happy.Test.Utils.Stub.AppDomainUtils;

namespace Happy.Test.Utils
{
    [TestFixture]
    public sealed class AssemblyUtilTest
    {
        [Test]
        public void CreateConcreteDescendentInstances_Test()
        {
            var instances = AppDomain.CurrentDomain
                                .CreateConcreteDescendentInstances<ITestInterface>();

            Assert.AreEqual(2, instances.Count());
        }
    }
}
