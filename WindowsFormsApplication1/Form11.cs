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
            string selectquery1 = "select CustName,CustCompName,CustAddress,CustPhone,Custmobile,CustFax from CustomerDetails";
            DataTable dt1 = d.getDetailByQuery(selectquery1);
            string val = " ";
            List<string> sd = new List<string>();
            foreach (DataColumn dr in dt1.Columns)
            {
                val = dr.ColumnName;
                sd.Add(val);
            }
            comsearchvalue.DataSource = sd;

            counter = 0;
            panel2.Visible = true;
            string selectquery = "select Custid, CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from customerdetails";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView2.DataSource = dt;

        }

        public void rowcollection(DataGridViewCellCollection cell)
        {
            txtcustomercode.Text = cell[0].Value.ToString();
            txtCustomerName.Text = cell[1].Value.ToString();
            txtCompName.Text = cell[2].Value.ToString();
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
            maxquantity = Convert.ToInt32((cell1[3].Value.ToString()));
            txtQuantity.Text = "";
            txtAmmount.Text = "";

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
            comsearchvalue.DataSource = sd;
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
                int que =0;
                int quantity = Convert.ToInt32(txtQuantity.Text);
                int rate = Convert.ToInt32(txtRate.Text);
                que=quantity*rate;
                txtAmmount.Text = que.ToString(); 
                if (que < quantity)
                {
                    txtQuantity.Text = "";
                    txtAmmount.Text = "";
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
            dr[4] = txtQuantity.Text.Trim();
            dr[5] = txtAmmount.Text.Trim();
            addToCartTable.Rows.Add(dr);
            gridsalesdelivary.DataSource = addToCartTable;
            double totalAmount = Convert.ToDouble(txtTotalAmmount.Text);
            totalAmount += Convert.ToDouble(txtAmmount.Text.Trim());
            txtTotalAmmount.Text = totalAmount.ToString();

            txtItemCode.Text = "I";
            txtProductName.Text = "";
            txtRate.Text = "";
            txtQuantity.Text = "";
            txtAmmount.Text = "";
            txtItemCode.Focus();
        }


        private void salesdelivary_Load(object sender, EventArgs e)
        {
            txtItemCode.Text = "I";
            dtpDate.Value = DateTime.Now;
            txtcustomercode.Text = "C";
            panel2.Visible = false;
            Purchase.PurchaseDetails purChaseDetailObj = new Purchase.PurchaseDetails();
            vendorDetails = purChaseDetailObj.GetVendorDetaisInDataTable();
            ItemDetails = purChaseDetailObj.GetItemPriceAndNameDetaisInDataTable();
            setAutoCompleteMode(txtProductName, "ItemName", ItemDetails);
            setAddToCraftTable();
            string selectquery = "select  Delivaryid from salesOrderDelivery ";
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
        private void makeblank()
        {
            txtcustomercode.Text = "C";
            txtCustomerName.Text = "";
            txtCompName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtMobile.Text = "";
            txtFax.Text = "";
            txtRefNo.Text = "";
            addToCartTable.Clear();
            gridsalesdelivary.DataSource = "";
        }

        private void butSaveButton_Click(object sender, EventArgs e)
        {

            if (txtRefNo.Text == "")
            {

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
                    string insertquery = "insert into  orderdetails values('" + txtcustomercode.Text + "','" + dtpDate.Text + "','" + txtTotalAmmount.Text + "')";
                    int insertrows = d.saveDetails(insertquery);
                    if (insertrows > 0)
                    {

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
                            string txtAmount = cellcollection[5].Value.ToString();
                            string Orderid = id;
                            string query = "insert into customerorderdescriptions Values('" + Orderid + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";
                           
                            // int insertrow = d.saveDetails(query);
                            show.Add(query);
                        }

                        int inserirow1 = d.saveDetails(show);
                        if (inserirow1 > 0)
                        {
                             string salesdelivary = "Insert into salesOrderDelivery values('" +id + "','true','" + dtpDate.Text + "')";
                            int insert=d.saveDetails(salesdelivary);
                                if(insert>0)
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
                    string insertquery = "insert into  orderdetails values('" + txtcustomercode.Text + "','" + dtpDate.Text + "','" + txtTotalAmmount.Text + "')";
                    int insertrows = d.saveDetails(insertquery);
                    if (insertrows > 0)
                    {

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
                            string txtAmount = cellcollection[5].Value.ToString();
                            //string orderid = txtSrNo.Text;
                            string query = "insert into customerorderdescriptions Values('" + Orde + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";

                            //int insertrow = d.saveDetails(query);

                            show.Add(query);
                        }

                        int inserirow1 = d.saveDetails(show);
                        if (inserirow1 > 0)
                        {
                            string salesdelivary = "Insert into salesOrderDelivery values('" + Orde + "','true','" + dtpDate.Text + "')";
                            int insert = d.saveDetails(salesdelivary);
                            if (insert > 0)
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
                makeblank();
               
           
                }


            if (txtRefNo.Text != "")
            {
                string deletequrri1 = "delete customerorderdescriptions where OrderId='" + txtRefNo.Text + "'";
                DataTable dt1 = d.getDetailByQuery(deletequrri1);
                counter = 0;
                if (counter == 0)
                {
                    DataGridViewRowCollection rowcollection = gridsalesdelivary.Rows;
                    List<string> show = new List<string>();
                    for (int a = 0; a < rowcollection.Count; a++)
                    {
                        DataGridViewRow currentrow = rowcollection[a];
                        DataGridViewCellCollection cellcollection = currentrow.Cells;
                        string txtitemcode = cellcollection[0].Value.ToString();
                        // string txtproductname = cellcollection[1].Value.ToString();
                        string txtRate = cellcollection[2].Value.ToString();
                        string txtQuantity = cellcollection[4].Value.ToString();
                        string txtAmount = cellcollection[5].Value.ToString();
                        string Orderid = txtRefNo.Text;

                        string query = "insert into customerorderdescriptions Values('" + Orderid + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";
                        
                        show.Add(query);
                    }

                    int inserirow1 = d.saveDetails(show);
                    if (inserirow1 > 0)
                        {
                            string insertquery = "insert into salesOrderDelivery values('" + txtRefNo.Text + "','true','" + dtpDate.Text + "')";
                            int insert = d.saveDetails(insertquery);
                        if(insert>0)
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
            makeblank();
            int value = Convert.ToInt32(txtSrNo.Text);
            int value1 = value + 1;
            txtSrNo.Text = value1.ToString();
           
                    }
     
        private void setAutoCompleteMode(TextBox txt, string ColumnName, DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
               foreach(DataRow dr in dt.Rows)
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
            addToCartTable.Columns.Add(new DataColumn("DelivaryQuantity"));
            addToCartTable.Columns.Add(new DataColumn("Amount"));
        }

        private void ButSelectPurchaseOrder_Click(object sender, EventArgs e)
        {

            string selectquery1 = "select  CustId,date,Totalammount from orderdetails";
            DataTable dt1 = d.getDetailByQuery(selectquery1);
            string val = " ";
            List<string> sd = new List<string>();
            foreach (DataColumn dr in dt1.Columns)
            {
                val = dr.ColumnName;
                sd.Add(val);
            }
            comsearchvalue.DataSource = sd;
            counter = 2;
            panel2.Visible = true;
            string selectquery = "select orderid, custid,date,totalammount from orderdetails";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                string s = comsearchvalue.SelectedValue.ToString();
                string val = s;
                string selectQuery = "select CustId,CustName,CustCompName,CustAddress,CustPhone,Custmobile,CustFax from CustomerDetails where " + val + " like '" + txtsearchvalue.Text + "%'";
                DataTable dt = d.getDetailByQuery(selectQuery);
                dataGridView2.DataSource = dt;
            }
            else if (counter == 1)
            {
                string s1 = comsearchvalue.SelectedValue.ToString();
                string val1 = s1;
                string selectQuery1 = "select it.itemid,it.ItemName,ip.Mrpprice,iq.CurrentQuantity from ItemDetails it join ItemPriceDetail ip on it.Itemid=ip.Itemid join ItemQuantityDetail iq on ip.ItemId=iq.Itemid where " + val1 + " like '" + txtsearchvalue.Text + "%'";
                DataTable dt1 = d.getDetailByQuery(selectQuery1);
                dataGridView2.DataSource = dt1;
            }
            else if (counter == 2)
            {
                string s2 = comsearchvalue.SelectedValue.ToString();
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

            }
        }

        private void txtcustomercode_TextChanged(object sender, EventArgs e)
        {
            string selectquery = "select CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from CustomerDetails Where Custid='" + txtcustomercode.Text + "'";
            DataTable dt = d.getDetailByQuery(selectquery);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtCustomerName.Text = dr[0].ToString();
                    txtCompName.Text = dr[1].ToString();
                    txtAddress.Text = dr[2].ToString();
                    txtPhone.Text = dr[3].ToString();
                    txtMobile.Text = dr[4].ToString();
                    txtFax.Text = dr[5].ToString();
                }
                }
                else
                {
                    txtCustomerName.Text = "";
                    txtCompName.Text = "";
                    txtAddress.Text = "";
                    txtPhone.Text = "";
                    txtMobile.Text = "";
                    txtFax.Text = "";
                }
            }
        


        private void txtRefNo_TextChanged(object sender, EventArgs e)
        {
            string selectquery = "select  c.custId, c.CustName,c.CustCompName,c.CustAddress,c.CustPhone,c.CustMobile,c.CustFax,o.orderid from CustomerDetails c join orderdetails o on c.custId=o.custid where o.orderid='" + txtRefNo.Text + "'";
            DataTable dt = d.getDetailByQuery(selectquery);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtcustomercode.Text = dr[0].ToString();
                    txtCustomerName.Text = dr[1].ToString();
                    txtCompName.Text = dr[2].ToString();
                    txtAddress.Text = dr[3].ToString();
                    txtPhone.Text = dr[4].ToString();
                    txtMobile.Text = dr[5].ToString();
                    txtFax.Text = dr[6].ToString();
                    txtRefNo.Text = dr[7].ToString();
                }
            }
                //else
                //{
                //    txtRefNo.Text = "";
                //    txtCustomerName.Text = "";
                //    txtCompName.Text = "";
                //    txtAddress.Text = "";
                //    txtPhone.Text = "";
                //    txtMobile.Text = "";
                //    txtFax.Text = "";
                //}

                int totel = 0;
                string selectquery1 = "select it.itemid,iq.ItemName,it.price,it.quantity,it.totalammount from customerorderdescriptions it join ItemDetails iq on it.ItemId=iq.ItemId where orderid='" + txtRefNo.Text + "'";
                DataTable dt3 = d.getDetailByQuery(selectquery1);
                int totelrow = addToCartTable.Rows.Count;
                for (int a = 0; a < totelrow; a++)
                {
                    addToCartTable.Rows.RemoveAt(0);
                }
                for (int a = 0; a < dt3.Rows.Count; a++)
                {
                    DataRow dr1 = dt3.Rows[a];
                    string itemcode = dr1[0].ToString();
                    string productname = dr1[1].ToString();
                    string rate = dr1[2].ToString();
                    string quantity = dr1[3].ToString();
                    string ammount = dr1[4].ToString();
                    int amt = Convert.ToInt32(ammount);
                    totel = totel + amt;
                    dr1 = addToCartTable.NewRow();
                    dr1[0] = itemcode.Trim();
                    dr1[1] = productname.Trim();
                    dr1[2] = rate.Trim();
                    dr1[3] = quantity.Trim();
                    dr1[4] = quantity.Trim();
                    dr1[5] = ammount.Trim();
                    addToCartTable.Rows.Add(dr1);

                }
            
                gridsalesdelivary.DataSource = addToCartTable;
                txtTotalAmmount.Text = totel.ToString();

        }

        private void gridsalesdelivary_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
            string a = gridsalesdelivary.Rows[e.RowIndex].Cells[4].Value.ToString();
            string rate = gridsalesdelivary.Rows[e.RowIndex].Cells[2].Value.ToString();
            int quantity = Convert.ToInt32(a);
            int r = Convert.ToInt32(rate);
            int totalammount = quantity * r;
            gridsalesdelivary.Rows[e.RowIndex].Cells[5].Value = totalammount.ToString();
            string newquantity = gridsalesdelivary.Rows[e.RowIndex].Cells[3].Value.ToString();
            int quantity1 = Convert.ToInt32(newquantity);
            int finalquantity = quantity1 - quantity;
            int totalq = r * finalquantity;
            int totalammount1 = Convert.ToInt32(txtTotalAmmount.Text);
            int t = totalammount1 - totalq;
            txtTotalAmmount.Text = t.ToString();
            }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            string selectquery1 = "select i.ItemId,i.ItemName,ip.MrpPrice,iq.CurrentQuantity from ItemDetails i join ItemPriceDetail ip on i.ItemId=ip.ItemId join ItemQuantityDetail iq on ip.ItemId=iq.ItemId where i.ItemId='" + txtItemCode.Text + "'";
            DataTable dt = d.getDetailByQuery(selectquery1);
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtProductName.Text = dr[1].ToString();
                    txtRate.Text = dr[2].ToString();

                }
            }
            else
            {
                txtProductName.Text = "";
                txtRate.Text = "";
            }
        }


        }

      
    }


