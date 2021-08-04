using AutoMapper;
using SmartApartment.Application.DTOs;
using SmartApartment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartApartment.Application.MappingProfiles
{
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<State, StatesDto>();
        }
    }

    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>();
        }
    }
}
