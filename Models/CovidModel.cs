using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoolvisionTest.Models
{
    public class CovidModel
    {
        [JsonProperty("results")]
        public int Count { get; set; }

        [JsonProperty("response")]
        public List<string> Countries { get; set; }
    }
}