using System.Collections.Generic;

namespace GenericCollections
{
    class MapExamples
    {
        public static void Examples()
        {
            var employeesByName = new Dictionary<string, Employee>();
            employeesByName.Add("Scott", new Employee { Name = "Scott" });
            employeesByName.Add("Adam", new Employee { Name = "Adam" });
            employeesByName.Add("Sally", new Employee { Name = "Sally" });

            var scott = employeesByName["Scott"];

            foreach (var item in employeesByName)
            {
                System.Console.WriteLine($"{item.Key} : {item.Value.Name}");
            }

            var employeeListByName = new Dictionary<string, List<Employee>>();
            employeeListByName.Add(
                key: "Tim",
                value: new List<Employee> 
                {
                    new Employee { Name = "Tim" }
                }
            );

            employeeListByName["Tim"].Add(
                new Employee { Name = "Timothy" }
            );

            foreach (var item in employeeListByName)
            {
                foreach (var employee in item.Value)
                {
                    System.Console.WriteLine(employee.Name);
                }
            }
        }
    }
}