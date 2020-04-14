using System;

namespace GenericCollections
{
    class ArrayExamples
    {
        public static void Examples()
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

            // Arrays can be resized if needed, but this is considered bad practice.
            // It is better to use lists if you're unsure the exact length of your array,
            // or know you will want to add or remove items from it.
            Array.Resize(ref employees, 10);
        }
    }
}