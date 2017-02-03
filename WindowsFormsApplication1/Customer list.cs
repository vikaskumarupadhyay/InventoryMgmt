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
            string selectQuery = "select  Custd.CustId as [Customer ID] ,CustName AS Name ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustDesc AS Description,Custad.CustOpeningBalance AS [Opening Balance] , Custad.CustCurrentBalance AS [Current Ballance],CustPanNo AS [PAN NO], CustVatNo AS [VAT NO],CustCSTNo AS [CST NO]  ,CustServicetaxRegnNo AS [Service Tax Regn. No],CustExciseRegnNo AS [Excise Regn. No] ,Gstregnno AS [GST Regn. No] from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID ";
            string actualcolumn = "select  Custd.CustId  ,CustName  ,CustCompName  ,CustAddress ,CustCity , CustState  ,CustZip  ,CustCountry  ,CustEmail , CustWebAddress ,CustPhone  ,CustMobile  ,CustFax ,CustDesc ,Custad.CustOpeningBalance , Custad.CustCurrentBalance ,CustPanNo , CustVatNo ,CustCSTNo  ,CustServicetaxRegnNo ,CustExciseRegnNo  ,Gstregnno  from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID ";
            DataTable dt = d.getDetailByQuery(selectQuery);
            DataTable onlycolumnname = d.getDetailByQuery(actualcolumn);
            DataTable customtable = new DataTable();
            customtable.Columns.Add("Actualtablecolumname");
            customtable.Columns.Add("Aliascolumnname");
            DataColumnCollection c = dt.Columns;
            DataColumnCollection columnofname = onlycolumnname.Columns;
            for (int b = 1; b < c.Count; b++)
            {
                string d1 = c[b].ToString();
                string actualColumnName = columnofname[b].ToString();
                DataRow dr = customtable.NewRow();
                dr["Actualtablecolumname"] = actualColumnName;
                dr["Aliascolumnname"] = d1;
                customtable.Rows.Add(dr);
            }
           comboBox1.DataSource= customtable;
            comboBox1.ValueMember = "Actualtablecolumname";
            comboBox1.DisplayMember = "Aliascolumnname";
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
