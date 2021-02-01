using System.Linq;
using System.Net.Http;
using DadJokes.Api;
using DadJokes.Utilities;

namespace DadJokes.ConsoleApp
{
    class Program
    {
        private static IJokeService _jokeService;

        static void Main(string[] args)
        {
            _jokeService = new DadJokeService();

            var randomJoke = _jokeService.GetRandomJoke();

            var searchResults = _jokeService.GetBySearchTerm("dog");

            //foreach (var searchResult in searchResults)
            //{
            //    searchResult.Joke = searchResult.Joke.EmphasizeWithUppercase("dog");
            //}

            //var groupedJokes = searchResults.Select(x => x.Joke).ToGroupsByWordLength(20, 10);
        }
    }
}
