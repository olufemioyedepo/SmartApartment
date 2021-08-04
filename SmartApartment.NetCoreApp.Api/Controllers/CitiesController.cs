using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartApartment.Application.CQRS.StateFeature.Queries;
using SmartApartment.Application.Helpers;

namespace SmartApartment.NetCoreApp.Api.Controllers
{
    [ApiVersion("1.0")]
    public class CitiesController : BaseApiController
    {
        /// <summary>
        /// Gets Cities by State Id.
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns>A list of cities by state id</returns>
        [HttpGet("{stateId}")]
        public async Task<IActionResult> GetCitiesByStateId(int stateId)
        {
            var response = await Mediator.Send(new GetCitiesByStateIdQuery { StateId = stateId });
            if (response == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Utility.InternalServerErrorText());
            }

            if (response.Code == 500)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response.Message);
            }

            return Ok(response);
        }
    }
}
