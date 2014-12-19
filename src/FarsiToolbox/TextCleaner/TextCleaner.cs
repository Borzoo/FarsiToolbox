using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarsiToolbox.TextCleaner
{
    /// <summary>
    /// Includes text cleaning functions
    /// </summary>
    internal abstract class TextCleaner
    {
        private TextCleaner _cleaner;

        internal TextCleaner(TextCleaner cleaner = null)
        {
            _cleaner = cleaner;
        }

        internal string Clean(string input)
        {
            if (_cleaner != null)
            {
                input = _cleaner.Clean(input);
            }

            return Transform(input);
        }

        /// <summary>
        /// Transforms input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected abstract string Transform(string input);
    }

}
