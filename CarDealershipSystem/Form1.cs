using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDealershipSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(splashscreen));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }

        public void splashscreen()
        {
            Application.Run(new Form2());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUname.Text == "admin" && txtPwd.Text == "admin")
            {
                MessageBox.Show("Welcome To Car Dealership System");
                Dashboard dash = new Dashboard();
                dash.Show();
                this.Hide();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePwd cpw = new ChangePwd();
            cpw.Show();
        }
    }
}
