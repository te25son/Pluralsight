using System;
using System.Collections.Generic;
using System.Text;

namespace Tips
{
    public enum Steps
    {
        Step1,
        Step2,
        Step3
    }

    public static class StringExtensions
    {
        public static TEnum ParseEnum<TEnum>(this string value)
            where TEnum : struct
            // Using struct here will not eliminate all possible problems.
            // User can still pass another value type such as 'int' and it will be legal, but won't compile.
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value);
        }
    }

    public class EnumsAndGenerics
    {
        public void Examples()
        {
            var input = "Step1";
            var value = input.ParseEnum<Steps>();

            Console.WriteLine(value);
        }
    }
}
