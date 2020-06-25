using System;
using System.Collections.Generic;
using System.Linq;

namespace WhatIsFP
{
    public static class FuncstionsAsData
    {
        public static void Run()
        {
            var oneToTen = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var elevenToTwenty = new List<int> { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            
            oneToTen.RemoveUneven();

            // Using LINQ expression methods will not mutate the list.
            // Instead creates a new IEnumberable<T> that can safely be referenced
            // if needed.
            var onlyEvens =
                elevenToTwenty.Where(x => x % 2 == 0).OrderBy(x => x);

            oneToTen.WriteEach();
            onlyEvens.WriteEach();
        }

        private static void RemoveUneven(this List<int> enumerable)
        {
            // This method mutates the original list.

            var counter = 0;
            while (counter < enumerable.Count)
            {
                if (enumerable[counter] % 2 != 0)
                {
                    enumerable.RemoveAt(counter);
                }
                else
                {
                    counter++;
                }
            }
        }

        private static void WriteEach<T>(this IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                Console.WriteLine(item);
            }
        }
    }
}
