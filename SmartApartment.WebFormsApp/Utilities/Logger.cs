using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace SmartApartment.WebFormsApp.Utilities
{
    public class Logger : Exception
    {
        private static string _filePath;
        private static string _directory;
        public static void Log(Exception exception)
        {
            var basePath = ConfigurationManager.AppSettings["BasePath"];
            _directory = Path.Combine(basePath, "WealthMart", "ErrorLog");
            _filePath = Path.Combine(_directory, "WebLog.txt");

            var localDate = DateTime.Now.ToString("yyyy/MM/dd");
            var localTime = DateTime.Now.ToString("HH:mm:ss");
            var errorDateTime = localDate + " @ " + localTime;

            try
            {
                if (!Directory.Exists(_directory)) Directory.CreateDirectory(_directory);
                var sw = new StreamWriter(_filePath, true);
                sw.WriteLine("--------------------------");
                sw.WriteLine(errorDateTime);
                sw.WriteLine("--------------------------");
                sw.WriteLine("Exception Message: {0}", exception.Message);
                if (exception.InnerException != null)
                {
                    sw.WriteLine("Inner Exception: {0}", exception.InnerException);
                }
                sw.WriteLine();
                sw.Close();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }
    }
}