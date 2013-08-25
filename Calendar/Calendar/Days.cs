using System;
using System.Collections.Generic;
using System.Linq;

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

        public static IEnumerable<IGrouping<int, DateTime>> ByMonth(IEnumerable<DateTime> days)
        {
            return days.GroupBy(day => day.Month);
        }
    }
}