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
    public partial class EditCustomers : Form
    {
        public EditCustomers()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7FF550F\MSSQLSERVER01;Initial Catalog=CarSales;Integrated Security=True");

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditCustomers_Load(object sender, EventArgs e)
        {
            getCustomerRecord();
        }

        public void getCustomerRecord()
        {
            con.Open();
            string quarry = "SELECT * FROM Customer where customerid='" + txtCid.Text + "'";

            SqlCommand command = new SqlCommand(quarry, con);
            SqlDataReader me = command.ExecuteReader();
            while (me.Read())
            {
                txtCusName.Text = me[1].ToString();
                cmbSex.Text = me[2].ToString();
                txtHadd.Text = me[3].ToString();
                txtContact.Text = me[4].ToString();
                txtNation.Text = me[5].ToString();
                txtState.Text = me[6].ToString();
                txtLga.Text = me[7].ToString();
                txtEmail.Text = me[8].ToString();
            }
            con.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtContact.Text == "" && txtEmail.Text == "")
            {
                MessageBox.Show("No Field should be left empty", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            con.Open();
            string query = "UPDATE Customer SET name='" +
                txtCusName.Text + "',gender='" +
                cmbSex.SelectedItem + "',homeaddress'" +
                txtHadd.Text + "',phone='" +
                txtContact.Text + "',nationality='" +
                txtNation.Text + "',state='" +
                txtState.Text + "',lga='" +
                txtLga.Text + "',emai='" + txtEmail.Text + "' WHERE customerid='" + txtCid.Text + "'";
            SqlCommand command = new SqlCommand(query, con);
            int affectedrow = command.ExecuteNonQuery();
            if (affectedrow > 0)
            {
                MessageBox.Show("Customers Records Saved Successfully...!!!", "CONFIRMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There is a problem", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
            txtCusName.Clear();
            txtLga.Clear();
            txtNation.Clear();
            txtHadd.Clear();
            txtContact.Clear();
            txtState.Clear();
            cmbSex.SelectedIndex = -1;
            pictureBox1.Dispose();
            txtCid.Focus();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtContact.Text == "" && txtEmail.Text == "")
            {
                MessageBox.Show("No Field should be left empty", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            con.Open();
            string s = "DELETE FROM Customer WHERE customerid='" + txtCid.Text + "'";
            SqlCommand command = new SqlCommand(s, con);
            int affectedrow = command.ExecuteNonQuery();
            if (affectedrow > 0)
            {
                MessageBox.Show("Customers Records Deleted Successfully...!!!", "CONFIRMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There is a problem", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
            txtCusName.Clear();
            txtEmail.Clear();
            txtLga.Clear();
            txtNation.Clear();
            txtHadd.Clear();
            txtContact.Clear();
            txtState.Clear();
            cmbSex.SelectedIndex = -1;
            pictureBox1.Dispose();
            txtCid.Focus();
        }

        private void txtCid_TextChanged(object sender, EventArgs e)
        {
            getCustomerRecord();
        }
    }
}
