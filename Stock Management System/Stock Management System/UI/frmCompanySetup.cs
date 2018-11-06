using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stock_Management_System.BLL;
using Stock_Management_System.DAL;
using Stock_Management_System.Model;
using System.Data.SqlClient;
using System.Configuration;


namespace Stock_Management_System
{
    public partial class frmCompanySetup : Form
    {
        static string connection = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        SqlConnection con = new SqlConnection(connection);
        public frmCompanySetup()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {

                CompanySetup insGetSet = new CompanySetup();
                insGetSet.Name = nameTextBox.Text;


                CompanySetupManager companymanager = new CompanySetupManager();
                bool chk = companymanager.Insert(insGetSet);

                if (chk)
                {
                    MessageBox.Show("Data Saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Try Again");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            nameTextBox.Text = "";
            loadData();
        }
        public void loadData()
        {

            SqlDataAdapter sda = new SqlDataAdapter("SELECT* FROM CompanySetup", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[1].Value = item["Name"].ToString();
            }

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["slNo"].Value = (e.RowIndex + 1).ToString();
        }

        private void frmCompanySetup_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
