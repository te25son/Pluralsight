using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class CircularBuffer<T> : Buffer<T>
    {
        int _capacity;
        
        public CircularBuffer(int capacity = 10)
        {
            _capacity = capacity;
        }

        public bool IsFull
        {
            get { return _queue.Count == _capacity;  }
        }

        public override void Write(T value)
        {
            base.Write(value);
            if (_queue.Count > _capacity)
            {
                var discard = _queue.Dequeue();  // Throws away first item;
                OneItemDiscarded(discard, value);
            }
        }

        public event EventHandler<ItemDiscardedEventArgs<T>> ItemDiscarded;

        private void OneItemDiscarded(T discard, T value)
        {
            if (ItemDiscarded != null)
            {
                var args = new ItemDiscardedEventArgs<T>(discard, value);
                ItemDiscarded(this, args);
            }
        }
    }

    public class ItemDiscardedEventArgs<T> : EventArgs
    {
        public ItemDiscardedEventArgs(T discard, T newItem)
        {
            ItemDiscarded = discard;
            NewItem = newItem;
        }

        public T ItemDiscarded { get; set; }
        public T NewItem { get; set; }
    }
}
