using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using Happy.Utils.Reflection;
using Happy.Test.Utils.Reflection.Stub.AssemblyUtils;

namespace Happy.Test.Utils.Reflection
{
    [TestFixture]
    public sealed class AssemblyUtilTest
    {
        [Test]
        public void CreateConcreteDescendentInstances_Test()
        {
            var instances = this.GetType().Assembly
                                .CreateConcreteDescendentInstances<ITestInterface>();

            Assert.AreEqual(2, instances.Count());
        }
    }
}
