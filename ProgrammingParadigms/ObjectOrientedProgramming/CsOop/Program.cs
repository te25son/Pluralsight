using System;

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
            foreach (var reversal in analyzer.FindReversals())
            {
                PrintReversal(reversal);
            }
        }

        private static void PrintReversal(Reversal reversal)
        {
            if (reversal.Direction.Equals(ReversalDirection.Up))
            {
                Console.WriteLine($"Pivot upside {reversal.StockQuote.Date}");
            }
            if (reversal.Direction.Equals(ReversalDirection.Down))
            {
                Console.WriteLine($"Pivot downside {reversal.StockQuote.Date}");

            }
        }
    }
}
