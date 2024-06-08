using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_44905165.dashboard
{
    public partial class dashboard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // redirect if not logged in
            if (Session["UserID"] == null)
            {
                Response.Redirect("/", true);
            }

            // display user name
            username.InnerText = Session["UserName"].ToString();

            // highlight current nav link
            string url = Request.Url.AbsolutePath.ToLower();
            
            switch (url)
            {
                case "/appointments":
                    SetActiveLink(linkAppointments);                 
                    break;
                case "/booking":
                    SetActiveLink(linkBooking);
                    break;
            }
        }

        private void SetActiveLink(HyperLink link)
        {
            Color color = Color.FromArgb(1, 0, 165, 207);

            link.BackColor = color;
            link.BorderColor = color;
            link.ForeColor = Color.White;
        }
    }
}