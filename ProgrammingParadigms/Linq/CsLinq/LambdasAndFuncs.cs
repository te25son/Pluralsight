using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsLinq
{
    // Func is a generic type that encapsulates delegates, i.e. encapsulates
    // callable code.

    public class LambdasAndFuncs : Program
    {
        public static void ExampleOne()
        {
            // Function that takes an int and returns an int.
            Func<int, int> square = x => x * x;

            // Function that takes two ints and returns a bool.
            Func<int, int, bool> areEqual = (x, y) => x.Equals(y);
            
            Console.WriteLine(square(2));
            Console.WriteLine(areEqual(2, 3));
        }

        public static void ExampleTwo()
        {
            var query = CitiesList.Where(c => c.StartsWith("L"))
                                  .OrderByDescending(c => c.Length);

            var comprehensionQuery =
                from city in CitiesList
                where city.StartsWith("L")
                orderby city.Length descending
                select city;

            query.WriteForEach();
            comprehensionQuery.WriteForEach();
        }
    }
}
