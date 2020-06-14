using System.Collections.Generic;

namespace CsOop
{
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
}
