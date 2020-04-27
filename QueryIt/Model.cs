using System;
using System.Collections.Generic;
using System.Text;

namespace QueryIt
{
    public class Person
    {
        public string Name { get; set; }
    }

    public class Employee : Person
    {
        public int Id { get; set; }

        public virtual void DoWork()
        {
            Console.WriteLine("Working");
        }
    }

    public class Manager : Employee
    {
        public override void DoWork()
        {
            Console.WriteLine("Create a meeting");
        }
    }
}
