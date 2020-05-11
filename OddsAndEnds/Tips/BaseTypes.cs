using System;
using System.Collections.Generic;
using System.Text;

namespace Tips
{
    public class BaseTypes
    {
        // Using a base class that is not generic, i.e. it doesn't need any generic type parameters.
        public void Examples()
        {
            var list = new List<Item>();

            list.Add(new Item<int>());
            list.Add(new Item<double>());  // Need a list that can take both types.

            Array.ForEach(
                list.ToArray(),
                i => Console.WriteLine(i.GetType().FullName)
            );
        }
    }

    public class Item<T> : Item
    {

    }

    public class Item
    {

    }
}
