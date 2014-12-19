using FarsiToolbox.TextCleaner;

namespace FarsiToolbox
{
    public static class TextCleanerExtensions
    {
        public static string ReplaceYeKaf(this string input)
        {
            return new ArabicYeKafCleaner().Clean(input);
        }
    }
}
