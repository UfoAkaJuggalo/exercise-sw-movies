using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exercise_SW_Movies.DAL.Entities
{
    public class Species
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Films> Films { get; set; }

        public Species()
        {
            Films = new HashSet<Films>();
        }
    }
}
