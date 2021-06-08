using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoolvisionTest.Models
{
    public class CovidModel
    {
        [JsonProperty("results")]
        public int Count { get; set; }

        [JsonProperty("response")]
        public List<CovidCountry> Countries { get; set; }
    }


    public class CovidCountry 
    {
        [JsonProperty("country")]
        public string CountryName { get; set; }

        [JsonProperty("cases")]
        public CovidCases Cases { get; set; }
    }

    public class CovidCases
    {
        [JsonProperty("active")]
        public int Active { get; set; }
    }
}