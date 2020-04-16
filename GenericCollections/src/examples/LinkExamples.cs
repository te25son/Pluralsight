using System.Collections.Generic;

namespace GenericCollections
{
    class LinkExamples
    {
        public static void Examples()
        {
            // LinkedLists excel at adding, removing, and inserting
            // items at a specific locations within a list.

            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(1);  // { 1 }
            list.AddFirst(2);  // Will be added before the 1. { 2, 1 }

            var firstItem = list.First;
            list.AddAfter(firstItem, 5);  // Will be inserted between the 2 & 1. { 2, 5, 1 }
            list.AddBefore(firstItem, 3);  // Now 2 is the first item variable. { 3, 2, 5, 1 }

            foreach (var item in list)
            {
                System.Console.WriteLine(item);
            }

            var node = list.First;
            
            // Loops through the linked list by getting the next element
            while (node != null)
            {
                System.Console.WriteLine(node.Value);
                node = node.Next;
            }
        }
    }
}