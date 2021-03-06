﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exercise_SW_Movies.DAL.Entities
{
    public class Vehicles
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Films> Films { get; set; }

        public Vehicles()
        {
            Films = new HashSet<Films>();
        }
    }
}
