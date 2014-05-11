using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using Happy.Utils.Reflection;
using Happy.Test.Utils.Reflection.Stub.AttributeUtils;

namespace Happy.Test.Utils.Reflection
{
    [TestFixture]
    public sealed class AttributeUtilTest
    {
        [Test]
        public void GetAttributes_With_No_Attibute_Test()
        {
            var attibutes = typeof(TestClass).GetAttributes<TestFixtureAttribute>();

            Assert.AreEqual(0, attibutes.Length);
        }

        [Test]
        public void GetAttributes_With_Have_Attibute_Test()
        {
            var attibutes = typeof(TestClass).GetAttributes<SerializableAttribute>();

            Assert.AreEqual(1, attibutes.Length);
        }


        [Test]
        public void GetAttribute_With_No_Attibute_Test()
        {
            var attibute = typeof(TestClass).GetAttribute<TestFixtureAttribute>();

            Assert.IsNull(attibute);
        }

        [Test]
        public void GetAttribute_With_Have_Attibute_Test()
        {
            var attibute = typeof(TestClass).GetAttribute<SerializableAttribute>();

            Assert.IsNotNull(attibute);
        }
    }
}
