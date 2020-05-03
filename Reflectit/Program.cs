using System;
using System.Collections.Generic;

namespace ReflectIt
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeList = CreateCollection(typeof(List<>), typeof(Employee));  // Unbound generic : List<>.
            var genericArguments = employeeList.GetType().GenericTypeArguments;

            Console.Write(employeeList.GetType().Name);
            Array.ForEach(
                genericArguments,
                a => Console.WriteLine($"[{a.Name}]")
            );
        }

        private static object CreateCollection(Type collectionType, Type itemType)
        {
            var closedType = collectionType.MakeGenericType(itemType);
            return Activator.CreateInstance(closedType);
        }
    }

    public class Employee
    {
        public string Name { get; set; }
    }
}
