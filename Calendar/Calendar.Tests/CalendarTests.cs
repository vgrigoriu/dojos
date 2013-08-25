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
    }
}
