using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DataStructures
{
    public static class BufferExtensions
    {
        public static void Dump<T>(this IBuffer<T> buffer, Action<T> print)
        {
            foreach (var item in buffer)
            {
                print(item);
            }
        }

        public static IEnumerable<TOut> Map<T, TOut>(
            this IBuffer<T> buffer, Converter<T, TOut> converter)
        {
            return buffer.Select(i => converter(i));
        }
    }
}