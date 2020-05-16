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
        }
    }
}
