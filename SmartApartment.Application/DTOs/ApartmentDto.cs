using System;
using System.Collections.Generic;
using System.Text;

namespace SmartApartment.Application.DTOs
{
    public class ApartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ApartmentInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ApartmentType { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }

    public class ApartmentCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ApartmentTypeId { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }

    public class ApartmentTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CityDto
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }
    }
}
