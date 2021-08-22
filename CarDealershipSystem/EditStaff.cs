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
    public partial class EditStaff : Form
    {
        public EditStaff()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7FF550F\MSSQLSERVER01;Initial Catalog=CarSales;Integrated Security=True");
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text == "" && txtQualify.Text == "")
            {
                MessageBox.Show("No Field should be left empty", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            con.Open();
            string query = "UPDATE StaffReg SET staffname='" +
                txtFname.Text + "',gender='" +
                cmbSex.Text + "',address='" +
                txtAdd.Text + "',phone='" +
                txtPhone.Text + "',email='" +
                txtMail.Text + "',qualification='" +
                txtQualify.Text + "',dob='" +
                txtDob.Text + "',bloodgroup='" +
                cmbBgroup.Text + "' WHERE staffid='" + txtPId.Text + "'";
            SqlCommand command = new SqlCommand(query, con);
            int affectedrow = command.ExecuteNonQuery();
            if (affectedrow > 0)
            {
                MessageBox.Show("Staff Records Updated Successfully...!!!", "CONFIRMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There is a problem", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
            txtAdd.Clear();
            txtFname.Clear();
            txtMail.Clear();
            txtPhone.Clear();
            txtPId.Clear();
            txtPId.Focus();
            txtQualify.Clear();
            cmbBgroup.SelectedIndex = -1;
            cmbSex.SelectedIndex = -1;
        }

        public void getDoctortRecord()
        {
            con.Open();
            string quarry = "SELECT * FROM StaffReg where staffid='" + txtPId.Text + "'";

            SqlCommand command = new SqlCommand(quarry, con);
            SqlDataReader me = command.ExecuteReader();
            while (me.Read())
            {
                txtFname.Text = me[1].ToString();
                cmbSex.Text = me[2].ToString();
                txtAdd.Text = me[3].ToString();
                txtPhone.Text = me[4].ToString();
                txtMail.Text = me[5].ToString();
                txtQualify.Text = me[6].ToString();
                txtDob.Text = me[7].ToString();
                cmbBgroup.Text = me[8].ToString();
            }
            con.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text == "" && txtQualify.Text == "")
            {
                MessageBox.Show("No Field should be left empty", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            con.Open();
            string s = "DELETE FROM StaffReg where staffid='" + txtPId.Text + "'";
            SqlCommand command = new SqlCommand(s, con);
            int affectedrow = command.ExecuteNonQuery();
            if (affectedrow > 0)
            {
                MessageBox.Show("Staff Records Deleted Successfully...!!!", "CONFIRMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There is a problem", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
            txtAdd.Clear();
            txtFname.Clear();
            txtMail.Clear();
            txtPhone.Clear();
            txtPId.Clear();
            txtPId.Focus();
            txtQualify.Clear();
            cmbBgroup.SelectedIndex = -1;
            cmbSex.SelectedIndex = -1;
        }

        private void txtPId_TextChanged(object sender, EventArgs e)
        {
            getDoctortRecord();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
