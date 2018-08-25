using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinStarWars.Models
{
    public class ResultPeople
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("next")]
        public string Next { get; set; }
        [JsonProperty("previous")]
        public object Previous { get; set; }
        [JsonProperty("results")]
        public List<People> Peoples { get; set; }
    }
}
