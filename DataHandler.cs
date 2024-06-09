using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApp_44905165
{
    public class DataHandler
    {
        public SqlConnection conn { get; set; }
        private SqlDataAdapter adapter;
        private DataSet ds;

        public DataHandler()
        {
            try
            {
                // get path to database - this is specific to the folder structure of the parent folder
                string parentFolder = AppDomain.CurrentDomain.BaseDirectory;
                // database located within desktop application's project
                string relativePath = @"..\Desktop_44905165\BrightonMedical.mdf";
                string databasePath = Path.GetFullPath(Path.Combine(parentFolder, relativePath));

                conn = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={databasePath};Integrated Security=True");
                adapter = new SqlDataAdapter();
                ds = new DataSet();
            }
            catch (Exception ex)
            {
                // error message
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public bool FillGridView(SqlCommand cmd, ref GridView gv)
        {
            try
            {
                // uses sql select statement to fill referenced gridview
                conn.Open();

                ds.Clear();

                adapter.SelectCommand = cmd;

                // will return true if rows were added to gridview
                bool result = true;
                if (adapter.Fill(ds) < 1)
                {
                    result = false;
                }              

                gv.DataSource = ds;
                gv.DataBind();

                cmd.Dispose();

                conn.Close();

                return result;
            }
            catch (SqlException ex)
            {
                // error message
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public string[] GetRowValues(SqlCommand cmd, int MAX_FIELDS = 50)
        {
            // returns array with fields of a single row

            string[] data = new string[MAX_FIELDS];

            try
            {
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                // create array with values of row
                if (dr.Read())
                {
                    // get number of fields in row
                    int fields = dr.FieldCount;

                    // populate array
                    for (int i = 0; i < fields; i++)
                    {
                        data[i] = dr[i].ToString();
                    }
                }
                else
                {
                    // return null if there are no rows
                    data = null;
                }

                cmd.Dispose();
                conn.Close();
                return data;
            }
            catch (SqlException ex)
            {
                // error message
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public bool ExecuteInsert(SqlCommand cmd)
        {
            try
            {
                // uses sql insert statement to insert record into database
                conn.Open();

                adapter.InsertCommand = cmd;

                bool result = false;
                if (adapter.InsertCommand.ExecuteNonQuery() > 0)
                {
                    result = true;
                }

                cmd.Dispose();

                conn.Close();

                return result;
            }
            catch (SqlException ex)
            {
                // error message
                System.Diagnostics.Debug.WriteLine(ex.Message);

                return false;
            }
        }

        public bool ExecuteUpdate(SqlCommand cmd)
        {
            try
            {
                // uses sql update statement to update database
                conn.Open();

                adapter.UpdateCommand = cmd;

                bool result = false;
                if (adapter.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    result = true;
                }

                cmd.Dispose();

                conn.Close();

                return result;
            }
            catch (SqlException ex)
            {
                // error message
                System.Diagnostics.Debug.WriteLine(ex.Message);

                return false;
            }
        }

        public void FillDropDown(SqlCommand cmd, ref DropDownList ddlRef, string column)
        {
            // creates and assigns a new dataset to a drop down list

            try
            {
                conn.Open();

                DataSet dataSet = new DataSet();

                adapter.SelectCommand = cmd;
                adapter.Fill(dataSet);

                cmd.Dispose();

                conn.Close();

                // assign desired column to dataset
                ddlRef.DataValueField = column;
                ddlRef.DataTextField = column;
                ddlRef.DataSource = dataSet.Tables[0];
                ddlRef.DataBind();
            }
            catch (Exception ex)
            {
                // error message
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}