using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CarDealershipSystem
{
    public partial class CustomerData2 : Form
    {
        public CustomerData2()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7FF550F\MSSQLSERVER01;Initial Catalog=CarSales;Integrated Security=True");
        private void CustomerData2_Load(object sender, EventArgs e)
        {
            GridCustomerData();
        }

        public void GridCustomerData()
        {
            string cmdText = "SELECT * FROM Customer";
            SqlCommand cmd = new SqlCommand(cmdText, con);
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            dgvCustomer.DataSource = ds.Tables[0];
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Payment pay = new Payment();

            pay.txtPID.Text = dgvCustomer.CurrentRow.Cells[0].Value.ToString();
            pay.txtFname.Text = dgvCustomer.CurrentRow.Cells[1].Value.ToString();
            pay.txtPhone.Text = dgvCustomer.CurrentRow.Cells[7].Value.ToString();
            pay.txtBgroup.Text = dgvCustomer.CurrentRow.Cells[8].Value.ToString();

            pay.Show();
            this.Hide();
        }
    }
}
