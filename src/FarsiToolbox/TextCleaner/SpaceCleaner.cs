using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarsiToolbox.TextCleaner
{
    /// <summary>
    /// A TextCleaner for replacing duplicate spaces with single spaces.
    /// </summary>
    internal class SpaceCleaner : TextCleaner
    {
        internal SpaceCleaner(TextCleaner cleaner = null)
            :base(cleaner)
        {
        }

        protected override string Transform(string input)
        {
            var splittedInput = input.Split(new[] { '\t', ' ' });
            return string.Join(" ", splittedInput.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray());
        }
    }
}
