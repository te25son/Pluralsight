using System.Collections.Generic;
using Xunit;

namespace GenericCollections.Tests
{
    public class QueueTests
    {
        [Fact]
        public void FirstObjectInIsFirstOut()
        {
            var queue = new Queue<Employee>();
            queue.Enqueue(new Employee { Name = "Frodo" });
            queue.Enqueue(new Employee { Name = "Sam" });
            queue.Enqueue(new Employee { Name = "Gandalf" });

            // Peek gets the first element from the queue but does not remove it.
            var firstEmployee = queue.Peek();

            Assert.Equal("Frodo", firstEmployee.Name);
        }

        [Fact]
        public void DequeueRemovesObjectFromQueue()
        {
            var queue = new Queue<Employee>();
            queue.Enqueue(new Employee { Name = "Frodo" });
            queue.Enqueue(new Employee { Name = "Sam" });

            var firstEmployee = queue.Dequeue();

            Assert.False(queue.Contains(firstEmployee));
            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void CanConvertQueueToArray()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            // The created array is a copy of the queue.
            var asArray = queue.ToArray();
            queue.Dequeue();

            Assert.Equal(1, asArray[0]);
            Assert.Equal(2, queue.Count);
            Assert.Equal(2, queue.Peek());
        }
    }
}