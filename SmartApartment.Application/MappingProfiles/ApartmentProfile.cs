using AutoMapper;
using SmartApartment.Application.DTOs;
using SmartApartment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartApartment.Application.MappingProfiles
{
    public class ApartmentProfile : Profile
    {
        public ApartmentProfile()
        {
            CreateMap<Apartment, ApartmentDto>();
        }
    }

    public class ApartmentTypeProfile : Profile
    {
        public ApartmentTypeProfile()
        {
            CreateMap<ApartmentType, ApartmentTypeDto>();
        }
    }
}
