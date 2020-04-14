using System.Collections.Generic;
using Xunit;

namespace GenericCollections.Tests
{
    public class StackTests
    {
        [Fact]
        public void FirstObjectInIsLastOut()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.Equal(3, stack.Peek());
        }

        [Fact]
        public void PopRemovesObjectFromStack()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();

            Assert.Equal(2, stack.Count);
            Assert.False(stack.Contains(3));
        }

        [Fact]
        public void StackCanBeConvertedToArray()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            var toArray = stack.ToArray();
            stack.Pop();

            // When converting to an array, a stack is copied
            // in the order the elements would naturally come out.
            // Therefore, the first element of the array will be 3
            // because 3 is the last element in the stack and a stack
            // is a LIFO (Last In First Out) data structure.
            Assert.Equal(3, toArray[0]);
            Assert.Equal(3, toArray.Length);
            Assert.Equal(2, stack.Count);
        }
    }
}