using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XamarinStarWars.Services
{
    public class StarWarsService
    {
        readonly string _BASE_URL = "https://swapi.co/api";

        public async Task<List<string>> GetAllPeopleAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync($"{_BASE_URL}/people");
                return JsonConvert.DeserializeObject<List<string>>(json);
            }
        }
    }
}
