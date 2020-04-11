﻿using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {               
            var book = new InMemoryBook("Tim's Gradebook");
            book.GradeAdded += OnGradesAdded;

            EnterGrades(book);
            book.DisplayStatistics();

            var book2 = new InMemoryBook("Karina's Gradebook");
            book2.AddGrade(90.3);
            book2.AddGrade(77.6);
            book2.AddGrade(70.0);
            book2.GetStatistics();
        }

        private static void EnterGrades(Book book)
        {
            while(true)
            {
                Console.WriteLine("Enter a grade. Press 'Q' to quit.");
                var input = Console.ReadLine();
                
                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void OnGradesAdded(object sender, EventArgs e)
        {
            Console.WriteLine($"A grade was added.");
        }
    }
}
