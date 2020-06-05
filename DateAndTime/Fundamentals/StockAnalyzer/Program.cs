using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace StockAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            UseCultureInfo();
            ConvertBetweenTimeZones();
            Offset();
        }

        public static void UseCultureInfo()
        {
            var lines = File.ReadAllLines(@"StockData.csv");

            foreach (var line in lines.Skip(1))
            {
                var segments = line.Split(',');
                var tradeDate = DateTime.Parse(segments[1]);  // DateTime uses our current system settings.
                var tradeDateWithCulture = DateTime.Parse(segments[1], CultureInfo.GetCultureInfo("en-US"));  // Overload method can get date and time from other cultures.

                Console.WriteLine("Local Time:");
                Console.WriteLine("\t" + tradeDate.ToLongDateString());
                Console.WriteLine("USA Time:");
                Console.WriteLine("\t" + tradeDateWithCulture.ToLongDateString());
            }
        }

        public static void ConvertBetweenTimeZones()
        {
            var now = DateTime.Now;
            var sydneyTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. Australia Standard Time");
            var sydneyTime = TimeZoneInfo.ConvertTime(now, sydneyTimeZone);

            Console.WriteLine(now);
            Console.WriteLine(sydneyTime);
        }

        public static void Offset()
        {
            // DateTimeOffset provides us with information on the date and time
            // as well as the timezone which the date and time were created for.

            var timeWithOffeset = DateTimeOffset.Now;

            Console.WriteLine(DateTime.Now);
            Console.WriteLine(timeWithOffeset);

            // Displays all timezones which are equal to the current system's timezone
            // without taking daylight savings into consideration.
            foreach (var timeZone in TimeZoneInfo.GetSystemTimeZones())
            {
                if (timeZone.GetUtcOffset(timeWithOffeset) == timeWithOffeset.Offset)
                {
                    Console.WriteLine(timeZone);
                }
            }
        }
    }
}
