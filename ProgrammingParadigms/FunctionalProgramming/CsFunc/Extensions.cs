using System;
using System.Collections.Generic;
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
                catch (WebException ex)
                {
                    retryCount++;
                }
            } while (retryCount < 3 && !successful);

            return result;
        }
    }
}
