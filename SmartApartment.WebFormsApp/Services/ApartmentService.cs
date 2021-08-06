using MySql.Data.MySqlClient;
using SmartApartment.WebFormsApp.Model;
using SmartApartment.WebFormsApp.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace SmartApartment.WebFormsApp.Services
{
    public class ApartmentService
    {
        private readonly string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        public Result GetApartmentTypes()
        {
            var res = new Result();

            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM apartmenttypes"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);

                                res.ReturnedObject = dt;
                                res.Message = dt.Rows.Count > 0 ? "Aoartment types loaded successfully!" : "No apartment type found!";
                                res.ReturnedCode = 200;
                                res.Successful = true;
                            }

                            sda.Dispose();
                        }

                        cmd.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);

                res.Message = ex.Message;
                res.ReturnedCode = 500;
                res.ReturnedObject = null;
                res.Successful = false;
            }

            return res;
        }

        public Result GetApartments()
        {
            var res = new Result();

            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT apartments.Name, apartmenttypes.Name as ApartmentType, apartments.Address, apartments.Description FROM apartments INNER JOIN apartmenttypes ON apartmenttypes.Id = apartments.ApartmentTypeId"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);

                                res.ReturnedObject = dt;
                                res.Message = dt.Rows.Count > 0 ? "Aoartment loaded successfully!" : "No apartment data found!";
                                res.ReturnedCode = 200;
                                res.Successful = true;
                            }

                            sda.Dispose();
                        }

                        cmd.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);

                res.Message = ex.Message;
                res.ReturnedCode = 500;
                res.ReturnedObject = null;
                res.Successful = false;
            }

            return res;
        }
    }
}