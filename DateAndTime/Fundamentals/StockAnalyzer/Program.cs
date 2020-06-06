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
            ParsingDates();
            FormatDates();
            WorkingWithUtc();
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

        public static void ParsingDates()
        {
            var date = "9/10/2019 10:00:00 PM";
            var parsedDate = DateTime.ParseExact(date, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            
            Console.WriteLine(parsedDate);

            var date2 = "2019-07-01 10:00:00 PM +02:00";
            var parsedDate2 = DateTime.Parse(date2, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);

            Console.WriteLine(parsedDate2);
        }

        public static void FormatDates()
        {
            var date = "9/10/2019 10:00:00 PM";
            var parsedDate = DateTimeOffset.ParseExact(date, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            parsedDate = parsedDate.ToOffset(TimeSpan.FromHours(10));  // Now has 10 hour offset from UTC.
            var formattedDate = parsedDate.ToString("o");  // Converts time to ISO 8601 standard.

            Console.WriteLine(formattedDate);
        }

        public static void WorkingWithUtc()
        {
            var now = DateTimeOffset.UtcNow;  // DateTimeOffset displayes the UTC offset
            var nowNoOffset = DateTime.UtcNow;  // DateTime does not display the UTC offset

            Console.WriteLine($"Utc now with DateTimeOffset looks like - {now}");
            Console.WriteLine($"Utc now with DateTime looks like - {nowNoOffset}");

            var localTime = now.ToLocalTime();
            var universalTime = localTime.ToUniversalTime();

            Console.WriteLine(localTime);
            Console.WriteLine(universalTime);
        }
    }
}
