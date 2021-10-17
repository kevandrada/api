using System;
using System.Threading.Tasks;
using IntergalacticAirways.API.Services.ApiServices.Swapi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IntergalacticAirways.API.Controllers
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/starship")]
    public class StarshipController : Controller
    {
        #region Private Members
        private readonly IStarshipServices _starshipServices;
        private readonly ILogger _logger;
        #endregion

        #region Constructor
        public StarshipController(IStarshipServices starshipServices, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<StarshipServices>();
            _starshipServices = starshipServices;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Retrieves starships with pilots based on passenger capacity.
        /// </summary>
        /// <param name="passengers"></param>
        /// <returns>List of starships with pilots</returns>
        [HttpGet]
        public async Task<IActionResult> GetStarships([FromQuery]string passengers)
        {
            try
            {
                if (string.IsNullOrEmpty(passengers))
                    return StatusCode(400, "Bad Request");

                return Ok(await _starshipServices.GetStarships(passengers));
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception: {ex}");
                return StatusCode(500, "Failed");
            }
            
        }
        #endregion
    }
}