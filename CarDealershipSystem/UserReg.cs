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
    public partial class UserReg : Form
    {
        public UserReg()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7FF550F\MSSQLSERVER01;Initial Catalog=CarSales;Integrated Security=True");

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" && txtPwd.Text == "")
            {
                MessageBox.Show("No field should be left empty", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            con.Open();
            string s = "INSERT INTO users VALUES('" + txtUsername.Text + "','" + txtPwd.Text + "','" + cmbUType.SelectedItem + "')";
            SqlCommand command = new SqlCommand(s, con);
            int affectedrow = command.ExecuteNonQuery();
            if (affectedrow > 0)
            {
                MessageBox.Show("Data Saved Successfully...!!!", "CONFIRMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There is a problem", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            con.Close();
            txtPwd.Clear();
            txtUsername.Clear();
            cmbUType.SelectedIndex = -1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
