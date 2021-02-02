using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DadJokes.Api.Entities;
using DadJokes.Utilities;

namespace DadJokes.Api.Utilities
{
    public static class JokeHelpers
    {
        public static IDictionary<string, IEnumerable<string>> GroupJokesBySize(IEnumerable<JokeResponse> jokeResponses)
        {
            var resultsGrouped = new Dictionary<string, IEnumerable<string>>();

            var shortGroup = jokeResponses.Where(j => j.Size == nameof(JokeSize.Short)).Select(j => j.Joke);
            resultsGrouped.Add(nameof(JokeSize.Short), shortGroup);

            var mediumGroup = jokeResponses.Where(j => j.Size == nameof(JokeSize.Medium)).Select(j => j.Joke);
            resultsGrouped.Add(nameof(JokeSize.Medium), mediumGroup);

            var longGroup = jokeResponses.Where(j => j.Size == nameof(JokeSize.Long)).Select(j => j.Joke);
            resultsGrouped.Add(nameof(JokeSize.Long), longGroup);

            return resultsGrouped;
        }

        public static IEnumerable<JokeResponse> EmphasizeWithUppercase(this IEnumerable<JokeResponse> jokeResponses, string termToEmphasize)
        {
            // TODO: Clean up

            var emphasizedJoke = jokeResponses;

            // Account for cases where there are two or more terms in the search term
            var splitSearchTerms = termToEmphasize.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var jokeReponse in emphasizedJoke)
            {
                foreach (var splitSearchTerm in splitSearchTerms)
                {
                    jokeReponse.Joke = jokeReponse.Joke.EmphasizeWithUppercase(splitSearchTerm);
                }
            }

            return emphasizedJoke;
        }
    }
}
