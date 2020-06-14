using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CsOop
{
    public class StockQuoteCsvParser
    {
        readonly IDataLoader Loader;

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
}
