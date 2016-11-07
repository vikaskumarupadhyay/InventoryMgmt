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
    public partial class salesdelivary : Form
    {
        DB_Main d = new DB_Main();
        public salesdelivary()
        {
            InitializeComponent();
        }
        public int maxquantity = 0;
        public int counter = 0;
        DataTable vendorDetails = new DataTable();
        DataTable addToCartTable = new DataTable();
        DataTable customerdetails = new DataTable();
        DataTable ItemDetails = new DataTable();
        private void butcustomercode_Click(object sender, EventArgs e)
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
                string selectquery1 = "select i.itemid,id.itemname,i.price,i.quantity,i.totalprice from customerorderdescription i join ItemDetails id on i.itemid=id.ItemId where orderid='"+val+"'";
                DataTable dt1 = d.getDetailByQuery(selectquery1);
                gridsalesdelivary.DataSource = dt1;
        }
        }
         public void rowcollection(DataGridViewCellCollection cell)
        {
            txtcustomercode.Text = cell[0].Value.ToString();
            txtCustomerName.Text = cell[1].Value.ToString();
            txtCompName.Text= cell[2].Value.ToString();
            txtAddress.Text = cell[3].Value.ToString();
            txtPhone.Text = cell[4].Value.ToString();
            txtMobile.Text = cell[5].Value.ToString();
            txtFax.Text = cell[6].Value.ToString();
        }
         public void rowcollection1(DataGridViewCellCollection cell1)
         {
             txtItemCode.Text = cell1[0].Value.ToString();
             txtProductName.Text = cell1[1].Value.ToString();
             txtRate.Text = cell1[2].Value.ToString();
             maxquantity =Convert.ToInt32(cell1[3].Value.ToString());
             txtQuantity.Text = "";
             txtAmmount.Text= "0.0";

         }
       

         private void butitembutton_Click(object sender, EventArgs e)
         {
             counter = 1;
             panel2.Visible = true;
             string selectquery = "select i.Itemid,i.Itemname,ip.MrpPrice,iq.CurrentQuantity from itemdetails i join itempricedetail ip on i.itemid=ip.itemid join itemquantitydetail iq on ip.itemid=iq.itemid";
             DataTable dt = d.getDetailByQuery(selectquery);
             dataGridView2.DataSource = dt;
         }

         private void txtQuantity_TextChanged(object sender, EventArgs e)
         {
             if ((!string.IsNullOrEmpty(txtQuantity.Text)) && char.IsDigit(txtQuantity.Text, txtQuantity.Text.Length - 1))
             {
                 string qurry1 = "select CurrentQuantity from ItemQuantityDetail ";
                 DataTable dt1 = d.getDetailByQuery(qurry1);
                 string id1 = " ";
                 foreach (DataRow dr in dt1.Rows)
                 {
                     id1 = dr["CurrentQuantity"].ToString();
                 }
                 int que = maxquantity;
                 int quantity = Convert.ToInt32(txtQuantity.Text);
                 int rate = Convert.ToInt32(txtRate.Text);
                 txtAmmount.Text = (quantity * rate).ToString();
                 if (que < quantity)
                 {
                     txtQuantity.Text = "";
                     txtAmmount.Text = "0.00";
                 }
             }

         }

         private void butAddItem_Click(object sender, EventArgs e)
         {
             DataRow dr = addToCartTable.NewRow();
             dr[0] = txtItemCode.Text.Trim();
             dr[1] = txtProductName.Text.Trim();
             dr[2] = txtRate.Text.Trim();
             dr[3] = txtQuantity.Text.Trim();
             dr[4] = txtAmmount.Text.Trim();
             addToCartTable.Rows.Add(dr);
             gridsalesdelivary.DataSource = addToCartTable;
             double totalAmount = Convert.ToDouble(txtTotalAmmount.Text);
             totalAmount += Convert.ToDouble(txtAmmount.Text.Trim());
             txtTotalAmmount.Text = totalAmount.ToString();

             txtItemCode.Text = "I";
             txtProductName.Text = "";
             txtRate.Text = "";
             txtQuantity.Text = "";
             txtAmmount.Text = "0.0";
             txtItemCode.Focus();
         }

         private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {
             DataGridViewCellCollection Collection1 = dataGridView2.Rows[e.RowIndex].Cells;
             rowcollection1(Collection1);
             panel1.Visible = false;
         }

         private void salesdelivary_Load(object sender, EventArgs e)
         {
             panel2.Visible = false;
             Purchase.PurchaseDetails purChaseDetailObj = new Purchase.PurchaseDetails();
             vendorDetails = purChaseDetailObj.GetVendorDetaisInDataTable();
             ItemDetails = purChaseDetailObj.GetItemPriceAndNameDetaisInDataTable();
             setAutoCompleteMode(txtProductName, "ItemName", ItemDetails);
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
                 string Amount = gridsalesdelivary.SelectedRows[0].Cells[4].Value.ToString();
                 double totalAmount = Convert.ToDouble(txtTotalAmmount.Text);
                 totalAmount -= Convert.ToDouble(Amount.Trim());
                 txtTotalAmmount.Text = totalAmount.ToString();
                 int index = gridsalesdelivary.SelectedRows[0].Index;
                 addToCartTable.Rows.RemoveAt(index);

                 gridsalesdelivary.DataSource = addToCartTable;
                 if (addToCartTable.Rows.Count == 0)
                 {
                     txtTotalAmmount.Text = "0.0";
                     txtDiscount.Text = "0.0";
                 }
             }
         }

         private void butSaveButton_Click(object sender, EventArgs e)
         {
             counter = 0;
             if (counter == 0)
             {
                 string insertquery = "insert into orderdetail values('" + txtcustomercode.Text + "','" + dtpDate.Text + "','" + txtTotalAmmount.Text + "')";
                 int insertrows = d.saveDetails(insertquery);
                 if (insertrows > 0)
                 {
                     MessageBox.Show("details save successfully");
                 }
                 else
                 {
                     MessageBox.Show("details save not successfully");
                 }
                 DataGridViewRowCollection rowcollection = gridsalesdelivary.Rows;
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

                 int inserirow1 = d.saveDetails(show);
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

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    txtAmmount.Text = "";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = false;
                }
            }
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         }
        }


