using System.Collections.Generic;
using System.Linq;

namespace NUnit.Extras
{
    internal static class StringExtensions
    {
        internal static string[] SplitIntoWords(this string value)
        {
            char[] chars = value.ToCharArray();

            List<char> wordChars = new List<char>();
            List<string> words = new List<string>();

            if (char.IsLetterOrDigit(chars[0]))
                wordChars.Add(chars[0]);

            void EndWord()
            {
                if (wordChars.Any())
                {
                    words.Add(new string(wordChars.ToArray()));
                    wordChars.Clear();
                }
            }

            for (int i = 1; i < chars.Length; i++)
            {
                char current = chars[i];
                char prev = chars[i - 1];
                char? next = i + 1 < chars.Length ? (char?)chars[i + 1] : null;

                if (!char.IsLetterOrDigit(current))
                {
                    EndWord();
                }
                else if ((char.IsDigit(current) && char.IsLetter(prev)) ||
                    (char.IsLetter(current) && char.IsDigit(prev)) ||
                    (char.IsUpper(current) && char.IsLower(prev)) ||
                    (char.IsUpper(current) && next != null && char.IsLower(next.Value)))
                {
                    EndWord();
                    wordChars.Add(current);
                }
                else
                {
                    wordChars.Add(current);
                }
            }

            EndWord();

            return words.ToArray();
        }
    }
}
