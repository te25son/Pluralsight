using System;
using System.Collections.Generic;
using System.Text;

namespace Tips
{
    public class GenericsAndStatics
    {
        public void Examples()
        {
            var tracker = new Tracker();
            var tracker2 = new Tracker();
            var tracker3 = new Tracker();

            // Static fields are shared across all instances of Tracker.
            Console.WriteLine(Tracker.InstanceCount);

            var genericTracker = new Tracker<int>();
            var genericTracker2 = new Tracker<double>();
            var genericTracker3 = new Tracker<string>();
            var genericTracker4 = new Tracker<string>();

            Console.WriteLine(Tracker<int>.InstanceCount);
            Console.WriteLine(Tracker<double>.InstanceCount);
            Console.WriteLine(Tracker<string>.InstanceCount);
        }
    }

    public class Tracker
    {
        public Tracker()
        {
            InstanceCount += 1;
        }

        public static int InstanceCount;  // Only one TnstanceCount exists across all instances of Tracker.
    }

    // What is Tracker uses a generic type parameter??
    public class Tracker<T>
    {
        public Tracker()
        {
            InstanceCount += 1;
        }

        public static int InstanceCount;
    }
}
