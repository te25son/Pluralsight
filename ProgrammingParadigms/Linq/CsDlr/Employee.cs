using System;
using System.Collections.Generic;
using System.Text;

namespace CsDlr
{
    public class Employee
    {
        public string FirstName { get; set; }

        public void Speak()
        {
            Console.WriteLine($"Hi, my name is {FirstName}.");
        }
    }
}
