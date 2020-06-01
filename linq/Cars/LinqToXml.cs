using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Cars
{
    public class LinqToXml
    {
        public CsvProcessor Processor = new CsvProcessor();

        public void CreateXml()
        {
            var records = Processor.ProcessCarsFromCsv("fuel.csv");
            var mainNamespace = (XNamespace)"http://pluralsight.com/cars/2016";
            var extendedNamespace = (XNamespace)"http://pluralsight.com/cars/2016/ex";
            var document = new XDocument();
            var cars = new XElement(mainNamespace + "Cars", records.Select(r =>
                {
                    return new XElement(
                        extendedNamespace + "Car",
                        new XAttribute("Name", r.Name),
                        new XAttribute("Combined", r.Combined),
                        new XAttribute("Manufacturer", r.Manufacturer)
                    );
                })
            );

            cars.Add(new XAttribute(XNamespace.Xmlns + "ExtendedNamespace", extendedNamespace));

            document.Add(cars);
            document.Save("Fuel.xml");
        }

        public void QueryXml()
        {
            var mainNamespace = (XNamespace)"http://pluralsight.com/cars/2016";
            var extendedNamespace = (XNamespace)"http://pluralsight.com/cars/2016/ex";
            var document = XDocument.Load("fuel.xml");
            var query =
                from element in document.Element(mainNamespace + "Cars").Elements(extendedNamespace + "Car")
                where element.Attribute("Manufacturer").Value.Equals("BMW")
                select element.Attribute("Name").Value;

            foreach(var car in query)
            {
                Console.WriteLine(car);
            }
        }
    }
}
