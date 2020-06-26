using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressYourself
{
    public class DateRange
    {
        private readonly DateTime _start;
        
        private readonly DateTime _end;

        public DateTime Start { get { return _start; } }
        
        public DateTime End { get { return _end; } }

        public DateRange(DateTime start, DateTime end)
        {
            if (start.CompareTo(end) >= 0) throw new Exception("End must occur after the start");

            _start = start;
            _end = end;
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
