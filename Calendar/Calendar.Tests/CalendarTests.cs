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
    }
}
