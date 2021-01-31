using System;

namespace DadJokes.Utilities
{
    public static class Emphasizer
    {
        public static string EmphasizeWithUppercase(this string input, string wordToEmphasize)
        {
            string output = input
                .Replace(wordToEmphasize.ToLower(), wordToEmphasize.ToUpper())
                .Replace(Char.ToUpper(wordToEmphasize[0]) + input.Substring(1), wordToEmphasize.ToUpper());

            return output;
        }
    }
}
