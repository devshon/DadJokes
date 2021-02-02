using System;
using System.Collections.Generic;
using System.Linq;
using DadJokes.Api.Entities;
using DadJokes.Utilities;
using Microsoft.AspNetCore.WebUtilities;

namespace DadJokes.Api.Utilities
{
    public static class DadJokeServiceHelpers
    {
        public static IEnumerable<JokeResponse> EmphasizeWithUppercase(this IEnumerable<JokeResponse> jokeResponses, string termToEmphasize)
        {
            // TODO: Clean up

            var emphasizedJokes = jokeResponses;

            // Account for cases where there are two or more terms in the search term
            var splitSearchTerms = termToEmphasize.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var joke in emphasizedJokes)
            {
                foreach (var splitSearchTerm in splitSearchTerms)
                {
                    joke.Joke = joke.Joke.EmphasizeWithUppercase(splitSearchTerm);
                }
            }

            return emphasizedJokes;
        }

        public static string GetSearchRequestUriWithQueryString(string endpoint, string term, int limit)
        {
            var queryStringParameters = new Dictionary<string, string>();
            queryStringParameters.Add("limit", limit.ToString());
            queryStringParameters.Add("term", term);

            return QueryHelpers.AddQueryString(endpoint, queryStringParameters);
        }

        public static IDictionary<string, IEnumerable<JokeResponse>> GroupByJokeSize(IEnumerable<JokeResponse> jokeResponses)
        {
            var resultsGrouped = new Dictionary<string, IEnumerable<JokeResponse>>();

            var shortGroup = jokeResponses.Where(j => j.Size == nameof(JokeSize.Short));
            resultsGrouped.Add(nameof(JokeSize.Short), shortGroup);

            var mediumGroup = jokeResponses.Where(j => j.Size == nameof(JokeSize.Medium));
            resultsGrouped.Add(nameof(JokeSize.Medium), mediumGroup);

            var longGroup = jokeResponses.Where(j => j.Size == nameof(JokeSize.Long));
            resultsGrouped.Add(nameof(JokeSize.Long), longGroup);

            return resultsGrouped;
        }
    }
}
