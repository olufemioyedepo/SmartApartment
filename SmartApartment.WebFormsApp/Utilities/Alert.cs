using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.UI;

namespace SmartApartment.WebFormsApp.Utilities
{
    public class Alert
    {
        private static readonly Page Page = (Page)HttpContext.Current.Handler;

        public static string Text(string text)
        {
            try
            {
                var sb = new StringBuilder(text.Length * 5);
                text = text.Replace("\0", string.Empty);
                foreach (var c in text)
                {
                    sb.Append("\\x" + ("0" + Convert.ToString(c, 16).ToUpper()).Substring(
                                  ("0" + Convert.ToString(c, 16).ToUpper()).Length - 2));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                // WebLog.Log(ex);
            }

            return text;
        }
        public static void Show(string text, [Optional] string type, [Optional] string title)
        {
            type = type ?? "info";
            title = title ?? "";
            var script = "<script language=javascript>swal({title:'" + title + "', text:'" + Text(text) + "', type:'" + type + "'}), function() { " +
                "      swal('Deleted!', 'Your imaginary file has been deleted.', 'success');" +
                "}"+
                //"window.location = 'default.aspx';" + 
            "</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "sweetalert", script);
        }
    }
}