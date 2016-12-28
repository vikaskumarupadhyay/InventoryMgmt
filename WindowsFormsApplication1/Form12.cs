using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class salesinvoice : Form
    {
        DB_Main d = new DB_Main();
        public salesinvoice()
        {
            InitializeComponent();
        }
        public int maxquantity = 0;
        public int counter = 0;
        DataTable vendorDetails = new DataTable();
        DataTable addToCartTable = new DataTable();
        DataTable customerdetails = new DataTable();
        DataTable ItemDetails = new DataTable();
        private void butcustbutton_Click(object sender, EventArgs e)
        {
            string selectquery1 = "select CustName,CustCompName,CustAddress,CustPhone,Custmobile,CustFax from CustomerDetails";
            DataTable dt1 = d.getDetailByQuery(selectquery1);
            string val = " ";
            List<string> sd = new List<string>();
            foreach (DataColumn dr in dt1.Columns)
            {
                val = dr.ColumnName;
                sd.Add(val);
            }
            comserchvalue.DataSource = sd;
   
             counter = 0;
            panel2.Visible = true;
            string selectquery = "select Custid, CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from customerdetails";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView2.DataSource = dt;
        }
            
         public void rowcollection(DataGridViewCellCollection cell)
            {
            txtCustcode.Text = cell[0].Value.ToString();
            txtcustname.Text = cell[1].Value.ToString();
            txtcustcompname.Text= cell[2].Value.ToString();
            txtcustaddress.Text = cell[3].Value.ToString();
            txtcustphone.Text = cell[4].Value.ToString();
            txtcustmobile.Text = cell[5].Value.ToString();
            txtcustfax.Text= cell[6].Value.ToString();
        }
         public void rowcollection1(DataGridViewCellCollection cell1)
         {
             txtitemcode.Text = cell1[0].Value.ToString();
             txtproductname.Text = cell1[1].Value.ToString();
            txtrate.Text = cell1[2].Value.ToString();
             maxquantity =Convert.ToInt32(cell1[3].Value.ToString());
             txtquantity.Text = "";
             txtammount.Text= "";

         }

         private void butitembutton_Click(object sender, EventArgs e)
         {
             string selectquery1 = "select it.ItemName,ip.Mrpprice,iq.CurrentQuantity from ItemDetails it join ItemPriceDetail ip on it.Itemid=ip.Itemid join ItemQuantityDetail iq on ip.ItemId=iq.Itemid";
             DataTable dt1 = d.getDetailByQuery(selectquery1);
             string val = " ";
             List<string> sd = new List<string>();
             foreach (DataColumn dr in dt1.Columns)
             {
                 val = dr.ColumnName;
                 sd.Add(val);
             }
             comserchvalue.DataSource = sd;
             counter = 1;
             panel2.Visible = true;
             string selectquery = "select i.Itemid,i.Itemname,ip.MrpPrice,iq.CurrentQuantity from itemdetails i join itempricedetail ip on i.itemid=ip.itemid join itemquantitydetail iq on ip.itemid=iq.itemid";
             DataTable dt = d.getDetailByQuery(selectquery);
             dataGridView2.DataSource = dt;
         }
         private void txtquantity_TextChanged(object sender, EventArgs e)
         {
             if ((!string.IsNullOrEmpty(txtquantity.Text)) && char.IsDigit(txtquantity.Text,txtquantity.Text.Length-1))
             {
                 string qurry1 = "select CurrentQuantity from ItemQuantityDetail ";
                 DataTable dt1 = d.getDetailByQuery(qurry1);
                 string id1 = " ";
                 foreach (DataRow dr in dt1.Rows)
                 {
                     id1 = dr["CurrentQuantity"].ToString();
                 }
                 int que = 0;
                 int quantity = Convert.ToInt32(txtquantity.Text);
                 int rate = Convert.ToInt32(txtrate.Text);
                 que=quantity*rate;
                 txtammount.Text = que.ToString();
                 if (que < quantity)
                 {
                     txtquantity.Text = "";
                     txtammount.Text= "";
                 }
             }
         }

         private void butAdditem_Click(object sender, EventArgs e)
         {
           
             DataRow dr = addToCartTable.NewRow();
             dr[0] = txtitemcode.Text.Trim();
             dr[1] = txtproductname.Text.Trim();
             dr[2] = txtrate.Text.Trim();
             dr[3] = txtquantity.Text.Trim();
             dr[4] = txtammount.Text.Trim();
             addToCartTable.Rows.Add(dr);
             gridsalesinvoice.DataSource = addToCartTable;
             double totalAmount = Convert.ToDouble(txttotalammount.Text);
             totalAmount += Convert.ToDouble(txtammount.Text.Trim());
             txttotalammount.Text = totalAmount.ToString();

             txtitemcode.Text = "I";
             txtproductname.Text= "";
             txtrate.Text = "";
             txtquantity.Text = "";
             txtammount.Text = "";
             txtitemcode.Focus();
         }

         private void salesinvoice_Load(object sender, EventArgs e)
         {
             butRemoveItem.Visible = true;
             butAdditem.Visible = true;
             dtpdate.Value = DateTime.Now;
             txtCustcode.Text = "C";
             txtitemcode.Text = "I";
             panel2.Visible = false;
             Purchase.PurchaseDetails purChaseDetailObj = new Purchase.PurchaseDetails();
             vendorDetails = purChaseDetailObj.GetVendorDetaisInDataTable();
             ItemDetails = purChaseDetailObj.GetItemPriceAndNameDetaisInDataTable();
             setAutoCompleteMode(txtproductname, "ItemName", ItemDetails);
             setAddToCraftTable();
             string selectquery = "select  invoiceid from salesinvoice";
             DataTable dt3 = d.getDetailByQuery(selectquery);
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
         }

         private void butRemoveItem_Click(object sender, EventArgs e)
         {
            
             if (addToCartTable.Rows.Count > 0)
             {
                 string Amount = gridsalesinvoice.SelectedRows[0].Cells[4].Value.ToString();
                 double totalAmount = Convert.ToDouble(txttotalammount.Text);
                 totalAmount -= Convert.ToDouble(Amount.Trim());
                 txttotalammount.Text = totalAmount.ToString();
                 int index = gridsalesinvoice.SelectedRows[0].Index;
                 addToCartTable.Rows.RemoveAt(index);

                 gridsalesinvoice.DataSource = addToCartTable;
                 if (addToCartTable.Rows.Count == 0)
                 {
                     txttotalammount.Text = "0.0";
                     txtdiscount.Text = "0.0";
                 }
             }
         }

         private void button5_Click(object sender, EventArgs e)
         {
             if (txtRefNo.Text == "")
             {
                 string delivary = "select Delivaryid from salesOrderDelivery";
                 DataTable dt3 = d.getDetailByQuery(delivary);
                 string delivaryid = "";
                 foreach (DataRow dr in dt3.Rows)
                 {
                     delivaryid = dr[0].ToString();
                    
                 }
                 int del = Convert.ToInt32(delivaryid);
                 int deli = del + 1;
                 string order = "select orderid from orderdetails ";
                 DataTable d1 = d.getDetailByQuery(order);
                 string id = "";
                 foreach (DataRow dr in d1.Rows)
                 {
                     id = dr[0].ToString();
                 }
                 if (id == "")
                 {
                     id = "1";
                     string insertquery = "insert into  orderdetails values('" + txtCustcode.Text + "','" + dtpdate.Text + "','" + txttotalammount.Text + "')";
                     int insertrows = d.saveDetails(insertquery);
                     if (insertrows > 0)
                     {

                         DataGridViewRowCollection rowcollection = gridsalesinvoice.Rows;
                         List<string> show = new List<string>();
                         for (int a = 0; a < rowcollection.Count; a++)
                         {
                             DataGridViewRow currentrow = rowcollection[a];
                             DataGridViewCellCollection cellcollection = currentrow.Cells;
                             string txtitemcode = cellcollection[0].Value.ToString();
                             string txtProductName = cellcollection[1].Value.ToString();
                             string txtRate = cellcollection[2].Value.ToString();
                             string txtQuantity = cellcollection[3].Value.ToString();
                             string txtAmount = cellcollection[4].Value.ToString();
                             string Orderid = id;
                             string query = "insert into customerorderdescriptions Values('" + Orderid + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";

                             show.Add(query);
                         }

                         int inserirow1 = d.saveDetails(show);
                         if (inserirow1 > 0)
                         {
                             string salesdelivary = "Insert into salesOrderDelivery values('" + id + "','true','" + dtpdate.Text + "')";
                             int insertrow = d.saveDetails(salesdelivary);
                             string invoice = "Insert into salesinvoice values('" + deli + "','" + id + "','" + dtpdate.Text + "')";
                             int insertrow1 = d.saveDetails(invoice);
                             if (insertrow1 > 0)
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
                 else
                 {
                     int id1 = Convert.ToInt32(id);
                     int id2 = id1 + 1;
                     string Orde = id2.ToString();
                     string insertquery1 = "insert into  orderdetails values('" + txtCustcode.Text + "','" + dtpdate.Text + "','" + txttotalammount.Text + "')";
                     int insertrows1 = d.saveDetails(insertquery1);
                     if (insertrows1 > 0)
                     {

                         DataGridViewRowCollection rowcollection1 = gridsalesinvoice.Rows;
                         List<string> show1 = new List<string>();
                         for (int a = 0; a < rowcollection1.Count; a++)
                         {
                             DataGridViewRow currentrow = rowcollection1[a];
                             DataGridViewCellCollection cellcollection = currentrow.Cells;
                             string txtitemcode = cellcollection[0].Value.ToString();
                             string txtProductName = cellcollection[1].Value.ToString();
                             string txtRate = cellcollection[2].Value.ToString();
                             string txtQuantity = cellcollection[3].Value.ToString();
                             string txtAmount = cellcollection[4].Value.ToString();
                             string Orderid = id2.ToString();
                             string query = "insert into customerorderdescriptions Values('" + Orderid + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";

                             show1.Add(query);
                         }

                         int inserirow2 = d.saveDetails(show1);
                         if (inserirow2 > 0)
                         {
                             string salesdelivary = "Insert into salesOrderDelivery values('" + id2.ToString() + "','true','" + dtpdate.Text + "')";
                             int insertrow = d.saveDetails(salesdelivary);
                             string invoice = "Insert into salesinvoice values('" + deli+ "','" + id2.ToString()+ "','" + dtpdate.Text + "')";
                             int insertrow2 = d.saveDetails(invoice);
                             if (insertrow2 > 0)
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
             if (txtRefNo.Text != "")
             {
                 string delivary = "select Delivaryid from salesOrderDelivery";
                 DataTable dt3 = d.getDetailByQuery(delivary);
                 string delivaryid = txtRefNo.Text;
                 //foreach (DataRow dr in dt3.Rows)
                 //{
                 //    delivaryid = dr[0].ToString();

                 //}
                 //int del = Convert.ToInt32(delivaryid);
                 //int deli = del + 1;
               
                     string order = "select Orderid from salesOrderDelivery where Delivaryid ='" + txtRefNo.Text + "' ";
                     DataTable d1 = d.getDetailByQuery(order);
                     string id = "";
                     foreach (DataRow dr in d1.Rows)
                     {
                         id = dr[0].ToString();
                     }
                     string update = "update orderdetails set totalammount='" + txttotalammount.Text + "'where Orderid='" + id + "'";
                     int c = d.saveDetails(update);
                     string deletequrri1 = "delete customerorderdescriptions where OrderId='" + id + "'";
                     DataTable dt1 = d.getDetailByQuery(deletequrri1);
                     string insertquery = "insert into  orderdetails values('" + txtCustcode.Text + "','" + dtpdate.Text + "','" + txttotalammount.Text + "')";
                     int insertrows = d.saveDetails(insertquery);
                     if (insertrows > 0)
                     {

                         DataGridViewRowCollection rowcollection = gridsalesinvoice.Rows;
                         List<string> show = new List<string>();
                         for (int a = 0; a < rowcollection.Count; a++)
                         {
                             DataGridViewRow currentrow = rowcollection[a];
                             DataGridViewCellCollection cellcollection = currentrow.Cells;
                             string txtitemcode = cellcollection[0].Value.ToString();
                             string txtProductName = cellcollection[1].Value.ToString();
                             string txtRate = cellcollection[2].Value.ToString();
                             string txtQuantity = cellcollection[3].Value.ToString();
                             string txtAmount = cellcollection[4].Value.ToString();
                             // string Orderid = id;
                             string query = "insert into customerorderdescriptions Values('" + id + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";

                             show.Add(query);
                         }

                         int inserirow1 = d.saveDetails(show);
                         if (inserirow1 > 0)
                         {
                             string salesdelivary = "Update  salesOrderDelivery set DeliveryDate='" + dtpdate.Text + "' where delivaryid='" + delivaryid + "'";
                             int insertrow = d.saveDetails(salesdelivary);
                             string invoic = "Insert into salesinvoice values('" + txtRefNo.Text + "','" + id + "','" + dtpdate.Text + "')";
                             int insertrow1 = d.saveDetails(invoic);
                             if (insertrow1 > 0)
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
             
             int id3 = Convert.ToInt32(txtSrNo.Text);
             int id4 = id3 + 1;
             txtSrNo.Text = id4.ToString();
             Form5 s = new Form5(id3.ToString());
             s.Show();
                 makeblank();
                 
             }   
            
    
         
             
         
            
         
         private void setAutoCompleteMode(TextBox txt, string ColumnName, DataTable dt)
         {
             if (dt != null && dt.Rows.Count > 0)
             {
                 AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                 foreach (DataRow dr in dt.Rows)
                 {
                     string value = dr[ColumnName].ToString();
                     collection.Add(value);
                 }

                 txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                 txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                 txt.AutoCompleteCustomSource = collection;

             }
         }
         private void makeblank()
         {
             txtCustcode.Text = "";
             txtcustname.Text = "";
             txtcustcompname.Text = "";
             txtcustaddress.Text = "";
             txtcustphone.Text = "";
             txtcustmobile.Text = "";
            txtcustfax.Text = "";
             txtRefNo.Text = "";
             addToCartTable.Clear();
            gridsalesinvoice.DataSource = "";
         }

         private void setAddToCraftTable()
         {
             addToCartTable.Columns.Add(new DataColumn("ItemCode"));
             addToCartTable.Columns.Add(new DataColumn("ProductName"));
             addToCartTable.Columns.Add(new DataColumn("Rate"));
             addToCartTable.Columns.Add(new DataColumn("Quantity"));
             addToCartTable.Columns.Add(new DataColumn("Amount"));
         }

         private void butclose_Click(object sender, EventArgs e)
         {
             this.Close();
         }

         private void txtquantity_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (char.IsDigit(e.KeyChar))
             {
                 e.Handled = false;
             }
             else
             {
                 if (e.KeyChar == '\b')
                 {
                     txtammount.Text = "";
                     e.Handled = false;
                 }
                 else
                 {
                     e.Handled = true;
                 }
             }

         }

         private void txtsearchvalue_TextChanged(object sender, EventArgs e)
         {
             if (counter == 0)
             {
                 string s = comserchvalue.SelectedValue.ToString();
                 string val = s;
                 string selectQuery = "select CustId,CustName,CustCompName,CustAddress,CustPhone,Custmobile,CustFax from CustomerDetails where " + val + " like '" + txtsearchvalue.Text + "%'";
                 DataTable dt = d.getDetailByQuery(selectQuery);
                 dataGridView2.DataSource = dt;
             }
             else if (counter == 1)
             {
                 string s1 = comserchvalue.SelectedValue.ToString();
                 string val1 = s1;
                 string selectQuery1 = "select it.itemid,it.ItemName,ip.Mrpprice,iq.CurrentQuantity from ItemDetails it join ItemPriceDetail ip on it.Itemid=ip.Itemid join ItemQuantityDetail iq on ip.ItemId=iq.Itemid where " + val1 + " like '" + txtsearchvalue.Text + "%'";
                 DataTable dt1 = d.getDetailByQuery(selectQuery1);
                 dataGridView2.DataSource = dt1;
             }
             else if (counter == 2)
             {
                 string s2 = comserchvalue.SelectedValue.ToString();
                 string val2 = s2;
                 string selectQuery2 = "select Orderid,Custid,date,totalammount from Orderdetails where " + val2 + " like '" + txtsearchvalue.Text + "%'";
                 DataTable dt2 = d.getDetailByQuery(selectQuery2);
                 dataGridView2.DataSource = dt2;
             }
         }

         private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
         {
             if (counter == 0)
             {
                 DataGridViewCellCollection Collection = dataGridView2.Rows[e.RowIndex].Cells;
                 rowcollection(Collection);
                 panel2.Visible = false;
             }
             if (counter == 1)
             {
                 DataGridViewCellCollection Collection1 = dataGridView2.Rows[e.RowIndex].Cells;
                 rowcollection1(Collection1);
                 panel2.Visible = false;
             }
             if (counter == 2)
             {
                 panel2.Visible = false;
                 panel1.Visible = true;
                 DataGridViewCellCollection dell = dataGridView2.Rows[e.RowIndex].Cells;
                 string val = dell[0].Value.ToString();
                 txtRefNo.Text = val;
                 //string selectquery1 = "select i.itemid,id.itemname,i.price,i.quantity,i.totalprice from customerorderdescriptions i join ItemDetails id on i.itemid=id.ItemId where orderid='" + val + "'";
                 //DataTable dt1 = d.getDetailByQuery(selectquery1);
                 //gridsalesinvoice.DataSource = dt1;
             }
         }

         private void butselectpurchasedelivary_Click(object sender, EventArgs e)
         {
             string selectquery1 = "select OrderId ,CustId,date,Totalammount from orderdetails";
             DataTable dt1 = d.getDetailByQuery(selectquery1);
             string val = " ";
             List<string> sd = new List<string>();
             foreach (DataColumn dr in dt1.Columns)
             {
                 val = dr.ColumnName;
                 sd.Add(val);
             }
             comserchvalue.DataSource = sd;
             counter = 2;
             panel2.Visible = true;
             string selectquery = "select orderid,custid,date,totalammount from orderdetails";
             DataTable dt = d.getDetailByQuery(selectquery);
             dataGridView2.DataSource = dt;
         }
         private void gridsalesinvoice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
         {
             DataGridViewCellCollection Collection1 = dataGridView2.Rows[e.RowIndex].Cells;
             rowcollection1(Collection1);
             panel1.Visible = false;
         }

         private void txtCustcode_TextChanged(object sender, EventArgs e)
         {
             string selectquery = "select CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from CustomerDetails Where Custid='" + txtCustcode.Text+ "'";
             DataTable dt = d.getDetailByQuery(selectquery);
             if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
             {
                 foreach (DataRow dr in dt.Rows)
                 {
                     txtcustname.Text = dr[0].ToString();
                     txtcustcompname.Text = dr[1].ToString();
                     txtcustaddress.Text = dr[2].ToString();
                     txtcustphone.Text = dr[3].ToString();
                     txtcustmobile.Text = dr[4].ToString();
                     txtcustfax.Text = dr[5].ToString();

                 }
             }
             else
             {
                 txtcustname.Text = "";
                 txtcustcompname.Text = "";
                 txtcustaddress.Text = "";
                 txtcustphone.Text = "";
                 txtcustmobile.Text = "";
                 txtcustfax.Text = "";
             }
         }

         private void txtRefNo_TextChanged(object sender, EventArgs e)
         {
             string selectquery = "select Delivaryid from salesinvoice where Delivaryid='" + txtRefNo.Text + "'";
             DataTable dt = d.getDetailByQuery(selectquery);
             if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
             {
                 button5.Enabled = false;
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
                         txtCustcode.Text = dr1[0].ToString();
                         txtcustname.Text = dr1[1].ToString();
                         txtcustcompname.Text = dr1[2].ToString();
                         txtcustaddress.Text = dr1[3].ToString();
                         txtcustphone.Text = dr1[4].ToString();
                         txtcustmobile.Text = dr1[5].ToString();
                         txtcustfax.Text = dr1[6].ToString();
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
                     dr1 = addToCartTable.NewRow();
                     dr1[0] = t.Trim();
                     dr1[1] = t2.Trim();
                     dr1[2] = t1.Trim();
                     dr1[3] = t3.Trim();
                     dr1[4] = totalamt.Trim();
                     addToCartTable.Rows.Add(dr1);

                 }

                 gridsalesinvoice.DataSource = addToCartTable;
                 txttotalammount.Text = totel.ToString();
             
         }
         

         private void button1_Click(object sender, EventArgs e)
         {
             panel2.Visible = false;
         }

         private void txtitemcode_TextChanged(object sender, EventArgs e)
         {
             string selectquery1 = "select i.ItemId,i.ItemName,ip.MrpPrice,iq.CurrentQuantity from ItemDetails i join ItemPriceDetail ip on i.ItemId=ip.ItemId join ItemQuantityDetail iq on ip.ItemId=iq.ItemId where i.ItemId='" + txtitemcode.Text + "'";
             DataTable dt = d.getDetailByQuery(selectquery1);
             if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
             {
                 foreach (DataRow dr in dt.Rows)
                 {
                     txtproductname.Text = dr[1].ToString();
                     txtrate.Text = dr[2].ToString();

                 }
             }
             else
             {
                 txtproductname.Text = "";
                 txtrate.Text = "";
             }
         }

       
    }

    }

