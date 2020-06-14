using System;
using System.Collections;
using System.Collections.Generic;

namespace CsFunc
{
    static class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 3, 5, 7, 9, 11, 13 };

            foreach (var prime in numbers.Find(IsPrime))
            {
                Console.WriteLine(prime);
            }

            foreach (var even in numbers.Find(IsEven))
            {
                Console.WriteLine(even);
            }
        }

        private static IEnumerable<int> Find(this IEnumerable<int> values, Predicate<int> predicate)
        {
            foreach (var value in values)
            {
                if (predicate(value))
                {
                    yield return value;
                }
            }
        }

        private static bool IsPrime(this int number)
        {
            var result = true;
            for (long i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        private static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }
    }
}
