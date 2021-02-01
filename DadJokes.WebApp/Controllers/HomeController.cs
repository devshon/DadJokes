using System.Diagnostics;
using System.Linq;
using DadJokes.Api;
using DadJokes.Utilities;
using DadJokes.WebApp.Models;
using DadJokes.WebApp.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace DadJokes.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly int _jokeGroupingLongLowerLimit = 20;
        private readonly int _jokeGroupingMediumLowerLimit = 10;
        private readonly int _jokeGroupingShortLowerLimit = 0;
        private readonly IJokeService _jokeService;

        public HomeController(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Random()
        {
            var viewModel = new RandomViewModel();
            viewModel.RandomJoke = _jokeService.GetRandomJoke().Joke;

            return View(viewModel);
        }

        public IActionResult Search(string searchTerm)
        {
            var viewModel = new SearchViewModel();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                viewModel.SearchTerm = searchTerm;
                var jokeSearchResults = _jokeService.GetBySearchTerm(searchTerm);
                viewModel.GroupedJokes = jokeSearchResults
                    .Select(x => x.Joke)
                    .ToGroupsByWordLength(_jokeGroupingLongLowerLimit, _jokeGroupingMediumLowerLimit, _jokeGroupingShortLowerLimit);
            }

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
