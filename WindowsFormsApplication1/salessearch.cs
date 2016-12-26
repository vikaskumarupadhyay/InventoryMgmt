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
    public partial class salessearch : Form
    {
         DB_Main d = new DB_Main();
        public salessearch()
        {
            InitializeComponent();
        }

        private void salessearch_Load(object sender, EventArgs e)
        {
            string selectquery = " select od.orderid,od.custid,itd.ItemName,cod.quantity,cod.totalammount,od.date,sod.DeliveryDate,si.invoicedate from orderdetails  od  join customerorderdescriptions cod on od.orderid=cod.orderid join salesOrderDelivery sod on cod.orderid=sod.orderid join salesinvoice si on sod.orderid=si.orderid join ItemDetails itd on cod.ItemId=itd.ItemId";
             DataTable dt1 = d.getDetailByQuery(selectquery);
            List<string> sd = new List<string>();
            DataColumnCollection d1 = dt1.Columns;     
            for(int a=1;a<d1.Count;a++)
            {
                DataColumn dc = new DataColumn();
                string val = d1[a].ToString();
                sd.Add(val);
            }
            comboBox1.DataSource=sd;
           dataGridView1.DataSource = dt1;
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = comboBox1.SelectedValue.ToString();
            if (s == "orderrid")
            {
                s = "od.orderid";
                string selectquery = " select od.orderid,od.custid,itd.ItemName,cod.quantity,cod.totalammount,od.date,sod.DeliveryDate,si.invoicedate from orderdetails  od  join customerorderdescriptions cod on od.orderid=cod.orderid join salesOrderDelivery sod on cod.orderid=sod.orderid join salesinvoice si on sod.orderid=si.orderid join ItemDetails itd on cod.ItemId=itd.ItemId Where " + s + " like'" + textBox1.Text + "%' ";
                DataTable dt = d.getDetailByQuery(selectquery);
                dataGridView1.DataSource = dt;
            }
            else if (s == "custid")
            {
                s = "od.custid";
                string selectquery = " select od.orderid,od.custid,itd.ItemName,cod.quantity,cod.totalammount,od.date,sod.DeliveryDate,si.invoicedate from orderdetails  od  join customerorderdescriptions cod on od.orderid=cod.orderid join salesOrderDelivery sod on cod.orderid=sod.orderid join salesinvoice si on sod.orderid=si.orderid join ItemDetails itd on cod.ItemId=itd.ItemId Where " + s + " like'" + textBox1.Text + "%' ";
                DataTable dt = d.getDetailByQuery(selectquery);
                dataGridView1.DataSource = dt;
            }
            else if (s == "ItemName")
            {
                s = "itd.ItemName";
                string selectquery = " select od.orderid,od.custid,itd.ItemName,cod.quantity,cod.totalammount,od.date,sod.DeliveryDate,si.invoicedate from orderdetails  od  join customerorderdescriptions cod on od.orderid=cod.orderid join salesOrderDelivery sod on cod.orderid=sod.orderid join salesinvoice si on sod.orderid=si.orderid join ItemDetails itd on cod.ItemId=itd.ItemId Where " + s + " like'" + textBox1.Text + "%' ";
                DataTable dt = d.getDetailByQuery(selectquery);
                dataGridView1.DataSource = dt;
            }
            else if (s == "totalammount")
            {
                s = "cod.totalammount";
                string selectquery = " select od.orderid,od.custid,itd.ItemName,cod.quantity,cod.totalammount,od.date,sod.DeliveryDate,si.invoicedate from orderdetails  od  join customerorderdescriptions cod on od.orderid=cod.orderid join salesOrderDelivery sod on cod.orderid=sod.orderid join salesinvoice si on sod.orderid=si.orderid join ItemDetails itd on cod.ItemId=itd.ItemId Where " + s + " like'" + textBox1.Text + "%' ";
                DataTable dt = d.getDetailByQuery(selectquery);
                dataGridView1.DataSource = dt;
            }
            else if (s == "DeliveryDate")
            {
                s = "sod.DeliveryDate";
                string selectquery = " select od.orderid,od.custid,itd.ItemName,cod.quantity,cod.totalammount,od.date,sod.DeliveryDate,si.invoicedate from orderdetails  od  join customerorderdescriptions cod on od.orderid=cod.orderid join salesOrderDelivery sod on cod.orderid=sod.orderid join salesinvoice si on sod.orderid=si.orderid join ItemDetails itd on cod.ItemId=itd.ItemId Where " + s + " ='" + textBox1.Text + "' ";
                DataTable dt = d.getDetailByQuery(selectquery);
                dataGridView1.DataSource = dt;
            }
            else if (s == "date")
            {
                s = "od.date";
                string selectquery = " select od.orderid,od.custid,itd.ItemName,cod.quantity,cod.totalammount,od.date,sod.DeliveryDate,si.invoicedate from orderdetails  od  join customerorderdescriptions cod on od.orderid=cod.orderid join salesOrderDelivery sod on cod.orderid=sod.orderid join salesinvoice si on sod.orderid=si.orderid join ItemDetails itd on cod.ItemId=itd.ItemId Where " + s + " ='" + textBox1.Text + "' ";
                DataTable dt = d.getDetailByQuery(selectquery);
                dataGridView1.DataSource = dt;
            }
            else if(s=="invoicedate")
            {
                s="si.invoicedate";
                string selectquery = " select od.orderid,od.custid,itd.ItemName,cod.quantity,cod.totalammount,od.date,sod.DeliveryDate,si.invoicedate from orderdetails  od  join customerorderdescriptions cod on od.orderid=cod.orderid join salesOrderDelivery sod on cod.orderid=sod.orderid join salesinvoice si on sod.orderid=si.orderid join ItemDetails itd on cod.ItemId=itd.ItemId Where " + s + " ='" + textBox1.Text + "' ";
                DataTable dt = d.getDetailByQuery(selectquery);
                dataGridView1.DataSource = dt;
            }

        }

        }
    }

