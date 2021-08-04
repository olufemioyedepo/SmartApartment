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
    public class StatesController : BaseApiController
    {
        /// <summary>
        /// Gets all States.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetStatesQuery());

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
