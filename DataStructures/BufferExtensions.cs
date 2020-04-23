using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataStructures
{
    public static class BufferExtensions
    {
        public static void Dump<T>(this IBuffer<T> buffer)
        {
            foreach (var item in buffer)
            {
                Console.WriteLine($"{item} : {item.GetType()}");
            }
        }

        public static IEnumerable<TOut> AsEnumerableOf<T, TOut>(
            this IBuffer<T> buffer)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            foreach (var item in buffer)
            {
                var result = converter.ConvertTo(item, typeof(TOut));
                yield return (TOut)result;
            }
        }
    }
}