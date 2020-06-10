using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Extensions;

namespace CsLinq
{
    // All LINQ operators are defined as extensions methods
    // in the System.Linq namespace.

    public class ExtensionsAndLambdas
    {
        public static void ExampleOne()
        {
            var cities = new[] { "Ghent", "London", "Las Vegas", "Hyderabad" };
            var query = cities.Filter(c => c.StartsWith("L"));

            query.WriteForEach();
        }
    }
}
