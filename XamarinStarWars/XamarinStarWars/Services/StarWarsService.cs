using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinStarWars.Models;

namespace XamarinStarWars.Services
{
    public class StarWarsService
    {
        readonly string _BASE_URL = "https://swapi.co/api";

        public async Task<ResultPeople> GetAllPeopleAsync(String url)
        {
            using (var client = new HttpClient())
            {
                String urlApi = url == null ? $"{_BASE_URL}/people" : url;
                Debug.WriteLine("urlApi: " + urlApi);

                var json = await client.GetStringAsync(urlApi);
                ResultPeople result = JsonConvert.DeserializeObject<ResultPeople>(json);

                return result;
            }
        }

        public async Task<List<Film>> GetFilmsByListUrl (List<String> urls)
        {
            using (var client = new HttpClient())
            {
                List<Film> films = new List<Film>();

                foreach (var filmUrl in urls)
                {
                    var json = await client.GetStringAsync(filmUrl);
                    films.Add(JsonConvert.DeserializeObject<Film>(json));
                }



                return films;
            }
        }
    }
}
