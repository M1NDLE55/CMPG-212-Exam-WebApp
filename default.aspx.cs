using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_44905165
{
    public partial class _default : System.Web.UI.Page
    {
        DataHandler handler;

        protected void Page_Load(object sender, EventArgs e)
        {
            handler = new DataHandler();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = "piet@tester.com";
            string password = "frikkels";
            
            //string email = txtEmail.Text;
            //string password = txtPassword.Text;

            // get id if user info correct
            SqlCommand cmd = new SqlCommand(@"select id, name from patient where email = @email and password = @password", handler.conn);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);

            string[] data = handler.GetRowValues(cmd, 2);
            if (data != null)
            {
                // hide error message
                lblLoginError.Visible = false;

                // create session
                Session["UserID"] = int.Parse(data[0]);
                Session["UserName"] = data[1];

                // redirect to dashboard
                Response.Redirect("/appointments");
            }
            else
            {
                // display error message
                lblLoginError.Visible = true;
            }
        }
    }
}