using System.Collections.Generic;

namespace GenericCollections
{
    class QueueExamples
    {
        public static void Examples()
        {
            // Queue is a FIFO (First In First Out) data structure
            // because the first object to go in is always the first object
            // to go out.
            
            Queue<Employee> line = new Queue<Employee>();
            line.Enqueue(new Employee { Name = "Frodo" });
            line.Enqueue(new Employee { Name = "Merry" });
            line.Enqueue(new Employee { Name = "Pippin" });
            line.Enqueue(new Employee { Name = "Sam" });

            while (line.Count > 0)
            {
                // Dequeue gets the next item in line, but also removes the item.
                var employee = line.Dequeue();
                System.Console.WriteLine(employee.Name);
            }
        }
    }
}