using System;

namespace GradeBook
{
    public class Statistics
    {

        public Statistics()
        {
            Count = 0;
            Sum = 0.0;
            Highest = double.MinValue;
            Lowest = double.MaxValue;
        }

        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public double Highest;

        public double Lowest;

        public char Letter
        {
            get
            {
                switch (Average)
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
        }

        public double Sum;

        public int Count;

        public void Add(double number)
        {
            Sum += number;
            Count++;
            Lowest = Math.Min(number, Lowest);
            Highest = Math.Max(number, Highest);
        }
    }
}