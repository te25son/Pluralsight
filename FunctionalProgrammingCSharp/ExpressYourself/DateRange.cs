using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressYourself
{
    public class DateRange
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public bool DateIsInRange(DateTime checkDate)
        {
            return Start.CompareTo(checkDate) <= 0 && End.CompareTo(checkDate) >= 0;
        }
    }
}
