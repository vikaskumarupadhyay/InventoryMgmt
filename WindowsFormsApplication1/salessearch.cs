﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ExcelLibrary.SpreadSheet;

namespace WindowsFormsApplication1
{
    public partial class salessearch : Form
    {
        Class2 s1 = new Class2();
        List<Class2> class2Collection = new List<Class2>();
        DB_Main d = new DB_Main();
        public salessearch()
        {
            InitializeComponent();
        }
        public void group(string name, string address, string contactno, string email, string openingbalance, string currentbalance, int top)
        {

            //System.Windows.Forms.GroupBox obj5 = new System.Windows.Forms.GroupBox();
            GroupBox s = new GroupBox();
            this.Controls.Add(s);
            s.Top = top;
            s.Width = 750;
            s.Height = 90;
            s.Left = 80;
            // System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
            TextBox t = new TextBox();
            t.Top = 10;
            t.Width = 700;
            t.Height = 40;
            t.Left = 20;
            t.BackColor = Color.Green;
            s.Controls.Add(t);
            t.Text = name;
            // System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
            Label t1 = new Label();
            this.Controls.Add(t1);
            t1.Top = 40;
            t1.Left = 30;
            t1.Text = "Address";
            s.Controls.Add(t1);

            // System.Windows.Forms.Label lbl1 = new System.Windows.Forms.Label();
            Label t2 = new Label();
            t2.Top = 40;
            t2.Left = 180;
            t2.Text = "ContactNo";
            s.Controls.Add(t2);
            //System.Windows.Forms.Label lbl2 = new System.Windows.Forms.Label();
            Label t3 = new Label();
            this.Controls.Add(t3);
            t3.Top = 40;
            t3.Left = 350;
            t3.Text = "Emailaddress";
            s.Controls.Add(t3);
            // System.Windows.Forms.Label lbl3 = new System.Windows.Forms.Label();
            Label t4 = new Label();
            this.Controls.Add(t4);
            t4.Top = 40;
            t4.Left = 500;
            t4.Text = "OpeningBalance";
            s.Controls.Add(t4);
            // System.Windows.Forms.Label lbl4 = new System.Windows.Forms.Label();
            Label t5 = new Label();
            this.Controls.Add(t5);
            t5.Top = 40;
            t5.Left = 650;
            t5.Text = "CurrentBalance";
            s.Controls.Add(t5);

            // System.Windows.Forms.Label lbl5 = new System.Windows.Forms.Label();
            Label t6 = new Label();
            this.Controls.Add(t6);
            t6.Top = 65;
            t6.Left = 30;
            s.Controls.Add(t6);
            t6.Text = address;

            // System.Windows.Forms.Label lbl6 = new System.Windows.Forms.Label();
            Label t7 = new Label();
            this.Controls.Add(t7);
            t7.Top = 65;
            t7.Left = 180;
            s.Controls.Add(t7);
            t7.Text = contactno;
            // System.Windows.Forms.Label lbl7 = new System.Windows.Forms.Label();
            Label t8 = new Label();
            this.Controls.Add(t8);
            t8.Top = 65;
            t8.Left = 350;
            s.Controls.Add(t8);
            t8.Text = email;
            // System.Windows.Forms.Label lbl8 = new System.Windows.Forms.Label();
            Label t9 = new Label();
            this.Controls.Add(t9);
            t9.Top = 65;
            t9.Left = 500;
            s.Controls.Add(t9);
            t9.Text = openingbalance;
            // System.Windows.Forms.Label lbl9 = new System.Windows.Forms.Label();
            Label t10 = new Label();
            this.Controls.Add(t10);
            t10.Top = 65;
            t10.Left = 650;
            s.Controls.Add(t10);
            t10.Text = currentbalance;
            // System.Windows.Forms.Label lbl10 = new System.Windows.Forms.Label();
            Label t11 = new Label();
            this.Controls.Add(t11);
            t11.Top = 65;
            t11.Left = 600;
            s.Controls.Add(t11);


            // obj.Width = 750;
            // obj5.Text = "Current balance";


        }
        public double getTotalAmounts()
        {
            double totalValue = 0.0;
            double s;
            for (int a = 0; a < dataGridView1.Rows.Count; a++)
            {
                s = Convert.ToDouble(dataGridView1.Rows[a].Cells[14].Value);
                totalValue = totalValue + s;

            }
            return totalValue;
        }
        public double getqtybuiled()
        {
            double totalValue = 0.0;
            double s;
            for (int a = 0; a < dataGridView1.Rows.Count; a++)
            {
                s = Convert.ToDouble(dataGridView1.Rows[a].Cells[13].Value);
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
                s = Convert.ToDouble(dataGridView1.Rows[a].Cells[16].Value);
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
                s = Convert.ToDouble(dataGridView1.Rows[a].Cells[22].Value);
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
                s = Convert.ToDouble(dataGridView1.Rows[a].Cells[17].Value);
                totalValue = totalValue + s;

            }
            return totalValue;
        }
        private void salessearch_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            dataGridView1.AllowUserToAddRows = true;
            string select = "select DeliveryDate from salesOrderDelivery where Delivaryid='"+1+"'";
            DataTable dt2 = d.getDetailByQuery(select);
            string num = "";
            foreach(DataRow dr in dt2.Rows)
            {
                num = dr[0].ToString();
            }
            dateTimePicker1.Text = num;

            button2.Enabled = false;
            // int j = 5;
            //int h = 0;
            //string name = "";
            //string Address = "";
            //string Contactno = "";
            //string Email = "";
            //string openingbalance = "";
            //string currentbalance = "";
            //for (int a = 0; a < class2Collection.Count; a++)
            //{

