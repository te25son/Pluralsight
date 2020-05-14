using System;
using System.Collections.Generic;
using System.Linq;

namespace Queries
{
    class Program
    {
        public static List<Movie> _movies = new List<Movie>
        {
            new Movie { Title = "The Dark Knight", Rating = 8.9f, Year = 2008 },
            new Movie { Title = "The King's Speech", Rating = 8.0f, Year = 2010 },
            new Movie { Title = "Casablanca", Rating = 8.5f, Year = 1942 },
            new Movie { Title = "Star Wars V", Rating = 8.7f, Year = 1980 }
        };

        static void Main(string[] args)
        {
            DeferredExecutionPitfall();
        }

        public static void DeferredExecutionPitfall()
        {
            var query = _movies.Filter(m => m.Year >= 2000);
            //var query = _movies.Filter(m => m.Year >= 2000).ToList();
            var enumerator = query.GetEnumerator();

            Console.WriteLine(query.Count());  // This will cause the query to run twice.
                                               // Once to get the count, and again during the while loop below.
                                               // To avaoid this pitfall, call .ToList or ToArray at the end of your query.
                                               // This will trigger the query once so you can use it later.

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }
        }
    }
}
