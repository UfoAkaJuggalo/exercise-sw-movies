using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exercise_SW_Movies.DAL.Entities
{
    public class Films
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Episode_id { get; set; }
        public string Opening_crawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public DateTime Release_date  { get; set; }
        public string Url { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
        public virtual ICollection<Species> Species { get; set; }
        public virtual ICollection<Vehicles> Vehicles { get; set; }
        public virtual ICollection<Planets> Planets { get; set; }
        public virtual ICollection<Starships> Starships { get; set; }
        public virtual ICollection<People> People { get; set; }
        public ICollection<Rating> Rating { get; set; }
    }
}
