using System;

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
    }
}
