using System;

namespace generic_collections
{
    class Program
    {
        static void Main(string[] args)
        {
            UsingArrays();
        }

        private static void UsingArrays()
        {
            // Demonstrates a very basic use of arrays.

            Employee[] employees = new Employee[]
            {
                new Employee { Name = "Tim" },
                new Employee { Name = "Thomas"}
            };

            foreach (var employee in employees)
            {
                System.Console.WriteLine(employee.Name);
            }

            for (int i = 0; i < employees.Length; i++)
            {
                System.Console.WriteLine(employees[i].Name);
            }

            Array.Resize(ref employees, 10);
        }
    }
}
