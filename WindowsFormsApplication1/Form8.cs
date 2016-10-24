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
    public partial class Form8 : Form
    {
        public int counter = 0;
        DB_Main dbMainClass = new DB_Main();
        DataTable vendorDetails = new DataTable();
        DataTable ItemDetails = new DataTable();
        DataTable addToCartTable = new DataTable();
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;

            string stlect = "select Orderid from VendorOrderDetails";
            DataTable dt = dbMainClass.getDetailByQuery(stlect);
            string id = "";
            foreach (DataRow dr in dt.Rows)
            {
                id = dr[0].ToString();
            }
            //txtSrNo.Text = id;
            if (id == "")
            {
                //int txt = Convert.ToInt32(id);
                //int txt1 = txt + 1;
                id = "1";
                txtSrNo.Text = id;
            }
            else
            {
                int txt = Convert.ToInt32(id);
                int txt1 = txt + 1;
                txtSrNo.Text = txt1.ToString();
            }

            Purchase.PurchaseDetails purChaseDetailObj = new Purchase.PurchaseDetails();
            vendorDetails = purChaseDetailObj.GetVendorDetaisInDataTable();
            ItemDetails = purChaseDetailObj.GetItemPriceAndNameDetaisInDataTable();
            setAutoCompleteMode(txtproductName, "ItemName", ItemDetails);
            setAddToCraftTable();
        }
        private void setVAlue()
        {
            if (vendorDetails.Rows.Count > 0)
            {
                string vendorId = txtVendorId.Text;
                if (vendorId.Trim() != "" && vendorId != null)
                {
                    DataRow[] dr = vendorDetails.Select("vendorid='" + vendorId + "'");
                    if (dr != null && dr.Length > 0)
                    {
                        //venderId, , vCompName, vAddress, vCity, vState, vZip, vCountry, vEmail, vWebAddress, vPhone, vMobile, vFax, vDesc
                        string vendorName = dr[0]["Name"].ToString();
                        string vendorAddress = dr[0]["Address"].ToString();
                        string vendorCompName = dr[0]["CompanyName"].ToString();
                        string vendorPhone = dr[0]["Phone"].ToString();
                        string vendorMobile = dr[0]["Mobile"].ToString();
                        string vendorFax = dr[0]["Fax"].ToString();

                        txtVendorName.Text = vendorName;
                        txtVendorAddress.Text = vendorAddress;
                        txtVendorCompanyName.Text = vendorCompName;
                        txtPhone.Text = vendorPhone;
                        txtMobile.Text = vendorMobile;
                        txtFax.Text = vendorFax;
                    }
                    else
                    {
                        txtVendorName.Text = "";
                        txtVendorAddress.Text = "";
                        txtVendorCompanyName.Text = "";
                        txtPhone.Text = "";
                        txtMobile.Text = "";
                        txtFax.Text = "";
                    }
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
        private void setitemVlue(string ColumnName, string value)
        {
            if (ItemDetails.Rows.Count > 0)
            {
                string ItemId = txtItemId.Text;
                if (value.Trim() != "" && value != null)
                {
                    DataRow[] dr = ItemDetails.Select(ColumnName + "='" + value + "'");
                    if (dr != null && dr.Length > 0)
                    {
                        //venderId, , vCompName, vAddress, vCity, vState, vZip, vCountry, vEmail, vWebAddress, vPhone, vMobile, vFax, vDesc
                        string ItemName = dr[0]["ItemName"].ToString();
                        string salesPrice = dr[0]["SalesPrice"].ToString();
                        string itemCode = dr[0]["ItemID"].ToString();
                        txtRate.Text = salesPrice;
                        txtproductName.Text = ItemName;

                        txtItemId.Text = itemCode;

                        if (ColumnName.StartsWith("ItemId"))
                        {
                            txtQuentity.Focus();
                        }
                    }
                    else
                    {
                        txtRate.Text = "";
                        if (ColumnName.StartsWith("ItemId"))
                        {
                            txtproductName.Text = "";
                        }
                        else if (ColumnName.StartsWith("ItemName"))
                        {
                            txtItemId.Text = "";
                        }

                    }
                }
            }
        }


        private void setDetails(DataGridViewCellCollection cellCollection)
        {
            try
            {
                txtVendorId.Text = cellCollection[0].Value.ToString();
                txtVendorName.Text = cellCollection[1].Value.ToString();
                txtVendorCompanyName.Text = cellCollection[2].Value.ToString();
                txtVendorAddress.Text = cellCollection[3].Value.ToString();
                txtPhone.Text = cellCollection[4].Value.ToString();
                txtMobile.Text = cellCollection[5].Value.ToString();
                txtFax.Text = cellCollection[7].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void buttVendor_Click(object sender, EventArgs e)
        {
            counter = 0;
            panel2.Visible = true;
            string selectqurry = "select venderId,vName,vCompName,vAddress,vPhone,vMobile,vFax from VendorDetails";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            dataGridView2.DataSource = dt;
        }
        private void setDetails1(DataGridViewCellCollection cellCollection)
        {
            try
            {
                txtItemId.Text = cellCollection[0].Value.ToString();
                txtproductName.Text = cellCollection[1].Value.ToString();
                txtRate.Text = cellCollection[2].Value.ToString();
                txtAmount.Text = cellCollection[3].Value.ToString();
                // txtQuanity.Text = cellCollection[4].Value.ToString();

            }
            catch (Exception ex)
            {
            }
        }

        private void buttItem_Click(object sender, EventArgs e)
        {
            counter = 1;
            panel2.Visible = true;
            string selectqurry = "select ipd.ItemId,itd.ItemName,ipd.purChasePrice,ipd.MrpPrice,iqd.CurrentQuantity from ItemPriceDetail ipd join ItemDetails itd on ipd.ItemId=itd.ItemId join ItemQuantityDetail iqd on itd.ItemId=iqd.ItemId where CurrentQuantity>0 ";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            dataGridView2.DataSource = dt;
        }

        private void buttSelectPurchase_Click(object sender, EventArgs e)
        {
            counter = 2;
            panel2.Visible = true;
            string selectqurry = "select * from VendorOrderDetails";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            dataGridView2.DataSource = dt;
        }

        private void buttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtVendorId_TextChanged(object sender, EventArgs e)
        {
            if (txtVendorId.Text.Trim() != "" && txtVendorId.Text.StartsWith("V"))
            {
                setVAlue();
            }
        }

        private void txtItemId_TextChanged(object sender, EventArgs e)
        {
            string itemCode = txtItemId.Text;
            setitemVlue("ItemId", itemCode);
        }

        private void txtproductName_TextChanged(object sender, EventArgs e)
        {
            string value = txtproductName.SelectedText;
            string val = txtproductName.Text;
        }

        private void txtproductName_Leave(object sender, EventArgs e)
        {
            string value = txtproductName.SelectedText;
            string val = txtproductName.Text;
        }

        private void txtproductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//|| e.KeyCode==Keys.Space) 
            {
                setitemVlue("ItemName", txtproductName.Text.Trim());
                txtQuentity.Focus();
            }
        }

        private void txtQuentity_TextChanged(object sender, EventArgs e)
        {
            string QuantiTy = txtQuentity.Text;
            int result = 0;
            if (int.TryParse(QuantiTy, out result))
            {

                int TotalQuantity = Convert.ToInt32(QuantiTy);
                if (TotalQuantity > 0)
                {
                    double RatePerPice = Convert.ToDouble(txtRate.Text.Trim());
                    txtAmount.Text = (TotalQuantity * RatePerPice).ToString();
                }
                else
                {
                    txtAmount.Text = "";
                }
            }
        }

        private void buttAddItem_Click(object sender, EventArgs e)
        {
            string qurry = "select CurrentQuantity from ItemQuantityDetail where ItemId='" + txtItemId.Text + "'";
            DataTable dt = dbMainClass.getDetailByQuery(qurry);
            string id = "";
            foreach (DataRow dr in dt.Rows)
            {
                id = dr["CurrentQuantity"].ToString();
            }

            int curentQuntity = Convert.ToInt32(txtQuentity.Text);
            int cuentQuantity = Convert.ToInt32(id);
            if (cuentQuantity == 0)
            {
                MessageBox.Show("now CurrentQuantity of deadt");
               txtQuentity.Text = "";
            }
            else
            {
                if (cuentQuantity < curentQuntity)
                {
                    MessageBox.Show("now CurrentQuantity of deadt");
                }
                else
                {
                    //int curentQuntity = Convert.ToInt32(txtQuanity.Text);
                    int lastQuantity = cuentQuantity - curentQuntity;
                    string id1 = lastQuantity.ToString();
                    string updateQurry = "update ItemQuantityDetail set CurrentQuantity='" + id1 + "'where ItemId='" + txtItemId.Text + "'";
                    int insertedRows = dbMainClass.saveDetails(updateQurry);
                    DataRow dr = addToCartTable.NewRow();
                    dr[0] = txtItemId.Text.Trim();
                    dr[1] = txtproductName.Text.Trim();
                    dr[2] = txtRate.Text.Trim();
                    dr[3] = txtQuentity.Text.Trim();
                    dr[4] = txtAmount.Text.Trim();
                    addToCartTable.Rows.Add(dr);
                    dataGridView1.DataSource = addToCartTable;
                    double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
                    totalAmount += Convert.ToDouble(txtAmount.Text.Trim());
                    txtTotalAmount.Text= totalAmount.ToString();

                    txtItemId.Text = "I";
                    txtproductName.Text = "";
                    txtRate.Text = "";
                    txtQuentity.Text = "";
                    txtAmount.Text = "0.0";
                    txtItemId.Focus();
                }

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

        private void buttRemoveItem_Click(object sender, EventArgs e)
        {
             if (addToCartTable.Rows.Count > 0)
            {
                string Amount = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
                totalAmount -= Convert.ToDouble(Amount.Trim());
                txtTotalAmount.Text = totalAmount.ToString();
                int index = dataGridView1.SelectedRows[0].Index;
                addToCartTable.Rows.RemoveAt(index);

                dataGridView1.DataSource = addToCartTable;
                if (addToCartTable.Rows.Count == 0)
                {
                  txtTotalAmount.Text = "0.0";
                    txtDiscount.Text = "0.0";
                }
            }

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
             double totalAmount = 0.0;
            foreach (DataRow dr in addToCartTable.Rows)
            {
                totalAmount += Convert.ToDouble(dr[4].ToString());
            }
            string discountAmount = txtDiscount.Text;
            //double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
            double amount = 0.0;
            if (double.TryParse(discountAmount, out amount))
            {
                double totalDiscount = Convert.ToDouble(discountAmount);
                totalAmount = totalAmount - ((totalAmount * totalDiscount) / 100);
                txtTotalAmount.Text= totalAmount.ToString();
            }
        }

        private void buttSave_Click(object sender, EventArgs e)
        {
             counter = 0;
            if (counter == 0)
            {
                string insertqurry = "insert into VendorOrderDetails values('" +txtVendorId.Text + "','" + txtdate.Text + "','" + txtTotalAmount.Text + "')";
                int insertedRows = dbMainClass.saveDetails(insertqurry);
                if (insertedRows > 0)
                {

                    MessageBox.Show("Details Saved Successfully");

                }
                else
                {
                    MessageBox.Show("Details Not Saved Successfully");
                }

                DataGridViewRowCollection RowCollection = dataGridView1.Rows;
                List<string> sf = new List<string>();
                for (int a = 0; a < RowCollection.Count; a++)
                {

                    DataGridViewRow currentRow = RowCollection[a];
                    DataGridViewCellCollection cellCollection = currentRow.Cells;
                    string txtItemCode = cellCollection[0].Value.ToString();
                    string txtRate = cellCollection[2].Value.ToString();
                    string txtQuanity = cellCollection[3].Value.ToString();
                    string txtAmoun = cellCollection[4].Value.ToString();
                    string OrderID = txtSrNo.Text;
                    string Query = "insert into VendorOrderDesc Values('" + OrderID + "','" + txtItemCode + "','" + txtRate + "','" + txtQuanity + "','" + txtAmoun + "')";
                    //MessageBox.Show(Query);
                    sf.Add(Query);
                }
                int insertedRows1 = dbMainClass.SaveDetails(sf);
                if (insertedRows1 > 0)
                {
                    MessageBox.Show("Details Saved Successfully");
                }
                else
                {
                    MessageBox.Show("Details Not Saved Successfully");
                }
            }

        }

        private void txtQuentity_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (Char.IsDigit(e.KeyChar))
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

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (counter == 0)
            {
                panel2.Visible = false;
                DataGridViewCellCollection CellCollection = dataGridView2.Rows[e.RowIndex].Cells;
                setDetails(CellCollection);
            }
            else if (counter == 1)
            {
                panel2.Visible = false;
                DataGridViewCellCollection CellCollection = dataGridView2.Rows[e.RowIndex].Cells;
                setDetails1(CellCollection);
            }
         else if (counter == 2)
            {
                panel2.Visible = false;
                DataGridViewCellCollection CellCollection = dataGridView2.Rows[e.RowIndex].Cells;
                string s = CellCollection[0].Value.ToString();
                string s1 = CellCollection[1].Value.ToString();
                //MessageBox.Show(" "+s +" "+s1);
                string selectqurry = "select venderId,vName,vCompName,vAddress,vPhone,vMobile,vFax from VendorDetails where venderId='" + s1 + "'";
                DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
                foreach (DataRow dr in dt.Rows)
                {
                    txtVendorId.Text = dr[0].ToString();
                    txtVendorName.Text = dr[1].ToString();
                    txtVendorCompanyName.Text = dr[2].ToString();
                    txtVendorAddress.Text = dr[3].ToString();
                    txtPhone.Text = dr[4].ToString();
                    txtMobile.Text = dr[5].ToString();
                    txtFax.Text = dr[6].ToString();
                }
                string selectqurry1 = "select vodd.ItemId,td.ItemName, vodd.Quantity,vodd.Price,vodd.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId where vod. Orderid='" + s + "'";
                DataTable dt1 = dbMainClass.getDetailByQuery(selectqurry1);
                dataGridView1.DataSource = dt1;
            }
           }
        }

    }
