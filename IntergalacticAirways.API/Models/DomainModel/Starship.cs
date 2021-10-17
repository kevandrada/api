using Newtonsoft.Json;

namespace IntergalacticAirways.API.Models.DomainModel
{
    public class Starship
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("pilots")]
        public string[] Pilots { get; set; }
    }

    public class GetStarshipOutputDto
    {
        
    }
}