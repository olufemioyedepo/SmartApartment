using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApartment.NetCoreApp.Mvc.Models.Apartment
{
    public class ApartmentInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ApartmentType { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
