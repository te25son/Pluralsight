using System.Collections.Generic;

namespace GenericCollections
{
    class SortExamples
    {
        public static void Examples()
        {
            // Sorted also works with lists and sets. 
            // See sorted tests.
            var employeesByName = new SortedDictionary<string, List<Employee>>();
            employeesByName.Add(
                "Sales",
                new List<Employee>
                {
                    new Employee(),
                    new Employee(),
                    new Employee()
                }
            );
            employeesByName.Add(
                "Engineering",
                new List<Employee>
                {
                    new Employee(),
                    new Employee(),
                    new Employee()
                }
            );

            foreach (var item in employeesByName)
            {
                System.Console.WriteLine($"The count for {item.Key} is {item.Value.Count}.");
            }
        }
    }
}