using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using DadJokes.Api.Entities;
using Newtonsoft.Json;

namespace DadJokes.Api
{
    public class DadJokeService : IJokeService
    {
        private readonly string _getRandomJokeEndpoint = string.Empty;
        private readonly string _getBySearchTermEndpoint = "/search";
        private readonly int _getBySearchTermResultsLimit = 30;

        private HttpClient _httpClient;

        public DadJokeService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            // TODO: should these be passed in
            _httpClient.BaseAddress = new Uri("https://icanhazdadjoke.com/");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public JokeResult GetRandomJoke()
        {
            var responseMessage = _httpClient.GetAsync(_getRandomJokeEndpoint).Result;

            string content = responseMessage.Content.ReadAsStringAsync().Result;

            // Consider the extension method GetFromJsonAsync
            var jokeResult = JsonConvert.DeserializeObject<JokeResult>(content);

            return jokeResult;
        }

        public IEnumerable<JokeResult> GetBySearchTerm(string searchTerm)
        {
            // TODO: Move creation of query string somewhere else
            var responseMessage = _httpClient.GetAsync(_getBySearchTermEndpoint + $"?term=\"{searchTerm}\"&limit={_getBySearchTermResultsLimit}").Result;
            string content = responseMessage.Content.ReadAsStringAsync().Result;

            // Consider the extension method GetFromJsonAsync
            var jokeSearchResults = JsonConvert.DeserializeObject<JokeSearchResult>(content);

            return jokeSearchResults.Results;
        }
    }
}
