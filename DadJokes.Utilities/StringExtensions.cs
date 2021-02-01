using System;
using System.Collections.Generic;
using System.Linq;

namespace DadJokes.Utilities
{
    public static class StringExtensions
    {
        public static string EmphasizeWithUppercase(this string input, string termToEmphasize)
        {
            string output = input
                .Replace(termToEmphasize.ToLower(), termToEmphasize.ToUpper())
                .Replace(Char.ToUpper(termToEmphasize[0]) + input.Substring(1), termToEmphasize.ToUpper());

            return output;
        }

        public static int NumberOfWords(this string input)
        {
            int output = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

            return output;
        }

        public static IList<IEnumerable<string>> ToGroupsByWordLength(
            this IEnumerable<string> strings, int longLowerLimit, int mediumLowerLimit, int shortLowerLimit = 0)
        {
            if (longLowerLimit <= mediumLowerLimit || mediumLowerLimit <= shortLowerLimit)
            {
                throw new ArgumentOutOfRangeException();
            }

            var shorts = strings
                .Where(x => x.NumberOfWords() < mediumLowerLimit)
                .Where(x => x.NumberOfWords() >= shortLowerLimit);

            var mediums = strings
                .Where(x => x.NumberOfWords() < longLowerLimit)
                .Where(x => x.NumberOfWords() >= mediumLowerLimit);

            var longs = strings
                .Where(x => x.NumberOfWords() >= longLowerLimit);

            var groups = new List<IEnumerable<string>>();
            groups.Add(shorts);
            groups.Add(mediums);
            groups.Add(longs);

            return groups;
        }
    }
}
