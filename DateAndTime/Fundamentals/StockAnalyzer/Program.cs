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

        }
    }
}
