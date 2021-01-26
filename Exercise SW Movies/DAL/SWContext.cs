using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Exercise_SW_Movies.DAL.Entities;

using Microsoft.EntityFrameworkCore;

namespace Exercise_SW_Movies.DAL
{
    public class SWContext : DbContext
    {
        public DbSet<Films> Films { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<Planets> Planets { get; set; }
        public DbSet<Starships> Starships { get; set; }
        public DbSet<People> People { get; set; }

        public SWContext(DbContextOptions<SWContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Films>().ToTable("Films");
            modelBuilder.Entity<Rating>().ToTable("Rating");
            modelBuilder.Entity<Species>().ToTable("Species");
            modelBuilder.Entity<Vehicles>().ToTable("Vehicles");
            modelBuilder.Entity<Planets>().ToTable("Planets");
            modelBuilder.Entity<Starships>().ToTable("Starships");
            modelBuilder.Entity<People>().ToTable("People");
        }
    }
}
