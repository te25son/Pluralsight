using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GenericCollections.Tests
{
    public class ListTests
    {
        [Fact]
        public void ListCanInsert()
        {
            var integers = new List<int> { 1, 2, 3 };
            integers.Insert(1, 6);

            Assert.Equal(6, integers[1]);
        }

        [Fact]
        public void ListCanRemove()
        {
            var integers = new List<int> { 1, 2, 3, 2 };
            integers.Remove(2);  // Remove all removes the first instance of the element from a list.

            Assert.True(integers.SequenceEqual(new [] { 1, 3, 2 }));
        }

        [Fact]
        public void ListCanRemoveMoreThanOne()
        {
            var integers = new List<int> { 1, 2, 3, 2 };
            integers.RemoveAll(n => n.Equals(2));  // RemoveAll removes all instances of an element from a list. 

            Assert.True(integers.SequenceEqual(new [] { 1, 3 }));
        }

        [Fact]
        public void ListCanFindObjects()
        {
            var integers = new List<int> { 1, 2, 3 };
            var index = integers.IndexOf(3);  // Gets the index of the element: 3.

            Assert.Equal(2, index);
        }

        [Fact]
        public void ListReturnsDefaultIfObjectDoesNotExist()
        {
            var integers = new List<int> { 1, 2, 3 };
            var index = integers.IndexOf(4);

            Assert.Equal(-1, index);
        }
    }
}
