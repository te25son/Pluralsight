using System.Collections.Generic;

namespace GenericCollections
{
    class ListExamples
    {
        public static void Examples()
        {
            // Demonstartes the basic usage of a list object. 

            List<Employee> employees = new List<Employee>
            {
                new Employee { Name = "Timothy" },
                new Employee { Name = "Thomas" }
            };

            // Unlike arrays, lists can be added to.
            employees.Add(new Employee { Name = "Johnny" });

            foreach (var employee in employees)
            {
                System.Console.WriteLine(employee.Name);
            }

            for (int i = 0; i < employees.Count; i++)
            {
                System.Console.WriteLine(employees[i].Name);
            }

            var numbers = new List<int>();
            var capacity = -1;
            var count = 0;

            while (count < 500)
            {
                if (numbers.Capacity != capacity)
                {
                    capacity = numbers.Capacity;
                    System.Console.WriteLine(capacity);
                }
                numbers.Add(1);
                count ++;
            }
        }
    }
}