using System;
using System.Collections.Generic;

namespace Calendar
{
    public class Days
    {
        public static IEnumerable<DateTime> InYear(int year)
        {
            var day = new DateTime(year, 1, 1);

            while (day.Year == year)
            {
                yield return day;
                day = day.AddDays(1);
            }
        }
    }
}