            //    s1 = class2Collection[a];
            //    name = s1.name;
            //    Address = s1.address;
            //    Contactno = s1.mobileno;
            //    Email = s1.Emailaddress;
            //    openingbalance = s1.openingbalance;
            //    currentbalance = s1.currentbalance;
            //    h = 20 * a * j;
            //    group(name, Address, Contactno, Email, openingbalance, currentbalance, h);
            //}
            //select od.orderid,od.custid,itd.ItemName,cod.quantity,cod.totalammount,od.date,sod.DeliveryDate,si.invoicedate from orderdetails  od  join customerorderdescriptions cod on od.orderid=cod.orderid join salesOrderDelivery sod on cod.orderid=sod.orderid join salesinvoice si on sod.orderid=si.orderid join ItemDetails itd on cod.ItemId=itd.ItemId
            //string selectquery = "SELECT dbo.salesOrderDelivery.Delivaryid as [Invoice ID],dbo.salesOrderDelivery.RefNo as [Order Ref. NO], dbo.CustomerDetails.custId as[Customer ID], dbo.CustomerDetails.CustName as[Customer Name], dbo.CustomerDetails.CustCompName as[Compnay Name],dbo.salesOrderDelivery.DeliveryDate as [Invoice Date], dbo.customerorderdescriptions.ItemId as [Item ID],dbo.ItemDetails.ItemName as [Item Name],dbo.ItemDetails.ItemCompName as[Itme Compnay Name],cast(dbo.ItemPriceDetail.MrpPrice as numeric(38,2)) as[MRP],cast(dbo.customerorderdescriptions.price as numeric(38,2)) as[Selling Rate],dbo.customerorderdescriptions.quantity as [Quantity Billed],cast(dbo.customerorderdescriptions.totalammount as numeric(38,2)) as[Gross Amount], dbo.orderdetails.Discount as[Discount Rate],cast((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100 as numeric(38,2)) as [Discount Amount], dbo.orderdetails.Tax as[Tax], cast((dbo.customerorderdescriptions.totalammount)- ((dbo.customerorderdescriptions.totalammount)/(1+(dbo.orderdetails.Tax/100)))as numeric(38,2)) as [Tax Amount], cast((dbo.customerorderdescriptions.totalammount)-((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100)as numeric(38,2)) AS [Net Amount (Including Tax)],payment.TotalAmount as[Total Amount],payment.BalanceAmount as[Balance Amount],(case when payment.BalanceAmount>0 then 'Delivered' else 'Fully settled' end) as [Delivery Status] FROM  dbo.salesOrderDelivery INNER JOIN dbo.orderdetails ON dbo.salesOrderDelivery.Orderid = dbo.orderdetails.orderid Inner JOIN SalesPaymentDetailes payment on payment.Invoiceid= dbo.salesOrderDelivery.Delivaryid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId INNER JOIN dbo.customerorderdescriptions ON dbo.orderdetails.orderid = dbo.customerorderdescriptions.Orderid INNER JOIN dbo.ItemDetails ON dbo.customerorderdescriptions.ItemId = dbo.ItemDetails.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId ORDER BY Delivaryid ASC";
            string selectquery = "SELECT dbo.salesOrderDelivery.Delivaryid as [Sales Invoice ID],dbo.salesOrderDelivery.RefNo as [S.O. Reference No.],dbo.salesOrderDelivery.DeliveryDate as [Invoice Date], dbo.CustomerDetails.custId as[Customer ID], dbo.CustomerDetails.CustName as[Customer Name], dbo.CustomerDetails.CustCompName as[Compnay Name],dbo.CustomerDetails.CustAddress as [Address],dbo.customerorderdescriptions.ItemId as [Item ID],dbo.ItemDetails.ItemName as [Item Name],dbo.ItemDetails.ItemCompName as[Itme Compnay Name],itd.HSN,cast(dbo.ItemPriceDetail.MrpPrice as numeric(38, 2)) as[MRP],cast(dbo.customerorderdescriptions.price as numeric(38, 2)) as[Selling Rate],dbo.customerorderdescriptions.quantity as [Quantity Billed],cast(dbo.customerorderdescriptions.price *dbo.customerorderdescriptions.quantity as numeric(38,2))as[Gross Amount],itd.Discount as[Discount Rate (In %)],cast((dbo.customerorderdescriptions.price*itd.Discount)/100 as numeric(38,2)) as [Discount Amount],cast((((dbo.customerorderdescriptions.Price)* (dbo.customerorderdescriptions.Quantity))-(dbo.customerorderdescriptions.Price)* (dbo.customerorderdescriptions.Quantity)*(itd.Discount/100))as numeric(38,2)) as [Taxable Value],(case when DBo.CustomerDetails.CustState != (select top 1 State from DBO.CompnayDetails) then '0.0'else CGST end) as CGST,(case when DBo.CustomerDetails.CustState != (select top 1 State from DBO.CompnayDetails) then '0.0'else SGST end) as SGST,(case when DBo.CustomerDetails.CustState = (select top 1 State from DBO.CompnayDetails) then '0.0' else itd.IGST  end) as IGST, itd.CESS, cast((dbo.customerorderdescriptions.totalammount) - ((dbo.customerorderdescriptions.totalammount * dbo.orderdetails.Discount) / 100) as numeric(38, 2)) AS[Net Amount (Including Tax)] ,p.InvoiceAmount as [Invoice Amount] ,p.[Paid Amount] ,p.Balance as [Balance Amount],(case when p.Balance > 0 then 'Delivered' else 'Fully settled' end) as [Delivery Status] FROM dbo.salesOrderDelivery INNER JOIN dbo.orderdetails ON dbo.salesOrderDelivery.Orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId   INNER JOIN dbo.customerorderdescriptions ON dbo.orderdetails.orderid = dbo.customerorderdescriptions.Orderid  INNER JOIN dbo.ItemDetails ON dbo.customerorderdescriptions.ItemId = dbo.ItemDetails.ItemId  INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId Join ItemTaxDetail itd on dbo.ItemPriceDetail.ItemId=itd.ItemId  left join  (select Invoiceid, MAX(InvoiceAmount) as InvoiceAmount, (MAX(InvoiceAmount) - sum(TotalAmount)) as Balance, sum(TotalAmount) as [Paid Amount] from SalesPaymentDetailes  join salesOrderDelivery on SalesPaymentDetailes.Invoiceid = salesOrderDelivery.Delivaryid  group by Invoiceid) p on salesOrderDelivery.Delivaryid = p.Invoiceid  ORDER BY Delivaryid ASC";
            //string actualcolumn = "SELECT top 1 dbo.salesOrderDelivery.Delivaryid,dbo.salesOrderDelivery.RefNo, dbo.CustomerDetails.custId , dbo.CustomerDetails.CustName , dbo.CustomerDetails.CustCompName,dbo.salesOrderDelivery.DeliveryDate, dbo.customerorderdescriptions.ItemId ,dbo.ItemDetails.ItemName,dbo.ItemDetails.ItemCompName ,cast(dbo.ItemPriceDetail.MrpPrice as numeric(38,2)),cast(dbo.customerorderdescriptions.price as numeric(38,2)),dbo.customerorderdescriptions.quantity,cast(dbo.customerorderdescriptions.totalammount as numeric(38,2)), dbo.orderdetails.Discount,cast((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100 as numeric(38,2)), dbo.orderdetails.Tax, cast((dbo.customerorderdescriptions.totalammount)- ((dbo.customerorderdescriptions.totalammount)/(1+(dbo.orderdetails.Tax/100)))as numeric(38,2)), cast((dbo.customerorderdescriptions.totalammount)-((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100)as numeric(38,2)) ,payment.TotalAmount,payment.BalanceAmount,(case when payment.BalanceAmount>0 then 'Delivered' else 'Fully settled' end)FROM  dbo.salesOrderDelivery INNER JOIN dbo.orderdetails ON dbo.salesOrderDelivery.Orderid = dbo.orderdetails.orderid Inner JOIN SalesPaymentDetailes payment on payment.Invoiceid= dbo.salesOrderDelivery.Delivaryid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId INNER JOIN dbo.customerorderdescriptions ON dbo.orderdetails.orderid = dbo.customerorderdescriptions.Orderid INNER JOIN dbo.ItemDetails ON dbo.customerorderdescriptions.ItemId = dbo.ItemDetails.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId ";
            string actualcolumn = "SELECT top 1 dbo.salesOrderDelivery.Delivaryid,dbo.salesOrderDelivery.RefNo,dbo.salesOrderDelivery.DeliveryDate, dbo.CustomerDetails.custId, dbo.CustomerDetails.CustName , dbo.CustomerDetails.CustCompName,dbo.CustomerDetails.CustAddress,dbo.customerorderdescriptions.ItemId,dbo.ItemDetails.ItemName,dbo.ItemDetails.ItemCompName ,itd.HSN,cast(dbo.ItemPriceDetail.MrpPrice as numeric(38, 2)),cast(dbo.customerorderdescriptions.price as numeric(38, 2)),dbo.customerorderdescriptions.quantity,cast(dbo.customerorderdescriptions.price *dbo.customerorderdescriptions.quantity as numeric(38,2)),itd.Discount,cast((dbo.customerorderdescriptions.price*itd.Discount)/100 as numeric(38,2)),cast((((dbo.customerorderdescriptions.Price)* (dbo.customerorderdescriptions.Quantity))-(dbo.customerorderdescriptions.Price)* (dbo.customerorderdescriptions.Quantity)*(itd.Discount/100))as numeric(38,2)),(case when DBo.CustomerDetails.CustState != (select top 1 State from DBO.CompnayDetails) then '0.0'else CGST end),(case when DBo.CustomerDetails.CustState != (select top 1 State from DBO.CompnayDetails) then '0.0'else SGST end),(case when DBo.CustomerDetails.CustState = (select top 1 State from DBO.CompnayDetails) then '0.0' else itd.IGST  end), itd.CESS, cast((dbo.customerorderdescriptions.totalammount) - ((dbo.customerorderdescriptions.totalammount * dbo.orderdetails.Discount) / 100) as numeric(38, 2)) ,p.InvoiceAmount ,p.[Paid Amount] ,p.Balance ,(case when p.Balance > 0 then 'Delivered' else 'Fully settled' end)FROM dbo.salesOrderDelivery INNER JOIN dbo.orderdetails ON dbo.salesOrderDelivery.Orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId   INNER JOIN dbo.customerorderdescriptions ON dbo.orderdetails.orderid = dbo.customerorderdescriptions.Orderid  INNER JOIN dbo.ItemDetails ON dbo.customerorderdescriptions.ItemId = dbo.ItemDetails.ItemId  INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId Join ItemTaxDetail itd on dbo.ItemPriceDetail.ItemId=itd.ItemId  left join  (select Invoiceid, MAX(InvoiceAmount) as InvoiceAmount, (MAX(InvoiceAmount) - sum(TotalAmount)) as Balance, sum(TotalAmount) as [Paid Amount] from SalesPaymentDetailes  join salesOrderDelivery on SalesPaymentDetailes.Invoiceid = salesOrderDelivery.Delivaryid  group by Invoiceid) p on salesOrderDelivery.Delivaryid = p.Invoiceid  ";
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


