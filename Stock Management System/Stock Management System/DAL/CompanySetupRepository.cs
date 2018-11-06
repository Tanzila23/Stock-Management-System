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
    class CompanySetupRepository
    {
        static string connection = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        SqlConnection con = new SqlConnection(connection);
        public bool Insert(CompanySetup cm)
        {

            string query = @"INSERT CompanySetup (name) Values (@name)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", cm.Name);
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
    }
}
