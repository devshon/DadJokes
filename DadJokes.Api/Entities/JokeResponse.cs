using Newtonsoft.Json;

namespace DadJokes.Api.Entities
{
    /// <summary>
    /// Represents a response from the Dad Joke API random joke endpoint.
    /// </summary>
    public class JokeResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("joke")]
        public string Joke { get; set; }
    }
}
