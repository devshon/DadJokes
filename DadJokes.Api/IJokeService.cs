using System.Collections.Generic;
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
        /// <returns>Collection of jokes that contain the search term provided.</returns>
        Task<IEnumerable<JokeResponse>> GetBySearchTerm(string searchTerm);

        /// <summary>
        /// Gets a random joke.
        /// </summary>
        /// <returns>JokeResult representing a random joke.</returns>
        Task<JokeResponse> GetRandomJoke();
    }
}
