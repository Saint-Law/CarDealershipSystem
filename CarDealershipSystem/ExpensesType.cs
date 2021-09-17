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
    public partial class ExpensesType : Form
    {
        public ExpensesType()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7FF550F\MSSQLSERVER01;Initial Catalog=CarSales;Integrated Security=True");
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtExp.Text == "")
            {
                MessageBox.Show("No field should be left empty", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            con.Open();
            string query = "INSERT INTO expenseType VALUES('" + txtid.Text + "','" + txtExp.Text + "')";
            SqlCommand command = new SqlCommand(query, con);
            int affectedrow = command.ExecuteNonQuery();
            if (affectedrow > 0)
            {
                MessageBox.Show("Data Saved Successfully...!!!", "COMFIRMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There is a problem", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            con.Close();
            txtExp.Clear();
            displayData();
            generatID();
            txtExp.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtExp.Text == "")
            {
                MessageBox.Show("No field should be left empty", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 
            con.Open();
            string query = "UPDATE expenseType SET ExpensesType= '" + txtExp.Text + "' WHERE typeid= '" + txtid.Text + "'";
            SqlCommand command = new SqlCommand(query, con);
            int affectedrow = command.ExecuteNonQuery();
            if (affectedrow > 0)

                MessageBox.Show("One Record Updated Successfully...!!!", "CONFIRMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
            {
                MessageBox.Show("There is a problem", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            con.Close();
            txtExp.Clear();
            displayData();
            generatID();
            txtExp.Focus();
        }

        public void displayData()
        {
            string cmdText = "select * from expenseType";
            SqlCommand cmd = new SqlCommand(cmdText, con);
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            DataGridView2.DataSource = ds.Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtExp.Text == "")
            {
                MessageBox.Show("No field should be left empty", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            con.Open();
            string query = "Delete from expenseType where typeid='" + txtid.Text + "'";
            SqlCommand command = new SqlCommand(query, con);
            int affectedrow = command.ExecuteNonQuery();
            if (affectedrow > 0)

                MessageBox.Show("One Record Deleted Successfully...!!!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
            {
                MessageBox.Show("There is a problem", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
            txtExp.Clear();
            displayData();
            generatID();
            txtExp.Focus();
        }

        public void generatID()
        {
            var chars = "1234567890GHIJKLMRSTUVWXYZ";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 5)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            txtid.Text = "ExpT" + result;
        }

        private void ExpensesType_Load(object sender, EventArgs e)
        {
            displayData();
            generatID();
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DataGridView2.Rows[e.RowIndex];

                txtid.Text = row.Cells["TypeID"].Value.ToString();
                txtExp.Text = row.Cells["ExpensesType"].Value.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
