using System;
using FarsiToolbox.DateAndTime;
using Xunit.Extensions;
using Xunit;
using System.Collections.Generic;

namespace FarsiToolboxTests
{
    public class PersianDateTimeTests
    {
        public static IEnumerable<object[]> DateTimeAndEquivalentPersianDates
        {
            get
            {
                yield return new object[] { new DateTime(2014, 12, 21, 10, 25, 11, 153), 1393, 9, 30, 10, 25, 11, 153 };
                yield return new object[] { new DateTime(2015, 3, 20, 23, 59, 59, 0), 1393, 12, 29, 23, 59, 59, 0 };
                yield return new object[] { new DateTime(2015, 3, 21, 10, 25, 11, 153), 1394, 1, 1, 10, 25, 11, 153 };
                yield return new object[] { new DateTime(2017, 3, 20, 10, 25, 11, 153), 1395, 12, 30, 10, 25, 11, 153 };
                yield return new object[] { new DateTime(2017, 3, 21, 10, 25, 11, 153), 1396, 1, 1, 10, 25, 11, 153 };
            }
        }

        [Theory]
        [PropertyData("DateTimeAndEquivalentPersianDates")]
        public void DateTimeConstructor(DateTime dateTime, int year, int month, int day, int hour, int minute, int second, int millisecond)
        {

            var actual = new PersianDateTime(dateTime);
            var expected = new PersianDateTime(year, month, day, hour, minute, second, millisecond);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [PropertyData("DateTimeAndEquivalentPersianDates")]
        public void ExplicitCastToDateTime(DateTime dateTime, int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            Assert.Equal(dateTime, (DateTime)new PersianDateTime(year, month, day, hour, minute, second, millisecond));
        }

        [Theory]
        [PropertyData("DateTimeAndEquivalentPersianDates")]
        public void ExplicitCastFromDateTime(DateTime dateTime, int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            var actual = (PersianDateTime)dateTime;
            var expected = new PersianDateTime(year, month, day, hour, minute, second, millisecond);
            Assert.Equal(expected, actual);
        }
    }
}
