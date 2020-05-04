using System;
using System.ComponentModel;
using Xunit;

namespace ReflectIt.Tests
{
    public class IoCTests
    {
        [Fact]
        public void CanResolveTypes()
        {
            var ioc = new Container();
            ioc.For<ILogger>.Use<SqlServerLogger>();

            var logger = ioc.Resolve<ILogger>();

            Assert.Equal(typeof(SqlServerLogger), logger.GetType());
        }
    }
}
