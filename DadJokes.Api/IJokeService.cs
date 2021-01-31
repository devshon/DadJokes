using System.Collections.Generic;

namespace DadJokes.Api
{
    public interface IJokeService
    {
        string GetRandomJoke();
        IList<string> SearchJokeTerm(string term);
    }
}
