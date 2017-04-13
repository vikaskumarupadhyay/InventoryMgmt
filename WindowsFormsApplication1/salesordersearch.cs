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
    public partial class salesordersearch : Form
    {
        DB_Main d = new DB_Main();
        public salesordersearch()
        {
            InitializeComponent();
        }
        public double getTotalAmounts()
        {
            double totalValue = 0.0;
            double s;
            for (int a = 0; a < dataGridView1.Rows.Count; a++)
            {
                s = Convert.ToDouble(dataGridView1.Rows[a].Cells[20].Value);
                totalValue = totalValue + s;

            }
            return totalValue;
        }
        public double getdiscountamount()
        {
            double totalValue = 0.0;
            double s;
            for (int a = 0; a < dataGridView1.Rows.Count; a++)
            {
                s = Convert.ToDouble(dataGridView1.Rows[a].Cells[22].Value);
                totalValue = totalValue + s;

            }
            return totalValue;
        }
        public double gettaxamount()
        {
            double totalValue = 0.0;
            double s;
            for (int a = 0; a < dataGridView1.Rows.Count; a++)
            {
                s = Convert.ToDouble(dataGridView1.Rows[a].Cells[24].Value);
                totalValue = totalValue + s;

            }
            return totalValue;
        }
        public double getwithauttaxamount()
        {
            double totalValue = 0.0;
            double s;
            for (int a = 0; a < dataGridView1.Rows.Count; a++)
            {
                s = Convert.ToDouble(dataGridView1.Rows[a].Cells[25].Value);
                totalValue = totalValue + s;

            }
            return totalValue;
        }
        private void salesordersearch_Load(object sender, EventArgs e)
        {
            try
            {
                string selectquery = "SELECT dbo.CustomerDetails.custId as[Customer ID], dbo.CustomerDetails.CustName as[Customer Name], dbo.CustomerDetails.CustCompName as[Compnay Name],dbo.CustomerDetails.CustAddress as [Address], dbo.CustomerDetails.CustCity as[City], dbo.CustomerDetails.CustState as[State], dbo.CustomerDetails.CustZip as[Zip], dbo.CustomerDetails.CustCountry as [Country],dbo.CustomerDetails.CustEmail as[Email], dbo.CustomerDetails.CustWebAddress as[Web Address], dbo.CustomerDetails.CustPhone as[Phone], dbo.CustomerDetails.CustMobile as [Mobile],dbo.customerorderdescriptions.orderid as [Order ID], dbo.orderdetails.date as [Order Date],dbo.customerorderdescriptions.ItemId as[Item ID],dbo.ItemDetails.ItemName as[Item Name],dbo.ItemDetails.ItemCompName as[Item Compnay Name],dbo.ItemPriceDetail.MrpPrice as[Mrp], dbo.customerorderdescriptions.price as[Selling Rate], dbo.customerorderdescriptions.quantity as [Quantity], dbo.customerorderdescriptions.totalammount as[Gross Amount], dbo.orderdetails.Discount as[Discount Rate],((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100) as [Discount Amount], dbo.orderdetails.Tax as[Tax], (dbo.customerorderdescriptions.totalammount)- ((dbo.customerorderdescriptions.totalammount)/(1+(dbo.orderdetails.Tax/100))) as [Tax Amount], dbo.orderdetails.totalammount AS [Net Amount (Including Tax)] FROM dbo.CompnayDetails CROSS JOIN dbo.ItemDetails INNER JOIN dbo.customerorderdescriptions ON dbo.ItemDetails.ItemId = dbo.customerorderdescriptions.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId INNER JOIN dbo.orderdetails ON dbo.customerorderdescriptions.orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId ";
                string actualcolumn = "SELECT top 1 dbo.CustomerDetails.custId ,dbo.CustomerDetails.CustName, dbo.CustomerDetails.CustCompName, dbo.CustomerDetails.CustAddress, dbo.CustomerDetails.CustCity,dbo.CustomerDetails.CustState, dbo.CustomerDetails.CustZip, dbo.CustomerDetails.CustCountry, dbo.CustomerDetails.CustEmail,dbo.CustomerDetails.CustWebAddress, dbo.CustomerDetails.CustPhone, dbo.CustomerDetails.CustMobile, dbo.customerorderdescriptions.orderid,dbo.customerorderdescriptions.ItemId, dbo.customerorderdescriptions.price, dbo.customerorderdescriptions.quantity, dbo.customerorderdescriptions.totalammount,dbo.ItemDetails.ItemName, dbo.ItemPriceDetail.MrpPrice, dbo.orderdetails.date, dbo.orderdetails.totalammount AS Expr1, dbo.orderdetails.Discount,dbo.orderdetails.Discountamount, dbo.orderdetails.Tax, dbo.orderdetails.Taxamount, dbo.orderdetails.WithautTaxamount FROM dbo.CompnayDetails CROSS JOIN dbo.ItemDetails INNER JOIN dbo.customerorderdescriptions ON dbo.ItemDetails.ItemId = dbo.customerorderdescriptions.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId INNER JOIN dbo.orderdetails ON dbo.customerorderdescriptions.orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId";
                DataTable dt = d.getDetailByQuery(selectquery);
                // DataTable dt1 = d.getDetailByQuery(actualcolumn);
                DataTable dtOnlyColumnName = d.getDetailByQuery(actualcolumn);
                DataTable customDataTable = new DataTable();
                customDataTable.Columns.Add("ActualTableColumnName");
                customDataTable.Columns.Add("AliasTableColumnName");
                //List<string> ls = new List<string>();
                DataColumnCollection d1 = dt.Columns;
                DataColumnCollection dataColumnForName = dtOnlyColumnName.Columns;
                for (int a = 0; a < d1.Count; a++)
                {
                    //DataColumn dc = new DataColumn();
                    string b = d1[a].ToString();
                    string actualColumnName = dataColumnForName[a].ToString();
                    DataRow dr = customDataTable.NewRow();
                    dr["ActualTableColumnName"] = actualColumnName;
                    dr["AliasTableColumnName"] = b;
                    customDataTable.Rows.Add(dr);
                    //  ls.Add(b);
                }

                comsalesordersearch.DataSource = customDataTable;
                comsalesordersearch.ValueMember = "ActualTableColumnName";
                comsalesordersearch.DisplayMember = "AliasTableColumnName";
                dataGridView1.DataSource = dt;
                double grosa = getTotalAmounts();
                txtGrossAmount.Text = grosa.ToString();
                double disa = getdiscountamount();
                Txtdisamount.Text = disa.ToString();
                double taxamount = gettaxamount();
                txttaxamount.Text = taxamount.ToString();
                double withaut = getwithauttaxamount();
                txtwithauttaxamount.Text = withaut.ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string s = comsalesordersearch.SelectedValue.ToString();
            string selectquery = "SELECT dbo.CustomerDetails.custId as[Customer ID], dbo.CustomerDetails.CustName as[Customer Name], dbo.CustomerDetails.CustCompName as[Compnay Name],dbo.CustomerDetails.CustAddress as [Address], dbo.CustomerDetails.CustCity as[City], dbo.CustomerDetails.CustState as[State], dbo.CustomerDetails.CustZip as[Zip], dbo.CustomerDetails.CustCountry as [Country],dbo.CustomerDetails.CustEmail as[Email], dbo.CustomerDetails.CustWebAddress as[Web Address], dbo.CustomerDetails.CustPhone as[Phone], dbo.CustomerDetails.CustMobile as [Mobile],dbo.customerorderdescriptions.orderid as [Order ID], dbo.orderdetails.date as [Order Date],dbo.customerorderdescriptions.ItemId as[Item ID],dbo.ItemDetails.ItemName as[Item Name],dbo.ItemDetails.ItemCompName as[Item Compnay Name],dbo.ItemPriceDetail.MrpPrice as[Mrp], dbo.customerorderdescriptions.price as[Selling Rate], dbo.customerorderdescriptions.quantity as [Quantity], dbo.customerorderdescriptions.totalammount as[Gross Amount], dbo.orderdetails.Discount as[Discount Rate],((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100) as [Discount Amount], dbo.orderdetails.Tax as[Tax], (dbo.customerorderdescriptions.totalammount)- ((dbo.customerorderdescriptions.totalammount)/(1+(dbo.orderdetails.Tax/100))) as [Tax Amount], dbo.orderdetails.totalammount AS [Net Amount (Including Tax)] FROM dbo.CompnayDetails CROSS JOIN dbo.ItemDetails INNER JOIN dbo.customerorderdescriptions ON dbo.ItemDetails.ItemId = dbo.customerorderdescriptions.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId INNER JOIN dbo.orderdetails ON dbo.customerorderdescriptions.orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId  Where " + s + " like'" + txtsearch.Text + "%'";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = comsalesordersearch.SelectedValue.ToString();
            string selectquery = "SELECT dbo.CustomerDetails.custId as[Customer ID], dbo.CustomerDetails.CustName as[Customer Name], dbo.CustomerDetails.CustCompName as[Compnay Name],dbo.CustomerDetails.CustAddress as [Address], dbo.CustomerDetails.CustCity as[City], dbo.CustomerDetails.CustState as[State], dbo.CustomerDetails.CustZip as[Zip], dbo.CustomerDetails.CustCountry as [Country],dbo.CustomerDetails.CustEmail as[Email], dbo.CustomerDetails.CustWebAddress as[Web Address], dbo.CustomerDetails.CustPhone as[Phone], dbo.CustomerDetails.CustMobile as [Mobile],dbo.customerorderdescriptions.orderid as [Order ID], dbo.orderdetails.date as [Order Date],dbo.customerorderdescriptions.ItemId as[Item ID],dbo.ItemDetails.ItemName as[Item Name],dbo.ItemDetails.ItemCompName as[Item Compnay Name],dbo.ItemPriceDetail.MrpPrice as[Mrp], dbo.customerorderdescriptions.price as[Selling Rate], dbo.customerorderdescriptions.quantity as [Quantity], dbo.customerorderdescriptions.totalammount as[Gross Amount], dbo.orderdetails.Discount as[Discount Rate],((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100) as [Discount Amount], dbo.orderdetails.Tax as[Tax], (dbo.customerorderdescriptions.totalammount)- ((dbo.customerorderdescriptions.totalammount)/(1+(dbo.orderdetails.Tax/100))) as [Tax Amount], dbo.orderdetails.totalammount AS [Net Amount (Including Tax)] FROM dbo.CompnayDetails CROSS JOIN dbo.ItemDetails INNER JOIN dbo.customerorderdescriptions ON dbo.ItemDetails.ItemId = dbo.customerorderdescriptions.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId INNER JOIN dbo.orderdetails ON dbo.customerorderdescriptions.orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId   where date BETWEEN '" + dateTimePicker1.Value.Date + "' AND '" + dateTimePicker2.Value.Date + "'";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView1.DataSource = dt;
        }

       
    }
}
