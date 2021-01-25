using System.IO;
using System.Net;
using System.Text;

using Exercise_SW_Movies.DAL.Entities;

using Newtonsoft.Json.Linq;

namespace Exercise_SW_Movies.DAL
{
    public class SWApiReader
    {
        const string baseUrl = "https://swapi.dev/api/";

        public JArray GetMovies()
        {
            var url = baseUrl + "films/";

            var responseString = GetResponse(url);
            var movies = JObject.Parse(responseString);

            return (JArray)movies["results"];
        }

        public People GetCharacterById(int id)
        {
            var url = baseUrl + "people/" + id + "/";

            var responseString = GetResponse(url);

            return new People
            {
                Id = id,
                Name = (string)JObject.Parse(responseString)["name"]
            };
        }

        public Starships GetStarshipById(int id)
        {
            var url = baseUrl + "starships/" + id + "/";

            var responseString = GetResponse(url);

            return new Starships
            {
                Id = id,
                Name = (string)JObject.Parse(responseString)["name"]
            };
        }
        
        public Planets GetPlanetById(int id)
        {
            var url = baseUrl + "planets/" + id + "/";

            var responseString = GetResponse(url);

            return new Planets
            {
                Id = id,
                Name = (string)JObject.Parse(responseString)["name"]
            };
        }
        
        public Vehicles GetVehilceById(int id)
        {
            var url = baseUrl + "vehicles/" + id + "/";

            var responseString = GetResponse(url);

            return new Vehicles
            {
                Id = id,
                Name = (string)JObject.Parse(responseString)["name"]
            };
        }
        
        public Species GetSpeciesById(int id)
        {
            var url = baseUrl + "species/" + id + "/";

            var responseString = GetResponse(url);

            return new Species
            {
                Id = id,
                Name = (string)JObject.Parse(responseString)["name"]
            };
        }
        
        private string GetResponse(string url)
        { 
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            return reader.ReadToEnd();
        }

    }
}
