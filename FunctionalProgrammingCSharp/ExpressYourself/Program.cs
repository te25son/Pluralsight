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

            var range = new DateRange 
            { 
                Start = DateTime.Parse("2015-11-01"),
                End = DateTime.Parse("2015-11-06") 
            };

            testDates.ForEach(d => Console.WriteLine($"{d:yyy-MM-dd} - {range.DateIsInRange(d)}"));
            
            // The end date of our mutable type is changed, and the result of the line above changes.
            range.End = DateTime.MaxValue;

            testDates.ForEach(d => Console.WriteLine($"{d:yyy-MM-dd} - {range.DateIsInRange(d)}"));
        }
    }
}
