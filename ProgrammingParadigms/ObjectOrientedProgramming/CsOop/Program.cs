using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CsOop
{
    class Program
    {
        // Big Three:
        // Encapsulation - allows us to build abstractions by hiding details.
        // Iheritance
        // Polymorphism
        static void Main(string[] args)
        {
            var date = new List<DateTime>();
            var open = new List<decimal>();
            var high = new List<decimal>();
            var low = new List<decimal>();
            var close = new List<decimal>();

            var lines = File.ReadAllLines("msft.csv");
            for (int i = 1; i < lines.Length; i++)
            {
                var data = lines[i].Split(',');
                date.Add(DateTime.Parse(data[0], CultureInfo.InvariantCulture));
                open.Add(decimal.Parse(data[1]));
                high.Add(decimal.Parse(data[2]));
                low.Add(decimal.Parse(data[3]));
                close.Add(decimal.Parse(data[4]));
            }

            for (int i = 0; i < date.Count - 1; i++)
            {
                if (open[i] > high[i + 1] && close[i] < low[i + 1])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Pivot downside {date[i].ToShortDateString()}");
                }
                if (open[i] < low[i + 1] && close[i] > high[i + 1])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Pivot upside {date[i].ToShortDateString()}");
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
