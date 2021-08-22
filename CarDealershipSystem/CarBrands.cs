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
    public partial class CarBrands : Form
    {
        public CarBrands()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7FF550F\MSSQLSERVER01;Initial Catalog=CarSales;Integrated Security=True");
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBID.Text == "" && txtCarM.Text == "")
            {
                MessageBox.Show("No Field should be left empty", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            con.Open();
            string s = "INSERT INTO carBrand VALUES('" + txtBID.Text + "','" + txtCarB.Text + "','" + txtCarM.Text + "','" + txtComment.Text + "')";
            SqlCommand command = new SqlCommand(s, con);
            int affectedrow = command.ExecuteNonQuery();
            if (affectedrow > 0)
            {
                MessageBox.Show("Record Saved Successfully...!!!", "CONFIRMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There is a problem", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            con.Close();
            getBrandID();
            txtCarB.Clear();
            txtCarM.Clear();
            txtComment.Clear();
        }

        public void getBrandID()
        {
            var chars = "6789012345";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 5)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            txtBID.Text = "B" + result;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CarBrands_Load(object sender, EventArgs e)
        {
            getBrandID();
        }
    }
}
