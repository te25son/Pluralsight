using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CsFunc
{
    public class TimeKeeper
    {
        public TimeSpan Measure(Action action)
        {
            var watch = new Stopwatch();
            watch.Start();
            action();
            return watch.Elapsed;
        }
    }
}
