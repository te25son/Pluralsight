using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.Entity;

namespace Cars
{
    public class LinqAndEntityFramework
    {
        public CsvProcessor Processor = new CsvProcessor();

        public void InsertData()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarDb>());
            
            var cars = Processor.ProcessCarsFromCsv("fuel.csv");
            var db = new CarDb();

            if (!db.Cars.Any())
            {
                foreach (var car in cars)
                {
                    db.Cars.Add(car);
                }
                db.SaveChanges();
            }
        }

        public void QueryData()
        {
            var db = new CarDb();
            db.Database.Log = Console.WriteLine;

            var method =
                db.Cars.Where(c => c.Manufacturer.Equals("BMW"))
                       .OrderByDescending(c => c.Combined)
                       .ThenBy(c => c.Name)
                       .Take(10)
                       .ToList();  // This ultimately forces the query to run and saves it in case you need to use the data within the query again.

            Console.WriteLine(method.Count());  // Without calling ToList at the end of the query, Count would force the query to run twice.
            foreach (var car in method)
            {
                Console.WriteLine($"{car.Name} : {car.Combined}");
            }
        }
    }
}
