using System.Collections.Generic;
using System.Linq;

namespace CsOop
{
    public class StockQuoteAnalyzer
    {
        private readonly List<StockQuote> Quotes;

        public StockQuoteAnalyzer(StockQuoteCsvParser parser)
        {
            Quotes = parser.ParseQuotes().ToList();
        }

        public IEnumerable<Reversal> FindReversals()
        {
            var locator = new ReversalLocator(Quotes);
            return locator.Locate();
        }
    }
}
