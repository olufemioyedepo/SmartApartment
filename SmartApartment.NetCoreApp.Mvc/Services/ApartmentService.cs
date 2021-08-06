using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using Serilog;
using SmartApartment.Application.Helpers;
using SmartApartment.NetCoreApp.Mvc.Models.WebResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApartment.NetCoreApp.Mvc.Services
{
    public class ApartmentService
    {
        private readonly string apartmentsEndpoint;
        readonly IConfiguration _configuration;
        public ApartmentService(IConfiguration configuration)
        {
            _configuration = configuration;
            apartmentsEndpoint = _configuration.GetSection("Endpoints").GetSection("Apartments").Value;
        }

        public async Task<List<ApartmentData>> GetApartments()
        {
            var instrumentsResponse = new ApartmentsResponse();
            var apartmentData = new List<ApartmentData>();

            try
            {

                var client = new RestClient(apartmentsEndpoint);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);

                IRestResponse response = await client.ExecuteAsync(request);
                instrumentsResponse = JsonConvert.DeserializeObject<ApartmentsResponse>(response.Content);

                if (instrumentsResponse == null)
                {
                }

                apartmentData = instrumentsResponse.Data;
            }
            catch (Exception ex)
            {
                Log.Error(Utility.ErrorLog(ex));
                return null;
            }

            return apartmentData;
        }
    }
}
