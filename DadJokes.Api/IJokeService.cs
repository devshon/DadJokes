using System.Collections.Generic;

namespace DadJokes.Api
{
    public interface IJokeService
    {
        string GetRandomJoke();
        IEnumerable<string> SearchJokeTerm(string term);
    }
}
