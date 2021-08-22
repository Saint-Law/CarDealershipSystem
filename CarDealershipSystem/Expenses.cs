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
    public partial class Expenses : Form
    {
        public Expenses()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7FF550F\MSSQLSERVER01;Initial Catalog=CarSales;Integrated Security=True");
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtExp.Text == "" && txtAmt.Text == "")
            {
                MessageBox.Show("No field should be left empty", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            con.Open();
            string query = "INSERT INTO Expense VALUES('" + txtExpenseID.Text + "','" +
                txtExp.Text + "','" +
                dtpExpenseDate.Text + "','" +
                cmbExpT.SelectedItem + "','" +
                txtAmt.Text + "')";
            SqlCommand command = new SqlCommand(query, con);
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
            txtAmt.Clear();
            txtExp.Clear();
            dtpExpenseDate.Text = DateTime.Now.ToString();
            displayData();
            generateExpenseID();
            cmbExpT.SelectedIndex = -1;
            txtExp.Focus();
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

        public void generateExpenseID()
        {

            var chars = "1234567890ABCDE";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 5)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            txtExpenseID.Text = "Exp" + result;

        }

        private void Expenses_Load(object sender, EventArgs e)
        {
            generateExpenseID();
            displayData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EditExpenses epz = new EditExpenses();
            epz.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EditExpenses epz = new EditExpenses();
            epz.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
