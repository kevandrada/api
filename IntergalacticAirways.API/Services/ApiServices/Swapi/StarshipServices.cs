using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using IntergalacticAirways.API.Models.AppModels;
using IntergalacticAirways.API.Models.Dtos.Swapi;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Linq;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace IntergalacticAirways.API.Services.ApiServices.Swapi
{
    public class StarshipServices : IStarshipServices
    {
        #region Private Members
        private readonly SwapiSettings _swapiSettings;
        private readonly ILogger _logger;
        #endregion

        #region Constructor
        public StarshipServices(IOptions<SwapiSettings> swapiSettings, ILoggerFactory loggerFactory)
        {
            _swapiSettings = swapiSettings.Value;
            _logger = loggerFactory.CreateLogger<StarshipServices>();
        }
        #endregion
        
        #region Public Methods
        public async Task<IEnumerable<GetStarshipOutputDto>> GetStarships(string passengers)
        {
            try 
            {
                int param = int.Parse(passengers);
                var starships = await _swapiSettings.StarshipRetrieveUrl
                    .GetJsonAsync<StarshipResultDto>();
                
                int totalPages = (int)Math.Ceiling((double)starships.Count / starships.Results.Count());
                var listOfStarships = new List<GetStarshipOutputDto>();
                for(int x = 1; x <= totalPages; x++)
                {
                    var item = await _swapiSettings.StarshipRetrieveUrl
                        .SetQueryParam("page", x.ToString())
                        .GetJsonAsync<StarshipResultDto>();
                    
                    listOfStarships.AddRange(
                        item?.Results?.Where(a => (a.Pilots.Count > 0)
                            && (!Regex.IsMatch(a.Passengers, @"^[a-zA-Z/]+$"))
                            && (int.Parse(a.Passengers, NumberStyles.AllowThousands) >= param))
                    );
                }                

                foreach(var starship in listOfStarships)
                {
                    var pilots = new List<string>();
                    foreach(var pilot in starship.Pilots) 
                    {                         
                        var pilotInfo = await pilot.GetJsonAsync<GetPilotOutputDto>();                        
                        pilots.Add(pilotInfo.Name);
                    }
                    starship.Pilots = pilots;
                }     

                return listOfStarships;
            }
            catch (FlurlHttpException ex)
            {
                _logger.LogError($"Exception: {ex}");
                return null;
            }
        }
        #endregion
    }
}