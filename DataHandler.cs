using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApp_44905165
{
    public class DataHandler
    {
        private SqlConnection conn;

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

                conn.Open();
                conn.Close();
            }
            catch (Exception ex)
            {
                // error message
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}