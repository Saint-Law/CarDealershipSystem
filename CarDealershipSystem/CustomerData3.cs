﻿using System;
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
    public partial class CustomerData3 : Form
    {
        public CustomerData3()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7FF550F\MSSQLSERVER01;Initial Catalog=CarSales;Integrated Security=True");
        private void CustomerData3_Load(object sender, EventArgs e)
        {
            GridCustomerData();
        }

        public void GridCustomerData()
        {
            string cmdText = "SELECT * FROM Customer";
            SqlCommand cmd = new SqlCommand(cmdText, con);
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            dgvPatient.DataSource = ds.Tables[0];
        }
    }
}
