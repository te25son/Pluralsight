using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class InMemoryBook : Book
    {
        private List<double> grades;       
        
        public override event GradeAddedDelegate GradeAdded;

        public InMemoryBook(string name) : 
            base(name)
        {
            Name = name;
            grades = new List<double>();
        }

        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90); break;
                case 'B':
                    AddGrade(80); break;
                case 'C':
                    AddGrade(70); break;
                case 'D':
                    AddGrade(60); break;
                case 'F':
                    AddGrade(50); break;      
                default:
                    AddGrade(0); break;
            }
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                GradeAdded?.Invoke(this, new EventArgs());
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)} : {grade}.");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            for (var index = 0; index < grades.Count; index++)
            {
                statistics.Add(grades[index]);
            }

            return statistics;
        }

        public void DisplayStatistics(Statistics statistics = null)
        {
            var statisticsToDisplay = statistics ?? GetStatistics();
            Console.WriteLine($"For the book named {Name}");
            Console.WriteLine($"The lowest grade is: {statisticsToDisplay.Lowest}");
            Console.WriteLine($"The highest grade is: {statisticsToDisplay.Highest}");
            Console.WriteLine($"The average grade is: {statisticsToDisplay.Average}");
            Console.WriteLine($"The letter grade of the average score is: {statisticsToDisplay.Letter}");
        }
    }
}