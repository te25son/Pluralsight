using System;
using System.Collections.Generic;
using System.Text;

namespace Playground
{
    public class Study
    {
        public int MultiplyByActionResult(int number, Func<int, int, int> action)
        {
            // Takes an int and returns that int multiplied by an action
            // that is determined during use.
            return number * action(number, number);
        }

        public int SquareAndMultiplyByActionResult(int number, Func<int, int, int> action)
        {
            var squared = number * number;
            return squared * action(number, squared);
        }
    }
}
