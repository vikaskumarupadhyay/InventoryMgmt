using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Customer_list : Form
    {
        DB_Main d = new DB_Main();
        public Customer_list()
        {
            InitializeComponent();
        }

        private void Customer_list_Load(object sender, EventArgs e)
        {
            string selectQuery = "select cd.custid,cd.CustName,cd.CustCompName,cd.CustAddress,cd.CustCity,cd.CustState,cd.CustZip,cd.CustCountry,cd.CustEmail,cd.CustWebAddress,cd.CustPhone,cd.CustMobile,cd.CustFax,cd.CustDesc,cad.CustOpeningBalance,cad.CustCurrentBalance from CustomerDetails cd join CustomerAccountDetails cad on cd.CustId=cad.CustId ";
            DataTable dt = d.getDetailByQuery(selectQuery);
            List<string> sd = new List<string>();
            DataColumnCollection d1 = dt.Columns;

            for (int a = 1; a < d1.Count; a++)
            {
                DataColumn dc = new DataColumn();
                string val = d1[a].ToString();
                sd.Add(val);
            }
            comboBox1.DataSource = sd;
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = comboBox1.SelectedValue.ToString();
           // string val = "Cust" + s;
            string selectQuery = "select cd.custid,cd.CustName,cd.CustCompName,cd.CustAddress,cd.CustCity,cd.CustState,cd.CustZip,cd.CustCountry,cd.CustEmail,cd.CustWebAddress,cd.CustPhone,cd.CustMobile,cd.CustFax,cd.CustDesc,cad.CustOpeningBalance,cad.CustCurrentBalance from CustomerDetails cd join CustomerAccountDetails cad on cd.CustId=cad.CustId  where " + s + " like '" + textBox1.Text + "%'";
            DataTable dt = d.getDetailByQuery(selectQuery);
            dataGridView1.DataSource = dt;
        }
    }
}