            comboBox1.DataSource = customDataTable;
            comboBox1.ValueMember = "ActualTableColumnName";
            comboBox1.DisplayMember = "AliasTableColumnName";
            dataGridView1.DataSource = dt;
            double s = getTotalAmounts();
            txtgrossamount.Text = s.ToString();
            double disa = getdiscountamount();
            txtdiscountamount.Text = disa.ToString();
            double taxa = gettaxamount();
            txttaxamount.Text = taxa.ToString();
            double witha = getwithauttaxamount();
            txtwithauttaxamoubnt.Text = witha.ToString();
            double qtybuiled = getqtybuiled();
            txtquantitybuiled.Text = qtybuiled.ToString();

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = comboBox1.SelectedValue.ToString();
            if (s == "Delivaryid")
            {
                s = "dbo.salesOrderDelivery." + s;
            }
            else if (s == "custId")
            {
                s = "dbo.CustomerDetails." + s;
            }
            else if (s == "DeliveryDate")
            {
                s = "dbo.salesOrderDelivery." + s;
            }
            else if (s == "ItemId")
            {
                s = "dbo.customerorderdescriptions." + s;
            }
            else if (s == "Column1")
            {
                s = "cast(dbo.ItemPriceDetail.MrpPrice as numeric(38,2))";
            }
            else if (s == "Column2")
            {
                s = "cast(dbo.customerorderdescriptions.price as numeric(38,2))";
            }
            else if (s == "Column3")
            {
                s = "cast(dbo.customerorderdescriptions.totalammount as numeric(38,2))";
            }
            else if (s == "Column4")
            {
                s = "cast((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100 as numeric(38,2))";
            }
            else if (s == "Column5")
            {
                s = "cast((((dbo.customerorderdescriptions.Price)* (dbo.customerorderdescriptions.Quantity))-(dbo.customerorderdescriptions.Price)* (dbo.customerorderdescriptions.Quantity)*(itd.Discount/100))as numeric(38,2))";
            }
           
