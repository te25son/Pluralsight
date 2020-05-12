using System;
using System.Collections.Generic;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
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

            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee { Id = 1, Name = "Dexter" },
                new Employee { Id = 1, Name = "Sherlock" }
            };

            IEnumerable<Employee> sales = new List<Employee>
            {
                new Employee { Id = 3, Name = "Brad" }
            };

            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }

            Console.WriteLine(sales.Count());
            Console.WriteLine(developers.Count());
        }
    }
}
