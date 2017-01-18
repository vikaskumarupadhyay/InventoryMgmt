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
    public partial class Form7 : Form
    {
        public int counter = 0;
        DB_Main dbMainClass = new DB_Main();
        DataTable vendorDetails = new DataTable();
        DataTable ItemDetails = new DataTable();
        DataTable addToCartTable = new DataTable();
       
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            IndexTex1();
            txtQunty.ReadOnly = true;
            button4.Enabled = false;
            button3.Enabled = false;
            txtdate.Value = DateTime.Now;
            string stlect = "select Deliveryid from CustomerOrderDelivery";
            DataTable dt = dbMainClass.getDetailByQuery(stlect);
            string id = "";
            foreach (DataRow dr in dt.Rows)
            {
                id = dr[0].ToString();
            }
            //txtSrNo.Text = id;
            if (id == "")
            {
                id = "1";
                txtSrNo.Text = id;
            }
            else
            {
                int txt = Convert.ToInt32(id);
                int txt1 = txt + 1;
                txtSrNo.Text = txt1.ToString();
            }
            panel2.Visible = false;

            Purchase.PurchaseDetails purChaseDetailObj = new Purchase.PurchaseDetails();
            vendorDetails = purChaseDetailObj.GetVendorDetaisInDataTable();
            ItemDetails = purChaseDetailObj.GetItemPriceAndNameDetaisInDataTable();
            setAutoCompleteMode(txtProductName, "ItemName", ItemDetails);
            setAddToCraftTable();
        }
        private void setVAlue()
        {
            if (vendorDetails.Rows.Count > 0)
            {
                string vendorId = textVendercod.Text;
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
                        txtAddress.Text = vendorAddress;
                        txtCompanyName.Text = vendorCompName;
                        txtPhone.Text = vendorPhone;
                        txtMobile.Text = vendorMobile;
                        txtFax.Text = vendorFax;
                    }
                    else
                    {
                        txtVendorName.Text = "";
                        txtAddress.Text = "";
                        txtCompanyName.Text = "";
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
                            txtQunty.Focus();
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

        private void button1_Click(object sender, EventArgs e)
        {
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
            IndexTex();
        }

        private void setDetails(DataGridViewCellCollection cellCollection)
        {
            try
            {
                textVendercod.Text = cellCollection[0].Value.ToString();
                txtVendorName.Text = cellCollection[1].Value.ToString();
                txtCompanyName.Text = cellCollection[2].Value.ToString();
                txtAddress.Text = cellCollection[3].Value.ToString();
                txtPhone.Text = cellCollection[10].Value.ToString();
                txtMobile.Text = cellCollection[11].Value.ToString();
                txtFax.Text = cellCollection[12].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }
        private void setDetails1(DataGridViewCellCollection cellCollection)
        {
            try
            {
                txtItemCode.Text = cellCollection[0].Value.ToString();
                txtProductName.Text = cellCollection[1].Value.ToString();
                txtRate.Text = cellCollection[6].Value.ToString();
                //txtAmount.Text = cellCollection[4].Value.ToString();
                // txtQuanity.Text = cellCollection[4].Value.ToString();

            }
            catch (Exception ex)
            {
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSearch.Text = "";
            comboBox1.SelectedIndex = 0;
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
                txtQunty.ReadOnly = false;
                button3.Enabled = true;
            }
            if (counter == 2)
            {
                panel2.Visible = false;
                DataGridViewCellCollection CellCollection = dataGridView2.Rows[e.RowIndex].Cells;
                string s = CellCollection[0].Value.ToString();
                string s1 = CellCollection[1].Value.ToString();
                txtRef.Text = s;
                //MessageBox.Show(" "+s +" "+s1);
                string selectqurry = "select venderId,vName,vCompName,vAddress,vPhone,vMobile,vFax from VendorDetails where venderId='" + s1 + "'";
                makeBlnk(selectqurry);
                //DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
                //foreach (DataRow dr in dt.Rows)
                //{
                //    textVendercod.Text = dr[0].ToString();
                //    txtVendorName.Text = dr[1].ToString();
                //    txtCompanyName.Text = dr[2].ToString();
                //    txtAddress.Text = dr[3].ToString();
                //    txtPhone.Text = dr[4].ToString();
                //    txtMobile.Text = dr[5].ToString();
                //    txtFax.Text = dr[6].ToString();
                //}
                string selectqurry1 = "select vodd.ItemId,td.ItemName, vodd.Quantity,vodd.Price,vodd.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId where vod. Orderid='" + s + "'";
                DataTable dt1 = dbMainClass.getDetailByQuery(selectqurry1);
                dataGridView1.DataSource = dt1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
            IndexTex();

        }

        private void btnSelectPurchaseOrder_Click(object sender, EventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textVendercod_TextChanged(object sender, EventArgs e)
        {
            if (textVendercod.Text.Trim() != "" && textVendercod.Text.StartsWith("V"))
            {
                setVAlue();
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
            string value = txtProductName.SelectedText;
            string val = txtProductName.Text;
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//|| e.KeyCode==Keys.Space) 
            {
                setitemVlue("ItemName", txtProductName.Text.Trim());
                txtQunty.Focus();
            }
        }

        private void txtQunty_TextChanged(object sender, EventArgs e)
        {
            string QuantiTy = txtQunty.Text;
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
        private void button3_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            txtQunty.TabStop = false;
            txtQunty.Enabled = false;
                 if (txtProductName.Text==""&&txtQunty.Text=="")
                  {
                    //MessageBox.Show("now CurrentQuantity of deadt");
                  }
                  else
             {
           
            DataRow dr = addToCartTable.NewRow();
            dr[0] = txtItemCode.Text.Trim();
            dr[1] = txtProductName.Text.Trim();
            dr[2] = txtRate.Text.Trim();
            dr[3] = txtQunty.Text.Trim();
            dr[4] = txtQunty.Text.Trim();
            dr[5] = txtAmount.Text.Trim();
            addToCartTable.Rows.Add(dr);

            dataGridView1.DataSource = addToCartTable;
            double totalAmount = Convert.ToDouble(txttotalAmount.Text);
            totalAmount += Convert.ToDouble(txtAmount.Text.Trim());
            txttotalAmount.Text = totalAmount.ToString();

            txtItemCode.Text = "I";
            txtProductName.Text = "";
            txtRate.Text = "";
            txtQunty.Text = "";
            txtAmount.Text = "0.0";
            txtItemCode.Focus();
            txtQunty.TabStop = false;
            txtQunty.Enabled = false;
            button3.Enabled = false;
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
            addToCartTable.Columns.Add(new DataColumn("ResivQuantity"));
            addToCartTable.Columns.Add(new DataColumn("Amount"));
        }
        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Focus();
                //if (addToCartTable.Rows.Count > 0)
                //{
                    
                //    string Amount = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                //    double totalAmount = Convert.ToDouble(txttotalAmount.Text);
                //    totalAmount -= Convert.ToDouble(Amount.Trim());
                //    txttotalAmount.Text = totalAmount.ToString();
                //    int index = dataGridView1.SelectedRows[0].Index;
                //    addToCartTable.Rows.RemoveAt(index);

                //    dataGridView1.DataSource = addToCartTable;
                //    if (addToCartTable.Rows.Count == 0)
                //    {
                //        txttotalAmount.Text = "0.0";
                //        txtdis.Text = "0.0";
                //    }
                //    if (dataGridView1.Rows.Count > 0)
                //    {
                //        button4.Enabled = true;
                //    }
                //    else
                //    {
                     button4.Enabled = false;
                     txtQunty.Enabled = false;
                     txtQunty.TabStop = false;
                //    }
                     
                //}
           
           
        }

        private void txtdis_TextChanged(object sender, EventArgs e)
        {
            double totalAmount = 0.00;//Convert.ToDouble(txttotalAmount.Text);
            foreach (DataRow dr in addToCartTable.Rows)
            {
                totalAmount += Convert.ToDouble(dr[4].ToString());
            }
            string discountAmount = txtdis.Text;
            //double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
            double amount = 0.0;
            if (double.TryParse(discountAmount, out amount))
            {
                double totalDiscount = Convert.ToDouble(discountAmount);
                totalAmount = totalAmount - ((totalAmount * totalDiscount) / 100);
                txttotalAmount.Text = totalAmount.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtRef.Text == "")
            {
                string order = "select orderId from VendorOrderDetails";
                DataTable dt1 = dbMainClass.getDetailByQuery(order);
                string id2 = "";
                foreach (DataRow dr in dt1.Rows)
                {
                    id2 = dr[0].ToString();
                }
                string OrderID = "";
                if (id2 == "")
                {
                    id2 = "1";
                    OrderID = id2;
                    string insertqurry = "insert into VendorOrderDetails values('" + textVendercod.Text + "','" + txtdate.Text + "','" + txttotalAmount.Text + "','"+txtdis.Text+"','"+txtvat.Text+"','"+txtgst.Text+"','"+txtdis.Text+"','"+txttotalAmount.Text+"')";
                    int insertedRows = dbMainClass.saveDetails(insertqurry);
                    if (insertedRows > 0)
                    {
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
                            string deleteQurry = "delete VendorOrderDesc where Orderid='" + OrderID+ "'";
                            DataTable dt = dbMainClass.getDetailByQuery(deleteQurry);


                            DataGridViewRowCollection RowCollection1 = dataGridView1.Rows;
                            List<string> sf1 = new List<string>();
                            for (int a = 0; a < RowCollection1.Count; a++)
                            {

                                DataGridViewRow currentRow = RowCollection1[a];
                                DataGridViewCellCollection cellCollection = currentRow.Cells;
                                string txtItemCode = cellCollection[0].Value.ToString();
                                string txtRate = cellCollection[2].Value.ToString();
                                string txtQuanity = cellCollection[4].Value.ToString();
                                string txtAmoun = cellCollection[5].Value.ToString();
                                //string OrderID1 = OrderID;

                                string Query = "insert into VendorOrderDesc Values('" + OrderID + "','" + txtItemCode + "','" + txtRate + "','" + txtQuanity + "','" + txtAmoun + "')";
                                //MessageBox.Show(Query);

                                sf1.Add(Query);

                            }
                            int insertedRows2 = dbMainClass.saveDetails(sf1);
                            if (insertedRows2 > 0)
                            {
                                string insertQurry = "insert into CustomerOrderDelivery Values('" + OrderID + "','true','" + txtdate.Text + "')";
                                int insertedRows3 = dbMainClass.saveDetails(insertQurry);
                                if (insertedRows3 > 0)
                                {
                                    MessageBox.Show("Details Saved Successfully");
                                }
                                else
                                {
                                    MessageBox.Show("Details Not Saved Successfully");
                                }
                            }
                            //    MessageBox.Show("Details Saved Successfully");
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Details Not Saved Successfully");
                            //}
                        }
                    }
                }
                else
                {
                    int id3 = Convert.ToInt32(id2);
                    int id4 = id3 + 1;
                    OrderID = id4.ToString();
                    string insertqurry1 = "insert into VendorOrderDetails values('" + textVendercod.Text + "','" + txtdate.Text + "','" + txttotalAmount.Text + "','" + txtdis.Text + "','" + txtvat.Text + "','" + txtgst.Text + "','" + txtdis.Text + "','" + txttotalAmount.Text + "')";
                    int insertedRows1 = dbMainClass.saveDetails(insertqurry1);
                    if (insertedRows1 > 0)
                    {
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
                        int insertedRows2 = dbMainClass.saveDetails(sf);
                        if (insertedRows2 > 0)
                        {
                            string deleteQurry = "delete VendorOrderDesc where Orderid='" + OrderID + "'";
                            DataTable dt = dbMainClass.getDetailByQuery(deleteQurry);


                            DataGridViewRowCollection RowCollection2 = dataGridView1.Rows;
                            List<string> sf1 = new List<string>();
                            for (int a = 0; a < RowCollection.Count; a++)
                            {

                                DataGridViewRow currentRow = RowCollection2[a];
                                DataGridViewCellCollection cellCollection = currentRow.Cells;
                                string txtItemCode = cellCollection[0].Value.ToString();
                                string txtRate = cellCollection[2].Value.ToString();
                                string txtQuanity = cellCollection[4].Value.ToString();
                                string txtAmoun = cellCollection[5].Value.ToString();
                               // string OrderID = id4.ToString(); ;

                                string Query = "insert into VendorOrderDesc Values('" + OrderID + "','" + txtItemCode + "','" + txtRate + "','" + txtQuanity + "','" + txtAmoun + "')";
                                //MessageBox.Show(Query);

                                sf1.Add(Query);

                            }
                            int insertedRows4 = dbMainClass.saveDetails(sf1);
                            if (insertedRows4 > 0)
                            {
                                string insertQurry = "insert into CustomerOrderDelivery Values('" + OrderID + "','true','" + txtdate.Text + "')";
                                int insertedRows5 = dbMainClass.saveDetails(insertQurry);
                                if (insertedRows5 > 0)
                                {
                                    MessageBox.Show("Details Saved Successfully");
                                }
                                else
                                {
                                    MessageBox.Show("Details Not Saved Successfully");
                                }
                            }
                            //    MessageBox.Show("Details Saved Successfully");
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Details Not Saved Successfully");
                            //}
                        }
                    }
                }
            }
            else if (txtRef.Text != "")
            {
                string deleteQurry = "delete VendorOrderDesc where Orderid='" + txtRef.Text + "'";
                DataTable dt = dbMainClass.getDetailByQuery(deleteQurry);
                //dataGridView1.DataSource = "";


                counter = 0;
                if (counter == 0)
                {


                    DataGridViewRowCollection RowCollection = dataGridView1.Rows;
                    List<string> sf1 = new List<string>();
                    for (int a = 0; a < RowCollection.Count; a++)
                    {

                        DataGridViewRow currentRow = RowCollection[a];
                        DataGridViewCellCollection cellCollection = currentRow.Cells;
                        string txtItemCode = cellCollection[0].Value.ToString();
                        string txtRate = cellCollection[2].Value.ToString();
                        string txtQuanity = cellCollection[4].Value.ToString();
                        string txtAmoun = cellCollection[5].Value.ToString();
                        string OrderID = txtRef.Text;

                        string Query = "insert into VendorOrderDesc Values('" + OrderID + "','" + txtItemCode + "','" + txtRate + "','" + txtQuanity + "','" + txtAmoun + "')";
                        //MessageBox.Show(Query);

                        sf1.Add(Query);

                    }
                    int insertedRows1 = dbMainClass.saveDetails(sf1);
                    if (insertedRows1 > 0)
                    {
                        string insertQurry = "insert into CustomerOrderDelivery Values('" + txtRef.Text + "','true','" + txtdate.Text + "')";
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
            makeBlank();
            int id = Convert.ToInt32(txtSrNo.Text);
            int id1 = id + 1;
            txtSrNo.Text = id1.ToString();

        }
        private void txtQunty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                button3.Focus();
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           
        }



        private void txtRef_TextChanged(object sender, EventArgs e)
        {
            string tot = "";
            int totel = 0;
            string select = "select vo.Orderid,vo.venderId,vod.ItemId,vo.Discount from VendorOrderDesc vod join VendorOrderDetails vo on vod.Orderid=vo.Orderid where vo.Orderid='" + txtRef.Text + "'";
            DataTable dt = dbMainClass.getDetailByQuery(select);
            //string dis = "";
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                string a = dr[1].ToString();
                string dis = dr[3].ToString();
               txtdis.Text = dis;
               //txttotalAmount.Text = dis;
                string select1 = "select venderId,vName,vCompName,vAddress ,vPhone,vMobile,vFax from VendorDetails where venderId='" + a + "'";
                makeBlnk(select1);
                //DataTable dt1 = dbMainClass.getDetailByQuery(select1);
                //foreach (DataRow dr1 in dt1.Rows)
                //{
                //    textVendercod.Text = dr1[0].ToString();
                //    txtVendorName.Text = dr1[1].ToString();
                //    txtCompanyName.Text = dr1[2].ToString();
                //    txtAddress.Text = dr1[3].ToString();
                //    txtPhone.Text = dr1[4].ToString();
                //    txtMobile.Text = dr1[5].ToString();
                //    txtFax.Text = dr1[6].ToString();
                //}
               
                string b = dr[0].ToString();
                string selectqurry1 = "select vodd.ItemId,td.ItemName, vodd.Quantity,vodd.Price,vodd.TotalPrice,vod.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId where vod. Orderid='" + b + "'";
                DataTable dt2 = dbMainClass.getDetailByQuery(selectqurry1);
                int totalRowCount = addToCartTable.Rows.Count;
                for(int rowCount=0;rowCount<totalRowCount;rowCount++)
                {
                    addToCartTable.Rows.RemoveAt(0);
                }

                for (int c = 0; c < dt2.Rows.Count; c++)
                {
                    DataRow dr2 = dt2.Rows[c];
                    string txtItemCode = dr2[0].ToString();
                    string txtRate = dr2[1].ToString();
                    string txtQuanity = dr2[2].ToString();
                    string txtAmoun = dr2[3].ToString();
                    string txtitemNmae = dr2[4].ToString();
                    string txtitemNmea = dr2[5].ToString();
                    tot = txtitemNmea;
                    //int amt = Convert.ToInt32(txtitemNmea);
                    //totel = totel + amt;
                    dr2 = addToCartTable.NewRow();
                    dr2[0] = txtItemCode.Trim();
                    dr2[1] = txtRate.Trim();
                    dr2[3] = txtQuanity.Trim();
                    dr2[2] = txtAmoun.Trim();
                    dr2[4] = txtQuanity.Trim();
                    dr2[5] = txtitemNmae.Trim();
                   // dr2[5] = textBox1.Text.Trim();
                    addToCartTable.Rows.Add(dr2);
                }
                dataGridView1.DataSource = addToCartTable;
                txttotalAmount.Text = tot;
            }
        }

        private void txtRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    makeBlank();
                    //textVendercod.Text = "V";
                    //txtVendorName.Text = "";
                    //txtAddress.Text = "";
                    //txtCompanyName.Text = "";
                    //txtPhone.Text = "";
                    //txtMobile.Text = "";
                    //txtFax.Text = "";
                    //txtRef.Text = "";
                    //dataGridView1.DataSource = "";
                  
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        private void makeBlank()
        {
            textVendercod.Text = "V";
            txtVendorName.Text = "";
            txtAddress.Text = "";
            txtCompanyName.Text = "";
            txtPhone.Text = "";
            txtMobile.Text = "";
            txtFax.Text = "";
            txttotalAmount.Text = "";
            dataGridView1.DataSource = "";
            addToCartTable.Clear();
            txtRef.Text = "";

        }
        private void makeBlnk(string r)
        {
            DataTable dt = dbMainClass.getDetailByQuery(r);
            foreach (DataRow dr in dt.Rows)
            {
                textVendercod.Text = dr[0].ToString();
                txtVendorName.Text = dr[1].ToString();
                txtCompanyName.Text = dr[2].ToString();
                txtAddress.Text = dr[3].ToString();
                txtPhone.Text = dr[4].ToString();
                txtMobile.Text = dr[5].ToString();
                txtFax.Text = dr[6].ToString();
            }
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //string a = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //MessageBox.Show(a);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string a = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            string rate = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            int quantity = Convert.ToInt32(a);
            int reta = Convert.ToInt32(rate);
            int toteamount = quantity * reta;
            dataGridView1.Rows[e.RowIndex].Cells[5].Value = toteamount.ToString();
            string qun = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            int quanti = Convert.ToInt32(qun);
            int vauequn = quanti - quantity;
            int trea = reta * vauequn;
            int tamunt = Convert.ToInt32(txttotalAmount.Text);
            int tam = tamunt - trea;
            txttotalAmount.Text = tam.ToString();

        }

        private void butClose_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                dataGridView1.Focus();
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                button5.Focus();
                button7.TabStop = true;
                btnSelectPurchaseOrder.TabStop = true;
            }
            //    button4.Enabled = true;
            //}
            //else
            //{
            //    button4.Enabled = false;
            //}
        }

        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtQunty.ReadOnly = false;
                button3.Enabled = true;
                txtQunty.Enabled = true;
                txtQunty.Focus();
                IndexTex2();
                textVendercod.TabStop = false;
                button1.TabStop = false;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                if (dataGridView1.Rows != null && dataGridView1.RowCount > 0)
                {
                    button4.Focus();
                }
                else
                {
                    button5.Focus();
                }
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
                    txtQunty.Text = "";
                    txtItemCode.Focus();

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

        private void button3_Leave(object sender, EventArgs e)
        {
           // button3.Enabled = false;
        }

        private void IndexTex()
        {
            comboBox1.Focus();
            textVendercod.TabStop = false;
            button1.TabStop = false;
            txtItemCode.TabStop = false;
            button2.TabStop = false;
            button7.TabStop = false;
            button5.TabStop = false;
            btnSelectPurchaseOrder.TabStop = false;
            txtdis.TabStop = false;
            txtQunty.TabStop = false;
            txtItemCode.TabStop = false;
            button4.TabStop = false;
            txtProductName.TabStop = false;
            button3.TabStop = false;
            panel2.TabStop = false;
            panel1.TabStop = false;
            txtRate.TabStop = false;
            txtAmount.TabStop = false;
            txtRef.TabStop = false;
        }
        private void IndexTex3()
        {
            txtItemCode.Focus();
            txtItemCode.TabStop = true;
            button2.TabStop = true;
            textVendercod.TabStop = false;
            button1.TabStop = false;
            textVendercod.TabStop = true;
            button1.TabStop = true;
        }
        private void IndexTex1()
        {
           //txtVendorCode.TabStop = false;
            button1.TabStop = true; ;
            txtItemCode.TabStop = false;
            button2.TabStop = false;
            button7.TabStop = false;
            button5.TabStop = false;
            txtdis.TabStop = false;
            txtQunty.TabStop = false;
            txtItemCode.TabStop = false;
            txtProductName.TabStop = false;
            button3.TabStop = false;
            panel2.TabStop = false;
            //panel1.TabStop = false;
            txtRef.TabStop = false;
            txtAmount.TabStop = false;
            txtRate.TabStop = false;
            btnSelectPurchaseOrder.TabStop = false;
        }
        private void IndexTex2()
        {
            txtItemCode.TabStop = true;
            button2.TabStop = true;
            txtdis.TabStop = false;
            txtQunty.TabStop = true;
            button3.TabStop = true;
            button4.TabStop = true;
            panel2.TabStop = false;
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                if (addToCartTable.Rows.Count > 0)
                {

                    string Amount = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    double totalAmount = Convert.ToDouble(txttotalAmount.Text);
                    totalAmount -= Convert.ToDouble(Amount.Trim());
                    txttotalAmount.Text = totalAmount.ToString();
                    int index = dataGridView1.SelectedRows[0].Index;
                    addToCartTable.Rows.RemoveAt(index);

                    dataGridView1.DataSource = addToCartTable;
                    if (addToCartTable.Rows.Count == 0)
                    {
                        txttotalAmount.Text = "0.0";
                        txtdis.Text = "0.0";
                    }
                    if (dataGridView1.Rows.Count == 0)
                    {
                        txtItemCode.Focus();
                    }
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
                    }
                    //else
                    //{
                    //    button4.Enabled = false;
                    //}
                }
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtItemCode.Focus();
                button4.Enabled = true;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textVendercod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                IndexTex3();
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                IndexTex3();
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                string s = comboBox1.SelectedValue.ToString();
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

        private void dataGridView2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            txtSearch.Text = "";
            comboBox1.SelectedIndex = 0;
            int currentIndex = dataGridView2.CurrentRow.Index;
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (dataGridView1.RowCount == currentIndex + 1)
                    currentIndex = currentIndex + 1;
                if (counter == 0)
                {
                    panel2.Visible = false;
                    DataGridViewCellCollection CellCollection = dataGridView2.Rows[currentIndex - 1].Cells;
                    setDetails(CellCollection);
                    IndexTex3();
                }
                if (counter == 1)
                {
                    panel2.Visible = false;
                    DataGridViewCellCollection CellCollection = dataGridView2.Rows[currentIndex - 1].Cells;
                    setDetails1(CellCollection);
                    txtQunty.ReadOnly = false;
                    button3.Enabled = true;
                    txtQunty.Focus();
                    IndexTex2();
                    txtQunty.Enabled = true;
                }
                if (counter == 2)
                {
                    panel2.Visible = false;
                    DataGridViewCellCollection CellCollection = dataGridView1.Rows[currentIndex - 1].Cells;
                    string s = CellCollection[0].Value.ToString();
                    string s1 = CellCollection[1].Value.ToString();
                    txtRef.Text = s;
                    //MessageBox.Show(" "+s +" "+s1);
                    string selectqurry = "select venderId,vName,vCompName,vAddress,vPhone,vMobile,vFax from VendorDetails where venderId='" + s1 + "'";
                    makeBlnk(selectqurry);
                    //DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    textVendercod.Text = dr[0].ToString();
                    //    txtVendorName.Text = dr[1].ToString();
                    //    txtCompanyName.Text = dr[2].ToString();
                    //    txtAddress.Text = dr[3].ToString();
                    //    txtPhone.Text = dr[4].ToString();
                    //    txtMobile.Text = dr[5].ToString();
                    //    txtFax.Text = dr[6].ToString();
                    //}
                    string selectqurry1 = "select  itm.ItemId,itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],ipd.purChasePrice as [Purchase Price],ipd.SalesPrice as[Sales Price],ipd.MrpPrice as[Mrp Price],ipd.Margin as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId where vod. Orderid='" + s + "'";
                    DataTable dt1 = dbMainClass.getDetailByQuery(selectqurry1);
                    dataGridView1.DataSource = dt1;
                }
            }
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtSearch.Text = "";
            comboBox1.SelectedIndex = 0;
            int currentIndex = dataGridView2.CurrentRow.Index;
                if (dataGridView1.RowCount == currentIndex + 1)
                    currentIndex = currentIndex + 1;
                if (counter == 0)
                {
                    panel2.Visible = false;
                    DataGridViewCellCollection CellCollection = dataGridView2.Rows[e.RowIndex].Cells;
                    setDetails(CellCollection);
                    IndexTex3();
                }
                if (counter == 1)
                {
                    panel2.Visible = false;
                    DataGridViewCellCollection CellCollection = dataGridView2.Rows[e.RowIndex].Cells;
                    setDetails1(CellCollection);
                    txtQunty.ReadOnly = false;
                    button3.Enabled = true;
                    txtQunty.Focus();
                    IndexTex2();
                    txtQunty.Enabled = true;
                }
                if (counter == 2)
                {
                    panel2.Visible = false;
                    DataGridViewCellCollection CellCollection = dataGridView1.Rows[e.RowIndex].Cells;
                    string s = CellCollection[0].Value.ToString();
                    string s1 = CellCollection[1].Value.ToString();
                    txtRef.Text = s;
                    //MessageBox.Show(" "+s +" "+s1);
                    string selectqurry = "select venderId,vName,vCompName,vAddress,vPhone,vMobile,vFax from VendorDetails where venderId='" + s1 + "'";
                    makeBlnk(selectqurry);
                    //DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    textVendercod.Text = dr[0].ToString();
                    //    txtVendorName.Text = dr[1].ToString();
                    //    txtCompanyName.Text = dr[2].ToString();
                    //    txtAddress.Text = dr[3].ToString();
                    //    txtPhone.Text = dr[4].ToString();
                    //    txtMobile.Text = dr[5].ToString();
                    //    txtFax.Text = dr[6].ToString();
                    //}
                    string selectqurry1 = "select  itm.ItemId,itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],ipd.purChasePrice as [Purchase Price],ipd.SalesPrice as[Sales Price],ipd.MrpPrice as[Mrp Price],ipd.Margin as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId where vod. Orderid='" + s + "'";
                    DataTable dt1 = dbMainClass.getDetailByQuery(selectqurry1);
                    dataGridView1.DataSource = dt1;
            }
        }

        private void button5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                textVendercod.Focus();
            }
        }

        private void btnSelectPurchaseOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                textVendercod.Focus();
            }
        }

        private void button7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                textVendercod.Focus();
            }
        }
    }
        
}
