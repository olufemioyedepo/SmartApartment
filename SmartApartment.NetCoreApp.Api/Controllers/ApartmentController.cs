using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartApartment.Application.CQRS.ApartmentFeature.Commands;
using SmartApartment.Application.CQRS.ApartmentFeature.Queries;
using SmartApartment.Application.Helpers;

namespace SmartApartment.NetCoreApp.Api.Controllers
{
    [ApiVersion("1.0")]
    public class ApartmentController : BaseApiController
    {
        // <summary>
        /// Gets All Apartments.
        /// </summary>
        /// <param name=""></param>
        /// <returns>A list of apartments</returns>
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var response = await Mediator.Send(new ApartmentsQuery());
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

        // <summary>
        /// Gets All Apartments Types.
        /// </summary>
        /// <param name=""></param>
        /// <returns>A list of apartment types</returns>
        [HttpGet("types")]
        public async Task<IActionResult> GetApartmentTypes()
        {
            var response = await Mediator.Send(new ApartmentTypesQuery());

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

        /// <summary>
        /// Updates the Apartment record based on Id.   
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(UpdateApartmentCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await Mediator.Send(command);

            if (response == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Utility.InternalServerErrorText());
            }

            if (response.Code == 400)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response.Message);
            }

            if (response.Code == 500)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response.Message);
            }

            return Ok(response);
        }

        /// <summary>
        /// Creates a new Apartment.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateApartmentCommand command)
        {
            var response = await Mediator.Send(command);

            if (response == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Utility.InternalServerErrorText());
            }

            if (response.Code == 500)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response.Message);
            }

            return StatusCode(StatusCodes.Status201Created, response);
        }
    }
}
