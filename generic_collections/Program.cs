using System;
using System.Collections.Generic;

namespace generic_collections
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("---- ARRAYS ----");
            UsingArrays();
            System.Console.WriteLine("---- LISTS ----");
            UsingLists();
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

            // Arrays can be resized if needed, but this is considered bad practice.
            // It is better to use lists if you're unsure the exact length of your array,
            // or know you will want to add or remove items from it.
            Array.Resize(ref employees, 10);
        }

        private static void UsingLists()
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
