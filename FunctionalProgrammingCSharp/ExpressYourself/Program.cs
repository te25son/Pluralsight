using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;

namespace ExpressYourself
{
    class Program
    {
        static void Main(string[] args)
        {
            WhyImmutibilityMatters();
        }

        static void WhyImmutibilityMatters()
        {
            var testDates =
                new List<DateTime>
                {
                    DateTime.Parse("2015-11-03"),
                    DateTime.Parse("2015-11-01"),
                    DateTime.Parse("2015-10-01"),
                    DateTime.Parse("2015-12-01"),
                };

            var range = new DateRange(DateTime.Parse("2015-11-01"), DateTime.Parse("2015-11-06"));

            testDates.ForEach(d => Console.WriteLine($"{d:yyy-MM-dd} - {range.DateIsInRange(d)}"));

            var range2 = new DateRange(range.Start, DateTime.MaxValue);

            testDates.ForEach(d => Console.WriteLine($"{d:yyy-MM-dd} - {range2.DateIsInRange(d)}"));

            var range3 = range.Slide(7);

            testDates.ForEach(d => Console.WriteLine($"{d:yyy-MM-dd} - {range3.DateIsInRange(d)}"));
        }
    }
}
