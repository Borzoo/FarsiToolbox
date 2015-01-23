using System;
using FarsiToolbox.DateAndTime;
using Xunit.Extensions;
using Xunit;
using System.Collections.Generic;
using Moq;

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

        public static IEnumerable<object[]> PersianDateAndObjectForEqualityTest
        {
            get
            {
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new DateTime(2015, 1, 23, 16, 37, 52, 10), true };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new DateTime(2015, 1, 23, 16, 37, 52, 9), false };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new DateTime(2015, 1, 23, 16, 37, 53, 10), false };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new DateTime(2015, 1, 23, 16, 32, 52, 10), false };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new DateTime(2015, 1, 23, 11, 37, 52, 10), false };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new DateTime(2015, 1, 22, 16, 37, 52, 10), false };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new DateTime(2015, 2, 23, 16, 37, 52, 10), false };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), true };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1393, 11, 3, 16, 37, 52, 9), false };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1393, 11, 3, 16, 37, 53, 10), false };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1393, 11, 3, 16, 38, 52, 10), false };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1393, 11, 3, 15, 37, 52, 10), false };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1393, 11, 4, 16, 37, 52, 10), false };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1393, 12, 3, 16, 37, 52, 10), false };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1394, 11, 3, 16, 37, 52, 10), false };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), null, false };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new Object(), false };
            }
        }

        public static IEnumerable<object[]> PersianDateAndPersianDateForEqualityTest
        {
            get
            {
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), true };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1393, 11, 3, 16, 37, 52, 9), false };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1393, 11, 3, 16, 37, 53, 10), false };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1393, 11, 3, 16, 38, 52, 10), false };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1393, 11, 3, 15, 37, 52, 10), false };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1393, 11, 4, 16, 37, 52, 10), false };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1393, 12, 3, 16, 37, 52, 10), false };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1394, 11, 3, 16, 37, 52, 10), false };
            }
        }

        public static IEnumerable<object[]> PersianDateAndObjectCompareToTest
        {
            get
            {
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new DateTime(2015, 1, 23, 16, 37, 52, 10), 0 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new DateTime(2015, 1, 23, 16, 37, 52, 9), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new DateTime(2015, 1, 23, 16, 37, 52, 11), -1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new DateTime(2015, 1, 23, 16, 37, 51, 10), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new DateTime(2015, 1, 23, 16, 37, 53, 10), -1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new DateTime(2015, 1, 23, 16, 36, 52, 10), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new DateTime(2015, 1, 23, 16, 38, 52, 10), -1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new DateTime(2015, 1, 23, 15, 37, 52, 10), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new DateTime(2015, 1, 23, 17, 37, 52, 10), -1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new DateTime(2015, 1, 22, 16, 37, 52, 10), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new DateTime(2015, 1, 24, 16, 37, 52, 10), -1 };
                yield return new object[] { new PersianDateTime(1393, 11, 17, 16, 37, 52, 10), new DateTime(2015, 1, 6, 16, 37, 52, 10), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 17, 16, 37, 52, 10), new DateTime(2015, 3, 6, 16, 37, 52, 10), -1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new DateTime(2014, 1, 23, 16, 37, 52, 10), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new DateTime(2016, 1, 23, 16, 37, 52, 10), -1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), 0 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1393, 11, 3, 16, 37, 52, 9), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1393, 11, 3, 16, 37, 52, 11), -1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1393, 11, 3, 16, 37, 51, 10), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1393, 11, 3, 16, 37, 53, 10), -1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1393, 11, 3, 16, 36, 52, 10), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1393, 11, 3, 16, 38, 52, 10), -1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1393, 11, 3, 15, 37, 52, 10), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1393, 11, 3, 17, 37, 52, 10), -1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1393, 11, 2, 16, 37, 52, 10), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1393, 11, 4, 16, 37, 52, 10), -1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1393, 10, 3, 16, 37, 52, 10), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1393, 12, 3, 16, 37, 52, 10), -1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1392, 11, 3, 16, 37, 52, 10), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), (object)new PersianDateTime(1394, 11, 3, 16, 37, 52, 10), -1 };
            }
        }

        public static IEnumerable<object[]> PersianDateTimeAndPersianDateTimeCompareToTest
        {
            get
            {
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), 0 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1393, 11, 3, 16, 37, 52, 9), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1393, 11, 3, 16, 37, 52, 11), -1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1393, 11, 3, 16, 37, 51, 10), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1393, 11, 3, 16, 37, 53, 10), -1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1393, 11, 3, 16, 36, 52, 10), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1393, 11, 3, 16, 38, 52, 10), -1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1393, 11, 3, 15, 37, 52, 10), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1393, 11, 3, 17, 37, 52, 10), -1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1393, 11, 2, 16, 37, 52, 10), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1393, 11, 4, 16, 37, 52, 10), -1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1393, 10, 3, 16, 37, 52, 10), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1393, 12, 3, 16, 37, 52, 10), -1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1392, 11, 3, 16, 37, 52, 10), 1 };
                yield return new object[] { new PersianDateTime(1393, 11, 3, 16, 37, 52, 10), new PersianDateTime(1394, 11, 3, 16, 37, 52, 10), -1 };
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

        [Theory]
        [InlineData(1394, 10, 4, 14, 25, 22, 0, "y y", "4 4")]
        [InlineData(1394, 10, 4, 14, 25, 22, 0, "yy", "94")]
        [InlineData(1394, 10, 4, 14, 25, 22, 0, "yyy", "394")]
        [InlineData(1394, 10, 4, 14, 25, 22, 0, "yyyy", "1394")]
        [InlineData(1394, 10, 4, 14, 25, 22, 0, "yyyyy", "01394")]
        [InlineData(9, 10, 4, 14, 25, 22, 0, "y y", "9 9")]
        [InlineData(9, 10, 4, 14, 25, 22, 0, "yy", "09")]
        [InlineData(9, 10, 4, 14, 25, 22, 0, "yyy", "009")]
        [InlineData(9, 10, 4, 14, 25, 22, 0, "yyyy", "0009")]
        [InlineData(9, 10, 4, 14, 25, 22, 0, "yyyyy", "00009")]
        public void ToStringWithYearFormat(int year, int month, int day, int hour, int minute, int second, int millisecond, string formatStr, string formattedStr)
        {
            var actual = new PersianDateTime(year, month, day, hour, minute, second, millisecond).ToString(formatStr);
            Assert.Equal(formattedStr, actual);
        }

        [Theory]
        [InlineData(1394, 1, 4, 14, 25, 22, 0, "M M", "1 1")]
        [InlineData(1394, 2, 4, 14, 25, 22, 0, "M M", "2 2")]
        [InlineData(1394, 3, 4, 14, 25, 22, 0, "M M", "3 3")]
        [InlineData(1394, 4, 4, 14, 25, 22, 0, "M M", "4 4")]
        [InlineData(1394, 5, 4, 14, 25, 22, 0, "M M", "5 5")]
        [InlineData(1394, 6, 4, 14, 25, 22, 0, "M M", "6 6")]
        [InlineData(1394, 7, 4, 14, 25, 22, 0, "M M", "7 7")]
        [InlineData(1394, 8, 4, 14, 25, 22, 0, "M M", "8 8")]
        [InlineData(1394, 9, 4, 14, 25, 22, 0, "M M", "9 9")]
        [InlineData(1394, 10, 4, 14, 25, 22, 0, "M M", "10 10")]
        [InlineData(1394, 11, 4, 14, 25, 22, 0, "M M", "11 11")]
        [InlineData(1394, 12, 4, 14, 25, 22, 0, "M M", "12 12")]
        [InlineData(1394, 1, 4, 14, 25, 22, 0, "MM", "01")]
        [InlineData(1394, 2, 4, 14, 25, 22, 0, "MM", "02")]
        [InlineData(1394, 3, 4, 14, 25, 22, 0, "MM", "03")]
        [InlineData(1394, 4, 4, 14, 25, 22, 0, "MM", "04")]
        [InlineData(1394, 5, 4, 14, 25, 22, 0, "MM", "05")]
        [InlineData(1394, 6, 4, 14, 25, 22, 0, "MM", "06")]
        [InlineData(1394, 7, 4, 14, 25, 22, 0, "MM", "07")]
        [InlineData(1394, 8, 4, 14, 25, 22, 0, "MM", "08")]
        [InlineData(1394, 9, 4, 14, 25, 22, 0, "MM", "09")]
        [InlineData(1394, 10, 4, 14, 25, 22, 0, "MM", "10")]
        [InlineData(1394, 11, 4, 14, 25, 22, 0, "MM", "11")]
        [InlineData(1394, 12, 4, 14, 25, 22, 0, "MM", "12")]
        [InlineData(1394, 1, 4, 14, 25, 22, 0, "MMM", "فروردین")]
        [InlineData(1394, 2, 4, 14, 25, 22, 0, "MMM", "اردیبهشت")]
        [InlineData(1394, 3, 4, 14, 25, 22, 0, "MMM", "خرداد")]
        [InlineData(1394, 4, 4, 14, 25, 22, 0, "MMM", "تیر")]
        [InlineData(1394, 5, 4, 14, 25, 22, 0, "MMM", "مرداد")]
        [InlineData(1394, 6, 4, 14, 25, 22, 0, "MMM", "شهریور")]
        [InlineData(1394, 7, 4, 14, 25, 22, 0, "MMM", "مهر")]
        [InlineData(1394, 8, 4, 14, 25, 22, 0, "MMM", "آبان")]
        [InlineData(1394, 9, 4, 14, 25, 22, 0, "MMM", "آذر")]
        [InlineData(1394, 10, 4, 14, 25, 22, 0, "MMM", "دی")]
        [InlineData(1394, 11, 4, 14, 25, 22, 0, "MMM", "بهمن")]
        [InlineData(1394, 12, 4, 14, 25, 22, 0, "MMM", "اسفند")]
        [InlineData(1394, 1, 4, 14, 25, 22, 0, "MMMM", "فروردین")]
        [InlineData(1394, 2, 4, 14, 25, 22, 0, "MMMM", "اردیبهشت")]
        [InlineData(1394, 3, 4, 14, 25, 22, 0, "MMMM", "خرداد")]
        [InlineData(1394, 4, 4, 14, 25, 22, 0, "MMMM", "تیر")]
        [InlineData(1394, 5, 4, 14, 25, 22, 0, "MMMM", "مرداد")]
        [InlineData(1394, 6, 4, 14, 25, 22, 0, "MMMM", "شهریور")]
        [InlineData(1394, 7, 4, 14, 25, 22, 0, "MMMM", "مهر")]
        [InlineData(1394, 8, 4, 14, 25, 22, 0, "MMMM", "آبان")]
        [InlineData(1394, 9, 4, 14, 25, 22, 0, "MMMM", "آذر")]
        [InlineData(1394, 10, 4, 14, 25, 22, 0, "MMMM", "دی")]
        [InlineData(1394, 11, 4, 14, 25, 22, 0, "MMMM", "بهمن")]
        [InlineData(1394, 12, 4, 14, 25, 22, 0, "MMMM", "اسفند")]
        public void ToStringWithMonthFormat(int year, int month, int day, int hour, int minute, int second, int millisecond, string formatStr, string formattedStr)
        {
            var actual = new PersianDateTime(year, month, day, hour, minute, second, millisecond).ToString(formatStr);
            Assert.Equal(formattedStr, actual);
        }

        [Theory]
        [InlineData(1394, 1, 4, 14, 25, 22, 0, "d d", "4 4")]
        [InlineData(1394, 2, 10, 14, 25, 22, 0, "d d", "10 10")]
        [InlineData(1394, 1, 4, 14, 25, 22, 0, "dd", "04")]
        [InlineData(1394, 2, 10, 14, 25, 22, 0, "dd", "10")]
        [InlineData(1393, 3, 10, 14, 25, 22, 0, "ddd", "شنبه")]
        [InlineData(781, 1, 8, 14, 25, 22, 0, "ddd", "یکشنبه")]
        [InlineData(1393, 2, 1, 14, 25, 22, 0, "ddd", "دوشنبه")]
        [InlineData(1391, 12, 29, 14, 25, 22, 0, "ddd", "سه شنبه")]
        [InlineData(1393, 2, 10, 14, 25, 22, 0, "ddd", "چهارشنبه")]
        [InlineData(1393, 1, 7, 14, 25, 22, 0, "ddd", "پنج شنبه")]
        [InlineData(781, 1, 6, 14, 25, 22, 0, "ddd", "جمعه")]
        [InlineData(1393, 12, 9, 14, 25, 22, 0, "dddd", "شنبه")]
        [InlineData(1393, 9, 16, 14, 25, 22, 0, "dddd", "یکشنبه")]
        [InlineData(1395, 12, 30, 14, 25, 22, 0, "dddd", "دوشنبه")]
        [InlineData(1393, 7, 8, 14, 25, 22, 0, "dddd", "سه شنبه")]
        [InlineData(1393, 2, 10, 14, 25, 22, 0, "dddd", "چهارشنبه")]
        [InlineData(1393, 1, 7, 14, 25, 22, 0, "dddd", "پنج شنبه")]
        [InlineData(1393, 12, 29, 14, 25, 22, 0, "dddd", "جمعه")]
        public void ToStringWithDayFormat(int year, int month, int day, int hour, int minute, int second, int millisecond, string formatStr, string formattedStr)
        {
            var actual = new PersianDateTime(year, month, day, hour, minute, second, millisecond).ToString(formatStr);
            Assert.Equal(formattedStr, actual);
        }

        [Theory]
        [InlineData(1393, 10, 4, 1, 0, 0, 0, "h h", "1 1")]
        [InlineData(1393, 10, 4, 10, 0, 0, 0, "h h", "10 10")]
        [InlineData(1393, 10, 4, 13, 0, 0, 0, "h h", "1 1")]
        [InlineData(1393, 10, 4, 1, 0, 0, 0, "hh", "01")]
        [InlineData(1393, 10, 4, 10, 0, 0, 0, "hh", "10")]
        [InlineData(1393, 10, 4, 13, 0, 0, 0, "hh", "01")]
        [InlineData(1393, 10, 4, 1, 0, 0, 0, "H H", "1 1")]
        [InlineData(1393, 10, 4, 10, 0, 0, 0, "H H", "10 10")]
        [InlineData(1393, 10, 4, 13, 0, 0, 0, "H H", "13 13")]
        [InlineData(1393, 10, 4, 1, 0, 0, 0, "HH", "01")]
        [InlineData(1393, 10, 4, 10, 0, 0, 0, "HH", "10")]
        [InlineData(1393, 10, 4, 13, 0, 0, 0, "HH", "13")]
        public void ToStringWithHourFormat(int year, int month, int day, int hour, int minute, int second, int millisecond, string formatStr, string formattedStr)
        {
            var actual = new PersianDateTime(year, month, day, hour, minute, second, millisecond).ToString(formatStr);
            Assert.Equal(formattedStr, actual);
        }

        [Theory]
        [InlineData(1393, 10, 4, 0, 1, 0, 0, "m m", "1 1")]
        [InlineData(1393, 10, 4, 0, 10, 0, 0, "m m", "10 10")]
        [InlineData(1393, 10, 4, 0, 1, 0, 0, "mm", "01")]
        [InlineData(1393, 10, 4, 0, 10, 0, 0, "mm", "10")]
        public void ToStringWithMinuteFormat(int year, int month, int day, int hour, int minute, int second, int millisecond, string formatStr, string formattedStr)
        {
            var actual = new PersianDateTime(year, month, day, hour, minute, second, millisecond).ToString(formatStr);
            Assert.Equal(formattedStr, actual);
        }

        [Theory]
        [InlineData(1393, 10, 4, 0, 1, 1, 0, "s s", "1 1")]
        [InlineData(1393, 10, 4, 0, 10, 10, 0, "s s", "10 10")]
        [InlineData(1393, 10, 4, 0, 1, 1, 0, "ss", "01")]
        [InlineData(1393, 10, 4, 0, 50, 50, 0, "ss", "50")]
        public void ToStringWithSecondFormat(int year, int month, int day, int hour, int minute, int second, int millisecond, string formatStr, string formattedStr)
        {
            var actual = new PersianDateTime(year, month, day, hour, minute, second, millisecond).ToString(formatStr);
            Assert.Equal(formattedStr, actual);
        }

        [Theory]
        [InlineData(1393, 10, 4, 0, 1, 1, 0, "t t", "ق.ظ ق.ظ")]
        [InlineData(1393, 10, 4, 13, 10, 10, 0, "t t", "ب.ظ ب.ظ")]
        [InlineData(1393, 10, 4, 11, 1, 1, 0, "tt", "ق.ظ")]
        [InlineData(1393, 10, 4, 23, 50, 50, 0, "tt", "ب.ظ")]
        public void ToStringWithAmPmDesignatorFormat(int year, int month, int day, int hour, int minute, int second, int millisecond, string formatStr, string formattedStr)
        {
            var actual = new PersianDateTime(year, month, day, hour, minute, second, millisecond).ToString(formatStr);
            Assert.Equal(formattedStr, actual);
        }

        [Theory]
        [InlineData(1393, 10, 4, 11, 1, 3, 0, "04/10/1393 11:01:03 ق.ظ")]
        [InlineData(1393, 1, 4, 23, 1, 3, 0, "04/01/1393 11:01:03 ب.ظ")]
        [InlineData(1393, 10, 14, 0, 13, 23, 0, "14/10/1393 00:13:23 ق.ظ")]
        [InlineData(1393, 10, 14, 23, 14, 3, 0, "14/10/1393 11:14:03 ب.ظ")]
        public void ToStringWithEmptyFormat(int year, int month, int day, int hour, int minute, int second, int millisecond, string formattedStr)
        {
            var actual = new PersianDateTime(year, month, day, hour, minute, second, millisecond).ToString();
            Assert.Equal(formattedStr, actual);
        }

        [Theory]
        [InlineData(1393, 10, 4, 11, 1, 3, 0, "d", "04/10/1393")]
        [InlineData(13, 10, 4, 11, 1, 3, 0, "d", "04/10/0013")]
        [InlineData(1393, 12, 8, 11, 1, 3, 0, "d", "08/12/1393")]
        [InlineData(1393, 10, 4, 11, 1, 3, 0, "D", "پنج شنبه، 04 دی 1393")]
        [InlineData(13, 10, 4, 11, 1, 3, 0, "D", "پنج شنبه، 04 دی 0013")]
        [InlineData(1393, 12, 8, 11, 1, 3, 0, "D", "جمعه، 08 اسفند 1393")]
        [InlineData(1393, 10, 4, 11, 1, 3, 0, "t", "11:01 ق.ظ")]
        [InlineData(1393, 1, 4, 23, 1, 43, 0, "t", "11:01 ب.ظ")]
        [InlineData(1393, 10, 14, 0, 13, 23, 0, "t", "00:13 ق.ظ")]
        [InlineData(1393, 10, 4, 11, 1, 3, 0, "T", "11:01:03 ق.ظ")]
        [InlineData(1393, 1, 4, 23, 1, 43, 0, "T", "11:01:43 ب.ظ")]
        [InlineData(1393, 10, 14, 0, 0, 0, 100, "T", "00:00:00 ق.ظ")]
        [InlineData(1393, 10, 4, 11, 1, 3, 0, "f", "پنج شنبه، 04 دی 1393 11:01 ق.ظ")]
        [InlineData(1393, 1, 4, 23, 1, 43, 0, "f", "دوشنبه، 04 فروردین 1393 11:01 ب.ظ")]
        [InlineData(1393, 10, 14, 0, 13, 23, 0, "f", "یکشنبه، 14 دی 1393 00:13 ق.ظ")]
        [InlineData(1393, 10, 4, 11, 1, 3, 0, "F", "پنج شنبه، 04 دی 1393 11:01:03 ق.ظ")]
        [InlineData(1393, 1, 4, 23, 1, 43, 0, "F", "دوشنبه، 04 فروردین 1393 11:01:43 ب.ظ")]
        [InlineData(1393, 10, 14, 0, 13, 23, 100, "F", "یکشنبه، 14 دی 1393 00:13:23 ق.ظ")]
        public void ToStringWithGeneralFormat(int year, int month, int day, int hour, int minute, int second, int millisecond, string formatStr, string formattedStr)
        {
            var actual = new PersianDateTime(year, month, day, hour, minute, second, millisecond).ToString(formatStr);
            Assert.Equal(formattedStr, actual);
        }


        [Theory]
        [InlineData(1250, 10, 4, 11, 1, 3, 0, "04/10/1250")]
        [InlineData(13, 10, 4, 11, 1, 3, 0, "04/10/0013")]
        [InlineData(1, 12, 8, 11, 1, 3, 0, "08/12/0001")]
        [InlineData(1967, 12, 8, 11, 1, 3, 0, "08/12/1967")]
        public void ToShortDateString(int year, int month, int day, int hour, int minute, int second, int millisecond, string formattedStr)
        {
            var actual = new PersianDateTime(year, month, day, hour, minute, second, millisecond).ToShortDateString();
            Assert.Equal(formattedStr, actual);
        }

        [Theory]
        [InlineData(1393, 10, 4, 11, 1, 3, 0, "پنج شنبه، 04 دی 1393")]
        [InlineData(1, 10, 4, 11, 1, 3, 0, "چهارشنبه، 04 دی 0001")]
        [InlineData(1898, 12, 8, 11, 1, 3, 0, "سه شنبه، 08 اسفند 1898")]
        public void ToLongDateString(int year, int month, int day, int hour, int minute, int second, int millisecond, string formattedStr)
        {
            var actual = new PersianDateTime(year, month, day, hour, minute, second, millisecond).ToLongDateString();
            Assert.Equal(formattedStr, actual);
        }

        [Theory]
        [InlineData(1393, 10, 4, 11, 1, 3, 0, "11:01 ق.ظ")]
        [InlineData(1393, 1, 4, 23, 1, 43, 0, "11:01 ب.ظ")]
        [InlineData(1393, 10, 14, 0, 13, 23, 0, "00:13 ق.ظ")]
        public void ToShortTimeString(int year, int month, int day, int hour, int minute, int second, int millisecond, string formattedStr)
        {
            var actual = new PersianDateTime(year, month, day, hour, minute, second, millisecond).ToShortTimeString();
            Assert.Equal(formattedStr, actual);
        }

        [Theory]
        [InlineData(1393, 10, 4, 0, 0, 0, 0, "00:00:00 ق.ظ")]
        [InlineData(1393, 1, 4, 23, 59, 59, 999, "11:59:59 ب.ظ")]
        [InlineData(1393, 10, 14, 1, 0, 0, 100, "01:00:00 ق.ظ")]
        public void ToLongTimeString(int year, int month, int day, int hour, int minute, int second, int millisecond, string formattedStr)
        {
            var actual = new PersianDateTime(year, month, day, hour, minute, second, millisecond).ToLongTimeString();
            Assert.Equal(formattedStr, actual);
        }

        [Fact]
        public void Now_ReturnsCorrectPersianDateTime()
        {
            var systemClockStub = new Mock<SystemClock>();
            systemClockStub.SetupGet(x => x.Now).Returns(new DateTime(2015, 1, 1, 23, 59, 59));
            PersianDateTime.Clock = systemClockStub.Object;

            Assert.Equal(new PersianDateTime(1393, 10, 11, 23, 59, 59), PersianDateTime.Now);
        }

        [Fact]
        public void Today_ReturnsCorrectPersianDateTime()
        {
            var systemClockStub = new Mock<SystemClock>();
            systemClockStub.SetupGet(x => x.Now).Returns(new DateTime(2015, 1, 1, 23, 59, 59));
            PersianDateTime.Clock = systemClockStub.Object;

            Assert.Equal(new PersianDateTime(1393, 10, 11, 0, 0, 0), PersianDateTime.Today);
        }

        [Theory]
        [PropertyData("PersianDateAndObjectForEqualityTest")]
        public void ObjectEquals(PersianDateTime pdt, object obj, bool expected)
        {
            Assert.Equal(expected, pdt.Equals(obj));
        }

        [Theory]
        [PropertyData("PersianDateAndPersianDateForEqualityTest")]
        public void PersianDateTimeEquals(PersianDateTime pdt1, PersianDateTime pdt2, bool expected)
        {
            Assert.Equal(expected, pdt1.Equals(pdt2));
        }

        [Theory]
        [PropertyData("PersianDateAndObjectCompareToTest")]
        public void ObjectCompareTo_ValueToCompareIsDateTimeOrPersianDateTime(PersianDateTime pdt, object obj, int expected)
        {
            Assert.Equal(expected, pdt.CompareTo(obj));
        }

        [Fact]
        public void ObjectCompareTo_ValueToCompareIsNotDateTimeOrPersianDateTime_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new PersianDateTime(DateTime.Now).CompareTo(new Object()));
        }

        [Theory]
        [PropertyData("PersianDateTimeAndPersianDateTimeCompareToTest")]
        public void PersianDateTimeCompareTo(PersianDateTime pdt1, PersianDateTime pdt2, int expected)
        {
            Assert.Equal(expected, pdt1.CompareTo(pdt2));
        }

        [Theory]
        [PropertyData("PersianDateTimeAndPersianDateTimeCompareToTest")]
        public void PersianDateTimeComopare(PersianDateTime pdt1, PersianDateTime pdt2, int expected)
        {
            Assert.Equal(expected, PersianDateTime.Compare(pdt1, pdt2));
        }
    }
}
