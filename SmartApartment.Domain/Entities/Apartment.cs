using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartApartment.Domain.Entities
{
    public class Apartment : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string Description { get; set; }
        // State Id
        // City Id
        [Required]
        public int ApartmentTypeId { get; set; }
        public ApartmentType ApartmentType { get; set; }
        
    }
}
