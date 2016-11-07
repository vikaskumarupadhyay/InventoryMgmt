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
    public partial class salesorder : Form
    {

        DB_Main d = new DB_Main();
        public salesorder()
        {
            InitializeComponent();

        }
        public int maxItemQuantity = 0;
        public int counter = 0;
        DataTable vendorDetails = new DataTable();
        DataTable addToCartTable = new DataTable();
        DataTable customerdetails = new DataTable();
        DataTable ItemDetails = new DataTable();
        private void button1_Click(object sender, EventArgs e)
        {
            counter = 0;
            panel2.Visible = true;
            string selectquery = "select Custid, CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from customerdetails";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView2.DataSource = dt;

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
        }
        public void rowcollection(DataGridViewCellCollection cell)
        {
            txtcustomercode.Text = cell[0].Value.ToString();
            textBox2.Text = cell[1].Value.ToString();
            textBox3.Text = cell[2].Value.ToString();
            textBox4.Text = cell[3].Value.ToString();
            textBox5.Text = cell[4].Value.ToString();
            textBox6.Text = cell[5].Value.ToString();
            textBox7.Text = cell[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            counter = 1;
            panel2.Visible = true;
            string selectquery = "select i.Itemid,i.Itemname,ip.MrpPrice,iq.CurrentQuantity from itemdetails i join itempricedetail ip on i.itemid=ip.itemid join itemquantitydetail iq on ip.itemid=iq.itemid";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView2.DataSource = dt;
        }

        public void rowcollection1(DataGridViewCellCollection cell1)
        {
            txtitemcode.Text = cell1[0].Value.ToString();
            txtProductName.Text = cell1[1].Value.ToString();
            txtRate.Text = cell1[2].Value.ToString();
            maxItemQuantity = Convert.ToInt32((cell1[3].Value.ToString()));
            txtAmount.Text = "0.0";

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(txtQuantity.Text)) && char.IsDigit(txtQuantity.Text, txtQuantity.Text.Length - 1))
            {
                int que = maxItemQuantity;
                int quantity = Convert.ToInt32(txtQuantity.Text);
                int rate = Convert.ToInt32(txtRate.Text);
                txtAmount.Text = (quantity * rate).ToString();

                if (que < quantity)
                {
                    txtQuantity.Text = "";
                    txtAmount.Text = "0.0";
                }
            }
        }
        private void butadditem_Click(object sender, EventArgs e)
        {
            //string query = "select CurrentQuantity from ItemQuantityDetail where Itemid='" + txtitemcode.Text + "'";
            //DataTable dt = d.getDetailByQuery(query);
            //string id = "";
            //foreach (DataRow dr in dt.Rows)
            //{
            //    id = dr["CurrentQuantity"].ToString();
            //}
            //int currentQuantity1 = maxItemQuantity;
            //int currentquantity = Convert.ToInt32(txtQuantity.Text);
            //if (currentquantity == 0)
            //{
            //    MessageBox.Show("now current quantity is not available");
            //    txtQuantity.Text = "";
            //}
            //else
            //{
            //    if (currentQuantity1 < currentquantity)
            //    {
            //        MessageBox.Show("now current quantity is not available");
            //    }

                DataRow dr = addToCartTable.NewRow();
                dr[0] = txtitemcode.Text.Trim();
                dr[1] = txtProductName.Text.Trim();
                dr[2] = txtRate.Text.Trim();
                dr[3] = txtQuantity.Text.Trim();
                dr[4] = txtAmount.Text.Trim();
                addToCartTable.Rows.Add(dr);
                gridsalesorder.DataSource = addToCartTable;
                double totalAmount = Convert.ToDouble(txttotalammount.Text);
                totalAmount = Convert.ToDouble(txtAmount.Text.Trim());
                txttotalammount.Text = totalAmount.ToString();

                txtitemcode.Text = "I";
                txtProductName.Text = "";
                txtRate.Text = "";
                txtQuantity.Text = "";
                txtAmount.Text = "0.0";
                txtitemcode.Focus();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection Collection1 = dataGridView2.Rows[e.RowIndex].Cells;
            rowcollection1(Collection1);
            panel1.Visible = false;
        }

        private void salesorder_Load(object sender, EventArgs e)
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
                txtsrno.Text = id;
            }
            else
            {
                int t = Convert.ToInt32(id);
                int t1 = t + 1;
                txtsrno.Text = t1.ToString();
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (addToCartTable.Rows.Count > 0)
            {
                string Amount = gridsalesorder.SelectedRows[0].Cells[4].Value.ToString();
                double totalAmount = Convert.ToDouble(txttotalammount.Text);
                totalAmount -= Convert.ToDouble(Amount.Trim());
                txttotalammount.Text = totalAmount.ToString();
                int index = gridsalesorder.SelectedRows[0].Index;
                addToCartTable.Rows.RemoveAt(index);

                gridsalesorder.DataSource = addToCartTable;
                if (addToCartTable.Rows.Count == 0)
                {
                    txttotalammount.Text = "0.0";
                    txtdiscount.Text = "0.0";
                }
            }
        }

        private void savebutton_Click(object sender, EventArgs e)
        {

                counter = 0;
                if (counter == 0)
                {
                    string insertquery = "insert into orderdetail values('" + txtcustomercode.Text + "','" + txtdate.Text + "','" + txttotalammount.Text + "')";
                    int insertrows = d.saveDetails(insertquery);
                    if (insertrows > 0)
                    {
                        MessageBox.Show("details save successfully");
                    }
                    else
                    {
                        MessageBox.Show("details save not successfully");
                    }
                    DataGridViewRowCollection rowcollection = gridsalesorder.Rows;
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
                        string Orderid = txtsrno.Text;
                        string query = "insert into customerorderdescription Values('" + Orderid + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";
                        show.Add(query);
                    }

                    int inserirow1 = d.saveDetails(show);
                    if(inserirow1>0)
                    {
                        MessageBox.Show("details save successfully");
                    }
                    else
                    {
                        MessageBox.Show("details save not successfully");
                    }
                }

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
                    txtAmount.Text = "";
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

