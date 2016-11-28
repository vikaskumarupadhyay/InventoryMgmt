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
    public partial class Form9 : Form
    {
        DB_Main dbMainClass = new DB_Main();
        DataTable vendorDetails = new DataTable();
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            txtpayDate.Value = DateTime.Now;
            Purchase.PurchaseDetails purChaseDetailObj = new Purchase.PurchaseDetails();
            vendorDetails = purChaseDetailObj.GetVendorDetaisInDataTable();
            panel2.Visible = false;
        }
        private void setVAlue()
        {
            if (vendorDetails.Rows.Count > 0)
            {
                string vendorId = txtvendorId.Text;
                if (vendorId.Trim() != "" && vendorId != null)
                {
                    DataRow[] dr = vendorDetails.Select("vendorid='" + vendorId + "'");
                    if (dr != null && dr.Length > 0)
                    {
                        //venderId, , vCompName, vAddress, vCity, vState, vZip, vCountry, vEmail, vWebAddress, vPhone, vMobile, vFax, vDesc
                        string vendorName = dr[0]["Name"].ToString();
                        string vendorAddress = dr[0]["Address"].ToString();
                        string vendorCompName = dr[0]["CompanyName"].ToString();
                        string vendorPhone = dr[0]["Phone"].ToString();
                        string vendorMobile = dr[0]["Mobile"].ToString();
                        string vendorFax = dr[0]["Fax"].ToString();

                        txtVendorName.Text = vendorName;
                        txtAddress.Text = vendorAddress;
                        txtCompanyName.Text = vendorCompName;
                        txtPhone.Text = vendorPhone;
                        txtMobile.Text = vendorMobile;
                        txtFax.Text = vendorFax;
                    }
                    else
                    {
                        txtVendorName.Text = "";
                        txtAddress.Text = "";
                        txtCompanyName.Text = "";
                        txtPhone.Text = "";
                        txtMobile.Text = "";
                        txtFax.Text = "";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            string selectqurry = "select venderId,vName as NAME,vCompName as COMPNAME,vAddress as ADDRESS,vPhone as PHONE,vMobile as MOBILE,vFax as FAX from VendorDetails";
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
            dataGridView2.DataSource = dt;

        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            string s = comboBox1.SelectedValue.ToString();
            string m = "v" + s;
            string selectQurry = "select venderId,vName as NAME,vCompName as COMPANYNAME,vAddress as ADDRESS,vPhone as PHONE,vMobile as MOBILE,vFax as FAX from VendorDetails where " + m + " like '" + txtSearch.Text + "%'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            dataGridView2.DataSource = dt;
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = false;
            DataGridViewCellCollection call = dataGridView2.Rows[e.RowIndex].Cells;
            setDetails(call);
        }
        private void setDetails(DataGridViewCellCollection cellCollection)
        {
            try
            {
               txtvendorId.Text = cellCollection[0].Value.ToString();
                txtVendorName.Text = cellCollection[1].Value.ToString();
                txtCompanyName.Text = cellCollection[2].Value.ToString();
                txtAddress.Text = cellCollection[3].Value.ToString();
                txtPhone.Text = cellCollection[4].Value.ToString();
                txtMobile.Text = cellCollection[5].Value.ToString();
                txtFax.Text = cellCollection[6].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtvendorId_TextChanged(object sender, EventArgs e)
        {
            if (txtvendorId.Text.Trim() != "" && txtvendorId.Text.StartsWith("V"))
            {
                setVAlue();
            }
        }

     
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
