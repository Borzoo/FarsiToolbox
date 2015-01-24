using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("FarsiToolboxTests")]
namespace FarsiToolbox.DateAndTime
{
    /// <summary>
    /// Represents a Hijri Shamsi date
    /// </summary>
    public struct PersianDateTime : IComparable, IEquatable<PersianDateTime>
    {
        private static PersianCalendar _calendar = new PersianCalendar();

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

        private long? _ticks;
        /// <summary>
        /// Gets the number of ticks that represent the date and time of this instance
        /// </summary>
        public long Ticks
        {
            get
            {
                return (_ticks ?? (_ticks = ((DateTime)this).Ticks)).Value;
            }
            private set
            {
                this._ticks = value;
            }
        }

        private TimeSpan? _timeOfDay;
        /// <summary>
        /// Gets the time of day for this instance
        /// </summary>
        public TimeSpan TimeOfDay
        {
            get
            {
                return (_timeOfDay ?? (_timeOfDay = new TimeSpan(0, this.Hour, this.Minute, this.Second, this.MilliSecond))).Value;
            }
        }

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
            Ticks = dateTime.Ticks;
        }

        /// <summary>
        /// Returns a value that indicates whether the value of this instance is equal to the value of the specified object
        /// </summary>
        /// <param name="obj">The object to compare to this instance</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is DateTime)
            {
                return this == (PersianDateTime)(DateTime)obj;
            }
            else if (obj is PersianDateTime)
            {
                return this == (PersianDateTime)obj;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the hash code for this instance
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            //taken from DateTime.GetHashCode
            return (((int)Ticks) ^ ((int)(Ticks >> 0x20)));
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
        ///  Converts the value of the current PersianDateTime object to its equivalent string representation using the provided format.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string format)
        {
            return PersianDateTimeFormatter.Format(this, format, PersianDateTimeFormatInfo.DateTimeFormatInfo);
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
        /// Compares this instance with the specified object that contains the specified PersianDateTime or DateTime and returns an integer
        /// that indicates whether this instance is earlier, the same as or later than the specified PersianDateTime or DateTime value.
        /// </summary>
        /// <param name="obj">A boxed object or null</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj is PersianDateTime)
            {
                return this.CompareTo((PersianDateTime)obj);
            }
            else if (obj is DateTime)
            {
                return this.CompareTo((PersianDateTime)(DateTime)obj);
            }
            else
            {
                throw new ArgumentException("Object must be of type PersianDateTime or DateTime.");
            }
        }

        /// <summary>
        /// Compares this instance with the specified PersianDateTime and returns an integer that indicates whether this instance
        /// is earlier, the same as or later than the specified PersianDateTime or DateTime value.
        /// </summary>
        /// <param name="pdt">The object to compare to current instance</param>
        /// <returns></returns>
        public int CompareTo(PersianDateTime pdt)
        {
            if (this == pdt)
            {
                return 0;
            }
            else if (this.Year != pdt.Year)
            {
                return this.Year > pdt.Year ? 1 : -1;
            }
            else if (this.Month != pdt.Month)
            {
                return this.Month > pdt.Month ? 1 : -1;
            }
            else if (this.Day != pdt.Day)
            {
                return this.Day > pdt.Day ? 1 : -1;
            }
            else
            {
                return this.TimeOfDay.CompareTo(pdt.TimeOfDay);
            }
        }

        /// <summary>
        /// Returns a value that indicates whether this instance is equal to the specified PersianDateTime instance
        /// </summary>
        /// <param name="other">The object to compare to current instance</param>
        /// <returns></returns>
        public bool Equals(PersianDateTime other)
        {
            return this == other;
        }

        /// <summary>
        /// Compares two instances of PersianDateTime and returns an integer that indicates whether the first instance is earlier than, the same as or later 
        /// than the second instance
        /// </summary>
        /// <param name="t1">The first instance to compare</param>
        /// <param name="t2">The second instance to compare</param>
        /// <returns></returns>
        public static int Compare(PersianDateTime t1, PersianDateTime t2)
        {
            return t1.CompareTo(t2);
        }

        /// <summary>
        /// Returns days in specified month of the specified year
        /// </summary>
        /// <param name="year">The year</param>
        /// <param name="month">The month - between 1 and 12</param>
        /// <returns>The number of days in month. Takes leap years into account.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static int DaysInMonth(int year, int month)
        {
            return _calendar.GetDaysInMonth(year, month);
        }

        /// <summary>
        /// Returns a value that indicates whether the specified year is a leap year
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public static bool IsLeapYear(int year)
        {
            return _calendar.IsLeapYear(year);
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
        /// Determines whether two instances of PersianDateTime are equal
        /// </summary>
        /// <param name="pdt1">First instance</param>
        /// <param name="pdt2">Second instance</param>
        /// <returns></returns>
        public static bool operator ==(PersianDateTime pdt1, PersianDateTime pdt2)
        {
            return pdt1.Year == pdt2.Year
                && pdt1.Month == pdt2.Month
                && pdt1.Day == pdt2.Day
                && pdt1.Hour == pdt2.Hour
                && pdt1.Minute == pdt2.Minute
                && pdt1.Second == pdt2.Second
                && pdt1.MilliSecond == pdt2.MilliSecond;
        }

        /// <summary>
        /// Determines whether two instances of PersianDateTime are not equal
        /// </summary>
        /// <param name="pdt1">First instance</param>
        /// <param name="pdt2">Second instance</param>
        /// <returns></returns>
        public static bool operator !=(PersianDateTime pdt1, PersianDateTime pdt2)
        {
            return !(pdt1 == pdt2);
        }

        /// <summary>
        /// Determines whether one instance of PersianDateTime is earlier than the other instance
        /// </summary>
        /// <param name="pdt1"></param>
        /// <param name="pdt2"></param>
        /// <returns></returns>
        public static bool operator <(PersianDateTime pdt1, PersianDateTime pdt2)
        {
            return pdt1.CompareTo(pdt2) < 0;
        }

        /// <summary>
        /// Determines whether one instance of PersianDateTime is earlier than or the same as the other instance
        /// </summary>
        /// <param name="pdt1"></param>
        /// <param name="pdt2"></param>
        /// <returns></returns>
        public static bool operator <=(PersianDateTime pdt1, PersianDateTime pdt2)
        {
            return pdt1.CompareTo(pdt2) <= 0;
        }

        /// <summary>
        /// Determines whether one instance of PersianDateTime is later than the other instance
        /// </summary>
        /// <param name="pdt1"></param>
        /// <param name="pdt2"></param>
        /// <returns></returns>
        public static bool operator >(PersianDateTime pdt1, PersianDateTime pdt2)
        {
            return pdt1.CompareTo(pdt2) > 0;
        }

        /// <summary>
        /// Determines whether one instance of PersianDateTime is later than or the same as the other instance
        /// </summary>
        /// <param name="pdt1"></param>
        /// <param name="pdt2"></param>
        /// <returns></returns>
        public static bool operator >=(PersianDateTime pdt1, PersianDateTime pdt2)
        {
            return pdt1.CompareTo(pdt2) >= 0;
        }
    }
}