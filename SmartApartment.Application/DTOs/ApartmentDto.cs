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
