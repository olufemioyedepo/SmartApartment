using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartApartment.Domain.Entities
{
    public class State : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
