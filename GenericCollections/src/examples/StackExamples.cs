using System.Collections.Generic;

namespace GenericCollections
{
    class StackExamples
    {
        public static void Examples()
        {
            // Stack is a LIFO (Last In First Out) data structure.
            // The last element to be added will be the first element
            // out when calling the Pop method.
            Stack<Employee> stack = new Stack<Employee>();
            stack.Push(new Employee { Name = "Frodo "});
            stack.Push(new Employee { Name = "Sam"});
            stack.Push(new Employee { Name = "Bilbo "});

            while (stack.Count > 0)
            {
                var hobbit = stack.Pop();
                System.Console.WriteLine(hobbit.Name);
            }
        }
    }
}