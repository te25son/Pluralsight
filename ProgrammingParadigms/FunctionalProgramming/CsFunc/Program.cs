using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CsFunc
{
    static class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 3, 5, 7, 9, 11, 13 };

            //foreach (var prime in numbers.Find(IsPrime))
            //{
            //    Console.WriteLine(prime);
            //}
 
            //foreach (var even in numbers.Find(IsEven))
            //{
            //    Console.WriteLine(even);
            //}

            foreach (var prime in GetRandomNumbers().Find(IsPrime).Take(2))
            {
                Console.WriteLine(prime);
            }
        }

        private static IEnumerable<int> GetRandomNumbers()
        {
            var rand = new Random();
            while (true)
            {
                // yield return forces the code to return at the last possible moment.
                // this is called lazy code.
                yield return rand.Next(1000);
            }
        }

        private static IEnumerable<int> Find(this IEnumerable<int> values, Predicate<int> predicate)
        {
            foreach (var value in values)
            {
                Console.WriteLine($"Testing {value}");
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
