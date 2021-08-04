using System;
using System.Collections.Generic;
using System.Text;

namespace SmartApartment.Domain
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.Now;
    }
}
