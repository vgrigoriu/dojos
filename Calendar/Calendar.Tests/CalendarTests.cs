using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Calendar.Tests
{
    public class CalendarTests
    {
        [Fact]
        public void DaysEnumeratorReturnsFirstDayOfYear()
        {
            var daysInYear = Days.InYear(2013);

            DateTime firstDay = daysInYear.First();

            firstDay.Should().Be(new DateTime(2013, 1, 1));
        }

        [Fact]
        public void DaysEnumeratorReturnsAllTheDaysInYear()
        {
            var daysInYear = Days.InYear(2013);

            daysInYear.Count().Should().Be(365);
        }

        [Fact]
        public void DaysAreSplitIntoMonths()
        {
            var daysInYear = Days.InYear(2013);
            var daysByMonth = Days.ByMonth(daysInYear).ToList();

            daysByMonth.Count().Should().Be(12);
            daysByMonth.First().Count().Should().Be(31);
        }

        [Fact]
        public void WeeksAreSplitOnSunday()
        {
            var days = new[]
            {
                // Thursday
                new DateTime(2013, 8, 22),
                // Friday
                new DateTime(2013, 8, 23),
                // Saturday
                new DateTime(2013, 8, 24),
                // Sunday
                new DateTime(2013, 8, 25),
                // Monday
                new DateTime(2013, 8, 26),
                // Tueday
                new DateTime(2013, 8, 27),
            };

            var weeks = days.Weeks().ToList();
            var firstWeek = weeks.First();

            firstWeek.Count().Should().Be(4);
            weeks.Count().Should().Be(2);
        }
    }
}
