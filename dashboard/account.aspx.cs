using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_44905165.dashboard
{
    public partial class account : System.Web.UI.Page
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
            int patientID = (int)Session["UserID"];

            if (!IsPostBack)
            {
                // get personal info
                SqlCommand personalDetailsCmd = new SqlCommand(@"select name, surname, number, email, emergency_contact from patient where id = @id", handler.conn);
                personalDetailsCmd.Parameters.AddWithValue("@id", patientID);

                string[] personal = handler.GetRowValues(personalDetailsCmd, 5);

                // get allergies as a comma seperated list
                SqlCommand allergiesCmd = new SqlCommand(@"select STRING_AGG(allergy, ',') as allergies from allergy where patient_id = @patient_id group by patient_id", handler.conn);
                allergiesCmd.Parameters.AddWithValue("@patient_id", patientID);

                // parse allergies to array
                string[] allergies = handler.GetRowValues(allergiesCmd, 1)?[0].Split(',');             

                // prefill data
                txtName.Text = personal[0];
                txtSurname.Text = personal[1];
                txtNumber.Text = personal[2];
                txtEmail.Text = personal[3];
                txtEmergency.Text = personal[4];

                if (allergies != null)
                {
                    foreach (string allergy in allergies)
                    {
                        lstAllergies.Items.Add(allergy);
                    }
                }                
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // get personal info
            string
                name = txtName.Text,
                surname = txtSurname.Text,
                number = txtNumber.Text,
                email = txtEmail.Text,
                emergency = txtEmergency.Text;
            int patientID = (int)Session["UserID"];

            // update personal info
            string sql = @"update patient set name = @name, surname = @surname, number = @number, email = @email, emergency_contact = @emergency where id = @id";
            SqlCommand cmd = new SqlCommand(sql, handler.conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@surname", surname);
            cmd.Parameters.AddWithValue("@number", number);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@emergency", emergency);
            cmd.Parameters.AddWithValue("@id", patientID);

            if (handler.ExecuteUpdate(cmd))
            {
                // set username and refresh page
                Session["UserName"] = name;
                Response.Redirect("/account");               
            }
        }

        protected void btnAddAllergy_Click(object sender, EventArgs e)
        {
            string allergy = txtAllergy.Text;
            
            // check if allergy is in list
            bool hasValue = false;
            int i = 0;
            while (!hasValue && i < lstAllergies.Items.Count)
            {
                if (allergy.ToLower() == lstAllergies.Items[i].ToString().ToLower())
                {
                    hasValue = true;
                }

                i++;
            }

            if (hasValue)
            {
                lblAllergyError.Text = "Allergy already added*";
                lblAllergyError.Visible = true;
                txtAllergy.Text = "";
                return;
            }

            lblAllergyError.Visible = false;
            int patientID = (int)Session["UserID"];

            // insert allergy
            SqlCommand cmd = new SqlCommand(@"insert into allergy (patient_id, allergy) values(@id, @allergy)", handler.conn);
            cmd.Parameters.AddWithValue("@id", patientID);
            cmd.Parameters.AddWithValue("@allergy", allergy);

            if (handler.ExecuteInsert(cmd))
            {
                // add allergy to list
                lstAllergies.Items.Add(allergy);
                txtAllergy.Text = "";
            }
            else
            {
                lblAllergyError.Text = "An insert error occured*";
                lblAllergyError.Visible = true;
            }
        }

        protected void btnRemoveAllergy_Click(object sender, EventArgs e)
        {
            lblListError.Visible = false;
            int patientID = (int)Session["UserID"];

            // delete allergy from database
            SqlCommand cmd = new SqlCommand(@"delete allergy where patient_id = @id and allergy = @allergy",handler.conn);
            cmd.Parameters.AddWithValue("@id", patientID);
            cmd.Parameters.AddWithValue("@allergy", lstAllergies.Items[lstAllergies.SelectedIndex].Text);

            if (handler.ExecuteDelete(cmd))
            {
                // remove allergy from list
                lstAllergies.Items.RemoveAt(lstAllergies.SelectedIndex);
                lblListError.Visible = false;
            }
            else
            {
                lblListError.Text = "An update error occured*";
                lblListError.Visible = true;
            }

        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text,
                newPassword = txtNewPassword.Text;
            int patientID = (int)Session["UserID"];

            lblPasswordMessage.Visible = false;

            // update patient's password if current password is correct
            SqlCommand cmd = new SqlCommand(@"update patient set password = @newPassword where password = @password and id = @id", handler.conn);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@newPassword", newPassword);
            cmd.Parameters.AddWithValue("@id", patientID);

            if (handler.ExecuteUpdate(cmd))
            {              
                lblPasswordMessage.Text = "Password updated successfully*";
                lblPasswordMessage.ForeColor = Color.Green;              
            }
            else
            {
                lblPasswordMessage.Text = "Incorrect password*";
                lblPasswordMessage.ForeColor = Color.Red;   
            }

            // confirmation message
            lblPasswordMessage.Visible = true;

            // clear input
            txtPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirm.Text = "";
        }
    }
}