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
        string invoice = "";
        DB_Main d = new DB_Main();
        DataTable customerdetails = new DataTable();
        DataTable addToCartTable = new DataTable();
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
            button1.Visible = false;
            Purchase.PurchaseDetails purchasedetailobj = new Purchase.PurchaseDetails();
            customerdetails = purchasedetailobj.GetcustomerdetailsInDataTable();
            panel2.Visible = false;
            txtcustomerid.Text = "C";
            string s = invoice;
            txtRefNo.Text = s;
            panel2.Visible = false;
            string select = " select Orderid from salesinvoice where invoiceid='" + s + "'";
            DataTable dt = d.getDetailByQuery(select);
            string invo = "";
            foreach (DataRow dr in dt.Rows)
            {
                invo = dr[0].ToString();
            }
            string select1 = "select Custid from orderdetails where Orderid='" + invo+ "'";
            DataTable dt1 = d.getDetailByQuery(select1);
            string ordorid = "";
            foreach (DataRow dr in dt1.Rows)
            {
                ordorid = dr[0].ToString();
            }
            string select2=" Select Custid, CustName,CustCompName ,CustAddress ,CustPhone ,CustMobile ,CustFax   from CustomerDetails where Custid='"+ordorid+"'";
            DataTable dt2 = d.getDetailByQuery(select2);
            foreach (DataRow dr in dt2.Rows)
            {
                txtcustomerid.Text = dr[0].ToString();
                txtcustname.Text = dr[1].ToString();
                txtcustcompnayname.Text = dr[2].ToString();
                txtaddress.Text = dr[3].ToString();
                txtphone.Text = dr[4].ToString();
                txtmobile.Text = dr[5].ToString();
                txtfax.Text = dr[6].ToString();
            }
            string select3 = "select vod.ItemId,ide.ItemName,vod.Price,vod.Quantity,vod.totalammount from customerorderdescriptions vod join ItemDetails ide on Vod.ItemId=ide.ItemId where vod.Orderid='" + invo + "'";
            DataTable dt4 = d.getDetailByQuery(select3);
            string selectquery = "select totalammount from orderdetails where orderid='" + invo + "'";
            DataTable dt5 = d.getDetailByQuery(selectquery);
            foreach (DataRow dr in dt5.Rows)
            {
                txttotalammount.Text = dr[0].ToString();
            }
            dataGridView1.DataSource = dt4;

            string selectquery1 = "select id from payment";
            DataTable dt3 = d.getDetailByQuery(selectquery1);
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
            //txtcustomerid.Text = "C";

            //dtpdate.Value = DateTime.Now;
            //Purchase.PurchaseDetails purchasedetailobj = new Purchase.PurchaseDetails();
            //customerdetails = purchasedetailobj.GetcustomerdetailsInDataTable();
            //panel2.Visible = false;
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
                txttotalammount.Text = collection[7].Value.ToString();
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
            //if (txtcustomerid.Text.Trim() != "" && txtcustomerid.Text.StartsWith("C"))
            //{
            //    setvalue();
            //}
            string selectquery = "select c.CustName,c.CustCompName,c.CustAddress,c.CustPhone,c.CustMobile,c.CustFax ,ca.CustCurrentBalance from CustomerDetails c Join CustomerAccountDetails ca on c.Custid=ca.Custid Where c.Custid='" + txtcustomerid.Text + "'";
            DataTable dt = d.getDetailByQuery(selectquery);

            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtcustname.Text = dr[0].ToString();
                    txtcustcompnayname.Text = dr[1].ToString();
                    txtaddress.Text = dr[2].ToString();
                    txtphone.Text = dr[3].ToString();
                    txtmobile.Text = dr[4].ToString();
                    txtfax.Text = dr[5].ToString();
                    txttotalammount.Text = dr[6].ToString();
                }
            }
            else
            {
                txtcustname.Text = "";
                txtcustcompnayname.Text = "";
                txtaddress.Text = "";
                txtphone.Text= "";
                txtmobile.Text = "";
                txtfax.Text= "";
                txttotalammount.Text = "";
            }
        }

        private void txtpayammount_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {

               // txtpayammount.Text = Value.chaqueammount;
                int totalammount = Convert.ToInt32(txttotalammount.Text);
                int payment = Convert.ToInt32(txtpayammount.Text);
                int remaining = totalammount - payment;
                txtreamaining.Text = remaining.ToString();
            }
            else if (radioButton2.Checked)
            {
                txtpayammount.Text = Value.chaqueammount;
                int totalammount = Convert.ToInt32(txttotalammount.Text);
                int payment = Convert.ToInt32(txtpayammount.Text);
                int remaining = totalammount - payment;
                txtreamaining.Text = remaining.ToString();
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
            radioButton1.Checked = false;
            
        }
        private void makeblank1()
        {
            radioButton2.Checked = false;
            checkBox1.Checked = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string Chaquedate = Value.Bankdate;
            string bankname = Value.Bankname;
            string chaqueno = Value.chaqueno;
            string chaqueammount = Value.chaqueammount;
            if (txtRefNo.Text == "")
            {
                if (radioButton1.Checked)
                {
                    string insertquery = "Insert into vithautrefrancereceipt values('" + txtcustomerid.Text + "','" + txttotalammount.Text + "','" + txtpayammount.Text + "','" + dtpdate.Text + "')";
                    int insert = d.saveDetails(insertquery);

                    string selectquery = "select CustCurrentBalance from CustomerAccountDetails where Custid='" + txtcustomerid.Text + "'";
                    DataTable dt = d.getDetailByQuery(selectquery);
                    string id = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        id = dr[0].ToString();
                    }
                    int id1 = Convert.ToInt32(id);
                    int id2 = Convert.ToInt32(txtreamaining.Text);
                    int id3 = id2;
                    string update = "update CustomerAccountDetails set CustCurrentBalance='" + id3.ToString() + "' where Custid='" + txtcustomerid.Text + "'";
                    int c = d.saveDetails(update);
                    if (c > 0)
                    {
                        MessageBox.Show("details save successfully");
                    }
                    else
                    {
                        MessageBox.Show("details save not successfully");

                    }

                }
                else if (radioButton2.Checked)
                {
                    string insertquery1 = "Insert into vithautrefrancereceipt values('" + txtcustomerid.Text + "','" + txttotalammount.Text + "','" + txtpayammount.Text + "','" + txtreamaining.Text + "','" + dtpdate.Text + "')";
                    int insert2 = d.saveDetails(insertquery1);
                    string selectquery = "select CustCurrentBalance from CustomerAccountDetails where Custid='" + txtcustomerid.Text + "'";
                    DataTable dt = d.getDetailByQuery(selectquery);
                    string id = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        id = dr[0].ToString();
                    }
                    int id1 = Convert.ToInt32(id);
                    int id2 = Convert.ToInt32(txtreamaining.Text);
                    int id3 = id2;
                    string update = "update CustomerAccountDetails set CustCurrentBalance='" + id3.ToString() + "' where Custid='" + txtcustomerid.Text + "'";
                    int c = d.saveDetails(update);
                    if (c > 0)
                    {
                        MessageBox.Show("details save successfully");
                    }
                    else
                    {
                        MessageBox.Show("details save not successfully");

                    }

                }
            }

            else if (txtRefNo.Text != "")
            {

                if (radioButton1.Checked)
                {
                    string insertd = "insert into payment values('" + txtRefNo.Text + "','" + txttotalammount.Text + "','" + txtpayammount.Text + "','" + txtreamaining.Text + "','Cash','" + dtpdate.Text + "')";
                    int s2 = d.saveDetails(insertd);
                    if (s2 > 0)
                    {

                        string selectquery = "select CustCurrentBalance from CustomerAccountDetails where Custid='" + txtcustomerid.Text + "'";
                        DataTable dt = d.getDetailByQuery(selectquery);
                        string id = "";
                        foreach (DataRow dr in dt.Rows)
                        {
                            id = dr[0].ToString();
                        }
                        int id1 = Convert.ToInt32(id);
                        int id2 = Convert.ToInt32(txtreamaining.Text);
                        int id3 = id1 + id2;
                        string update = "update CustomerAccountDetails set CustCurrentBalance='" + id3.ToString() + "' where Custid='" + txtcustomerid.Text + "'";
                        int c = d.saveDetails(update);
                        if (c > 0)
                        {
                            MessageBox.Show("details save successfully");
                        }
                        else
                        {
                            MessageBox.Show("details save not successfully");

                        }
                    }

                }

                else if (radioButton2.Checked)
                {
                    string insert3 = "insert into payment values('" + txtRefNo.Text + "','" + txttotalammount.Text + "','" + txtpayammount.Text + "','" + txtreamaining.Text + "','Chaque','" + dtpdate.Text + "')";
                    int s3 = d.saveDetails(insert3);
                    if (s3 > 0)
                    {
                        string insert4 = "Insert into chaquedetail values('" + txtSrNo.Text + "','" + Chaquedate + "','" + bankname + "','" + chaqueno + "','" + chaqueammount + "')";
                        int insertrow = d.saveDetails(insert4);
                        if (insertrow > 0)
                        {
                            string id = "";
                            string selectquery = "select CustCurrentBalance from CustomerAccountDetails where Custid='" + txtcustomerid.Text + "'";
                            DataTable dt = d.getDetailByQuery(selectquery);
                            foreach (DataRow dr in dt.Rows)
                            {
                                id = dr[0].ToString();
                            }
                            int id1 = Convert.ToInt32(id);
                            int id2 = Convert.ToInt32(txtreamaining.Text);
                            int id3 = id1 + id2;

                            string update = "update CustomerAccountDetails set CustCurrentBalance='" + id3.ToString() + "'where Custid='" + txtcustomerid.Text + "'";
                            int c1 = d.saveDetails(update);
                            if (c1 > 0)
                            {
                                MessageBox.Show("details save successfully");
                            }

                            else
                            {
                                MessageBox.Show("details save not successfully");

                            }
                        }


                    }

                }
                

            }
            makeblank();
            makeblank1();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ChaqueForm sh = new ChaqueForm(txtpayammount);
            sh.Show();
             
        }

        private void txtRefNo_TextChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = true;            
            //string select = "select orderid from salesinvoice Where invoiceid='" + txtRefNo.Text + "'";
            //DataTable dt = d.getDetailByQuery(select);
            //string customerid= "";
            //foreach (DataRow dr in dt.Rows)
            //{
            //    customerid = dr[0].ToString();
            //}
            string selectquery = "select  c.custId, c.CustName,c.CustCompName,c.CustAddress,c.CustPhone,c.CustMobile,c.CustFax,o.Orderid,s.Delivaryid,i.invoiceid from CustomerDetails c join orderdetails o on c.custId=o.custid join salesOrderDelivery s on o.Orderid=s.OrderId join salesinvoice i on o.Orderid=i.Orderid where i.invoiceid='"+txtRefNo.Text+"'";
            DataTable dt1 = d.getDetailByQuery(selectquery);
            string orderid = "";
            if (dt1 != null && dt1.Rows != null && dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    txtcustomerid.Text = dr[0].ToString();
                    txtcustname.Text = dr[1].ToString();
                    txtcustcompnayname.Text = dr[2].ToString();
                    txtaddress.Text = dr[3].ToString();
                    txtphone.Text = dr[4].ToString();
                    txtmobile.Text = dr[5].ToString();
                    txtfax.Text = dr[6].ToString();
                    orderid = dr[7].ToString();
                }
            }
            string total="";
            string selectq= "select it.itemid,iq.ItemName,it.price,it.quantity,it.totalammount from customerorderdescriptions it join ItemDetails iq on it.ItemId=iq.ItemId where orderid='"+orderid + "'";
             DataTable dt3 = d.getDetailByQuery(selectq);
             string select2 = " select totalammount from orderdetails where orderid='" + orderid + "'";
             DataTable dt4 = d.getDetailByQuery(select2);
             foreach (DataRow dr1 in dt4.Rows)
             {
                total = dr1[0].ToString();
             }

             dataGridView1.DataSource = dt3;
             txttotalammount.Text =total;
            
           
        }

        private void txtRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
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
            txtcustomerid.ReadOnly = true;
            checkBox1.Checked = false;
            button1.Visible = true;
            txtSrNo.ReadOnly= true;
            txtRefNo.ReadOnly = true;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            txtcustomerid.ReadOnly = false;
            checkBox2.Checked = false;
            button1.Visible = false;
            makeblank();
        }


        

        }
       
    }

