using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Extensions;

namespace CsLinq
{
    // All LINQ operators are defined as extensions methods
    // in the System.Linq namespace.

    public class ExtensionsAndLambdas : Program
    {
        public static void ExampleOne()
        {
            var query = CitiesList.Filter(c => c.StartsWith("L"));

            query.WriteForEach();
        }
    }
}
