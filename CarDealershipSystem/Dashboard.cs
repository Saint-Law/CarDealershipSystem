using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDealershipSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Are you sure you want to quit", "closed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerReg reg = new CustomerReg();
            reg.ShowDialog();
        }

        private void addUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void expenseTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpensesType type = new ExpensesType();
            type.ShowDialog();
        }

        private void expenseEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expenses exp = new Expenses();
            exp.ShowDialog();
        }

        private void medicineCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarBrands brand = new CarBrands();
            brand.ShowDialog();
        }

        private void medicineEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePwd pwd = new ChangePwd();
            pwd.ShowDialog();
        }

        private void addDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void editDoctorRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditStaff staff = new EditStaff();
            staff.ShowDialog();
        }

        private void editPatientRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCustomers edit = new EditCustomers();
            edit.ShowDialog();
        }

        private void bookAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bookings book = new Bookings();
            book.ShowDialog();
        }

        private void editBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void viewAppointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookingData data = new BookingData();
            data.ShowDialog();
        }

        private void makePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment pay = new Payment();
            pay.ShowDialog();
        }
    }
}
