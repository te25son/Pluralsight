using System;
using System.Collections.Generic;
using System.Text;

namespace WhatIsFP
{
    public static class EmphasizingExpressions
    {
        public static void Run()
        {
            var posExample = 2;
            var negExample = -2;

            GetPosOrNegStatement(posExample);
            GetPosOrNegStatement(negExample);

            GetPosOrNegExpression(posExample);
            GetPosOrNegExpression(negExample);
        }

        private static void GetPosOrNegStatement(int value)
        {
            // posOrNeg is an extraneous variable.
            string posOrNeg;

            if (value > 0)
                posOrNeg = "positive";
            else
                posOrNeg = "negative";

            Console.WriteLine($"{value} is {posOrNeg}");
        }

        private static void GetPosOrNegExpression(int value)
        {
            // Remove the extraneous variable with an expression.
            Console.WriteLine($"{value} is {(value > 0 ? "positive" : "negative")}");
        }
    }
}
