using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DadJokes.Api.Entities;
using Newtonsoft.Json;

namespace DadJokes.Api
{
    public class DadJokeService : IJokeService
    {
        private readonly string _acceptMediaType = "application/json";
        private readonly string _baseAddress = "https://icanhazdadjoke.com/";
        private readonly string _getRandomJokeEndpoint = string.Empty;
        private readonly string _getBySearchTermEndpoint = "/search";
        private readonly int _getBySearchTermResultsLimit = 30;

        private HttpClient _httpClient;

        public DadJokeService()
        {
            // TODO: Should this be hiding HttpClient?
            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(_baseAddress);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_acceptMediaType));
        }

        public async Task<IEnumerable<JokeResult>> GetBySearchTerm(string searchTerm)
        {
            // TODO: Move creation of query string somewhere else
            var responseMessage = await _httpClient.GetAsync(_getBySearchTermEndpoint + $"?term=\"{searchTerm}\"&limit={_getBySearchTermResultsLimit}");
            string content = await responseMessage.Content.ReadAsStringAsync();

            var jokeSearchResults = JsonConvert.DeserializeObject<JokeSearchResult>(content);

            return jokeSearchResults.Results;
        }

        public async Task<JokeResult> GetRandomJoke()
        {
            var responseMessage = await _httpClient.GetAsync(_getRandomJokeEndpoint);

            string content = await responseMessage.Content.ReadAsStringAsync();

            var jokeResult = JsonConvert.DeserializeObject<JokeResult>(content);

            return jokeResult;
        }
    }
}
