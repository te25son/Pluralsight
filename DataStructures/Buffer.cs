using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class Buffer<T> : IBuffer<T>
    {
        Queue<T> _queue = new Queue<T>();

        public bool IsEmpty
        {
            get { return _queue.Count == 0; }
        }

        public T Read()
        {
            return _queue.Dequeue();
        }

        public void Write(T value)
        {
            _queue.Enqueue(value);
        }
    }
}
