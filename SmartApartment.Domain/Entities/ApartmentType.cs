using System;
using System.Collections.Generic;
using System.Text;

namespace SmartApartment.Domain.Entities
{
    public class ApartmentType : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Apartment> Apartments{ get; set; }
    }
}
