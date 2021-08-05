using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using static System.Diagnostics.Trace;

namespace SmartApartment.WebFormsApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			/*
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
						boxHeader.Text = "No token in session";
						return;
					}
					string[] parts = rawIdToken.Split(".".ToCharArray());
					string decodedPayload = Decode(parts[1]);

					dynamic payload = JsonConvert.DeserializeObject(decodedPayload);
					Session["Name"] = $"Welcome {payload.name}!";
				}
			}
			 */
		}
	}
}