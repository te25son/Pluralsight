using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;

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

            //var timeKeeper = new TimeKeeper();
            //var elapsed = timeKeeper.Measure(() =>
            //{
            //    foreach (var prime in GetRandomNumbers().Find(IsPrime).Take(2))
            //    {
            //        Console.WriteLine(prime);
            //    }
            //});
            //Console.WriteLine(elapsed);

            //var url = "http://microsoft.com";
            //var client = new WebClient();
            //Func<string, string> download = url => client.DownloadString(url);
            //Func<string, Func<string>> downloadCurry = download.Curry();

            //var data = download.Partial(url).WithRetry();
            //var data2 = downloadCurry(url).WithRetry();

            //Func<int, int, int, int, int> addFourThings = (a, b, c, d) => a + b + c + d;

            //var curry = new CurryOverloads();
            //var curriedFourThings = curry.Curry(addFourThings);
            //var result = curriedFourThings(1)(2)(3)(4);

            //Console.WriteLine(result);

            AsynchAndParallel.Example();
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

        private static void MoreCurry()
        {
            // An anonymous delegate that takes two ints and returns an int.
            Func<int, int, int> add = (x, y) => x + y;
            int a = add(2, 3);
            Console.WriteLine(a);

            // An anonymous delegate that takes an int and returns an anonymous delegate
            // that also takes and int and returns an int.
            Func<int, Func<int, int>> curriedAdd = x => y => x + y;
            int b = curriedAdd(2)(3);

            // Creates an anonymous delegate that takes an int and adds 5 to it.
            var add5 = curriedAdd(5);
            Console.WriteLine(add5(3));
            Console.WriteLine(add5(2));
        }
    }
}
