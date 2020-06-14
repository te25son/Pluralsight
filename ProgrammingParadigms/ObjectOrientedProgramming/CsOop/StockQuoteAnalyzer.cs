using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace CsOop
{
    public class StockQuoteAnalyzer
    {
        readonly string FilePath;
        readonly List<DateTime> Dates = new List<DateTime>();
        readonly List<decimal> Opens = new List<decimal>();
        readonly List<decimal> Highs = new List<decimal>();
        readonly List<decimal> Lows = new List<decimal>();
        readonly List<decimal> Closes = new List<decimal>();

        public StockQuoteAnalyzer(string filePath)
        {
            FilePath = filePath;
        }

        public void LoadQuotes()
        {
            var lines = File.ReadAllLines(FilePath);
            for (int i = 1; i < lines.Length; i++)
            {
                var data = lines[i].Split(',');
                Dates.Add(DateTime.Parse(data[0], CultureInfo.InvariantCulture));
                Opens.Add(decimal.Parse(data[1]));
                Highs.Add(decimal.Parse(data[2]));
                Lows.Add(decimal.Parse(data[3]));
                Closes.Add(decimal.Parse(data[4]));
            }
        }

        public void AnalyzeQuotes()
        {
            for (int i = 0; i < Dates.Count - 1; i++)
            {
                if (Opens[i] > Highs[i + 1] && Closes[i] < Lows[i + 1])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Pivot downside {Dates[i].ToShortDateString()}");
                }
                if (Opens[i] < Lows[i + 1] && Closes[i] > Highs[i + 1])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Pivot upside {Dates[i].ToShortDateString()}");
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
