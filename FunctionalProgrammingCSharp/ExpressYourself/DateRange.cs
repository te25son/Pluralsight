using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressYourself
{
    public class DateRange
    {
        public DateTime Start { get; }

        public DateTime End { get; }

        public DateRange(DateTime start, DateTime end)
        {
            if (start.CompareTo(end) >= 0) throw new Exception("End must occur after the start");

            Start = start;
            End = end;
        }

        public bool DateIsInRange(DateTime checkDate)
        {
            return Start.CompareTo(checkDate) <= 0 && End.CompareTo(checkDate) >= 0;
        }

        public DateRange Slide(int days)
        {
            return new DateRange(Start.AddDays(days), End.AddDays(days));
        }
    }
}
