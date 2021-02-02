using System.Threading.Tasks;
using DadJokes.Api.Entities;

namespace DadJokes.Api
{
    /// <summary>
    /// Represents a joke service.
    /// </summary>
    public interface IJokeService
    {
        /// <summary>
        /// Gets jokes based on search term provided. 
        /// </summary>
        /// <param name="searchTerm">The term to search for jokes with.</param>
        /// <param name="limit">The maximum number of search results to return. Default is 30.</param>
        /// <returns>Collection of jokes that contain the search term provided.</returns>
        Task<JokeSearchResponse> GetBySearchTerm(string searchTerm, int limit = 30);

        /// <summary>
        /// Gets a random joke.
        /// </summary>
        /// <returns>JokeResult representing a random joke.</returns>
        Task<JokeResponse> GetRandomJoke();
    }
}
