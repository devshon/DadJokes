using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadJokes.Api
{
    interface IJokeService
    {
        string GetRandom();
        IList<string> SearchTerm(string term);
    }
}
