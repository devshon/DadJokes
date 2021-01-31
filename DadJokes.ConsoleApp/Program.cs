using System.Net.Http;
using DadJokes.Api;

namespace DadJokes.ConsoleApp
{
    class Program
    {
        private static IJokeService _jokeService;

        static void Main(string[] args)
        {
            _jokeService = new DadJokeService(new HttpClient());

            var randomJoke = _jokeService.GetRandomJoke();

            var searchResults = _jokeService.GetBySearchTerm("dog");
        }
    }
}
