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
    public partial class BookingData : Form
    {
        public BookingData()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7FF550F\MSSQLSERVER01;Initial Catalog=CarSales;Integrated Security=True");
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GridBookingData()
        {
            string cmdText = "SELECT * FROM booking";
            SqlCommand cmd = new SqlCommand(cmdText, con);
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            dgvCustomer.DataSource = ds.Tables[0];
        }

        public void SearchByPhone()
        {
            string cmdText = "SELECT * FROM booking where contact='" + txtSearch.Text + "'";
            SqlCommand cmd = new SqlCommand(cmdText, con);
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            dgvCustomer.DataSource = ds.Tables[0];
        }

        public void searchByID()
        {
            string cmdText = "SELECT * FROM booking where bookingid='" + txtSearch.Text + "'";
            SqlCommand cmd = new SqlCommand(cmdText, con);
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            dgvCustomer.DataSource = ds.Tables[0];
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            GridBookingData();
        }

        private void BookingData_Load(object sender, EventArgs e)
        {
            GridBookingData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchByID();
        }

        private void txtsName_TextChanged(object sender, EventArgs e)
        {
            SearchByPhone();
        }
    }
}
