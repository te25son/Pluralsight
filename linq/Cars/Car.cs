﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Car
    {
        public int Year { get; set; }
        
        public string Manufacturer { get; set; }
        
        public string Name { get; set; }
        
        public double Dispacement { get; set; }
        
        public int Cylinders { get; set; }
        
        public double City { get; set; }
        
        public int Highway { get; set; }
        
        public int Combined { get; set; }

        internal static Car ParseFromCsv(string line)
        {
            var columns = line.Split(',');
            return new Car
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