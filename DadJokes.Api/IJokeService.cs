using System.Collections.Generic;
using System.Threading.Tasks;
using DadJokes.Api.Entities;

namespace DadJokes.Api
{
    public interface IJokeService
    {
        Task<IEnumerable<JokeResult>> GetBySearchTerm(string searchTerm);
        Task<JokeResult> GetRandomJoke();
    }
}
