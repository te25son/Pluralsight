using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;       
        
        public string Name;

        public Book(string name)
        {
            Name = name;
            grades = new List<double>();
        }

        public void AddLetterGrade(char letter)
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

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)} : {grade}.");
            }
        }

        private void AddCar()
        {
            throw new NotImplementedException();
        }

        public double GetLowestGrade()
        {
            var lowestGrade = double.MaxValue;
            foreach (var grade in grades)
            {
                lowestGrade = Math.Min(grade, lowestGrade);
            }
            return lowestGrade;
        }

        public double GetHighestGrade()
        {   
            var highestGrade = double.MinValue;
            foreach (var grade in grades)
            {
                highestGrade = Math.Max(grade, highestGrade);
            }
            return highestGrade;
        }

        public double GetAverageGrade()
        {
            var result = 0.0;
            foreach (var grade in grades)
            {
                result += grade;
            }
            return result /= grades.Count;
        }

        public char GetLetterGrade(double average)
        {
            switch (average)
            {
                case var d when d >= 90.0:
                    return 'A';             
                case var d when d >= 80.0:
                    return 'B';
                case var d when d >= 70.0:
                    return 'C';
                case var d when d >= 60.0:
                    return 'D';
                default:
                    return 'F';
            }
        }

        public Statistics GetStatistics()
        {
            var average = GetAverageGrade();
            var statistics = new Statistics
            {
                Highest = GetHighestGrade(),
                Lowest = GetLowestGrade(),
                Average = average,
                Letter = GetLetterGrade(average)
            };

            return statistics;
        }
    }
}