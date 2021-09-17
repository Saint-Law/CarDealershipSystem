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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7FF550F\MSSQLSERVER01;Initial Catalog=CarSales;Integrated Security=True");

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            CustomerData2 pdata = new CustomerData2();
            pdata.Show();
        }

        public void WashPrice()
        {
            if (cmbTreat.Text == "")
            {
                txtPriceUnit.Text = "".ToString();
            }
            else
            {
                con.Open();
                SqlCommand command = con.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM carBrand WHERE Brand='" + cmbTreat.SelectedItem.ToString() + "'";
                command.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    txtPriceUnit.Text = dr["Amount"].ToString();
                }
            }

            con.Close();
        }

        public void getInvoice()
        {
            var chars = "6789012345";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 5)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            txtInNo.Text = "INV" + result;
        }

        public void getWashRecord()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Brand FROM carBrand ORDER BY Brand ASC", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbTreat.Items.Add(dr["Brand"]);
            }
            con.Close();
            dr.Close();
            dr.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtArec.Text == "" && txtTamount.Text == "")
            {
                MessageBox.Show("No Field Should Be Left Empty", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            con.Open();
            string query = "INSERT INTO Payment VALUES('" + txtInNo.Text + "','" +
                dtpIndate.Text + "','" +
                cmbCash.SelectedItem + "','" +
                txtPID.Text + "','" +
                txtFname.Text + "','" +
                txtBgroup.Text + "','" +
                txtPhone.Text + "','" +
                cmbTreat.SelectedItem + "','" +
                txtUnit.Text + "','" +
                txtPriceUnit.Text + "','" +
                txtTamount.Text + "','" + txtArec.Text + "','" + txtBalance.Text + "')";
            SqlCommand command = new SqlCommand(query, con);
            int affectedrow = command.ExecuteNonQuery();
            if (affectedrow > 0)
            {
                MessageBox.Show("Payment Record Saved Successfully...!!!", "CONFIRMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There is a problem", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            con.Close();
            txtArec.Clear();
            txtBalance.Clear();
            txtBgroup.Clear();
            txtFname.Clear();
            //txtLpay.Clear();
            txtPhone.Clear();
            txtPID.Clear();
            getInvoice();
            txtPriceUnit.Clear();
            txtTamount.Clear();
            txtUnit.Clear();
            cmbCash.SelectedIndex = -1;
            cmbTreat.SelectedIndex = -1;
            dtpIndate.Text = DateTime.Now.ToString();
        }

        private void txtUnit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTamount.Text = (float.Parse(txtPriceUnit.Text) * float.Parse(txtUnit.Text)).ToString();

            }
            catch
            {
                if (txtUnit.Text == "")
                {
                    txtTamount.Text = "";
                }
            }
        }

        private void cmbTreat_SelectedIndexChanged(object sender, EventArgs e)
        {
            WashPrice();
        }

       
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtArec.Text == "" && txtTamount.Text == "")
            {
                MessageBox.Show("No Field Should Be Left Empty", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            con.Open();
            string query = "UPDATE Payment SET date='" +
                dtpIndate.Text + "',paymenttype='" +
                cmbCash.Text + "',patientid='" +
                txtPID.Text + "',fullname='" +
                txtFname.Text + "',bloodgroup='" +
                txtBgroup.Text + "',phone='" +
                txtPhone.Text + "',treatment='" +
                cmbTreat.Text + "',unit='" +
                txtUnit.Text + "',priceperunit='" +
                txtPriceUnit.Text + "',total='" +
                txtTamount.Text + "',amountreceived='" +
                txtArec.Text + "',duebalance='" + txtBalance.Text + "' WHERE invoice='" + txtInNo.Text + "'";
            SqlCommand command = new SqlCommand(query, con);
            int affectedrow = command.ExecuteNonQuery();
            if (affectedrow > 0)
            {
                MessageBox.Show("Payment Record Updated Successfully...!!!", "CONFIRMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There is a problem", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            con.Close();
            txtArec.Clear();
            txtBalance.Clear();
            txtBgroup.Clear();
            txtFname.Clear();

            txtPhone.Clear();
            txtPID.Clear();
            getInvoice();
            txtPriceUnit.Clear();
            txtTamount.Clear();
            txtUnit.Clear();
            cmbCash.SelectedIndex = -1;
            cmbTreat.SelectedIndex = -1;
            dtpIndate.Text = DateTime.Now.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtArec.Text == "" && txtTamount.Text == "")
            {
                MessageBox.Show("No Field Should Be Left Empty", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            con.Open();
            string query = "DELETE FROM Payment WHERE invoice='" + txtInNo.Text + "'";
            SqlCommand command = new SqlCommand(query, con);
            int affectedrow = command.ExecuteNonQuery();
            if (affectedrow > 0)
            {
                MessageBox.Show("One Record Deleted Successfully...!!!", "CONFIRMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There is a problem", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            con.Close();
            txtArec.Clear();
            txtBalance.Clear();
            txtBgroup.Clear();
            txtFname.Clear();
            //txtLpay.Clear();
            txtPhone.Clear();
            txtPID.Clear();
            getInvoice();
            txtPriceUnit.Clear();
            txtTamount.Clear();
            txtUnit.Clear();
            cmbCash.SelectedIndex = -1;
            cmbTreat.SelectedIndex = -1;
            dtpIndate.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PaymentData pDat = new PaymentData();
            pDat.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtArec_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtBalance.Text = (float.Parse(txtTamount.Text) - float.Parse(txtArec.Text)).ToString();

            }
            catch
            {
                if (txtArec.Text == "")
                {
                    txtBalance.Text = "";
                }
            }
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            getInvoice();
            getWashRecord();
        }
    }
}
