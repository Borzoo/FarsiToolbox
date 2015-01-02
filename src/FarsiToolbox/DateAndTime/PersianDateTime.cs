using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly:InternalsVisibleTo("FarsiToolboxTests")]
namespace FarsiToolbox.DateAndTime
{
    /// <summary>
    /// Represents a Hijri Shamsi date
    /// </summary>
    public struct PersianDateTime
    {
        private static SystemClock _clock;

        /// <summary>
        /// Gets of sets the current clock of the system.
        /// </summary>
        internal static SystemClock Clock
        {
            get
            {
                return _clock ?? (_clock = new SystemClock());
            }
            set
            {
                _clock = value;
            }
        }

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

        /// <summary>
        /// Gets the day of week
        /// </summary>
        public int DayOfWeek { get; private set; }

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
            : this()
        {
            Year = year;
            Month = month;
            Day = day;
            DayOfWeek = (int)_calendar.GetDayOfWeek((DateTime)this);
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
            : this(_calendar.GetYear(dateTime), _calendar.GetMonth(dateTime), _calendar.GetDayOfMonth(dateTime),
                   dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond)
        {
        }

        /// <summary>
        /// Explicit cast operator from PersianDateTime to DateTime (Gregorian)
        /// </summary>
        /// <param name="persianDateTime"></param>
        /// <returns></returns>
        public static explicit operator DateTime(PersianDateTime persianDateTime)
        {
            return _calendar.ToDateTime(persianDateTime.Year, persianDateTime.Month, persianDateTime.Day, persianDateTime.Hour, persianDateTime.Minute, persianDateTime.Second, persianDateTime.MilliSecond);
        }

        /// <summary>
        /// Explicit cast operator from DateTime (Gregorian) to PersianDateTime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static explicit operator PersianDateTime(DateTime dateTime)
        {
            return new PersianDateTime(dateTime);
        }

        /// <summary>
        ///  Converts the value of the current PersianDateTime object to its equivalent string representation using the provided format.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string format)
        {
            return PersianDateTimeFormatter.Format(this, format, PersianDateTimeFormatInfo.DateTimeFormatInfo);
        }

        /// <summary>
        /// Converts the value of the current PersianDateTime object to its equivalent string representation using the default format.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return PersianDateTimeFormatter.Format(this, null, PersianDateTimeFormatInfo.DateTimeFormatInfo);
        }

        /// <summary>
        /// Converts the value of the current PersianDateTime object to long time string format.
        /// </summary>
        /// <returns></returns>
        public string ToLongTimeString()
        {
            return PersianDateTimeFormatter.Format(this, "T", PersianDateTimeFormatInfo.DateTimeFormatInfo);
        }

        /// <summary>
        /// Converts the value of the current PersianDateTime object to short time string format.
        /// </summary>
        /// <returns></returns>
        public string ToShortTimeString()
        {
            return PersianDateTimeFormatter.Format(this, "t", PersianDateTimeFormatInfo.DateTimeFormatInfo);
        }

        /// <summary>
        /// Converts the value of the current PersianDateTime object to long Date string format.
        /// </summary>
        /// <returns></returns>
        public string ToLongDateString()
        {
            return PersianDateTimeFormatter.Format(this, "D", PersianDateTimeFormatInfo.DateTimeFormatInfo);
        }

        /// <summary>
        /// Converts the value of the current PersianDateTime object to short date string format.
        /// </summary>
        /// <returns></returns>
        public string ToShortDateString()
        {
            return PersianDateTimeFormatter.Format(this, "d", PersianDateTimeFormatInfo.DateTimeFormatInfo);
        }

        /// <summary>
        /// Gets a PersianDateTime instance representing Now
        /// </summary>
        public static PersianDateTime Now
        {
            get
            {
                return new PersianDateTime(Clock.Now);
            }
        }

        /// <summary>
        /// Gets a PersianDateTime instance representing Today
        /// </summary>
        public static PersianDateTime Today
        {
            get
            {
                return new PersianDateTime(Clock.Now.Date);
            }
        }
    }
}