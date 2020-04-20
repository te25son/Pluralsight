using System;
using System.Collections.Generic;

namespace GenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("---- ARRAYS ----");
            ArrayExamples.Examples();
            
            System.Console.WriteLine("---- LISTS ----");
            ListExamples.Examples();
            
            System.Console.WriteLine("---- QUEUES ----");
            QueueExamples.Examples();
            
            System.Console.WriteLine("---- STACKS ----");
            StackExamples.Examples();

            System.Console.WriteLine("---- LINKS ----");
            LinkExamples.Examples();

            System.Console.WriteLine("---- MAPS ----");
            MapExamples.Examples();

            System.Console.WriteLine("---- SORT ----");
            SortExamples.Examples();

            System.Console.WriteLine("\nFurther Examples\n");
            var departments = new SortedDictionary<string, SortedSet<Employee>>();
            
            departments.Add("Sales", new SortedSet<Employee>(new EmployeeComparer()));
            departments["Sales"].Add(new Employee { Name = "Joy" });
            departments["Sales"].Add(new Employee { Name = "Dani" });
            departments["Sales"].Add(new Employee { Name = "Dani" });

            departments.Add("Engineering", new SortedSet<Employee>(new EmployeeComparer()));
            departments["Engineering"].Add(new Employee { Name = "Adam" });
            departments["Engineering"].Add(new Employee { Name = "Eve" });
            departments["Engineering"].Add(new Employee { Name = "Jim" });

            foreach (var department in departments)
            {
                System.Console.WriteLine(department.Key);
                foreach (var employee in department.Value)
                {
                    System.Console.WriteLine($"\t{employee.Name}");
                }
            }
        }
    }
}
