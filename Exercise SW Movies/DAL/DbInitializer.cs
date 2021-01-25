using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Exercise_SW_Movies.DAL.Entities;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json.Linq;

namespace Exercise_SW_Movies.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(SWContext context)
        {
            context.Database.EnsureCreated();

            if (context.Films.Any())
            {
                return;
            }

            var SWApiReader = new SWApiReader();
            var filmsList = new List<Films>();
            var peopleList = new List<People>();
            var starshipsList = new List<Starships>();
            var planetsList = new List<Planets>();
            var vehiclesList = new List<Vehicles>();
            var speciesList = new List<Species>();

            var movies = SWApiReader.GetMovies();

            foreach (var item in movies)
            {
                var movie = new Films
                {
                    Id = (int)JObject.Parse(item.ToString())["episode_id"],
                    Episode_id = (int)JObject.Parse(item.ToString())["episode_id"],
                    Title = (string)JObject.Parse(item.ToString())["title"],
                    Opening_crawl = (string)JObject.Parse(item.ToString())["opening_crawl"],
                    Director = (string)JObject.Parse(item.ToString())["director"],
                    Producer = (string)JObject.Parse(item.ToString())["producer"],
                    Url = (string)JObject.Parse(item.ToString())["url"],
                    Created = (DateTime)JObject.Parse(item.ToString())["created"],
                    Edited = (DateTime)JObject.Parse(item.ToString())["edited"],
                    Release_date = (DateTime)JObject.Parse(item.ToString())["release_date"]
                };

                var peoples = new List<People>();
                var starships = new List<Starships>();
                var planets = new List<Planets>();
                var vehicles = new List<Vehicles>();
                var species = new List<Species>();

                var peoplesIds = GetArraysOfIds((JArray)JObject.Parse(item.ToString())["characters"]);
                foreach (var id in peoplesIds)
                {
                    var character = peopleList.FirstOrDefault(f=> f.Id == id);
                    if (character != null)
                        peoples.Add(character);
                    else
                    {
                        var newCharacter = SWApiReader.GetCharacterById(id);
                        peoples.Add(newCharacter);
                        peopleList.Add(newCharacter);
                    }
                }

                var speciesIds = GetArraysOfIds((JArray)JObject.Parse(item.ToString())["species"]);
                foreach (var id in speciesIds)
                {
                    var kind = speciesList.FirstOrDefault(f=> f.Id == id);
                    if (kind != null)
                        species.Add(kind);
                    else
                    {
                        var newKind = SWApiReader.GetSpeciesById(id);
                        species.Add(newKind);
                        speciesList.Add(newKind);
                    }
                }

                var starshipsIds = GetArraysOfIds((JArray)JObject.Parse(item.ToString())["starships"]);
                foreach (var id in starshipsIds)
                {
                    var starship = starshipsList.FirstOrDefault(f=> f.Id == id);
                    if (starship != null)
                        starships.Add(starship);
                    else
                    {
                        var newStarship = SWApiReader.GetStarshipById(id);
                        starships.Add(newStarship);
                        starshipsList.Add(newStarship);
                    }
                }

                var vehilcesIds = GetArraysOfIds((JArray)JObject.Parse(item.ToString())["vehicles"]);
                foreach (var id in vehilcesIds)
                {
                    var vehilce = vehiclesList.FirstOrDefault(f=> f.Id == id);
                    if (vehilce != null)
                        vehicles.Add(vehilce);
                    else
                    {
                        var newVehilce = SWApiReader.GetVehilceById(id);
                        vehicles.Add(newVehilce);
                        vehiclesList.Add(newVehilce);
                    }
                }

                var planetsIds = GetArraysOfIds((JArray)JObject.Parse(item.ToString())["planets"]);
                foreach (var id in planetsIds)
                {
                    var planet = planetsList.FirstOrDefault(f=> f.Id == id);
                    if (planet != null)
                        planets.Add(planet);
                    else
                    {
                        var newPlanet = SWApiReader.GetPlanetById(id);
                        planets.Add(newPlanet);
                        planetsList.Add(newPlanet);
                    }
                }

                movie.People = peoples;
                movie.Starships = starships;
                movie.Planets = planets;
                movie.Vehicles = vehicles;
                movie.Species = species;

                filmsList.Add(movie);
            }

            foreach (var item in speciesList)
            {
                context.Species.Add(item);
            }
            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Species ON");
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Species OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }

            foreach (var item in vehiclesList)
            {
                context.Vehicles.Add(item);
            }
            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Vehicles ON");
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Vehicles OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }

            foreach (var item in planetsList)
            {
                context.Planets.Add(item);
            }
            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Planets ON");
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Planets OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }

            foreach (var item in starshipsList)
            {
                context.Starships.Add(item);
            }
            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Starships ON");
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Starships OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }

            foreach (var item in peopleList)
            {
                context.People.Add(item);
            }
            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.People ON");
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.People OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }

            foreach (var item in filmsList)
            {
                context.Films.Add(item);
            }

            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Films ON");
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Films OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }

        private static List<int> GetArraysOfIds(JArray jArray)
        {
            var result = new List<int>();

            foreach (var item in jArray)
            {
                var digits = Regex.Split(item.ToString(), @"\D+");
                foreach (var digit in digits)
                {
                    int number;
                    if(int.TryParse(digit, out number))
                    {
                        result.Add(number);
                    }
                }
            }
            
            return result;
        }
    }
}