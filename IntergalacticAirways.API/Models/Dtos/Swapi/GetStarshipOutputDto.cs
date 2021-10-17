using System.Collections.Generic;
using Newtonsoft.Json;

namespace IntergalacticAirways.API.Models.Dtos.Swapi
{
    public class StarshipResultDto
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("results")]
        public List<GetStarshipOutputDto> Results { get; set; }
    }

    public class GetStarshipOutputDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("starship_class")]
        public string StarshipClass { get; set; }

        [JsonProperty("passengers")]
        public string Passengers { get; set; }

        [JsonProperty("MGLT")]
        public string MGLT { get; set; }

        [JsonProperty("pilots")]
        public List<string> Pilots { get; set; }
    }

}