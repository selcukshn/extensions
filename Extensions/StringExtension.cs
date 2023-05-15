using System.Text.RegularExpressions;

namespace Console.Extensions
{
    public static class StringExtension
    {
        private static char[] TurkishChars = new char[] { 'ç', 'Ç', 'ğ', 'Ğ', 'ı', 'İ', 'ö', 'Ö', 'ş', 'Ş', 'ü', 'Ü' };
        private static Dictionary<char, char> TrToEng = new Dictionary<char, char>{
            {'ç','c'},{'Ç','C'},{'ğ','g'},{'Ğ','G'},{'ı','i'},{'İ','I'},{'ö','o'},{'Ö','O'},{'ş','s'},{'Ş','S'},{'ü','u'},{'Ü','U'}
        };
        public static string TurkishToEnglish(this String str, bool toLower = true)
        {
            foreach (var c in TrToEng)
            {
                str = str.Replace(c.Key, c.Value);
            }
            if (toLower)
                return str.ToLower();
            return str;
        }
        private static string ReplaceSpecialChars(this String str, string replaceChar, string pattern)
        {
            return new Regex(pattern).Replace(str, replaceChar);
        }
        public static string ReplaceSpecialChars(this String str, string replaceChar)
        {
            return ReplaceSpecialChars(str, replaceChar, @"[^a-zA-Z0-9\- ]");
        }
        public static string ReplaceSpecialChars(this String str, bool removeSpace, string replaceChar)
        {
            return ReplaceSpecialChars(str, replaceChar, removeSpace ? @"[^a-zA-Z0-9\-]" : @"[^a-zA-Z0-9\- ]");
        }
        public static string RemoveSpecialChars(this String str)
        {
            return new Regex(@"[^a-zA-Z0-9\-_ ]").Replace(str, "");
        }
        public static string RemoveSpecialChars(this String str, params char[] exclude)
        {
            string patternExt = string.Empty;
            foreach (var c in exclude)
            {
                patternExt += $"\\{c}";
            }
            return new Regex(@$"[^a-zA-Z0-9\-_{patternExt} ]").Replace(str, "");
        }
        public static string ReplaceSpaces(this String str, char replaceChar)
        {
            return str.Trim().Replace(' ', replaceChar);
        }
        public static string RemoveSpaces(this String str)
        {
            return str.Trim().Replace(" ", string.Empty);
        }

        public static string ToUrl(this String str)
        {
            return str.TurkishToEnglish().ReplaceSpaces('-').RemoveSpecialChars();
        }
    }
}