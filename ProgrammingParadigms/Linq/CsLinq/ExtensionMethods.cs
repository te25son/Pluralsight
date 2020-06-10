using Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsLinq
{
    public class ExtensionMethods
    {
        // Extension Method:
        // Method that looks like it's a method of a given type,
        // but in reality it's just a static method of a different type.

        public static void ExampleOne()
        {
            var date = new DateTime(2002, 8, 9);
            var daysTillEndOfMonth = date.DaysToEndOfMonth();

            Console.WriteLine(daysTillEndOfMonth);
        }

        public static void ExampleTwo()
        {
            var cities = new[] { "Ghent", "London", "Las Vegas", "Hyderabad" };
            var query = cities.StringsThatStartWith("L");

            foreach (var city in query)
            {
                Console.WriteLine(city);
            }
        }
    }

    public static class DateUtilities
    {
        // The 'this' keyword makes this an extension method
        // of a DateTime object.
        public static int DaysToEndOfMonth(this DateTime date)
        {
            return DateTime.DaysInMonth(date.Year, date.Month) - date.Day;
        }
    }
}

namespace Extensions
{
    public static class FilterExtensions
    {
        public static IEnumerable<string> StringsThatStartWith(this IEnumerable<string> input, string start)
        {
            foreach (var s in input)
            {
                if (s.StartsWith(start))
                {
                    // 'yield return' generates an Ienumerable in the background.
                    yield return s;
                }
            }
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> input, Predicate<T> predicate)
        {
            foreach (var item in input)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static void WriteForEach<T>(this IEnumerable<T> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine(item);
            }
        }
    }
}
