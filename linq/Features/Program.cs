using System;
using System.Collections.Generic;
using System.Linq;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            BuiltInDelegates();
            QuerySyntax();

            var developers = new Employee[]
            {
                new Employee { Id = 1, Name = "Dexter" },
                new Employee { Id = 1, Name = "Sherlock" }
            };

            var sales = new List<Employee>
            {
                new Employee { Id = 3, Name = "Brad" }
            };

            Console.WriteLine(sales.Count());  // Using own extension method.
            Console.WriteLine(developers.Count());
        }

        public static void QuerySyntax()
        {
            var employees = new List<Employee>
            {
                new Employee { Name = "Frodo" },
                new Employee { Name = "Bilbo" },
                new Employee { Name = "Samwise" }
            };

            var query = employees.Where(e => e.Name.Length.Equals(5));
            var query2 = from employee in employees  // Same as the above query but with different syntax.
                         where employee.Name.Length.Equals(5)
                         orderby employee.Name
                         select employee;

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }
        }

        public static void BuiltInDelegates()
        {
            Func<int, int> square = x => x * x;  // The last parameter of Func is the return type.
            Func<int, int, int> add = (x, y) => x + y;  // Use parenthensis when you have more than one parameter and want to use a lambda expression.
            Func<int, int, int> multiply = (int x, int y) =>  // Can make more complex-looking lambda expressions, but probably shouldn't.
            {
                int temp = x + y;
                return temp;  // Will always have to use return if you decide to do this.
            };

            Action<int> write = x => Console.WriteLine(x);  // Action takes a certain number of parameters and always returns void.

            write(square(add(1, multiply(2, 3))));
        }
    }
}
