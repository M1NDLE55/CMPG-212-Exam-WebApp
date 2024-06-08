using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_44905165
{
    public partial class register : System.Web.UI.Page
    {
        DataHandler handler;

        protected void Page_Load(object sender, EventArgs e)
        {
            handler = new DataHandler();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            SqlCommand getIdCmd = new SqlCommand(@"select id, case when password is null then 'empty' else 'filled' end as status from patient where email = @email", handler.conn);
            getIdCmd.Parameters.AddWithValue("@email", email);

            string[] patient = handler.GetRowValues(getIdCmd, 2);

            // check if patient exists
            if (patient == null)
            {
                lblRegisterError.Text = "You have not yet been added by an admin*";
                lblRegisterError.Visible = true;
                return;
            }

            // check if password is empty
            if (patient[1] != "empty")
            {
                lblRegisterError.Text = "This account is already registered*";
                lblRegisterError.Visible = true;
                return;
            }

            // get patient id
            int patientID = int.Parse(patient[0]);

            // update password
            SqlCommand updatePasswordCmd = new SqlCommand(@"update patient set password = @password where id = @id",handler.conn);
            updatePasswordCmd.Parameters.AddWithValue("@password", password);
            updatePasswordCmd.Parameters.AddWithValue("@id", patientID);

            if (!handler.ExecuteUpdate(updatePasswordCmd))
            {
                lblRegisterError.Text = "Something unexpected happend*";
                lblRegisterError.Visible = true;
                return;
            }

            // create session
            Session["UserID"] = patientID;

            // redirect to dashboard
            //Response.Redirect("/dashboard");
        }
    }
}