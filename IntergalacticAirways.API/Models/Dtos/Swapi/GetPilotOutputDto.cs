using System.Collections.Generic;
using Newtonsoft.Json;

namespace IntergalacticAirways.API.Models.Dtos.Swapi
{
    public class GetPilotOutputDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("starships")]
        public List<string> Starships { get; set; }
    }
}