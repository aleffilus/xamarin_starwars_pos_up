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
    }
}
