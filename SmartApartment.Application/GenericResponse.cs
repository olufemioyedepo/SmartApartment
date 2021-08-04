using System;
using System.Collections.Generic;
using System.Text;

namespace SmartApartment.Application
{
    public class GenericResponse<T>
    {
        public int Code { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
