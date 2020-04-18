using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public interface IBuffer<T>
    {
        bool IsEmpty { get; }
        void Write(T value);
        T Read();
    }
}
