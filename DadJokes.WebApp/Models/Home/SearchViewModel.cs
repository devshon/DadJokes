using System;
using System.Collections.Generic;

namespace DadJokes.WebApp.Models.Home
{
    public class SearchViewModel
    {
        public string SearchTerm { get; set; }
        public IList<IEnumerable<string>> GroupedJokes { get; set; }
    }
}
