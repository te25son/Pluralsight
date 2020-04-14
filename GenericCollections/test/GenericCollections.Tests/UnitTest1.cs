using System;
using System.Collections.Generic;
using Xunit;

namespace GenericCollections.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            List<int> integers = new List<int> { 1, 2, 3 };
            integers.Insert(1, 6);

            Assert.Equal(6, integers[1]);
        }
    }
}
