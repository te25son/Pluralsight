using System;

namespace CsDlr
{
    // DLR = Dynamic Language Runtime
    // Dynamic Languages vs Static Languages

    class Program
    {
        static void Main(string[] args)
        {
            object speaker = GetASpeaker();
            speaker.GetType().GetMethod("Speak").Invoke(speaker, null);

            // dynamic skips the compile and runs at runtime.
            dynamic speaker2 = GetASpeaker();
            speaker2.Speak();
        }  

        private static object GetASpeaker()
        {
            return new Employee { FirstName = "George" };
        }
    }
}
