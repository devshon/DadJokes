using System.Collections.Generic;
using Newtonsoft.Json;

namespace DadJokes.Api.Entities
{
    /// <summary>
    /// Represents a JSON response from the Dad Joke API search endpoint.
    /// </summary>
    public class JokeSearchResponse
    {
        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("next_page")]
        public int NextPage { get; set; }

        [JsonProperty("previous_page")]
        public int PreviousPage { get; set; }

        [JsonProperty("results")]
        public IEnumerable<JokeResponse> Results { get; set; }

        [JsonProperty("search_term")]
        public string SearchTerm { get; set; }

        [JsonProperty("total_jokes")]
        public int TotalJokes { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonIgnore]
        public IDictionary<string, IEnumerable<string>> ResultsGrouped { get; set; }
    }
}
