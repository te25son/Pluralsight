using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFunc
{
    public static class AsynchAndParallel
    {
        public static void Example()
        {
            var timeKeeper = new TimeKeeper();
            var elapsed = timeKeeper.Measure(() => FindLargePrimesInParallel(900000, 1000000));
            Console.WriteLine(elapsed);
        }

        private static IList<int> FindLargePrimes(int start, int end)
        {
            var primes = Enumerable.Range(start, end - start).ToList();
            return primes.Where(IsPrime).ToList();
        }

        private static IList<int> FindLargePrimesInParallel(int start, int end)
        {
            // AsParallel splits the invokable methods across multiple threads.
            var primes = Enumerable.Range(start, end - start).ToList();
            return primes.AsParallel().Where(IsPrime).ToList();
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
    }
}
