using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using SmartApartment.NetCoreApp.Mvc.Models.WebResponse;
using SmartApartment.NetCoreApp.Mvc.Services;

namespace SmartApartment.NetCoreApp.Mvc.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly string apartmentsEndpoint;
        readonly IConfiguration _configuration;
        private readonly ApartmentService _apartmentService;

        public ApartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
            apartmentsEndpoint = _configuration.GetSection("Endpoints").GetSection("Apartments").Value;
            _apartmentService = new ApartmentService(_configuration);
        }

        [Authorize]
        public async Task<IActionResult> IndexAsync()
        {
            
            var apartmentData = await _apartmentService.GetApartments(); 
            return View(apartmentData);
        }

        public IActionResult Types()
        {
            return View();
        }
    }
}
