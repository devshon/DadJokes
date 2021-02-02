using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DadJokes.Api.Entities;
using DadJokes.Api.Utilities;
using DadJokes.Utilities;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace DadJokes.Api
{
    /// <summary>
    /// Dad Joke API service that communicates with the https://icanhazdadjoke.com/ API.
    /// </summary>
    public class DadJokeService : IJokeService
    {
        private readonly string _baseAddress = "https://icanhazdadjoke.com/";
        private readonly string _endpointGetRandomJoke = string.Empty;
        private readonly string _endpointGetBySearchTerm = "search";

        private readonly string _headerAcceptMediaType = "application/json";
        private readonly string _headerUserAgentProductName = "ShonsDadJokeService";
        private readonly string _headerUserAgentProductVersion = "1.0";

        private readonly int _jokeGroupingLongLowerLimit = 20;
        private readonly int _jokeGroupingMediumLowerLimit = 10;
        private readonly int _jokeGroupingShortLowerLimit = 0;

        private HttpClient _httpClient;

        /// <summary>
        /// Creates a new instance of DadJokeService.
        /// </summary>
        /// <param name="httpClient">The client used to make calls to the Dad Joke API.</param>
        public DadJokeService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri(_baseAddress);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_headerAcceptMediaType));
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(_headerUserAgentProductName, _headerUserAgentProductVersion));
        }

        /// <summary>
        /// Gets a collection of jokes by the search term provided. 
        /// An OR operation is used by the API if more than one term is given.
        /// </summary>
        /// <param name="searchTerm">The term to search for jokes with.</param>
        /// <param name="limit">The maximum number of search results to return. Default is 30.</param>
        /// <returns>Collection of jokes that contain the search term provided.</returns>
        public async Task<JokeSearchResponse> GetBySearchTerm(string searchTerm, int limit = 30)
        {
            var queryStringParameters = new Dictionary<string, string>();
            queryStringParameters.Add("limit", limit.ToString());
            queryStringParameters.Add("term", searchTerm);

            var queryStringHelper = QueryHelpers.AddQueryString(_endpointGetBySearchTerm, queryStringParameters);
            var responseMessage = await _httpClient.GetAsync(queryStringHelper);
            
            responseMessage.EnsureSuccessStatusCode();

            string content = await responseMessage.Content.ReadAsStringAsync();

            var jokeSearchReponse = JsonConvert.DeserializeObject<JokeSearchResponse>(content);

            if (searchTerm != null)
            {
                jokeSearchReponse.Results = jokeSearchReponse.Results.EmphasizeWithUppercase(searchTerm);
            }

            jokeSearchReponse.ResultsGrouped = JokeHelpers.GroupJokesBySize(jokeSearchReponse.Results);

            return jokeSearchReponse;
        }

        /// <summary>
        /// Gets a random joke from the API.
        /// </summary>
        /// <returns>A random joke from the API.</returns>
        public async Task<JokeResponse> GetRandomJoke()
        {
            var responseMessage = await _httpClient.GetAsync(_endpointGetRandomJoke);
            
            responseMessage.EnsureSuccessStatusCode();

            string content = await responseMessage.Content.ReadAsStringAsync();

            var jokeResult = JsonConvert.DeserializeObject<JokeResponse>(content);

            return jokeResult;
        }
    }
}
