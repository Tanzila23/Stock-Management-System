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
    public partial class frmStockIn : Form
    {
        public frmStockIn()
        {
            InitializeComponent();
        }

        private void frmStockIn_Load(object sender, EventArgs e)
        {
            StockInRepository cmb = new StockInRepository();          
            cmb.ComboBoxCatagorySetup(categoryComboBox);
            cmb.ComboBoxCompanySetup(companyComboBox);
            cmb.ComboBoxItmeSetup(itemComboBox);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                StockIn insGet = new StockIn();
                insGet.ComapanyName = companyComboBox.Text;
                insGet.CatagoryName = categoryComboBox.Text;
                insGet.Item = itemComboBox.Text;
                insGet.ReorderLavel = reorderTextBox.Text;
                insGet.StockInQuantity = stockinTextBox.Text;
                insGet.AvailableQuantity = availableQuanTextBox.Text;

                StockInManager manager = new StockInManager();
                bool chk = manager.Insert(insGet);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
