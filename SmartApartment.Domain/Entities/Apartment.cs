using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        [Required]
        public int ApartmentTypeId { get; set; }
        [ForeignKey("ApartmentTypeId")]
        public ApartmentType ApartmentType { get; set; }

        [Required]
        public int StateId { get; set; }
        [ForeignKey("StateId")]
        public State State { get; set; }
        
        [Required]
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
    }
}
