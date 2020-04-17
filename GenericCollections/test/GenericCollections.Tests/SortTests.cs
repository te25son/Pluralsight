using System.Collections.Generic;
using Xunit;

namespace GenericCollections.Tests
{
    public class SortTests
    {
        [Fact]
        public void CanUseSortedLists()
        {
            var list = new SortedList<int, string>();
            list.Add(3, "three");
            list.Add(2, "two");
            list.Add(1, "one");

            Assert.Equal(0, list.IndexOfKey(1));
            Assert.Equal(1, list.IndexOfKey(2));
        }

        [Fact]
        public void CanUseSortedSets()
        {
            var set = new SortedSet<int>();
            set.Add(3);
            set.Add(1);
            set.Add(2);

            var enumerator = set.GetEnumerator();
            enumerator.MoveNext();  // Moves to the first element of the set.
            Assert.Equal(1, enumerator.Current);
        }
    }
}