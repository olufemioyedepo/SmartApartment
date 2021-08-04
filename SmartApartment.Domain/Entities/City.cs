using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartApartment.Domain.Entities
{
    public class City : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [ForeignKey("State")]
        public int StateId { get; set; }
        //public State State { get; set; }
    }
}
