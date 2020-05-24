using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            //var processor = new CarCsvProcessor("fuel.csv");
            //var cars = processor.List;
            //var query = cars.OrderByDescending(c => c.Combined)
            //                .ThenBy(c => c.Name);

            //foreach (var car in query.Take(10))
            //{
            //    Console.WriteLine($"{car.Name} : {car.Combined}");
            //}

            //FilterBySpecificManufacturer();
            //FilterOperatorsThatReturnBoolean();
            //JoinData();
            //GroupData();
            //GroupJoinData();
            MostFuelEfficientCarsByCountry();
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

        public static void ProjectingData()
        {
            var processor = new CarCsvProcessor("fuel.csv");

            // You can project data from a large data source to a new anonymous class.
            // This will allow you save space if you decide you don't want to use
            // everything in the larger data set.
            //
            // For example...

            var query = processor.List.Select(
                c => new { c.Manufacturer, c.Name, c.Combined }  // Converts data to an anonymous data type that just has 3 properties.
            );

            foreach (var car in query)
            {
                Console.WriteLine($"{car.Manufacturer} {car.Name} : {car.Combined}");
            }
        }

        public static void FlattenData()
        {
            var processor = new CarCsvProcessor("fuel.csv");
            var carNames = processor.List.Select(c => c.Name);

            foreach (var name in carNames)
            {
                foreach (var character in name)
                {
                    Console.WriteLine(character);
                }
            }

            var carNameCharacters = processor.List.SelectMany(c => c.Name); // Iterates over nested sequences.

            WriteEnumerable(carNameCharacters);
        }

        public static void JoinData()
        {
            var carProcessor = new CarCsvProcessor("fuel.csv");
            var cars = carProcessor.List;
            var manufacturers = ProcessManufacturersFromCsv("manufacturers.csv");

            // Using query syntax
            var query =
                from car in cars
                join manufacturer in manufacturers
                    on car.Manufacturer equals manufacturer.Name
                orderby car.Combined descending, car.Name ascending
                select new
                {
                    manufacturer.Headquarters,
                    car.Name,
                    car.Combined
                };

            // Using method syntax
            var method =
                cars.Join(
                    inner: manufacturers,
                    outerKeySelector: c => c.Manufacturer,  // Value that linq will join on.
                    innerKeySelector: m => m.Name,  // Value that will match a car with a manufacturer.
                    resultSelector: (c, m) => new  // Projects two objects that have been joined together and puts them into one.
                    {
                        m.Headquarters,
                        c.Name,
                        c.Combined
                    })
                    .OrderByDescending(c => c.Combined)
                    .ThenBy(c => c.Name);

            WriteEnumerable(query.Select(c => c.Name));
            WriteEnumerable(method.Select(c => c.Name));
        }

        public static void JoinOnMultipleObjects()
        {
            var carProcessor = new CarCsvProcessor("fuel.csv");
            var cars = carProcessor.List;
            var manufacturers = ProcessManufacturersFromCsv("manufacturers.csv");

            // Using query syntax
            var query =
                from car in cars
                join manufacturer in manufacturers
                    on new { car.Manufacturer, car.Year } 
                        equals 
                        new { Manufacturer = manufacturer.Name, manufacturer.Year }  // The property names must be the same in each new object (Manufacturer & Year).
                orderby car.Combined descending, car.Name ascending
                select new
                {
                    manufacturer.Headquarters,
                    car.Name,
                    car.Combined
                };

            // Using method syntax
            var method =
                cars.Join(
                    inner: manufacturers,
                    outerKeySelector: c => new { c.Manufacturer, c.Year },  // Value that linq will join on.
                    innerKeySelector: m => new { Manufacturer = m.Name, m.Year },  // Value that will match a car with a manufacturer.
                    resultSelector: (c, m) => new  // Projects two objects that have been joined together and puts them into one.
                    {
                        m.Headquarters,
                        c.Name,
                        c.Combined
                    })
                    .OrderByDescending(c => c.Combined)
                    .ThenBy(c => c.Name);
        }

        public static void GroupData()
        {
            var cars = ProcessCarsFromCsv("fuel.csv");
            var manufacturers = ProcessManufacturersFromCsv("manufacturers.csv");

            var query =
                from car in cars
                group car by car.Manufacturer.ToUpper() into manufacturer
                orderby manufacturer.Key
                select manufacturer;

            var method =
                cars.GroupBy(c => c.Manufacturer.ToUpper())
                    .OrderBy(g => g.Key);

            foreach (var group in query)
            {
                Console.WriteLine(group.Key);
                foreach (var car in group.OrderByDescending(c => c.Combined).Take(2))
                {
                    Console.WriteLine($"\t{car.Name} : {car.Combined}");
                }
            }
        }

        public static void GroupJoinData()
        {
            var cars = ProcessCarsFromCsv("fuel.csv");
            var manufacturers = ProcessManufacturersFromCsv("manufacturers.csv");

            var query =
                from manufacturer in manufacturers  // Use the manufacturer object to group cars underneath of.
                join car in cars on manufacturer.Name equals car.Manufacturer
                    into carGroup
                orderby manufacturer.Name
                select new
                {
                    Manufacturer = manufacturer,
                    Cars = carGroup
                };

            var method =
                manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer, (m, g) =>
                    new
                    {
                        Manufacturer = m,
                        Cars = g
                    })
                .OrderBy(m => m.Manufacturer.Name);

            foreach (var group in method)
            {
                Console.WriteLine($"{group.Manufacturer.Name} : {group.Manufacturer.Headquarters}");
                foreach (var car in group.Cars.Take(2))
                {
                    Console.WriteLine($"\t{car.Name} : {car.Combined}");
                }
            }
        }

        public static void MostFuelEfficientCarsByCountry()
        {
            // Finds the most fuel efficient cars and groups them by country and displays the
            // top three most fuel efficient cars by county.
            var cars = ProcessCarsFromCsv("fuel.csv");
            var manufacturers = ProcessManufacturersFromCsv("manufacturers.csv");

            // My solution
            var carsByCountry =
                cars.Join(manufacturers, c => c.Manufacturer, m => m.Name, (c, m) =>
                    new
                    {
                        Country = m.Headquarters,
                        c.Manufacturer,
                        c.Name,
                        c.Combined
                    })
                .GroupBy(c => c.Country)
                .OrderBy(g => g.Key)
                .ToList();

            foreach (var group in carsByCountry)
            {
                Console.WriteLine(group.Key);
                foreach (var car in group.OrderByDescending(c => c.Combined).Take(3))
                {
                    Console.WriteLine($"\t{car.Manufacturer} {car.Name} : {car.Combined}");
                }
            }
        }

        private static List<Manufacturer> ProcessManufacturersFromCsv(string path)
        {
            var query = File.ReadAllLines(path)
                            .Where(l => l.Length > 1)
                            .Select(l =>
                            {
                                var columns = l.Split(',');
                                return new Manufacturer
                                {
                                    Name = columns[0],
                                    Headquarters = columns[1],
                                    Year = int.Parse(columns[2])
                                };
                            });
            
            return query.ToList();
        }

        private static List<Car> ProcessCarsFromCsv(string path)
        {
            var query = File.ReadAllLines(path)
                            .Skip(1)
                            .Where(l => l.Length > 1)
                            .Select(l =>
                            {
                                var columns = l.Split(',');
                                return new Car
                                {
                                    Year = int.Parse(columns[0]),
                                    Manufacturer = columns[1],
                                    Name = columns[2],
                                    Dispacement = double.Parse(columns[3]),
                                    Cylinders = int.Parse(columns[4]),
                                    City = double.Parse(columns[5]),
                                    Highway = int.Parse(columns[6]),
                                    Combined = int.Parse(columns[7])
                                };
                            });

            return query.ToList();
        }

        private static void WriteEnumerable<T>(IEnumerable<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
