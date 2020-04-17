using System.Collections.Generic;
using Xunit;

namespace GenericCollections.Tests
{
    public class MapTests
    {
        [Fact]
        public void CanUseDictionaryAsMap()
        {
            var map = new Dictionary<int, string>();
            map.Add(1, "one");
            map.Add(2, "two");

            Assert.Equal("one", map[1]);
        }

        [Fact]
        public void CanSearchKeyWithKeyContains()
        {
            var map = new Dictionary<int, string>();
            map.Add(1, "one");
            map.Add(2, "two");

            Assert.True(map.ContainsKey(1));
        }

        [Fact]
        public void CanRemoveByKey()
        {
            var map = new Dictionary<int, string>();
            map.Add(1, "one");
            map.Add(2, "two");
            map.Remove(1);

            Assert.False(map.ContainsKey(1));
        }

        [Fact]
        public void CanSearchValueWithContainsValue()
        {
            var map = new Dictionary<int, string>();
            map.Add(1, "one");
            map.Add(2, "two");

            Assert.True(map.ContainsValue("two"));
        }
    }
}