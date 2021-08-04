using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SmartApartment.Application.DTOs;
using SmartApartment.Application.Helpers;
using SmartApartment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartApartment.Application.CQRS.StateFeature.Queries
{
    public class GetCitiesByStateIdQuery : IRequest<GenericResponse<List<CityDto>>>
    {
        public int StateId { get; set; }
        public class GetCitiesByStateIdQueryHandler : IRequestHandler<GetCitiesByStateIdQuery, GenericResponse<List<CityDto>>> 
        {
            private readonly IAppDbContext _context;
            private readonly IMapper _mapper;
            public GetCitiesByStateIdQueryHandler(IAppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GenericResponse<List<CityDto>>> Handle(GetCitiesByStateIdQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    var cities = await _context.Cities.Where(s => s.StateId == query.StateId).ToListAsync();
                    var mappedCities = _mapper.Map<List<City>, List<CityDto>>(cities);

                    return new GenericResponse<List<CityDto>>()
                    {
                        Code = 200,
                        Data = mappedCities,
                        Message = mappedCities.Count > 0 ? "Cities loaded successfully!" : "No city found for selected state!",
                        Success = true
                    };
                }
                catch (Exception ex)
                {
                    Log.Error(Utility.ErrorLog(ex));
                    return new GenericResponse<List<CityDto>>()
                    {
                        Code = 500,
                        Data = null,
                        Message = ex.Message,
                        Success = false
                    };
                }

            }
        }
        
    }
}
