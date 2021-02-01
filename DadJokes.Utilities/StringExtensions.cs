using System;
using System.Collections.Generic;
using System.Linq;

namespace DadJokes.Utilities
{
    /// <summary>
    /// Provides string extension methods. 
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Searches for a term in the input and emphasizes it by making it all uppercase.
        /// </summary>
        /// <param name="input">Input to search for the term.</param>
        /// <param name="termToEmphasize">The term to search for.</param>
        /// <returns>Returns tne original input string with the searched term in all uppercase, if any were found.</returns>
        public static string EmphasizeWithUppercase(this string input, string termToEmphasize)
        {
            if (string.IsNullOrWhiteSpace(termToEmphasize))
            {
                throw new ArgumentOutOfRangeException();
            }

            string output = input
                .Replace(termToEmphasize.ToLower(), termToEmphasize.ToUpper())
                .Replace(Char.ToUpper(termToEmphasize[0]) + input.Substring(1), termToEmphasize.ToUpper());

            return output;
        }

        /// <summary>
        /// Gets the number of words in the input string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The number of words in the input string.</returns>
        public static int GetNumberOfWords(this string input)
        {
            int output = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

            return output;
        }

        /// <summary>
        /// Groups collection of strings into three categories based on word length: short, medium and long.
        /// </summary>
        /// <param name="inputStrings">Collection of strings.</param>
        /// <param name="longLowerLimit">The lower word length limit for the long group.</param>
        /// <param name="mediumLowerLimit">The lower word length limit for the medium group.</param>
        /// <param name="shortLowerLimit">The lower word length limit for the short group.</param>
        /// <returns>Grouped string collections based on word length: short, medium and long.</returns>
        public static IList<IEnumerable<string>> ToGroupsByWordLength(
            this IEnumerable<string> inputStrings, int longLowerLimit, int mediumLowerLimit, int shortLowerLimit = 0)
        {
            if (longLowerLimit <= mediumLowerLimit || mediumLowerLimit <= shortLowerLimit)
            {
                throw new ArgumentOutOfRangeException();
            }

            var shorts = inputStrings
                .Where(x => x.GetNumberOfWords() < mediumLowerLimit)
                .Where(x => x.GetNumberOfWords() >= shortLowerLimit);

            var mediums = inputStrings
                .Where(x => x.GetNumberOfWords() < longLowerLimit)
                .Where(x => x.GetNumberOfWords() >= mediumLowerLimit);

            var longs = inputStrings
                .Where(x => x.GetNumberOfWords() >= longLowerLimit);

            var groups = new List<IEnumerable<string>>();
            groups.Add(shorts);
            groups.Add(mediums);
            groups.Add(longs);

            return groups;
        }
    }
}
