using System;
using System.Collections.Generic;

namespace CsLinq
{
    public class Program
    {
        public static IEnumerable<string> CitiesList = new[] { "Ghent", "London", "Las Vegas", "Hyderabad" };

        static void Main(string[] args)
        {
            ExtensionMethods.ExampleOne();
            ExtensionMethods.ExampleTwo();

            ExtensionsAndLambdas.ExampleOne();

            LambdasAndFuncs.ExampleOne();
            LambdasAndFuncs.ExampleTwo();
        }
    }
}