            else if (s == "TotalAmount")
            {
                s = "p.InvoiceAmount";
            }
            else if (s == "Balance")
            {
                s = "p.Balance";
            }
            else if (s == "Paid Amount")
            {
                s = "p.[Paid Amount]";
            }
            else if (s == "Delivery Status")
            {
                s = "(case when p.Balance>0 then 'Delivered' else 'Fully settled' end)";
            }
            else if (s == "Column6")
            {
                s="(case when DBo.CustomerDetails.CustState != (select top 1 State from DBO.CompnayDetails) then '0.0'else CGST end)";
            }
            else if(s=="Column7")
            {
                s="(case when DBo.CustomerDetails.CustState != (select top 1 State from DBO.CompnayDetails) then '0.0'else SGST end)";
            }
             else if(s=="Column8")
            {
                 s=" (case when DBo.CustomerDetails.CustState = (select top 1 State from DBO.CompnayDetails) then '0.0' else itd.IGST  end)";
             }
            else if (s == "CESS")
            {
                s = "itd.CESS";
            }
            else if (s == "Column9")
            {
                s = "cast((dbo.customerorderdescriptions.totalammount) - ((dbo.customerorderdescriptions.totalammount * dbo.orderdetails.Discount) / 100) as numeric(38, 2))";
            }
            else if (s == "Column10")
            {
                s = "(case when p.Balance > 0 then 'Delivered' else 'Fully settled' end)";
            }
            //  s = "od.orderid";
            // string selectquery = "SELECT dbo.CustomerDetails.custId,dbo.CustomerDetails.CustName as[Customer Name], dbo.CustomerDetails.CustCompName as[Compnay Name],dbo.CustomerDetails.CustAddress as [Address], dbo.CustomerDetails.CustCity as[City], dbo.CustomerDetails.CustState as[State], dbo.CustomerDetails.CustZip as[Zip], dbo.CustomerDetails.CustCountry as [Country],dbo.CustomerDetails.CustEmail as[Email], dbo.CustomerDetails.CustWebAddress as[Web Address], dbo.CustomerDetails.CustPhone as[Phone], dbo.CustomerDetails.CustMobile as [Mobile],dbo.CustomerDetails.CustFax as [Fax], dbo.CustomerDetails.CustPanNo as [PAN NO], dbo.CustomerDetails.CustVatNo as [VAT NO], dbo.CustomerDetails.CustCstNo as [CST NO],dbo.CustomerDetails.CustServicetaxRegnNo as[Service Tax Regn NO], dbo.CustomerDetails.CustExciseRegnNo as [Exice Regn No], dbo.CustomerDetails.Gstregnno as[GST Regn No], dbo.customerorderdescriptions.ItemId as [Item Id],dbo.customerorderdescriptions.orderid as [Order Id], dbo.customerorderdescriptions.price as[Price], dbo.customerorderdescriptions.quantity as [Quantity], dbo.customerorderdescriptions.totalammount as[Totalamount], dbo.ItemDetails.ItemName as [Item Name], dbo.ItemPriceDetail.MrpPrice as[MRP Price], dbo.ItemPriceDetail.Margin as[Margin], dbo.orderdetails.totalammount AS Expr1, dbo.orderdetails.Discount as[Discount],dbo.orderdetails.Discountamount as[Discount Amount], dbo.orderdetails.Tax as[Tax], dbo.orderdetails.Taxamount as[Tax Amount], dbo.orderdetails.WithautTaxamount as[Withaut Tax amount], dbo.salesOrderDelivery.Delivaryid as [Delivary Id], dbo.salesOrderDelivery.DeliveryDate as [Delivary Date] FROM dbo.salesOrderDelivery INNER JOIN dbo.ItemDetails INNER JOIN dbo.customerorderdescriptions ON dbo.ItemDetails.ItemId = dbo.customerorderdescriptions.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId INNER JOIN dbo.orderdetails ON dbo.customerorderdescriptions.orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId ON dbo.salesOrderDelivery.Orderid = dbo.orderdetails.orderid CROSS JOIN dbo.CompnayDetails Where " + s + " like'" + textBox1.Text + "%' ";
            string selectquery = "SELECT dbo.salesOrderDelivery.Delivaryid as [Sales Invoice ID],dbo.salesOrderDelivery.RefNo as [S.O. Reference No.],dbo.salesOrderDelivery.DeliveryDate as [Invoice Date], dbo.CustomerDetails.custId as[Customer ID], dbo.CustomerDetails.CustName as[Customer Name], dbo.CustomerDetails.CustCompName as[Compnay Name],dbo.CustomerDetails.CustAddress as [Address],dbo.customerorderdescriptions.ItemId as [Item ID],dbo.ItemDetails.ItemName as [Item Name],dbo.ItemDetails.ItemCompName as[Itme Compnay Name],itd.HSN,cast(dbo.ItemPriceDetail.MrpPrice as numeric(38, 2)) as[MRP],cast(dbo.customerorderdescriptions.price as numeric(38, 2)) as[Selling Rate],dbo.customerorderdescriptions.quantity as [Quantity Billed],cast(dbo.customerorderdescriptions.price *dbo.customerorderdescriptions.quantity as numeric(38,2))as[Gross Amount],itd.Discount as[Discount Rate (In %)],cast((dbo.customerorderdescriptions.price*itd.Discount)/100 as numeric(38,2)) as [Discount Amount],cast((((dbo.customerorderdescriptions.Price)* (dbo.customerorderdescriptions.Quantity))-(dbo.customerorderdescriptions.Price)* (dbo.customerorderdescriptions.Quantity)*(itd.Discount/100))as numeric(38,2)) as [Taxable Value],(case when DBo.CustomerDetails.CustState != (select top 1 State from DBO.CompnayDetails) then '0.0'else CGST end) as CGST,(case when DBo.CustomerDetails.CustState != (select top 1 State from DBO.CompnayDetails) then '0.0'else SGST end) as SGST,(case when DBo.CustomerDetails.CustState = (select top 1 State from DBO.CompnayDetails) then '0.0' else itd.IGST  end) as IGST, itd.CESS, cast((dbo.customerorderdescriptions.totalammount) - ((dbo.customerorderdescriptions.totalammount * dbo.orderdetails.Discount) / 100) as numeric(38, 2)) AS[Net Amount (Including Tax)] ,p.InvoiceAmount as [Invoice Amount] ,p.[Paid Amount] ,p.Balance as [Balance Amount],(case when p.Balance > 0 then 'Delivered' else 'Fully settled' end) as [Delivery Status] FROM dbo.salesOrderDelivery INNER JOIN dbo.orderdetails ON dbo.salesOrderDelivery.Orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId   INNER JOIN dbo.customerorderdescriptions ON dbo.orderdetails.orderid = dbo.customerorderdescriptions.Orderid  INNER JOIN dbo.ItemDetails ON dbo.customerorderdescriptions.ItemId = dbo.ItemDetails.ItemId  INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId Join ItemTaxDetail itd on dbo.ItemPriceDetail.ItemId=itd.ItemId  left join  (select Invoiceid, MAX(InvoiceAmount) as InvoiceAmount, (MAX(InvoiceAmount) - sum(TotalAmount)) as Balance, sum(TotalAmount) as [Paid Amount] from SalesPaymentDetailes  join salesOrderDelivery on SalesPaymentDetailes.Invoiceid = salesOrderDelivery.Delivaryid  group by Invoiceid) p on salesOrderDelivery.Delivaryid = p.Invoiceid  Where " + s + " like'" + textBox1.Text + "%' and DeliveryDate BETWEEN '" + dateTimePicker1.Value.ToString() + "' AND '" + dateTimePicker2.Value.ToString() + "'";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView1.DataSource = dt;
            double s1 = getTotalAmounts();
            txtgrossamount.Text = s1.ToString();
            double disa = getdiscountamount();
            txtdiscountamount.Text = disa.ToString();
            double taxa = gettaxamount();
            txttaxamount.Text = taxa.ToString();
            double witha = getwithauttaxamount();
            txtwithauttaxamoubnt.Text = witha.ToString();
            double qtybuiled = getqtybuiled();
            txtquantitybuiled.Text = qtybuiled.ToString();
            //}
            //else if (s == "custid")
            //{
            //    s = "od.custid";
            //    string selectquery = " select od.orderid,od.custid,itd.ItemName,cod.quantity,cod.totalammount,od.date,sod.DeliveryDate,si.invoicedate from orderdetails  od  join customerorderdescriptions cod on od.orderid=cod.orderid join salesOrderDelivery sod on cod.orderid=sod.orderid join salesinvoice si on sod.orderid=si.orderid join ItemDetails itd on cod.ItemId=itd.ItemId Where " + s + " like'" + textBox1.Text + "%' ";
            //    DataTable dt = d.getDetailByQuery(selectquery);
            //    dataGridView1.DataSource = dt;
            //}
            //else if (s == "ItemName")
            //{
            //    s = "itd.ItemName";
            //    string selectquery = " select od.orderid,od.custid,itd.ItemName,cod.quantity,cod.totalammount,od.date,sod.DeliveryDate,si.invoicedate from orderdetails  od  join customerorderdescriptions cod on od.orderid=cod.orderid join salesOrderDelivery sod on cod.orderid=sod.orderid join salesinvoice si on sod.orderid=si.orderid join ItemDetails itd on cod.ItemId=itd.ItemId Where " + s + " like'" + textBox1.Text + "%' ";
            //    DataTable dt = d.getDetailByQuery(selectquery);
            //    dataGridView1.DataSource = dt;
            //}
            //else if (s == "totalammount")
            //{
            //    s = "cod.totalammount";
            //    string selectquery = " select od.orderid,od.custid,itd.ItemName,cod.quantity,cod.totalammount,od.date,sod.DeliveryDate,si.invoicedate from orderdetails  od  join customerorderdescriptions cod on od.orderid=cod.orderid join salesOrderDelivery sod on cod.orderid=sod.orderid join salesinvoice si on sod.orderid=si.orderid join ItemDetails itd on cod.ItemId=itd.ItemId Where " + s + " like'" + textBox1.Text + "%' ";
            //    DataTable dt = d.getDetailByQuery(selectquery);
            //    dataGridView1.DataSource = dt;
            //}
            //else if (s == "DeliveryDate")
            //{
            //    s = "sod.DeliveryDate";
            //    string selectquery = " select od.orderid,od.custid,itd.ItemName,cod.quantity,cod.totalammount,od.date,sod.DeliveryDate,si.invoicedate from orderdetails  od  join customerorderdescriptions cod on od.orderid=cod.orderid join salesOrderDelivery sod on cod.orderid=sod.orderid join salesinvoice si on sod.orderid=si.orderid join ItemDetails itd on cod.ItemId=itd.ItemId Where " + s + " ='" + textBox1.Text + "' ";
            //    DataTable dt = d.getDetailByQuery(selectquery);
            //    dataGridView1.DataSource = dt;
            //}
            //else if (s == "date")
            //{
            //    s = "od.date";
            //    string selectquery = " select od.orderid,od.custid,itd.ItemName,cod.quantity,cod.totalammount,od.date,sod.DeliveryDate,si.invoicedate from orderdetails  od  join customerorderdescriptions cod on od.orderid=cod.orderid join salesOrderDelivery sod on cod.orderid=sod.orderid join salesinvoice si on sod.orderid=si.orderid join ItemDetails itd on cod.ItemId=itd.ItemId Where " + s + " ='" + textBox1.Text + "' ";
            //    DataTable dt = d.getDetailByQuery(selectquery);
            //    dataGridView1.DataSource = dt;
            //}
            //else if(s=="invoicedate")
            //{
            //    s="si.invoicedate";
            //    string selectquery = " select od.orderid,od.custid,itd.ItemName,cod.quantity,cod.totalammount,od.date,sod.DeliveryDate,si.invoicedate from orderdetails  od  join customerorderdescriptions cod on od.orderid=cod.orderid join salesOrderDelivery sod on cod.orderid=sod.orderid join salesinvoice si on sod.orderid=si.orderid join ItemDetails itd on cod.ItemId=itd.ItemId Where " + s + " ='" + textBox1.Text + "' ";
            //    DataTable dt = d.getDetailByQuery(selectquery);
            //    dataGridView1.DataSource = dt;
            //}

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRowCollection rowcollection = dataGridView1.Rows;
            List<Class2> class2Collection = new List<Class2>();

