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
         counter = 0;
            panel2.Visible = true;
            string selectquery = "select Custid, CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from customerdetails";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView2.DataSource = dt;
        }
       

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                // string val1 = dell[1].Value.ToString();
                txtSrNo.Text = val;
                //string selectquery = "select custid,CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from CustomerDetails where custid='" + val1 + "'";
                //DataTable dt = d.getDetailByQuery(selectquery);
                //foreach (DataRow dr in dt.Rows)
                //{
                //    txtcustomercode.Text = dr[0].ToString();
                //    txtCustomerName.Text = dr[1].ToString();
                //    txtCompName.Text = dr[2].ToString();
                //    txtAddress.Text = dr[3].ToString();
                //    txtPhone.Text = dr[4].ToString();
                //    txtMobile.Text = dr[5].ToString();
                //    txtFax.Text = dr[6].ToString();
                //}
                string selectquery1 = "select i.itemid,id.itemname,i.price,i.quantity,i.totalprice from customerorderdescription i join ItemDetails id on i.itemid=id.ItemId where orderid='" + val + "'";
                DataTable dt1 = d.getDetailByQuery(selectquery1);
                gridsalesinvoice.DataSource = dt1;
            }
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
             txtammount.Text= "0.0";

         }

         private void butitembutton_Click(object sender, EventArgs e)
         {
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
                 int que = maxquantity;
                 int quantity = Convert.ToInt32(txtquantity.Text);
                 int rate = Convert.ToInt32(txtrate.Text);
                 txtammount.Text = (quantity * rate).ToString();
                 if (que < quantity)
                 {
                     txtquantity.Text = "";
                     txtammount.Text= "0.00";
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
             txtammount.Text = "0.0";
             txtitemcode.Focus();
         }

         private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {
             DataGridViewCellCollection Collection1 = dataGridView2.Rows[e.RowIndex].Cells;
             rowcollection1(Collection1);
             panel1.Visible = false;
         }

         private void salesinvoice_Load(object sender, EventArgs e)
         {
             panel2.Visible = false;
             Purchase.PurchaseDetails purChaseDetailObj = new Purchase.PurchaseDetails();
             vendorDetails = purChaseDetailObj.GetVendorDetaisInDataTable();
             ItemDetails = purChaseDetailObj.GetItemPriceAndNameDetaisInDataTable();
             setAutoCompleteMode(txtproductname, "ItemName", ItemDetails);
             setAddToCraftTable();
             string selectquery = "select max orderid from orderdetail";
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
             counter = 0;
             if (counter == 0)
             {
                 string insertquery = "insert into orderdetail values('" + txtCustcode.Text + "','" + dtpdate.Text+ "','" + txttotalammount.Text + "')";
                 int insertrows = d.saveDetails(insertquery);
                 if (insertrows > 0)
                 {
                     MessageBox.Show("details save successfully");
                 }
                 else
                 {
                     MessageBox.Show("details save not successfully");
                 }
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
                     string Orderid = txtSrNo.Text;
                     string query = "insert into customerorderdescription Values('" + Orderid + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";
                     show.Add(query);
                 }

                 int inserirow1 = d.SaveDetails(show);
                 if (inserirow1 > 0)
                 {
                     MessageBox.Show("details save successfully");
                 }
                 else
                 {
                     MessageBox.Show("details save not successfully");
                 }

             }
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
         private void setAddToCraftTable()
         {
             addToCartTable.Columns.Add(new DataColumn("ItemCode"));
             addToCartTable.Columns.Add(new DataColumn("ProductName"));
             addToCartTable.Columns.Add(new DataColumn("Rate"));
             addToCartTable.Columns.Add(new DataColumn("Quantity"));
             addToCartTable.Columns.Add(new DataColumn("Amount"));
         }

         private void ButSelectPurchaseOrder_Click(object sender, EventArgs e)
         {
             counter = 2;
             panel2.Visible = true;
             string selectquery = "select orderid,custid,date,totalprice from orderdetail";
             DataTable dt = d.getDetailByQuery(selectquery);
             dataGridView2.DataSource = dt;
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


        }

    }

