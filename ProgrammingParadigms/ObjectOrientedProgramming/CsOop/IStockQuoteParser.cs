using System;
using System.Collections.Generic;
using System.Text;

namespace CsOop
{
    public interface IStockQuoteParser
    {
        IList<StockQuote> ParseQuotes();
    }
}
