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
            textVendercod.Select(textVendercod.Text.Length, 0);
            txtItemCode.Select(txtItemCode.Text.Length, 0);
            txtDiscount.ReadOnly = true;
            IndexTex1();
            txtTaxAmount.Visible = false;
            txtWAmount.Visible = false;
            txtDisAmount.Visible = false;
            txtQunty.ReadOnly = true;
            button4.Enabled = false;
            button3.Enabled = false;
            txtdis.ReadOnly = true;
            txtDisAmount.Text = "0";
            txttotalAmount.Text = "0.00";
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
                //int txt = Convert.ToInt32(id);
                //int txt1 = txt + 1;
                //txtSrNo.Text = txt1.ToString();
                DeliveryID(id);

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
            txtSearch.Focus();
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
                txtRate.Text = cellCollection[7].Value.ToString();
                double rate = Convert.ToDouble(txtRate.Text);
                // maxquantity = Convert.ToInt32((cell1[3].Value.ToString()));
                txtQunty.Text = "1";
                double quantuty = Convert.ToDouble(txtQunty.Text);
                double amount = (rate * quantuty);
                txtAmount.Text = amount.ToString("###0.00");
               //cellCollection[4].Value.ToString();

            }
            catch (Exception ex)
            {
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          /*  //txtSearch.Text = "";
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
                    txtQunty.Focus();
                    txtQunty.Select(txtQunty.Text.Length, 0);
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
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeliveryReportViewer.Visible = false;
            txtSearch.Text = "";
           //txtAmount.Text = "0";
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
            txtSearch.Focus();
           

        }

        private void btnSelectPurchaseOrder_Click(object sender, EventArgs e)
        {
            counter = 2;
            DeliveryReportViewer.Visible = false;
            panel2.Visible = true;
            string selectqurry = "select  VendorOrderDetails.Orderid as[Order Id],VendorOrderDetails.venderId as [Vendor Id], VendorDetails.vName as[Vendor Name],VendorDetails.vCompName as[Company Name], VendorDetails.vAddress as[Address],VendorOrderDetails.OrderDate as[Order Date],(select Sum(VendorOrderDesc.Quantity) from VendorOrderDesc where VendorOrderDesc.Orderid= VendorOrderDetails.Orderid) as[Bild Quanity],VendorOrderDetails.WithoutTexAmount as[Gross Amount],VendorOrderDetails.Discount as[Discount Rate],VendorOrderDetails.DisAmount as[Dicount Amount],VendorOrderDetails.vat as[Tax],VendorOrderDetails.TextTaxAmmount as[Tax Amount],VendorOrderDetails.TotalPrice as[Total Amount] from VendorOrderDetails join VendorDetails on VendorDetails.venderId=VendorOrderDetails.venderId";
            string selectqurryForActualColumnName = "select top 1 VendorOrderDetails.Orderid,VendorOrderDetails.venderId, VendorDetails.vName, VendorDetails.vAddress,VendorDetails.vCompName,VendorOrderDetails.OrderDate,(select Sum(VendorOrderDesc.Quantity) from VendorOrderDesc where VendorOrderDesc.Orderid= VendorOrderDetails.Orderid) as[Bild Quanity],VendorOrderDetails.WithoutTexAmount,VendorOrderDetails.Discount,VendorOrderDetails.DisAmount,VendorOrderDetails.vat,VendorOrderDetails.TextTaxAmmount,VendorOrderDetails.TotalPrice from VendorOrderDetails join VendorDetails on VendorDetails.venderId=VendorOrderDetails.venderId";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            DataTable dtOnlyColumnName = dbMainClass.getDetailByQuery(selectqurryForActualColumnName);
            DataTable customDataTable = new DataTable();
            customDataTable.Columns.Add("ActualTableColumnName");
            customDataTable.Columns.Add("AliasTableColumnName");
            //List<string> ls = new List<string>();
            DataColumnCollection d = dt.Columns;
            DataColumnCollection dataColumnForName = dtOnlyColumnName.Columns;
            for (int a = 0; a < d.Count; a++)
            {
                //DataColumn dc = new DataColumn();
                string b = d[a].ToString();
                string actualColumnName = dataColumnForName[a].ToString();
                DataRow dr = customDataTable.NewRow();
                dr["ActualTableColumnName"] = actualColumnName;
                dr["AliasTableColumnName"] = b;
                customDataTable.Rows.Add(dr);
                //  ls.Add(b);
            }

            comboBox1.DataSource = customDataTable;
            comboBox1.ValueMember = "ActualTableColumnName";
            comboBox1.DisplayMember = "AliasTableColumnName";
            dataGridView2.DataSource = dt;
            //comboBox1.DataSource = ls;
            //dataGridView2.DataSource = dt;
            IndexTex();
            //addToCartTable.Columns.RemoveAt(6);
            if (!addToCartTable.Columns.Contains("Revised Quantity"))
            {
                addToCartTable.Columns.Add(new DataColumn("Revised Quantity"));
            }

            if (!addToCartTable.Columns.Contains("Amount"))
            {
                addToCartTable.Columns.Add(new DataColumn("Amount"));
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textVendercod_TextChanged(object sender, EventArgs e)
        {
            if (!textVendercod.Text.StartsWith("V"))
            {
                textVendercod.Text = string.Concat("V", textVendercod.Text);
                textVendercod.Select(textVendercod.Text.Length, 0);
            }
            if (textVendercod.Text.Trim() != "" && textVendercod.Text.StartsWith("V"))
            {
                setVAlue();
            }
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            if (!txtItemCode.Text.StartsWith("I"))
            {
                txtItemCode.Text = string.Concat("I", txtItemCode.Text);
                txtItemCode.Select(txtItemCode.Text.Length, 0);
            }
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
                    txtAmount.Text = "0.00";
                }
            }
        }
        #region /////////// AddToList Clicked ///////////////
        private void button3_Click(object sender, EventArgs e)
        {
            button5.TabStop = true;
            button7.TabStop = true;
              if ((txtQunty.Text == "") || (txtQunty.Text == "0"))
                  {
                      MessageBox.Show("Entered Quantity should not less than one.",
    "Information",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning);
                      txtQunty.Text = "1";
                      txtQunty.Focus();
                      txtQunty.SelectAll();
                  }
                 
            else
            {
                button3.Focus();
                txtRef.Enabled = false;
                btnSelectPurchaseOrder.Enabled = false;
                if (txtRef.Text == "")
                {
                    txtItemCode.Focus();
                    txtQunty.ReadOnly = true;
                    textVendercod.TabStop = true;
                    button1.TabStop = true;
                    txtDiscount.TabStop = false;
                    string itemid = "";
                    string quntity = "";
                    string rate = "";
                    string ammount = "";
                    int counter = 0;
                    int quntity1 = 0;
                    string itemname = product(txtItemCode.Text);
                    if (itemname != txtProductName.Text)
                    {
                                MessageBox.Show("Please Select correct ItemCode");
                                return;
                            }
                            else
                            {
                                foreach (DataRow dr3 in addToCartTable.Rows)
                                {
                                    int q3 = 0;
                                    itemid = dr3[0].ToString();
                                    if (ls.Contains(itemid) && dataGridView1.Rows[counter].DefaultCellStyle.Font != null)
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
                                        int q2 = Convert.ToInt32(txtQunty.Text);
                                        q3 = q1 + q2;
                                        quntity1 = quntity1 + q3;
                                        int q4 = Convert.ToInt32(txtQuantityBild.Text);
                                        int q5 = q4 - q1;
                                        int q6 = quntity1 + q5;
                                        txtQuantityBild.Text = q6.ToString();
                                        dr3[5] = q3.ToString();
                                        Double rate1 = Convert.ToDouble(rate);
                                        Double rate6 = rate1 * q2;
                                        Double rate2 = Convert.ToDouble(ammount);
                                        Double rate7 = Convert.ToDouble(txtAmount.Text);
                                        Double rate3 = rate6 + rate2;
                                        dr3[6] = rate3.ToString("###0.00");
                                        Double rate4 = Convert.ToDouble(txttotalAmount.Text);
                                        Double rate5 = rate4 + rate7;
                                        txttotalAmount.Text = rate5.ToString("###0.00");//rate3.ToString();
                                        // MessageBox.Show("Please Enter the Quanity");

                                        txtWAmount.Text = rate5.ToString();
                                        
                                        txtItemCode.Text = "I";
                                        txtItemCode.Select(txtItemCode.Text.Length, 0);
                                        txtProductName.Text = "";
                                        txtRate.Text = "";
                                        txtQunty.Text = "";
                                        txtAmount.Text = "";
                                        //txtItemCode.Focus();
                                        button3.Enabled = false;


                                    }
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
                    if (txtProductName.Text == "" && txtQunty.Text == "")
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
                            //string select1 = "select ItemName from ItemDetails where ItemId='" + txtItemCode.Text + "'";
                            //DataTable data1 = dbMainClass.getDetailByQuery(select1);
                            //string itemName = "";
                            //foreach (DataRow dr2 in data1.Rows)
                            //{
                            //    itemName = dr2[0].ToString();
                            //}
                            string itemname1 = product(txtItemCode.Text);
                            if (itemname1!= txtProductName.Text)
                            {
                                MessageBox.Show("Please Select correct ItemCode");
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

                                button4.Enabled = true;
                                DataRow dr = addToCartTable.NewRow();
                                dr[0] = txtItemCode.Text.Trim();
                                dr[1] = txtProductName.Text.Trim();
                                dr[2] = ConpanyName.Trim();
                                dr[3] = Mrp.Trim();
                                dr[4] = txtRate.Text.Trim();
                                dr[5] = txtQunty.Text.Trim();
                                dr[6] = txtAmount.Text.Trim();
                                int q1 = Convert.ToInt32(txtQunty.Text.Trim());
                                int q2 = Convert.ToInt32(txtQuantityBild.Text);
                                int q3 = q1 + q2;
                                txtQuantityBild.Text = q3.ToString();
                                addToCartTable.Rows.Add(dr);
                                dataGridView1.DataSource = addToCartTable;
                                var dgvcount = dataGridView1.Rows.Count;
                                dataGridView1.CurrentCell = dataGridView1.Rows[dgvcount - 2].Cells[0];
                                //dgv_Checks.CurrentCell = dgv_Checks.Rows[dgvcount - 1].Cells[0];
                                double totalAmount = Convert.ToDouble(txttotalAmount.Text);
                                totalAmount += Convert.ToDouble(txtAmount.Text.Trim());
                                txttotalAmount.Text = totalAmount.ToString("###0.00");
                                txtWAmount.Text = totalAmount.ToString();

                                txtWAmount.Text = totalAmount.ToString("###0.00");
                                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                                txtItemCode.Text = "I";
                                txtProductName.Text = "";
                                txtRate.Text = "";
                                txtQunty.Text = "";
                                txtAmount.Text = "";
                                //txtItemCode.Focus();
                                button3.Enabled = false;
                                //txtRemoveItem.Focus();
                                txtQunty.TabStop = false;
                                txtQunty.ReadOnly = true;
                                //}
                            }
                        }
                        if (dataGridView1.Rows.Count > 1)
                        {
                            txtDiscount.ReadOnly = false;
                        }
                        txtItemCode.Select(txtItemCode.Text.Length, 0);
                    }


                }
                if (txtRef.Text != "")
                {
                    txtItemCode.Focus();
                    txtQunty.ReadOnly = true;
                    textVendercod.TabStop = true;
                    button1.TabStop = true;
                    txtDiscount.TabStop = false;
                    string itemid = "";
                    string quntity = "";
                    string rate = "";
                    string ammount = "";
                    int quntity1 = 0;
                    int counter = 0;
                    string itemname = product(txtItemCode.Text);
                    if (itemname != txtProductName.Text)
                    {
                                MessageBox.Show("Please Select correct ItemCode");
                            }
                            else
                            {
                                foreach (DataRow dr3 in addToCartTable.Rows)
                                {
                                    int q3 = 0;
                                    itemid = dr3[0].ToString();
                                    if (ls.Contains(itemid) && dataGridView1.Rows[counter].DefaultCellStyle.Font != null)
                                    {
                                        counter++;
                                        continue;
                                    }
                                    counter++;
                                    quntity = dr3[5].ToString();
                                    rate = dr3[4].ToString();
                                    ammount = dr3[7].ToString();

                                    if (itemid == txtItemCode.Text)
                                    {
                                        if (quntity == "")
                                        {
                                            quntity = "0";
                                        }
                                        int q1 = Convert.ToInt32(quntity);
                                        int q2 = Convert.ToInt32(txtQunty.Text);
                                        q3 = q1 + q2;
                                        quntity1 = quntity1 + q3;
                                        int q4 = Convert.ToInt32(txtQuantityBild.Text);
                                        int q5 = q4 - q1;
                                        int q6 = quntity1 + q5;
                                        txtQuantityBild.Text = q6.ToString();
                                        dr3[5] = q3.ToString();
                                        dr3[6] = q3.ToString();
                                        Double rate1 = Convert.ToDouble(rate);
                                        Double rate6 = rate1 * q2;
                                        Double rate2 = Convert.ToDouble(ammount);
                                        Double rate7 = Convert.ToDouble(txtAmount.Text);
                                        Double rate3 = rate6 + rate2;
                                        dr3[7] = rate3.ToString("###0.00");
                                        Double rate4 = Convert.ToDouble(txttotalAmount.Text);
                                        Double rate5 = rate4 + rate7;
                                        txttotalAmount.Text = rate5.ToString("###0.00");//rate3.ToString();
                                        // MessageBox.Show("Please Enter the Quanity");

                                        txtWAmount.Text = rate5.ToString();

                                        txtItemCode.Text = "I";
                                        txtItemCode.Select(txtItemCode.Text.Length, 0);
                                        txtProductName.Text = "";
                                        txtRate.Text = "";
                                        txtQunty.Text = "";
                                        txtAmount.Text = "";
                                        //txtItemCode.Focus();
                                        button3.Enabled = false;


                                    }
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
                    if (txtProductName.Text == "" && txtQunty.Text == "")
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
                            //string select1 = "select ItemName from ItemDetails where ItemId='" + txtItemCode.Text + "'";
                            //DataTable data1 = dbMainClass.getDetailByQuery(select1);
                            //string itemName = "";
                            //foreach (DataRow dr2 in data1.Rows)
                            //{
                            //    itemName = dr2[0].ToString();
                            //}
                            string itemname1 = product(txtItemCode.Text);
                            if (itemname1 != txtProductName.Text)
                            {
                                MessageBox.Show("Please Select correct ItemCode");
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

                                button4.Enabled = true;
                                DataRow dr = addToCartTable.NewRow();
                                dr[0] = txtItemCode.Text.Trim();
                                dr[1] = txtProductName.Text.Trim();
                                dr[2] = ConpanyName.Trim();
                                dr[3] = Mrp.Trim();
                                dr[4] = txtRate.Text.Trim();
                                dr[5] = txtQunty.Text.Trim();
                                dr[6] = txtQunty.Text.Trim();
                                dr[7] = txtAmount.Text.Trim();
                                int q1 = Convert.ToInt32(txtQunty.Text.Trim());
                                int q2 = Convert.ToInt32(txtQuantityBild.Text);
                                int q3 = q1 + q2;
                                txtQuantityBild.Text = q3.ToString();
                                addToCartTable.Rows.Add(dr);
                                dataGridView1.DataSource = addToCartTable;
                                var dgvcount = dataGridView1.Rows.Count;
                                dataGridView1.CurrentCell = dataGridView1.Rows[dgvcount - 2].Cells[0];
                                //dgv_Checks.CurrentCell = dgv_Checks.Rows[dgvcount - 1].Cells[0];
                                double totalAmount = Convert.ToDouble(txttotalAmount.Text);
                                totalAmount += Convert.ToDouble(txtAmount.Text.Trim());
                                txttotalAmount.Text = totalAmount.ToString("###0.00");
                                txtWAmount.Text = totalAmount.ToString();

                                txtWAmount.Text = totalAmount.ToString();
                                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                                txtItemCode.Text = "I";
                                txtProductName.Text = "";
                                txtRate.Text = "";
                                txtQunty.Text = "";
                                txtAmount.Text = "";
                                //txtItemCode.Focus();
                                button3.Enabled = false;
                                //txtRemoveItem.Focus();
                                txtQunty.TabStop = false;
                                txtQunty.ReadOnly = true;
                                //}
                            }
                        }
                        if (dataGridView1.Rows.Count > 1)
                        {
                            txtDiscount.ReadOnly = false;
                        }
                        txtItemCode.Select(txtItemCode.Text.Length, 0);
                    }


                }
            }
               
        }
        #endregion

        #region /////////// add Column to AddToCraft DataTable///////////////
        private void setAddToCraftTable()
        {
            addToCartTable.Columns.Add(new DataColumn("Item Code"));
            addToCartTable.Columns.Add(new DataColumn("Item Name"));
            addToCartTable.Columns.Add(new DataColumn("Company Name"));
            addToCartTable.Columns.Add(new DataColumn("MRP"));
            addToCartTable.Columns.Add(new DataColumn("Rate"));
            addToCartTable.Columns.Add(new DataColumn("Quantity"));
            addToCartTable.Columns.Add(new DataColumn("Revised Quantity"));
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
        public string product(string ItemName)
        {
            string select1 = "select ItemName from ItemDetails where ItemId='" + ItemName + "'";
            DataTable data1 = dbMainClass.getDetailByQuery(select1);
            string itemName = "";
            foreach (DataRow dr2 in data1.Rows)
            {
                itemName = dr2[0].ToString();
            }
            return itemName;
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
            if (txtProductName.Text != "")
            {
                MessageBox.Show("Please Add Item");
                txtQunty.Focus();
            }
          else  if (textVendercod.Text == "V")
            {
                MessageBox.Show("Please Enter The Vendor Code");
                textVendercod.Focus();
                textVendercod.Select(textVendercod.Text.Length, 0);
            }
            else if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please Enter The Item");
                txtItemCode.Focus();
                txtItemCode.Select(txtItemCode.Text.Length, 0);
            }
            else
            {
             
                if (ls.Count == dataGridView1.Rows.Count - 1)
                {
                    MessageBox.Show("Please Enter The Item");
                    txtItemCode.Focus();
                    txtItemCode.Select(txtItemCode.Text.Length, 0);
                    //return;//
                }
                else
                {
                    pnlPaymentDetail.Visible = true;
                    CmbPageName.SelectedIndex = 0;
                    CmbCompany.SelectedIndex = 0;
                    CmbCardType.SelectedIndex = 0;
                    CashAmount.Focus();
                }
            }
            //deliverysave();

            
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
                int count = 0;
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
                    string insertqurry = "insert into VendorOrderDetails values('" + textVendercod.Text + "','" + txtdate.Value.ToString() + "','" + txttotalAmount.Text + "','" +txtDiscount.Text +"','" + txtdis.Text + "','" + txtDisAmount.Text + "','" + txtTaxAmount.Text + "','" + txtWAmount.Text + "')";
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
                            if (ls.Contains(txtItemCod) && dataGridView1.Rows[count].DefaultCellStyle.Font != null)
                            {
                                count++;
                                continue;
                            }
                            count++;
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
                                if (ls.Contains(txtItemCode) && dataGridView1.Rows[count].DefaultCellStyle.Font != null)
                                {
                                    count++;
                                    continue;
                                }
                                count++;
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
                                    DeliveryID(txtSrNo.Text);
                                    BlankPaymentPage();
                                    makeBlank();
                                   
                                    dataGridView1.AllowUserToAddRows = true;
                                }
                                else
                                {
                                    MessageBox.Show("Details Not Saved Successfully");
                                    dataGridView1.AllowUserToAddRows = true;
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
                    string insertqurry1 = "insert into VendorOrderDetails values('" + textVendercod.Text + "','" + txtdate.Value.ToString() + "','" + txttotalAmount.Text + "','" +txtDiscount.Text +"','" + txtdis.Text + "','" + txtDisAmount.Text + "','" + txtTaxAmount.Text + "','" + txtWAmount.Text + "')";

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
                            if (ls.Contains(txtItemCod) && dataGridView1.Rows[count].DefaultCellStyle.Font != null)
                                {
                                    count++;
                                    continue;
                                }
                            count++;
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
                            //string deleteQurry = "delete VendorOrderDesc where Orderid='" + OrderID + "'";
                            //DataTable dt = dbMainClass.getDetailByQuery(deleteQurry);


                            //DataGridViewRowCollection RowCollection2 = dataGridView1.Rows;
                            //List<string> sf1 = new List<string>();
                            //for (int a = 0; a < RowCollection.Count; a++)
                            //{

                            //    DataGridViewRow currentRow = RowCollection2[a];
                            //    DataGridViewCellCollection cellCollection = currentRow.Cells;
                            //    string txtItemCode = cellCollection[0].Value.ToString();
                            //    if (ls.Contains(txtItemCode) && dataGridView1.Rows[count-1].DefaultCellStyle.Font != null)
                            //    {
                            //        count++;
                            //        continue;
                            //    }
                            //    count++;
                            //    string txtRate = cellCollection[4].Value.ToString();
                            //    string txtQuanity = cellCollection[5].Value.ToString();
                            //    string txtAmoun = cellCollection[6].Value.ToString();
                            //    // string OrderID = id4.ToString(); ;

                            //    string Query = "insert into VendorOrderDesc Values('" + OrderID + "','" + txtItemCode + "','" + txtRate + "','" + txtQuanity + "','" + txtAmoun + "')";
                            //    //MessageBox.Show(Query);

                            //    sf1.Add(Query);

                            //}
                            //int insertedRows4 = dbMainClass.saveDetails(sf1);
                            //if (insertedRows4 > 0)
                            //{
                                string insertQurry = "insert into CustomerOrderDelivery Values('" + OrderID + "','true','" + txtdate.Value.ToString() + "','" + Ref + "')";
                                int insertedRows5 = dbMainClass.saveDetails(insertQurry);
                                if (insertedRows5 > 0)
                                {
                                    string insertQurry1 = "insert into AllPaymentDetailes Values('" + txtInvoiceid.Text + "','" + CashAmount.Text + "','" + txtCreditAmount.Text + "','" + txtDebitBankName.Text + "','" + txtCardNumber.Text + "','" + CmbCardType.SelectedItem.ToString() + "','" + txtChequeAmount.Text + "','" + txtChequeBankName.Text + "','" + txtChequeNumber.Text + "','" + dateTimePicker1.Value.ToString() + "','" + txtEwalletAmount.Text + "','" + EWalletCompanyName.Text + "','" + txtTransactionNumber.Text + "','" + dateTimePicker2.Value.ToString() + "','" + txtCouponAmount.Text + "','" + CmbCompany.SelectedItem.ToString() + "','" + txtInvoiceAmount.Text + "','" + txtTotalAmount1.Text + "','" + txtBalance.Text + "','" + txtRturned.Text + "','" + txtNetAmount.Text + "')";
                                    int insertedRows = dbMainClass.saveDetails(insertQurry1);
                                    if (insertedRows > 0)
                                    {

                                        MessageBox.Show("Details Saved Successfully");
                                        DeliveryID(txtSrNo.Text);
                                        BlankPaymentPage();
                                        makeBlank();
                                      
                                        DialogResult result1 = MessageBox.Show("This Page Print", "Important Question", MessageBoxButtons.YesNo);
                                        if (result1 == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            DeliveryReportViewer.Visible = true;
                                            panel2.Visible = true;
                                            //string conntion = "Data Source=DELL-PC;Initial Catalog=SalesMaster;User ID=sa; Password=dell@12345;";
                                            SqlConnection con = dbMainClass.openConnection();//new SqlConnection(conntion);
                                            int id = Convert.ToInt32(txtSrNo.Text);
                                            int id7 = id - 1;
                                            string selectqurry = "select * from purchesDelivery where Deliveryid='" + id7 + "'";
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
                                            textVendercod.Focus();
                                            textVendercod.Select(textVendercod.Text.Length, 0);
                                            textVendercod.TabStop = true;
                                            button1.TabStop = true;
                                        }

                                        dataGridView1.AllowUserToAddRows = true;

                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Details Not Saved Successfully");
                                    dataGridView1.AllowUserToAddRows = true;
                                }
                           // }
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
             if (txtRef.Text != "")
            {
                int count = 0;
                string updateQurry1 = "update VendorOrderDetails set venderId='" + textVendercod.Text + "',TotalPrice='" + txttotalAmount.Text + "',Discount='" + txtDiscount.Text + "',DisAmount='" + txtDisAmount.Text + "',TextTaxAmmount='" + txtTaxAmount.Text + "' where Orderid='" + txtRef.Text + "'";
                int insertedRows3 = dbMainClass.saveDetails(updateQurry1);
                if (insertedRows3 > 0)
                {
                    dataGridView1.AllowUserToAddRows = false;
                    DataGridViewRowCollection call1 = dataGridView1.Rows;
                    for (int c = 0; c < call1.Count; c++)
                    {
                        DataGridViewRow currentRow1 = call1[c];
                        DataGridViewCellCollection cellCollection1 = currentRow1.Cells;
                        string itid = cellCollection1[0].Value.ToString();
                        //if (ls.Contains(itid) && dataGridView1.Rows[count].DefaultCellStyle.Font != null)
                        //{
                        //    count++;
                        //    continue;
                        //}
                        //count++;
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
                    DataTable dt2 = dbMainClass.getDetailByQuery(deleteQurry);
                    //dataGridView1.DataSource = "";


                    counter = 0;
                    if (counter == 0)
                    {
                        string updateQurry = "update VendorOrderDetails set WithoutTexAmount='" + txtWAmount.Text + "' where Orderid='"+txtRef.Text+"'";
                        int inserted = dbMainClass.saveDetails(updateQurry);

                        DataGridViewRowCollection RowCollection = dataGridView1.Rows;
                        List<string> sf1 = new List<string>();
                        for (int a = 0; a < RowCollection.Count; a++)
                        {

                            DataGridViewRow currentRow = RowCollection[a];
                            DataGridViewCellCollection cellCollection = currentRow.Cells;
                            string txtItemCode = cellCollection[0].Value.ToString();
                            if (ls.Contains(txtItemCode) && dataGridView1.Rows[count].DefaultCellStyle.Font != null)
                            {
                                count++;
                                continue;
                            }
                            count++;
                            string txtRate = cellCollection[4].Value.ToString();
                            string txtQuanity = cellCollection[6].Value.ToString();
                            string txtAmoun = cellCollection[7].Value.ToString();
                            string OrderID1 = txtRef.Text;

                            string Query = "insert into VendorOrderDesc Values('" + OrderID1 + "','" + txtItemCode + "','" + txtRate + "','" + txtQuanity + "','" + txtAmoun + "')";
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
                                    DeliveryID(txtSrNo.Text);
                                    BlankPaymentPage();
                                    makeBlank();
                                   
                                    txtRef.Text = "";
                                    DialogResult result1 = MessageBox.Show("This Page Print", "Important Question", MessageBoxButtons.YesNo);
                                    if (result1 == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        DeliveryReportViewer.Visible = true;
                                        panel2.Visible = true;
                                        //string conntion = "Data Source=NITU;Initial Catalog=SalesMaster;Integrated Security=true;";
                                        SqlConnection con = dbMainClass.openConnection(); //new SqlConnection(conntion);
                                        int id = Convert.ToInt32(txtSrNo.Text);
                                        int id7 = id - 1;
                                        string selectqurry = "select * from purchesDelivery where Deliveryid='" +id7 + "'";
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
                                        addToCartTable.Columns.RemoveAt(6);
                                        if (!addToCartTable.Columns.Contains("Revised Quantity"))
                                        {
                                            addToCartTable.Columns.Add(new DataColumn("Revised Quantity"));
                                            addToCartTable.Columns.RemoveAt(6);
                                        }

                                        if (!addToCartTable.Columns.Contains("Amount"))
                                        {
                                            addToCartTable.Columns.RemoveAt(6);
                                            addToCartTable.Columns.Add(new DataColumn("Amount"));
                                        }
                                        textVendercod.Focus();
                                        textVendercod.Select(textVendercod.Text.Length, 0);
                                        textVendercod.TabStop = true;
                                        button1.TabStop = true;
                                       
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
            //int id = Convert.ToInt32(txtSrNo.Text);
            //int id1 = id + 1;
            //txtSrNo.Text = id1.ToString();

        }
        private void txtQunty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //button3.Focus();
                  if ((txtQunty.Text == "") || (txtQunty.Text == "0"))
                  {
                      MessageBox.Show("Entered Quantity should not less than one.",
    "Information",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning);
                      txtQunty.Text = "1";
                      txtQunty.Focus();
                      txtQunty.SelectAll();
                  }
                  else
                  {
                      button3.Focus();
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
                if (txtRef.Text == "")
                {
                    MessageBox.Show("please enter the Refence Number");
                    txtRef.Focus();
                }
                else
                {
                    string dilqurry1 = "select Orderid from VendorOrderDesc where Orderid ='" + txtRef.Text + "'";
                    DataTable dildt2 = dbMainClass.getDetailByQuery(dilqurry1);
                    if (dildt2.Rows.Count==0)
                    {
                        MessageBox.Show("This Order Is Not Available");
                        txtRef.Text = "";
                        textVendercod.Focus();
                        textVendercod.Select(textVendercod.Text.Length, 0);
                        button1.TabStop = true;
                        textVendercod.TabStop = true;

                        //return;
                    }
                    else
                    {
                        button4.Enabled = true;
                        txtItemCode.Focus();
                        IndexTex2();
                        addToCartTable.Columns.RemoveAt(6);
                        if (!addToCartTable.Columns.Contains("Revised Quantity"))
                        {
                            addToCartTable.Columns.Add(new DataColumn("Revised Quantity"));
                        }

                        if (!addToCartTable.Columns.Contains("Amount"))
                        {
                            addToCartTable.Columns.Add(new DataColumn("Amount"));
                        }
                        txtRef.ReadOnly = true;
                        string dilqurry = "select Orderid from CustomerOrderDelivery where Orderid ='" + txtRef.Text + "'";
                        DataTable dildt = dbMainClass.getDetailByQuery(dilqurry);
                        if (dildt != null && dildt.Rows != null && dildt.Rows.Count > 0)
                        {
                            //button5.Enabled = false;
                            addToCartTable.Columns.RemoveAt(6);
                            if (!addToCartTable.Columns.Contains("Revised Quantity"))
                            {
                                addToCartTable.Columns.Add(new DataColumn("Revised Quantity"));
                                addToCartTable.Columns.RemoveAt(6);

                            }

                            if (!addToCartTable.Columns.Contains("Amount"))
                            {
                                addToCartTable.Columns.Add(new DataColumn("Amount"));
                            }
                            button4.Enabled = false;
                            MessageBox.Show("This Order completed");
                            addToCartTable.Columns.RemoveAt(6);
                            if (!addToCartTable.Columns.Contains("Revised Quantity"))
                            {
                                addToCartTable.Columns.Add(new DataColumn("Revised Quantity"));
                                addToCartTable.Columns.RemoveAt(6);

                            }

                            if (!addToCartTable.Columns.Contains("Amount"))
                            {
                                addToCartTable.Columns.Add(new DataColumn("Amount"));
                            }
                            //addToCartTable.Columns.RemoveAt(6);
                            txtRef.Text = "";
                            textVendercod.Focus();
                            textVendercod.Select(textVendercod.Text.Length, 0);
                            addToCartTable.Columns.RemoveAt(6);
                            textVendercod.TabStop = true;
                            button1.TabStop = true;

                        }


                        else
                        {
                            addToCartTable.Columns.RemoveAt(6);
                            if (!addToCartTable.Columns.Contains("Revised Quantity"))
                            {
                                addToCartTable.Columns.Add(new DataColumn("Revised Quantity"));
                                addToCartTable.Columns.RemoveAt(6);

                            }

                            if (!addToCartTable.Columns.Contains("Amount"))
                            {
                                addToCartTable.Columns.Add(new DataColumn("Amount"));
                            }
                            button5.Enabled = true;
                            decimal totel1 = 0;
                            string select = "select vo.Orderid,vo.venderId,vod.ItemId,vo.Discount from VendorOrderDesc vod join VendorOrderDetails vo on vod.Orderid=vo.Orderid where vo.Orderid ='" + txtRef.Text + "'";
                            DataTable dt = dbMainClass.getDetailByQuery(select);
                            //string dis = "";
                            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                            {
                                DataRow dr = dt.Rows[0];
                                string a = dr[1].ToString();
                                string dis = dr[3].ToString();
                                //txtdis.Text = dis;
                                string select1 = "select venderId,vName,vCompName,vAddress ,vPhone,vMobile,vFax from VendorDetails where venderId='" + a + "'";
                                SetVendor(select1);
                                string selectqurry1 = "select vodd.ItemId,td.ItemName,td.ItemCompName,ipq.MrpPrice, vodd.Quantity,vodd.Price,vodd.TotalPrice,vod.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId join ItemPriceDetail ipq on td.ItemId=ipq.ItemId where vod. Orderid ='" + txtRef.Text + "'";
                                DataTable dt2 = dbMainClass.getDetailByQuery(selectqurry1);
                                int totalRowCount = addToCartTable.Rows.Count;
                                for (int rowCount = 0; rowCount < totalRowCount; rowCount++)
                                {
                                    addToCartTable.Rows.RemoveAt(0);
                                }
                                int quntity1 = 0;
                                for (int c = 0; c < dt2.Rows.Count; c++)
                                {
                                    DataRow dr2 = dt2.Rows[c];
                                    string tItemCode = dr2[0].ToString();
                                    string txtitemNmae = dr2[1].ToString();
                                    string CompanyName = dr2[2].ToString();
                                    string MrpPrice = dr2[3].ToString();
                                    string txtRate = dr2[5].ToString();
                                    string txtQuanity = dr2[4].ToString();
                                    string txtAmoun = dr2[6].ToString();
                                    string txtitemNmea = dr2[6].ToString();
                                    
                                    decimal amt = Convert.ToDecimal(txtitemNmea);
                                    totel1 = totel1 + amt;
                                    dr2 = addToCartTable.NewRow();
                                    dr2[0] = tItemCode.Trim();
                                    dr2[1] = txtitemNmae.Trim();
                                    dr2[2] = CompanyName.Trim();
                                    dr2[3] = MrpPrice.Trim();
                                    dr2[4] = txtRate.Trim();
                                    dr2[5] = txtQuanity.Trim();
                                    dr2[6] = txtQuanity.Trim();
                                    dr2[7] = txtAmoun.Trim();
                                    int q1 = Convert.ToInt32(txtQuanity.Trim());
                                    quntity1 = quntity1 + q1;
                                    txtQuantityBild.Text = quntity1.ToString();
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
                    button4.Enabled = false;
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
            txttotalAmount.Text = "0.00";
            txtQuantityBild.Text = "0";
           // dataGridView1.DataSource = "";
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
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           /* if (txtRef.Text == "")
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
                    txttotalAmount.Text = toat.ToString("###0.00");
                }
                else
                {
                    MessageBox.Show("please select your correct row");
                }
            }
            */
            if (txtRef.Text != "")
            {
                int quantity=0;
                string a =  dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                        string rate =  dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        quantity = Convert.ToInt32(a);
                        double r = Convert.ToDouble(rate);
                        double totalammount = quantity * r;
                        dataGridView1.Rows[e.RowIndex].Cells[7].Value = totalammount.ToString();
                        //string newquantity = gridsalesdelivary.Rows[e.RowIndex].Cells[3].Value.ToString();
                        string rate1 =  dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                        double quantity1 = Convert.ToDouble(a);
                        double finalquantity = Convert.ToDouble(rate1);
                        finalquantity = quantity1 - quantity;
                        double totalq = quantity1 * finalquantity;
                        double totalammount1 = Convert.ToDouble(txttotalAmount.Text);
                        double t = totalammount1 + totalq;
                        txttotalAmount.Text = totalammount.ToString("###0.00");
                        double totalValues = 0.0;

                        foreach (DataGridViewRow row in  dataGridView1.Rows)
                        {
                            dataGridView1.AllowUserToAddRows = false;
                             string amountValue = row.Cells[row.Cells.Count-1].Value.ToString();
                                totalValues += Convert.ToDouble(amountValue);
                            
                          
                        }
                        txttotalAmount.Text = totalValues.ToString("###0.00");
                        dataGridView1.AllowUserToAddRows = true;
                    }
                else
                {
                    MessageBox.Show("please select your correct row");
                    dataGridView1.Rows[e.RowIndex].Cells[0].Value = "";
                }
           // }
           
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            if (txtRef.Text == "")
            {
                panel2.Visible = false;
                DeliveryReportViewer.Visible = false;
                if (txtProductName.Text != "")
                {
                    txtQunty.Focus();
                    txtQunty.TabStop = true;
                    txtItemCode.TabStop = true;
                    textVendercod.TabStop = true;
                    button1.TabStop = true;
                    button2.TabStop = true;
                    button3.TabStop = true;
                    button4.TabStop = true;
                }
                else if (textVendercod.Text == "V")
                {
                    textVendercod.Focus();
                    textVendercod.Select(textVendercod.Text.Length, 0);
                    button1.TabStop = true;
                    textVendercod.TabStop = true;
                    addToCartTable.Columns.RemoveAt(6);
                    if (!addToCartTable.Columns.Contains("Revised Quantity"))
                    {
                        addToCartTable.Columns.Add(new DataColumn("Revised Quantity"));
                        addToCartTable.Columns.RemoveAt(6);
                    }

                    if (!addToCartTable.Columns.Contains("Amount"))
                    {
                        addToCartTable.Columns.RemoveAt(6);
                        addToCartTable.Columns.Add(new DataColumn("Amount"));
                    }
                
                }
                else if (textVendercod.Text != "V")
                {
                    txtItemCode.Focus();
                    txtItemCode.Select(txtItemCode.Text.Length, 0);
                    IndexTex2();
                    if (dataGridView1.RowCount > 0)
                    {
                        IndexTex2();
                        button5.TabStop = true;
                        button7.TabStop = true;
                    }


                }
                
            }
            if (txtRef.Text != "")
            {
                panel2.Visible = false;
                DeliveryReportViewer.Visible = false;
              
                if (txtProductName.Text != "")
                {
                    txtQunty.Focus();
                    txtQunty.TabStop = true;
                    txtItemCode.TabStop = true;
                    textVendercod.TabStop = true;
                    button1.TabStop = true;
                    button2.TabStop = true;
                    button3.TabStop = true;
                    button4.TabStop = true;
                }
                else if (textVendercod.Text == "V")
                {
                    textVendercod.Focus();
                    textVendercod.Select(textVendercod.Text.Length, 0);
                    button1.TabStop = true;
                    textVendercod.TabStop = true;
                }
                else if (textVendercod.Text != "V")
                {
                    txtItemCode.Focus();
                    txtItemCode.Select(txtItemCode.Text.Length, 0);
                    IndexTex2();
                }

            }
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
                                                  txtQunty.Text = "1";
                          int que = Convert.ToInt32(txtQunty.Text);
                          string purchesprice = "select SalesPrice from ItemPriceDetail where ItemId ='" + txtItemCode.Text + "'";
                          DataTable dt1 = dbMainClass.getDetailByQuery(purchesprice);
                          string salep = "";
                          foreach (DataRow dr in dt1.Rows)
                          {
                              salep = dr[0].ToString();
                          }
                          Double Saleprice = Convert.ToDouble(salep);
                          Double price = Saleprice * que;
                          txtAmount.Text = price.ToString("###0.00");


                        button3.Enabled = true;
                        txtQunty.Enabled = true;
                        txtQunty.Focus();
                        txtQunty.SelectAll();

                        IndexTex2();
                        textVendercod.TabStop = true;
                        button1.TabStop = true;
                        button5.TabStop = false;
                        button7.TabStop = false;
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
                   // txtItemCode.Text = "I";
                    //txtItemCode.Select(txtItemCode.Text.Length, 0);
                    //}
                    e.Handled = false;
                    txtProductName.Text = "";
                    txtRate.Text = "";
                    txtQunty.ReadOnly = true;
                    txtAmount.Text = "";
                    txtQunty.Text = "";
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
            txtItemCode.Select(txtItemCode.Text.Length, 0);
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
            //txtItemCode.TabStop = true;
            //button2.TabStop = true;
            //textVendercod.TabStop = true;
            //button1.TabStop = true;
            //txtdis.TabStop = false;
            if (txtQunty.Text != "")
            {
                txtQunty.Focus();
                txtQunty.TabStop = true;
                txtQunty.SelectAll();
            }
            else
            {
                txtQunty.TabStop = false;
            }
            txtItemCode.TabStop = true;
            button2.TabStop = true;
            txtDiscount.TabStop = false;
            button3.TabStop = true;
            button4.TabStop = true;
            textVendercod.TabStop = true;
            button1.TabStop = true;
           // button3.TabStop = true;
           // button4.TabStop = true;
           // panel2.TabStop = false;
          button5.TabStop = true;
          button7.TabStop = true;
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                    Color backGroundColor = dataGridView1.DefaultCellStyle.SelectionBackColor;
                    if (backGroundColor.Name == "DodgerBlue" || backGroundColor.Name == "Highlight")
                    {
                        MessageBox.Show("Please select  remove button");
                        return;
                    }
                    if (addToCartTable.Rows.Count > 0)
                    {
                        if (txttotalAmount.Text == "")
                        {
                            txttotalAmount.Text = "0";
                        }
                        int index = dataGridView1.SelectedRows[0].Index;
                        string itemId = dataGridView1.Rows[index - 1].Cells[0].Value.ToString();
                        if ((!ls.Contains(itemId)) || (dataGridView1.Rows[index - 1].DefaultCellStyle.Font == null))
                        {
                            string Amount = "";
                            int currentrow = dataGridView1.CurrentRow.Index;
                            if (txtRef.Text == "")
                            {
                                Amount = dataGridView1.Rows[currentrow - 1].Cells[6].Value.ToString();
                                string quantity = dataGridView1.Rows[currentrow - 1].Cells[5].Value.ToString();
                                int q1 = Convert.ToInt32(txtQuantityBild.Text);
                                q1 -= Convert.ToInt32(quantity.Trim());
                                txtQuantityBild.Text = q1.ToString();
                                if (Amount == "")
                                {
                                    Amount = "0";
                                }
                            }
                            else if (txtRef.Text != "")
                            {
                                Amount = dataGridView1.Rows[currentrow - 1].Cells[7].Value.ToString();
                                string quantity = dataGridView1.Rows[currentrow - 1].Cells[6].Value.ToString();
                                int q1 = Convert.ToInt32(txtQuantityBild.Text);
                                q1 -= Convert.ToInt32(quantity.Trim());
                                txtQuantityBild.Text = q1.ToString();
                                if (Amount == "")
                                {
                                    Amount = "0";
                                }
                            }
                            double totalAmount = Convert.ToDouble(txttotalAmount.Text);
                            totalAmount -= Convert.ToDouble(Amount.Trim());
                            txttotalAmount.Text = totalAmount.ToString("##0.00");
                            // int index = dataGridView1.SelectedRows[0].Index;
                            //addToCartTable.Rows.RemoveAt(index-1);

                            dataGridView1.Rows[index - 1].DefaultCellStyle.Font = new Font(new FontFamily("Microsoft Sans Serif"), 9.00F, FontStyle.Strikeout);
                            dataGridView1.Rows[index - 1].DefaultCellStyle.ForeColor = Color.Red;
                            ls.Add(itemId);
                            dataGridView1.DataSource = addToCartTable;
                            if (addToCartTable.Rows.Count == 0)
                            {
                                txttotalAmount.Text = "0.00";
                                txtdis.Text = "0.00";
                            }
                            if (ls.Count == dataGridView1.Rows.Count - 1)
                            {
                                txtItemCode.Focus();
                                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                                txtItemCode.Select(txtItemCode.Text.Length, 0);
                                button7.TabStop = false;
                                button5.TabStop = false;
                            }
                            if (dataGridView1.Rows.Count > 0)
                            {
                                //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
                            }

                            if (dataGridView1.Rows.Count > 0)
                            {
                                txtDiscount.Text = "0.00";
                                txtDiscount.ReadOnly = true;
                            }
                            if (dataGridView1.Rows.Count > 1)
                            {
                                txtDiscount.ReadOnly = false;
                                //button7.TabStop = true;
                                //button5.TabStop = true;
                            }
                            //else
                            //{
                            //    button4.Enabled = false;
                        }
                        else if ((!ls.Contains(itemId)) || (dataGridView1.Rows[index - 1].DefaultCellStyle.Font != null))
                        {
                            MessageBox.Show("Item already deleted!");
                        }
                    }
                //int index1 = dataGridView1.SelectedRows[0].Index;
                //string itemId1 = dataGridView1.Rows[index1 - 1].Cells[0].Value.ToString();
               
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                var dgvcount = dataGridView1.Rows.Count;
                dataGridView1.CurrentCell = dataGridView1.Rows[dgvcount - 2].Cells[0];
                txtItemCode.Focus();
                txtItemCode.Select(txtItemCode.Text.Length, 0);
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
                string selectqurry = "select  VendorOrderDetails.Orderid as[Order Id],VendorOrderDetails.venderId as [Vendor Id], VendorDetails.vName as[Vendor Name],VendorDetails.vCompName as[Company Name], VendorDetails.vAddress as[Address],VendorOrderDetails.OrderDate as[Order Date],(select Sum(VendorOrderDesc.Quantity) from VendorOrderDesc where VendorOrderDesc.Orderid= VendorOrderDetails.Orderid) as[Bild Quanity],VendorOrderDetails.WithoutTexAmount as[Gross Amount],VendorOrderDetails.Discount as[Discount Rate],VendorOrderDetails.DisAmount as[Dicount Amount],VendorOrderDetails.vat as[Tax],VendorOrderDetails.TextTaxAmmount as[Tax Amount],VendorOrderDetails.TotalPrice as[Total Amount] from VendorOrderDetails join VendorDetails on VendorDetails.venderId=VendorOrderDetails.venderId where " + t + " like '" + txtSearch.Text + "%'";
                DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
                dataGridView2.DataSource = dt;
            }
        }

        private void dataGridView2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
           // purchase++;
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
                        //panel2.Visible = false;
                        addToCartTable.Columns.RemoveAt(6);
                        if (!addToCartTable.Columns.Contains("Revised Quantity"))
                        {
                            addToCartTable.Columns.Add(new DataColumn("Revised Quantity"));
                            addToCartTable.Columns.RemoveAt(6);
                        }

                        if (!addToCartTable.Columns.Contains("Amount"))
                        {
                            addToCartTable.Columns.Add(new DataColumn("Amount"));
                        }
                        DataGridViewCellCollection CellCollection = dataGridView2.Rows[currentIndex - 1].Cells;
                        if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                        {
                            string s = CellCollection[0].Value.ToString();
                            string s1 = CellCollection[1].Value.ToString();
                            txtRef.Text = s;
                            string dilqurry = "select Orderid from CustomerOrderDelivery where Orderid ='" + s + "'";
                            DataTable dildt = dbMainClass.getDetailByQuery(dilqurry);
                            if (dildt != null && dildt.Rows != null && dildt.Rows.Count > 0)
                            {
                                panel2.Visible = true;
                                txtRef.Text = "";
                                makeBlank();
                                txtSearch.Focus();
                                button4.Enabled = false;
                                MessageBox.Show("This Order completed");
                                return;
                                
                               
                            }
                            else
                            {
                                panel2.Visible = false;
                                button4.Enabled = true;
                                button2.TabStop = true;
                                button4.TabStop = true;
                                button5.TabStop = true;
                                button7.TabStop = true;
                                btnSelectPurchaseOrder.Enabled = false;
                                txtItemCode.TabStop = true;
                                // button4.Enabled = true;
                                txtItemCode.Focus();
                                string selectqurry = "select venderId,vName,vCompName,vAddress,vPhone,vMobile,vFax from VendorDetails where venderId='" + s1 + "'";
                                SetVendor(selectqurry);
                                string selectqurry1 = "select vodd.ItemId,td.ItemName,td.ItemCompName,ipq.MrpPrice, vodd.Quantity,vodd.Price,vodd.TotalPrice,vod.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId join ItemPriceDetail ipq on td.ItemId=ipq.ItemId where vod. Orderid ='" + s + "'";
                                DataTable dt2 = dbMainClass.getDetailByQuery(selectqurry1);
                                int totalRowCount = addToCartTable.Rows.Count;
                                for (int rowCount = 0; rowCount < totalRowCount; rowCount++)
                                {
                                    addToCartTable.Rows.RemoveAt(0);
                                }
                                double totel1 = 0;
                                int quntity1 = 0;
                                for (int c = 0; c < dt2.Rows.Count; c++)
                                {
                                    DataRow dr2 = dt2.Rows[c];
                                    string txtItemCod = dr2[0].ToString();
                                    string txtitemNmae = dr2[1].ToString();
                                    string CompanyName = dr2[2].ToString();
                                    string MrpPrice = dr2[3].ToString();
                                    string txtRate = dr2[5].ToString();
                                    string txtQuanity = dr2[4].ToString();
                                    string txtAmoun = dr2[6].ToString();
                                    string txtitemNmea = dr2[6].ToString();
                                    //tot = txtitemNmea;
                                    double amt = Convert.ToDouble(txtitemNmea);
                                    totel1 = totel1 + amt;
                                    dr2 = addToCartTable.NewRow();
                                    dr2[0] = txtItemCod.Trim();
                                    dr2[1] = txtitemNmae.Trim();
                                    dr2[2] = CompanyName.Trim();
                                    dr2[3] = MrpPrice.Trim();
                                    dr2[4] = txtRate.Trim();
                                    dr2[5] = txtQuanity.Trim();
                                    dr2[6] = txtQuanity.Trim();
                                    dr2[7] = txtAmoun.Trim();
                                    int q1 = Convert.ToInt32(txtQuanity.Trim());
                                    quntity1 = quntity1 + q1;
                                    txtQuantityBild.Text = quntity1.ToString();
                                    addToCartTable.Rows.Add(dr2);
                                }
                                dataGridView1.DataSource = addToCartTable;
                                txttotalAmount.Text = totel1.ToString("###0.00");
                            }
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
               
                addToCartTable.Columns.RemoveAt(6);
                if (!addToCartTable.Columns.Contains("Revised Quantity"))
                {
                    addToCartTable.Columns.Add(new DataColumn("Revised Quantity"));
                    addToCartTable.Columns.RemoveAt(6);
                }

                if (!addToCartTable.Columns.Contains("Amount"))
                {
                    addToCartTable.Columns.Add(new DataColumn("Amount"));
                }
                DataGridViewCellCollection CellCollection = dataGridView2.Rows[e.RowIndex].Cells;
                if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                {
                    string s = CellCollection[0].Value.ToString();
                    string s1 = CellCollection[1].Value.ToString();
                    txtRef.Text = s;
                    string dilqurry = "select Orderid from CustomerOrderDelivery where Orderid ='" + s + "'";
                    DataTable dildt = dbMainClass.getDetailByQuery(dilqurry);
                    if (dildt != null && dildt.Rows != null && dildt.Rows.Count > 0)
                    {
                        panel2.Visible = true;
                        txtRef.Text = "";
                        button4.Enabled = false;
                        makeBlank();
                        txtSearch.Focus();
                        MessageBox.Show("This Order completed");
                        return;
                        
                       
                       
                    }
                    else
                    {
                        panel2.Visible = false;
                        button4.Enabled = true;
                        button2.TabStop = true;
                        button4.TabStop = true;
                        button5.TabStop = true;
                        button7.TabStop = true;
                        btnSelectPurchaseOrder.Enabled = false;
                        txtItemCode.TabStop = true;
                       // button4.Enabled = true;
                        txtItemCode.Focus();
                        string selectqurry = "select venderId,vName,vCompName,vAddress,vPhone,vMobile,vFax from VendorDetails where venderId='" + s1 + "'";
                        SetVendor(selectqurry);

                        string selectqurry1 = "select vodd.ItemId,td.ItemName,td.ItemCompName,ipq.MrpPrice, vodd.Quantity,vodd.Price,vodd.TotalPrice,vod.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId join ItemPriceDetail ipq on td.ItemId=ipq.ItemId where vod. Orderid ='" + s + "'";
                        DataTable dt2 = dbMainClass.getDetailByQuery(selectqurry1);
                        int totalRowCount = addToCartTable.Rows.Count;
                        for (int rowCount = 0; rowCount < totalRowCount; rowCount++)
                        {
                            addToCartTable.Rows.RemoveAt(0);
                        }
                        double totel1 = 0;
                        int quntity1 = 0;
                        for (int c = 0; c < dt2.Rows.Count; c++)
                        {
                            DataRow dr2 = dt2.Rows[c];
                            string txtItemCod = dr2[0].ToString();
                            string txtitemNmae = dr2[1].ToString();
                            string CompanyName = dr2[2].ToString();
                            string MrpPrice = dr2[3].ToString();
                            string txtRate = dr2[5].ToString();
                            string txtQuanity = dr2[4].ToString();
                            string txtAmoun = dr2[6].ToString();
                            string txtitemNmea = dr2[6].ToString();
                            //tot = txtitemNmea;
                            double amt = Convert.ToDouble(txtitemNmea);
                            totel1 = totel1 + amt;
                            dr2 = addToCartTable.NewRow();
                            dr2[0] = txtItemCod.Trim();
                            dr2[1] = txtitemNmae.Trim();
                            dr2[2] = CompanyName.Trim();
                            dr2[3] = MrpPrice.Trim();
                            dr2[4] = txtRate.Trim();
                            dr2[5] = txtQuanity.Trim();
                            dr2[6] = txtQuanity.Trim();
                            dr2[7] = txtAmoun.Trim();
                            int q1 = Convert.ToInt32(txtQuanity.Trim());
                            quntity1 = quntity1 + q1;
                            txtQuantityBild.Text = quntity1.ToString();
                            addToCartTable.Rows.Add(dr2);
                        }
                        dataGridView1.DataSource = addToCartTable;
                        txttotalAmount.Text = totel1.ToString("###0.00");

                    }
                }
            }
        }

        private void button5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                textVendercod.Focus();
                textVendercod.Select(textVendercod.Text.Length, 0);
            }
        }

        private void btnSelectPurchaseOrder_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                textVendercod.Focus();
                textVendercod.Select(textVendercod.Text.Length, 0);
            }
        }

        private void button7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                textVendercod.Focus();
                textVendercod.Select(textVendercod.Text.Length, 0);
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            int counte = 0;
            if (txtRef.Text == "")
            {
               
                double totalAmount = 0.00;//Convert.ToDouble(txttotalAmount.Text);
                double totalAmount1 = 0.00;
                foreach (DataRow dr in addToCartTable.Rows)
                {
                    string itemid = dr[0].ToString();
                    if (ls.Contains(itemid) && dataGridView1.Rows[counte].DefaultCellStyle.Font != null)
                    {
                        counte++;
                        continue;
                    }
                    counte++;
                    totalAmount += Convert.ToDouble(dr[6].ToString());
                    totalAmount1 += Convert.ToDouble(dr[6].ToString());
                }
                string discountAmount = txtDiscount.Text;
                //double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
                double amount = 0.0;
                if (double.TryParse(discountAmount, out amount))
                {
                    double totalDiscount = Convert.ToDouble(discountAmount);
                    totalAmount = totalAmount - ((totalAmount * totalDiscount) / 100);
                    totalAmount1 = ((totalAmount1 * totalDiscount) / 100);
                    txttotalAmount.Text = totalAmount.ToString();
                    double dis = totalAmount1; //* totalDiscount / 100;
                    txtDisAmount.Text = dis.ToString("###0.00");
                    txtDiscount.Select(txtDiscount.Text.Length, 0);
                }
            }
            if (txtRef.Text != "")
            {
                counter = 0;
                double totalAmount = 0.00;//Convert.ToDouble(txttotalAmount.Text);
                double totalAmount1 = 0.00;
                foreach (DataRow dr in addToCartTable.Rows)
                {
                    string itemid = dr[0].ToString();
                    if (ls.Contains(itemid) && dataGridView1.Rows[counter].DefaultCellStyle.Font != null)
                    {
                        counter++;
                        continue;
                    }
                    counter++;
                    totalAmount += Convert.ToDouble(dr[7].ToString());
                    totalAmount1 += Convert.ToDouble(dr[7].ToString());
                }
                string discountAmount = txtDiscount.Text;
                //double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
                double amount = 0.0;
                if (double.TryParse(discountAmount, out amount))
                {
                    double totalDiscount = Convert.ToDouble(discountAmount);
                    totalAmount = totalAmount - ((totalAmount * totalDiscount) / 100);
                    totalAmount1 = ((totalAmount1 * totalDiscount) / 100);
                    txttotalAmount.Text = totalAmount.ToString("###0.00");
                    double dis = totalAmount1; //* totalDiscount / 100;
                    txtDisAmount.Text = dis.ToString("###0.00");
                    txtDiscount.Text = totalDiscount.ToString("###0.00");
                    txtDiscount.Select(txtDiscount.Text.Length, 0);
                }
            }

        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            double totalAmount3 = 0.00;
         if  ((char.IsDigit(e.KeyChar)  || e.KeyChar == '.'))
            {
                if (txtDiscount.Text.IndexOf('.') != -1 && txtDiscount.Text.Split('.')[1].Length == 2)
                {
                    //MessageBox.Show("The maximum decimal points are 2!");
                    e.Handled = true;
                }
            }
            else
            {
                if (e.KeyChar == '\b')
                {
               
                        counter = 0;
                        foreach (DataRow dr in addToCartTable.Rows)
                        {
                            string itemid = dr[0].ToString();
                            if (ls.Contains(itemid) && dataGridView1.Rows[counter].DefaultCellStyle.Font != null)
                            {
                                counter++;
                                continue;
                            }
                            counter++;
                             if (txtRef.Text == "" || txtDiscount.Text == "")
                            {
                            totalAmount3 += Convert.ToDouble(dr[6].ToString());
                             }
                             else if (txtRef.Text != "" || txtDiscount.Text == "")
                             {
                                totalAmount3 += Convert.ToDouble(dr[7].ToString());
                             }
                        }
                        double s1 = totalAmount3;
                        txttotalAmount.Text = s1.ToString("###0.00");
               // }
                   // txtdis.Text = "0";
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
            //if (ch == 46 && txtDiscount.Text.IndexOf('.') != -1)
            //{
            //    e.Handled = true;
            //    return;
            //}
            //if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            //{
            //    e.Handled = true;
            //}
            //if (e.KeyChar == (char)Keys.Enter)
            //{
            if (e.KeyChar == (char)Keys.Enter)
            {

                //if (txtRef.Text == "")
                //{
                //    double totalAmount = 0.00;//Convert.ToDouble(txttotalAmount.Text);
                //    double totalAmount1 = 0.00;
                //    foreach (DataRow dr in addToCartTable.Rows)
                //    {
                //        string itemid = dr[0].ToString();
                //        if (ls.Contains(itemid) && dataGridView1.Rows[counter].DefaultCellStyle.Font != null)
                //        {
                //            counter++;
                //            continue;
                //        }
                //        counter++;
                //        totalAmount += Convert.ToDouble(dr[6].ToString());
                //        totalAmount1 += Convert.ToDouble(dr[6].ToString());
                //    }
                //    string discountAmount = txtDiscount.Text;
                //    //double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
                //    double amount = 0.0;
                //    if (double.TryParse(discountAmount, out amount))
                //    {
                //        double totalDiscount = Convert.ToDouble(discountAmount);
                //        totalAmount = totalAmount - ((totalAmount * totalDiscount) / 100);
                //        totalAmount1 = ((totalAmount1 * totalDiscount) / 100);
                //        txttotalAmount.Text = totalAmount.ToString();
                //        double dis = totalAmount1; //* totalDiscount / 100;
                //        txtDisAmount.Text = dis.ToString();
                //    }
                //}
                //if (txtRef.Text != "")
                //{
                //    double totalAmount = 0.00;//Convert.ToDouble(txttotalAmount.Text);
                //    double totalAmount1 = 0.00;
                //    foreach (DataRow dr in addToCartTable.Rows)
                //    {
                //        string itemid = dr[0].ToString();
                //        if (ls.Contains(itemid) && dataGridView1.Rows[counter].DefaultCellStyle.Font != null)
                //        {
                //            counter++;
                //            continue;
                //        }
                //        counter++;
                //        totalAmount += Convert.ToDouble(dr[7].ToString());
                //        totalAmount1 += Convert.ToDouble(dr[7].ToString());
                //    }
                //    string discountAmount = txtDiscount.Text;
                //    //double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
                //    double amount = 0.0;
                //    if (double.TryParse(discountAmount, out amount))
                //    {
                //        double totalDiscount = Convert.ToDouble(discountAmount);
                //        totalAmount = totalAmount - ((totalAmount * totalDiscount) / 100);
                //        totalAmount1 = ((totalAmount1 * totalDiscount) / 100);
                //        txttotalAmount.Text = totalAmount.ToString();
                //        double dis = totalAmount1; //* totalDiscount / 100;
                //        txtDisAmount.Text = dis.ToString();
                //    }
                //}

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
            double g = Convert.ToDouble(txtdis.Text);
            double tax = d + ((g / 100));
            double taxamount = total / tax;
            double totaltax = total - taxamount;
            txtTaxAmount.Text = totaltax.ToString("###0.00");
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
            BlankPaymentPage();
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //string insertQurry = "insert into AllPaymentDetailes Values('" + txtInvoiceid.Text + "','" + CashAmount.Text + "','" + txtCreditAmount.Text + "','" + txtDebitBankName.Text + "','" + txtCardNumber.Text + "','" + CmbCardType.SelectedItem.ToString() + "','" + txtChequeAmount.Text + "','" + txtChequeBankName.Text + "','" + txtChequeNumber.Text + "','" + dateTimePicker1.Value.ToString() + "','" + txtEwalletAmount.Text + "','" + EWalletCompanyName.Text + "','" + txtTransactionNumber.Text + "','" + dateTimePicker2.Value.ToString() + "','" + txtCouponAmount.Text + "','" + CmbCompany.SelectedItem.ToString() + "','" + txtInvoiceAmount.Text + "','" + txtTotalAmount1.Text + "','" + txtBalance.Text + "','" + txtRturned.Text + "','" + txtNetAmount.Text + "')";
            //int insertedRows = dbMainClass.saveDetails(insertQurry);

            deliverysave();
            pnlPaymentDetail.Visible = false;
            DeliveryReportViewer.Visible = true;
            txtRef.Enabled = true;
            btnSelectPurchaseOrder.Enabled = true;
        }

        private void pnlPaymentDetail_Paint(object sender, PaintEventArgs e)
        {
            IndexTex();
            txtInvoiceid.Text = txtSrNo.Text;
            Double total = Convert.ToDouble(txttotalAmount.Text);
            txtInvoiceAmount.Text = total.ToString("###0.00");
            allvisible();
           
        }
        public void allvisible()
        {
            txtCardNumber.ReadOnly = true;
            txtDebitBankName.ReadOnly = true;
            CmbCardType.Enabled = false;
            txtChequeBankName.ReadOnly = true;
            txtChequeNumber.ReadOnly = true;
            txtCompanyName.ReadOnly = true;
            CmbCompany.Enabled = false;
            dateTimePicker1.Enabled = false;
            txtTransactionNumber.ReadOnly = true;
            dateTimePicker2.Enabled = false;
            EWalletCompanyName.ReadOnly = true;
            //label23.Visible = false;
            //label25.Visible = false;
            //label26.Visible = false;
            //label28.Visible = false;
            //label30.Visible = false;
            //label31.Visible = false;
            //label32.Visible = false;
            //label34.Visible = false;
            //label35.Visible = false;
            //label36.Visible = false;
            txtCardNumber.TabStop = true;
            txtDebitBankName.TabStop = true;
            txtChequeBankName.TabStop = true;
            txtChequeNumber.TabStop = true;
            txtTransactionNumber.TabStop = false;
            EWalletCompanyName.TabStop = false;
        }

        private void CashAmount_TextChanged(object sender, EventArgs e)
        {
            if (CashAmount.Text != "0")
            {
                //CashAmount.Text = "";
                string amount = CashAmount.Text;
                //CashAmount.Text = amount;
                 double amount1 = 0.0;
                 if (double.TryParse(amount, out amount1))
                 {
                     txtTotalAmount1.Text = CashAmount.Text;
                 }
            }
        }

        private void CashAmount_Leave(object sender, EventArgs e)
        {
            decimal x;
            if (decimal.TryParse(CashAmount.Text, out x))
            {
                if (CashAmount.Text.IndexOf('.') != -1 && CashAmount.Text.Split('.')[1].Length > 2)
                {
                    MessageBox.Show("The maximum decimal points are 2!");
                    CashAmount.Focus();
                }
                else CashAmount.Text = x.ToString("0.00");
            }
            else
            {
                CashAmount.Text = "0.00";
                //MessageBox.Show("Data invalid!");
                //txtVenderOpeningBal.Focus();
            }
            
        }

        private void txtCreditAmount_Leave(object sender, EventArgs e)
        {
            if (txtCreditAmount.Text == "0.00")
            {
                credittext1();
            }
            if (txtCreditAmount.Text != "0.00")
            {
               credittext();
            }
            decimal x;
            if (decimal.TryParse(txtCreditAmount.Text, out x))
            {
                if (txtCreditAmount.Text.IndexOf('.') != -1 && txtCreditAmount.Text.Split('.')[1].Length > 2)
                {
                    MessageBox.Show("The maximum decimal points are 2!");
                    txtCreditAmount.Focus();
                }
                else txtCreditAmount.Text = x.ToString("0.00");
            }
            else
            {
                txtCreditAmount.Text = "0.00";
                //MessageBox.Show("Data invalid!");
                //txtVenderOpeningBal.Focus();
            }
        }

        private void txtChequeAmount_Leave(object sender, EventArgs e)
        {
           if (txtCreditAmount.Text == "0.00")
            {
                credittext1();
            }
           if (txtCreditAmount.Text != "0.00")
           {
               credittext();
               decimal x;
               if (decimal.TryParse(txtChequeAmount.Text, out x))
               {
                   if (txtChequeAmount.Text.IndexOf('.') != -1 && txtChequeAmount.Text.Split('.')[1].Length > 2)
                   {
                       MessageBox.Show("The maximum decimal points are 2!");
                       txtChequeAmount.Focus();
                   }
                   else txtChequeAmount.Text = x.ToString("0.00");
               }
               else
               {
                   txtChequeAmount.Text = "0.00";
                   //MessageBox.Show("Data invalid!");
                   //txtVenderOpeningBal.Focus();
               }
           }
            
        }

        private void txtEwalletAmount_Leave(object sender, EventArgs e)
        {
            if (txtEwalletAmount.Text == "0.00")
            {
                Ewalled1();
            }
            else
            {
                Ewalled();
            }
            decimal x;
            if (decimal.TryParse(txtChequeAmount.Text, out x))
            {
                if (txtChequeAmount.Text.IndexOf('.') != -1 && txtChequeAmount.Text.Split('.')[1].Length > 2)
                {
                    MessageBox.Show("The maximum decimal points are 2!");
                    txtChequeAmount.Focus();
                }
                else txtChequeAmount.Text = x.ToString("0.00");
            }
            else
            {
                txtChequeAmount.Text = "0.00";
                //MessageBox.Show("Data invalid!");
                //txtVenderOpeningBal.Focus();
            }
           
         }

        private void txtCouponAmount_Leave(object sender, EventArgs e)
        {
            if (txtCouponAmount.Text == "0.00")
            {
                //CmbCompany.Visible = false;
               // label23.Visible = false;
            }
            else
            {
                //CmbCompany.Visible = true;
                //label23.Visible = true;
            }
            decimal x;
            if (decimal.TryParse(txtCouponAmount.Text, out x))
            {
                if (txtCouponAmount.Text.IndexOf('.') != -1 && txtCouponAmount.Text.Split('.')[1].Length > 2)
                {
                    MessageBox.Show("The maximum decimal points are 2!");
                    txtCouponAmount.Focus();
                }
                else txtCouponAmount.Text = x.ToString("0.00");
            }
            else
            {
                txtCouponAmount.Text = "0.00";
                //MessageBox.Show("Data invalid!");
                //txtVenderOpeningBal.Focus();
            }
           
           
        }

        private void txtTotalAmount1_TextChanged(object sender, EventArgs e)
        {
            txtNetAmount.Text = txtTotalAmount1.Text;
            Double Amount = Convert.ToDouble(txtTotalAmount1.Text);
            Double Amount1 = Convert.ToDouble(txtInvoiceAmount.Text);
            Double Amount2 = Amount1 - Amount;
            string Amount3 = Amount2.ToString();
            txtBalance.Text = Amount2.ToString("##0.00");
        }

        private void CashAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CashAmount.Text == "")
            {
                txttotalAmount.Text = "0.00";
               // txtBalance.Text = "0.00";
            }
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //if (CashAmount.Text.IndexOf('.') != -1 && CashAmount.Text.Split('.')[1].Length == 2)
                //{
                    //MessageBox.Show("The maximum decimal points are 2!");
                e.Handled = false;
                //}
            }
            else
            {
                if (e.KeyChar == '\b')
                {

                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtCreditAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtCreditAmount.Text == "0.00" && txtCreditAmount.Text =="")
            {
                credittext1();
                txtTotalAmount1.Text = "0.00";
            }
            if (txtCreditAmount.Text != "0.00")
            {
                credittext();
                string amount = txtCreditAmount.Text ;
                 double amount1 = 0.0;
                 if (double.TryParse(amount, out amount1))
                 {
                     txtCreditAmount.Text = amount;
                     Double Amount = Convert.ToDouble(txtCreditAmount.Text);
                     Double Amount1 = Convert.ToDouble(CashAmount.Text);
                     Double amount2 = Amount + Amount1;
                     //string Amount2 = amount2.ToString();
                     txtTotalAmount1.Text = amount2.ToString("##0.00");
                 }
               
            }
        }
        public void credittext()
        {
            txtCardNumber.ReadOnly = false;
            txtDebitBankName.ReadOnly = false;
            CmbCardType.Enabled = true;
            txtCardNumber.TabStop = true;
            txtDebitBankName.TabStop = true;
          }
        public void credittext1()
        {
            txtCardNumber.ReadOnly = true;
            txtDebitBankName.ReadOnly = true;
            CmbCardType.Enabled = false;
            txtCardNumber.TabStop = false;
            txtDebitBankName.TabStop = false;
        }
        private void txtChequeAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtChequeAmount.Text == "0.00")
            {
                chequetxt1();
            }
            if (txtChequeAmount.Text != "0.00")
            {
                chequetxt();
                string amount = txtChequeAmount.Text;
                 double amount1 = 0.0;
                 if (double.TryParse(amount, out amount1))
                 {
                     txtChequeAmount.Text = amount;
                     //txtNetAmount.Text = amount;
                     Double Amount = Convert.ToDouble(txtCreditAmount.Text);
                     Double Amount1 = Convert.ToDouble(CashAmount.Text);
                     Double Amount3 = Convert.ToDouble(txtChequeAmount.Text);
                     Double amount2 = Amount + Amount1 + Amount3;
                     //string Amount2 = amount2.ToString();
                     txtTotalAmount1.Text = amount2.ToString("##0.00");
                 }
            }

        }
        public void chequetxt()
        {
            txtChequeBankName.ReadOnly = false;
            txtChequeNumber.ReadOnly = false;
            dataGridView1.Enabled = false;
            txtChequeBankName.TabStop = false;
            txtChequeNumber.TabStop = false;
          
        }
        public void chequetxt1()
        {
            txtChequeBankName.ReadOnly = true;
            txtChequeNumber.ReadOnly = true;
            dataGridView1.Enabled = true;
            txtChequeBankName.TabStop = true;
            txtChequeNumber.TabStop = true;
        }
        private void txtCouponAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtCouponAmount.Text == "0.00")
            {
                CmbCompany.Enabled = true;
                //label23.Visible = false;
            }
            if (txtCouponAmount.Text != "0.00")
            {
                CmbCompany.Enabled = false;
                //label23.Visible = true;
                string amount = txtCouponAmount.Text;
                //txtCouponAmount.Text = amount;
                 double amount1 = 0.0;
                 if (double.TryParse(amount, out amount1))
                 {
                     Double Amount = Convert.ToDouble(txtCreditAmount.Text);
                     Double Amount1 = Convert.ToDouble(CashAmount.Text);
                     Double Amount3 = Convert.ToDouble(txtChequeAmount.Text);
                     Double Amount4 = Convert.ToDouble(txtEwalletAmount.Text);
                     Double Amount5 = Convert.ToDouble(txtCouponAmount.Text);
                     Double amount2 = Amount + Amount1 + Amount3 + Amount4 + Amount5;
                     string Amount2 = amount2.ToString();
                     txtTotalAmount1.Text = amount2.ToString("##0.00");
                 }
            }
        }

        private void txtEwalletAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtEwalletAmount.Text == "")
            {
                Ewalled1();
            }
           else if (txtEwalletAmount.Text != "0")
            {
                Ewalled();
                string amount = txtEwalletAmount.Text ;
                double amount1 = 0.0;
                if (double.TryParse(amount, out amount1))
                {
                    txtEwalletAmount.Text = amount;
                    Double Amount = Convert.ToDouble(txtCreditAmount.Text);
                    Double Amount1 = Convert.ToDouble(CashAmount.Text);
                    Double Amount3 = Convert.ToDouble(txtChequeAmount.Text);
                    Double Amount4 = Convert.ToDouble(txtEwalletAmount.Text);
                    Double amount2 = Amount + Amount1 + Amount3 + Amount4;
                    string Amount2 = amount2.ToString();
                    txtTotalAmount1.Text = Amount2;
                }
            }

        }
        public void Ewalled()
        {
            txtTransactionNumber.ReadOnly = false;
            EWalletCompanyName.ReadOnly = false;
            dataGridView2.Enabled = false;
            txtTransactionNumber.TabStop = false;
            EWalletCompanyName.TabStop= false;

        }
        public void Ewalled1()
        {

            txtTransactionNumber.ReadOnly = true;
            EWalletCompanyName.ReadOnly = true;
            dataGridView2.Enabled = true;
            txtTransactionNumber.TabStop = false;
            EWalletCompanyName.TabStop = false;
        }
        private void BlankPaymentPage()
        {
            CashAmount.Text = "0.00";
            txtCreditAmount.Text = "0.00";
            txtDebitBankName.Text = "";
            txtCardNumber.Text = "";
            CmbCardType.SelectedIndex = 0;
            txtChequeAmount.Text = "0.00";
            txtChequeBankName.Text = "";
            txtChequeNumber.Text = "";
            txtWAmount.Text = "0.00";
            txtEwalletAmount.Text = "0.00";
            EWalletCompanyName.Text = "";
            txtTransactionNumber.Text = "";
            txtCouponAmount.Text = "0.00";
            CmbCompany.SelectedIndex = 0;
            txtTotalAmount1.Text = "0.00";
            txtBalance.Text = "0.00";
            txtRturned.Text = "0.00";
            txtNetAmount.Text = "0.00";
            
            
        }

        private void txtCreditAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //if (txtCreditAmount.Text.IndexOf('.') != -1 && txtCreditAmount.Text.Split('.')[1].Length == 2)
                //{
                //    //MessageBox.Show("The maximum decimal points are 2!");
                e.Handled = false;
                //}
            }
            else
            {
                if (e.KeyChar == '\b')
                {

                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtRturned_TextChanged(object sender, EventArgs e)
        {
            if (txtBalance.Text == "")
            {
                txtBalance.Text = "0";
            }
            if (txtRturned.Text == "")
            {
                txtRturned.Text = "0";
            }
            string sub = txtBalance.Text;
            string return1 = txtRturned.Text;
             double amount1 = 0.0;
             if (double.TryParse(sub, out amount1))
             {
                 double bal = Convert.ToDouble(txtBalance.Text);
                 if (double.TryParse(return1, out amount1))
                 {
                     double ReturnAmount = Convert.ToDouble(txtRturned.Text);
                     double bal1 = bal + ReturnAmount;
                     txtBalance.Text = bal1.ToString();
                 }
             }

        }
        private void txtRturned_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))

            {
                //if (txtRturned.Text.IndexOf('.') != -1 && txtRturned.Text.Split('.')[1].Length == 2)
                //{
                //    //MessageBox.Show("The maximum decimal points are 2!");
                //    e.Handled = true;
                //}
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    txtBalance.Text = "0";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtDiscount_MouseClick(object sender, MouseEventArgs e)
        {
            if(txtDiscount.Text=="0.00")
            {
              txtDiscount.Text = "";
            }
           else if (txtDiscount.Text != "0.00")
            {
            }
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "")
            {
                txtDiscount.Text = "0.00";
            }
            Double totaldicount =Convert.ToDouble( txtDiscount.Text);
            txtDiscount.Text = totaldicount.ToString("###0.00");
        }

        private void txtInvoiceid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtChequeAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //if (txtChequeAmount.Text.IndexOf('.') != -1 && txtChequeAmount.Text.Split('.')[1].Length == 2)
                //{
                //    //MessageBox.Show("The maximum decimal points are 2!");
                e.Handled = false;
                //}
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    txtBalance.Text = "0";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtEwalletAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //if (txtEwalletAmount.Text.IndexOf('.') != -1 && txtEwalletAmount.Text.Split('.')[1].Length == 2)
                //{
                //    //MessageBox.Show("The maximum decimal points are 2!");
                e.Handled = false;
                //}
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    txtBalance.Text = "0";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtCouponAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
            //    if (txtCouponAmount.Text.IndexOf('.') != -1 && txtCouponAmount.Text.Split('.')[1].Length == 2)
            //    {
            //        //MessageBox.Show("The maximum decimal points are 2!");
                e.Handled = false;
                //}
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    txtBalance.Text = "0";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txttotalAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //if (txttotalAmount.Text.IndexOf('.') != -1 && txttotalAmount.Text.Split('.')[1].Length == 2)
                //{
                //    //MessageBox.Show("The maximum decimal points are 2!");
                e.Handled = false;
                //}
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    txtBalance.Text = "0";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtWAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //if (txtWAmount.Text.IndexOf('.') != -1 && txtWAmount.Text.Split('.')[1].Length == 2)
                //{
                //    //MessageBox.Show("The maximum decimal points are 2!");
                e.Handled = false;
                //}
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    txtBalance.Text = "0";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtDisAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //if (txtDisAmount.Text.IndexOf('.') != -1 && txtDisAmount.Text.Split('.')[1].Length == 2)
                //{
                    //MessageBox.Show("The maximum decimal points are 2!");
                e.Handled = false;
                //}
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    txtBalance.Text = "0";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtTaxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //if (txtTaxAmount.Text.IndexOf('.') != -1 && txtTaxAmount.Text.Split('.')[1].Length == 2)
                //{
                //    //MessageBox.Show("The maximum decimal points are 2!");
                e.Handled = false;
                //}
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    txtBalance.Text = "0";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //if (txtBalance.Text.IndexOf('.') != -1 && txtBalance.Text.Split('.')[1].Length == 2)
                //{
                    //MessageBox.Show("The maximum decimal points are 2!");
                e.Handled = false;
                //}
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    txtBalance.Text = "0";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

       

       

       

       
    }

}
