using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock_Management_System.Model;
using System.Windows.Forms;
using System.Data;

namespace Stock_Management_System.DAL
{
    class ItemSetupRepository
    {

        static string connection = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        SqlConnection con = new SqlConnection(connection);
        public bool Insert(ItemSetup it)
        {

            string query = @"INSERT ItemSetup (catagoryName,companyName,ItemName,ReorderLavel) Values (@catagoryName,@companyName,@ItemName,@ReorderLavel)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@catagoryName", it.CatagoryName);
            cmd.Parameters.AddWithValue("@companyName", it.ComapanyName);
            cmd.Parameters.AddWithValue("@ItemName", it.ItemName);
            cmd.Parameters.AddWithValue("@ReorderLavel", it.ReorderLavel);
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

        public void ComboBoxCompanySetup(ComboBox combo)
        {
            string qry = "Select * from CompanySetup";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            combo.DataSource = dt;
            combo.DisplayMember = "name";
            combo.ValueMember = "id";
        }

        public void ComboBoxCatagorySetup(ComboBox combo)
        {
            string qry = "Select * from CategorySetup";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            combo.DataSource = dt;
            combo.DisplayMember = "name";
            combo.ValueMember = "id";
        }

    }
}
