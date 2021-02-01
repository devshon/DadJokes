using System;
using System.Collections.Generic;

namespace DadJokes.WebApp.Models.Home
{
    public class SearchViewModel
    {
        public string SearchTerm { get; set; }
        public IDictionary<string, IEnumerable<string>> GroupedJokes { get; set; }
    }
}
