using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartApartment.WebFormsApp.Model
{
    public class Result
    {
        public bool Successful { get; set; }

        public string Message { get; set; } = string.Empty;

        public int ReturnedCode { get; set; }

        public object ReturnedObject { get; set; }
    }
}