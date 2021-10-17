using System.Collections.Generic;
using System.Threading.Tasks;
using IntergalacticAirways.API.Models.Dtos.Swapi;

namespace IntergalacticAirways.API.Services.ApiServices.Swapi
{
    public interface IStarshipServices
    {
        Task<IEnumerable<GetStarshipOutputDto>> GetStarships(string passengers);
    }
}