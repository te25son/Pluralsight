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
            // The code has been abstracted (encapsulation) so that you do not have to understand the intricacies
            // of the underlying code.
            // This is similar to a driver getting into a car without understanding exactly how
            // the engine operates.

            var analyzer = new StockQuoteAnalyzer("msft.csv");
            analyzer.LoadQuotes();
            analyzer.AnalyzeQuotes();
        }
    }
}
