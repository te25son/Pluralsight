using System;
using System.Globalization;

namespace Arithmetic
{
    class Program
    {
        static Calendar calendar = CultureInfo.InvariantCulture.Calendar;

        static void Main(string[] args)
        {
            DifferenceBetweenDates();
            GetWeekNumber();
            ExtendingDates();
        }

        static void DifferenceBetweenDates()
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

        static void GetWeekNumber()
        {
            var start = new DateTimeOffset(2007, 12, 31, 0, 0, 0, TimeSpan.Zero);
            var week = calendar.GetWeekOfYear(start.DateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            Console.WriteLine(week);

            var isoWeek = ISOWeek.GetWeekOfYear(start.DateTime);

            Console.WriteLine(isoWeek);
        }

        static void ExtendingDates()
        {
            var contractDate = new DateTimeOffset(2019, 7, 1, 0, 0, 0, TimeSpan.Zero);

            Console.WriteLine(contractDate);

            contractDate = contractDate.AddMonths(6);

            Console.WriteLine(contractDate);
        }
    }
}
