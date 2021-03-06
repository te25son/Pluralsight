﻿using System;

namespace Tips
{
    class Program
    {
        static void Main(string[] args)
        {
            var enumAndGenericExamples = new EnumsAndGenerics();
            enumAndGenericExamples.Examples();

            var mathProblem = new MathProblem();
            mathProblem.Examples();

            var baseTypes = new BaseTypes();
            baseTypes.Examples();

            var usingStatic = new GenericsAndStatics();
            usingStatic.Examples();
        }
    }
}
