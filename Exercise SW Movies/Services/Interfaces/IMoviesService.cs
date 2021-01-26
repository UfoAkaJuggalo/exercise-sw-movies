using System.Collections.Generic;

using Exercise_SW_Movies.Models;

namespace Exercise_SW_Movies.Services.Interfaces
{
    public interface IMoviesService
    {
        IEnumerable<MovieListItem> GetMoviesList();
        MovieDetails GetMovieDetails(int id);
    }
}
