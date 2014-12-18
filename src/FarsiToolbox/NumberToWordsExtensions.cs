using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarsiToolbox
{
    public static class NumberToWordsExtensions
    {
        /// <summary>
        /// Converts the passed number to written Farsi
        /// </summary>
        /// <param name="number">Number to convert to words</param>
        /// <example>
        /// <para>1 is converted to یک</para>
        /// <para>2 is converted to دو</para>
        /// </example>
        /// <returns></returns>
        public static string ToWords(this int number)
        {
            return new NumberToWords().Convert(number);
        }

        /// <summary>
        /// Converts the passed number to ordinal written Farsi
        /// </summary>
        /// <example>
        /// <para>1 is converted to اول</para>
        /// <para>2 is converted to دوم</para>
        /// </example>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ToOrdinalWords(this int number)
        {
            return new NumberToWords().ConvertToOrdinal(number);
        }
    }
}
