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

namespace SmartApartment.Application.CQRS.StateFeature.Queries
{
    public class GetStatesQuery : IRequest<GenericResponse<List<StatesDto>>>
    {
        public class GetSatesQueryHandler : IRequestHandler<GetStatesQuery, GenericResponse<List<StatesDto>>>
        {
            private readonly IAppDbContext _context;
            private readonly IMapper _mapper;

            public GetSatesQueryHandler(IAppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GenericResponse<List<StatesDto>>> Handle(GetStatesQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    var states = await _context.States.ToListAsync();
                    var statesMapped = _mapper.Map<List<State>, List<StatesDto>>(states);

                    return new GenericResponse<List<StatesDto>>()
                    {
                        Code = 200,
                        Data = statesMapped,
                        Message = statesMapped.Count > 0 ? "States loaded successfully!" : "No state found!",
                        Success = true
                    };
                }
                catch (Exception ex)
                {
                    Log.Error(Utility.ErrorLog(ex));
                    return new GenericResponse<List<StatesDto>>()
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
