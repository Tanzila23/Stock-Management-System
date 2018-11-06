using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using Stock_Management_System.Model;
using System.Windows.Forms;

namespace Stock_Management_System.DAL
{
  
    class CatagorySetupRepository
    {
        static string  connection = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        SqlConnection con = new SqlConnection(connection);
        public bool Insert(CatagorySetup ca)
        {
           
            string query = @"INSERT CategorySetup (name) Values (@name)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", ca.Name);           
            con.Open();
            int rowAffect = cmd.ExecuteNonQuery();
            con.Close();
            if (rowAffect > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void AlredyExist(CatagorySetup cs)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                string query = @"SELECT * FROM CategorySetup WHERE EXISTS (SELECT * FROM CategorySetup WHERE name=@name)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", cs.Name);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    MessageBox.Show("This Name Already Added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
    }


