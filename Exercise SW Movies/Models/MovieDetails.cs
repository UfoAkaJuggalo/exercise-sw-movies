using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_SW_Movies.Models
{
    public class MovieDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Episode_id { get; set; }
        public string Opening_crawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public DateTime Release_date  { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public IEnumerable<string> Species { get; set; }
        public IEnumerable<string> Vehicles { get; set; }
        public IEnumerable<string> Planets { get; set; }
        public IEnumerable<string> Starships { get; set; }
        public IEnumerable<string> People { get; set; }
        public double Rating { get; set; }
        public int Votes { get; set; }
    }
}
