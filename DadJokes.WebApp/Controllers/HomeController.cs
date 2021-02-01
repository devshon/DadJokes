using System.Diagnostics;
using DadJokes.Api;
using DadJokes.WebApp.Models;
using DadJokes.WebApp.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace DadJokes.WebApp.Controllers
{
    public class HomeController : Controller
    {
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

        public IActionResult Search()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
