using System;
using System.Collections.Generic;

namespace ReflectIt
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeList = CreateCollection(typeof(List<>), typeof(Employee));
            Console.Write(employeeList.GetType().Name);

            var genericArguments = employeeList.GetType().GenericTypeArguments;
            Array.ForEach(
                genericArguments,
                a => Console.Write($"[{a}]")
            );
            Console.WriteLine();
        }

        private static object CreateCollection(Type collectionType, Type itemType)
        {
            // Closes the unbound type collectionType<> to be collectionType<itemType>.
            var closedType = collectionType.MakeGenericType(itemType);
            return Activator.CreateInstance(closedType);
        }
    }

    public class Employee
    {
        public string Name { get; set; }
    }
}
