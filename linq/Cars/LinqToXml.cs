using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Cars
{
    public class LinqToXml
    {
        public CsvProcessor Processor = new CsvProcessor();

        public void BuildElementOrientedXml()
        {
            var records = Processor.ProcessCarsFromCsv("fuel.csv");
            var document = new XDocument();
            var cars = new XElement("Cars");

            foreach (var record in records)
            {
                var car = new XElement("Car");
                var name = new XElement("Name", record.Name);
                var combined = new XElement("Combined", record.Combined);

                car.Add(name);
                car.Add(combined);

                cars.Add(car);
            }

            document.Add(cars);
            document.Save("Fuel.xml");
        }
    }
}
