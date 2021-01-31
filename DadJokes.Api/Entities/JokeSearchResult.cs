﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace DadJokes.Api.Entities
{
    public class JokeSearchResult
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
        public IEnumerable<JokeResult> Results { get; set; }

        [JsonProperty("search_term")]
        public string SearchTerm { get; set; }

        [JsonProperty("total_jokes")]
        public int TotalJokes { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}
