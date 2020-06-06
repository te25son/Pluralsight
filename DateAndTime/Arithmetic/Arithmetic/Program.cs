using System;
using System.Globalization;

namespace Arithmetic
{
    class Program
    {
        static void Main(string[] args)
        {
            var timeSpan = new TimeSpan(60, 100, 200);

            Console.WriteLine(timeSpan.Days);
            Console.WriteLine(timeSpan.Hours);
            Console.WriteLine(timeSpan.Minutes);
            Console.WriteLine(timeSpan.Seconds);

            var start = DateTimeOffset.UtcNow;
            var end = start.AddSeconds(45);
            var difference = end - start;

            Console.WriteLine(difference.TotalMinutes);
        }
    }
}
