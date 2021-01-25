using System;
using System.ComponentModel.DataAnnotations;

namespace Exercise_SW_Movies.DAL.Entities
{
    public class Rating
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Rate { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public Films Films { get; set; }
    }
}
