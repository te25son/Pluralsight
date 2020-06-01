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
            var query =
                from car in db.Cars
                orderby car.Combined descending, car.Name ascending
                select car;

            foreach (var car in query)
            {
                Console.WriteLine($"{car.Name} : {car.Combined}");
            }
        }
    }
}
