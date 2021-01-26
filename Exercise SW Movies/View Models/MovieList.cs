using System.Collections.Generic;

using Exercise_SW_Movies.Models;

namespace Exercise_SW_Movies.View_Models
{
    public class MovieList
    {
        public IEnumerable<MovieListItem> Movies { get; set; }
    }
}
