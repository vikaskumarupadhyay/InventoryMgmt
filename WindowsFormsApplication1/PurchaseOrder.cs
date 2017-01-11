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
    public partial class PurchaseOrder : Form
    {
        public PurchaseOrder()
        {
            InitializeComponent();
        }
        public int counter = 0;
        DB_Main dbMainClass = new DB_Main();
        DataTable vendorDetails = new DataTable();
        DataTable ItemDetails = new DataTable();
        DataTable addToCartTable = new DataTable();

        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            IndexTex1();
            btnAddItem.Enabled = false;
            txtRemoveItem.Enabled = false;
            txtQuanity.ReadOnly = true;
            dtpDate.Value = DateTime.Now;
            panel2.Visible = false;
            SqlConnection con = dbMainClass.openConnection();
            string stlect = "select  Orderid from VendorOrderDetails";
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
            setAutoCompleteMode(txtProductName, "ItemName", ItemDetails);
            setAddToCraftTable();
            //setAutoCompleteMode(txtVendorName, "Name", vendorDetails);
        }

        private void txtVendorCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                IndexTex3();
            }
        }

        private void txtVendorCode_KeyUp(object sender, KeyEventArgs e)
        {

        }
        private void setVAlue()
        {
            if (vendorDetails.Rows.Count > 0)
            {
                string vendorId = txtVendorCode.Text;
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
                        txtVendorPhone.Text = vendorPhone;
                        txtVendorMobile.Text = vendorMobile;
                        txtVendorFax.Text = vendorFax;
                    }
                    else
                    {
                        txtVendorName.Text = "";
                        txtVendorAddress.Text = "";
                        txtVendorCompanyName.Text = "";
                        txtVendorPhone.Text = "";
                        txtVendorMobile.Text = "";
                        txtVendorFax.Text = "";
                    }
                }
            }
        }

        private void txtVendorCode_Leave(object sender, EventArgs e)
        {
            ///setVAlue();
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

        private void txtVendorCode_TextChanged(object sender, EventArgs e)
        {

            if (txtVendorCode.Text.Trim() != "" && txtVendorCode.Text.StartsWith("V"))
            {
                setVAlue();
                
            }
        }



        private void setitemVlue(string ColumnName, string value)
        {
            if (ItemDetails.Rows.Count > 0)
            {
                string ItemId = txtItemCode.Text;
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
                        txtProductName.Text = ItemName;

                        txtItemCode.Text = itemCode;

                        if (ColumnName.StartsWith("ItemId"))
                        {
                            txtQuanity.Focus();
                        }
                    }
                    else
                    {
                        txtRate.Text = "";
                        if (ColumnName.StartsWith("ItemId"))
                        {
                            txtProductName.Text = "";
                        }
                        else if (ColumnName.StartsWith("ItemName"))
                        {
                            txtItemCode.Text = "";
                        }

                    }
                }
            }
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
       {
            string itemCode = txtItemCode.Text;
            setitemVlue("ItemId", itemCode);
            txtItemCode.Focus();
           
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            string value = txtProductName.SelectedText;
            string val = txtProductName.Text;
        }

        private void txtProductName_Leave(object sender, EventArgs e)
        {
            string ItemName = txtProductName.Text.Trim();
            setitemVlue("ItemName", ItemName);
        }

        private void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
          

        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//|| e.KeyCode==Keys.Space) 
            {
                setitemVlue("ItemName", txtProductName.Text.Trim());
                txtQuanity.Focus();
            }
        }

        private void txtQuanity_TextChanged(object sender, EventArgs e)
        {

            string QuantiTy = txtQuanity.Text;
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

        #region /////////// AddToList Clicked ///////////////
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            txtItemCode.Focus();
            txtVendorCode.TabStop = false;
            button1.TabStop = false;
            txtDiscount.TabStop = false;
            //txtRemoveItem.Focus();
           
            //string qurry = "select CurrentQuantity from ItemQuantityDetail where ItemId='" + txtItemCode.Text + "'";
            //DataTable dt = dbMainClass.getDetailByQuery(qurry);
            //string id = "";
            //foreach (DataRow dr in dt.Rows)
            //{
            //    id = dr["CurrentQuantity"].ToString();
            //}

            //int curentQuntity = Convert.ToInt32(txtQuanity.Text);
            //int cuentQuantity = Convert.ToInt32(id);
            //if (cuentQuantity == 0)
            //{
            //    MessageBox.Show("now CurrentQuantity of deadt");
            //    txtQuanity.Text = "";
            //}
            //else
            //{
            //    if (cuentQuantity < curentQuntity)
            //    {
            //        MessageBox.Show("now CurrentQuantity of deadt");
            //    }
            //    else
            //    {
            if (txtProductName.Text == "" && txtQuanity.Text == "")
            {
               // MessageBox.Show("please enter the ");
            }
            else
            {
                txtRemoveItem.Enabled = true;
                    DataRow dr = addToCartTable.NewRow();
                    dr[0] = txtItemCode.Text.Trim();
                    dr[1] = txtProductName.Text.Trim();
                    dr[2] = txtRate.Text.Trim();
                    dr[3] = txtQuanity.Text.Trim();
                    dr[4] = txtAmount.Text.Trim();
                    addToCartTable.Rows.Add(dr);
                    gridPurchaseOrder.DataSource = addToCartTable;
                    double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
                    totalAmount += Convert.ToDouble(txtAmount.Text.Trim());
                    txtTotalAmount.Text = totalAmount.ToString();

                    txtItemCode.Text = "I";
                    txtProductName.Text = "";
                    txtRate.Text = "";
                    txtQuanity.Text = "";
                    txtAmount.Text = "0.0";
                   // txtItemCode.Focus();
                    btnAddItem.Enabled = false;
                    //txtRemoveItem.Focus();
                    txtQuanity.TabStop = false;
                    txtQuanity.Enabled = false;
                }

            //}
        }
        #endregion

        #region /////////// add Column to AddToCraft DataTable///////////////
        private void setAddToCraftTable()
        {
            addToCartTable.Columns.Add(new DataColumn("ItemCode"));
            addToCartTable.Columns.Add(new DataColumn("ProductName"));
            addToCartTable.Columns.Add(new DataColumn("Rate"));
            addToCartTable.Columns.Add(new DataColumn("Quantity"));
            addToCartTable.Columns.Add(new DataColumn("Amount"));
        }
        #endregion

        private void txtRemoveItem_Click(object sender, EventArgs e)
        {
            gridPurchaseOrder.Focus();
            txtRemoveItem.Enabled = false;
           
            //if (addToCartTable.Rows.Count > 0)
            //{
            //    string Amount = gridPurchaseOrder.SelectedRows[0].Cells[4].Value.ToString();
            //    double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
            //    totalAmount -= Convert.ToDouble(Amount.Trim());
            //    txtTotalAmount.Text = totalAmount.ToString();
            //    int index = gridPurchaseOrder.SelectedRows[0].Index;
            //    addToCartTable.Rows.RemoveAt(index);

            //    gridPurchaseOrder.DataSource = addToCartTable;
            //    if (addToCartTable.Rows.Count == 0)
            //    {
            //        txtTotalAmount.Text = "0.0";
            //        txtDiscount.Text = "0.0";
            //    }
            //    if (gridPurchaseOrder.Rows.Count > 0)
            //    {
            //        txtRemoveItem.Enabled = true;
            //    }
            //    else
            //    {
            //        txtRemoveItem.Enabled =false;
            //    }
            //}
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
                txtTotalAmount.Text = totalAmount.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            dataGridView1.DataSource = dt;
           IndexTex();
           comboBox1.Focus();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }


        private void setDetails(DataGridViewCellCollection cellCollection)
        {
            try
            {
                txtVendorCode.Text = cellCollection[0].Value.ToString();
                txtVendorName.Text = cellCollection[1].Value.ToString();
                txtVendorCompanyName.Text = cellCollection[2].Value.ToString();
                txtVendorAddress.Text = cellCollection[3].Value.ToString();
                txtVendorPhone.Text = cellCollection[10].Value.ToString();
                txtVendorMobile.Text = cellCollection[11].Value.ToString();
                txtVendorFax.Text = cellCollection[12].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            //string selectqurry = "select itm.ItemName,itm.ItemCompName,itm.ItemDesc,itm.groupid,itm.Unitid,ipd.purChasePrice,ipd.SalesPrice,ipd.MrpPrice,ipd.Margin,iqd.OpeningQuantity,iqd.CurrentQuantity from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid";
            //DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            //List<string> ls = new List<string>();
            
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
            dataGridView1.DataSource = dt;
            IndexTex();
            comboBox1.Focus();
        }
        private void setDetails1(DataGridViewCellCollection cellCollection)
        {
            try
            {
                txtItemCode.Text = cellCollection[0].Value.ToString();
                txtProductName.Text = cellCollection[1].Value.ToString();
                txtRate.Text = cellCollection[6].Value.ToString();
               // txtAmount.Text = cellCollection[3].Value.ToString();
                // txtQuanity.Text = cellCollection[4].Value.ToString();

            }
            catch (Exception ex)
            {
            }
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataGridViewRowCollection call = gridPurchaseOrder.Rows;
            for (int c = 0; c < call.Count; c++)
            {
                DataGridViewRow currentRow1 = call[c];
                DataGridViewCellCollection cellCollection1 = currentRow1.Cells;
                string itid = cellCollection1[0].Value.ToString();
                string que = cellCollection1[3].Value.ToString();



                string qurry = "select CurrentQuantity from ItemQuantityDetail where ItemId='" + itid + "'";
                DataTable dt = dbMainClass.getDetailByQuery(qurry);
                string id = "";
                foreach (DataRow dr in dt.Rows)
                {
                    id = dr["CurrentQuantity"].ToString();
                }

                int curentQuntity = Convert.ToInt32(que);
                int cuentQuantity = Convert.ToInt32(id);
                int lastQuantity = cuentQuantity + curentQuntity;
                string id1 = lastQuantity.ToString();
                string updateQurry = "update ItemQuantityDetail set CurrentQuantity='" + id1 + "'where ItemId='" + itid + "'";
                int insertedRows2 = dbMainClass.saveDetails(updateQurry);
            }

            counter = 0;
            if (counter == 0)
            {
                string insertqurry = "insert into VendorOrderDetails values('" + txtVendorCode.Text + "','" + dtpDate.Text + "','" + txtTotalAmount.Text + "','"+txtDiscount.Text+"')";
                int insertedRows = dbMainClass.saveDetails(insertqurry);
                if (insertedRows > 0)
                {
                    DataGridViewRowCollection RowCollection = gridPurchaseOrder.Rows;
                    List<string> sf = new List<string>();
                    for (int a = 0; a < RowCollection.Count; a++)
                    {

                        DataGridViewRow currentRow = RowCollection[a];
                        DataGridViewCellCollection cellCollection = currentRow.Cells;
                        string txtItemCod = cellCollection[0].Value.ToString();
                        string txtRate = cellCollection[2].Value.ToString();
                        string txtQuanit = cellCollection[3].Value.ToString();
                        string txtAmoun = cellCollection[4].Value.ToString();
                        string OrderID = txtSrNo.Text;
                        string Query = "insert into VendorOrderDesc Values('" + OrderID + "','" + txtItemCod + "','" + txtRate + "','" + txtQuanit + "','" + txtAmoun + "')";
                        //MessageBox.Show(Query);
                        sf.Add(Query);
                    }
                    int insertedRows1 = dbMainClass.saveDetails(sf);

                    if (insertedRows1 > 0)
                    {
                        MessageBox.Show("Details Saved Successfully");

                        int id2 = Convert.ToInt32(txtSrNo.Text);
                        int id3 = id2 + 1;
                        txtSrNo.Text = id3.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Details Not Saved Successfully");
                    }

                }
               
            }

            makeBlank();
            txtVendorCode.Focus(); 

        }
        private void makeBlank()
        {
             txtVendorCode.Text = "V";
            txtVendorName.Text = "";
            txtVendorAddress.Text = "";
            txtVendorCompanyName.Text = "";
            txtVendorPhone.Text = "";
            txtVendorMobile.Text = "";
            txtVendorFax.Text = "";
            txtTotalAmount.Text = "";
            txtDiscount.Text = "";
            gridPurchaseOrder.DataSource = "";

        }

        private void txtQuanity_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtQuanity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnAddItem.Focus();
            }
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtsearch.Text = "";
            comboBox1.SelectedIndex = 0;
            if (counter == 0)
            {
                panel2.Visible = false;
                DataGridViewCellCollection CellCollection = dataGridView1.Rows[e.RowIndex].Cells;
                setDetails(CellCollection);
                IndexTex3();
            }
            else if (counter == 1)
            {
                panel2.Visible = false;
                DataGridViewCellCollection CellCollection = dataGridView1.Rows[e.RowIndex].Cells;
                setDetails1(CellCollection);
                txtQuanity.ReadOnly = false;
                btnAddItem.Enabled = true;
                txtQuanity.Enabled = true;
                IndexTex2();
            }

        }

        private void buttBack_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                string s = comboBox1.SelectedValue.ToString();
                //string m = "v" + s;
                string selectQurry = "select vd.venderId as [Vender Id ],vd.vName AS Name ,vd.vCompName AS [Company Name] ,vd.vAddress AS Address,vd.vCity AS City,vd. vState AS State ,vd.vZip AS Zip ,vd.vCountry AS Country ,vd.vEmail AS[E-Mail ],vd. vWebAddress AS[Web Address],vd.vPhone AS Phone ,vd.vMobile AS Mobile ,vd.vFax AS Fax ,vd.vPanNo as[PAN No],vd.vVatNo as [VAT No],vd.vCstNo as[CST No],vd.vServiceTaxRegnNo as [Service Tax Regn.No],vd.vExciseRegnNo as [Excise Regn.No],vd.vGSTRegnNo as[GST Regn.No],vd.vDesc AS Description,vad.vOpeningBalance AS [Opening Balance] , vad.vCurrentBalance AS [Current Balance] from  vendorDetails vd join    VendorAccountDetails  vad on vd.venderID=vad.venderID where " + s + " like '" + txtsearch.Text + "%'";
                DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
                dataGridView1.DataSource = dt;
            }
            else if (counter == 1)
            {
                string s = comboBox1.SelectedValue.ToString();
                string selectQurry = "select  itm.ItemId,itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],ipd.purChasePrice as [Purchase Price],ipd.SalesPrice as[Sales Price],ipd.MrpPrice as[Mrp Price],ipd.Margin as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId where " + s + " like '" + txtsearch.Text + "%'";
                DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
             txtsearch.Text = "";
            comboBox1.SelectedIndex = 0;
            int currentIndex = dataGridView1.CurrentRow.Index;
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (dataGridView1.RowCount == currentIndex + 1)
                    currentIndex = currentIndex + 1;
                if (counter == 0)
                {
                    panel2.Visible = false;
                    DataGridViewCellCollection CellCollection = dataGridView1.Rows[currentIndex - 1].Cells;
                    setDetails(CellCollection);
                    IndexTex3();
                    
                }
                else if (counter == 1)
                {
                    panel2.Visible = false;
                    DataGridViewCellCollection CellCollection = dataGridView1.Rows[currentIndex - 1].Cells;
                    setDetails1(CellCollection);
                    txtQuanity.ReadOnly = false;
                    btnAddItem.Enabled = true;
                    txtQuanity.Enabled = true;
                    IndexTex2();
                }
            }
        }

        private void btnAddItem_Leave(object sender, EventArgs e)
        {
           // btnAddItem.Enabled = false;
            //txtRemoveItem.Focus();
        }
        private void IndexTex()
        {
            txtVendorCode.TabStop = false;
            button1.TabStop = false;
            txtItemCode.TabStop = false;
            button2.TabStop = false;
            btnClose.TabStop = false;
            btnSave.TabStop = false;
            txtDiscount.TabStop = false;
            txtQuanity.TabStop = false;
            txtItemCode.TabStop = false;
            txtRemoveItem.TabStop = false;
            txtProductName.TabStop = false;
            btnAddItem.TabStop = false;
            btnClose.TabStop = false;
            btnSave.TabStop = false;
            panel2.TabStop = false;
            panel1.TabStop = false;
        }
        private void IndexTex3()
        {
            txtItemCode.Focus();
            txtItemCode.TabStop = true;
            button2.TabStop = true;
            txtVendorCode.TabStop = false;
            button1.TabStop = false;
            txtVendorCode.TabStop = true;
            button1.TabStop = true;
        }
        private void IndexTex1()
        {
           // txtVendorCode.TabStop = false;
            //button1.TabStop = false;
            txtItemCode.TabStop = false;
            button2.TabStop = false;
            btnClose.TabStop = false;
            btnSave.TabStop = false;
            txtDiscount.TabStop = false;
            txtQuanity.TabStop = false;
            txtItemCode.TabStop = false;
            txtProductName.TabStop = false;
            btnAddItem.TabStop = false;
            btnClose.TabStop = false;
            btnSave.TabStop = false;
            panel2.TabStop = false;
            panel1.TabStop = false;
        }
        private void IndexTex2()
        {
            txtQuanity.Focus();
            txtItemCode.TabStop = true;
            button2.TabStop = true;
            txtDiscount.TabStop = false;
            txtQuanity.TabStop = true;
            btnAddItem.TabStop = true;
            txtRemoveItem.TabStop = true;
        }

        private void gridPurchaseOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (addToCartTable.Rows.Count > 0)
                {
                    string Amount = gridPurchaseOrder.SelectedRows[0].Cells[4].Value.ToString();
                    double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
                    totalAmount -= Convert.ToDouble(Amount.Trim());
                    txtTotalAmount.Text = totalAmount.ToString();
                    int index = gridPurchaseOrder.SelectedRows[0].Index;
                    addToCartTable.Rows.RemoveAt(index);

                    gridPurchaseOrder.DataSource = addToCartTable;
                    if (addToCartTable.Rows.Count == 0)
                    {
                        txtTotalAmount.Text = "0.0";
                        txtDiscount.Text = "0.0";
                    }
                    if (gridPurchaseOrder.Rows.Count==0)
                    {
                        txtItemCode.Focus();
                    }
                    if (gridPurchaseOrder.Rows.Count > 0)
                    {
                        gridPurchaseOrder.Rows[gridPurchaseOrder.Rows.Count - 1].Selected = true;
                    }
                    else
                    {
                        //txtRemoveItem.Enabled = false;
                    }
                   
                }
            }
             if (e.KeyChar == Convert.ToChar(Keys.Escape))
             {
                 txtItemCode.Focus();
                 txtRemoveItem.Enabled = true;
             }

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtQuanity.ReadOnly = false;
                btnAddItem.Enabled = true;
                txtQuanity.Enabled = true;
                IndexTex2();
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtRemoveItem.Focus();
            }
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                    txtAmount.Text = "";
                    txtQuanity.Text = "";
                    txtItemCode.Focus();

                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void panel2_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void btnAddItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtItemCode.Focus();
                txtVendorCode.TabStop = false;
                button1.TabStop = false;
                txtDiscount.TabStop = false;
            }
        }

        private void txtRemoveItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                gridPurchaseOrder.Focus();
            }
        }
    }
}
