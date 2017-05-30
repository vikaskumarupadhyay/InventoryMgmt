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
        List<string> ls = new List<string>();
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

            txtDiscount.ReadOnly = true;
            txtVendorCode.Select(txtVendorCode.Text.Length, 0);
            txtItemCode.Select(txtItemCode.Text.Length, 0);
            txtdis.ReadOnly = true;
            PurchesCrystalReportViewer.Visible = false;
            txtwithautaxamount.Visible = false;
            DisAmmount.Visible = false;
            TextTaxAmmount.Visible = false;
            DisAmmount.Text = "0";
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
                OrderID(id);

            }
            string comQurry = "select TexId from CompnayDetails";
            DataTable dt2 = dbMainClass.getDetailByQuery(comQurry);
             string taxtid="";
            foreach (DataRow dr in dt2.Rows)
            {
               

               taxtid = dr[0].ToString();
            }
            string selectName = "select TexAmount,TexName from CompnayTex where TexId='" + taxtid + "'"; //TexName='" + DB_Main.taxName + "'";
            DataTable dt1 = dbMainClass.getDetailByQuery(selectName);
            //textBox16.Text = DB_Main.taxName;
            foreach (DataRow dr in dt1.Rows)
            {
                //txtTexAmount.Text 

                txtDiscount.Text = dr[0].ToString();
                textBox16.Text = dr[1].ToString();
            }
            Purchase.PurchaseDetails purChaseDetailObj = new Purchase.PurchaseDetails();
            vendorDetails = purChaseDetailObj.GetVendorDetaisInDataTable();
            ItemDetails = purChaseDetailObj.GetItemPriceAndNameDetaisInDataTable();
            setAutoCompleteMode(txtProductName, "ItemName", ItemDetails);
            setAddToCraftTable();
            //setAutoCompleteMode(txtVendorName, "Name", vendorDetails);

            gridPurchaseOrder.DataSource = addToCartTable;
        }

                  public void OrderID(String s)
          {
              int txt = Convert.ToInt32(s);
              int txt1 = txt + 1;
              txtSrNo.Text = txt1.ToString();
          }   

        private void txtVendorCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            string getId = "select venderId from VendorDetails where venderId='" + txtVendorCode.Text + "'";
            DataTable dt = dbMainClass.getDetailByQuery(getId);
            if (e.KeyChar == (Char)Keys.Enter)
            {

                if (dt != null && dt.Rows.Count > 0)
                {
                    IndexTex3();
                }
                else
                {
                    MessageBox.Show("Please Enter The Correct Vendor Id");
                }

            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                IndexTex3();
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtItemCode.Select(txtItemCode.Text.Length, 0);
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
                    if (txtVendorCode.Text == "")
                    {
                        txtVendorCode.Text = "V";
                    }
                    e.Handled = false;
                }
                else if( (e.KeyChar == 'V' || e.KeyChar == 'v') && string.IsNullOrWhiteSpace(txtVendorCode.Text))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
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

            if (!txtVendorCode.Text.StartsWith("V"))
            {
                txtVendorCode.Text = string.Concat("V", txtVendorCode.Text);
                txtVendorCode.Select(txtVendorCode.Text.Length, 0);
            }

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
                        double sales = Convert.ToDouble(salesPrice);
                        txtRate.Text = sales.ToString("###0.00");
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
           if (!txtItemCode.Text.StartsWith("I"))
           {
               txtItemCode.Text = string.Concat("I", txtItemCode.Text);
               txtItemCode.Select(txtItemCode.Text.Length, 0);
           }
           // string itemCode = txtItemCode.Text;
           // setitemVlue("ItemId", itemCode);
            //txtItemCode.Focus();
           
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
                    txtAmount.Text = (TotalQuantity * RatePerPice).ToString("###0.00");
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
            if ((txtQuanity.Text == "") || (txtQuanity.Text == "0"))
            {
                MessageBox.Show("Please Enter The Quanity");
               
                txtQuanity.Focus();
            }
            else
            {
                txtItemCode.Focus();
                txtQuanity.ReadOnly = true;
                txtQuanity.TabStop = false;
                txtVendorCode.TabStop = true;
                button1.TabStop = true;
                txtDiscount.TabStop = false;
                string itemid = "";
                string quntity = "";
                string rate = "";
                string ammount = "";
                int counter = 0;
                foreach (DataRow dr3 in addToCartTable.Rows)
                {
                    int q3 = 0;
                    itemid = dr3[0].ToString();
                    if (ls.Contains(itemid) && gridPurchaseOrder.Rows[counter].DefaultCellStyle.Font != null)
                    {
                        counter++;
                        continue;
                    }
                    counter++;
                    quntity = dr3[5].ToString();
                    rate = dr3[4].ToString();
                    ammount = dr3[6].ToString();

                    if (itemid == txtItemCode.Text)
                    {
                        if (quntity == "")
                        {
                            quntity = "0";
                        }
                        int q1 = Convert.ToInt32(quntity);
                        int q2 = Convert.ToInt32(txtQuanity.Text);
                        q3 = q1 + q2;
                        dr3[5] = q3.ToString();
                        Double rate1 = Convert.ToDouble(rate);
                        Double rate6 = rate1 * q2;
                        Double rate2 = Convert.ToDouble(ammount);
                        Double rate7 = Convert.ToDouble(txtAmount.Text);
                        Double rate3 = rate6 + rate2;
                        dr3[6] = rate3.ToString();
                        Double rate4 = Convert.ToDouble(txtTotalAmount.Text);
                        Double rate5 = rate4 + rate7;
                        txtTotalAmount.Text = rate5.ToString("###0.00");//rate3.ToString();
                        // MessageBox.Show("Please Enter the Quanity");

                        txtwithautaxamount.Text = rate5.ToString();
                        txtItemCode.Text = "I";
                        txtItemCode.Select(txtItemCode.Text.Length, 0);
                        txtProductName.Text = "";
                        txtRate.Text = "";
                        txtQuanity.Text = "";
                        txtAmount.Text = "";
                        //txtItemCode.Focus();
                        btnAddItem.Enabled = false;

                    }
                }



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
                    if (txtAmount.Text == "")
                    {
                        // txtAmount.Text = "0";
                        MessageBox.Show("Please Enter the Quanity");
                    }
                    else
                    {
                        string selectq = "select ids.ItemCompName,cast(ipd.MrpPrice as numeric(38,2)) from ItemPriceDetail ipd join ItemDetails ids on ipd.ItemId=ids.ItemId where ipd.ItemId='" + txtItemCode.Text + "'";
                        DataTable dta = dbMainClass.getDetailByQuery(selectq);
                        string ConpanyName = "";
                        string Mrp = "";
                        foreach (DataRow dr1 in dta.Rows)
                        {
                            ConpanyName = dr1[0].ToString();
                            Mrp = dr1[1].ToString();
                        }

                        txtRemoveItem.Enabled = true;
                        DataRow dr = addToCartTable.NewRow();
                        dr[0] = txtItemCode.Text.Trim();
                        dr[1] = txtProductName.Text.Trim();
                        dr[2] = ConpanyName.Trim();
                        dr[3] = Mrp.Trim();
                        dr[4] = txtRate.Text.Trim();
                        dr[5] = txtQuanity.Text.Trim();
                        dr[6] = txtAmount.Text.Trim();

                        //dr[5] = txtAmount.Text.Trim();
                        addToCartTable.Rows.Add(dr);
                        gridPurchaseOrder.DataSource = addToCartTable;
                        var dgvcount = gridPurchaseOrder.Rows.Count;
                        gridPurchaseOrder.CurrentCell = gridPurchaseOrder.Rows[dgvcount - 2].Cells[0];
                        double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
                        totalAmount += Convert.ToDouble(txtAmount.Text.Trim());
                        txtTotalAmount.Text = totalAmount.ToString("###0.00");
                        txtwithautaxamount.Text = totalAmount.ToString();

                        txtwithautaxamount.Text = totalAmount.ToString();
                        gridPurchaseOrder.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                        txtItemCode.Text = "I";
                        txtProductName.Text = "";
                        txtRate.Text = "";
                        txtQuanity.Text = "";
                        txtAmount.Text = "";
                        //txtItemCode.Focus();
                        btnAddItem.Enabled = false;
                        //txtRemoveItem.Focus();
                        txtQuanity.TabStop = false;
                        txtQuanity.ReadOnly = true;
                        //}
                    }
                    if (gridPurchaseOrder.Rows.Count > 1)
                    {
                        txtdis.ReadOnly = false;
                    }
                    txtItemCode.Select(txtItemCode.Text.Length, 0);
                }
            }
        }
        #endregion

        #region /////////// add Column to AddToCraft DataTable///////////////
        private void setAddToCraftTable()
        {
            addToCartTable.Columns.Add(new DataColumn("Item Code"));
            addToCartTable.Columns.Add(new DataColumn("Product Name"));
            addToCartTable.Columns.Add(new DataColumn("Company Name"));
            addToCartTable.Columns.Add(new DataColumn("Mrp"));
            addToCartTable.Columns.Add(new DataColumn("Rate"));
            addToCartTable.Columns.Add(new DataColumn("Quantity"));
            addToCartTable.Columns.Add(new DataColumn("Amount"));
           
            //addToCartTable.Columns.Add(new DataColumn("TexAmount"));
        }
        #endregion

        private void txtRemoveItem_Click(object sender, EventArgs e)
        {
            gridPurchaseOrder.DefaultCellStyle.SelectionBackColor = Color.Red;
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
            //double totalAmount = 0.0;
            //foreach (DataRow dr in addToCartTable.Rows)
            //{
            //    totalAmount += Convert.ToDouble(dr[4].ToString());
            //}
            //string discountAmount = txtDiscount.Text;
            ////double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
            //double amount = 0.0;
            //if (double.TryParse(discountAmount, out amount))
            //{
            //    double totalDiscount = Convert.ToDouble(discountAmount);
            //    totalAmount = totalAmount - ((totalAmount * totalDiscount) / 100);
            //    txtTotalAmount.Text = totalAmount.ToString();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtsearch.Text = "";
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
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
           
            txtsearch.Text = "";
            //string selectqurry = "select itm.ItemName,itm.ItemCompName,itm.ItemDesc,itm.groupid,itm.Unitid,ipd.purChasePrice,ipd.SalesPrice,ipd.MrpPrice,ipd.Margin,iqd.OpeningQuantity,iqd.CurrentQuantity from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid";
            //DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            //List<string> ls = new List<string>();
            
            counter = 1;
            panel2.Visible = true;
            string selectqurry = "select  itm.ItemId,itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],cast(ipd.purChasePrice as numeric(38,2)) as [Purchase Price],cast(ipd.MrpPrice as numeric(38,2)) as[Mrp Price] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId where iqd.CurrentQuantity>0";
            string selectqurryForActualColumnName = "select top 1  itm.ItemId, itm.ItemName,itm.ItemCompName ,itm.ItemDesc ,ig.groupName ,cast(ipd.purChasePrice as numeric(38,2)),cast(ipd.MrpPrice as numeric(38,2)) from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            DataTable dtOnlyColumnName = dbMainClass.getDetailByQuery(selectqurryForActualColumnName);
            DataTable customDataTable = new DataTable();
            customDataTable.Columns.Add("ActualTableColumnName");
            customDataTable.Columns.Add("AliasTableColumnName");
            DataColumnCollection d = dt.Columns;
            DataColumnCollection dataColumnForName = dtOnlyColumnName.Columns;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            string select = "select  itm.ItemId,itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],cast(ipd.purChasePrice as numeric(38,2)) as [Purchase Price],cast(ipd.SalesPrice as numeric(38,2)) as[Sales Price],cast(ipd.MrpPrice as numeric(38,2)) as[Mrp Price],cast(ipd.Margin as numeric(38,2)) as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId where iqd.CurrentQuantity>0";
            DataTable dt1 = dbMainClass.getDetailByQuery(select);
            dataGridView1.DataSource = dt1;
            IndexTex();
            txtsearch.Focus();
            
        }
        private void setDetails1(DataGridViewCellCollection cellCollection)
        {
            try
            {
                txtItemCode.Text = cellCollection[0].Value.ToString();
                txtProductName.Text = cellCollection[1].Value.ToString();
                txtRate.Text = cellCollection[7].Value.ToString();
                double rate = Convert.ToDouble(txtRate.Text);
                // maxquantity = Convert.ToInt32((cell1[3].Value.ToString()));
            txtQuanity.Text = "1";
            double quantuty = Convert.ToDouble(txtQuanity.Text);
                double amount = (rate * quantuty);
                txtAmount.Text = amount.ToString();
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
            if (txtVendorCode.Text == "V")
            {
                MessageBox.Show("Please Enter The Vendor Code");
                txtVendorCode.Focus();
                txtVendorCode.Select(txtVendorCode.Text.Length,0);
            }
           else if (gridPurchaseOrder.CurrentRow == null)
            {
                MessageBox.Show("Please Enter The Item");
                txtItemCode.Focus();
                txtItemCode.Select(txtItemCode.Text.Length, 0);
            }
            else
            {
                if (ls.Count == gridPurchaseOrder.Rows.Count - 1)
                {
                    MessageBox.Show("Please Enter The Item");
                    txtItemCode.Focus();
                    txtItemCode.Select(txtItemCode.Text.Length, 0);
                    return;
                }
                PO_SaveDetails();
            }
        }
        private void PO_SaveDetails()
        {
            /* DataGridViewRowCollection call = gridPurchaseOrder.Rows;
            for (int c = 0; c < call.Count; c++)
            {
                DataGridViewRow currentRow1 = call[c];
                DataGridViewCellCollection cellCollection1 = currentRow1.Cells;
                string itid = cellCollection1[0].Value.ToString();
                string que = cellCollection1[2].Value.ToString();



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
            }*/
           
                gridPurchaseOrder.AllowUserToAddRows = false;
                counter = 0;
                if (counter == 0)
                {
                    int count = 0;

                    if (txtDiscount.Text == "")
                    {
                        txtDiscount.Text = "0";
                    }
                    else
                    {

                        string insertqurry = "insert into VendorOrderDetails values('" + txtVendorCode.Text + "','" + dtpDate.Value.ToString() + "','" + txtTotalAmount.Text + "','" + txtdis.Text + "','" + txtDiscount.Text + "','" + DisAmmount.Text + "','" + TextTaxAmmount.Text + "','" + txtwithautaxamount.Text + "')";

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
                                if (ls.Contains(txtItemCod)&&gridPurchaseOrder.Rows[count].DefaultCellStyle.Font!=null)
                                {
                                    count++;
                                    continue;
                                }
                                
                                string txtQuanit = cellCollection[5].Value.ToString();
                                string txtRate = cellCollection[4].Value.ToString();
                                string txtAmoun = cellCollection[6].Value.ToString();
                                string OrderID = txtSrNo.Text;
                                string Query = "insert into VendorOrderDesc Values('" + OrderID + "','" + txtItemCod + "','" + txtRate + "','" + txtQuanit + "','" + txtAmoun + "')";
                                //MessageBox.Show(Query);
                                sf.Add(Query);
                            }
                            count++;
                            int insertedRows1 = dbMainClass.saveDetails(sf);

                            if (insertedRows1 > 0)
                            {
                                MessageBox.Show("Details Saved Successfully");
                               
                                DialogResult result1 = MessageBox.Show("This Page Print", "Important Question", MessageBoxButtons.YesNo);
                                if (result1 == System.Windows.Forms.DialogResult.Yes)
                                {

                                    PurchesCrystalReportViewer.Visible = true;

                                    panel2.Visible = true;
                                    //string conntion = "Data Source=DELL-PC;Initial Catalog=SalesMaster;User ID=sa; Password=dell@12345;";
                                    SqlConnection con = dbMainClass.openConnection();//new SqlConnection(conntion);
                                    string selectqurry = "select * from VwPurchesOrderDatils where OrderId='" + txtSrNo.Text + "'";
                                    SqlCommand cmd = new SqlCommand(selectqurry, con);
                                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                                    PurchSet ds = new PurchSet();
                                    sda.Fill(ds, "VwPurchesOrderDatils");
                                    PurchesCrystalReport cryRpt = new PurchesCrystalReport();
                                    //ReportDocument cryRpt = new ReportDocument();
                                    //cryRpt.Load("C:\\Users\\Umesh\\Documents\\visual studio 2010\\Projects\\WindowsFormsApplication5\\WindowsFormsApplication5\\PurchesCrystalReport.rpt");
                                    cryRpt.SetDataSource(ds.Tables[1]);
                                    PurchesCrystalReportViewer.ReportSource = cryRpt;
                                    PurchesCrystalReportViewer.Refresh();
                                }
                                if (result1 == System.Windows.Forms.DialogResult.No)
                                {
                                    PurchesCrystalReportViewer.Visible = false;

                                    panel2.Visible = false;
                                }
                                gridPurchaseOrder.AllowUserToAddRows = true;
                                //gridPurchaseOrder.DataSource = addToCartTable;
                                OrderID(txtSrNo.Text);
                                makeBlank();

                            }
                              
                            else
                            {
                                MessageBox.Show("Details Not Saved Successfully");
                                gridPurchaseOrder.AllowUserToAddRows = true;
                            }
                        }
                    }

                }
            //}

           
            txtVendorCode.Focus();
            txtVendorCode.Select(txtVendorCode.Text.Length, 0);

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
            txtTotalAmount.Text = "0.00";
            txtdis.Text = "0";
            addToCartTable.Clear();
           // gridPurchaseOrder.DataSource = "";
            txtRemoveItem.Enabled = false;

        }

        private void txtQuanity_Leave(object sender, EventArgs e)
        {
             
        }

        private void txtQuanity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                 if ((txtQuanity.Text == "") || (txtQuanity.Text == "0"))
                {
                    MessageBox.Show("Please Enter The Quanity");
                    txtQuanity.Focus();
                }
                else
                {
                    btnAddItem.Focus();
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
            //txtsearch.Text = "";
            comboBox1.SelectedIndex = 0;
            if (counter == 0)
            {
                panel2.Visible = false;
                DataGridViewCellCollection CellCollection = dataGridView1.Rows[e.RowIndex].Cells;
                if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                {
                    setDetails(CellCollection);
                    IndexTex3();
                }
            }
            else if (counter == 1)
            {
                panel2.Visible = false;
                DataGridViewCellCollection CellCollection = dataGridView1.Rows[e.RowIndex].Cells;
                if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                {
                    setDetails1(CellCollection);
                    txtQuanity.ReadOnly = false;
                    btnAddItem.Enabled = true;
                    txtQuanity.Enabled = true;
                    IndexTex2();
                }
            }

        }

        private void buttBack_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
           

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
            txtItemCode.Select(txtItemCode.Text.Length, 0);
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
            txtQuanity.SelectAll();
            txtItemCode.TabStop = true;
            button2.TabStop = true;
            txtDiscount.TabStop = false;
            txtQuanity.TabStop = true;
            btnAddItem.TabStop = true;
            txtRemoveItem.TabStop = true;
            btnSave.TabStop = true;
            btnClose.TabStop = true;
            txtVendorCode.TabStop = true;
            button1.TabStop = true;
        }

        private void gridPurchaseOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Color backGroundColor = gridPurchaseOrder.DefaultCellStyle.SelectionBackColor;
                if (backGroundColor.Name == "DodgerBlue" || backGroundColor.Name == "Highlight")
                {
                    MessageBox.Show("Please select remove button");
                    return;
                }
                if (addToCartTable.Rows.Count > 0)
                {
                    if (txtTotalAmount.Text == "")
                    {
                        txtTotalAmount.Text = "0";
                    }
                    int index = gridPurchaseOrder.SelectedRows[0].Index;
                    string itemId = gridPurchaseOrder.Rows[index - 1].Cells[0].Value.ToString();
                    if ((!ls.Contains(itemId)) || (gridPurchaseOrder.Rows[index - 1].DefaultCellStyle.Font == null))
                    {
                        int courentrow = gridPurchaseOrder.CurrentRow.Index;
                        string Amount = gridPurchaseOrder.Rows[courentrow - 1].Cells[6].Value.ToString();
                        if (Amount == "")
                        {
                            Amount = "0";
                        }
                        double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
                        totalAmount -= Convert.ToDouble(Amount.Trim());
                        txtTotalAmount.Text = totalAmount.ToString();
                        //int index = gridPurchaseOrder.SelectedRows[0].Index;
                        //addToCartTable.Rows.RemoveAt(index-1);
                        gridPurchaseOrder.Rows[index - 1].DefaultCellStyle.Font = new Font(new FontFamily("Microsoft Sans Serif"), 9.00F, FontStyle.Strikeout);
                        gridPurchaseOrder.Rows[index - 1].DefaultCellStyle.ForeColor = Color.Red;
                        //string itemId = gridPurchaseOrder.Rows[index - 1].Cells[0].Value.ToString();// I44

                        ls.Add(itemId);
                        //gridPurchaseOrder.DataSource = addToCartTable;
                        if (addToCartTable.Rows.Count == 0)
                        {
                            txtTotalAmount.Text = "0.0";
                            txtDiscount.Text = "0.0";
                        }
                        if(ls.Count==gridPurchaseOrder.Rows.Count-1)
                        {
                            txtItemCode.Focus();
                            txtItemCode.Select(txtItemCode.Text.Length, 0);
                            gridPurchaseOrder.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                        }
                        if (gridPurchaseOrder.Rows.Count > 0)
                        {
                           // gridPurchaseOrder.Rows[gridPurchaseOrder.Rows.Count - 1].Selected = true;
                        }
                        if (gridPurchaseOrder.Rows.Count > 0)
                        {
                            txtdis.Text = "0";
                            txtdis.ReadOnly = true;
                        }
                        if (gridPurchaseOrder.Rows.Count > 1)
                        {
                            txtdis.ReadOnly = false;
                        }
                        else
                        {
                            //txtRemoveItem.Enabled = false;
                        }
                    }
                   else if ((!ls.Contains(itemId)) || (gridPurchaseOrder.Rows[index - 1].DefaultCellStyle.Font != null))
                    {
                        MessageBox.Show("Item already deleted!");
                    }
                }
            }
             if (e.KeyChar == Convert.ToChar(Keys.Escape))
             {
                 var dgvcount = gridPurchaseOrder.Rows.Count;
                 gridPurchaseOrder.CurrentCell = gridPurchaseOrder.Rows[dgvcount - 2].Cells[0];
                 gridPurchaseOrder.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                 txtItemCode.Focus();
                 txtItemCode.Select(txtItemCode.Text.Length, 0);
                 txtRemoveItem.Enabled = true;
             }

        }

       
        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
           

                string getId = "select ItemId from ItemDetails where ItemId ='" + txtItemCode.Text + "'";
                DataTable dt = dbMainClass.getDetailByQuery(getId);
                if (e.KeyChar == (Char)Keys.Enter)
                {
                    if (txtVendorCode.Text == "V")
                    {
                        MessageBox.Show("Please Enter The Vendor Code");
                        txtVendorCode.Focus();
                        txtItemCode.Text = "I";
                        txtProductName.Text = "";
                        txtRate.Text = "";
                        txtQuanity.Text = "";
                        txtAmount.Text = "";
                        btnAddItem.Enabled = false;
                    }
                    else
                    {
                        string itemCode = txtItemCode.Text;
                         setitemVlue("ItemId", itemCode);
                        if (dt != null && dt.Rows.Count > 0)
                        {                            
                              txtQuanity.ReadOnly = false;
                              txtQuanity.Text = "1";
                              int que = Convert.ToInt32(txtQuanity.Text);
                              string purchesprice = "select SalesPrice from ItemPriceDetail where ItemId ='" + txtItemCode.Text + "'";
                              DataTable dt1 = dbMainClass.getDetailByQuery(purchesprice);
                              string salep="";
                              foreach (DataRow dr in dt1.Rows)
                              {
                                  salep = dr[0].ToString();
                              }
                              Double Saleprice = Convert.ToDouble(salep);
                              Double price = Saleprice * que;
                              txtAmount.Text = price.ToString("###0.00");

                            btnAddItem.Enabled = true;
                            txtQuanity.Enabled = true;
                            IndexTex2();
                        }
                        else
                        {
                            MessageBox.Show("Please Enter the Correct Item Id");
                        }
                    }
                }
                if (e.KeyChar == Convert.ToChar(Keys.Escape))
                {
                    if (gridPurchaseOrder.Rows != null && gridPurchaseOrder.RowCount > 0)
                    {
                        txtRemoveItem.Focus();
                    }
                    else
                    {
                        btnSave.Focus();
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
                    if (txtItemCode.Text == "")
                    {
                        txtItemCode.Text = "I";
                    }
                    e.Handled = false;
                    txtAmount.Text = "";
                    txtRate.Text = "";

                    txtQuanity.Text = "";
                    txtItemCode.Focus();
                    txtItemCode.Select(txtItemCode.Text.Length, 0);

                }
                else if ((e.KeyChar == 'I' || e.KeyChar == 'i') && string.IsNullOrWhiteSpace(txtItemCode.Text))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
                }
            //}
        }

        private void panel2_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void btnAddItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtItemCode.Focus();
                //txtItemCode.Select(txtItemCode.Text.Length, 0);
                txtVendorCode.TabStop = false;
                button1.TabStop = false;
                txtDiscount.TabStop = false;
            }
        }

        private void txtRemoveItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                
                gridPurchaseOrder.Focus();
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                btnSave.Focus();
                btnClose.TabStop = true;
            }
        }

        private void buttBack_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = false;
            if (txtVendorCode.Text == "V")
            {
                txtVendorCode.Focus();
                txtVendorCode.Select(txtVendorCode.Text.Length, 0);
            }
            else if (txtVendorCode.Text != "V")
            {
                txtItemCode.Focus();
                txtItemCode.Select(txtItemCode.Text.Length, 0);
            }
        }

        private void txtsearch_TextChanged_1(object sender, EventArgs e)
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

        private void dataGridView1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //txtsearch.Text = "";
            comboBox1.SelectedIndex = 0;
            int currentIndex = dataGridView1.CurrentRow.Index;
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (counter == 0)
                {
                    panel2.Visible = false;
                    DataGridViewCellCollection CellCollection = dataGridView1.Rows[currentIndex-1].Cells;
                    if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                    {
                        setDetails(CellCollection);
                        IndexTex3();
                    }
                }
                else if (counter == 1)
                {
                    panel2.Visible = false;
                    DataGridViewCellCollection CellCollection = dataGridView1.Rows[currentIndex - 1].Cells;
                    if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                    {
                        setDetails1(CellCollection);
                        txtQuanity.ReadOnly = false;
                        btnAddItem.Enabled = true;
                        txtQuanity.Enabled = true;
                        IndexTex2();
                    }
                }
            }
        }

        private void btnSave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtVendorCode.Focus();
                txtVendorCode.Select(txtVendorCode.Text.Length, 0);
            }
        }

        private void btnClose_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                txtVendorCode.Focus();
                txtVendorCode.Select(txtVendorCode.Text.Length, 0);
            }
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //txtsearch.Text = "";
            comboBox1.SelectedIndex = 0;
           
                if (counter == 0)
                {
                    panel2.Visible = false;
                    DataGridViewCellCollection CellCollection = dataGridView1.SelectedRows[0].Cells;
                    if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                    {
                        setDetails(CellCollection);
                        IndexTex3();
                    }
                }
                else if (counter == 1)
                {
                    panel2.Visible = false;
                    DataGridViewCellCollection CellCollection = dataGridView1.SelectedRows[0].Cells;
                    if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                    {
                        setDetails1(CellCollection);
                        txtQuanity.ReadOnly = false;
                        btnAddItem.Enabled = true;
                        txtQuanity.Enabled = true;
                        IndexTex2();
                    }
                }
        }

        private void gridPurchaseOrder_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string itemid = gridPurchaseOrder.Rows[e.RowIndex].Cells[0].Value.ToString();
            string item = "";
            string selectQurry = "select ItemId from ItemDetails";
            DataTable dt1 = dbMainClass.getDetailByQuery(selectQurry);
            foreach(DataRow dr1 in dt1.Rows)
            {
                item = dr1[0].ToString();
                if (item == itemid)
                {
                    break;
                }

            }
                if (item == itemid)
                {


                    string selectqurry = "select Ids.ItemName,Ids.ItemCompName,ipd.MrpPrice, ipd.SalesPrice from ItemDetails Ids  join ItemPriceDetail ipd on Ids.ItemId=ipd.ItemId  where Ids.ItemId='" + itemid + "'";
                    DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
                    string rate = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        gridPurchaseOrder.Rows[e.RowIndex].Cells[1].Value = dr[0].ToString();
                        gridPurchaseOrder.Rows[e.RowIndex].Cells[2].Value = dr[1].ToString();
                        gridPurchaseOrder.Rows[e.RowIndex].Cells[3].Value = dr[2].ToString();
                        // gridPurchaseOrder.Rows[e.RowIndex].Cells[5].Value=dr[3].ToString();

                        rate = dr[3].ToString();
                    }
                    if (gridPurchaseOrder.Rows[e.RowIndex].Cells[0].Value != null)
                    {
                        int co = gridPurchaseOrder.CurrentRow.Index;
                        DataGridViewRow selectedRow = gridPurchaseOrder.Rows[0];
                        selectedRow.Selected = true;
                        selectedRow.Cells[4].Selected = true;
                        //gridPurchaseOrder.CurrentCell = gridPurchaseOrder[gridPurchaseOrder.CurrentCell.ColumnIndex + 2, gridPurchaseOrder.CurrentCell.RowIndex];
                        //gridPurchaseOrder.Focus();
                    }
                    gridPurchaseOrder.Rows[e.RowIndex].Cells[4].Value = rate;
                    string quantity = gridPurchaseOrder.Rows[e.RowIndex].Cells[5].Value.ToString();
                    if (quantity == "")
                    {
                        quantity = "0";
                    }
                    int q1 = Convert.ToInt32(quantity);
                    Double rate1 = Convert.ToDouble(rate);
                    Double price = rate1 * q1;
                    if (price.ToString() == "")
                    {
                        price = 0;
                    }
                    gridPurchaseOrder.Rows[e.RowIndex].Cells[6].Value = price.ToString();
                        Double totalammount = Convert.ToDouble(txtTotalAmount.Text);
                    Double toat = totalammount + price;
                    txtTotalAmount.Text = toat.ToString("###0.00");
                }
                else
                {
                    
                    //if(itemid=="I1")
                    //{
                    MessageBox.Show("please select your correct row ");
                    gridPurchaseOrder.Rows[e.RowIndex].Cells[0].Value = "";
                    //gridPurchaseOrder.Rows[0].Cells[2].Selected = true;
                  }
            //}
        }

        private void Distxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            double totalAmount = 0.00;
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    counter = 0;
                    foreach (DataRow dr in addToCartTable.Rows)
                    {
                        string itemid = dr[0].ToString();
                        if (ls.Contains(itemid) && gridPurchaseOrder.Rows[counter].DefaultCellStyle.Font != null)
                        {
                            counter++;
                            continue;
                        }
                        counter++;
                        totalAmount += Convert.ToDouble(dr[6].ToString());
                    }
                    double s1 = totalAmount;
                    txtTotalAmount.Text = s1.ToString("###0.00");
                    //txtdis.Text = "0";
                    // double total = Convert.ToDouble(txttotalammount.Text);
                    // double d = Convert.ToDouble(discountamount.Text);
                    // double g = d + total;
                    //txttotalammount.Text = g.ToString();
                    //discountamount.Text = "";


                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }

            //char ch = e.KeyChar;
            //if (ch == 46 && txtdis.Text.IndexOf('.') != -1)
            //{
            //    e.Handled = true;
            //    return;
            //}
            //if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            //{
            //    e.Handled = true;
            //}
            if (e.KeyChar == (char)Keys.Enter)
            {
               
                //double totalAmount1 = 0.00;//Convert.ToDouble(txttotalAmount.Text);
                //double totalamount2 = 0.00;
                //foreach (DataRow dr in addToCartTable.Rows)
                //{
                //    string itemid = dr[0].ToString();
                //    if (ls.Contains(itemid) && gridPurchaseOrder.Rows[counter].DefaultCellStyle.Font != null)
                //    {
                //        counter++;
                //        continue;
                //    }
                //    counter++;
                //    totalAmount1 += Convert.ToDouble(dr[6].ToString()); 
                //    totalamount2 += Convert.ToDouble(dr[6].ToString());
                //}
                //double s = totalAmount1;
                //string discountAmount = txtdis.Text;
                ////double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
                //double amount = 0.0;
                //if (double.TryParse(discountAmount, out amount))
                //{
                //    double totalDiscount = Convert.ToDouble(discountAmount);
                //    totalAmount1 = totalAmount1 - ((totalAmount1 * totalDiscount) / 100);
                //    totalamount2  =  ((totalamount2  * totalDiscount) / 100);
                //    txtTotalAmount.Text = totalAmount1.ToString("###0.00");
                //    txtwithautaxamount.Text = s.ToString();

                //    double dis = totalamount2;//totalAmount1 * totalDiscount / 100;
                //    DisAmmount.Text = dis.ToString();

                //   // DisAmmount.Text = totalDiscount.ToString();
                //}
            }
        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {
            double d = 1;
            double total = Convert.ToDouble(txtTotalAmount.Text);
            double g = Convert.ToDouble(txtDiscount.Text);
            double tax = d + ((g / 100));
            double taxamount = total / tax;
            double totaltax = total - taxamount;
            TextTaxAmmount.Text = totaltax.ToString("###0.00");
        }

        private void DisAmmount_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Distxt_TextChanged(object sender, EventArgs e)
        {

            //if (txtdis.Text == "")
            //{
            //    txtdis.Text = "0";
            //}
            double totalAmount1 = 0.00;//Convert.ToDouble(txttotalAmount.Text);
            double totalamount2 = 0.00;
            counter = 0;
            foreach (DataRow dr in addToCartTable.Rows)
            {
                string itemid = dr[0].ToString();
                if (ls.Contains(itemid) && gridPurchaseOrder.Rows[counter].DefaultCellStyle.Font != null)
                {
                    counter++;
                    continue;
                }
                counter++;
                totalAmount1 += Convert.ToDouble(dr[6].ToString());
                totalamount2 += Convert.ToDouble(dr[6].ToString());
            }
            double s = totalAmount1;
            string discountAmount = txtdis.Text;
            //double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
            double amount = 0.0;
            if (double.TryParse(discountAmount, out amount))
            {
                double totalDiscount = Convert.ToDouble(discountAmount);
                totalAmount1 = totalAmount1 - ((totalAmount1 * totalDiscount) / 100);
                totalamount2 = ((totalamount2 * totalDiscount) / 100);
                txtTotalAmount.Text = totalAmount1.ToString("###0.00");
                txtwithautaxamount.Text = s.ToString("###0.00");

                double dis = totalamount2;//totalAmount1 * totalDiscount / 100;
                DisAmmount.Text = dis.ToString("###0.00");
                txtdis.Text = totalDiscount.ToString("###0.00");
                txtdis.Select(txtdis.Text.Length, 0);

                // DisAmmount.Text = totalDiscount.ToString();
            }

        }
        private void Distxt_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void PurchaseOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "S")
            {
                PO_SaveDetails();
                //this.Close();
            }
            if (e.Alt && e.KeyCode.ToString() == "D")
            {
                txtdis.Focus();
            }
        }

        private void gridPurchaseOrder_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
        //    string itemid = gridPurchaseOrder.Rows[e.RowIndex].Cells[0].Value.ToString();
        //    string que = gridPurchaseOrder.Rows[e.RowIndex].Cells[5].Value.ToString();
        //    if (itemid == "")
        //    {
        //        if (que == "")
        //        {
        //        }
        //    }
        //    //}
        }

        private void PurchaseOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtdis_Leave(object sender, EventArgs e)
        {
            /*decimal x;
            if (decimal.TryParse(txtdis.Text, out x))
            {
                if (txtdis.Text.IndexOf('.') != -1 && txtdis.Text.Split('.')[1].Length > 2)
                {
                    MessageBox.Show("The maximum decimal points are 2!");
                    txtdis.Focus();
                }
                else txtdis.Text = x.ToString("0.00");
            }
            else
            {
                txtdis.Text = "0.00";
                //MessageBox.Show("Data invalid!");
                //txtVenderOpeningBal.Focus();
            }*/
           
        }

        private void txtdis_Click(object sender, EventArgs e)
        {
            
        }

       
      
      
       
    }
}