using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace CsOop
{
    // Small Abstractions are good abstractions, because they focus
    // on one thing and do it well.

    public class StockQuote
    {
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }

        public bool ReversesDownFrom(StockQuote otherQuote)
        {
            return Open > otherQuote.High && Close < otherQuote.Low;
        }

        public bool ReversesUpFrom(StockQuote otherQuote)
        {
            return Open < otherQuote.Low && Close > otherQuote.High;
        }
    }

    public interface IDataLoader
    {
        string LoadData();
    }

    public class FileLoader : IDataLoader
    {
        private readonly string FilePath;

        public FileLoader(string filePath)
        {
            FilePath = filePath;
        }

        public string LoadData()
        {
            return File.ReadAllText(FilePath);
        }
    }

    public class WebLoader : IDataLoader
    {
        private readonly string Url;

        public WebLoader(string url)
        {
            Url = url;
        }

        public string LoadData()
        {
            var client = new WebClient();
            return client.DownloadString(new Uri(Url));
        }
    }

    public class StockQuoteCsvParser
    {
        IDataLoader Loader;

        public StockQuoteCsvParser(string source)
        {
            if (source.ToLower().StartsWith("HTTP"))
            {
                Loader = new WebLoader(source);
            }
            else
            {
                Loader = new FileLoader(source);
            }
        }

        public IEnumerable<StockQuote> Load()
        {
            var csvData = Loader.LoadData().Split('\n');

            return
                from line in csvData.Skip(1)
                let data = line.Replace("-", "/").Split(',')
                where data[0].Length > 0
                select new StockQuote()
                {
                    Date = DateTime.Parse(data[0], CultureInfo.InvariantCulture),
                    Open = decimal.Parse(data[1]),
                    High = decimal.Parse(data[2]),
                    Low = decimal.Parse(data[3]),
                    Close = decimal.Parse(data[4])
                };
        }
    }

    public enum ReversalDirection
    {
        Up,
        Down
    }

    public class Reversal
    {
        public Reversal(StockQuote quote, ReversalDirection direction)
        {
            StockQuote = quote;
            Direction = direction;
        }

        public ReversalDirection Direction { get; set; }
        public StockQuote StockQuote { get; set; }
    }

    public class ReversalLocator
    {
        private readonly IList<StockQuote> Quotes;

        public ReversalLocator(IList<StockQuote> quotes)
        {
            Quotes = quotes;
        }

        public IEnumerable<Reversal> Locate()
        {
            for (int i = 0; i < Quotes.Count - 1; i++)
            {
                if (Quotes[i].ReversesDownFrom(Quotes[i + 1]))
                {
                    yield return new Reversal(Quotes[i], ReversalDirection.Down);
                }
                if (Quotes[i].ReversesUpFrom(Quotes[i + 1]))
                {
                    yield return new Reversal(Quotes[i], ReversalDirection.Up);
                }
            }
        }
    }

    public class StockQuoteAnalyzer
    {
        private readonly StockQuoteCsvParser Loader;
        private readonly List<StockQuote> Quotes;

        public StockQuoteAnalyzer(string urlOrFilePath)
        {
            Loader = new StockQuoteCsvParser(urlOrFilePath);
            Quotes = Loader.Load().ToList();
        }

        public IEnumerable<Reversal> FindReversals()
        {
            var locator = new ReversalLocator(Quotes);
            return locator.Locate();
        }
    }
}
