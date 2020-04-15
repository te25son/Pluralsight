using System.Collections.Generic;

namespace GenericCollections
{
    class SetExamples
    {
        public static void Examples()
        {
            HashSet<int> set = new HashSet<int>();
            set.Add(1);
            set.Add(2);
            set.Add(2);  // A set does not accept duplicates of objects, so this second two will not exist within my set.
            set.Add(3);

            foreach (var item in set)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}