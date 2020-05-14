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
            //DeferredExecutionPitfall();
            //DeferredExecutionWithExceptions();
        }

        public static void StreamingOperators()
        {
            // A streaming operator only needs to read through the source data
            // like the sequence of movies up until the point that it produces a result.
            // At that point, it will yield the result and jump out of the method so
            // we can process that single item.

            var query = _movies.Where(m => m.Year >= 2000) // Where is a streaming method.
                               .OrderByDescending(m => m.Rating);  // OrderByDescending is not a streaming method.
        }

        public static void DeferredExecutionWithExceptions()
        {
            // Set up Movie to throw an exception when it gets the Year.
            var query = Enumerable.Empty<Movie>();

            try
            {
                query = _movies.Where(m => m.Year >= 2000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(query.Count());  // The error is triggered here because the where method
                                               // is not called until this point. 
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
