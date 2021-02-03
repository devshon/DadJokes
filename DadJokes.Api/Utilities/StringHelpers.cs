using System;

namespace DadJokes.Api.Utilities
{
    /// <summary>
    /// Provides string helper methods. 
    /// </summary>
    public static class StringHelpers
    {
        /// <summary>
        /// Searches for a term in the input string and emphasizes it by making it all uppercase.
        /// </summary>
        /// <param name="input">Input to search for the term.</param>
        /// <param name="termToEmphasize">The term to search for.</param>
        /// <returns>Returns tne original input string with the searched term in all uppercase, if any were found.</returns>
        public static string EmphasizeWithUppercase(this string input, string termToEmphasize)
        {
            if (string.IsNullOrWhiteSpace(termToEmphasize))
            {
                throw new ArgumentOutOfRangeException(nameof(termToEmphasize), "Value cannot be null or whitespace.");
            }

            string output = input
                .Replace(termToEmphasize.ToLower(), termToEmphasize.ToUpper())
                .Replace(Char.ToUpper(termToEmphasize[0]) + termToEmphasize.Substring(1), termToEmphasize.ToUpper());

            return output;
        }
    }
}
