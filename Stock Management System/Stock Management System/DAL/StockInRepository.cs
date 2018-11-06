using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stock_Management_System.Model;

namespace Stock_Management_System.DAL
{
    class StockInRepository
    {
        static string connection = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        SqlConnection con = new SqlConnection(connection);
        public bool Insert(StockIn st)
        {
            string query = @"INSERT StockIn (companyName,catagoryName,item,reorderLavel,availableQuantity,stockQuantity) Values (@companyName,@catagoryName,@item,@reorderLavel,@availableQuantity,@stockQuantity)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@companyName", st.ComapanyName);
            cmd.Parameters.AddWithValue("@catagoryName", st.CatagoryName);
            cmd.Parameters.AddWithValue("@item", st.Item);
            cmd.Parameters.AddWithValue("@reorderLavel", st.ReorderLavel);
            cmd.Parameters.AddWithValue("@availableQuantity", st.AvailableQuantity);
            cmd.Parameters.AddWithValue("@stockQuantity", st.StockInQuantity);
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

        public DataTable GridView()
        {
            string query = @"Select id as Id,department as Department,name as Name,regNo as Registration,contact as Contact from Student";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            return dt;
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

        public void ComboBoxItmeSetup(ComboBox combo)
        {
            string qry = "Select * from ItemSetup";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            combo.DataSource = dt;
            combo.DisplayMember = "itemName";
            combo.ValueMember = "id";
        }

        public void AlredyExisRegistrationNo(StockIn st)
        {
            //SqlConnection con = new SqlConnection(connection);     
            //string query = @"SELECT * FROM Student WHERE EXISTS (SELECT * FROM Student WHERE regNo=@regNo)";
            //SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@regNo", st.Registration_No);
            //con.Open();
            //SqlDataReader reader = cmd.ExecuteReader();
            //reader.Read();
            //if (reader.HasRows)

            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}          

            try
            {

                SqlConnection con = new SqlConnection(connection);

                //string query = @"SELECT name FROM Department WHERE EXISTS (SELECT name FROM Department)";
                string query = @"SELECT * FROM Student WHERE EXISTS (SELECT * FROM Student WHERE regNo=@regNo)";

                SqlCommand cmd = new SqlCommand(query, con);
               // cmd.Parameters.AddWithValue("@regNo", st.Registration_No);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    MessageBox.Show("Registration Number Already Exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                con.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
    }
}
