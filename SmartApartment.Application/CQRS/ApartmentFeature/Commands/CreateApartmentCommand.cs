using MediatR;
using Serilog;
using SmartApartment.Application.Helpers;
using SmartApartment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartApartment.Application.CQRS.ApartmentFeature.Commands
{
    public class CreateApartmentCommand : IRequest<GenericResponse<Apartment>>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int ApartmentTypeId { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateApartmentCommand, GenericResponse<Apartment>>
        {
            private readonly IAppDbContext _context;
            public CreateProductCommandHandler(IAppDbContext context)
            {
                _context = context;
            }
            public async Task<GenericResponse<Apartment>> Handle(CreateApartmentCommand command, CancellationToken cancellationToken)
            {
                var apartment = new Apartment
                {
                    Name = command.Name,
                    ApartmentTypeId = command.ApartmentTypeId,
                    Address = command.Address,
                    Description = command.Description,
                    CityId = command.CityId,
                    StateId = command.StateId
                };

                try
                {
                    _context.Apartments.Add(apartment);
                    var response = await _context.SaveChangesAsync();

                    if (response == 0)
                    {
                        return new GenericResponse<Apartment>()
                        {
                            Code = 400,
                            Data = null,
                            Message = "Could not create apartment!",
                            Success = false
                        };
                    }

                    return new GenericResponse<Apartment>()
                    {
                        Code = 201,
                        Data = apartment,
                        Message = "Apartment created successfully1",
                        Success = true
                    };
                }
                catch (Exception ex)
                {
                    Log.Error(Utility.ErrorLog(ex));

                    return new GenericResponse<Apartment>()
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
