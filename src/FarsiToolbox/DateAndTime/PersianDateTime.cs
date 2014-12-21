using System;
using System.Globalization;

namespace FarsiToolbox.DateAndTime
{
    /// <summary>
    /// Represents a Hijri Shamsi date
    /// </summary>
    public class PersianDateTime
    {
        /// <summary>
        /// Gets the Hijri Shamsi Year
        /// </summary>
        public int Year { get; private set; }

        /// <summary>
        /// Gets the Hijri Shamsi Month
        /// </summary>
        public int Month { get; private set; }

        /// <summary>
        /// Gets the  Hijri Shamsi Day
        /// </summary>
        public int Day { get; private set; }

        /// <summary>
        /// Gets Hour
        /// </summary>
        public int Hour { get; private set; }

        /// <summary>
        /// Gets Minute
        /// </summary>
        public int Minute { get; private set; }

        /// <summary>
        /// Gets Second
        /// </summary>
        public int Second { get; private set; }

        /// <summary>
        /// Gets MilliSecond
        /// </summary>
        public int MilliSecond { get; private set; }

        private static PersianCalendar _calendar = new PersianCalendar();

        /// <summary>
        /// Creates an instance of PersianDateTime
        /// </summary>
        /// <param name="year">Shamsi Year</param>
        /// <param name="month">Shamsi Month</param>
        /// <param name="day">Shamsi Day</param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="milliSecond"></param>
        public PersianDateTime(int year, int month, int day, int hour = 0, int minute = 0, int second = 0, int milliSecond = 0)
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
            MilliSecond = milliSecond;
        }

        /// <summary>
        /// Creates an instance of PersianDateTime from an existing DateTimes
        /// </summary>
        /// <param name="dateTime"></param>
        public PersianDateTime(DateTime dateTime)
        {
            Year = _calendar.GetYear(dateTime);
            Month = _calendar.GetMonth(dateTime);
            Day = _calendar.GetDayOfMonth(dateTime);
            Hour = dateTime.Hour;
            Minute = dateTime.Minute;
            Second = dateTime.Second;
            MilliSecond = dateTime.Millisecond;
        }
    }
}