            for (int a = 0; a < rowcollection.Count; a++)
            {
                DataGridViewRow currentrow = rowcollection[a];
                DataGridViewCellCollection cellcollecton = currentrow.Cells;

                Class2 gridViewClassObject = new Class2();

                gridViewClassObject.name = cellcollecton[2].Value.ToString();
                gridViewClassObject.address = cellcollecton[3].Value.ToString();
                gridViewClassObject.mobileno = cellcollecton[4].Value.ToString();
                gridViewClassObject.Emailaddress = cellcollecton[5].Value.ToString();
                gridViewClassObject.openingbalance = cellcollecton[6].Value.ToString();
                gridViewClassObject.currentbalance = cellcollecton[7].Value.ToString();
                class2Collection.Add(gridViewClassObject);

            }
            customerprint p = new customerprint(class2Collection);
            p.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            /*string s = comboBox1.SelectedValue.ToString();
            string selectQurry = "SELECT dbo.CustomerDetails.custId, dbo.CustomerDetails.CustName as[Customer Name], dbo.CustomerDetails.CustCompName as[Compnay Name],dbo.CustomerDetails.CustAddress as [Address], dbo.CustomerDetails.CustCity as[City], dbo.CustomerDetails.CustState as[State], dbo.CustomerDetails.CustZip as[Zip], dbo.CustomerDetails.CustCountry as [Country],dbo.CustomerDetails.CustEmail as[Email], dbo.CustomerDetails.CustWebAddress as[Web Address], dbo.CustomerDetails.CustPhone as[Phone], dbo.CustomerDetails.CustMobile as [Mobile],dbo.CustomerDetails.CustFax as [Fax], dbo.CustomerDetails.CustPanNo as [PAN NO], dbo.CustomerDetails.CustVatNo as [VAT NO], dbo.CustomerDetails.CustCstNo as [CST NO],dbo.CustomerDetails.CustServicetaxRegnNo as[Service Tax Regn NO], dbo.CustomerDetails.CustExciseRegnNo as [Exice Regn No], dbo.CustomerDetails.Gstregnno as[GST Regn No], dbo.customerorderdescriptions.ItemId as [Item Id],dbo.customerorderdescriptions.orderid as [Order Id], dbo.customerorderdescriptions.price as[Price], dbo.customerorderdescriptions.quantity as [Quantity], dbo.customerorderdescriptions.totalammount as[Totalamount], dbo.ItemDetails.ItemName as [Item Name], dbo.ItemPriceDetail.MrpPrice as[MRP Price], dbo.ItemPriceDetail.Margin as[Margin], dbo.orderdetails.totalammount AS Expr1, dbo.orderdetails.Discount as[Discount],dbo.orderdetails.Discountamount as[Discount Amount], dbo.orderdetails.Tax as[Tax], dbo.orderdetails.Taxamount as[Tax Amount], dbo.orderdetails.WithautTaxamount as[Withaut Tax amount], dbo.salesOrderDelivery.Delivaryid as [Delivary Id], dbo.salesOrderDelivery.DeliveryDate as [Delivary Date] FROM dbo.salesOrderDelivery INNER JOIN dbo.ItemDetails INNER JOIN dbo.customerorderdescriptions ON dbo.ItemDetails.ItemId = dbo.customerorderdescriptions.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId INNER JOIN dbo.orderdetails ON dbo.customerorderdescriptions.orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId ON dbo.salesOrderDelivery.Orderid = dbo.orderdetails.orderid CROSS JOIN dbo.CompnayDetails where DeliveryDate BETWEEN '" + dateTimePicker1.Value.Date + "' AND '" + dateTimePicker2.Value.Date + "'";
            //"select od.Orderid,od.venderId,itd.ItemName,vod.Quantity,vod.TotalPrice,od.OrderDate,cod.DeliveryDate,coi.InvoiceDate from VendorOrderDetails od join VendorOrderDesc vod on vod.Orderid=od.Orderid join CustomerOrderDelivery cod on cod.Orderid=vod.Orderid join CustomerOrderInvoice coi on coi.Orderid=vod.Orderid join ItemDetails itd on itd.ItemId=vod.ItemId where " + a + "= '" + txtsearch.Text + "'";
            DataTable dt = d.getDetailByQuery(selectQurry);
            dataGridView1.DataSource = dt;*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.AllowUserToAddRows == true)
            {
                dataGridView1.AllowUserToAddRows = false;
            }
            string FileName = "";
            SaveFileDialog openFileDialog1 = new SaveFileDialog();
            //FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();
            openFileDialog1.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
            openFileDialog1.FileName = "Sales Details";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog1.FileName;

            }
            //DataGridViewColumnCollection column = dataGridView1.Columns;
            int cout = 0;
            int rowCoumt = 0;
            // column1 = dc.Name.ToString();
            string file = FileName;//+ ".xls"; //System.Configuration.ConfigurationManager.AppSettings["ExcelFilePath1"] + FolderName + "newdoc.xls";
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("First Sheet");

            foreach (DataGridViewColumn dc in dataGridView1.Columns)
            {

                worksheet.Cells[rowCoumt, cout] = new Cell(dc.Name);
                cout++;

            }

            //foreach (DataGridViewRow row in dataGridView1.Rows) { }
            DataGridViewRowCollection rowcollection = dataGridView1.Rows;

            int rowindex = 1;
            //int countindex = 0;
            for (int a = 0; a < rowcollection.Count; a++)
            {
                DataGridViewRow currentrow = rowcollection[a];
                DataGridViewCellCollection cellcollecton = currentrow.Cells;
                int countrow = 0;

                for (int b = 0; b < currentrow.Cells.Count; b++)
                {
                    worksheet.Cells[rowindex, countrow] = new Cell(currentrow.Cells[b].Value.ToString());
                    // countindex++;
                    countrow++;
                }
                // name = cellcollecton[0].Value.ToString() + " , " + cellcollecton[1].Value.ToString() + " , " + cellcollecton[2].Value.ToString() + " , " + cellcollecton[3].Value.ToString() + " , " + cellcollecton[4].Value.ToString() + " , " + cellcollecton[5].Value.ToString() + "  , " + cellcollecton[6].Value.ToString() + " , " + cellcollecton[7].Value.ToString() + " , " + cellcollecton[8].Value.ToString() + " , " + cellcollecton[9].Value.ToString() + " , " + cellcollecton[10].Value.ToString() + " , " + cellcollecton[11].Value.ToString() + " , " + cellcollecton[12].Value.ToString() + ", " + cellcollecton[13].Value.ToString() + " , " + cellcollecton[14].Value.ToString() + " , " + cellcollecton[15].Value.ToString();
                rowindex++;
            }
            workbook.Worksheets.Add(worksheet);
            workbook.Save(file);
            dataGridView1.AllowUserToAddRows = true;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                double d = 0;
                Double.TryParse(dataGridView1.Rows[i].Cells[21].Value.ToString(), out d);
                sum += d;
            }

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(dateTimePicker2.Text);
            if (date > DateTime.Now.Date)
            {
                MessageBox.Show("plese select your correct date");
                dateTimePicker2.Text = DateTime.Now.ToString();
            }
            string s = comboBox1.SelectedValue.ToString();

            //string selectquery = "SELECT dbo.CustomerDetails.custId as[Customer ID], dbo.CustomerDetails.CustName as[Customer Name], dbo.CustomerDetails.CustCompName as[Compnay Name],dbo.CustomerDetails.CustAddress as [Address], dbo.CustomerDetails.CustCity as[City], dbo.CustomerDetails.CustState as[State], dbo.CustomerDetails.CustZip as[Zip], dbo.CustomerDetails.CustCountry as [Country],dbo.CustomerDetails.CustEmail as[Email], dbo.CustomerDetails.CustWebAddress as[Web Address], dbo.CustomerDetails.CustPhone as[Phone], dbo.CustomerDetails.CustMobile as [Mobile],dbo.salesOrderDelivery.Delivaryid as [Invoice ID], dbo.salesOrderDelivery.DeliveryDate as [Invoice Date],dbo.salesOrderDelivery.RefNo as [Order Ref. NO], dbo.customerorderdescriptions.ItemId as [Item ID],dbo.ItemDetails.ItemName as [Item Name],dbo.ItemDetails.ItemCompName as[Itme Compnay Name],dbo.ItemPriceDetail.MrpPrice as[MRP], dbo.customerorderdescriptions.price as[Selling Rate],dbo.customerorderdescriptions.quantity as [Quantity Billed],dbo.customerorderdescriptions.totalammount as[Gross Amount], dbo.orderdetails.Discount as[Discount Rate],((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100) as [Discount Amount], dbo.orderdetails.totalammount AS [Net Amount], dbo.orderdetails.Tax as[Tax], (dbo.customerorderdescriptions.totalammount)- ((dbo.customerorderdescriptions.totalammount)/(1+(dbo.orderdetails.Tax/100))) as [Tax Amount] FROM dbo.salesOrderDelivery INNER JOIN dbo.ItemDetails INNER JOIN dbo.customerorderdescriptions ON dbo.ItemDetails.ItemId = dbo.customerorderdescriptions.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId INNER JOIN dbo.orderdetails ON dbo.customerorderdescriptions.orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId ON dbo.salesOrderDelivery.Orderid = dbo.orderdetails.orderid CROSS JOIN dbo.CompnayDetails Where DeliveryDate BETWEEN '" + dateTimePicker1.Value.Date + "' AND '" + dateTimePicker2.Value.Date + "'";
            //DataTable dt = d.getDetailByQuery(selectquery);
            //dataGridView1.DataSource = dt;
            //double s1 = getTotalAmounts();
            //txtgrossamount.Text = s1.ToString();
            //double disa = getdiscountamount();
            //txtdiscountamount.Text = disa.ToString();
            //double taxa = gettaxamount();
            //txttaxamount.Text = taxa.ToString();
            //double witha = getwithauttaxamount();
            //txtwithauttaxamoubnt.Text = witha.ToString();

            string selectquery = "SELECT dbo.salesOrderDelivery.Delivaryid as [Sales Invoice ID],dbo.salesOrderDelivery.RefNo as [S.O. Reference No.],dbo.salesOrderDelivery.DeliveryDate as [Invoice Date], dbo.CustomerDetails.custId as[Customer ID], dbo.CustomerDetails.CustName as[Customer Name], dbo.CustomerDetails.CustCompName as[Compnay Name],dbo.CustomerDetails.CustAddress as [Address],dbo.customerorderdescriptions.ItemId as [Item ID],dbo.ItemDetails.ItemName as [Item Name],dbo.ItemDetails.ItemCompName as[Itme Compnay Name],itd.HSN,cast(dbo.ItemPriceDetail.MrpPrice as numeric(38, 2)) as[MRP],cast(dbo.customerorderdescriptions.price as numeric(38, 2)) as[Selling Rate],dbo.customerorderdescriptions.quantity as [Quantity Billed],cast(dbo.customerorderdescriptions.price *dbo.customerorderdescriptions.quantity as numeric(38,2))as[Gross Amount],itd.Discount as[Discount Rate (In %)],cast((dbo.customerorderdescriptions.price*itd.Discount)/100 as numeric(38,2)) as [Discount Amount],cast((((dbo.customerorderdescriptions.Price)* (dbo.customerorderdescriptions.Quantity))-(dbo.customerorderdescriptions.Price)* (dbo.customerorderdescriptions.Quantity)*(itd.Discount/100))as numeric(38,2)) as [Taxable Value],(case when DBo.CustomerDetails.CustState != (select top 1 State from DBO.CompnayDetails) then '0.0'else CGST end) as CGST,(case when DBo.CustomerDetails.CustState != (select top 1 State from DBO.CompnayDetails) then '0.0'else SGST end) as SGST,(case when DBo.CustomerDetails.CustState = (select top 1 State from DBO.CompnayDetails) then '0.0' else itd.IGST  end) as IGST, itd.CESS, cast((dbo.customerorderdescriptions.totalammount) - ((dbo.customerorderdescriptions.totalammount * dbo.orderdetails.Discount) / 100) as numeric(38, 2)) AS[Net Amount (Including Tax)] ,p.InvoiceAmount as [Invoice Amount] ,p.[Paid Amount] ,p.Balance as [Balance Amount],(case when p.Balance > 0 then 'Delivered' else 'Fully settled' end) as [Delivery Status] FROM dbo.salesOrderDelivery INNER JOIN dbo.orderdetails ON dbo.salesOrderDelivery.Orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId   INNER JOIN dbo.customerorderdescriptions ON dbo.orderdetails.orderid = dbo.customerorderdescriptions.Orderid  INNER JOIN dbo.ItemDetails ON dbo.customerorderdescriptions.ItemId = dbo.ItemDetails.ItemId  INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId Join ItemTaxDetail itd on dbo.ItemPriceDetail.ItemId=itd.ItemId  left join  (select Invoiceid, MAX(InvoiceAmount) as InvoiceAmount, (MAX(InvoiceAmount) - sum(TotalAmount)) as Balance, sum(TotalAmount) as [Paid Amount] from SalesPaymentDetailes  join salesOrderDelivery on SalesPaymentDetailes.Invoiceid = salesOrderDelivery.Delivaryid  group by Invoiceid) p on salesOrderDelivery.Delivaryid = p.Invoiceid where DeliveryDate BETWEEN '" + dateTimePicker1.Value.Date + "' AND '" + dateTimePicker2.Value.Date + "'";
            //"select od.Orderid,od.venderId,itd.ItemName,vod.Quantity,vod.TotalPrice,od.OrderDate,cod.DeliveryDate,coi.InvoiceDate from VendorOrderDetails od join VendorOrderDesc vod on vod.Orderid=od.Orderid join CustomerOrderDelivery cod on cod.Orderid=vod.Orderid join CustomerOrderInvoice coi on coi.Orderid=vod.Orderid join ItemDetails itd on itd.ItemId=vod.ItemId where " + a + "= '" + txtsearch.Text + "'";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(dateTimePicker1.Text);
            if (date > DateTime.Now.Date)
            {
                MessageBox.Show("plese select your correct date");
                dateTimePicker1.Text = DateTime.Now.ToString();
            }
            //string s = comboBox1.SelectedValue.ToString();

            //string selectquery = "SELECT dbo.CustomerDetails.custId as[Customer ID], dbo.CustomerDetails.CustName as[Customer Name], dbo.CustomerDetails.CustCompName as[Compnay Name],dbo.CustomerDetails.CustAddress as [Address], dbo.CustomerDetails.CustCity as[City], dbo.CustomerDetails.CustState as[State], dbo.CustomerDetails.CustZip as[Zip], dbo.CustomerDetails.CustCountry as [Country],dbo.CustomerDetails.CustEmail as[Email], dbo.CustomerDetails.CustWebAddress as[Web Address], dbo.CustomerDetails.CustPhone as[Phone], dbo.CustomerDetails.CustMobile as [Mobile],dbo.salesOrderDelivery.Delivaryid as [Invoice ID], dbo.salesOrderDelivery.DeliveryDate as [Invoice Date],dbo.salesOrderDelivery.RefNo as [Order Ref. NO], dbo.customerorderdescriptions.ItemId as [Item ID],dbo.ItemDetails.ItemName as [Item Name],dbo.ItemDetails.ItemCompName as[Itme Compnay Name],dbo.ItemPriceDetail.MrpPrice as[MRP], dbo.customerorderdescriptions.price as[Selling Rate],dbo.customerorderdescriptions.quantity as [Quantity Billed],dbo.customerorderdescriptions.totalammount as[Gross Amount], dbo.orderdetails.Discount as[Discount Rate],((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100) as [Discount Amount], dbo.orderdetails.totalammount AS [Net Amount], dbo.orderdetails.Tax as[Tax], (dbo.customerorderdescriptions.totalammount)- ((dbo.customerorderdescriptions.totalammount)/(1+(dbo.orderdetails.Tax/100))) as [Tax Amount] FROM dbo.salesOrderDelivery INNER JOIN dbo.ItemDetails INNER JOIN dbo.customerorderdescriptions ON dbo.ItemDetails.ItemId = dbo.customerorderdescriptions.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId INNER JOIN dbo.orderdetails ON dbo.customerorderdescriptions.orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId ON dbo.salesOrderDelivery.Orderid = dbo.orderdetails.orderid CROSS JOIN dbo.CompnayDetails Where DeliveryDate BETWEEN '" + dateTimePicker1.Value.Date + "' AND '" + dateTimePicker2.Value.Date + "'";
            //DataTable dt = d.getDetailByQuery(selectquery);


            string selectquery = "SELECT dbo.salesOrderDelivery.Delivaryid as [Sales Invoice ID],dbo.salesOrderDelivery.RefNo as [S.O. Reference No.],dbo.salesOrderDelivery.DeliveryDate as [Invoice Date], dbo.CustomerDetails.custId as[Customer ID], dbo.CustomerDetails.CustName as[Customer Name], dbo.CustomerDetails.CustCompName as[Compnay Name],dbo.CustomerDetails.CustAddress as [Address],dbo.customerorderdescriptions.ItemId as [Item ID],dbo.ItemDetails.ItemName as [Item Name],dbo.ItemDetails.ItemCompName as[Itme Compnay Name],itd.HSN,cast(dbo.ItemPriceDetail.MrpPrice as numeric(38, 2)) as[MRP],cast(dbo.customerorderdescriptions.price as numeric(38, 2)) as[Selling Rate],dbo.customerorderdescriptions.quantity as [Quantity Billed],cast(dbo.customerorderdescriptions.price *dbo.customerorderdescriptions.quantity as numeric(38,2))as[Gross Amount],itd.Discount as[Discount Rate (In %)],cast((dbo.customerorderdescriptions.price*itd.Discount)/100 as numeric(38,2)) as [Discount Amount],cast((((dbo.customerorderdescriptions.Price)* (dbo.customerorderdescriptions.Quantity))-(dbo.customerorderdescriptions.Price)* (dbo.customerorderdescriptions.Quantity)*(itd.Discount/100))as numeric(38,2)) as [Taxable Value],(case when DBo.CustomerDetails.CustState != (select top 1 State from DBO.CompnayDetails) then '0.0'else CGST end) as CGST,(case when DBo.CustomerDetails.CustState != (select top 1 State from DBO.CompnayDetails) then '0.0'else SGST end) as SGST,(case when DBo.CustomerDetails.CustState = (select top 1 State from DBO.CompnayDetails) then '0.0' else itd.IGST  end) as IGST, itd.CESS, cast((dbo.customerorderdescriptions.totalammount) - ((dbo.customerorderdescriptions.totalammount * dbo.orderdetails.Discount) / 100) as numeric(38, 2)) AS[Net Amount (Including Tax)] ,p.InvoiceAmount as [Invoice Amount] ,p.[Paid Amount] ,p.Balance as [Balance Amount],(case when p.Balance > 0 then 'Delivered' else 'Fully settled' end) as [Delivery Status] FROM dbo.salesOrderDelivery INNER JOIN dbo.orderdetails ON dbo.salesOrderDelivery.Orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId   INNER JOIN dbo.customerorderdescriptions ON dbo.orderdetails.orderid = dbo.customerorderdescriptions.Orderid  INNER JOIN dbo.ItemDetails ON dbo.customerorderdescriptions.ItemId = dbo.ItemDetails.ItemId  INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId Join ItemTaxDetail itd on dbo.ItemPriceDetail.ItemId=itd.ItemId  left join  (select Invoiceid, MAX(InvoiceAmount) as InvoiceAmount, (MAX(InvoiceAmount) - sum(TotalAmount)) as Balance, sum(TotalAmount) as [Paid Amount] from SalesPaymentDetailes  join salesOrderDelivery on SalesPaymentDetailes.Invoiceid = salesOrderDelivery.Delivaryid  group by Invoiceid) p on salesOrderDelivery.Delivaryid = p.Invoiceid  where DeliveryDate BETWEEN '" + dateTimePicker1.Value.Date + "' AND '" + dateTimePicker2.Value.Date + "'";
            //"select od.Orderid,od.venderId,itd.ItemName,vod.Quantity,vod.TotalPrice,od.OrderDate,cod.DeliveryDate,coi.InvoiceDate from VendorOrderDetails od join VendorOrderDesc vod on vod.Orderid=od.Orderid join CustomerOrderDelivery cod on cod.Orderid=vod.Orderid join CustomerOrderInvoice coi on coi.Orderid=vod.Orderid join ItemDetails itd on itd.ItemId=vod.ItemId where " + a + "= '" + txtsearch.Text + "'";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView1.DataSource = dt;
            dataGridView1.DataSource = dt;
            double s1 = getTotalAmounts();
            txtgrossamount.Text = s1.ToString();
            double disa = getdiscountamount();
            txtdiscountamount.Text = disa.ToString();
            double taxa = gettaxamount();
            txttaxamount.Text = taxa.ToString();
            double witha = getwithauttaxamount();
            txtwithauttaxamoubnt.Text = witha.ToString();
            double qtybuiled = getqtybuiled();
            txtquantitybuiled.Text = qtybuiled.ToString();

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

     
    }
}