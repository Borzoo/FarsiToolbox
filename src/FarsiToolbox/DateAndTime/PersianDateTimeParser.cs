using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FarsiToolbox.DateAndTime
{
    internal class PersianDateTimeParser
    {
        /// <summary>
        /// Matches: 1394/1/5 or 1394-1-05 or 1394/01/5 or 1394/01/05 or 94/01/5 or 94/1/05
        /// </summary>
        const string PersianDatePattern = @"(?<year>(\d){1,4})[/-](?<month>0[1-9]|[1-9]|1[0-2])[/-](?<day>1[0-9]|2[0-9]|3[0-1]|0[1-9]|[1-9])";

        public bool TryParse(string dateTimeStr, out PersianDateTime dateTime)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dateTimeStr))
                {
                    dateTime = new PersianDateTime();
                    return false;
                }

                var regex = new Regex(PersianDatePattern);
                var matchResult = regex.Match(dateTimeStr);
                if (!matchResult.Success)
                {
                    dateTime = new PersianDateTime();
                }
                else
                {
                    var year = int.Parse(matchResult.Groups["year"].Value);

                    // TODO: This is subjective. Improve it if you have any better idea and make sure you've updated related UnitTests.
                    if (year < 50)
                        year = 1400 + year;
                    else if (year >= 50 && year <= 99)
                        year = 1300 + year;

                    var month = int.Parse(matchResult.Groups["month"].Value);
                    var day = int.Parse(matchResult.Groups["day"].Value);

                    if (dateTimeStr.Length > matchResult.Length)
                    {
                        // Use .NET time parser
                        var timeString = dateTimeStr.Substring(matchResult.Length);
                        DateTime time;
                        var isValidTime = DateTime.TryParse(timeString, out time);
                        if (!isValidTime)
                        {
                            dateTime = new PersianDateTime();
                            return isValidTime;
                        }

                        dateTime = new PersianDateTime(year, month, day, time.Hour, time.Minute, time.Second, time.Millisecond);
                    }
                    else
                        dateTime = new PersianDateTime(year, month, day);
                }
                return matchResult.Success;
            }
            catch
            {
                return false;
                dateTime = new PersianDateTime();
            }
        }

        public PersianDateTime Parse(string dateTime)
        {
            PersianDateTime dt;
            if (!TryParse(dateTime, out dt))
                throw new ArgumentException("Input date (and time) is not valid.", "dateTime");

            return dt;
        }
    }
}
