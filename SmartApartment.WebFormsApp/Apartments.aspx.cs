using SmartApartment.WebFormsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartApartment.WebFormsApp
{
    public partial class Apartments : System.Web.UI.Page
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
                GetApartments();
            }
        }

        private void GetApartments()
        {
            var apartmentTypes = new ApartmentService().GetApartments();
            if (apartmentTypes != null)
            {
                rptItems.DataSource = apartmentTypes.ReturnedObject;
                rptItems.DataBind();
            }
        }
    }
}