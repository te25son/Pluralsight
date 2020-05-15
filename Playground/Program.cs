using System;
using System.Collections.Generic;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var study = new Study();
            var results = new List<int>
            {
                // Uses the same method but returns a different result.

                study.MultiplyByActionResult(2, (x, y) => x + y),  // Multiply 2 by (2 + 2)
                study.MultiplyByActionResult(2, (x, y) => x - y),  // Multiply 2 by (2 - 2)
                study.MultiplyByActionResult(2, (x, y) => x * y),  // Multiply 2 by (2 * 2)
                study.MultiplyByActionResult(2, (x, y) => x / y),  // Multiply 2 by (2 / 2)
            };

            WriteCollection(results);
            WriteCollectionCompared(results, x => x > 5);  // Write the items of the collection if the item is greater than 5.
            WriteCollectionCompared(results, x => x < 5);  // Write the items of the collection if the item is less than 5.
        }

        public static void WriteCollection<T>(List<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public static void WriteCollectionCompared<T>(List<T> list, Predicate<T> expression)
        {
            // Iterate through the list.
            foreach (var item in list)
            {
                // Check if the item in the list matches the expression.
                //
                // This expression is a method that takes a single parameter
                // and returns true or false.
                if (expression(item))
                {
                    // Write the item to the console.
                    Console.WriteLine(item);
                }
            }
        }
    }
}
