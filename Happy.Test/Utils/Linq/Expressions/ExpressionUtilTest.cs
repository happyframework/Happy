using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Happy.Utils.Linq.Expressions;

namespace Happy.Test.Utils.Linq.Expressions
{
    [TestFixture]
    public sealed class ExpressionUtilTest
    {
        [Test]
        public void CreatePropertyExpression_Test()
        {
            var expression = ExpressionUtil.CreatePropertyExpression<DateTime, int>(
                                                                                "Year");
            var year = expression.Compile()(new DateTime(1985, 09, 10));

            Assert.AreEqual(1985, year);
        }

        [Test]
        public void GeMemberNameTest()
        {
            var name = ExpressionUtil.GeMemberName<DateTime, int>(x => x.Year);

            Assert.AreEqual("Year", name);
        }

    }
}
