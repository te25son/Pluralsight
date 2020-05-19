using System;
using System.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new CarCsvProcessor("fuel.csv");
            var cars = processor.List;
            var query = cars.OrderByDescending(c => c.Combined)
                            .ThenBy(c => c.Name);

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name} : {car.Combined}");
            }

            FilterBySpecificManufacturer();
            FilterOperatorsThatReturnBoolean();
        }

        public static void FilterBySpecificManufacturer()
        {
            var processor = new CarCsvProcessor("fuel.csv");
            var query = processor.List.Where(c => c.Manufacturer.Equals("BMW") && c.Year.Equals(2016))
                                      .OrderByDescending(c => c.Combined)
                                      .ThenBy(c => c.Name);

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Manufacturer} {car.Name} : {car.Combined}");
            }

            Console.WriteLine(query.First().Name);  // Gets the first element of the sequence.
            Console.WriteLine(query.FirstOrDefault().Name);  // Gets the first element of the sequence or returns a default value for the type if the sequence is empty.

        }

        public static void FilterOperatorsThatReturnBoolean()
        {
            var processor = new CarCsvProcessor("fuel.csv");
            // Because these operators return a boolean they do not offer deferred execution.

            var result = processor.List.Any(  // Do any cars have a manufacturer named Ford?
                c => c.Manufacturer.Equals("Ford")
            );
            var result2 = processor.List.All(  // Do all cars have a manufacturer named Ford?
                c => c.Manufacturer.Equals("Ford")
            );

            Console.WriteLine(result);
            Console.WriteLine(result2);
        }
    }
}
