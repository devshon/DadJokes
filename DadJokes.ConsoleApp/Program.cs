using System;
using System.Net.Http;
using System.Net.Http.Headers;
using DadJokes.Api;

namespace DadJokes.ConsoleApp
{
    class Program
    {
        private static IJokeService _jokeService;

        static void Main(string[] args)
        {
            _jokeService = new JokeService();

        }
    }
}
