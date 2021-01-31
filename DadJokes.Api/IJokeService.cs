using System.Collections.Generic;

namespace DadJokes.Api
{
    public interface IJokeService
    {
        string GetRandom();
        IList<string> SearchTerm(string term);
    }
}
