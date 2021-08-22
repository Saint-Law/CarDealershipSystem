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
    public partial class BankDeposit : Form
    {
        public BankDeposit()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7FF550F\MSSQLSERVER01;Initial Catalog=CarSales;Integrated Security=True");
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAmt.Text == "" && txtid.Text == "")
            {
                MessageBox.Show("No field should be left empty", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            con.Open();
            string s = "INSERT INTO Deposit VALUES('" +
                txtid.Text + "','" +
                txtAmt.Text + "','" +
                txtTno.Text + "','" + dtpDeposit.Text + "','" + txtPerson.Text + "')";
            SqlCommand command = new SqlCommand(s, con);
            int affectedrow = command.ExecuteNonQuery();
            if (affectedrow > 0)
            {
                MessageBox.Show("Deposit Saved Successfully.........!!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There is a problem", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
            generatID();
            txtAmt.Clear();
            txtTno.Clear();
            dtpDeposit.Text = DateTime.Now.ToString();
            txtAmt.Focus();
        }

        public void generatID()
        {
            var chars = "9876543210";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 5)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            txtid.Text = "BK" + result;
        }

        private void BankDeposit_Load(object sender, EventArgs e)
        {
            generatID();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
