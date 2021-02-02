﻿using System;
using System.Collections.Generic;
using System.Linq;
using DadJokes.Api.Entities;
using DadJokes.Utilities;
using Microsoft.AspNetCore.WebUtilities;

namespace DadJokes.Api.Utilities
{
    // TODO: Consider renaming, maybe DadJokeServiceHelpers?
    public static class JokeHelpers
    {
        // TODO: Consider changing dictionary value to IEnumberable<JokeResponse>
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

        public static string GetSearchRequestUriWithQueryString(string endpoint, string term, int limit)
        {
            var queryStringParameters = new Dictionary<string, string>();
            queryStringParameters.Add("limit", limit.ToString());
            queryStringParameters.Add("term", term);

            return QueryHelpers.AddQueryString(endpoint, queryStringParameters);
        }
    }
}
