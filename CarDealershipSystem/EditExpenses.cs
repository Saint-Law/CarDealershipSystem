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
    public partial class EditExpenses : Form
    {
        public EditExpenses()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7FF550F\MSSQLSERVER01;Initial Catalog=CarSales;Integrated Security=True");
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtExp.Text == "" && txtAmt.Text == "")
            {
                MessageBox.Show("No field should be left empty", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            con.Open();
            string query = "UPDATE Expense SET expense='" +
                txtExp.Text + "',date='" +
                dtpExpenseDate.Text + "',expensetype='" +
                cmbExpT.SelectedItem + "',amount='" +
                txtAmt.Text + "' WHERE expenseid='" + txtExpenseID.Text + "'";
            SqlCommand command = new SqlCommand(query, con);
            int affectedrow = command.ExecuteNonQuery();
            if (affectedrow > 0)
            {
                MessageBox.Show("One Record Updated Successfully...!!!", "CONFIRMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There is a problem", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            con.Close();
            txtAmt.Clear();
            txtExp.Clear();
            txtExpenseID.Clear();
            dtpExpenseDate.Text = DateTime.Now.ToString();
            displayDataGrid();
            txtExpenseID.Focus();
            cmbExpT.SelectedIndex = -1;
        }

        public void displayDataGrid()
        {
            string cmdText = "SELECT * FROM Expenses";
            SqlCommand cmd = new SqlCommand(cmdText, con);
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            DataGridView2.DataSource = ds.Tables[0];
        }

        public void displayData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT ExpensesType FROM expenseType ORDER BY ExpensesType ASC", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbExpT.Items.Add(dr["ExpensesType"]);
            }
            con.Close();
            dr.Close();
            dr.Dispose();
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DataGridView2.Rows[e.RowIndex];

                txtExpenseID.Text = row.Cells["ExpensesID"].Value.ToString();
                txtExp.Text = row.Cells["Expenses"].Value.ToString();
                dtpExpenseDate.Text = row.Cells["Date"].Value.ToString();
                cmbExpT.Text = row.Cells["Type"].Value.ToString();
                txtAmt.Text = row.Cells["Amount"].Value.ToString();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtExpenseID.Text == "" && cmbExpT.Text == "")
            {
                MessageBox.Show("No field should be left empty", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            con.Open();
            string query = "DELETE FROM Expenses WHERE expenseid='" + txtExpenseID.Text + "'";
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
            txtAmt.Clear();
            txtExp.Clear();
            txtExpenseID.Clear();
            dtpExpenseDate.Text = DateTime.Now.ToString();
            displayDataGrid();
            txtExpenseID.Focus();
            cmbExpT.SelectedIndex = -1;
        }

        private void EditExpenses_Load(object sender, EventArgs e)
        {
            displayData();
            displayDataGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
