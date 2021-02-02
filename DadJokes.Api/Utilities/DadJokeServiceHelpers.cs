using System;
using System.Collections.Generic;
using System.Linq;
using DadJokes.Api.Entities;
using Microsoft.AspNetCore.WebUtilities;

namespace DadJokes.Api.Utilities
{
    /// <summary>
    /// Provides helper methods for the DadJokeService.
    /// </summary>
    public static class DadJokeServiceHelpers
    {
        /// <summary>
        /// Emphasizes the given term in each joke, if found.
        /// </summary>
        /// <param name="jokeResponses">Collection of jokes to look for the term in.</param>
        /// <param name="termToEmphasize">The term to emphasize.</param>
        /// <returns>The same collection of jokes but with emphasized (all uppercase) search terms.</returns>
        public static IEnumerable<JokeResponse> EmphasizeWithUppercase(this IEnumerable<JokeResponse> jokeResponses, string termToEmphasize)
        {
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

        /// <summary>
        /// Constructs a request URI for the DadJoke search endpoint.
        /// </summary>
        /// <param name="endpoint">The request endpoint.</param>
        /// <param name="term">The term value for the query string.</param>
        /// <param name="limit">The limit value for the query string.</param>
        /// <returns>Request URI for the DadJoke search endpoint.</returns>
        public static string GetSearchRequestUriWithQueryString(string endpoint, string term, int limit)
        {
            var queryStringParameters = new Dictionary<string, string>();
            queryStringParameters.Add("limit", limit.ToString());
            queryStringParameters.Add("term", term);

            return QueryHelpers.AddQueryString(endpoint, queryStringParameters);
        }

        /// <summary>
        /// Groups the collection of jokes by their size.
        /// </summary>
        /// <param name="jokeResponses">Collection of jokes to group.</param>
        /// <returns>Collection of jokes grouped by size</returns>
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
