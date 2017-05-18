﻿using System;
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
    public partial class Form7 : Form
    {
        List<string> ls = new List<string>();

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
            txtDiscount.ReadOnly = true;
            IndexTex1();
            txtTaxAmount.Visible = false;
            txtWAmount.Visible = false;
            txtDisAmount.Visible = false;
            txtQunty.ReadOnly = true;
            button4.Enabled = false;
            button3.Enabled = false;
            txtDisAmount.Text = "0";
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
            pnlPaymentDetail.Visible = false;
            string comQurry = "select TexId from CompnayDetails";
            DataTable dt2 = dbMainClass.getDetailByQuery(comQurry);
            string taxtid = "";
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
                txtdis.Text = dr[0].ToString();
                textBox16.Text = dr[1].ToString();
            }
            Purchase.PurchaseDetails purChaseDetailObj = new Purchase.PurchaseDetails();
            vendorDetails = purChaseDetailObj.GetVendorDetaisInDataTable();
            ItemDetails = purChaseDetailObj.GetItemPriceAndNameDetaisInDataTable();
            setAutoCompleteMode(txtProductName, "ItemName", ItemDetails);
            setAddToCraftTable();
            if (txtRef.Text == "")
            {
                addToCartTable.Columns.RemoveAt(6);
                dataGridView1.DataSource = addToCartTable;
            }
        }
        public void DeliveryID(String s)
        {
            int txt = Convert.ToInt32(s);
            int txt1 = txt + 1;
            txtSrNo.Text = txt1.ToString();
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
                        double sales = Convert.ToDouble(salesPrice);
                        txtRate.Text = sales.ToString("###0.00");


                        string itemCode = dr[0]["ItemID"].ToString();
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
            DeliveryReportViewer.Visible = false;
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
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
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
            //txtSearch.Text = "";
            comboBox1.SelectedIndex = 0;
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
                    txtQunty.ReadOnly = false;
                    button3.Enabled = true;
                }
            }
            if (counter == 2)
            {
                panel2.Visible = false;
                DataGridViewCellCollection CellCollection = dataGridView2.Rows[e.RowIndex].Cells;
                if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                {
                    string s = CellCollection[0].Value.ToString();
                    string s1 = CellCollection[1].Value.ToString();
                    txtRef.Text = s;
                    //MessageBox.Show(" "+s +" "+s1);
                    string selectqurry = "select venderId,vName,vCompName,vAddress,vPhone,vMobile,vFax from VendorDetails where venderId='" + s1 + "'";
                    SetVendor(selectqurry);
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeliveryReportViewer.Visible = false;
            txtSearch.Text = "";
            counter = 1;
            panel2.Visible = true;
            string selectqurry = "select  itm.ItemId,itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],cast(ipd.purChasePrice as numeric(38,2)) as [Purchase Price],cast(ipd.MrpPrice as numeric(38,2)) as[Mrp Price] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId where iqd.CurrentQuantity>0";
            string selectqurryForActualColumnName = "select top 1  itm.ItemId, itm.ItemName,itm.ItemCompName ,itm.ItemDesc ,ig.groupName ,cast(ipd.purChasePrice as numeric(38,2)) ,cast(ipd.MrpPrice as numeric(38,2)) from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            DataTable dtOnlyColumnName = dbMainClass.getDetailByQuery(selectqurryForActualColumnName);
            DataTable customDataTable = new DataTable();
            customDataTable.Columns.Add("ActualTableColumnName");
            customDataTable.Columns.Add("AliasTableColumnName");
            DataColumnCollection d = dt.Columns;
            DataColumnCollection dataColumnForName = dtOnlyColumnName.Columns;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            dataGridView2.DataSource = dt1;
            IndexTex();

        }

        private void btnSelectPurchaseOrder_Click(object sender, EventArgs e)
        {
            counter = 2;
            DeliveryReportViewer.Visible = false;
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
            IndexTex();

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
            //string itemCode = txtItemCode.Text;
            //setitemVlue("ItemId", itemCode);
            //txtItemCode.Focus();

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
                    txtAmount.Text = (TotalQuantity * RatePerPice).ToString("###0.00");
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
            txtQunty.ReadOnly = true;
            if (txtRef.Text == "")
            {

                string itemid = "";
                string quntity = "";
                string rate = "";
                string prise = "";
                List<string> ls1 = new List<string>();
                foreach (DataRow dr3 in addToCartTable.Rows)
                {
                    int q3 = 0;
                    itemid = dr3[0].ToString();
                    if (ls.Contains(itemid))
                    {
                        continue;
                    }
                    quntity = dr3[5].ToString();
                    rate = dr3[4].ToString();
                    prise = dr3[6].ToString();
                    if (txtItemCode.Text == itemid)
                    {
                        int q1 = Convert.ToInt32(quntity);
                        int q2 = Convert.ToInt32(txtQunty.Text);
                        q3 = q1 + q2;
                        dr3[5] = q3.ToString();
                        //dr3[4] = q3.ToString();
                        Double rate1 = Convert.ToDouble(prise);
                        Double rate2 = Convert.ToDouble(txtAmount.Text);
                        Double rate3 = rate1 + rate2;
                        dr3[6] = rate3.ToString();
                        Double rate4 = Convert.ToDouble(txttotalAmount.Text);
                        Double rate5 = rate4 + rate2;
                        txttotalAmount.Text = rate5.ToString("###0.00");//rate3.ToString();
                        // MessageBox.Show("Please Enter the Quanity");
                        /* txtItemCode.Text = "I";
                         txtProductName.Text = "";
                         txtRate.Text = "";
                         txtQunty.Text = "";
                         txtAmount.Text = "";
                         //addToCartTable.Columns.Add("Qtuhjh");*/
                        ls.Add(itemid);
                    }
                }
                if (addToCartTable != null && addToCartTable.Rows != null && addToCartTable.Rows.Count > 0)
                {
                    string it = "";
                    for (int c = 0; c < ls.Count; c++)
                    {
                        it = ls[c];
                    }
                    if (txtItemCode.Text == it)
                    {
                        txtItemCode.Text = "I";
                        txtProductName.Text = "";
                        txtRate.Text = "";
                        txtQunty.Text = "";
                        txtAmount.Text = "";
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
                        DataRow dr = addToCartTable.NewRow();
                        dr[0] = txtItemCode.Text.Trim();
                        dr[1] = txtProductName.Text.Trim();
                        dr[2] = ConpanyName.Trim();
                        dr[3] = Mrp.Trim();
                        dr[5] = txtQunty.Text.Trim();
                        dr[4] = txtRate.Text.Trim();
                        dr[6] = txtAmount.Text.Trim();

                        //dr[5] = txtAmount.Text.Trim();
                        addToCartTable.Rows.Add(dr);
                        dataGridView1.DataSource = addToCartTable;
                        double totalAmount = Convert.ToDouble(txttotalAmount.Text);
                        totalAmount += Convert.ToDouble(txtAmount.Text.Trim());
                        txttotalAmount.Text = totalAmount.ToString("###0.00");
                        txtWAmount.Text = totalAmount.ToString();

                        txtItemCode.Text = "I";
                        txtProductName.Text = "";
                        txtRate.Text = "";
                        txtQunty.Text = "";
                        txtAmount.Text = "";
                        txtItemCode.Focus();
                        button3.Enabled = false;
                    }
                    if (dataGridView1.Rows.Count > 1)
                    {
                        txtDiscount.ReadOnly = false;
                    }
                    //}

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
                    //addToCartTable.Columns.RemoveAt(6);
                    DataRow dr = addToCartTable.NewRow();
                    dr[0] = txtItemCode.Text.Trim();
                    if (ls.Contains(dr[0]))
                    {

                    }
                    dr[1] = txtProductName.Text.Trim();
                    dr[2] = ConpanyName.Trim();
                    dr[3] = Mrp.Trim();
                    dr[5] = txtQunty.Text.Trim();
                    dr[4] = txtRate.Text.Trim();
                    dr[6] = txtAmount.Text.Trim();

                    //dr[5] = txtAmount.Text.Trim();
                    addToCartTable.Rows.Add(dr);
                    dataGridView1.DataSource = addToCartTable;
                    double totalAmount = Convert.ToDouble(txttotalAmount.Text);
                    totalAmount += Convert.ToDouble(txtAmount.Text.Trim());
                    txttotalAmount.Text = totalAmount.ToString("###0.00");
                    txtWAmount.Text = totalAmount.ToString();

                    txtItemCode.Text = "I";
                    txtProductName.Text = "";
                    txtRate.Text = "";
                    txtQunty.Text = "";
                    txtAmount.Text = "";
                    txtItemCode.Focus();
                    txtQunty.TabStop = false;
                    txtQunty.ReadOnly = true;
                    button3.Enabled = false;
                }
                if (dataGridView1.Rows.Count > 1)
                {
                    txtDiscount.ReadOnly = false;
                }
                //}
            }

            if (txtRef.Text != "")
            {
                if (txtProductName.Text == "" && txtQunty.Text == "")
                {
                    //MessageBox.Show("now CurrentQuantity of deadt");
                }
                else
                {
                    if (txtAmount.Text == "")
                    {
                        MessageBox.Show("please Enter Quantity");
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
                        DataRow dr = addToCartTable.NewRow();
                        dr[0] = txtItemCode.Text.Trim();
                        dr[1] = txtProductName.Text.Trim();
                        dr[2] = ConpanyName.Trim();
                        dr[3] = Mrp.Trim();
                        dr[4] = txtRate.Text.Trim();
                        dr[5] = txtQunty.Text.Trim();
                        dr[6] = txtQunty.Text.Trim();
                        dr[7] = txtAmount.Text.Trim();
                        addToCartTable.Rows.Add(dr);

                        dataGridView1.DataSource = addToCartTable;
                        double totalAmount = Convert.ToDouble(txttotalAmount.Text);
                        totalAmount += Convert.ToDouble(txtAmount.Text.Trim());
                        txttotalAmount.Text = totalAmount.ToString("###0.00");
                        txtWAmount.Text = totalAmount.ToString();

                        txtItemCode.Text = "I";
                        txtProductName.Text = "";
                        txtRate.Text = "";
                        txtQunty.Text = "";
                        txtAmount.Text = "";
                        txtItemCode.Focus();
                        txtQunty.TabStop = false;
                        txtQunty.ReadOnly = true;
                        button3.Enabled = false;
                    }
                    if (dataGridView1.Rows.Count > 1)
                    {
                        txtDiscount.ReadOnly = false;
                    }


                }
            }
        }
        #endregion

        #region /////////// add Column to AddToCraft DataTable///////////////
        private void setAddToCraftTable()
        {
            addToCartTable.Columns.Add(new DataColumn("ItemCode"));
            addToCartTable.Columns.Add(new DataColumn("ProductName"));
            addToCartTable.Columns.Add(new DataColumn("Company Name"));
            addToCartTable.Columns.Add(new DataColumn("Mrp"));
            addToCartTable.Columns.Add(new DataColumn("Rate"));
            addToCartTable.Columns.Add(new DataColumn("Quantity"));
            addToCartTable.Columns.Add(new DataColumn("ResivQuantity"));
            addToCartTable.Columns.Add(new DataColumn("Amount"));
        }
        #endregion

        private void button4_Click(object sender, EventArgs e)
        {

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;
            //dataGridView1.Rows[0].DefaultCellStyle.Font = new Font(new FontFamily("Microsoft Sans Serif"), 9.00F, FontStyle.Strikeout);
            //dataGridView1.DefaultCellStyle.Font = new DataGridViewSelectedRowCollection(new FontFamily("Microsoft Sans Serif"), 8.25F, FontStyle.Strikeout);
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
            //txtQunty.Enabled = false;
            txtQunty.TabStop = false;
            //    }

            //}


        }

        private void txtdis_TextChanged(object sender, EventArgs e)
        {
            /*double totalAmount = 0.00;//Convert.ToDouble(txttotalAmount.Text);
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
            }*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //deliverysave();

            pnlPaymentDetail.Visible = true;
            CmbPageName.SelectedIndex = 0;
            CmbCompany.SelectedIndex = 0;
            CmbCardType.SelectedIndex = 0;
            //comboBox2.Text = "Delivery-Payment";

        }
        public void deliverysave()
        {
            if (txtRef.Text == "")
            {
                if (txtDiscount.Text == "")
                {
                    txtDiscount.Text = "0";
                }
                string Ref = "0";
                dataGridView1.AllowUserToAddRows = false;
                DataGridViewRowCollection call = dataGridView1.Rows;
                for (int c = 0; c < call.Count; c++)
                {
                    DataGridViewRow currentRow1 = call[c];
                    DataGridViewCellCollection cellCollection1 = currentRow1.Cells;
                    string itid = cellCollection1[0].Value.ToString();
                    if (ls.Contains(itid))
                    {
                        continue;
                    }
                    string que = cellCollection1[5].Value.ToString();
                    //string quent = cellCollection1[4].Value.ToString();



                    string qurry = "select CurrentQuantity from ItemQuantityDetail where ItemId='" + itid + "'";
                    DataTable dt = dbMainClass.getDetailByQuery(qurry);
                    string currid = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        currid = dr["CurrentQuantity"].ToString();
                    }
                    //int quent1=Convert.ToInt32(quent);
                    int curentQuntity = Convert.ToInt32(que);
                    int cuentQuantity = Convert.ToInt32(currid);
                    int lastQuantity = cuentQuantity + curentQuntity;
                    //int resivquenty = lastQuantity + quent1;
                    string currid1 = lastQuantity.ToString();
                    string updateQurry = "update ItemQuantityDetail set CurrentQuantity='" + lastQuantity + "'where ItemId='" + itid + "'";
                    int insertedRows2 = dbMainClass.saveDetails(updateQurry);
                }
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
                    string insertqurry = "insert into VendorOrderDetails values('" + textVendercod.Text + "','" + txtdate.Value.ToString() + "','" + txttotalAmount.Text + "','" + txtdis.Text + "','" + txtvat.Text + "','" + txtDisAmount.Text + "','" + txtTaxAmount.Text + "','" + txtWAmount.Text + "')";
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
                            if (ls.Contains(txtItemCod))
                            {
                                continue;
                            }
                            string txtRate = cellCollection[4].Value.ToString();
                            string txtQuanit = cellCollection[5].Value.ToString();
                            string txtAmoun = cellCollection[6].Value.ToString();

                            string Query = "insert into VendorOrderDesc Values('" + OrderID + "','" + txtItemCod + "','" + txtRate + "','" + txtQuanit + "','" + txtAmoun + "')";
                            //MessageBox.Show(Query);
                            sf.Add(Query);
                        }
                        int insertedRows1 = dbMainClass.saveDetails(sf);
                        if (insertedRows1 > 0)
                        {
                            string deleteQurry = "delete VendorOrderDesc where Orderid='" + OrderID + "'";
                            DataTable dt = dbMainClass.getDetailByQuery(deleteQurry);


                            DataGridViewRowCollection RowCollection1 = dataGridView1.Rows;
                            List<string> sf1 = new List<string>();
                            for (int a = 0; a < RowCollection1.Count; a++)
                            {

                                DataGridViewRow currentRow = RowCollection1[a];
                                DataGridViewCellCollection cellCollection = currentRow.Cells;
                                string txtItemCode = cellCollection[0].Value.ToString();
                                if (ls.Contains(txtItemCode))
                                {
                                    continue;
                                }
                                string txtRate = cellCollection[4].Value.ToString();
                                string txtQuanity = cellCollection[5].Value.ToString();
                                string txtAmoun = cellCollection[6].Value.ToString();
                                //string OrderID1 = OrderID;

                                string Query = "insert into VendorOrderDesc Values('" + OrderID + "','" + txtItemCode + "','" + txtRate + "','" + txtQuanity + "','" + txtAmoun + "')";
                                //MessageBox.Show(Query);

                                sf1.Add(Query);

                            }
                            int insertedRows2 = dbMainClass.saveDetails(sf1);
                            if (insertedRows2 > 0)
                            {

                                string insertQurry = "insert into CustomerOrderDelivery Values('" + OrderID + "','true','" + txtdate.Value.ToString() + "','" + Ref + "')";
                                int insertedRows3 = dbMainClass.saveDetails(insertQurry);
                                if (insertedRows3 > 0)
                                {
                                    MessageBox.Show("Details Saved Successfully");
                                    dataGridView1.AllowUserToAddRows = true;
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
                    string insertqurry1 = "insert into VendorOrderDetails values('" + textVendercod.Text + "','" + txtdate.Value.ToString() + "','" + txttotalAmount.Text + "','" + txtdis.Text + "','" + txtvat.Text + "','" + txtDisAmount.Text + "','" + txtTaxAmount.Text + "','" + txtWAmount.Text + "')";

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
                            if (ls.Contains(txtItemCod))
                            {
                                continue;
                            }
                            string txtRate = cellCollection[4].Value.ToString();
                            string txtQuanit = cellCollection[5].Value.ToString();
                            string txtAmoun = cellCollection[6].Value.ToString();

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
                                if (ls.Contains(txtItemCode))
                                {
                                    continue;
                                }
                                string txtRate = cellCollection[4].Value.ToString();
                                string txtQuanity = cellCollection[5].Value.ToString();
                                string txtAmoun = cellCollection[6].Value.ToString();
                                // string OrderID = id4.ToString(); ;

                                string Query = "insert into VendorOrderDesc Values('" + OrderID + "','" + txtItemCode + "','" + txtRate + "','" + txtQuanity + "','" + txtAmoun + "')";
                                //MessageBox.Show(Query);

                                sf1.Add(Query);

                            }
                            int insertedRows4 = dbMainClass.saveDetails(sf1);
                            if (insertedRows4 > 0)
                            {
                                string insertQurry = "insert into CustomerOrderDelivery Values('" + OrderID + "','true','" + txtdate.Value.ToString() + "','" + Ref + "')";
                                int insertedRows5 = dbMainClass.saveDetails(insertQurry);
                                if (insertedRows5 > 0)
                                {
                                    string insertQurry1 = "insert into AllPaymentDetailes Values('" + txtInvoiceid.Text + "','" + CashAmount.Text + "','" + txtCreditAmount.Text + "','" + txtDebitBankName.Text + "','" + txtCardNumber.Text + "','" + CmbCardType.SelectedItem.ToString() + "','" + txtChequeAmount.Text + "','" + txtChequeBankName.Text + "','" + txtChequeNumber.Text + "','" + dateTimePicker1.Value.ToString() + "','" + txtEwalletAmount.Text + "','" + EWalletCompanyName.Text + "','" + txtTransactionNumber.Text + "','" + dateTimePicker2.Value.ToString() + "','" + txtCouponAmount.Text + "','" + CmbCompany.SelectedItem.ToString() + "','" + txtInvoiceAmount.Text + "','" + txtTotalAmount1.Text + "','" + txtBalance.Text + "','" + txtRturned.Text + "','" + txtNetAmount.Text + "')";
                                    int insertedRows = dbMainClass.saveDetails(insertQurry1);
                                    if (insertedRows > 0)
                                    {

                                        MessageBox.Show("Details Saved Successfully");
                                        DialogResult result1 = MessageBox.Show("This Page Print", "Important Question", MessageBoxButtons.YesNo);
                                        if (result1 == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            DeliveryReportViewer.Visible = true;
                                            panel2.Visible = true;
                                            //string conntion = "Data Source=DELL-PC;Initial Catalog=SalesMaster;User ID=sa; Password=dell@12345;";
                                            SqlConnection con = dbMainClass.openConnection();//new SqlConnection(conntion);
                                            string selectqurry = "select * from purchesDelivery where Deliveryid='" + txtSrNo.Text + "'";
                                            SqlCommand cmd = new SqlCommand(selectqurry, con);
                                            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                                            PurchesDelivery ds = new PurchesDelivery();
                                            sda.Fill(ds, "purchesDelivery");
                                            DeliveryPage cryRpt = new DeliveryPage();
                                            //ReportDocument cryRpt = new ReportDocument();
                                            //cryRpt.Load("C:\\Users\\Umesh\\Documents\\visual studio 2010\\Projects\\WindowsFormsApplication5\\WindowsFormsApplication5\\PurchesCrystalReport.rpt");
                                            cryRpt.SetDataSource(ds.Tables[1]);
                                            DeliveryReportViewer.ReportSource = cryRpt;
                                            DeliveryReportViewer.Refresh();
                                        }
                                        if (result1 == System.Windows.Forms.DialogResult.No)
                                        {
                                            DeliveryReportViewer.Visible = false;
                                            panel2.Visible = false;
                                        }




                                        dataGridView1.AllowUserToAddRows = true;

                                    }
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
                            //}
                        }
                    }
                }
            }
            else if (txtRef.Text != "")
            {
                string updateQurry1 = "update VendorOrderDetails set venderId='" + textVendercod.Text + "',TotalPrice='" + txttotalAmount.Text + "',Discount='" + txtDiscount.Text + "',DisAmount='" + txtDisAmount.Text + "',TextTaxAmmount='" + txtTaxAmount.Text + "' where Orderid='" + txtRef.Text + "'";
                int insertedRows3 = dbMainClass.saveDetails(updateQurry1);
                if (insertedRows3 > 0)
                {
                    dataGridView1.AllowUserToAddRows = false;
                    DataGridViewRowCollection call = dataGridView1.Rows;
                    for (int c = 0; c < call.Count; c++)
                    {
                        DataGridViewRow currentRow1 = call[c];
                        DataGridViewCellCollection cellCollection1 = currentRow1.Cells;
                        string itid = cellCollection1[0].Value.ToString();
                        string que = cellCollection1[5].Value.ToString();
                        string quent = cellCollection1[6].Value.ToString();



                        string qurry = "select CurrentQuantity from ItemQuantityDetail where ItemId='" + itid + "'";
                        DataTable dt = dbMainClass.getDetailByQuery(qurry);
                        string currid = "";
                        foreach (DataRow dr in dt.Rows)
                        {
                            currid = dr["CurrentQuantity"].ToString();
                        }
                        int quent1 = Convert.ToInt32(quent);
                        // int curentQuntity = Convert.ToInt32(que);
                        //int quntity = curentQuntity - quent1;
                        int cuentQuantity = Convert.ToInt32(currid);
                        int lastQuantity = cuentQuantity + quent1; //cuentQuantity - curentQuntity;
                        //int resivquenty = lastQuantity + quent1;
                        //string currid1 = resivquenty.ToString();
                        string updateQurry = "update ItemQuantityDetail set CurrentQuantity='" + lastQuantity + "'where ItemId='" + itid + "'";
                        int insertedRows2 = dbMainClass.saveDetails(updateQurry);
                    }
                    string deleteQurry = "delete VendorOrderDesc where Orderid='" + txtRef.Text + "'";
                    DataTable dt1 = dbMainClass.getDetailByQuery(deleteQurry);
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
                            string txtRate = cellCollection[4].Value.ToString();
                            string txtQuanity = cellCollection[5].Value.ToString();
                            string txtAmoun = cellCollection[7].Value.ToString();
                            string OrderID = txtRef.Text;

                            string Query = "insert into VendorOrderDesc Values('" + OrderID + "','" + txtItemCode + "','" + txtRate + "','" + txtQuanity + "','" + txtAmoun + "')";
                            //MessageBox.Show(Query);

                            sf1.Add(Query);

                        }
                        int insertedRows1 = dbMainClass.saveDetails(sf1);
                        if (insertedRows1 > 0)
                        {
                            string insertQurry = "insert into CustomerOrderDelivery Values('" + txtRef.Text + "','true','" + txtdate.Value.ToString() + "','" + txtRef.Text + "')";
                            int insertedRows2 = dbMainClass.saveDetails(insertQurry);
                            if (insertedRows2 > 0)
                            {
                                string insertQurry1 = "insert into AllPaymentDetailes Values('" + txtInvoiceid.Text + "','" + CashAmount.Text + "','" + txtCreditAmount.Text + "','" + txtDebitBankName.Text + "','" + txtCardNumber.Text + "','" + CmbCardType.SelectedItem.ToString() + "','" + txtChequeAmount.Text + "','" + txtChequeBankName.Text + "','" + txtChequeNumber.Text + "','" + dateTimePicker1.Value.ToString() + "','" + txtEwalletAmount.Text + "','" + EWalletCompanyName.Text + "','" + txtTransactionNumber.Text + "','" + dateTimePicker2.Value.ToString() + "','" + txtCouponAmount.Text + "','" + CmbCompany.SelectedItem.ToString() + "','" + txtInvoiceAmount.Text + "','" + txtTotalAmount1.Text + "','" + txtBalance.Text + "','" + txtRturned.Text + "','" + txtNetAmount.Text + "')";
                                int insertedRows = dbMainClass.saveDetails(insertQurry1);
                                if (insertedRows > 0)
                                {
                                    MessageBox.Show("Details Saved Successfully");
                                    txtRef.Text = "";
                                    DialogResult result1 = MessageBox.Show("This Page Print", "Important Question", MessageBoxButtons.YesNo);
                                    if (result1 == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        DeliveryReportViewer.Visible = true;
                                        panel2.Visible = true;
                                        //string conntion = "Data Source=NITU;Initial Catalog=SalesMaster;Integrated Security=true;";
                                        SqlConnection con = dbMainClass.openConnection(); //new SqlConnection(conntion);
                                        string selectqurry = "select * from purchesDelivery where Deliveryid='" + txtSrNo.Text + "'";
                                        SqlCommand cmd = new SqlCommand(selectqurry, con);
                                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                                        PurchesDelivery ds = new PurchesDelivery();
                                        sda.Fill(ds, "purchesDelivery");
                                        PurchesDelivery2 cryRpt = new PurchesDelivery2();
                                        //ReportDocument cryRpt = new ReportDocument();
                                        //cryRpt.Load("C:\\Users\\Umesh\\Documents\\visual studio 2010\\Projects\\WindowsFormsApplication5\\WindowsFormsApplication5\\PurchesCrystalReport.rpt");
                                        cryRpt.SetDataSource(ds.Tables[1]);
                                        DeliveryReportViewer.ReportSource = cryRpt;
                                        DeliveryReportViewer.Refresh();
                                    }
                                    if (result1 == System.Windows.Forms.DialogResult.No)
                                    {
                                        DeliveryReportViewer.Visible = false;
                                        panel2.Visible = false;
                                    }

                                    dataGridView1.AllowUserToAddRows = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Details Not Saved Successfully");
                            }
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
            // string dilqurry = "select Orderid from CustomerOrderDelivery where Orderid='"+txtRef.Text+"'";
            // DataTable dildt = dbMainClass.getDetailByQuery(dilqurry);
            //  if (dildt != null && dildt.Rows != null && dildt.Rows.Count > 0)
            //     {
            //     //button5.Enabled = false;

            //     MessageBox.Show("This Order completed");
            //     txtRef.Text = "";
            //     textVendercod.Focus();
            //     //int totel = 0;
            //     //string select = "select vo.Orderid,vo.venderId,vod.ItemId,vo.Discount from VendorOrderDesc vod join VendorOrderDetails vo on vod.Orderid=vo.Orderid where vo.Orderid='" + txtRef.Text + "'";
            //     //DataTable dt = dbMainClass.getDetailByQuery(select);
            //     ////string dis = "";
            //     //if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            //     //{
            //     //    DataRow dr = dt.Rows[0];
            //     //    string a = dr[1].ToString();
            //     //    string dis = dr[3].ToString();
            //     //    txtdis.Text = dis;
            //     //    string select1 = "select venderId,vName,vCompName,vAddress ,vPhone,vMobile,vFax from VendorDetails where venderId='" + a + "'";
            //     //    SetVendor(select1);
            //     //    string selectqurry1 = "select vodd.ItemId,td.ItemName, vodd.Quantity,vodd.Price,vodd.TotalPrice,vod.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId where vod. Orderid='" + txtRef.Text + "'";
            //     //    DataTable dt2 = dbMainClass.getDetailByQuery(selectqurry1);
            //     //    int totalRowCount = addToCartTable.Rows.Count;
            //     //    for (int rowCount = 0; rowCount < totalRowCount; rowCount++)
            //     //    {
            //     //        addToCartTable.Rows.RemoveAt(0);
            //     //    }

            //     //    for (int c = 0; c < dt2.Rows.Count; c++)
            //     //    {
            //     //        DataRow dr2 = dt2.Rows[c];
            //     //        string txtItemCode = dr2[0].ToString();
            //     //        string txtitemNmae = dr2[1].ToString();
            //     //        string txtRate = dr2[2].ToString();
            //     //        string txtQuanity = dr2[3].ToString();
            //     //        string txtAmoun = dr2[4].ToString();
            //     //        string txtitemNmea = dr2[5].ToString();
            //     //        int amt = Convert.ToInt32(txtAmoun);
            //     //        totel = totel + amt;
            //     //        dr2 = addToCartTable.NewRow();
            //     //        dr2[0] = txtItemCode.Trim();
            //     //        dr2[1] = txtitemNmae.Trim();
            //     //        dr2[2] = txtRate.Trim();//
            //     //        dr2[3] = txtQuanity.Trim();
            //     //        dr2[4] = txtQuanity.Trim();
            //     //        dr2[5] = txtAmoun.Trim();
            //     //        // dr2[5] = textBox1.Text.Trim();
            //     //        addToCartTable.Rows.Add(dr2);

            //     //    }
            //     //    dataGridView1.DataSource = addToCartTable;
            //     //    txttotalAmount.Text = totel.ToString();
            //     //}
            //     }

            // else
            // {
            //     button5.Enabled = true;
            //     int totel1 = 0;
            //     string select = "select vo.Orderid,vo.venderId,vod.ItemId,vo.Discount from VendorOrderDesc vod join VendorOrderDetails vo on vod.Orderid=vo.Orderid where vo.Orderid='" + txtRef.Text + "'";
            //     DataTable dt = dbMainClass.getDetailByQuery(select);
            //     //string dis = "";
            //     if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            //     {
            //         DataRow dr = dt.Rows[0];
            //         string a = dr[1].ToString();
            //         string dis = dr[3].ToString();
            //         txtdis.Text = dis;
            //         string select1 = "select venderId,vName,vCompName,vAddress ,vPhone,vMobile,vFax from VendorDetails where venderId='" + a + "'";
            //         SetVendor(select1);
            //         string selectqurry1 = "select vodd.ItemId,td.ItemName, vodd.Quantity,vodd.Price,vodd.TotalPrice,vod.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId where vod. Orderid='" + txtRef.Text + "'";
            //         DataTable dt2 = dbMainClass.getDetailByQuery(selectqurry1);
            //         int totalRowCount = addToCartTable.Rows.Count;
            //         for (int rowCount = 0; rowCount < totalRowCount; rowCount++)
            //         {
            //             addToCartTable.Rows.RemoveAt(0);
            //         }

            //         for (int c = 0; c < dt2.Rows.Count; c++)
            //         {
            //             DataRow dr2 = dt2.Rows[c];
            //             string txtItemCode = dr2[0].ToString();
            //             string txtitemNmae = dr2[1].ToString();
            //             string txtRate = dr2[2].ToString();
            //             string txtQuanity = dr2[3].ToString();
            //             string txtAmoun = dr2[4].ToString();
            //             string txtitemNmea = dr2[5].ToString();
            //             //tot = txtitemNmea;
            //             int amt = Convert.ToInt32(txtitemNmea);
            //             totel1 = totel1 + amt;
            //             dr2 = addToCartTable.NewRow();
            //             dr2[0] = txtItemCode.Trim();
            //             dr2[1] = txtitemNmae.Trim();
            //             dr2[2] = txtRate.Trim();//
            //             dr2[3] = txtQuanity.Trim();
            //             dr2[4] = txtQuanity.Trim();
            //             dr2[5] = txtAmoun.Trim();
            //             // dr2[5] = textBox1.Text.Trim();
            //             addToCartTable.Rows.Add(dr2);
            //         }
            //         dataGridView1.DataSource = addToCartTable;
            //         txttotalAmount.Text = totel1.ToString();
            //     }
            //// }
            // }
        }

        private void txtRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                addToCartTable.Columns.RemoveAt(6);
                addToCartTable.Columns.Add(new DataColumn("ResivQuantity"));
                addToCartTable.Columns.Add(new DataColumn("Amount"));
                txtRef.ReadOnly = true;
                string dilqurry = "select Orderid from CustomerOrderDelivery where Orderid ='" + txtRef.Text + "'";
                DataTable dildt = dbMainClass.getDetailByQuery(dilqurry);
                if (dildt != null && dildt.Rows != null && dildt.Rows.Count > 0)
                {
                    //button5.Enabled = false;

                    MessageBox.Show("This Order completed");
                    txtRef.Text = "";
                    textVendercod.Focus();

                }


                else
                {
                    button5.Enabled = true;
                    int totel1 = 0;
                    string select = "select vo.Orderid,vo.venderId,vod.ItemId,vo.Discount from VendorOrderDesc vod join VendorOrderDetails vo on vod.Orderid=vo.Orderid where vo.Orderid ='" + txtRef.Text + "'";
                    DataTable dt = dbMainClass.getDetailByQuery(select);
                    //string dis = "";
                    if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        string a = dr[1].ToString();
                        string dis = dr[3].ToString();
                        txtdis.Text = dis;
                        string select1 = "select venderId,vName,vCompName,vAddress ,vPhone,vMobile,vFax from VendorDetails where venderId='" + a + "'";
                        SetVendor(select1);
                        string selectqurry1 = "select vodd.ItemId,td.ItemName,td.ItemCompName,ipq.MrpPrice, vodd.Quantity,vodd.Price,vodd.TotalPrice,vod.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId join ItemPriceDetail ipq on td.ItemId=ipq.ItemId where vod. Orderid ='" + txtRef.Text + "'";
                        DataTable dt2 = dbMainClass.getDetailByQuery(selectqurry1);
                        int totalRowCount = addToCartTable.Rows.Count;
                        for (int rowCount = 0; rowCount < totalRowCount; rowCount++)
                        {
                            addToCartTable.Rows.RemoveAt(0);
                        }

                        for (int c = 0; c < dt2.Rows.Count; c++)
                        {
                            DataRow dr2 = dt2.Rows[c];
                            string txtItemCode = dr2[0].ToString();
                            string txtitemNmae = dr2[1].ToString();
                            string CompanyName = dr2[2].ToString();
                            string MrpPrice = dr2[3].ToString();
                            string txtRate = dr2[5].ToString();
                            string txtQuanity = dr2[4].ToString();
                            string txtAmoun = dr2[6].ToString();
                            string txtitemNmea = dr2[6].ToString();
                            //tot = txtitemNmea;
                            int amt = Convert.ToInt32(txtitemNmea);
                            totel1 = totel1 + amt;
                            dr2 = addToCartTable.NewRow();
                            dr2[0] = txtItemCode.Trim();
                            dr2[1] = txtitemNmae.Trim();
                            dr2[2] = CompanyName.Trim();
                            dr2[3] = MrpPrice.Trim();
                            dr2[4] = txtRate.Trim();
                            dr2[5] = txtQuanity.Trim();
                            dr2[6] = txtQuanity.Trim();
                            dr2[7] = txtAmoun.Trim();
                            // dr2[5] = textBox1.Text.Trim();
                            addToCartTable.Rows.Add(dr2);
                        }
                        dataGridView1.DataSource = addToCartTable;
                        txttotalAmount.Text = totel1.ToString();
                    }
                    if (dataGridView1.Rows.Count > 0)
                    {
                        txtDiscount.ReadOnly = true;
                    }
                    if (dataGridView1.Rows.Count > 1)
                    {
                        txtDiscount.ReadOnly = false;
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
            txttotalAmount.Text = "0";
            dataGridView1.DataSource = "";
            addToCartTable.Clear();

        }
        private void SetVendor(string r)
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

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (txtRef.Text == "")
            {
                string itemid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string selectqurry = "select Ids.ItemName,Ids.ItemCompName,ipd.MrpPrice, ipd.SalesPrice from ItemDetails Ids  join ItemPriceDetail ipd on Ids.ItemId=ipd.ItemId  where Ids.ItemId='" + itemid + "'";
                DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
                string rate = "";
                foreach (DataRow dr in dt.Rows)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value = dr[0].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = dr[1].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = dr[2].ToString();
                    // gridPurchaseOrder.Rows[e.RowIndex].Cells[5].Value=dr[3].ToString();

                    rate = dr[3].ToString();
                }
                if (rate != "")
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
                    {
                        int co = dataGridView1.CurrentRow.Index;
                        DataGridViewRow selectedRow = dataGridView1.Rows[0];
                        selectedRow.Selected = true;
                        selectedRow.Cells[4].Selected = true;
                        //gridPurchaseOrder.CurrentCell = gridPurchaseOrder[gridPurchaseOrder.CurrentCell.ColumnIndex + 2, gridPurchaseOrder.CurrentCell.RowIndex];
                        //gridPurchaseOrder.Focus();
                    }
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value = rate;
                    string quantity = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
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
                    dataGridView1.Rows[e.RowIndex].Cells[6].Value = price.ToString();
                    Double totalammount = Convert.ToDouble(txttotalAmount.Text);
                    Double toat = totalammount + price;
                    txttotalAmount.Text = toat.ToString();
                }
                else
                {
                    MessageBox.Show("please select your correct row");
                }
            }

            if (txtRef.Text != "")
            {

                string a = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                string rate = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                if (a != "")
                {
                    int quantity = Convert.ToInt32(a);
                    int reta = Convert.ToInt32(rate);
                    int toteamount = quantity * reta;
                    dataGridView1.Rows[e.RowIndex].Cells[7].Value = toteamount.ToString();
                    string qun = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    int quanti = Convert.ToInt32(qun);
                    int vauequn = quantity - quanti;
                    int trea = reta * vauequn;
                    int tamunt = Convert.ToInt32(txttotalAmount.Text);
                    int tam = tamunt + trea;
                    txttotalAmount.Text = tam.ToString();
                }
                else
                {
                    MessageBox.Show("please select your correct row");
                    dataGridView1.Rows[e.RowIndex].Cells[0].Value = "";
                }
            }

        }





        private void butClose_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            DeliveryReportViewer.Visible = false;
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
            string getId = "select ItemId from ItemDetails where ItemId ='" + txtItemCode.Text + "'";
            DataTable dt = dbMainClass.getDetailByQuery(getId);
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (textVendercod.Text == "V")
                {
                    MessageBox.Show("Please Enter The Vendor Code");
                    textVendercod.Focus();
                    txtItemCode.Text = "I";
                    txtProductName.Text = "";
                    txtRate.Text = "";
                    txtQunty.Text = "";
                    txtAmount.Text = "";
                    button3.Enabled = false;
                }
                else
                {
                    string itemCode = txtItemCode.Text;
                    setitemVlue("ItemId", itemCode);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        txtQunty.ReadOnly = false;
                        button3.Enabled = true;
                        txtQunty.Enabled = true;
                        txtQunty.Focus();
                        IndexTex2();
                        textVendercod.TabStop = true;
                        button1.TabStop = true;
                    }
                    else
                    {
                        MessageBox.Show("Please Enter The Correct Item Id");

                    }
                }
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
                    //if (txtItemCode.Text == "")
                    //{
                    txtItemCode.Text = "I";
                    //}
                    e.Handled = false;
                    txtAmount.Text = "";
                    txtQunty.Text = "";
                    txtItemCode.Focus();

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
            button5.TabStop = true;
            button7.TabStop = true;
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                if (addToCartTable.Rows.Count > 0)
                {


                    int currentrow = dataGridView1.CurrentRow.Index;
                    string Amount = dataGridView1.Rows[currentrow - 1].Cells[6].Value.ToString();
                    double totalAmount = Convert.ToDouble(txttotalAmount.Text);
                    totalAmount -= Convert.ToDouble(Amount.Trim());
                    txttotalAmount.Text = totalAmount.ToString();
                    int index = dataGridView1.SelectedRows[0].Index;
                    //addToCartTable.Rows.RemoveAt(index-1);

                    dataGridView1.Rows[index - 1].DefaultCellStyle.Font = new Font(new FontFamily("Microsoft Sans Serif"), 9.00F, FontStyle.Strikeout);
                    dataGridView1.Rows[index - 1].DefaultCellStyle.ForeColor = Color.Red;

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
                    if (dataGridView1.Rows.Count > 0)
                    {
                        txtDiscount.Text = "0";
                        txtDiscount.ReadOnly = true;
                    }
                    if (dataGridView1.Rows.Count > 1)
                    {
                        txtDiscount.ReadOnly = false;
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
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textVendercod_KeyPress(object sender, KeyPressEventArgs e)
        {
            string getId = "select venderId from VendorDetails where venderId='" + textVendercod.Text + "'";
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
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    if (textVendercod.Text == "")
                    {
                        textVendercod.Text = "V";
                    }
                    e.Handled = false;
                }
                else if (e.KeyChar == 'V' && string.IsNullOrWhiteSpace(textVendercod.Text))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
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
            // txtSearch.Text = "";
            comboBox1.SelectedIndex = 0;
            int currentIndex = dataGridView2.CurrentRow.Index;
            if (e.KeyChar == (char)Keys.Enter)
            {
                //if (dataGridView1.RowCount == currentIndex + 1)
                //    currentIndex = currentIndex + 1;
                if (counter == 0)
                {
                    panel2.Visible = false;
                    DataGridViewCellCollection CellCollection = dataGridView2.Rows[currentIndex - 1].Cells;
                    if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                    {
                        setDetails(CellCollection);
                        IndexTex3();
                    }
                }
                if (counter == 1)
                {
                    panel2.Visible = false;
                    DataGridViewCellCollection CellCollection = dataGridView2.Rows[currentIndex - 1].Cells;
                    if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                    {
                        setDetails1(CellCollection);
                        txtQunty.ReadOnly = false;
                        button3.Enabled = true;
                        txtQunty.Focus();
                        IndexTex2();
                        txtQunty.Enabled = true;
                    }
                }
                if (counter == 2)
                {
                    panel2.Visible = false;
                    DataGridViewCellCollection CellCollection = dataGridView2.Rows[currentIndex - 1].Cells;
                    if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                    {
                        string s = CellCollection[0].Value.ToString();
                        string s1 = CellCollection[1].Value.ToString();
                        txtRef.Text = s;
                        //MessageBox.Show(" "+s +" "+s1);
                        string selectqurry = "select venderId,vName,vCompName,vAddress,vPhone,vMobile,vFax from VendorDetails where venderId='" + s1 + "'";
                        SetVendor(selectqurry);
                        string selectqurry1 = "select vodd.ItemId,td.ItemName,td.ItemCompName,ipq.MrpPrice, vodd.Quantity,vodd.Price,vodd.TotalPrice,vod.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId join ItemPriceDetail ipq on td.ItemId=ipq.ItemId where vod. Orderid ='" + s + "'";
                        DataTable dt2 = dbMainClass.getDetailByQuery(selectqurry1);
                        int totalRowCount = addToCartTable.Rows.Count;
                        for (int rowCount = 0; rowCount < totalRowCount; rowCount++)
                        {
                            addToCartTable.Rows.RemoveAt(0);
                        }
                        int totel1 = 0;
                        for (int c = 0; c < dt2.Rows.Count; c++)
                        {
                            DataRow dr2 = dt2.Rows[c];
                            string txtItemCode = dr2[0].ToString();
                            string txtitemNmae = dr2[1].ToString();
                            string CompanyName = dr2[2].ToString();
                            string MrpPrice = dr2[3].ToString();
                            string txtRate = dr2[5].ToString();
                            string txtQuanity = dr2[4].ToString();
                            string txtAmoun = dr2[6].ToString();
                            string txtitemNmea = dr2[6].ToString();
                            //tot = txtitemNmea;
                            int amt = Convert.ToInt32(txtitemNmea);
                            totel1 = totel1 + amt;
                            dr2 = addToCartTable.NewRow();
                            dr2[0] = txtItemCode.Trim();
                            dr2[1] = txtitemNmae.Trim();
                            dr2[2] = CompanyName.Trim();
                            dr2[3] = MrpPrice.Trim();
                            dr2[4] = txtRate.Trim();
                            dr2[5] = txtQuanity.Trim();
                            dr2[6] = txtQuanity.Trim();
                            dr2[7] = txtAmoun.Trim();
                            // dr2[5] = textBox1.Text.Trim();
                            addToCartTable.Rows.Add(dr2);
                        }
                        dataGridView1.DataSource = addToCartTable;
                        txttotalAmount.Text = totel1.ToString();
                    }
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
            //int currentIndex = dataGridView2.CurrentRow.Index;
            //if (dataGridView1.RowCount == currentIndex + 1)
            //currentIndex = currentIndex + 1;
            if (counter == 0)
            {
                panel2.Visible = false;
                DataGridViewCellCollection CellCollection = dataGridView2.Rows[e.RowIndex].Cells;
                if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                {
                    setDetails(CellCollection);
                    IndexTex3();
                }
            }
            if (counter == 1)
            {
                panel2.Visible = false;
                DataGridViewCellCollection CellCollection = dataGridView2.Rows[e.RowIndex].Cells;

                if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                {
                    setDetails1(CellCollection);
                    txtQunty.ReadOnly = false;
                    button3.Enabled = true;
                    txtQunty.Focus();
                    IndexTex2();
                    txtQunty.Enabled = true;
                }
            }
            if (counter == 2)
            {
                panel2.Visible = false;
                DataGridViewCellCollection CellCollection = dataGridView2.Rows[e.RowIndex].Cells;
                if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                {
                    string s = CellCollection[0].Value.ToString();
                    string s1 = CellCollection[1].Value.ToString();
                    txtRef.Text = s;
                    //MessageBox.Show(" "+s +" "+s1);
                    string selectqurry = "select venderId,vName,vCompName,vAddress,vPhone,vMobile,vFax from VendorDetails where venderId='" + s1 + "'";
                    SetVendor(selectqurry);

                    string selectqurry1 = "select vodd.ItemId,td.ItemName,td.ItemCompName,ipq.MrpPrice, vodd.Quantity,vodd.Price,vodd.TotalPrice,vod.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId join ItemPriceDetail ipq on td.ItemId=ipq.ItemId where vod. Orderid ='" + s + "'";
                    DataTable dt2 = dbMainClass.getDetailByQuery(selectqurry1);
                    int totalRowCount = addToCartTable.Rows.Count;
                    for (int rowCount = 0; rowCount < totalRowCount; rowCount++)
                    {
                        addToCartTable.Rows.RemoveAt(0);
                    }
                    int totel1 = 0;
                    for (int c = 0; c < dt2.Rows.Count; c++)
                    {
                        DataRow dr2 = dt2.Rows[c];
                        string txtItemCode = dr2[0].ToString();
                        string txtitemNmae = dr2[1].ToString();
                        string CompanyName = dr2[2].ToString();
                        string MrpPrice = dr2[3].ToString();
                        string txtRate = dr2[5].ToString();
                        string txtQuanity = dr2[4].ToString();
                        string txtAmoun = dr2[6].ToString();
                        string txtitemNmea = dr2[6].ToString();
                        //tot = txtitemNmea;
                        int amt = Convert.ToInt32(txtitemNmea);
                        totel1 = totel1 + amt;
                        dr2 = addToCartTable.NewRow();
                        dr2[0] = txtItemCode.Trim();
                        dr2[1] = txtitemNmae.Trim();
                        dr2[2] = CompanyName.Trim();
                        dr2[3] = MrpPrice.Trim();
                        dr2[4] = txtRate.Trim();
                        dr2[5] = txtQuanity.Trim();
                        dr2[6] = txtQuanity.Trim();
                        dr2[7] = txtAmoun.Trim();
                        // dr2[5] = textBox1.Text.Trim();
                        addToCartTable.Rows.Add(dr2);
                    }
                    dataGridView1.DataSource = addToCartTable;
                    txttotalAmount.Text = totel1.ToString();

                }
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

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            //double totalAmount = 0.00;//Convert.ToDouble(txttotalAmount.Text);
            //foreach (DataRow dr in addToCartTable.Rows)
            //{
            //    totalAmount += Convert.ToDouble(dr[6].ToString());
            //}
            //string discountAmount = txtDiscount.Text;
            ////double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
            //double amount = 0.0;
            //if (double.TryParse(discountAmount, out amount))
            //{
            //    double totalDiscount = Convert.ToDouble(discountAmount);
            //    totalAmount = totalAmount - ((totalAmount * totalDiscount) / 100);
            //    txttotalAmount.Text = totalAmount.ToString();
            //}

        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txtDiscount.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
            //if (e.KeyChar == (char)Keys.Enter)
            //{
            if (e.KeyChar == (char)Keys.Enter)
            {

                if (txtRef.Text == "")
                {
                    double totalAmount = 0.00;//Convert.ToDouble(txttotalAmount.Text);
                    foreach (DataRow dr in addToCartTable.Rows)
                    {
                        totalAmount += Convert.ToDouble(dr[6].ToString());
                    }
                    string discountAmount = txtDiscount.Text;
                    //double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
                    double amount = 0.0;
                    if (double.TryParse(discountAmount, out amount))
                    {
                        double totalDiscount = Convert.ToDouble(discountAmount);
                        totalAmount = totalAmount - ((totalAmount * totalDiscount) / 100);
                        txttotalAmount.Text = totalAmount.ToString();
                        double dis = totalAmount * totalDiscount / 100;
                        txtDisAmount.Text = dis.ToString();
                    }
                }
                if (txtRef.Text != "")
                {
                    double totalAmount = 0.00;//Convert.ToDouble(txttotalAmount.Text);
                    foreach (DataRow dr in addToCartTable.Rows)
                    {
                        totalAmount += Convert.ToDouble(dr[7].ToString());
                    }
                    string discountAmount = txtDiscount.Text;
                    //double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
                    double amount = 0.0;
                    if (double.TryParse(discountAmount, out amount))
                    {
                        double totalDiscount = Convert.ToDouble(discountAmount);
                        totalAmount = totalAmount - ((totalAmount * totalDiscount) / 100);
                        txttotalAmount.Text = totalAmount.ToString();
                        double dis = totalAmount * totalDiscount / 100;
                        txtDisAmount.Text = dis.ToString();
                    }
                }

            }
        }

        private void txttotalAmount_TextChanged(object sender, EventArgs e)
        {
            if (txttotalAmount.Text == "")
            {
                txttotalAmount.Text = "0";
            }
            double d = 1;
            double total = Convert.ToDouble(txttotalAmount.Text);
            double g = Convert.ToDouble(txtDiscount.Text);
            double tax = d + ((g / 100));
            double taxamount = total / tax;
            double totaltax = total - taxamount;
            txtTaxAmount.Text = totaltax.ToString();
        }

        private void Form7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "S")
            {
                deliverysave();
                //this.Close();
            }
            if (e.Alt && e.KeyCode.ToString() == "D")
            {
                txtDiscount.Focus();
            }
        }

        private void txtItemCode_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlPaymentDetail.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //string insertQurry = "insert into AllPaymentDetailes Values('" + txtInvoiceid.Text + "','" + CashAmount.Text + "','" + txtCreditAmount.Text + "','" + txtDebitBankName.Text + "','" + txtCardNumber.Text + "','" + CmbCardType.SelectedItem.ToString() + "','" + txtChequeAmount.Text + "','" + txtChequeBankName.Text + "','" + txtChequeNumber.Text + "','" + dateTimePicker1.Value.ToString() + "','" + txtEwalletAmount.Text + "','" + EWalletCompanyName.Text + "','" + txtTransactionNumber.Text + "','" + dateTimePicker2.Value.ToString() + "','" + txtCouponAmount.Text + "','" + CmbCompany.SelectedItem.ToString() + "','" + txtInvoiceAmount.Text + "','" + txtTotalAmount1.Text + "','" + txtBalance.Text + "','" + txtRturned.Text + "','" + txtNetAmount.Text + "')";
            //int insertedRows = dbMainClass.saveDetails(insertQurry);

            deliverysave();
            pnlPaymentDetail.Visible = false;
            DeliveryReportViewer.Visible = true;
        }

        private void pnlPaymentDetail_Paint(object sender, PaintEventArgs e)
        {
            txtInvoiceid.Text = txtSrNo.Text;
            txtInvoiceAmount.Text = txttotalAmount.Text;
        }

        private void CashAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void CashAmount_Leave(object sender, EventArgs e)
        {
            if (CashAmount.Text == "")
            {
                CashAmount.Text = "0.00";
            }
            if (CashAmount.Text != "0.00")
            {
                //CashAmount.Text = "";
                string amount = CashAmount.Text + ".00";
                //CashAmount.Text = amount;
                txtTotalAmount1.Text = CashAmount.Text;
            }
        }

        private void txtCreditAmount_Leave(object sender, EventArgs e)
        {
            if (txtCreditAmount.Text == "")
            {
                txtCreditAmount.Text = "0.00";
            }
            if (txtCreditAmount.Text != "0.00")
            {
                string amount = txtCreditAmount.Text + ".00";
                txtCreditAmount.Text = amount;
                Double Amount = Convert.ToDouble(txtCreditAmount.Text);
                Double Amount1 = Convert.ToDouble(CashAmount.Text);
                Double amount2 = Amount + Amount1;
                string Amount2 = amount2.ToString();
                txtTotalAmount1.Text = Amount2 + ".00";
            }
        }

        private void txtChequeAmount_Leave(object sender, EventArgs e)
        {
            if (txtChequeAmount.Text == "")
            {
                txtChequeAmount.Text = "0.00";
            }
            if (txtChequeAmount.Text != "0.00")
            {
                string amount = txtChequeAmount.Text + ".00";
                txtChequeAmount.Text = amount;
                //txtNetAmount.Text = amount;
                Double Amount = Convert.ToDouble(txtCreditAmount.Text);
                Double Amount1 = Convert.ToDouble(CashAmount.Text);
                Double Amount3 = Convert.ToDouble(txtChequeAmount.Text);
                Double amount2 = Amount + Amount1 + Amount3;
                string Amount2 = amount2.ToString();
                txtTotalAmount1.Text = Amount2 + ".00";
            }

        }

        private void txtEwalletAmount_Leave(object sender, EventArgs e)
        {
            if (txtEwalletAmount.Text == "")
            {
                txtEwalletAmount.Text = "0.00";
            }
            if (txtEwalletAmount.Text != "0.00")
            {
                string amount = txtEwalletAmount.Text + ".00";
                txtEwalletAmount.Text = amount;
                Double Amount = Convert.ToDouble(txtCreditAmount.Text);
                Double Amount1 = Convert.ToDouble(CashAmount.Text);
                Double Amount3 = Convert.ToDouble(txtChequeAmount.Text);
                Double Amount4 = Convert.ToDouble(txtEwalletAmount.Text);
                Double amount2 = Amount + Amount1 + Amount3 + Amount4;
                string Amount2 = amount2.ToString();
                txtTotalAmount1.Text = Amount2 + ".00";
            }
        }

        private void txtCouponAmount_Leave(object sender, EventArgs e)
        {
            if (txtCouponAmount.Text == "")
            {
                txtCouponAmount.Text = "";
            }
            if (txtCouponAmount.Text != "0.00")
            {
                string amount = txtCouponAmount.Text;
                //txtCouponAmount.Text = amount;
                Double Amount = Convert.ToDouble(txtCreditAmount.Text);
                Double Amount1 = Convert.ToDouble(CashAmount.Text);
                Double Amount3 = Convert.ToDouble(txtChequeAmount.Text);
                Double Amount4 = Convert.ToDouble(txtEwalletAmount.Text);
                Double Amount5 = Convert.ToDouble(txtCouponAmount.Text);
                Double amount2 = Amount + Amount1 + Amount3 + Amount4 + Amount5;
                string Amount2 = amount2.ToString();
                txtTotalAmount1.Text = Amount2.ToString();
            }
        }

        private void txtTotalAmount1_TextChanged(object sender, EventArgs e)
        {
            txtNetAmount.Text = txtTotalAmount1.Text;
            Double Amount = Convert.ToDouble(txtTotalAmount1.Text);
            Double Amount1 = Convert.ToDouble(txtInvoiceAmount.Text);
            Double Amount2 = Amount1 - Amount;
            string Amount3 = Amount2.ToString();
            txtBalance.Text = Amount2.ToString();
        }

        private void CashAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && CashAmount.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }

}
