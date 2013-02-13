using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anti
{
    public static class Layout
    {
        static string english = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ[];',./{}<>?`~";
        static string[] arabic = { "ش", "لا", "ؤ", "ي", "ث", "ب", "ل", "ا", "ه", "ت", "ن", "م", "ة", "ى", "خ", "ح", "ض", "ق", "س", "ف", "ع", "ر", "ص", "ء", "غ", "ئ",
                                   "ِ", "لآ", "}", "]", "ُ", "[", "لأ", "أ", "÷", "ـ", "،", "/", "’", "آ", "×", "؛", "َ", "ٌ", "ٍ", "لإ", "‘", "{", "ً", "ْ", "إ", "~",
                                   "ج", "د", "ك", "ط", "و", "ز", "ظ", "<", ">", ",", ".", "؟", "ذ", "ّ" };
        static Dictionary<char, string> toArabic = new Dictionary<char, string>();
        static Dictionary<string, char> toEnglish = new Dictionary<string, char>();

        static Layout()
        {
            for (int i = 0; i < english.Length; i++)
            {
                toArabic.Add(english[i], arabic[i]);
                toEnglish.Add(arabic[i], english[i]);
            }
        }

        public static string ToArabic(string text)
        {
            StringBuilder str = new StringBuilder();
            foreach (char c in text)
                if (toArabic.ContainsKey(c))
                    str.Append(toArabic[c]);
                else
                    str.Append(c);
            return str.ToString();
        }

        public static string ToEnglish(string text)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
                if (i + 1 < text.Length && toEnglish.ContainsKey(text.Substring(i, 2)))
                    str.Append(toEnglish[text.Substring(i++, 2)]);
                else if (toEnglish.ContainsKey(text[i].ToString()))
                    str.Append(toEnglish[text[i].ToString()]);
                else
                    str.Append(text[i]);
            return str.ToString();
        }

        public static bool IsArabic(string text)
        {
            return text.Count(c => c >= '\u0600' && c <= '\u06FF') > text.Count(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'));
        }

        public static string Auto(string text)
        {
            return IsArabic(text) ? ToEnglish(text) : ToArabic(text);
        }
    }
}
