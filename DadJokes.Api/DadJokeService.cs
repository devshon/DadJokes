using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DadJokes.Api.Entities;
using Newtonsoft.Json;

namespace DadJokes.Api
{
    /// <summary>
    /// Dad Joke API service that communicates with the https://icanhazdadjoke.com/ API.
    /// </summary>
    public class DadJokeService : IJokeService
    {
        private readonly string _acceptMediaType = "application/json";
        private readonly string _baseAddress = "https://icanhazdadjoke.com/";
        private readonly string _getRandomJokeEndpoint = string.Empty;
        private readonly string _getBySearchTermEndpoint = "/search";
        private readonly int _getBySearchTermResultsLimit = 30;

        private HttpClient _httpClient;

        /// <summary>
        /// Creates a new instance of DadJokeService.
        /// </summary>
        public DadJokeService()
        {
            // TODO: Should this be hiding HttpClient?
            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(_baseAddress);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_acceptMediaType));
        }

        /// <summary>
        /// Gets a collection of jokes by the search term provided.
        /// </summary>
        /// <param name="searchTerm">The term to search for jokes with.</param>
        /// <returns>Collection of jokes that contain the search term provided.</returns>
        /// <remarks>Results are limited to a maximum of 30.</remarks>
        public async Task<IEnumerable<JokeResult>> GetBySearchTerm(string searchTerm)
        {
            var responseMessage = await _httpClient.GetAsync(_getBySearchTermEndpoint + $"?term=\"{searchTerm}\"&limit={_getBySearchTermResultsLimit}");
            string content = await responseMessage.Content.ReadAsStringAsync();

            var jokeSearchResults = JsonConvert.DeserializeObject<JokeSearchResult>(content);

            return jokeSearchResults.Results;
        }

        /// <summary>
        /// Gets a random joke from the API.
        /// </summary>
        /// <returns>JokeResult representing a random joke.</returns>
        public async Task<JokeResult> GetRandomJoke()
        {
            var responseMessage = await _httpClient.GetAsync(_getRandomJokeEndpoint);

            string content = await responseMessage.Content.ReadAsStringAsync();

            var jokeResult = JsonConvert.DeserializeObject<JokeResult>(content);

            return jokeResult;
        }
    }
}
