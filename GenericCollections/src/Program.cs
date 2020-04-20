using System;
using System.Collections.Generic;

namespace GenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            // CollectionExamples();
            EmployeeCompareExamples();
        }

        public static void CollectionExamples()
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
        }

        public static void EmployeeCompareExamples()
        {
            System.Console.WriteLine("\nEmployee Compare Examples\n");
            var departments = new DepartmentCollection();
            
            departments
                .Add("Sales", new Employee { Name = "Joy" })
                .Add("Sales", new Employee { Name = "Dani" })
                .Add("Sales", new Employee { Name = "Dani" });

            departments
                .Add("Engineering", new Employee { Name = "Adam" })
                .Add("Engineering", new Employee { Name = "Eve" })
                .Add("Engineering", new Employee { Name = "Jim" });

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
