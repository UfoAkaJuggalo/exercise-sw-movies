using System;
using System.Collections.Generic;
using System.Linq;

using Exercise_SW_Movies.DAL;
using Exercise_SW_Movies.DAL.Entities;
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

        public void AddVote(int movieId, int rate)
        {
            _context.Rating.Add(new Rating()
            {
                Rate = rate,
                Date = DateTime.Now,
                Films = _context.Films.FirstOrDefault(x => x.Id == movieId)
            });
            _context.SaveChanges();
        }

        public MovieDetails GetMovieDetails(int id)
        {
            var movie = _context.Films
                .FirstOrDefault(f => f.Id == id);
            
            var species = _context.Species
                .Where(x => x.Films
                .Any(y => y.Id == id))
                .ToList();

            var people = _context.People
                .Where(x => x.Films
                .Any(y => y.Id == id))
                .ToList();

            var planets = _context.Planets
                .Where(x => x.Films
                .Any(y => y.Id == id))
                .ToList();

            var starships = _context.Starships
                .Where(x => x.Films
                .Any(y => y.Id == id))
                .ToList();

            var vehicles = _context.Vehicles
                .Where(x => x.Films
                .Any(y => y.Id == id))
                .ToList();

            double ratings = 0;
            var ratingsresult = _context.Rating
                .Where(x => x.Films.Id == id);
            if (ratingsresult.Any())
                ratings = ratingsresult.Average(a => a.Rate);

            return new MovieDetails()
            {
                Id = movie.Id,
                Title = movie.Title,
                Episode_id = movie.Episode_id,
                Opening_crawl = movie.Opening_crawl,
                Created = movie.Created,
                Edited = movie.Edited,
                Director = movie.Director,
                Producer = movie.Producer,
                Release_date = movie.Release_date,
                Species = species.Select(x => x.Name),
                People = people.Select(x => x.Name),
                Planets = planets.Select(x => x.Name),
                Starships = starships.Select(x => x.Name),
                Vehicles = vehicles.Select(x => x.Name),
                Rating = ratings,
                Votes = ratingsresult.Count()
            };
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
