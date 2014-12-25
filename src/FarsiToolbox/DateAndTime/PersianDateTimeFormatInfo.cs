using System.Globalization;

namespace FarsiToolbox.DateAndTime
{
    internal static class PersianDateTimeFormatInfo
    {
        internal static DateTimeFormatInfo DateTimeFormatInfo { get; private set; }

        static PersianDateTimeFormatInfo()
        {
            var dtFormatInfo = DateTimeFormatInfo.GetInstance(new CultureInfo("fa"));
            var monthNames = new[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", "" };
            dtFormatInfo.AbbreviatedMonthGenitiveNames = dtFormatInfo.MonthNames = monthNames;
            dtFormatInfo.AbbreviatedMonthNames = dtFormatInfo.MonthGenitiveNames = monthNames;
            var dayNames = new[] { "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنج شنبه", "جمعه", "شنبه" };
            dtFormatInfo.DayNames = dtFormatInfo.AbbreviatedDayNames = dayNames;
            DateTimeFormatInfo = dtFormatInfo;
        }
    }

}
