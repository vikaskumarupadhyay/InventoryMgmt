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
            string selectqurry = "select vd.venderId,vd.vName as NAME,vd.vCompName as COMPNAME,vd.vAddress as ADDRESS,vd.vCity as CITY,vd.vState as STATE,vZip as ZIP,vd.vCountry as COUNTRY,vd.vEmail as EMAIL,vd.vWebAddress as WEBADDRESS,vd.vPhone as PHONE,vd.vMobile as MOBILE,vd.vFax as FAX,vd.vDesc as DESCription,Vad.vOpeningBalance as OpeningBalance,vad.vCurrentBalance as CurrentBalance,vd.vPanNo,vd.vTinNo  from VendorDetails vd join VendorAccountDetails Vad on vd.venderId=Vad.venderId";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            List<string> ls = new List<string>();
            DataColumnCollection d = dt.Columns;
            for (int a = 1; a < d.Count; a++)
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
            string selectQurry = "select vd.venderId,vd.vName as NAME,vd.vCompName as COMPNAME,vd.vAddress as ADDRESS,vd.vCity as CITY,vd.vState as STATE,vZip as ZIP,vd.vCountry as COUNTRY,vd.vEmail as EMAIL,vd.vWebAddress as WEBADDRESS,vd.vPhone as PHONE,vd.vMobile as MOBILE,vd.vFax as FAX,vd.vDesc as DESCription,Vad.vOpeningBalance as OpeningBalance,vad.vCurrentBalance as CurrentBalance  from VendorDetails vd join VendorAccountDetails Vad on vd.venderId=Vad.venderId  where " + m + " like '" + txtVenorSearch.Text + "%'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            dataGridView1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
