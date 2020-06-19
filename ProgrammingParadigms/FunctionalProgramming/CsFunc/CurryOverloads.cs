using System;
using System.Collections.Generic;
using System.Text;

namespace CsFunc
{
    public class CurryOverloads
    {
        public Func<T1, Func<T2, T3>> Curry<T1, T2, T3>(Func<T1, T2, T3> func)
        {
            return a => b => func(a, b);
        }
        public Func<T1, Func<T2, Func<T3, T4>>> Curry<T1, T2, T3, T4>(Func<T1, T2, T3, T4> func)
        {
            return a => b => c => func(a, b, c);
        }

        public Func<T1, Func<T2, Func<T3, Func<T4, T5>>>> Curry<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5> func)
        {
            return a => b => c => d => func(a, b, c, d);
        }
    }
}
