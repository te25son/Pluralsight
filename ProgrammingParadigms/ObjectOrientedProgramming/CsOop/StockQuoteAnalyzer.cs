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

    public class StockQuoteFileLoader : StockQuoteLoader
    {
        private readonly string FilePath;

        public StockQuoteFileLoader(string filePath)
        {
            FilePath = filePath;
        }

        protected override string[] GetData()
        {
            return File.ReadAllLines(FilePath);
        }
    }

    public class StockQuoteWebLoader : StockQuoteLoader
    {
        private readonly string Url;

        public StockQuoteWebLoader(string url)
        {
            Url = url;
        }

        protected override string[] GetData()
        {
            var client = new WebClient();
            return client.DownloadString(new Uri(Url)).Split('\n');
        }
    }

    public abstract class StockQuoteLoader
    {
        protected abstract string[] GetData();

        public IEnumerable<StockQuote> Load()
        {
            return GetData().Skip(1)
                       .Select(l => l.Replace("-", "/").Split(','))
                       .Where(i => i[0].Length > 0)
                       .Select(i =>
                           new StockQuote()
                           {
                               Date = DateTime.Parse(i[0], CultureInfo.InvariantCulture),
                               Open = decimal.Parse(i[1]),
                               High = decimal.Parse(i[2]),
                               Low = decimal.Parse(i[3]),
                               Close = decimal.Parse(i[4]),
                           }
                       );
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
        private readonly StockQuoteLoader Loader;
        private readonly List<StockQuote> Quotes;

        public StockQuoteAnalyzer(string urlOrFilePath)
        {
            if (urlOrFilePath.ToLower().StartsWith("http"))
            {
                Loader = new StockQuoteWebLoader(urlOrFilePath);
            }
            else
            {
                Loader = new StockQuoteFileLoader(urlOrFilePath);
            }
            Quotes = Loader.Load().ToList();
        }

        public IEnumerable<Reversal> FindReversals()
        {
            var locator = new ReversalLocator(Quotes);
            return locator.Locate();
        }
    }
}
