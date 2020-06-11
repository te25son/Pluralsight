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
            var comprehensionQuery =
                from city in CitiesList
                where city.StartsWith("L")
                where city.Length.Equals(6)
                select city;

            query.WriteForEach();
            comprehensionQuery.WriteForEach();
        }
    }
}
