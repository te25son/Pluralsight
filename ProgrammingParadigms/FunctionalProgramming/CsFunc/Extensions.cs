using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace CsFunc
{
    public static class Extensions
    {
        public static T WithRetry<T>(this Func<T> action)  // Takes a function without any parameters that returns T
        {
            var result = default(T);
            var retryCount = 0;
            var successful = false;

            do
            {
                try
                {
                    result = action();
                    successful = true;
                }
                catch
                {
                    retryCount++;
                }
            } while (retryCount < 3 && !successful);

            return result;
        }

        // Partial function application
        // Allows you to transform a function that takes `n` parameters
        // to a function that takes `n - 1` parameters.
        public static Func<TResult> Partial<TParam1, TResult>(
            this Func<TParam1, TResult> func, TParam1 parameter)
        {
            return () => func(parameter);
        }

        // Currying
        // Transform a function that takes n parameters
        // into a function that you invoke to apply a parameter,
        // and you get back as a result of function that takes
        // n - 1 parameters.
        public static Func<TParam1, Func<TResult>> Curry<TParam1, TResult>(
            this Func<TParam1, TResult> func)
        {
            return parameter => () => func(parameter);
        }
    }
}
