using System;
using System.Collections.Generic;

namespace Calendar
{
    public class Days
    {
        public static IEnumerable<DateTime> InYear(int year)
        {
            yield return new DateTime(year, 1, 1);
        }
    }
}