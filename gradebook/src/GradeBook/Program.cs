using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {               
            var book = new Book("Tim's Gradebook");
            InputGradesToBook(book);

            var book2 = new Book("Karina's Gradebook");
            book2.AddGrade(90.3);
            book2.AddGrade(77.6);
            book2.AddGrade(70.0);
            book2.GetStatistics();
        }

        static void InputGradesToBook(Book book)
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
    }
}
