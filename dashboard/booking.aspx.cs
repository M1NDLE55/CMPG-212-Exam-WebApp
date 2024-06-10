using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_44905165.dashboard
{
    public partial class booking : System.Web.UI.Page
    {
        DataHandler handler;

        protected void Page_Load(object sender, EventArgs e)
        {
            // redirect if not logged in
            if (Session["UserID"] == null)
            {
                Response.Redirect("/", true);
            }

            handler = new DataHandler();

            // config controls
            if (!IsPostBack)
            {
                // set date range validator - min = today and max = 2 years from now
                rangeValidatorDate.MinimumValue = DateTime.Now.ToShortDateString();
                rangeValidatorDate.MaximumValue = DateTime.Now.AddYears(2).ToShortDateString();

                // get procedures
                SqlCommand cmdProcedures = new SqlCommand(@"select name from [procedure] order by name asc", handler.conn);
                handler.FillDropDown(cmdProcedures, ref ddlProcedure, "name");

                // set time slots
                DateTime timeSlots = new DateTime(2000, 1, 1, 8, 0, 0);
                do
                {
                    ddlTime.Items.Add(timeSlots.ToShortTimeString());
                    timeSlots = timeSlots.AddMinutes(30);
                }
                while (!timeSlots.Equals(new DateTime(2000, 1, 1, 16, 30, 0)));
            }
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            string procedure = ddlProcedure.Text;
            DateTime dateTime = DateTime.Parse(txtDate.Text + " " + ddlTime.Text);
            int patientID = (int)Session["UserID"];

            // check for appointment at dateTime by same patient
            SqlCommand checkCmd = new SqlCommand(@"select 1 from appointment where patient_id = @id and booking_time = @dateTime", handler.conn);
            checkCmd.Parameters.AddWithValue("@id", patientID);
            checkCmd.Parameters.AddWithValue("@dateTime", dateTime);

            string[] data = handler.GetRowValues(checkCmd,1);
            if (data != null)
            {
                // display error if patient already has an appointment
                lblError.Text = "You already have an appointment at this date and time*";
                lblError.Visible = true;
                return;
            }
            else
            {
                lblError.Visible = false;
            }
         
            // create appointment
            string insertSql =
                @"insert into appointment (patient_id,procedure_id,booking_time,status) " +
                @"values(@id," +
                @"(select id from [procedure] where name = @procedure),"+
                @"@dateTime,'Open')";

            SqlCommand InsertCmd = new SqlCommand(insertSql, handler.conn);
            InsertCmd.Parameters.AddWithValue("@id",patientID);
            InsertCmd.Parameters.AddWithValue("@procedure",procedure);
            InsertCmd.Parameters.AddWithValue("@dateTime",dateTime);

            if (handler.ExecuteInsert(InsertCmd))
            {
                // confirm that insert was successful
                lblError.Visible = false;
                content.Visible = false;
                confirmation.Visible = true;
            }
            else
            {
                lblError.Text = "Something unexpected happend, please try again*";
                lblError.Visible = true;
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect("/appointments");
        }

        protected void btnBookAnother_Click(object sender, EventArgs e)
        {
            confirmation.Visible = false;

            // reset input
            ddlProcedure.SelectedIndex = 0;
            txtDate.Text = "yyyy/mm/dd";
            ddlTime.SelectedIndex = 0;

            content.Visible = true;           
        }
    }
}