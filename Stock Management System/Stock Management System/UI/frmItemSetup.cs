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
namespace Stock_Management_System
{
    public partial class frmItemSetup : Form
    {
        public frmItemSetup()
        {
            InitializeComponent();
        }
        private void frmItemSetup_Load(object sender, EventArgs e)
        {
            ItemSetupRepository cmb = new ItemSetupRepository();            
            cmb.ComboBoxCatagorySetup(categoryComboBox);
            cmb.ComboBoxCompanySetup(companyComboBox);
          
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                ItemSetup insGetSet = new ItemSetup();
                insGetSet.CatagoryName = categoryComboBox.Text;
                insGetSet.ComapanyName = companyComboBox.Text;
                insGetSet.ItemName = itemTextBox.Text;
                insGetSet.ReorderLavel = reorderTextBox.Text;


                ItemSetupManager companymanager = new ItemSetupManager();
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
        }

        
    }
}
