using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FarsiToolbox.DateAndTime
{
    internal static class PersianDateTimeFormatter
    {
        private static Dictionary<char, Func<PersianDateTime, DateTimeFormatInfo, int, string>> _formatters = new Dictionary<char, Func<PersianDateTime, DateTimeFormatInfo, int, string>>()
        {
            { 'y', GetFormattedYear },
            { 'M', GetFormattedMonth },
            { 'd',  GetFormattedDay},
            { 'h', GetFormattedHour12},
            { 'H', GetFormattedHour24},
            { 'm', GetFormattedMinute},
            { 's', GetFormattedSecond},
            { 't', GetFormattedDesignator}
        };

        private static string PadFormattedPart(int formattedPart, int repeat)
        {
            return formattedPart.ToString().PadLeft(repeat, '0');
        }

        private static string GetFormattedYear(PersianDateTime pdt, DateTimeFormatInfo formatInfo, int repeat)
        {
            if (repeat == 1)
            {
                return PadFormattedPart((pdt.Year % 10), 1);
            }
            else if (repeat == 2)
            {
                return PadFormattedPart((pdt.Year % 100), 2);
            }
            else if (repeat == 3)
            {
                return PadFormattedPart((pdt.Year % 1000), 3);
            }
            else
            {
                return PadFormattedPart(pdt.Year, repeat);
            }
        }

        private static string GetFormattedMonth(PersianDateTime pdt, DateTimeFormatInfo formatInfo, int repeat)
        {
            if (repeat <= 2)
            {
                return PadFormattedPart(pdt.Month, repeat);
            }
            else
            {
                return formatInfo.MonthNames[pdt.Month - 1];
            }
        }

        private static string GetFormattedDay(PersianDateTime pdt, DateTimeFormatInfo formatInfo, int repeat)
        {
            if (repeat <= 2)
            {
                return PadFormattedPart(pdt.Day, repeat);
            }
            else
            {
                return formatInfo.DayNames[pdt.DayOfWeek];
            }
        }

        private static string GetFormattedHour12(PersianDateTime pdt, DateTimeFormatInfo formatInfo, int repeat)
        {
            var hour = pdt.Hour;

            if (pdt.Hour > 12)
            {
                hour -= 12;
            }

            return PadFormattedPart(hour, repeat);
        }

        private static string GetFormattedHour24(PersianDateTime pdt, DateTimeFormatInfo formatInfo, int repeat)
        {
            return PadFormattedPart(pdt.Hour, repeat);
        }

        private static string GetFormattedMinute(PersianDateTime pdt, DateTimeFormatInfo formatInfo, int repeat)
        {
            return PadFormattedPart(pdt.Minute, repeat);
        }

        private static string GetFormattedSecond(PersianDateTime pdt, DateTimeFormatInfo formatInfo, int repeat)
        {
            return PadFormattedPart(pdt.Second, repeat);
        }

        private static string GetFormattedDesignator(PersianDateTime pdt, DateTimeFormatInfo formatInfo, int repeat)
        {
            return pdt.Hour < 12 ? formatInfo.AMDesignator : formatInfo.PMDesignator;
        }

        private static int GetTokenLength(string format, int index, char formatChar)
        {
            int lastConsecutiveFormatCharOccurance = index;

            while (lastConsecutiveFormatCharOccurance < format.Length && format[lastConsecutiveFormatCharOccurance] == formatChar)
            {
                lastConsecutiveFormatCharOccurance++;
            }

            return (lastConsecutiveFormatCharOccurance - index);
        }

        private static string GetPredefinedFormat(char format, DateTimeFormatInfo formatInfo)
        {
            var expandedFormat = string.Empty;

            switch (format)
            {
                case 'g':
                    expandedFormat = formatInfo.ShortDatePattern + " " + formatInfo.ShortTimePattern;
                    break;
                case 'G':
                    expandedFormat = formatInfo.ShortDatePattern + " " + formatInfo.LongTimePattern;
                    break;
                default:
                    throw new FormatException("Invalid format : " + format);
            }

            return expandedFormat;
        }

        internal static string Format(PersianDateTime persianDateTime, string format, DateTimeFormatInfo formatInfo)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "G";
            }
            if (format.Length == 1)
            {
                format = GetPredefinedFormat(format[0], formatInfo);
            }

            var index = 0;
            var result = new StringBuilder();

            while (index < format.Length)
            {
                var formatChar = format[index];
                var tokenLength = GetTokenLength(format, index, formatChar);
                if (_formatters.ContainsKey(formatChar))
                {
                    result.Append(_formatters[formatChar](persianDateTime, formatInfo, tokenLength));
                }
                else
                {
                    result.Append(formatChar);
                    tokenLength = 1;
                }
                index += tokenLength;
            }

            return result.ToString();
        }
    }
}
