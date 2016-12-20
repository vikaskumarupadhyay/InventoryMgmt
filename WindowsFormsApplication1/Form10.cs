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
           
            string selectquery1 = "select CustName,CustCompName,CustAddress,CustPhone,Custmobile,CustFax from CustomerDetails";
            DataTable dt1 = d.getDetailByQuery(selectquery1);
            string val = " ";
            List<string> sd = new List<string>();
            foreach (DataColumn dr in dt1.Columns)
            {
                val = dr.ColumnName;
                sd.Add(val);
            }
            comsearchsalesvalue.DataSource = sd;

            counter = 0;
            panel2.Visible = true;
            string selectquery = "select Custid, CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from customerdetails";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView1.DataSource = dt;

        }
        public void rowcollection(DataGridViewCellCollection cell)
        {
           txtcustomercode.Text = cell[0].Value.ToString();
            txtcustname.Text = cell[1].Value.ToString();
            txtcustcompname.Text = cell[2].Value.ToString();
            txtcustaddress.Text = cell[3].Value.ToString();
            txtcustphone.Text = cell[4].Value.ToString();
            txtcustmobile.Text = cell[5].Value.ToString();
            txtcustfax.Text = cell[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            counter = 1;
            string selectquery1="select it.ItemName,ip.Mrpprice,iq.CurrentQuantity from ItemDetails it join ItemPriceDetail ip on it.Itemid=ip.Itemid join ItemQuantityDetail iq on ip.ItemId=iq.Itemid";
            DataTable dt1 = d.getDetailByQuery(selectquery1);
            string val = " ";
            List<string> sd = new List<string>();
            foreach (DataColumn dr in dt1.Columns)
            {
                val = dr.ColumnName;
                sd.Add(val);
            }
            comsearchsalesvalue.DataSource = sd;
            panel2.Visible = true;
            string selectquery = "select i.Itemid,i.Itemname,ip.MrpPrice,iq.CurrentQuantity from itemdetails i join itempricedetail ip on i.itemid=ip.itemid join itemquantitydetail iq on ip.itemid=iq.itemid";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView1.DataSource = dt;
        }

        public void rowcollection1(DataGridViewCellCollection cell1)
        {
            txtitemcode.Text = cell1[0].Value.ToString();
            txtProductName.Text = cell1[1].Value.ToString();
            txtRate.Text = cell1[2].Value.ToString();
            maxItemQuantity = Convert.ToInt32((cell1[3].Value.ToString()));
            txtAmount.Text = "";

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txtQuantity.Text)) && char.IsDigit(txtQuantity.Text, txtQuantity.Text.Length - 1))
            {
                int que = maxItemQuantity;
                int quantity = Convert.ToInt32(txtQuantity.Text);
                int rate = Convert.ToInt32(txtRate.Text);
                txtAmount.Text = (quantity * rate).ToString();
            }

            //else if (que < quantity)
            //{
            //    txtQuantity.Text = "";
            //    txtAmount.Text = "";
            //}
        }
        private void makeblank()
        {
            txtcustomercode.Text = "C";
            txtcustname.Text = "";
            txtcustcompname.Text = "";
            txtcustaddress.Text = "";
            txtcustphone.Text = "";
            txtcustmobile.Text = "";
            txtcustfax.Text = "";
            txtitemcode.Text = " I";
            txtProductName.Text = "";
            txtRate.Text = "";
            txtQuantity.Text="";
            txtAmount.Text="";
            gridsalesorder.DataSource = "";
            txttotalammount.Text = "";
            addToCartTable.Clear();
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
               // textBox14.Text = dr[4].ToString();
                dr[4] = txtAmount.Text.Trim();
                addToCartTable.Rows.Add(dr);
                gridsalesorder.DataSource = addToCartTable;
                double totalAmount = Convert.ToDouble(txttotalammount.Text);
                totalAmount += Convert.ToDouble(txtAmount.Text.Trim());
                txttotalammount.Text = totalAmount.ToString();

                txtitemcode.Text = "I";
                txtProductName.Text = "";
                txtRate.Text = "";
                txtQuantity.Text = "";
                //textBox14.Text = "";
                txtAmount.Text = "";
                txtitemcode.Focus();
        }
    

        private void salesorder_Load(object sender, EventArgs e)
        {
            dtpdate.Value = DateTime.Now;
            txtcustomercode.Text = "C";
            txtitemcode.Text = "I";
            panel2.Visible = false;
            Purchase.PurchaseDetails purChaseDetailObj = new Purchase.PurchaseDetails();
            vendorDetails = purChaseDetailObj.GetVendorDetaisInDataTable();
            ItemDetails = purChaseDetailObj.GetItemPriceAndNameDetaisInDataTable();
            setAutoCompleteMode(txtProductName, "ItemName", ItemDetails);
            setAddToCraftTable();
            string selectquery = "select orderid from orderdetails";
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
           
            //if (id == "")
            //{
            //    id = "1";
            //    txtsrno.Text = id;
            //}
            //else
            //{
            //    int t = Convert.ToInt32(id);
            //    int t1 = t + 1;
            //    txtsrno.Text = t1.ToString();
            //}
               
                counter = 0;
                if (counter == 0)
                {
                    string insertquery = "insert into  orderdetails values('" + txtcustomercode.Text + "','" + dtpdate.Text + "','" + txttotalammount.Text + "')";
                    int insertrows = d.saveDetails(insertquery);
                   
                   
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
                        string query = "insert into customerorderdescriptions Values('" + txtsrno.Text + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";
                       
                        show.Add(query);
                    }

                    int inserirow1 = d.saveDetails(show);
                    if(inserirow1 > 0)
                    {
                        MessageBox.Show("details save successfully");
                    }
                    else
                    {
                        MessageBox.Show("details save not successfully");
                    }
                    int id = Convert.ToInt32(txtsrno.Text);
                    id = id + 1;
                    txtsrno.Text = id.ToString() ;
                    makeblank();
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

        private void txtsearchvalue_TextChanged(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                string s = comsearchsalesvalue.SelectedValue.ToString();
                string val = s;
                string selectQuery = "select Custid, CustName,CustCompName,CustAddress,CustPhone,Custmobile,CustFax from CustomerDetails where " + val + " like '" + txtsearchvalue.Text + "%'";
                DataTable dt = d.getDetailByQuery(selectQuery);
                dataGridView1.DataSource = dt;
            }
           else if (counter == 1)
            {
                string s1 = comsearchsalesvalue.SelectedValue.ToString();
                string val1 = s1;
                string selectQuery1 = "select it.ItemId, it.ItemName,ip.Mrpprice,iq.CurrentQuantity from ItemDetails it join ItemPriceDetail ip on it.Itemid=ip.Itemid join ItemQuantityDetail iq on ip.ItemId=iq.Itemid where " + val1 + " like '" + txtsearchvalue.Text + "%'";
                DataTable dt1 = d.getDetailByQuery(selectQuery1);
                dataGridView1.DataSource = dt1;
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = false;
            if (counter == 0)
            {
                DataGridViewCellCollection Collection = dataGridView1.Rows[e.RowIndex].Cells;
                rowcollection(Collection);
                panel2.Visible = false;
            }
            if (counter == 1)
            {
                DataGridViewCellCollection Collection1 = dataGridView1.Rows[e.RowIndex].Cells;
                rowcollection1(Collection1);
                panel2.Visible = false;
            }
            if (counter == 2)
            {
                panel2.Visible = false;
                panel1.Visible = true;
                DataGridViewCellCollection dell = dataGridView1.Rows[e.RowIndex].Cells;
                string val = dell[0].Value.ToString();
                txtsrno.Text = val;
                string selectquery1 = "select i.itemid,id.itemname,i.price,i.quantity,i.totalprice from customerorderdescriptions i join ItemDetails id on i.itemid=id.ItemId where orderid='" + val + "'";
                DataTable dt1 = d.getDetailByQuery(selectquery1);
                gridsalesorder.DataSource = dt1;
            }
        }

        private void gridsalesorder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection Collection1 = dataGridView1.Rows[e.RowIndex].Cells;
            rowcollection1(Collection1);
            panel1.Visible = false;
        }

        private void txtcustomercode_TextChanged(object sender, EventArgs e)
        {
           // if (txtcustomercode.Text.Trim() != "" && txtcustomercode.Text.StartsWith("C"))
           // {
               // setvalue();
            ///}
            string selectquery = "select CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from CustomerDetails Where Custid='" + txtcustomercode.Text + "'";
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

        private void txtitemcode_TextChanged(object sender, EventArgs e)
        {
            //int rate = Convert.ToInt32(txtRate.Text);
            //int que = Convert.ToInt32(txtQuantity.Text);
            //txtAmount.Text = (rate * que).ToString();
           
            string selectquery1 = "select i.ItemId,i.ItemName,ip.MrpPrice,iq.CurrentQuantity from ItemDetails i join ItemPriceDetail ip on i.ItemId=ip.ItemId join ItemQuantityDetail iq on ip.ItemId=iq.ItemId where i.ItemId='" + txtitemcode.Text + "'";
            DataTable dt = d.getDetailByQuery(selectquery1);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtProductName.Text = dr[1].ToString();
                    txtRate.Text = dr[2].ToString();
                    //txtRate.Text = dr[3].ToString();
                    //txtQuantity.Text = dr[3].ToString();
                   // txtAmount.Text = dr[4].ToString();
                    
                }
            }
            else
            {
                txtProductName.Text = "";
                txtRate.Text = "";
            }
        }


        private void setvalue()
        {
            if (customerdetails.Rows.Count > 0)
            {
                string Custid = txtcustomercode.Text;
                if (Custid.Trim() != "" && Custid != null)
                {
                    DataRow[] dr = customerdetails.Select("Custid='" + Custid + "'");
                    if (dr != null && dr.Length > 0)
                    {
                        string customername = dr[0]["CustName"].ToString();
                        string customercompnayname = dr[1]["CustCompName"].ToString();
                        string customeraddress = dr[2]["CustAddress"].ToString();
                        string customerphone = dr[3]["CustPhone"].ToString();
                        string customermobile = dr[4]["CustMobile"].ToString();
                        string customerFax = dr[5]["CustFax"].ToString();

                        txtcustname.Text = customername;
                        txtcustcompname.Text = customercompnayname;
                        txtcustaddress.Text = customeraddress;
                        txtcustphone.Text = customerphone;
                        txtcustmobile.Text = customermobile;
                        txtcustfax.Text = customerFax;

                    }
                    else
                    {
                        txtcustname.Text = "";
                        txtcustcompname.Text = "";
                        txtcustaddress.Text = "";
                        txtcustaddress.Text = "";
                        txtcustphone.Text = "";
                        txtcustmobile.Text = "";
                        txtcustfax.Text = "";

                    }
                }
            }
        }



        public DataGridView orderid { get; set; }

        private void butback_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

    

       
    }
}



