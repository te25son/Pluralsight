using System.Collections.Generic;
using Xunit;

namespace GenericCollections.Tests
{
    public class SetTests
    {
        [Fact]
        public void SetDoesNotTakeDuplicates()
        {
            var numberSet = new HashSet<int>();
            var employeeSet = new HashSet<Employee>();
            var scott = new Employee { Name = "Scott" };
            
            numberSet.Add(1);
            numberSet.Add(1);
            employeeSet.Add(scott);
            employeeSet.Add(scott);  // Same object so will not be in set.
            employeeSet.Add(new Employee { Name = "Scott" });  // A new object with the same name so will be in set.
            
            Assert.True(numberSet.Count.Equals(1));
            Assert.True(employeeSet.Count.Equals(2));
        }

        [Fact]
        public void SetIntersectsWithAnotherSet()
        {
            var set1 = new HashSet<int> { 1, 2, 3 };
            var set2 = new HashSet<int> { 2, 3, 4 };

            // Leaves behind the items that were in both sets.
            set1.IntersectWith(set2);

            Assert.Equal(new[] { 2, 3 }, set1);
        }

        [Fact]
        public void SetUnionsWithAnotherSet()
        {
            var set1 = new HashSet<int> { 1, 2, 3, 6 };
            var set2 = new HashSet<int> { 2, 3, 4, 5 };

            // Joins a set with another set.
            set1.UnionWith(set2);

            Assert.True(set1.SetEquals(new[] { 1, 2, 3, 4, 5, 6 }));
        }

        [Fact]
        public void CanGetDifferencesOfSets()
        {
            var set1 = new HashSet<int> { 1, 2, 3, 6 };
            var set2 = new HashSet<int> { 2, 3, 4, 5 };
            var set3 = new HashSet<int> { 1, 2, 3 };
            var set4 = new HashSet<int> { 1, 2, 3 };

            // Returns the items in a set that do not exist in both.
            set1.SymmetricExceptWith(set2);
            set3.SymmetricExceptWith(set4);

            Assert.True(set1.SetEquals(new[] { 1, 4, 5, 6 }));
            Assert.True(set3.Count.Equals(0));
        }
    }
}