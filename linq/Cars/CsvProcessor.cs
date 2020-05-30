using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Cars
{
    public class CsvProcessor
    {
        public List<Manufacturer> ProcessManufacturersFromCsv(string path)
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

        public List<Car> ProcessCarsFromCsv(string path)
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
    }
}
