using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartApartment.Application.Helpers
{
    public class Utility
    {
        readonly IConfiguration _configuration;

        public Utility(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string ErrorLog(Exception ex)
        {
            string exceptionMessage = String.Format(
                "Mesaage:\n {0}\n\n Inner Exception:\n {1}\n\n Stacktrace:\n {2}\n " +
                "______________________________________________________________________________________________________________________________________________________________________________________________",
                ex.Message, ex.InnerException == null ? "N/A" : ex.InnerException.Message, ex.StackTrace);
            return exceptionMessage;
        }

        public static string InternalServerErrorText()
        {
            return "A server error must have occured!";
        }
    }
}
