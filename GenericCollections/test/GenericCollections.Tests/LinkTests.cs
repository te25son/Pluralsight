using System.Collections.Generic;
using Xunit;

namespace GenericCollections.Tests
{
    public class LinkTests
    {
        [Fact]
        public void CanAddAfter()
        {
            var list = new LinkedList<string>();
            list.AddFirst("Hello");
            list.AddLast("World");

            var firstItem = list.First;
            list.AddAfter(firstItem, "there");
            
            Assert.Equal("there", firstItem.Next.Value);
        }

        [Fact]
        public void CanAddBefore()
        {
            var list = new LinkedList<string>();
            list.AddFirst("Hello");
            list.AddLast("World");
            
            var lastItem = list.Last;
            list.AddBefore(lastItem, "there");

            Assert.Equal("there", lastItem.Previous.Value);
        }

        [Fact]
        public void CanRemoveFirst()
        {
            var list = new LinkedList<string>();
            list.AddFirst("Freddy");
            list.AddLast("George");
            list.RemoveFirst();

            Assert.True(list.Count.Equals(1));
            Assert.Equal("George", list.First.Value);
        }

        [Fact]
        public void CanRemoveLast()
        {
            var list = new LinkedList<string>();
            list.AddFirst("Freddy");
            list.AddLast("George");
            list.RemoveLast();

            Assert.True(list.Count.Equals(1));
            Assert.Equal("Freddy", list.First.Value);
        }

        [Fact]
        public void CanRemoveSpecificItem()
        {
            var list = new LinkedList<string>();
            list.AddFirst("Freddy");
            list.AddLast("George");
            list.AddAfter(list.First, "Ben");

            var ben = list.Find("Ben");
            list.Remove(ben);

            Assert.DoesNotContain("Ben", list);
            Assert.True(list.Count.Equals(2));
        }
    }
}