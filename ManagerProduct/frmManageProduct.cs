using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerProduct
{
    public partial class frmManageProduct : Form
    {
        public frmManageProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnManaBill_Click(object sender, EventArgs e)
        {
            frmBill billform = new frmBill();
            billform.Show();
            this .Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnManageCustomer_Click(object sender, EventArgs e)
        {
            {
                ManageCustomerForm billform = new ManageCustomerForm();
                billform.Show();
                this.Hide();
            }

        }
    }
}
