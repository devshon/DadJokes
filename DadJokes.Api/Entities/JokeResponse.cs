using System;
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

        [JsonIgnore]
        public int NumberOfWords { get { return this.Joke.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length; } }

        [JsonIgnore]
        public string Size 
        { 
            get 
            {
                if (NumberOfWords >= JokeSize.Short && NumberOfWords < JokeSize.Medium)
                {
                    return nameof(JokeSize.Short);
                }
                else if (NumberOfWords >= JokeSize.Medium && NumberOfWords < JokeSize.Long)
                {
                    return nameof(JokeSize.Medium);
                }
                else if (NumberOfWords >= JokeSize.Long)
                {
                    return nameof(JokeSize.Long);
                }
                else
                {
                    return string.Empty;
                }
            } 
        }
    }
}
