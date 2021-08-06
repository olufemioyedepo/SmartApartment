using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Diagnostics.Trace;

namespace SmartApartment.WebFormsApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string eventArg = Request["__EVENTARGUMENT"];
            WriteLine($"Load __EVENTARGUMENT = {eventArg}");
            if (!string.IsNullOrEmpty(eventArg))
            {
                Session["RawIdToken"] = eventArg;
                //Response.Redirect("/", true);

                if (IsPostBack)
                {
                    string rawIdToken = Session["RawIdToken"]?.ToString();
                    if (rawIdToken == null)
                    {
                        return;
                    }
                    string[] parts = rawIdToken.Split(".".ToCharArray());
                    string decodedPayload = Decode(parts[1]);

                    dynamic payload = JsonConvert.DeserializeObject(decodedPayload);
                    Session["Name"] = $"Welcome {payload.name}!";
                    Session["LoggedIn"] = true;
                }
            }

            string name = Session["Name"]?.ToString();
            if (name == null)
            {
                liSignout.Visible = false;
                liLogin.Visible = true;
                return;
            }

            if (name != null)
            {
                liLogin.Visible = false;
                liSignout.Visible = true;
                lblUsername.InnerText = name;
            }
                
        }

        protected void SignOut_Click(object sender, EventArgs e)
        {
            var d = Session["Name"];
            Session.RemoveAll();

            Response.Redirect("/");
        }

        /// <summary>
		/// The base64 from an Id Token is not '='padded and it is in base64url encoding
		/// where underscore and dash need fixing before decode.
		/// </summary>
		string Decode(string value)
        {
            value = value.Replace("_", "/").Replace("-", "+");
            if (value.Length % 4 == 2) value += "==";
            else if (value.Length % 4 == 3) value += "=";
            string json = Encoding.ASCII.GetString(Convert.FromBase64String(value));
            var obj = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}