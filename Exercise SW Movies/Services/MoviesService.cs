using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Exercise_SW_Movies.DAL;
using Exercise_SW_Movies.Models;
using Exercise_SW_Movies.Services.Interfaces;

namespace Exercise_SW_Movies.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly SWContext _context;

        public MoviesService(SWContext context)
        {
            _context = context;
        }

        public IEnumerable<MovieListItem> GetMoviesList()
        {
            return _context.Films
                .Select(x => 
                    new MovieListItem()
                    {
                        Id = x.Id,
                        EpisodeId = x.Episode_id,
                        Title = x.Title
                    })
                .OrderBy(o => o.EpisodeId)
                .ToList();
        }
    }
}
