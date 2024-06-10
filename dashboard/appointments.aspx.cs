using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_44905165.dashboard
{
    public partial class appointments : System.Web.UI.Page
    {
        DataHandler handler;

        protected void Page_Load(object sender, EventArgs e)
        {
            // redirect if not logged in
            if (Session["UserID"] == null)
            {
                Response.Redirect("/", true);
            }
            
            // init data handler
            handler = new DataHandler();

            int patientID = (int)Session["UserID"];

            // get open upcoming appointments for a patient
            string sql =
                @"select a.id as ID, p.name as [Procedure], a.booking_time as DateTime, p.fee as Fee " +
                @"from appointment a join [procedure] p on a.procedure_id = p.id " +
                @"where a.booking_time >= GETDATE() " +
                @"and status = 'Open' " +
                @"and a.patient_id = @patient_id " +
                @"order by a.booking_time";
            SqlCommand cmd = new SqlCommand(sql ,handler.conn);
            cmd.Parameters.AddWithValue("@patient_id", patientID);

            // populate grid view with appointments
            if (!handler.FillGridView(cmd, ref gvAppointments))
            {
                // display message if no appointments are made
                content.Visible = false;
                message.Visible = true;
            }
        }

        protected void gvAppointments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel_Click")
            {
                // get selected row index and data
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                DataKey data = gvAppointments.DataKeys[rowIndex];

                // get appointment id
                string appointmentID = data.Values["ID"].ToString();

                // store id in cookie
                HttpCookie _cookie = new HttpCookie("CancelForm");
                _cookie["AppointmentID"] = appointmentID;
                Response.Cookies.Add(_cookie);

                // set confirmation details
                litDetails.Text =
                    $"<b>Appointment Details</b>" +
                    $"Procedure: {data.Values["Procedure"]}</br>" +
                    $"Date: {DateTime.Parse(data.Values["DateTime"].ToString()).ToLongDateString()}</br>" +
                    $"Time: {DateTime.Parse(data.Values["DateTime"].ToString()).ToShortTimeString()}</br>" +
                    $"Fee: {data.Values["Fee"]:C}";

                // display confirmation popup
                details.Visible = true;

            }
        }

        protected void btnKeep_Click(object sender, EventArgs e)
        {
            // reset details
            litDetails.Text = "";

            // remove cookie with appointment id
            HttpCookie _cookie = Request.Cookies["CancelForm"];
            if (_cookie != null )
            {
                _cookie.Expires = DateTime.Now.AddDays(-1);
            }
            
            // hide section
            details.Visible = false;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            HttpCookie _cookie = Request.Cookies["CancelForm"];
            if (_cookie == null)
            {
                // cookie wasn't created for some reason -> refresh page
                Response.Redirect("/appointments",true);
            }

            int appointmentID = int.Parse(_cookie["AppointmentID"]);

            // set appointment status to cancelled - only admins can delete appointments
            SqlCommand cmd = new SqlCommand(@"update appointment set status = 'Cancelled' where id = @id", handler.conn);
            cmd.Parameters.AddWithValue("@id", appointmentID);

            handler.ExecuteUpdate(cmd);

            // refresh page for gridview to update
            Response.Redirect("/appointments", true);
        }
    }
}