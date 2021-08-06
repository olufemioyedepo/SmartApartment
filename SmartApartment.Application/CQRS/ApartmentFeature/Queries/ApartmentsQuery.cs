using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SmartApartment.Application.DTOs;
using SmartApartment.Application.Helpers;
using SmartApartment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace SmartApartment.Application.CQRS.ApartmentFeature.Queries
{
    public class ApartmentsQuery : IRequest<GenericResponse<List<ApartmentInfoDto>>>
    {
        public class GetApartmentsQueryHandler : IRequestHandler<ApartmentsQuery, GenericResponse<List<ApartmentInfoDto>>>
        {
            private readonly IAppDbContext _context;
            private readonly IMapper _mapper;
            public GetApartmentsQueryHandler(IAppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GenericResponse<List<ApartmentInfoDto>>> Handle(ApartmentsQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    var apartments = await (from apartment in _context.Apartments
                                join apartmentType in _context.ApartmentTypes on apartment.ApartmentTypeId equals apartmentType.Id
                                join state in _context.States on apartment.StateId equals state.Id
                                join city in _context.Cities on apartment.CityId equals city.Id
                                where apartment.Id > 0
                                select new ApartmentInfoDto
                                {
                                    Id = apartment.Id,
                                    Name = apartment.Name,
                                    ApartmentType = apartmentType.Name,
                                    Address = apartment.Address,
                                    Description = !string.IsNullOrEmpty(apartment.Description) ? apartment.Description : "N/A",
                                    State = state.Name,
                                    City = city.Name,
                                }).ToListAsync();

                                
                    return new GenericResponse<List<ApartmentInfoDto>>()
                    {
                        Code = 200,
                        Data = apartments,
                        Message = apartments.Count > 0 ? "Apartments loaded successfully!" : "No apartment found!",
                        Success = true
                    };
                }
                catch (Exception ex)
                {
                    Log.Error(Utility.ErrorLog(ex));
                    return new GenericResponse<List<ApartmentInfoDto>>()
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

    public class ApartmentTypesQuery : IRequest<GenericResponse<List<ApartmentTypeDto>>>
    {
        public class GetApartmentsQueryHandler : IRequestHandler<ApartmentTypesQuery, GenericResponse<List<ApartmentTypeDto>>>
        {
            private readonly IAppDbContext _context;
            private readonly IMapper _mapper;
            public GetApartmentsQueryHandler(IAppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GenericResponse<List<ApartmentTypeDto>>> Handle(ApartmentTypesQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    var apartmentTypes = await _context.ApartmentTypes.ToListAsync();
                    var mappedApartmentTypes = _mapper.Map<List<ApartmentType>, List<ApartmentTypeDto>>(apartmentTypes);

                    return new GenericResponse<List<ApartmentTypeDto>>()
                    {
                        Code = 200,
                        Data = mappedApartmentTypes,
                        Message = mappedApartmentTypes.Count > 0 ? "Apartment types loaded successfully!" : "No apartment type found!",
                        Success = true
                    };
                }
                catch (Exception ex)
                {
                    Log.Error(Utility.ErrorLog(ex));
                    return new GenericResponse<List<ApartmentTypeDto>>()
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
