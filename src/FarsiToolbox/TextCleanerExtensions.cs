using FarsiToolbox.TextCleaner;

namespace FarsiToolbox
{
    /// <summary>
    /// Includes extension methods for text cleaning
    /// </summary>
    public static class TextCleanerExtensions
    {
        /// <summary>
        /// Replace Arabic ye and kaf with Farsi
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ReplaceYeKaf(this string input)
        {
            return new ArabicYeKafCleaner().Clean(input);
        }
    }
}
