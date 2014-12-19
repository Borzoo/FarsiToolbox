using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarsiToolbox.TextCleaner
{
    /// <summary>
    /// Text cleaner for replacing arabic ی and ک with Farsi
    /// </summary>
    internal class ArabicYeKafCleaner : TextCleaner
    {
        internal ArabicYeKafCleaner(TextCleaner cleaner = null)
            : base(cleaner)
        {
        }

        protected override string Transform(string input)
        {
            return input.Replace('\u064A', '\u06CC') //replace ی
                        .Replace('\u0643', '\u06A9'); //replace ک
        }
    }
}
