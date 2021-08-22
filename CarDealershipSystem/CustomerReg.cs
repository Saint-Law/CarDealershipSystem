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
    public partial class CustomerReg : Form
    {
        public CustomerReg()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7FF550F\MSSQLSERVER01;Initial Catalog=CarSales;Integrated Security=True");
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtContact.Text == "" && txtEmail.Text == "")
            {
                MessageBox.Show("No Field should be left empty", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            con.Open();
            string query = "INSERT INTO Customer VALUES('" + txtCid.Text + "','" +
                txtCusName.Text + "','" +
                cmbSex.SelectedItem + "','" +
                txtHadd.Text + "','" +
                txtContact.Text + "','" +
                txtNation.Text + "','" +
                txtState.Text + "','" +
                txtLga.Text + "','" + txtEmail.Text + "')";
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
        }

        public void generateCustomerID()
        {
            var chars = "1234567890IJKL";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 7)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            txtCid.Text = "CUS" + result;
        }

        private void CustomerReg_Load(object sender, EventArgs e)
        {
            generateCustomerID();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtCusName.Clear();
            txtEmail.Clear();
            txtLga.Clear();
            txtNation.Clear();
            txtHadd.Clear();
            txtContact.Clear();;
            generateCustomerID();
            txtState.Clear();
            cmbSex.SelectedIndex = -1;
            pictureBox1.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp) |*.jpg; *.png; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
