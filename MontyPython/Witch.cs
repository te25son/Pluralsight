using System;
using System.Collections.Generic;
using System.Text;

namespace MontyPython
{
    public class Witch
    {
        public double Weight { get; set; }

        public bool Burns
        {
            get { return true; } 
        }

        public bool Floats
        {
            get
            {
                var duck = new Duck();
                return Weight >= duck.MinValue && Weight <= duck.MaxValue;
            }
        }

        public bool IsMadeOfWood
        {
            get { return Burns && Floats; }
        }

        public bool IsWtich
        {
            get { return IsMadeOfWood; }
        }
    }
}
