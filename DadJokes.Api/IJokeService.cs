using System.Collections.Generic;
using DadJokes.Api.Entities;

namespace DadJokes.Api
{
    public interface IJokeService
    {
        IEnumerable<JokeResult> GetBySearchTerm(string searchTerm);
        JokeResult GetRandomJoke();
    }
}
