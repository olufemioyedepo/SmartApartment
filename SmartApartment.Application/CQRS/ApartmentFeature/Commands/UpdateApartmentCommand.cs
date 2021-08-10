using MediatR;
using Serilog;
using SmartApartment.Application.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartApartment.Application.CQRS.ApartmentFeature.Commands
{
    public class UpdateApartmentCommand : IRequest<GenericResponse<UpdateApartmentCommand>>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string Description { get; set; }
        [Required]
        public int ApartmentTypeId { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public class UpdateApartmentCommandHandler : IRequestHandler<UpdateApartmentCommand, GenericResponse<UpdateApartmentCommand>>
        {
            private readonly IAppDbContext _context;
            public UpdateApartmentCommandHandler(IAppDbContext context)
            {
                _context = context;
            }
            public async Task<GenericResponse<UpdateApartmentCommand>> Handle(UpdateApartmentCommand command, CancellationToken cancellationToken)
            {
                var res = 0;

                try
                {
                    var apartment = _context.Apartments.Where(a => a.Id == command.Id).FirstOrDefault();

                    if (apartment == null)
                    {
                        return new GenericResponse<UpdateApartmentCommand>()
                        {
                            Code = 400,
                            Data = null,
                            Message = "Invalid paramaters!",
                            Success = false
                        };
                    }

                    apartment.Name = command.Name;
                    apartment.Address = command.Address;
                    apartment.Description = command.Description;
                    apartment.ApartmentTypeId = command.ApartmentTypeId;
                    apartment.CityId = command.CityId;
                    apartment.StateId = command.StateId;

                    res = await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Log.Error(Utility.ErrorLog(ex));
                }

                return new GenericResponse<UpdateApartmentCommand>()
                {
                    Code = 200,
                    Data = command,
                    Message = "Apartment information updated successfully!",
                    Success = true
                };
            }
        }
    }
}
