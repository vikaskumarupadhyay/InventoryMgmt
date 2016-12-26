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
    public partial class PurchasSearch1 : Form
    {
        public PurchasSearch1()
        {
            InitializeComponent();
        }
         DB_Main dbMainClass = new DB_Main();
        
        private void PurchasSearch_Load(object sender, EventArgs e)
        {
            string selectqurry = "select od.Orderid,od.venderId,itd.ItemName,vod.Quantity,vod.TotalPrice,od.OrderDate,cod.DeliveryDate,coi.InvoiceDate from VendorOrderDetails od join VendorOrderDesc vod on od.Orderid=vod.Orderid join CustomerOrderDelivery cod on cod.Orderid=vod.Orderid join CustomerOrderInvoice coi on coi.Orderid=vod.Orderid join ItemDetails itd on itd.ItemId=vod.ItemId";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            List<string> ls = new List<string>();
            DataColumnCollection d = dt.Columns;
            for (int a = 0; a < d.Count; a++)
            {
                DataColumn dc = new DataColumn();
                string b = d[a].ToString();
                ls.Add(b);
            }
            comboPurchasesearch.DataSource = ls;
            gridPurchaseSearch.DataSource = dt;
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string s = comboPurchasesearch.SelectedValue.ToString();
            if (s == "Orderid")
            {
                s = "od.Orderid";
                get(s);
            }
            else if (s == "OrderDate")
            {
                s = "od.OrderDate";
                get1(s);
                
            }
            else if (s == "DeliveryDate")
            {
                s = "cod.DeliveryDate";
                get1(s);
            }
            else if (s == "InvoiceDate")
            {
                s = "coi.InvoiceDate";
                get1(s);
                //string selectQurry = "select od.Orderid,od.venderId,itd.ItemName,vod.Quantity,vod.TotalPrice,od.OrderDate,cod.DeliveryDate,coi.InvoiceDate from VendorOrderDetails od join VendorOrderDesc vod on vod.Orderid=od.Orderid join CustomerOrderDelivery cod on cod.Orderid=vod.Orderid join CustomerOrderInvoice coi on coi.Orderid=vod.Orderid join ItemDetails itd on itd.ItemId=vod.ItemId where " + s + " = '" + txtsearch.Text + "'";
                //DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
                //gridPurchaseSearch.DataSource = dt;
            }
            else if (s == "TotalPrice")
            {
                s = "vod.TotalPrice";
                get(s);
            }
            else 
            {
                get(s);
            }
        }
        private void get( string a)
        {
            string selectQurry = "select od.Orderid,od.venderId,itd.ItemName,vod.Quantity,vod.TotalPrice,od.OrderDate,cod.DeliveryDate,coi.InvoiceDate from VendorOrderDetails od join VendorOrderDesc vod on vod.Orderid=od.Orderid join CustomerOrderDelivery cod on cod.Orderid=vod.Orderid join CustomerOrderInvoice coi on coi.Orderid=vod.Orderid join ItemDetails itd on itd.ItemId=vod.ItemId where " + a + " like '" + txtsearch.Text + "%'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            gridPurchaseSearch.DataSource = dt;
        }
        private void get1(string a)
        {
            string selectQurry = "select od.Orderid,od.venderId,itd.ItemName,vod.Quantity,vod.TotalPrice,od.OrderDate,cod.DeliveryDate,coi.InvoiceDate from VendorOrderDetails od join VendorOrderDesc vod on vod.Orderid=od.Orderid join CustomerOrderDelivery cod on cod.Orderid=vod.Orderid join CustomerOrderInvoice coi on coi.Orderid=vod.Orderid join ItemDetails itd on itd.ItemId=vod.ItemId where " + a + "= '" + txtsearch.Text + "'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            gridPurchaseSearch.DataSource = dt;
        }
    }
}
