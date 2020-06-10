using System;
using System.Collections.Generic;

namespace CsLinq
{
    // Extension Method:
    // Method that looks like it's a method of a given type,
    // but in reality it's just a static method of a different type.

    class Program
    {
        static void Main(string[] args)
        {
            var date = new DateTime(2002, 8, 9);
            var daysTillEndOfMonth = date.DaysToEndOfMonth();

            Console.WriteLine(daysTillEndOfMonth);
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
