using MySql.Data.MySqlClient;
using SmartApartment.WebFormsApp.Services;
using SmartApartment.WebFormsApp.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace SmartApartment.WebFormsApp
{
    public partial class ApartmentTypes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var loggedIn = Convert.ToBoolean(Session["LoggedIn"]);
            if (loggedIn == false)
            {
                string message = "You are not authorized to view this page, kindly log in...";
                string url = "/";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += url;
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
            }

            if (!this.IsPostBack && loggedIn)
            {
                GetApartmentTypes();
            }
        }

        private void GetApartmentTypes()
        {
            var apartmentTypes = new ApartmentService().GetApartmentTypes();
            if (apartmentTypes != null)
            {
                rptItems.DataSource = apartmentTypes.ReturnedObject;
                rptItems.DataBind();
            }
        }
    }
}