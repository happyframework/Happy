using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using Happy.Utils.Reflection;

namespace Happy.Test.Utils.Reflection
{
    [TestFixture]
    public sealed class TypeUtilTest
    {
        [Test]
        public void CreateInstance_Test()
        {
            var guidStr = "42442E69-58D0-475B-90BB-FD53FA6D1710".ToLower();

            var instance = typeof(Guid).CreateInstance(guidStr);

            Assert.AreEqual(guidStr, instance.ToString());
        }

        [Test]
        public void IsConcreteType_Test()
        {
            Assert.IsTrue(typeof(List<int>).IsConcreteType());
            Assert.IsTrue(typeof(int).IsConcreteType());

            Assert.IsFalse(typeof(Dictionary<,>).IsConcreteType());
            Assert.IsFalse(typeof(IDisposable).IsConcreteType());
            Assert.IsFalse(typeof(Comparer<int>).IsConcreteType());
        }

        [Test]
        public void HasInterfaceMakeFromGenericInterfaceTypeDefinition_Test()
        {
            var genericInterfaceTypeDefinition = typeof(IEnumerable<>);

            Assert.IsTrue(
                typeof(List<int>).HasInterfaceMakeFromGenericInterfaceTypeDefinition
                (genericInterfaceTypeDefinition)
            );
        }
    }
}
