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
                .Select(Car.ParseFromCsv)
                .ToList();
        }
    }
}
