using System;
using System.Collections.Generic;
using System.Linq;

namespace Calendar
{
    public static class Days
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

        public static IEnumerable<IGrouping<int, DateTime>> ByMonth(this IEnumerable<DateTime> days)
        {
            return days.GroupBy(day => day.Month);
        }

        public static IEnumerable<IEnumerable<DateTime>> Weeks(this IEnumerable<DateTime> days)
        {
            var enumerator = days.GetEnumerator();
            while (enumerator.MoveNext())
                yield return NextWeek(enumerator);
        }

        private static IEnumerable<DateTime> NextWeek(IEnumerator<DateTime> enumerator)
        {
            var week = new List<DateTime>();
            do
            {
                week.Add(enumerator.Current);
            } while (enumerator.Current.DayOfWeek != DayOfWeek.Sunday && enumerator.MoveNext());

            return week;
        }
    }
}