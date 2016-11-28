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
    public partial class Form5 : Form

    {
        DB_Main d = new DB_Main();
        DataTable customerdetails = new DataTable();
     
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            txtcustomerid.Text = "C";
            dtpdate.Value = DateTime.Now;
            Purchase.PurchaseDetails purchasedetailobj = new Purchase.PurchaseDetails();
            customerdetails = purchasedetailobj.GetcustomerdetailsInDataTable();
            panel2.Visible = false;
        }
      
        private void setvalue()
        {
            if (customerdetails.Rows.Count > 0)
            {
                string customerid = txtcustomerid.Text;
                if (customerid.Trim() != "" && customerid != null)
                {
                    DataRow[] dr = customerdetails.Select("CustId='" + customerid + "'");
                    if (dr != null && dr.Length > 0)
                    {
                        string customername = dr[0]["Name"].ToString();
                        string customeraddress = dr[0]["Address"].ToString();
                        string customerCompName = dr[0]["COMPANYNAME"].ToString();
                       
                       
                        string customerphone = dr[0]["Phone"].ToString();
                        string customermobile = dr[0]["Mobile"].ToString();
                        string customerfax = dr[0]["Fax"].ToString();
                        txtcustname.Text = customername;
                        txtaddress.Text = customeraddress;
                        txtcustcompnayname.Text = customerCompName;
                       
                       
                        txtphone.Text = customerphone;
                        txtmobile.Text = customermobile;
                        txtfax.Text = customerfax;
                    }
                    else
                    {
                        txtcustname.Text = "";
                        txtcustcompnayname.Text = "";
                        txtaddress.Text = "";
                       
                        txtphone.Text = "";
                        txtmobile.Text = "";
                        txtfax.Text = "";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            string selectquery1 = " Select custid,CustName as Name,CustCompName as CompnayName,CustAddress as Address,CustPhone as Phone,CustMobile as Mobile,CustFax  as Fax from CustomerDetails";
            DataTable dt1 = d.getDetailByQuery(selectquery1);
           // string val = " ";
            List<string> sd = new List<string>();
            DataColumnCollection d1 = dt1.Columns;
            for(int a=1;a<d1.Count;a++)
            {
                DataColumn dc = new DataColumn();
                string val = d1[a].ToString();
                sd.Add(val);
            }
            combsearch.DataSource = sd;
            dataGridView2.DataSource = dt1;
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = false;
            DataGridViewCellCollection cell = dataGridView2.Rows[e.RowIndex].Cells;
            setdetails(cell);
        }
        private void setdetails(DataGridViewCellCollection collection)
        {
            try
            {
                txtcustomerid.Text = collection[0].Value.ToString();
                txtcustname.Text = collection[1].Value.ToString();
                txtcustcompnayname.Text = collection[2].Value.ToString();
                txtaddress.Text = collection[3].Value.ToString();
                txtphone.Text = collection[4].Value.ToString();
                txtmobile.Text = collection[5].Value.ToString();
                txtfax.Text = collection[6].Value.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string s = combsearch.SelectedValue.ToString();
            string m = "c" + s;
            string selectquery = "custid,CustName as Name,CustCompName as CompnayName,CustAddress as Address,CustPhone as Phone,CustMobile as Mobile,CustFax  as Fax from CustomerDetails";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView2.DataSource = dt;
        }

        private void txtcustomerid_TextChanged(object sender, EventArgs e)
        {
            if (txtcustomerid.Text.Trim() != "" && txtcustomerid.Text.StartsWith("C"))
            {
                setvalue();
            }
        }

      
       
    }
}
