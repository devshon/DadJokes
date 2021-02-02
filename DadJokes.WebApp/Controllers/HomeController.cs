﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IActionResult> Random()
        {
            var viewModel = new RandomViewModel();
            var randomJoke = await _jokeService.GetRandomJoke();
            viewModel.RandomJoke = randomJoke.Joke;

            return View(viewModel);
        }

        public async Task<IActionResult> Search(string searchTerm)
        {
            var jokeSearchResponse = await _jokeService.GetBySearchTerm(searchTerm);

            var groupedJokes = new Dictionary<string, IEnumerable<string>>();

            foreach (var item in jokeSearchResponse.ResultsBySize)
            {
                var jokeStrings = item.Value.Select(j => j.Joke);
                groupedJokes.Add(item.Key, jokeStrings);
            }

            var viewModel = new SearchViewModel();
            viewModel.SearchTerm = searchTerm;
            viewModel.GroupedJokes = groupedJokes;

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
