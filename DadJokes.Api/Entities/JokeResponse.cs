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
                if (NumberOfWords >= (int)JokeSize.Short && NumberOfWords < (int)JokeSize.Medium)
                {
                    return JokeSize.Short.ToString();
                }
                else if (NumberOfWords >= (int)JokeSize.Medium && NumberOfWords < (int)JokeSize.Long)
                {
                    return JokeSize.Medium.ToString();
                }
                else if (NumberOfWords >= (int)JokeSize.Long)
                {
                    return JokeSize.Long.ToString();
                }
                else
                {
                    throw new InvalidOperationException("Unable to determine size. Ensure size ranges are specified correctly.");
                }
            } 
        }
    }
}
