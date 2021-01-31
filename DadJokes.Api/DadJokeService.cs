using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DadJokes.Api
{
    public class DadJokeService : IJokeService
    {
        private HttpClient _httpClient;

        public DadJokeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string GetRandomJoke()
        {
            throw new NotImplementedException();
        }

        IEnumerable<string> IJokeService.SearchJokeTerm(string term)
        {
            throw new NotImplementedException();
        }
    }
}
