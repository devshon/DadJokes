using Newtonsoft.Json;

namespace DadJokes.Api.Entities
{
    public class JokeResult
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("joke")]
        public string Joke { get; set; }
    }
}
