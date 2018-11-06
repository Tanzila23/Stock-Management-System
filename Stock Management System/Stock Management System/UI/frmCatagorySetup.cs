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
    public partial class frmCatagorySetup : Form
    {
        static string connection = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        SqlConnection con = new SqlConnection(connection);
        public frmCatagorySetup()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {

                CatagorySetup insGetSet = new CatagorySetup();
                insGetSet.Name = nameTextBox.Text;


                CatagorySetupManager catagorymanager = new CatagorySetupManager();
                bool chk = catagorymanager.Insert(insGetSet);

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

            SqlDataAdapter sda = new SqlDataAdapter("SELECT* FROM CategorySetup", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[1].Value = item["Name"].ToString();
            }

        }

        private void frmCatagorySetup_Load(object sender, EventArgs e)
        {
            loadData();

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["slNo"].Value = (e.RowIndex + 1).ToString();
        }

        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //CatagorySetup exist = new CatagorySetup();
            //exist.Name = nameTextBox.Text;

            //CatagorySetupRepository cs = new CatagorySetupRepository();
            //cs.AlredyExist(exist);
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            CatagorySetup exist = new CatagorySetup();
            exist.Name = nameTextBox.Text;

            CatagorySetupRepository cs = new CatagorySetupRepository();
            cs.AlredyExist(exist);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //frmUpdateCatagorySetup up = new frmUpdateCatagorySetup();

            //= this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

            //up.ShowDialog();

        }
        public void trainee_info()
        {
            SqlConnection con = new SqlConnection(connection);
            string query = @"select  * from CategorySetup ";
            SqlCommand cmd = new SqlCommand(query, con);
            
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                var senderview = (DataGridView)sender;
                if (senderview.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    if (this.dataGridView1.CurrentCell.ColumnIndex == 2)
                    {
                        if (MessageBox.Show("Confirm Update Category", "Update Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            int row = Convert.ToInt32(dataGridView1.CurrentRow.Cells["slNo"].Value);
                            SqlConnection con = new SqlConnection(connection);
                            SqlCommand cmd = new SqlCommand(@"update CategorySetup  set  name = '" + dataGridView1.CurrentRow.Cells["Name"].Value +
                                                              "' where slNo ='" + row + "'", con);
                            
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();


                        }
                    }
                }
            }
        }
    }
}
