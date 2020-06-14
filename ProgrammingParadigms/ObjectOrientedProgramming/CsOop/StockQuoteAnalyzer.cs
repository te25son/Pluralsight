using System.Collections.Generic;
using System.Linq;

namespace CsOop
{
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
