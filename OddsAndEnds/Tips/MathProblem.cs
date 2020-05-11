using System;
using System.Collections.Generic;
using System.Text;

namespace Tips
{
    public class MathProblem
    {
        public void Examples()
        {
            var numbers = new double[] { 1, 2, 3, 4, 5, 6 };
            var result = SampledAverage(numbers);

            Console.WriteLine(result);
        }

        private double SampledAverage(double[] numbers)
            // I cannot make this method use generics because there is no constraint
            // allowing me to specify if an object uses the +, -, *, ... operators.
            // There's no way for me to say:
            // where T : SomethingHere
            // Use overloaded methods instead.
            //
            // However, you can use IComparable for types that use <, > operators.
        {
            var count = 0;
            var sum = 0.0;
            
            for (int i = 0; i < numbers.Length; i += 2)
            {
                sum += numbers[1];
                count += 1;
            }

            return sum / count;
        }
    }
}
