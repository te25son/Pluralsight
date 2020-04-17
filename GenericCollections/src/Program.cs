using System;

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
        }
    }
}
