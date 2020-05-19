using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Cars
{
    public class CarCsvProcessor
    {
        public CarCsvProcessor(string csvPath)
        {
            CsvPath = csvPath;
        }

        public string CsvPath { get; set; }

        public List<Car> List { 
            get { return ProcessFileToList(CsvPath); } 
        }

        public List<Car> ProcessFileToList(string path)
        {
            return File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .ToCar()
                .ToList();
        }
    }

    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> lines)  // Takes an incoming IEnumerable and does something with it.
        {
            foreach (var line in lines)
            {
                var columns = line.Split(',');
                yield return new Car
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Dispacement = double.Parse(columns[3]),
                    Cylinders = int.Parse(columns[4]),
                    City = double.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7]),
                };
            }
        }
    }
}
