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
            _jokeService = new DadJokeService(new HttpClient());

            var randomJoke = _jokeService.GetRandomJoke();

            var searchResults = _jokeService.GetBySearchTerm("dog");

            foreach (var searchResult in searchResults)
            {
                searchResult.Joke = searchResult.Joke.EmphasizeWithUppercase("dog");
            }

            var groupedJokes = Grouper.GroupByWordLength(searchResults.Select(x => x.Joke));
        }
    }
}
