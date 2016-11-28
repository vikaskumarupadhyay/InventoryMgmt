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
    public partial class VendorList1 : Form
    {
        public VendorList1()
        {
            InitializeComponent();
        }

        DB_Main dbMainClass = new DB_Main();
        private void VendorList_Load(object sender, EventArgs e)
        {

            string selectqurry = "select  vName as NAME, vCompName as COMPNAME,vAddress as ADDRESS,vCity as CITY,vState as STATE,vZip as ZIP,vCountry as COUNTRY,vEmail as EMAIL,vWebAddress as WEBADDRESS,vPhone as PHONE,vMobile as MOBILE,vFax as FAX,vDesc as DESCription from VendorDetails";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            List<string> ls = new List<string>();
            DataColumnCollection d = dt.Columns;
            for (int a = 0; a < d.Count; a++)
            {
                DataColumn dc = new DataColumn();
                string b = d[a].ToString();
                ls.Add(b);
            }
            comboBox1.DataSource = ls;
            dataGridView1.DataSource = dt;
        }

        private void txtVenorSearch_TextChanged(object sender, EventArgs e)
        {
            string s = comboBox1.SelectedValue.ToString();
            string m = "v" + s;
            string selectQurry = "select * from VendorDetails where " + m + " like '" + txtVenorSearch.Text + "%'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            dataGridView1.DataSource = dt;
        }
    }
}
