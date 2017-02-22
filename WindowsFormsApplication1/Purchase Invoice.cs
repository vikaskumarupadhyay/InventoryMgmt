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
        //private DataTable VendorOrderDetails;
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            txtQuentity.ReadOnly = true;
            buttAddItem.Enabled = false;
            buttRemoveItem.Enabled = false;
            panel2.Visible = false;
            dtpInvoiceDate.Value = DateTime.Now;
            string stlect = "select InvoiceId  from CustomerOrderInvoice";
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
                    DataRow[] dr = vendorDetails.Select("[Vender Id ]='" + vendorId + "'");
                    if (dr != null && dr.Length > 0)
                    {
                        //venderId, , vCompName, vAddress, vCity, vState, vZip, vCountry, vEmail, vWebAddress, vPhone, vMobile, vFax, vDesc
                        string vendorName = dr[0]["Name"].ToString();
                        string vendorAddress = dr[0]["Address"].ToString();
                        string vendorCompName = dr[0]["Compnay Name"].ToString();
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
                txtPhone.Text = cellCollection[10].Value.ToString();
                txtMobile.Text = cellCollection[11].Value.ToString();
                txtFax.Text = cellCollection[12].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void buttVendor_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            counter = 0;
            panel2.Visible = true;
            string selectqurry = "select vd.venderId as [Vender Id ],vd.vName AS Name ,vd.vCompName AS [Company Name] ,vd.vAddress AS Address,vd.vCity AS City,vd. vState AS State ,vd.vZip AS Zip ,vd.vCountry AS Country ,vd.vEmail AS[E-Mail ],vd. vWebAddress AS[Web Address],vd.vPhone AS Phone ,vd.vMobile AS Mobile ,vd.vFax AS Fax ,vd.vPanNo as[PAN No],vd.vVatNo as [VAT No],vd.vCstNo as[CST No],vd.vServiceTaxRegnNo as [Service Tax Regn.No],vd.vExciseRegnNo as [Excise Regn.No],vd.vGSTRegnNo as[GST Regn.No],vd.vDesc AS Description,vad.vOpeningBalance AS [Opening Balance] , vad.vCurrentBalance AS [Current Balance] from  vendorDetails vd join    VendorAccountDetails  vad on vd.venderID=vad.venderID";
            string selectqurryForActualColumnName = "select top 1 vd.venderId ,vd.vName  ,vd.vCompName  ,vd.vAddress ,vd.vCity,vd. vState  ,vd.vZip  ,vd.vCountry  ,vd.vEmail ,vd. vWebAddress ,vd.vPhone  ,vd.vMobile ,vd.vFax ,vd.vPanNo ,vd.vVatNo ,vd.vCstNo,vd.vServiceTaxRegnNo ,vd.vExciseRegnNo ,vd.vGSTRegnNo ,vd.vDesc,vad.vOpeningBalance, vad.vCurrentBalance  from  vendorDetails vd join    VendorAccountDetails  vad on vd.venderID=vad.venderID";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            DataTable dtOnlyColumnName = dbMainClass.getDetailByQuery(selectqurryForActualColumnName);
            DataTable customDataTable = new DataTable();
            customDataTable.Columns.Add("ActualTableColumnName");
            customDataTable.Columns.Add("AliasTableColumnName");
            DataColumnCollection d = dt.Columns;
            DataColumnCollection dataColumnForName = dtOnlyColumnName.Columns;
            for (int a = 1; a < d.Count; a++)
            {
                string b = d[a].ToString();
                string actualColumnName = dataColumnForName[a].ToString();
                DataRow dr = customDataTable.NewRow();
                dr["ActualTableColumnName"] = actualColumnName;
                dr["AliasTableColumnName"] = b;
                customDataTable.Rows.Add(dr);
            }

            comboBox1.DataSource = customDataTable;
            comboBox1.ValueMember = "ActualTableColumnName";
            comboBox1.DisplayMember = "AliasTableColumnName";
            dataGridView2.DataSource = dt;
        }
        private void setDetails1(DataGridViewCellCollection cellCollection)
        {
            try
            {
                txtItemId.Text = cellCollection[0].Value.ToString();
                txtproductName.Text = cellCollection[1].Value.ToString();
                txtRate.Text = cellCollection[6].Value.ToString();
                //txtAmount.Text = cellCollection[3].Value.ToString();
                // txtQuanity.Text = cellCollection[4].Value.ToString();

            }
            catch (Exception ex)
            {
            }
        }

        private void buttItem_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            counter = 1;
            panel2.Visible = true;
            string selectqurry = "select  itm.ItemId,itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],ipd.purChasePrice as [Purchase Price],ipd.SalesPrice as[Sales Price],ipd.MrpPrice as[Mrp Price],ipd.Margin as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId where iqd.CurrentQuantity>0";
            string selectqurryForActualColumnName = "select top 1  itm.ItemId, itm.ItemName,itm.ItemCompName ,itm.ItemDesc ,ig.groupName,iul.unitName ,ipd.purChasePrice ,ipd.SalesPrice ,ipd.MrpPrice ,ipd.Margin ,iqd.OpeningQuantity ,iqd.CurrentQuantity from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            DataTable dtOnlyColumnName = dbMainClass.getDetailByQuery(selectqurryForActualColumnName);
            DataTable customDataTable = new DataTable();
            customDataTable.Columns.Add("ActualTableColumnName");
            customDataTable.Columns.Add("AliasTableColumnName");
            DataColumnCollection d = dt.Columns;
            DataColumnCollection dataColumnForName = dtOnlyColumnName.Columns;
            for (int a = 1; a < d.Count; a++)
            {
                string b = d[a].ToString();
                string actualColumnName = dataColumnForName[a].ToString();
                DataRow dr = customDataTable.NewRow();
                dr["ActualTableColumnName"] = actualColumnName;
                dr["AliasTableColumnName"] = b;
                customDataTable.Rows.Add(dr);
            }
            comboBox1.DataSource = customDataTable;
            comboBox1.ValueMember = "ActualTableColumnName";
            comboBox1.DisplayMember = "AliasTableColumnName";
            dataGridView2.DataSource = dt;
        }

        private void buttSelectPurchase_Click(object sender, EventArgs e)
        {
            counter = 2;
            panel2.Visible = true;
            string selectqurry = "select * from VendorOrderDetails";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            List<string> ls = new List<string>();
            DataColumnCollection d = dt.Columns;
            for (int a = 1; a < d.Count; a++)
            {
                DataColumn dc = new DataColumn();
                string b = d[a].ToString();
                ls.Add(b);
            }
            comboBox1.DataSource = ls;
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
            txtQuentity.ReadOnly = false;
            buttAddItem.Enabled = true;
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
            //string qurry = "select CurrentQuantity from ItemQuantityDetail where ItemId='" + txtItemId.Text + "'";
            //DataTable dt = dbMainClass.getDetailByQuery(qurry);
            //string id = "";
            //foreach (DataRow dr in dt.Rows)
            //{
            //    id = dr["CurrentQuantity"].ToString();
            //}

            //int curentQuntity = Convert.ToInt32(txtQuentity.Text);
            //int cuentQuantity = Convert.ToInt32(id);
            //if (cuentQuantity == 0)
            //{
            //    MessageBox.Show("now CurrentQuantity of deadt");
            //   txtQuentity.Text = "";
            //}
            //else
            //{
            //    if (cuentQuantity < curentQuntity)
            //    {
            //        MessageBox.Show("now CurrentQuantity of deadt");
            //    }
            //    else
            //    {
            //        int curentQuntity1 = Convert.ToInt32(txtQuentity.Text);
            //        int lastQuantity = cuentQuantity - curentQuntity;
            //        string id1 = lastQuantity.ToString();
            //        string updateQurry = "update ItemQuantityDetail set CurrentQuantity='" + id1 + "'where ItemId='" + txtItemId.Text + "'";
            //        int insertedRows = dbMainClass.saveDetails(updateQurry);
             if (txtproductName.Text==""&& txtQuentity.Text=="")
                  {
                    //MessageBox.Show("now CurrentQuantity of deadt");
                  }
                  else
             {
                 if(txtAmount.Text=="")
                 {
                     MessageBox.Show("Please enter Quantity");
                 }
                 else
                 {
            buttRemoveItem.Enabled = true;
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
                if (dataGridView1.Rows.Count > 0)
                {
                    buttRemoveItem.Enabled = true;
                }
                else
                {
                    buttRemoveItem.Enabled = false;
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

            if (txtRef.Text== "")
            {
                string order = "select Deliveryidfrom CustomerOrderDelivery";
                DataTable dt1 = dbMainClass.getDetailByQuery(order);
                string id2 = "";
                string id5 = "";
                foreach (DataRow dr in dt1.Rows)
                {
                    id5 = dr[0].ToString();
                }
                string order1 = "select Orderid from VendorOrderDetails";
                DataTable dt4 = dbMainClass.getDetailByQuery(order1);
                foreach (DataRow dr in dt4.Rows)
                {
                    id2 = dr[0].ToString();
                }
                string OrderID = "";
                if (id2 == "")
                {
                    id2 = "1";
                    OrderID = id2;
                    string insertqurry = "insert into VendorOrderDetails values('" + txtVendorId.Text+ "','" + dtpInvoiceDate.Value.ToString()+ "','" + txtTotalAmount.Text + "','"+txtDiscount.Text+"')";
                    int insertedRows = dbMainClass.saveDetails(insertqurry);
                    //if (insertedRows > 0)
                    //{
                    DataGridViewRowCollection RowCollection = dataGridView1.Rows;
                    List<string> sf = new List<string>();
                    for (int a = 0; a < RowCollection.Count; a++)
                    {

                        DataGridViewRow currentRow = RowCollection[a];
                        DataGridViewCellCollection cellCollection = currentRow.Cells;
                        string txtItemCod = cellCollection[0].Value.ToString();
                        string txtRate = cellCollection[2].Value.ToString();
                        string txtQuanit = cellCollection[3].Value.ToString();
                        string txtAmoun = cellCollection[5].Value.ToString();

                        string Query = "insert into VendorOrderDesc Values('" + OrderID + "','" + txtItemCod + "','" + txtRate + "','" + txtQuanit + "','" + txtAmoun + "')";
                        //MessageBox.Show(Query);
                        sf.Add(Query);
                    }
                    int insertedRows1 = dbMainClass.saveDetails(sf);
                    if (insertedRows1 > 0)
                    {

                        if (id5 == "")
                        {
                            string deleteQurry = "delete VendorOrderDesc where Orderid='" + id2 + "'";
                            DataTable dt = dbMainClass.getDetailByQuery(deleteQurry);
                            //dataGridView1.DataSource = "";


                            DataGridViewRowCollection RowCollection2 = dataGridView1.Rows;
                            List<string> sf1 = new List<string>();
                            for (int a = 0; a < RowCollection2.Count; a++)
                            {

                                DataGridViewRow currentRow = RowCollection2[a];
                                DataGridViewCellCollection cellCollection = currentRow.Cells;
                                string txtItemCode = cellCollection[0].Value.ToString();
                                string txtRate = cellCollection[2].Value.ToString();
                                string txtQuanity = cellCollection[4].Value.ToString();
                                string txtAmoun = cellCollection[5].Value.ToString();
                                string OrderID1 = id2;

                                string Query = "insert into VendorOrderDesc Values('" + OrderID1 + "','" + txtItemCode + "','" + txtRate + "','" + txtQuanity + "','" + txtAmoun + "')";
                                //MessageBox.Show(Query);

                                sf1.Add(Query);

                            }
                            int insertedRows4 = dbMainClass.saveDetails(sf1);
                            if (insertedRows4 > 0)
                            {
                                string insertQurry = "insert into CustomerOrderDelivery Values('" + txtRef.Text + "','true','" + dtpInvoiceDate.Value.ToString() + "')";
                                int insertedRows2 = dbMainClass.saveDetails(insertQurry);
                                if (insertedRows2 > 0)
                                {
                                    MessageBox.Show("Details Saved Successfully");
                                }
                                else
                                {
                                    MessageBox.Show("Details Not Saved Successfully");
                                }
                            }
                        }
                    }
                }
                else
                {
                    int id3 = Convert.ToInt32(id2);
                    int id4 = id3 + 1;
                    OrderID = id4.ToString();
                    string insertqurry1 = "insert into VendorOrderDetails(venderId,OrderDate,TotalPrice,Discount) values('" + txtVendorId.Text + "','" + dtpInvoiceDate.Value.ToString() + "','" + txtTotalAmount.Text + "','"+txtDiscount.Text+"')";
                    int insertedRows1 = dbMainClass.saveDetails(insertqurry1);
                    //if (insertedRows1 > 0)
                    //{
                    DataGridViewRowCollection RowCollection = dataGridView1.Rows;
                    List<string> sf = new List<string>();
                    for (int a = 0; a < RowCollection.Count; a++)
                    {

                        DataGridViewRow currentRow = RowCollection[a];
                        DataGridViewCellCollection cellCollection = currentRow.Cells;
                        string txtItemCod = cellCollection[0].Value.ToString();
                        string txtRate = cellCollection[2].Value.ToString();
                        string txtQuanit = cellCollection[3].Value.ToString();
                        string txtAmoun = cellCollection[4].Value.ToString();

                        string Query = "insert into VendorOrderDesc Values('" + OrderID + "','" + txtItemCod + "','" + txtRate + "','" + txtQuanit + "','" + txtAmoun + "')";
                        //MessageBox.Show(Query);
                        sf.Add(Query);
                    }
                    int insertedRows2 = dbMainClass.saveDetails(sf);
                    if (insertedRows2 > 0)
                    {

                        string deleteQurry1 = "delete VendorOrderDesc where Orderid='" + OrderID + "'";
                        DataTable dt5 = dbMainClass.getDetailByQuery(deleteQurry1);
                        //dataGridView1.DataSource = "";

                        DataGridViewRowCollection RowCollection1 = dataGridView1.Rows;
                        List<string> sf2 = new List<string>();
                        for (int a = 0; a < RowCollection1.Count; a++)
                        {

                            DataGridViewRow currentRow = RowCollection1[a];
                            DataGridViewCellCollection cellCollection = currentRow.Cells;
                            string txtItemCode = cellCollection[0].Value.ToString();
                            string txtRate = cellCollection[2].Value.ToString();
                            string txtQuanity = cellCollection[3].Value.ToString();
                            string txtAmoun = cellCollection[4].Value.ToString();
                            string OrderID2 = OrderID;

                            string Query = "insert into VendorOrderDesc Values('" + OrderID2 + "','" + txtItemCode + "','" + txtRate + "','" + txtQuanity + "','" + txtAmoun + "')";
                            //MessageBox.Show(Query);

                            sf2.Add(Query);

                        }
                        int insertedRows3 = dbMainClass.saveDetails(sf2);
                        if (insertedRows3 > 0)
                        {
                            string insertQurry = "insert into CustomerOrderDelivery Values('" + OrderID + "','true','" + dtpInvoiceDate.Value.ToString() + "')";
                            int insertedRows5 = dbMainClass.saveDetails(insertQurry);
                            if (insertedRows5 > 0)
                            {
                                string select1 = "select * from CustomerOrderDelivery where Orderid='" + OrderID + "'";
                                DataTable dt2 = dbMainClass.getDetailByQuery(select1);
                                if (dt2 != null && dt2.Rows != null && dt2.Rows.Count > 0)
                                {
                                    DataRow dr1 = dt2.Rows[0];
                                    string r = dr1[1].ToString();
                                    string s = dr1[0].ToString();

                                    string select = "select * from CustomerOrderDelivery where Deliveryid='" + s + "'";
                                    DataTable dt = dbMainClass.getDetailByQuery(select);
                                    if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                                    {
                                        DataRow dr = dt.Rows[0];
                                        string c = dr[0].ToString();

                                            string Qurry1 = "insert into CustomerOrderInvoice Values('" + c + "','" + r + "','" + dtpInvoiceDate.Value.ToString() + "')";
                                            int insertedRows = dbMainClass.saveDetails(Qurry1);
                                            if (insertedRows > 0)
                                            {
                                                  MessageBox.Show("Details Saved Successfully");

                                             }
                                           else
                                           {
                                                MessageBox.Show("Details Not Saved Successfully");
                                           }
                                        }
                                    }
                               // }
                            }
                        }
                    }
                }
               
                
                int id = Convert.ToInt32(txtSrNo.Text);
                int id1 = id + 1;
                txtSrNo.Text = id1.ToString();
               // F9.MdiParent = this;
                Form9 F9 = new Form9(id.ToString());
                F9.Show();
                makeBlank();
            
            }
              
            if (txtRef.Text != "")
                {
                    string select1 = "select * from CustomerOrderDelivery where Deliveryid='" + txtRef.Text + "'";
                    DataTable dt2 = dbMainClass.getDetailByQuery(select1);
                    if (dt2 != null && dt2.Rows != null && dt2.Rows.Count > 0)
                    {
                        DataRow dr1 = dt2.Rows[0];
                        string r = dr1[1].ToString();
                        string deleteQurry = "delete VendorOrderDesc where Orderid='" + r + "'";
                        DataTable dt3 = dbMainClass.getDetailByQuery(deleteQurry);
                    }
                    counter = 0;
                    if (counter == 0)
                    {
                        //string insertqurry = "insert into VendorOrderDetails values('" +txtVendorId.Text + "','" + txtdate.Text + "','" + txtTotalAmount.Text + "')";
                        //int insertedRows = dbMainClass.saveDetails(insertqurry);
                        //if (insertedRows > 0)
                        //{

                        //    MessageBox.Show("Details Saved Successfully");

                        //}
                        //else
                        //{
                        //    MessageBox.Show("Details Not Saved Successfully");
                        //}
                        string select = "select * from CustomerOrderDelivery where Deliveryid='" + txtRef.Text + "'";
                        DataTable dt = dbMainClass.getDetailByQuery(select);
                        if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                        {
                            DataRow dr = dt.Rows[0];
                            string c = dr[1].ToString();
                            DataGridViewRowCollection RowCollection4 = dataGridView1.Rows;
                            List<string> sf4 = new List<string>();
                            for (int a = 0; a < RowCollection4.Count; a++)
                            {

                                DataGridViewRow currentRow = RowCollection4[a];
                                DataGridViewCellCollection cellCollection = currentRow.Cells;
                                string txtItemCode = cellCollection[0].Value.ToString();
                                string txtRate = cellCollection[2].Value.ToString();
                                string txtQuanity = cellCollection[3].Value.ToString();
                                string txtAmoun = cellCollection[4].Value.ToString();
                                string OrderID3 = c;
                                string Query = "insert into VendorOrderDesc Values('" + OrderID3 + "','" + txtItemCode + "','" + txtRate + "','" + txtQuanity + "','" + txtAmoun + "')";
                                //MessageBox.Show(Query);
                                sf4.Add(Query);
                            }
                            int insertedRows5 = dbMainClass.saveDetails(sf4);
                            if (insertedRows5 > 0)
                            {
                                string Qurry1 = "insert into CustomerOrderInvoice Values('" + txtRef.Text + "','" + c + "','" + dtpInvoiceDate.Value.ToString()+ "')";
                                int insertedRows = dbMainClass.saveDetails(Qurry1);
                                if (insertedRows > 0)
                                {

                                    MessageBox.Show("Details Saved Successfully");

                                }
                                else
                                {
                                    MessageBox.Show("Details Not Saved Successfully");
                                }

                            }
                        }
                    }
                //}
                   
                    //F9.MdiParent = this;
                makeBlank();
                int id = Convert.ToInt32(txtSrNo.Text);
                int id1 = id + 1;
                txtSrNo.Text = id1.ToString();
                Form9 F9 = new Form9(id.ToString());
                F9.Show();

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
           
           }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           
        }

     
        private void txtRef_TextChanged(object sender, EventArgs e)
        {
            //string refqurry = "select Deliveryid from CustomerOrderInvoice where Deliveryid ='" + txtRef.Text + "'";
            //DataTable refdt = dbMainClass.getDetailByQuery(refqurry);
            //if (refdt != null && refdt.Rows != null && refdt.Rows.Count > 0)
            //{
            //    //buttSave.Enabled = false;
            //    MessageBox.Show("This Delivery completed");
            //    txtRef.Text = "";
            //    txtVendorId.Focus();
                //int totel = 0;
                //string selc = "select * from CustomerOrderDelivery where Deliveryid ='" + txtRef.Text + "'";
                //DataTable dt2 = dbMainClass.getDetailByQuery(selc);
                //if (dt2 != null && dt2.Rows != null && dt2.Rows.Count > 0)
                //{
                //    DataRow dr0 = dt2.Rows[0];
                //    string c = dr0[1].ToString();
                //    string select = "select vo.Orderid,vo.venderId,vod.ItemId from VendorOrderDesc vod join VendorOrderDetails vo on vod.Orderid=vo.Orderid where vo.Orderid='" + c + "'";
                //    DataTable dt = dbMainClass.getDetailByQuery(select);
                //    if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                //    {
                //        DataRow dr = dt.Rows[0];
                //        string a = dr[1].ToString();
                //        string select1 = "select venderId,vName,vCompName,vAddress ,vPhone,vMobile,vFax from VendorDetails where venderId='" + a + "'";
                //        SetVendor(select1);
                //        string selectqurry1 = "select vodd.ItemId,td.ItemName, vodd.Quantity,vodd.Price,vodd.TotalPrice,vod.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId where vod. Orderid='" + c + "'";
                //        DataTable dt3 = dbMainClass.getDetailByQuery(selectqurry1);
                //        int totalRowCount = addToCartTable.Rows.Count;
                //        for (int rowCount = 0; rowCount < totalRowCount; rowCount++)
                //        {
                //            addToCartTable.Rows.RemoveAt(0);
                //        }

                //        for (int d = 0; d < dt3.Rows.Count; d++)
                //        {
                //            DataRow dr2 = dt3.Rows[d];
                //            string txtItemCode = dr2[0].ToString();
                //            string txtRate = dr2[1].ToString();
                //            string txtQuanity = dr2[2].ToString();
                //            string txtAmoun = dr2[3].ToString();
                //            string txtitemNmae = dr2[4].ToString();
                //            //totel = dr2[5].ToString();
                //            int amt = Convert.ToInt32(txtitemNmae);
                //            totel = totel + amt;

                //            dr2 = addToCartTable.NewRow();
                //            dr2[0] = txtItemCode.Trim();
                //            dr2[1] = txtRate.Trim();
                //            dr2[3] = txtQuanity.Trim();
                //            dr2[2] = txtAmoun.Trim();
                //            dr2[4] = txtitemNmae.Trim();
                //            addToCartTable.Rows.Add(dr2);
                //        }
                //        dataGridView1.DataSource = addToCartTable;
                //        txtTotalAmount.Text = totel.ToString();
                //    }
                //}

            //}
            //else
            //{
            //    buttSave.Enabled = true;
            //int totel =0;
            //string selc = "select * from CustomerOrderDelivery where Deliveryid ='" + txtRef.Text + "'";
            //DataTable dt2 = dbMainClass.getDetailByQuery(selc);
            //if (dt2 != null && dt2.Rows != null && dt2.Rows.Count > 0)
            //{
            //    DataRow dr0 = dt2.Rows[0];
            //    string c = dr0[1].ToString();
            //    string select = "select vo.Orderid,vo.venderId,vod.ItemId from VendorOrderDesc vod join VendorOrderDetails vo on vod.Orderid=vo.Orderid where vo.Orderid='" + c + "'";
            //    DataTable dt = dbMainClass.getDetailByQuery(select);
            //    if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            //    {
            //        DataRow dr = dt.Rows[0];
            //        string a = dr[1].ToString();
            //        string select1 = "select venderId,vName,vCompName,vAddress ,vPhone,vMobile,vFax from VendorDetails where venderId='" + a + "'";
            //        SetVendor(select1);
            //        string selectqurry1 = "select vodd.ItemId,td.ItemName, vodd.Quantity,vodd.Price,vodd.TotalPrice,vod.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId where vod. Orderid='" + c + "'";
            //        DataTable dt3 = dbMainClass.getDetailByQuery(selectqurry1);
            //        int totalRowCount = addToCartTable.Rows.Count;
            //        for (int rowCount = 0; rowCount < totalRowCount; rowCount++)
            //        {
            //            addToCartTable.Rows.RemoveAt(0);
            //        }

            //        for (int d = 0; d < dt3.Rows.Count; d++)
            //        {
            //            DataRow dr2 = dt3.Rows[d];
            //            string txtItemCode = dr2[0].ToString();
            //            string txtRate = dr2[1].ToString();
            //            string txtQuanity = dr2[2].ToString();
            //            string txtAmoun = dr2[3].ToString();
            //            string txtitemNmae = dr2[4].ToString();
            //            //totel = dr2[5].ToString();
            //            int amt = Convert.ToInt32(txtitemNmae);
            //            totel = totel + amt;

            //            dr2 = addToCartTable.NewRow();
            //            dr2[0] = txtItemCode.Trim();
            //            dr2[1] = txtRate.Trim();
            //            dr2[3] = txtQuanity.Trim();
            //            dr2[2] = txtAmoun.Trim();
            //            dr2[4] = txtitemNmae.Trim();
            //            addToCartTable.Rows.Add(dr2);
            //        }
            //        dataGridView1.DataSource = addToCartTable;
            //        txtTotalAmount.Text = totel.ToString();
            //    }
            //}

            //}
        }
        private void SetVendor(string r)
        {
            DataTable dt = dbMainClass.getDetailByQuery(r);
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
        }
        private void makeBlank()
        {
            txtVendorId.Text = "V";
            txtVendorName.Text = "";
            txtVendorAddress.Text = "";
            txtVendorCompanyName.Text = "";
            txtPhone.Text = "";
            txtMobile.Text = "";
            txtFax.Text = "";
            txtRef.Text = "";
            dataGridView1.DataSource = "";
            txtTotalAmount.Text = "0";
            addToCartTable.Clear();

        }

        private void txtRef_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtRef.ReadOnly = true;
                string refqurry = "select Deliveryid from CustomerOrderInvoice where Deliveryid ='" + txtRef.Text + "'";
                DataTable refdt = dbMainClass.getDetailByQuery(refqurry);
                if (refdt != null && refdt.Rows != null && refdt.Rows.Count > 0)
                {
                    //buttSave.Enabled = false;
                    MessageBox.Show("This Delivery completed");
                    txtRef.Text = "";
                    txtVendorId.Focus();

                  }
            else
            {
                buttSave.Enabled = true;
            int totel =0;
            string selc = "select * from CustomerOrderDelivery where Deliveryid ='" + txtRef.Text + "'";
            DataTable dt2 = dbMainClass.getDetailByQuery(selc);
            if (dt2 != null && dt2.Rows != null && dt2.Rows.Count > 0)
            {
                DataRow dr0 = dt2.Rows[0];
                string c = dr0[1].ToString();
                string select = "select vo.Orderid,vo.venderId,vod.ItemId from VendorOrderDesc vod join VendorOrderDetails vo on vod.Orderid=vo.Orderid where vo.Orderid='" + c + "'";
                DataTable dt = dbMainClass.getDetailByQuery(select);
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    string a = dr[1].ToString();
                    string select1 = "select venderId,vName,vCompName,vAddress ,vPhone,vMobile,vFax from VendorDetails where venderId='" + a + "'";
                    SetVendor(select1);
                    string selectqurry1 = "select vodd.ItemId,td.ItemName, vodd.Quantity,vodd.Price,vodd.TotalPrice,vod.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId where vod. Orderid='" + c + "'";
                    DataTable dt3 = dbMainClass.getDetailByQuery(selectqurry1);
                    int totalRowCount = addToCartTable.Rows.Count;
                    for (int rowCount = 0; rowCount < totalRowCount; rowCount++)
                    {
                        addToCartTable.Rows.RemoveAt(0);
                    }

                    for (int d = 0; d < dt3.Rows.Count; d++)
                    {
                        DataRow dr2 = dt3.Rows[d];
                        string txtItemCode = dr2[0].ToString();
                        string txtRate = dr2[1].ToString();
                        string txtQuanity = dr2[2].ToString();
                        string txtAmoun = dr2[3].ToString();
                        string txtitemNmae = dr2[4].ToString();
                        //totel = dr2[5].ToString();
                        int amt = Convert.ToInt32(txtitemNmae);
                        totel = totel + amt;

                        dr2 = addToCartTable.NewRow();
                        dr2[0] = txtItemCode.Trim();
                        dr2[1] = txtRate.Trim();
                        dr2[3] = txtQuanity.Trim();
                        dr2[2] = txtAmoun.Trim();
                        dr2[4] = txtitemNmae.Trim();
                        addToCartTable.Rows.Add(dr2);
                    }
                    dataGridView1.DataSource = addToCartTable;
                    txtTotalAmount.Text = totel.ToString();
                }
            }

            }
             }
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    txtRef.ReadOnly = false;
                    makeBlank();
                   // txtVendorId.Text = "V";
                   // txtVendorName.Text = "";
                   // txtVendorAddress.Text = "";
                   //txtVendorCompanyName.Text = "";
                   // txtPhone.Text = "";
                   // txtMobile.Text = "";
                   // txtFax.Text = "";
                   // txtRef.Text = "";
                   // dataGridView1.DataSource = "";

                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void buttAddItem_Leave(object sender, EventArgs e)
        {
            buttAddItem.Enabled = false;
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                string s = comboBox1.SelectedValue.ToString();
                //string m = "v" + s;
                string selectQurry = "select vd.venderId as [Vender Id ],vd.vName AS Name ,vd.vCompName AS [Company Name] ,vd.vAddress AS Address,vd.vCity AS City,vd. vState AS State ,vd.vZip AS Zip ,vd.vCountry AS Country ,vd.vEmail AS[E-Mail ],vd. vWebAddress AS[Web Address],vd.vPhone AS Phone ,vd.vMobile AS Mobile ,vd.vFax AS Fax ,vd.vPanNo as[PAN No],vd.vVatNo as [VAT No],vd.vCstNo as[CST No],vd.vServiceTaxRegnNo as [Service Tax Regn.No],vd.vExciseRegnNo as [Excise Regn.No],vd.vGSTRegnNo as[GST Regn.No],vd.vDesc AS Description,vad.vOpeningBalance AS [Opening Balance] , vad.vCurrentBalance AS [Current Balance] from  vendorDetails vd join    VendorAccountDetails  vad on vd.venderID=vad.venderID where " + s + " like '" + txtSearch.Text + "%'";
                DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
                dataGridView2.DataSource = dt;
            }
            else if (counter == 1)
            {
                string s = comboBox1.SelectedValue.ToString();
                string selectQurry = "select  itm.ItemId,itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],ipd.purChasePrice as [Purchase Price],ipd.SalesPrice as[Sales Price],ipd.MrpPrice as[Mrp Price],ipd.Margin as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId where " + s + " like '" + txtSearch.Text + "%'";
                DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
                dataGridView2.DataSource = dt;
            }
            else if (counter == 2)
            {
                string t = comboBox1.SelectedValue.ToString();
                string selectqurry = "select * from VendorOrderDetails where " + t + " like '" + txtSearch.Text + "%'";
                DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
                dataGridView2.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void dataGridView2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            //txtSearch.Text = "";
            int currentIndex = dataGridView2.CurrentRow.Index;
            if (counter == 0)
            {
                panel2.Visible = false;
                DataGridViewCellCollection CellCollection = dataGridView2.Rows[currentIndex - 1].Cells;
                if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                {
                    setDetails(CellCollection);
                }
            }
            else if (counter == 1)
            {
                panel2.Visible = false;
                DataGridViewCellCollection CellCollection = dataGridView2.Rows[currentIndex - 1].Cells;
                if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                {
                    setDetails1(CellCollection);
                    txtQuentity.ReadOnly = false;
                    buttAddItem.Enabled = true;
                }
            }
            else if (counter == 2)
            {
                panel2.Visible = false;
                DataGridViewCellCollection CellCollection = dataGridView2.SelectedRows[0].Cells;
                if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                {
                    string s = CellCollection[0].Value.ToString();
                    string s1 = CellCollection[1].Value.ToString();
                    //MessageBox.Show(" "+s +" "+s1);
                    string selectqurry = "select venderId,vName,vCompName,vAddress,vPhone,vMobile,vFax from VendorDetails where venderId='" + s1 + "'";
                    SetVendor(selectqurry);
                    //DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    txtVendorId.Text = dr[0].ToString();
                    //    txtVendorName.Text = dr[1].ToString();
                    //    txtVendorCompanyName.Text = dr[2].ToString();
                    //    txtVendorAddress.Text = dr[3].ToString();
                    //    txtPhone.Text = dr[4].ToString();
                    //    txtMobile.Text = dr[5].ToString();
                    //    txtFax.Text = dr[6].ToString();
                    //}
                    string selectqurry1 = "select vodd.ItemId,td.ItemName, vodd.Quantity,vodd.Price,vodd.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId where vod. Orderid='" + s + "'";
                    DataTable dt1 = dbMainClass.getDetailByQuery(selectqurry1);
                    List<string> ls = new List<string>();
                    DataColumnCollection d = dt1.Columns;
                    for (int a = 1; a < d.Count; a++)
                    {
                        DataColumn dc = new DataColumn();
                        string b = d[a].ToString();
                        ls.Add(b);
                    }
                    comboBox1.DataSource = ls;
                    dataGridView1.DataSource = dt1;
                }
            }
        }

        private void dataGridView2_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            txtSearch.Text = "";
            if (counter == 0)
            {
                panel2.Visible = false;
                DataGridViewCellCollection CellCollection = dataGridView2.Rows[e.RowIndex].Cells;
                if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                {
                    setDetails(CellCollection);
                }
            }
            else if (counter == 1)
            {
                panel2.Visible = false;
                DataGridViewCellCollection CellCollection = dataGridView2.Rows[e.RowIndex].Cells;
                if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                {
                    setDetails1(CellCollection);
                    txtQuentity.ReadOnly = false;
                    buttAddItem.Enabled = true;
                }
            }
            else if (counter == 2)
            {
                panel2.Visible = false;
                DataGridViewCellCollection CellCollection = dataGridView2.Rows[e.RowIndex].Cells;
                if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                {
                    string s = CellCollection[0].Value.ToString();
                    string s1 = CellCollection[1].Value.ToString();
                    //MessageBox.Show(" "+s +" "+s1);
                    string selectqurry = "select venderId,vName,vCompName,vAddress,vPhone,vMobile,vFax from VendorDetails where venderId='" + s1 + "'";
                    SetVendor(selectqurry);
                    //DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    txtVendorId.Text = dr[0].ToString();
                    //    txtVendorName.Text = dr[1].ToString();
                    //    txtVendorCompanyName.Text = dr[2].ToString();
                    //    txtVendorAddress.Text = dr[3].ToString();
                    //    txtPhone.Text = dr[4].ToString();
                    //    txtMobile.Text = dr[5].ToString();
                    //    txtFax.Text = dr[6].ToString();
                    //}
                    string selectqurry1 = "select vodd.ItemId,td.ItemName, vodd.Quantity,vodd.Price,vodd.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId where vod. Orderid='" + s + "'";
                    DataTable dt1 = dbMainClass.getDetailByQuery(selectqurry1);
                    List<string> ls = new List<string>();
                    DataColumnCollection d = dt1.Columns;
                    for (int a = 1; a < d.Count; a++)
                    {
                        DataColumn dc = new DataColumn();
                        string b = d[a].ToString();
                        ls.Add(b);
                    }
                    comboBox1.DataSource = ls;
                    dataGridView1.DataSource = dt1;
                }
            }
        }

        private void txtItemId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    if (txtItemId.Text == "")
                    {
                        txtItemId.Text = "I";
                    }
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtVendorId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    if (txtVendorId.Text == "")
                    {
                        txtVendorId.Text = "V";
                    }
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
