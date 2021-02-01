using System;
using System.Collections.Generic;
using System.Linq;

namespace DadJokes.Utilities
{
    public static class Grouper
    {
        public static IList<IEnumerable<string>> GroupByWordLength(IEnumerable<string> strings)
        {
            // three groups: <10 words, <20 words, and >= 20 words.
            var lessThan10 = strings.Where(x => x.NumberOfWords() < 10);
            var lessThan20GreaterThanOrEqualTo10 = strings.Where(x => x.NumberOfWords() < 20).Where(x => x.NumberOfWords() >= 10);
            var greaterThanOrEqualTo20 = strings.Where(x => x.NumberOfWords() >= 20);

            var groups = new List<IEnumerable<string>>();
            groups.Add(lessThan10);
            groups.Add(lessThan20GreaterThanOrEqualTo10);
            groups.Add(greaterThanOrEqualTo20);

            return groups;
        }

        // TODO: Need to move or rename class
        public static int NumberOfWords(this string input)
        {
            return input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
