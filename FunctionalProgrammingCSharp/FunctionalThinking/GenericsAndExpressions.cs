using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalThinking
{
    public class GenericsAndExpressions
    {
        private static Func<decimal, decimal, decimal> GetOperation(char oper)
        {
            switch (oper)
            {
                // This returns a reference to the mehtod so that we can execute it later.
                case '+': return (l, r) => l + r;
                case '-': return (l, r) => l - r;
                case '*': return (l, r) => l * r;
                case '/': return (l, r) => l / r;
            }

            throw new NotSupportedException($"The operator - {oper} - is not supported.");
        }

        private static decimal Eval(string expr)
        {
            var elements = expr.Split(new[] { ' ' }, 3);
            var l = Decimal.Parse(elements[0]);
            var r = Decimal.Parse(elements[1]);
            var op = elements[2][0];

            return GetOperation(op)(l, r);
        }

        public static void Run()
        {
            Console.WriteLine(Eval("1 3 +"));
            Console.WriteLine(Eval("10 5 -"));
            Console.WriteLine(Eval("2 3 *"));
            Console.WriteLine(Eval("14 2 /"));
        }
    }
}
