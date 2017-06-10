﻿using System;
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
       public string invoice;
        DB_Main d = new DB_Main();
        double amount = 0;
        DataTable customerdetails = new DataTable();
        DataTable addToCartTable = new DataTable();
        public string s;
        public Form5()
        {
            InitializeComponent();

        }
       public Form5(string invoiceid)
        {
            invoice = invoiceid;
            InitializeComponent();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            CmbCardType.SelectedIndex = 0;
            CmbCompany.SelectedIndex = 0;
            pnlSalesPayment.Visible = false;
            string selectqurry = "select salesOrderDelivery.Delivaryid as[Delivary Id],orderdetails.custid as [Customer Id], CustomerDetails.CustName as[Customer Name],CustomerDetails.CustCompName as[Company Name], CustomerDetails.CustAddress as[Address],salesOrderDelivery.DeliveryDate as[Delivery Date],(select Sum(customerorderdescriptions.quantity) from customerorderdescriptions where customerorderdescriptions.orderid= orderdetails.orderid) as[Bild Quanity],orderdetails.WithautTaxamount as[Gross Amount],orderdetails.Discount as[Discount Rate],orderdetails.Discountamount as[Dicount Amount],orderdetails.Tax as[Tax],orderdetails.Taxamount as[Tax Amount],orderdetails.totalammount as[Total Amount],pay.TotalAmount as[Paid Amount],pay.BalanceAmount as [Balance Amount] from orderdetails join CustomerDetails on CustomerDetails.custId=orderdetails.custid join salesOrderDelivery on orderdetails.Orderid=salesOrderDelivery.Orderid join SalesPaymentDetailes pay on salesOrderDelivery.Delivaryid=pay.Invoiceid";
            string selectqurryForActualColumnName = "select top 1 salesOrderDelivery.Delivaryid,orderdetails.custid, CustomerDetails.CustName,CustomerDetails.CustCompName, CustomerDetails.CustAddress,DeliveryDate,(select Sum(customerorderdescriptions.quantity) from customerorderdescriptions where customerorderdescriptions.orderid= orderdetails.orderid),orderdetails.WithautTaxamount,orderdetails.Discount,orderdetails.Discountamount,orderdetails.Tax,orderdetails.Taxamount,orderdetails.totalammount,pay.TotalAmount ,pay.BalanceAmount  from orderdetails join CustomerDetails on CustomerDetails.custId=orderdetails.custid join salesOrderDelivery on orderdetails.Orderid=salesOrderDelivery.Orderid join SalesPaymentDetailes pay on salesOrderDelivery.Delivaryid=pay.Invoiceid";
            DataTable dt = d.getDetailByQuery(selectqurry);
            DataTable dtOnlyColumnName = d.getDetailByQuery(selectqurryForActualColumnName);
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

            combsearch.DataSource = customDataTable;
            combsearch.ValueMember = "ActualTableColumnName";
            combsearch.DisplayMember = "AliasTableColumnName";
            dataGridView2.DataSource = dt;






            //string selectquery = "select  orderdetails.orderid as[Order Id],orderdetails.custid as [Customer Id], CustomerDetails.CustName as[Customer Name],CustomerDetails.CustCompName as[Company Name], CustomerDetails.CustAddress as[Address],orderdetails.date as[Order Date],(select Sum(customerorderdescriptions.quantity) from customerorderdescriptions where customerorderdescriptions.orderid= orderdetails.orderid) as[Bild Quanity],orderdetails.WithautTaxamount as[Gross Amount],orderdetails.Discount as[Discount Rate],orderdetails.Discountamount as[Dicount Amount],orderdetails.Tax as[Tax],orderdetails.Taxamount as[Tax Amount],orderdetails.totalammount as[Total Amount],pay.TotalAmount as[Paid Amount],pay.BalanceAmount as [Balance Amount] from orderdetails join CustomerDetails on CustomerDetails.custId=orderdetails.custid join salesOrderDelivery on orderdetails.Orderid=salesOrderDelivery.Orderid join SalesPaymentDetailes pay on salesOrderDelivery.Delivaryid=pay.Invoiceid";
            //DataTable dt = d.getDetailByQuery(selectquery);
            //List<string> sd = new List<string>();
            //DataColumnCollection d1 = dt.Columns;
            //for (int a = 1; a < d1.Count; a++)
            //{
            //    DataColumn dc = new DataColumn();
            //    string val = d1[a].ToString();
            //    sd.Add(val);
            //}
            //combsearch.DataSource = sd;
            //dataGridView2.DataSource = dt;
            
        //    txtpayammount.Text = "0";
        //    button1.Visible = false;
        //    Purchase.PurchaseDetails purchasedetailobj = new Purchase.PurchaseDetails();
        //    customerdetails = purchasedetailobj.GetcustomerdetailsInDataTable();
        //    panel2.Visible = false;
        //    txtcustomerid.Text = "C";
        //    txtRefNo.Text = invoice; 
        //    panel2.Visible = false;
        //    string select = " select Orderid from salesinvoice where invoiceid='" + invoice + "'";
        //    DataTable dt7 = d.getDetailByQuery(select);
        //    string invo = "";
        //    foreach (DataRow dr in dt7.Rows)
        //    {
        //        invo = dr[0].ToString();
        //    }
        //    string select1 = "select Custid from orderdetails where Orderid='" + invo+ "'";
        //    DataTable dt1 = d.getDetailByQuery(select1);
        //    string ordorid = "";
        //    foreach (DataRow dr in dt1.Rows)
        //    {
        //        ordorid = dr[0].ToString();
        //    }
        //    string select2=" Select Custid, CustName,CustCompName ,CustAddress ,CustPhone ,CustMobile ,CustFax   from CustomerDetails where Custid='"+ordorid+"'";
        //    DataTable dt2 = d.getDetailByQuery(select2);
        //    foreach (DataRow dr in dt2.Rows)
        //    {
        //        txtcustomerid.Text = dr[0].ToString();
        //        txtcustname.Text = dr[1].ToString();
        //        txtcustcompnayname.Text = dr[2].ToString();
        //        txtaddress.Text = dr[3].ToString();
        //        txtphone.Text = dr[4].ToString();
        //        txtmobile.Text = dr[5].ToString();
        //        txtfax.Text = dr[6].ToString();
        //    }
        //    int totel = 0;
        //    string select3 = "select vod.ItemId,ide.ItemName,vod.Price,vod.Quantity,vod.totalammount from customerorderdescriptions vod join ItemDetails ide on Vod.ItemId=ide.ItemId where vod.Orderid='" + invo + "'";
        //    DataTable dt4 = d.getDetailByQuery(select3);
        //    int totalRowCount = addToCartTable.Rows.Count;
        //    for (int rowCount = 0; rowCount < totalRowCount; rowCount++)
        //    {
        //        addToCartTable.Rows.RemoveAt(0);
        //    }

        //    for (int h = 0; h < dt4.Rows.Count; h++)
        //    {
        //        DataRow dr2 = dt4.Rows[h];
        //        string txtItemCode = dr2[0].ToString();
        //        string txtitemNmae = dr2[1].ToString();
        //        string txtRate = dr2[2].ToString();
        //        string txtQuanity = dr2[3].ToString();
        //        string txtAmoun = dr2[4].ToString();
               
        //        //totel = dr2[5].ToString();
        //        int amt = Convert.ToInt32(txtAmoun);
        //        totel = totel + amt;
        //    }
        //    dataGridView1.DataSource = dt4;
        //    txttotalammount.Text = totel.ToString();
        //    //string selectquery3 = "select totalammount from orderdetails where orderid='" + invo + "'";
        //    //DataTable dt8 = d.getDetailByQuery(selectquery3);
        //    //foreach (DataRow dr in dt8.Rows)
        //    //{
        //    //    txttotalammount.Text = dr[0].ToString();
        //    //}
        //    //dataGridView1.DataSource = dt4;

            string selectquery4 = "select id from SalesPaymentDetailes";
            DataTable dt3 = d.getDetailByQuery(selectquery4);
            string id = "";
            foreach (DataRow dr in dt3.Rows)
            {
                id = dr[0].ToString();
            }
            if (id == "")
            {
                id = "1";
                txtSrNo.Text = id;
            }
            else
            {
                int t = Convert.ToInt32(id);
                int t1 = t + 1;
                txtSrNo.Text = t1.ToString();
            }
        //    //txtcustomerid.Text = "C";

        //    //dtpdate.Value = DateTime.Now;
        //    //Purchase.PurchaseDetails purchasedetailobj = new Purchase.PurchaseDetails();
        //    //customerdetails = purchasedetailobj.GetcustomerdetailsInDataTable();
        //    //panel2.Visible = false;
        //}
      
        //private void setvalue()
        //{
        //    if (customerdetails.Rows.Count > 0)
        //    {
        //        string customerid = txtcustomerid.Text;
        //        if (customerid.Trim() != "" && customerid != null)
        //        {
        //            DataRow[] dr = customerdetails.Select("[custId]='" + customerid + "'");
        //            if (dr != null && dr.Length > 0)
        //            {
        //                string customername = dr[0]["Name"].ToString();
        //                string customeraddress = dr[0]["Address"].ToString();
        //                string customerCompName = dr[0]["COMPANYNAME"].ToString();
                       
                       
        //                string customerphone = dr[0]["Phone"].ToString();
        //                string customermobile = dr[0]["Mobile"].ToString();
        //                string customerfax = dr[0]["Fax"].ToString();
        //                txtcustname.Text = customername;
        //                txtaddress.Text = customeraddress;
        //                txtcustcompnayname.Text = customerCompName;
                       
                       
        //                txtphone.Text = customerphone;
        //                txtmobile.Text = customermobile;
        //                txtfax.Text = customerfax;
        //            }
        //            else
        //            {
        //                txtcustname.Text = "";
        //                txtcustcompnayname.Text = "";
        //                txtaddress.Text = "";
                       
        //                txtphone.Text = "";
        //                txtmobile.Text = "";
        //                txtfax.Text = "";
        //            }
        //        }
        //    }
        }
        public void salesedelivarytabindex()
        {
            CashAmount.Text = "0.00";
            txtCreditAmount.Text = "0.00";
            txtChequeAmount.Text = "0.00";
            txtEwalletAmount.Text = "0.00";
            txtCouponAmount.Text = "0.00";
            txtTotalAmount1.Text = "0.00";
            txtBalance.Text = "0.00";
            txtRturned.Text = "0.00";
            txtNetAmount.Text = "0.00";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            string selectquery1 = " Select c.custid,c.CustName as Name,c.CustCompName as CompnayName,c.CustAddress as Address,c.CustPhone as Phone,c.CustMobile as Mobile,c.CustFax  as Fax,ca.CustCurrentBalance from CustomerDetails c join CustomerAccountDetails ca on c.custid=ca.custid";
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
           // panel2.Visible = false;
            DataGridViewCellCollection cell = dataGridView2.Rows[e.RowIndex].Cells;
            if(!string.IsNullOrEmpty(cell[0].Value.ToString()))
            {
               
                setdetails(cell);
                string selectquery = " select pay.ReceiptDate as[Receipt Date],(select Sum(customerorderdescriptions.quantity) from customerorderdescriptions where customerorderdescriptions.orderid= orderdetails.orderid) as[Bild Quanity],orderdetails.WithautTaxamount as[Gross Amount],orderdetails.Discount as[Discount Rate],orderdetails.Discountamount as[Dicount Amount],orderdetails.Tax as[Tax],orderdetails.Taxamount as[Tax Amount],orderdetails.totalammount as[Total Amount],pay.TotalAmount as[Paid Amount],pay.BalanceAmount as [Balance Amount] from orderdetails join salesOrderDelivery on orderdetails.Orderid=salesOrderDelivery.Orderid join SalesPaymentDetailes pay on salesOrderDelivery.Delivaryid=pay.Invoiceid where salesOrderDelivery.Delivaryid='" + txtRefNo.Text + "' ";
                DataTable dt = d.getDetailByQuery(selectquery);
                string balance = "";
                foreach (DataRow dr in dt.Rows)
                {
                    balance = dr[9].ToString();
                }
                if (balance == "0.00")
                {
                    panel2.Visible = true;
                    MessageBox.Show("Fully paid");
                }
                else
                {
                    panel2.Visible = false;
                    dataGridView1.DataSource = dt;
                    double d2;
                    double d1 = 0;
                    DataGridViewRowCollection call = dataGridView1.Rows;
                    for (int c = 0; c < call.Count; c++)
                    {
                        DataGridViewRow currentRow1 = call[c];
                        DataGridViewCellCollection cellCollection1 = currentRow1.Cells;
                        d2 = Convert.ToDouble(cellCollection1[8].Value.ToString());
                        d1 = d1 + d2;
                    }
                    Double Amount1 = amount - d1;
                    txttotalammount.Text = Amount1.ToString("###0.00");
                }
            
            }
        }
        private void setdetails(DataGridViewCellCollection collection)
        {
            try
            {
                txtRefNo.Text = collection[0].Value.ToString();
                txtcustomerid.Text = collection[1].Value.ToString();
                txtcustname.Text = collection[2].Value.ToString();
                txtcustcompnayname.Text = collection[3].Value.ToString();
                txtaddress.Text = collection[4].Value.ToString();
               // txtphone.Text = collection[5].Value.ToString();
                //txtmobile.Text = collection[6].Value.ToString();
               // txtfax.Text = collection[7].Value.ToString();
                //txttotalammount.Text = collection[14].Value.ToString();
                amount = Convert.ToDouble(collection[12].Value.ToString());
            }
            catch (Exception ex)
            {

            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string s = combsearch.SelectedValue.ToString();
           // string m = "c" + s;
            if (s == "Column1")
            {
                s = "(select Sum(customerorderdescriptions.quantity) from customerorderdescriptions where customerorderdescriptions.orderid= orderdetails.orderid)";
            }
            else if (s == "orderid")
            {
                s = "orderdetails.orderid ";
            }
            else if (s == "custid")
            {
                s = "orderdetails.custid";
            }
            string selectquery = "select salesOrderDelivery.Delivaryid as[Delivary Id],orderdetails.custid as [Customer Id], CustomerDetails.CustName as[Customer Name],CustomerDetails.CustCompName as[Company Name], CustomerDetails.CustAddress as[Address],DeliveryDate as[Delivery Date],(select Sum(customerorderdescriptions.quantity) from customerorderdescriptions where customerorderdescriptions.orderid= orderdetails.orderid) as[Bild Quanity],orderdetails.WithautTaxamount as[Gross Amount],orderdetails.Discount as[Discount Rate],orderdetails.Discountamount as[Dicount Amount],orderdetails.Tax as[Tax],orderdetails.Taxamount as[Tax Amount],orderdetails.totalammount as[Total Amount],pay.TotalAmount as[Paid Amount],pay.BalanceAmount as [Balance Amount] from orderdetails join CustomerDetails on CustomerDetails.custId=orderdetails.custid join salesOrderDelivery on orderdetails.Orderid=salesOrderDelivery.Orderid join SalesPaymentDetailes pay on salesOrderDelivery.Delivaryid=pay.Invoiceid where " + s + " like '" + textBox8.Text + "%'";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView2.DataSource = dt;
        }

        private void txtcustomerid_TextChanged(object sender, EventArgs e)
        {
            //if (txtcustomerid.Text.Trim() != "" && txtcustomerid.Text.StartsWith("C"))
            //{
            //    setvalue();
            //    string selectquery = "select c.CustName,c.CustCompName,c.CustAddress,c.CustPhone,c.CustMobile,c.CustFax ,ca.CustCurrentBalance from CustomerDetails c Join CustomerAccountDetails ca on c.Custid=ca.Custid Where c.Custid='" + txtcustomerid.Text + "'";
            //    DataTable dt = d.getDetailByQuery(selectquery);
            //    string v = "";
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        v = dr[0].ToString();
            //    }
            //    txttotalammount.Text = v;
            //}
            //string v = "";
            //string selectquery1 = "select ca.CustCurrentBalance from CustomerAccountDetails where ca.custid=ca.custid";
            //DataTable dt1 = d.getDetailByQuery(selectquery1);
            //foreach(DataRow dr1 in dt1.Rows)
            //{
            //    v = dr1[0].ToString();
            //}
            //txttotalammount.Text = v;

           
            string selectquery = "select c.CustName,c.CustCompName,c.CustAddress,c.CustPhone,c.CustMobile,c.CustFax ,ca.CustCurrentBalance from CustomerDetails c Join CustomerAccountDetails ca on c.Custid=ca.Custid Where c.Custid='" + txtcustomerid.Text + "'";
            DataTable dt = d.getDetailByQuery(selectquery);

            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtcustname.Text = dr[0].ToString();
                    txtcustcompnayname.Text = dr[1].ToString();
                    txtaddress.Text = dr[2].ToString();
                   // txtphone.Text = dr[3].ToString();
                   // txtmobile.Text = dr[4].ToString();
                   // txtfax.Text = dr[5].ToString();
                    txttotalammount.Text = dr[6].ToString();
                }
               // txttotalammount.Text = v;
            }
            else
            {
                txtcustname.Text = "";
                txtcustcompnayname.Text = "";
                txtaddress.Text = "";
                txtphone.Text = "";
                txtmobile.Text = "";
                txtfax.Text = "";
                txttotalammount.Text = "";
            }
        }

        private void txtpayammount_TextChanged(object sender, EventArgs e)
        {
            if (radcashbutton.Checked)
            {
                if (txtpayammount.Text != "")
                {
                    double total = Convert.ToDouble(txttotalammount.Text);
                    double payamount = Convert.ToDouble(txtpayammount.Text);
                    double arrearAmount = total - payamount;
                    txtreamaining.Text = arrearAmount.ToString();
                }
            }
            if (radcheckbutton.Checked)
            {
                txtpayammount.Text= varible.chaqueAmount;
                double total = Convert.ToDouble(txttotalammount.Text);
                double payamount = Convert.ToDouble(txtpayammount.Text);
                double arrearAmount = total - payamount;
                txtreamaining.Text = arrearAmount.ToString();
            }
        }
        private void makeblank()
        {
            txtcustomerid.Text = "C";
            txtcustname.Text = "";
            txtcustcompnayname.Text = "";
            txtaddress.Text = "";
            txtphone.Text = "";
            txtmobile.Text = "";
            txtfax.Text = "";
            txtRefNo.Text = "";
            addToCartTable.Clear();
            dataGridView1.DataSource = "";
            txttotalammount.Text = "0";
            txtpayammount.Text="0";
            txtreamaining.Clear();
            txtRefNo.Text = "";
            radcashbutton.Checked = false;
            
        }
        private void makeblank1()
        {
            radcheckbutton.Checked = false;
            checkBox1.Checked = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pnlSalesPayment.Visible = true;
            //string Chaquedate = Value.Bankdate;
            //string bankname = Value.Bankname;
            //string chaqueno = Value.chaqueno;
            //string chaqueammount = Value.chaqueammount;
            //if (txtRefNo.Text == "")
            //{
            //    if (radcashbutton.Checked)
            //    {
            //        string insertquery = "Insert into vithautrefrancereceipt values('" + txtcustomerid.Text + "','" + txttotalammount.Text + "','" + txtpayammount.Text + "','" + dtpdate.Text + "')";
            //        int insert = d.saveDetails(insertquery);

            //        string selectquery = "select CustCurrentBalance from CustomerAccountDetails where Custid='" + txtcustomerid.Text + "'";
            //        DataTable dt = d.getDetailByQuery(selectquery);
            //        string id = "";
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            id = dr[0].ToString();
            //        }
            //        int id1 = Convert.ToInt32(id);
            //        int id2 = Convert.ToInt32(txtreamaining.Text);
            //        int id3 = id2;
            //        string update = "update CustomerAccountDetails set CustCurrentBalance='" + id3.ToString() + "' where Custid='" + txtcustomerid.Text + "'";
            //        int c = d.saveDetails(update);
            //        if (c > 0)
            //        {
            //            MessageBox.Show("details save successfully");
            //        }
            //        else
            //        {
            //            MessageBox.Show("details save not successfully");

            //        }

            //    }
            //    else if (radcheckbutton.Checked)
            //    {
            //        string insertquery1 = "Insert into vithautrefrancereceipt values('" + txtcustomerid.Text + "','" + txttotalammount.Text + "','" + txtpayammount.Text + "','" + txtreamaining.Text + "','" + dtpdate.Text + "')";
            //        int insert2 = d.saveDetails(insertquery1);
            //        string selectquery = "select CustCurrentBalance from CustomerAccountDetails where Custid='" + txtcustomerid.Text + "'";
            //        DataTable dt = d.getDetailByQuery(selectquery);
            //        string id = "";
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            id = dr[0].ToString();
            //        }
            //        int id1 = Convert.ToInt32(id);
            //        int id2 = Convert.ToInt32(txtreamaining.Text);
            //        int id3 = id2;
            //        string update = "update CustomerAccountDetails set CustCurrentBalance='" + id3.ToString() + "' where Custid='" + txtcustomerid.Text + "'";
            //        int c = d.saveDetails(update);
            //        if (c > 0)
            //        {
            //            MessageBox.Show("details save successfully");
            //        }
            //        else
            //        {
            //            MessageBox.Show("details save not successfully");

            //        }

            //    }
            //}

            //else if (txtRefNo.Text != "")
            //{

            //    if (radcashbutton.Checked)
            //    {
            //        string insertd = "insert into payment values('" + txtRefNo.Text + "','" + txttotalammount.Text + "','" + txtpayammount.Text + "','" + txtreamaining.Text + "','Cash','" + dtpdate.Text + "')";
            //        int s2 = d.saveDetails(insertd);
            //        if (s2 > 0)
            //        {

            //            string selectquery = "select CustCurrentBalance from CustomerAccountDetails where Custid='" + txtcustomerid.Text + "'";
            //            DataTable dt = d.getDetailByQuery(selectquery);
            //            string id = "";
            //            foreach (DataRow dr in dt.Rows)
            //            {
            //                id = dr[0].ToString();
            //            }
            //            int id1 = Convert.ToInt32(id);
            //            int id2 = Convert.ToInt32(txtreamaining.Text);
            //            int id3 = id1 + id2;
            //            string update = "update CustomerAccountDetails set CustCurrentBalance='" + id3.ToString() + "' where Custid='" + txtcustomerid.Text + "'";
            //            int c = d.saveDetails(update);
            //            if (c > 0)
            //            {
            //                MessageBox.Show("details save successfully");
            //            }
            //            else
            //            {
            //                MessageBox.Show("details save not successfully");

            //            }
            //        }

            //    }

            //    else if (radcheckbutton.Checked)
            //    {
            //        string insert3 = "insert into payment values('" + txtRefNo.Text + "','" + txttotalammount.Text + "','" + txtpayammount.Text + "','" + txtreamaining.Text + "','Chaque','" + dtpdate.Text + "')";
            //        int s3 = d.saveDetails(insert3);
            //        if (s3 > 0)
            //        {
            //            string insert4 = "Insert into chaquedetail values('" + txtSrNo.Text + "','" + Chaquedate + "','" + bankname + "','" + chaqueno + "','" + chaqueammount + "')";
            //            int insertrow = d.saveDetails(insert4);
            //            if (insertrow > 0)
            //            {
            //                string id = "";
            //                string selectquery = "select CustCurrentBalance from CustomerAccountDetails where Custid='" + txtcustomerid.Text + "'";
            //                DataTable dt = d.getDetailByQuery(selectquery);
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    id = dr[0].ToString();
            //                }
            //                int id1 = Convert.ToInt32(id);
            //                int id2 = Convert.ToInt32(txtreamaining.Text);
            //                int id3 = id1 + id2;

            //                string update = "update CustomerAccountDetails set CustCurrentBalance='" + id3.ToString() + "'where Custid='" + txtcustomerid.Text + "'";
            //                int c1 = d.saveDetails(update);
            //                if (c1 > 0)
            //                {
            //                    MessageBox.Show("details save successfully");
            //                }

            //                else
            //                {
            //                    MessageBox.Show("details save not successfully");

            //                }
            //            }


            //        }

            //    }
                

            //}
            //makeblank();
            //makeblank1();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ChaqueForm sh = new ChaqueForm(txtpayammount);
            sh.Show();
             
        }

        private void txtRefNo_TextChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
           
           
        }

        private void txtRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
            string selectquery = "select Delivaryid from salesinvoice where Delivaryid='" + txtRefNo.Text + "'";
            DataTable dt = d.getDetailByQuery(selectquery);
            string DilId = "";
            foreach (DataRow dr1 in dt.Rows)
            {
                DilId = dr1[0].ToString();
            }

            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                MessageBox.Show("invoice detail is completed");
                txtRefNo.Text = "";
                dataGridView1.DataSource = "";
            }
            else
            {
                button5.Enabled = true;
            }
            string selectquery1 = "select  c.custId, c.CustName,c.CustCompName,c.CustAddress,c.CustPhone,c.CustMobile,c.CustFax,o.Orderid,s.Delivaryid from CustomerDetails c join orderdetails o on c.custId=o.custid join salesOrderDelivery s on o.Orderid=s.OrderId where s.Delivaryid='" + txtRefNo.Text + "'";
            DataTable dt1 = d.getDetailByQuery(selectquery1);
            string OrderId = "";
            if (dt1 != null && dt1.Rows != null && dt1.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dt1.Rows)
                {
                    txtcustomerid.Text = dr1[0].ToString();
                    txtcustname.Text = dr1[1].ToString();
                    txtcustcompnayname.Text = dr1[2].ToString();
                    txtaddress.Text = dr1[3].ToString();
                    txtphone.Text = dr1[4].ToString();
                    txtmobile.Text = dr1[5].ToString();
                    txtfax.Text = dr1[6].ToString();
                    OrderId = dr1[7].ToString();
                }
            }

            int totel = 0;
            string selectquery2 = "select it.itemid,iq.ItemName,it.price,it.quantity,it.totalammount from customerorderdescriptions it join ItemDetails iq on it.ItemId=iq.ItemId where Orderid='" + OrderId + "'";
            DataTable dt3 = d.getDetailByQuery(selectquery2);
            int totelrow = addToCartTable.Rows.Count;
            for (int a = 0; a < totelrow; a++)
            {
                addToCartTable.Rows.RemoveAt(0);
            }
            for (int a = 0; a < dt3.Rows.Count; a++)
            {
                DataRow dr1 = dt3.Rows[a];
                string t = dr1[0].ToString();
                string t2 = dr1[1].ToString();
                string t1 = dr1[2].ToString();
                string t3 = dr1[3].ToString();
                string totalamt = dr1[4].ToString();
                int amt = Convert.ToInt32(totalamt);
                totel = totel + amt;
                //dr1 = addToCartTable.NewRow();
                //dr1[0] = t.Trim();
                //dr1[1] = t2.Trim();
                //dr1[2] = t1.Trim();
                //dr1[3] = t3.Trim();
                //dr1[4] = totalamt.Trim();
                //addToCartTable.Rows.Add(dr1);

            }

            dataGridView1.DataSource = dt3; //addToCartTable;
            txttotalammount.Text = totel.ToString();
        }

            if (char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    makeblank();
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            txtcustomerid.ReadOnly = false;
            checkBox2.Checked = false;
            button1.Visible = false;
            makeblank();
           
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            txtcustomerid.ReadOnly = true;
            checkBox1.Checked = false;
            button1.Visible = true;
            txtSrNo.ReadOnly = true;
            txtRefNo.ReadOnly = true;
        }

        private void txtpayammount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                    txtreamaining.Text = "0";
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void pnlSalesPayment_Paint(object sender, PaintEventArgs e)
        {

            txtInvoiceid.Text = txtRefNo.Text;
            txtInvoiceAmount.Text = txttotalammount.Text;
            txtBalance.Text = txttotalammount.Text;
            txtNetAmount.Text = txtTotalAmount1.Text;
            Double Amount = Convert.ToDouble(txtTotalAmount1.Text);
            Double Amount1 = Convert.ToDouble(txtInvoiceAmount.Text);
            Double Amount2 = Amount1 - Amount;
            string Amount3 = Amount2.ToString();
            txtBalance.Text = Amount2.ToString("##0.00");
          
           
        }

        private void CashAmount_TextChanged(object sender, EventArgs e)
        {
            if (CashAmount.Text != "0")
            {
                //CashAmount.Text = "";
                string amount = CashAmount.Text;
                //CashAmount.Text = amount;
                double amount1 = 0.0;
                if (double.TryParse(amount, out amount1))
                {
                    txtTotalAmount1.Text = CashAmount.Text;
                }
            }
        }

        private void CashAmount_Leave(object sender, EventArgs e)
        {
            decimal x;
            if (decimal.TryParse(CashAmount.Text, out x))
            {
                if (CashAmount.Text.IndexOf('.') != -1 && CashAmount.Text.Split('.')[1].Length > 2)
                {
                    MessageBox.Show("The maximum decimal points are 2!");
                    CashAmount.Focus();
                }
                else CashAmount.Text = x.ToString("0.00");
            }
            else
            {
                CashAmount.Text = "0.00";
                //MessageBox.Show("Data invalid!");
                //txtVenderOpeningBal.Focus();
            }
        }

        private void CashAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //if (CashAmount.Text.IndexOf('.') != -1 && CashAmount.Text.Split('.')[1].Length == 2)
                //{
                //MessageBox.Show("The maximum decimal points are 2!");
                e.Handled = false;
                //}
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    txtTotalAmount1.Text = "0.00";
                    txtNetAmount.Text = "0.00";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtCreditAmount_Leave(object sender, EventArgs e)
        {
            if (txtCreditAmount.Text == "")
            {
                txtCreditAmount.Text = "0.00";
            }
            if (txtCreditAmount.Text != "0.00")
            {
                string amount = txtCreditAmount.Text + ".00";
                txtCreditAmount.Text = amount;
                Double Amount = Convert.ToDouble(txtCreditAmount.Text);
                Double Amount1 = Convert.ToDouble(CashAmount.Text);
                Double amount2 = Amount + Amount1;
                string Amount2 = amount2.ToString();
                txtTotalAmount1.Text = Amount2 + ".00";
            }
        }

        public void credittext()
        {
            txtCardNumber.ReadOnly = false;
            txtDebitBankName.ReadOnly = false;
            CmbCardType.Enabled = true;
            txtCardNumber.TabStop = true;
            txtDebitBankName.TabStop = true;
        }
        public void credittext1()
        {
            txtCardNumber.ReadOnly = true;
            txtDebitBankName.ReadOnly = true;
            CmbCardType.Enabled = false;
            txtCardNumber.TabStop = false;
            txtDebitBankName.TabStop = false;
        }

        private void txtChequeAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtCreditAmount.Text == "0.00")
            {
                credittext1();
            }
            if (txtCreditAmount.Text != "0.00")
            {
                credittext();
                string amount = txtCreditAmount.Text;
                double amount1 = 0.0;
                if (double.TryParse(amount, out amount1))
                {
                    txtCreditAmount.Text = amount;
                    Double Amount = Convert.ToDouble(txtCreditAmount.Text);
                    Double Amount1 = Convert.ToDouble(CashAmount.Text);
                    Double amount2 = Amount + Amount1;
                    //string Amount2 = amount2.ToString();
                    txtTotalAmount1.Text = amount2.ToString("##0.00");
                }

            }
        }

        private void txtChequeAmount_Leave(object sender, EventArgs e)
        {
            if (txtCreditAmount.Text == "0.00")
            {
                credittext1();
            }
            if (txtCreditAmount.Text != "0.00")
            {
                credittext();
                decimal x;
                if (decimal.TryParse(txtChequeAmount.Text, out x))
                {
                    if (txtChequeAmount.Text.IndexOf('.') != -1 && txtChequeAmount.Text.Split('.')[1].Length > 2)
                    {
                        MessageBox.Show("The maximum decimal points are 2!");
                        txtChequeAmount.Focus();
                    }
                    else txtChequeAmount.Text = x.ToString("0.00");
                }
                else
                {
                    txtChequeAmount.Text = "0.00";
                    //MessageBox.Show("Data invalid!");
                    //txtVenderOpeningBal.Focus();
                }
            }
        }

        private void txtChequeAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //if (txtChequeAmount.Text.IndexOf('.') != -1 && txtChequeAmount.Text.Split('.')[1].Length == 2)
                //{
                //    //MessageBox.Show("The maximum decimal points are 2!");
                e.Handled = false;
                //}
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    txtBalance.Text = "0";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtEwalletAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtEwalletAmount.Text == "")
            {
                Ewalled1();
            }
            else if (txtEwalletAmount.Text != "0")
            {
                Ewalled();
                string amount = txtEwalletAmount.Text;
                double amount1 = 0.0;
                if (double.TryParse(amount, out amount1))
                {
                    txtEwalletAmount.Text = amount;
                    Double Amount = Convert.ToDouble(txtCreditAmount.Text);
                    Double Amount1 = Convert.ToDouble(CashAmount.Text);
                    Double Amount3 = Convert.ToDouble(txtChequeAmount.Text);
                    Double Amount4 = Convert.ToDouble(txtEwalletAmount.Text);
                    Double amount2 = Amount + Amount1 + Amount3 + Amount4;
                    string Amount2 = amount2.ToString();
                    txtTotalAmount1.Text = Amount2;
                }
            }
        }
        public void Ewalled()
        {
            txtTransactionNumber.ReadOnly = false;
            EWalletCompanyName.ReadOnly = false;
            dataGridView2.Enabled = false;
            txtTransactionNumber.TabStop = false;
            EWalletCompanyName.TabStop = false;

        }
        public void Ewalled1()
        {

            txtTransactionNumber.ReadOnly = true;
            EWalletCompanyName.ReadOnly = true;
            dataGridView2.Enabled = true;
            txtTransactionNumber.TabStop = false;
            EWalletCompanyName.TabStop = false;
        }
        private void txtEwalletAmount_Leave(object sender, EventArgs e)
        {
            if (txtEwalletAmount.Text == "0.00")
            {
                Ewalled1();
            }
            else
            {
                Ewalled();
            }
            decimal x;
            if (decimal.TryParse(txtChequeAmount.Text, out x))
            {
                if (txtChequeAmount.Text.IndexOf('.') != -1 && txtChequeAmount.Text.Split('.')[1].Length > 2)
                {
                    MessageBox.Show("The maximum decimal points are 2!");
                    txtChequeAmount.Focus();
                }
                else txtChequeAmount.Text = x.ToString("0.00");
            }
            else
            {
                txtChequeAmount.Text = "0.00";
                //MessageBox.Show("Data invalid!");
                //txtVenderOpeningBal.Focus();
            }
        }

        private void txtEwalletAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //if (txtEwalletAmount.Text.IndexOf('.') != -1 && txtEwalletAmount.Text.Split('.')[1].Length == 2)
                //{
                //    //MessageBox.Show("The maximum decimal points are 2!");
                e.Handled = false;
                //}
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    txtBalance.Text = "0";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtCouponAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtCouponAmount.Text == "0.00")
            {
                CmbCompany.Enabled = true;
                //label23.Visible = false;
            }
            if (txtCouponAmount.Text != "0.00")
            {
                CmbCompany.Enabled = false;
                //label23.Visible = true;
                string amount = txtCouponAmount.Text;
                //txtCouponAmount.Text = amount;
                double amount1 = 0.0;
                if (double.TryParse(amount, out amount1))
                {
                    Double Amount = Convert.ToDouble(txtCreditAmount.Text);
                    Double Amount1 = Convert.ToDouble(CashAmount.Text);
                    Double Amount3 = Convert.ToDouble(txtChequeAmount.Text);
                    Double Amount4 = Convert.ToDouble(txtEwalletAmount.Text);
                    Double Amount5 = Convert.ToDouble(txtCouponAmount.Text);
                    Double amount2 = Amount + Amount1 + Amount3 + Amount4 + Amount5;
                    string Amount2 = amount2.ToString();
                    txtTotalAmount1.Text = amount2.ToString("##0.00");
                }
            }
        }

        private void txtCouponAmount_Leave(object sender, EventArgs e)
        {
            if (txtCouponAmount.Text == "0.00")
            {
                //CmbCompany.Visible = false;
                // label23.Visible = false;
            }
            else
            {
                //CmbCompany.Visible = true;
                //label23.Visible = true;
            }
            decimal x;
            if (decimal.TryParse(txtCouponAmount.Text, out x))
            {
                if (txtCouponAmount.Text.IndexOf('.') != -1 && txtCouponAmount.Text.Split('.')[1].Length > 2)
                {
                    MessageBox.Show("The maximum decimal points are 2!");
                    txtCouponAmount.Focus();
                }
                else txtCouponAmount.Text = x.ToString("0.00");
            }
            else
            {
                txtCouponAmount.Text = "0.00";
                //MessageBox.Show("Data invalid!");
                //txtVenderOpeningBal.Focus();
            }
        }

        private void txtCouponAmount_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //    if (txtCouponAmount.Text.IndexOf('.') != -1 && txtCouponAmount.Text.Split('.')[1].Length == 2)
                //    {
                //        //MessageBox.Show("The maximum decimal points are 2!");
                e.Handled = false;
                //}
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    txtBalance.Text = "0";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtTotalAmount1_TextChanged(object sender, EventArgs e)
        {
            txtNetAmount.Text = txtTotalAmount1.Text;
            Double Amount = Convert.ToDouble(txtTotalAmount1.Text);
            Double Amount1 = Convert.ToDouble(txtInvoiceAmount.Text);
            Double Amount2 = Amount1 - Amount;
            string Amount3 = Amount2.ToString();
            txtBalance.Text = Amount2.ToString("##0.00");
        }

        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //if (txtBalance.Text.IndexOf('.') != -1 && txtBalance.Text.Split('.')[1].Length == 2)
                //{
                //MessageBox.Show("The maximum decimal points are 2!");
                e.Handled = false;
                //}
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    txtBalance.Text = "0";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtRturned_TextChanged(object sender, EventArgs e)
        {

            if (txtBalance.Text == "")
            {
                txtBalance.Text = "0";
            }
            if (txtRturned.Text == "")
            {
                txtRturned.Text = "0";
            }
            string sub = txtBalance.Text;
            string return1 = txtRturned.Text;
            double amount1 = 0.0;
            if (double.TryParse(sub, out amount1))
            {
                double bal = Convert.ToDouble(txtBalance.Text);
                if (double.TryParse(return1, out amount1))
                {
                    double ReturnAmount = Convert.ToDouble(txtRturned.Text);
                    double bal1 = bal + ReturnAmount;
                    txtBalance.Text = bal1.ToString();
                }
            }
        }

        private void txtRturned_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //if (txtRturned.Text.IndexOf('.') != -1 && txtRturned.Text.Split('.')[1].Length == 2)
                //{
                //    //MessageBox.Show("The maximum decimal points are 2!");
                //    e.Handled = true;
                //}
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    txtBalance.Text = "0";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime f1 = DateTime.Now;
            string insertQurry = "insert into SalesPaymentDetailes Values('" + txtInvoiceid.Text + "','" + CashAmount.Text + "','" + txtCreditAmount.Text + "','" + txtDebitBankName.Text + "','" + txtCardNumber.Text + "','" + CmbCardType.SelectedItem.ToString() + "','" + txtChequeAmount.Text + "','" + txtChequeBankName.Text + "','" + txtChequeNumber.Text + "','" + dateTimePicker1.Value.ToString() + "','" + txtEwalletAmount.Text + "','" + EWalletCompanyName.Text + "','" + txtTransactionNumber.Text + "','" + dateTimePicker2.Value.ToString() + "','" + txtCouponAmount.Text + "','" + CmbCompany.SelectedItem.ToString() + "','" + txtInvoiceAmount.Text + "','" + txtTotalAmount1.Text + "','" + txtBalance.Text + "','" + txtRturned.Text + "','" + txtNetAmount.Text + "','"+f1+"')";
            int insertedRows = d.saveDetails(insertQurry);
            if (insertedRows > 0)
            {

                MessageBox.Show("details save successfully");
                 salesedelivarytabindex();
                 //pnlSalesPayment.Visible = true;
                }
            else
               {
                    MessageBox.Show("details not save successfully");
              }
            pnlSalesPayment.Visible = false;
            panel2.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        }
       
    }

