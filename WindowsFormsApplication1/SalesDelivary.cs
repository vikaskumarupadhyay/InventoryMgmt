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
    public partial class salesdelivary : Form
    {
        List<string> ls = new List<string>();
        int h;
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
        private void tab()
        {
            txtcustomercode.Focus();
            txtcustomercode.TabStop = true;
            butcustomercode.TabStop = true;
            gridsalesdelivary.TabStop = false;
            txtItemCode.TabStop = false;
            butitembutton.TabStop = false;
            txtQuantity.TabStop = false;
            butAddItem.TabStop = false;
            butRemoveItem.TabStop = false;
            butSaveButton.TabStop = false;
            butClose.TabStop = false;
            ButSelectPurchaseOrder.TabStop = false;
            textBox1.TabStop = false;
            txttax.TabStop = false;
            textBox3.TabStop = false;
            
        }
        private void tab1()
        {
            txtItemCode.Focus();
            txtItemCode.TabStop = true;
            butitembutton.TabStop = true;
            txtItemCode.TabStop = true;
            butitembutton.TabStop = true;
        }
        private void tab2()
        {
            txtQuantity.Focus();
            txtcustomercode.TabStop = true;
            butcustomercode.TabStop = true;
            txtItemCode.TabStop = true;
            butitembutton.TabStop = true;
            txtQuantity.TabStop = false;
            butAddItem.TabStop = true;
            butRemoveItem.TabStop = true;
            butSaveButton.TabStop = true;
            butClose.TabStop = true;
            gridsalesdelivary.TabStop = false;
            ButSelectPurchaseOrder.TabStop = true;
            textBox1.TabStop = false;
            txttax.TabStop = false;
            textBox3.TabStop = false;
        }
        private void tab7()
        {
            txtQuantity.Focus();
            txtcustomercode.TabStop = true;
            butcustomercode.TabStop = true;
            txtItemCode.TabStop = true;
            butitembutton.TabStop = true;
           // txtQuantity.TabStop = false;
            butAddItem.TabStop = false;
            butRemoveItem.TabStop = true;
            butSaveButton.TabStop = false;
            butClose.TabStop = false;
            gridsalesdelivary.TabStop = false;
            ButSelectPurchaseOrder.TabStop = false;
            textBox1.TabStop = false;
            txttax.TabStop = false;
            textBox3.TabStop = false;
        }
        //private void tabindex()
        //{
        //    butcustomercode.TabStop = true;
        //    txtItemCode.TabStop = true;
        //    butitembutton.TabStop = true;
        //    txtQuantity.TabStop = true;
        //    butAddItem.TabStop = true;
        //    butRemoveItem.TabStop = true;
        //    butSaveButton.TabStop = true;
        //    ButSelectPurchaseOrder.TabStop = true;
        //    butClose.TabStop = true;


        //}
        //private void tab2()
        //{
        //    txtItemCode.Focus();
        //    txtItemCode.TabStop = true;
        //    butitembutton.TabStop = true;
        //    txtQuantity.TabStop = true;
        //    butAddItem.TabStop = true;
        //}
        //private void tab3()
        //{
        //    txtItemCode.Focus();
        //    txtItemCode.TabStop = true;
        //    butitembutton.TabStop = true;
        //   // txtQuantity.TabStop = false;

        //}
        private void butcustomercode_Click(object sender, EventArgs e)
        {
            crystalReportViewer2.Visible = false;
            //string selectquery1 = "select CustName,CustCompName,CustAddress,CustPhone,Custmobile,CustFax from CustomerDetails";
            //string actualcolumn = "select CustName ,CustCompName ,CustAddress ,CustPhone ,Custmobile ,CustFax  from CustomerDetails";
            string selectquery1 = "select  Custd.CustId as [Customer ID] ,CustName AS Name ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustDesc AS Description,Custad.CustOpeningBalance AS [Opening Balance] , Custad.CustCurrentBalance AS [Current Ballance],CustPanNo AS [PAN NO], CustVatNo AS [VAT NO],CustCSTNo AS [CST NO]  ,CustServicetaxRegnNo AS [Service Tax Regn. No],CustExciseRegnNo AS [Excise Regn. No] ,GSTRegnNo AS [GST Regn. No] from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID ";
            string actualcolumn = "select  Custd.CustId  ,CustName  ,CustCompName  ,CustAddress ,CustCity , CustState  ,CustZip  ,CustCountry  ,CustEmail , CustWebAddress ,CustPhone  ,CustMobile  ,CustFax ,CustDesc ,Custad.CustOpeningBalance , Custad.CustCurrentBalance ,CustPanNo , CustVatNo ,CustCSTNo  ,CustServicetaxRegnNo ,CustExciseRegnNo  ,GSTRegnNo  from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID ";
            DataTable dt1 = d.getDetailByQuery(selectquery1);
            DataTable onlycolumn = d.getDetailByQuery(actualcolumn);
            DataTable custometable = new DataTable();
            custometable.Columns.Add("actualcolumnname");
            custometable.Columns.Add("aliascolumnname");
            DataColumnCollection c = dt1.Columns;
            DataColumnCollection columnofname = onlycolumn.Columns;
            for (int a = 1; a < c.Count; a++)
            {
                string s = c[a].ToString();
                string actualcolumnname = columnofname[a].ToString();
                DataRow dr = custometable.NewRow();
                dr["actualcolumnname"] = actualcolumnname;
                dr["aliascolumnname"] = s;
                custometable.Rows.Add(dr);
            }
            comsearchvalue.DataSource = custometable;
            comsearchvalue.ValueMember = "actualcolumnname";
            comsearchvalue.DisplayMember = "aliascolumnname";

            counter = 0;
            panel2.Visible = true;
           // string selectquery = "select Custid, CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from customerdetails";
            string selectquery = "select  Custd.CustId as [Customer ID] ,CustName AS Name ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustDesc AS Description,Custad.CustOpeningBalance AS [Opening Balance] , Custad.CustCurrentBalance AS [Current Ballance],CustPanNo AS [PAN NO], CustVatNo AS [VAT NO],CustCSTNo AS [CST NO]  ,CustServicetaxRegnNo AS [Service Tax Regn. No],CustExciseRegnNo AS [Excise Regn. No] ,GSTRegnNo AS [GST Regn. No] from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID ";
            
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView2.DataSource = dt;
            txtQuantity.TabStop = false;
            txtcustomercode.TabStop = false;
            butcustomercode.TabStop = false;
            comsearchvalue.Focus();
            comsearchvalue.TabIndex = 1;
            txtsearchvalue.TabIndex = 2;
            dataGridView2.TabIndex = 3;
            button1.TabIndex = 4;

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
            txtRate.Text = cell1[6].Value.ToString();
           // maxquantity = Convert.ToInt32((cell1[3].Value.ToString()));
            txtQuantity.Text = "";
            txtAmmount.Text = "";

        }


        private void butitembutton_Click(object sender, EventArgs e)
        {
            crystalReportViewer2.Visible = false;
            string selectquery1 = "select  itm.ItemId as [Item Id],itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],ipd.SalesPrice as[Sales Price],ipd.MrpPrice as[Mrp Price] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId";
            string actualcolumn = "select top 1  itm.ItemId, itm.ItemName,itm.ItemCompName ,itm.ItemDesc ,ig.groupName,iul.unitName ,ipd.purChasePrice ,ipd.SalesPrice ,ipd.MrpPrice ,ipd.Margin ,iqd.OpeningQuantity ,iqd.CurrentQuantity from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId";
           
            //string selectquery1 = "select it.ItemName,ip.Mrpprice,iq.CurrentQuantity from ItemDetails it join ItemPriceDetail ip on it.Itemid=ip.Itemid join ItemQuantityDetail iq on ip.ItemId=iq.Itemid";
           // string actualcolumn = "select it.ItemName ,ip.Mrpprice ,iq.CurrentQuantity  from ItemDetails it join ItemPriceDetail ip on it.Itemid=ip.Itemid join ItemQuantityDetail iq on ip.ItemId=iq.Itemid";
            DataTable dt1 = d.getDetailByQuery(selectquery1);
            DataTable onlycolumn = d.getDetailByQuery(actualcolumn);
            DataTable custometable = new DataTable();
            custometable.Columns.Add("actualcolumnname");
            custometable.Columns.Add("aliascolumnname");
            DataColumnCollection c = dt1.Columns;
            DataColumnCollection columnofname = onlycolumn.Columns;
            for (int a = 1; a < c.Count; a++)
            {
                string s = c[a].ToString();
                string actualcolumnname = columnofname[a].ToString();
                DataRow dr = custometable.NewRow();
                dr["actualcolumnname"] = actualcolumnname;
                dr["aliascolumnname"] = s;
                custometable.Rows.Add(dr);
            }
            comsearchvalue.DataSource = custometable;
            comsearchvalue.ValueMember = "actualcolumnname";
            comsearchvalue.DisplayMember = "aliascolumnname";


            counter = 1;
            panel2.Visible = true;
            string selectquery = "select  itm.ItemId as [Item Id],itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],ipd.purChasePrice as [Purchase Price],ipd.SalesPrice as[Sales Price],ipd.MrpPrice as[Mrp Price],ipd.Margin as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId";
            
           // string selectquery = "select i.Itemid,i.Itemname,ip.MrpPrice,iq.CurrentQuantity from itemdetails i join itempricedetail ip on i.itemid=ip.itemid join itemquantitydetail iq on ip.itemid=iq.itemid";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView2.DataSource = dt;
            txtQuantity.TabStop = false;
            txtcustomercode.TabStop = false;
            butcustomercode.TabStop = false;
            comsearchvalue.Focus();
            comsearchvalue.TabIndex = 1;
            txtsearchvalue.TabIndex = 2;
            dataGridView2.TabIndex = 3;
            button1.TabIndex = 4;
            txtsearchvalue.Text = "";
            
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
           
            string select = "select CurrentQuantity from ItemQuantityDetail where itemid='" + txtItemCode.Text + "'";
            DataTable dt = d.getDetailByQuery(select);
            string s = "";
            foreach (DataRow dr in dt.Rows)
            {
                s = dr[0].ToString();

            }
            if (txtQuantity.Text=="")
            {
                txtQuantity.Text ="0";
            }
            if (s != "")
            {
                int g = Convert.ToInt32(s);
                int quantity = Convert.ToInt32(txtQuantity.Text);
                if (quantity < g)
                {
                    //    MessageBox.Show("d");

                    // if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                    if ((!string.IsNullOrEmpty(txtQuantity.Text)) && char.IsDigit(txtQuantity.Text, txtQuantity.Text.Length - 1) && (!string.IsNullOrEmpty(txtRate.Text)))
                    {
                        //     txtQuantity.ReadOnly = false;
                        // int que = maxquantity;
                        quantity = Convert.ToInt32(txtQuantity.Text);
                        double rate = Convert.ToDouble(txtRate.Text);
                        txtAmmount.Text = (quantity * rate).ToString();
                    }
                }

                else if (quantity > g)
                {
                    MessageBox.Show("Quantity is not available");
                    txtQuantity.Text = "0";
                    txtAmmount.Text = "0";
                }
            }
            //if ((!string.IsNullOrEmpty(txtQuantity.Text)) && char.IsDigit(txtQuantity.Text, txtQuantity.Text.Length - 1) && (!string.IsNullOrEmpty(txtRate.Text)))
            //{
            //    string qurry1 = "select CurrentQuantity from ItemQuantityDetail ";
            //    DataTable dt1 = d.getDetailByQuery(qurry1);
            //    string id1 = " ";
            //    foreach (DataRow dr in dt1.Rows)
            //    {
            //        id1 = dr["CurrentQuantity"].ToString();
            //    }
            //    int que = 0;
            //    int quantity = Convert.ToInt32(txtQuantity.Text);
            //    int rate = Convert.ToInt32(txtRate.Text);
            //    que = quantity * rate;
            //    txtAmmount.Text = que.ToString();
            //    if (que < quantity)
            //    {
            //        txtQuantity.Text = "";
            //        txtAmmount.Text = "";
            //    }
            //}

        }

        private void butAddItem_Click(object sender, EventArgs e)
        {

            butRemoveItem.Enabled = true;
            txtItemCode.Focus();
            //txtQuantity.Enabled = false;
            if (txtRefNo.Text == "")
            {

                string itemid = "";
                string quntity = "";
                string rate = "";
                string prise = "";
                List<string> ls1 = new List<string>();
                foreach (DataRow dr3 in addToCartTable.Rows)
                {
                    int q3 = 0;
                    //itemid = dr3[0].ToString();
                    string itid = dr3[0].ToString();
                    if (ls.Contains(itid))
                    {
                        continue;
                    }
                    quntity = dr3[5].ToString();
                    rate = dr3[4].ToString();
                    prise = dr3[6].ToString();
                    if (txtItemCode.Text==itemid)
                    {
                        int q1 = Convert.ToInt32(quntity);
                        int q2 = Convert.ToInt32(txtQuantity.Text);
                        q3 = q1 + q2;
                        dr3[5] = q3.ToString();
                        //dr3[4] = q3.ToString();
                        Double rate1 = Convert.ToDouble(prise);
                        Double rate2 = Convert.ToDouble(txtAmmount.Text);
                        Double rate3 = rate1 + rate2;
                        dr3[6] = rate3.ToString();
                        Double rate4 = Convert.ToDouble(txtTotalAmmount.Text);
                        Double rate5 = rate4 + rate2;
                        txtTotalAmmount.Text = rate5.ToString();//rate3.ToString();
                        // MessageBox.Show("Please Enter the Quanity");
                        /* txtItemCode.Text = "I";
                         txtProductName.Text = "";
                         txtRate.Text = "";
                         txtQunty.Text = "";
                         txtAmount.Text = "";
                         //addToCartTable.Columns.Add("Qtuhjh");*/
                        ls1.Add(itemid);
                        
                    }
                }
                if (addToCartTable != null && addToCartTable.Rows != null && addToCartTable.Rows.Count > 0 && txtRefNo.Text=="")
                {
                    string itemid1 = "";
                    for (int c = 0; c < ls1.Count; c++)
                    {
                        itemid1 = ls1[c];
                    }
                    if (txtItemCode.Text==itemid1)
                    {
                        txtItemCode.Text = "I";
                        txtProductName.Text = "";
                        txtRate.Text = "";
                        txtQuantity.Text = "";
                        txtAmmount.Text= "";
                    }
                    else
                    {
                        string selectq = "select ids.ItemCompName,ipd.MrpPrice from ItemPriceDetail ipd join ItemDetails ids on ipd.ItemId=ids.ItemId where ipd.ItemId='" + txtItemCode.Text + "'";
                        DataTable dta = d.getDetailByQuery(selectq);
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
                        dr[5] = txtQuantity.Text.Trim();
                        dr[4] = txtRate.Text.Trim();
                        dr[6] = txtAmmount.Text.Trim();

                        //dr[5] = txtAmount.Text.Trim();
                        addToCartTable.Rows.Add(dr);
                        gridsalesdelivary.DataSource = addToCartTable;
                        double totalAmount = Convert.ToDouble(txtTotalAmmount.Text);
                        totalAmount += Convert.ToDouble(txtAmmount.Text);
                        txtTotalAmmount.Text = totalAmount.ToString();
                       // txtwithauttaxamount.Text = txtTotalAmmount.Text;

                        txtItemCode.Text = "I";
                        txtProductName.Text = "";
                        txtRate.Text = "";
                        txtQuantity.Text = "";
                        txtAmmount.Text = "";
                    }
                    // }
                    if (gridsalesdelivary.Rows.Count > 1)
                    {
                        txtdiccount.ReadOnly = false;
                    }

                }
                else
                {
                    string selectq = "select ids.ItemCompName,ipd.MrpPrice from ItemPriceDetail ipd join ItemDetails ids on ipd.ItemId=ids.ItemId where ipd.ItemId='" + txtItemCode.Text + "'";
                    DataTable dta = d.getDetailByQuery(selectq);
                    string ConpanyName = "";
                    string Mrp = "";
                    foreach (DataRow dr1 in dta.Rows)
                    {
                        ConpanyName = dr1[0].ToString();
                        Mrp = dr1[1].ToString();
                    }
                   // addToCartTable.Columns.RemoveAt(6);
                    DataRow dr = addToCartTable.NewRow();
                    dr[0] = txtItemCode.Text.Trim();
                    if (ls1.Contains(dr[0]))
                    {
                        
                    }
                    dr[1] = txtProductName.Text.Trim();
                    dr[2] = ConpanyName.Trim();
                    dr[3] = Mrp.Trim();
                    dr[5] = txtQuantity.Text.Trim();
                    dr[4] = txtRate.Text.Trim();
                    dr[6] = txtAmmount.Text.Trim();

                    //dr[5] = txtAmount.Text.Trim();
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
                    // txtQuantity.TabStop = false;
                    // txtQuantity.Enabled = false;
                    butAddItem.Enabled = false;
                }
                // }
                if (gridsalesdelivary.Rows.Count > 1)
                {
                    txtdiccount.ReadOnly = false;
                }
            }

           else if (txtRefNo.Text != "")
            {
                if (txtProductName.Text == "" && txtQuantity.Text == "")
                {
                    //MessageBox.Show("now CurrentQuantity of deadt");
                }
                else
                {
                    if (txtAmmount.Text == "")
                    {
                        MessageBox.Show("please Enter Quantity");
                    }
                    else
                    {
                        string selectq = "select ids.ItemCompName,ipd.MrpPrice from ItemPriceDetail ipd join ItemDetails ids on ipd.ItemId=ids.ItemId where ipd.ItemId='" + txtItemCode.Text + "'";
                        DataTable dta = d.getDetailByQuery(selectq);
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
                        dr[5] = txtQuantity.Text.Trim();
                        dr[6] = txtQuantity.Text.Trim();
                        dr[7] = txtAmmount.Text.Trim();
                        addToCartTable.Rows.Add(dr);

                        gridsalesdelivary.DataSource= addToCartTable;
                        double totalAmount = Convert.ToDouble(txtTotalAmmount.Text);
                        totalAmount += Convert.ToDouble(txtAmmount.Text.Trim());
                        txtTotalAmmount.Text = totalAmount.ToString();

                        txtItemCode.Text = "I";
                        txtProductName.Text = "";
                        txtRate.Text = "";
                        txtQuantity.Text = "";
                        txtAmmount.Text = "";
                        txtItemCode.Focus();
                      //  txtQuantity.TabStop= false;
                       // txtQuantity.Enabled = false;
                        butAddItem.Enabled = false;
                    }
                    if (gridsalesdelivary.Rows.Count > 1)
                    {
                        txtdiccount.ReadOnly = false;
                    }

               }
           }
           
        }


        private void salesdelivary_Load(object sender, EventArgs e)
        {
            txtdiccount.ReadOnly = true;
            //dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridsalesdelivary.DataSource = addToCartTable;
            txttaxamount.Visible = false;
            txtdicountamount.Visible = false;
            txtwithauttaxamount.Visible = true;
            
            txtTotalAmmount.Text = "0";
            txtwithauttaxamount.Text = "0";
           // txtdiccount.ReadOnly = false;
            txttaxamount.Text = "0";
            txtdicountamount.Text = "0";
            tab();
            txtQuantity.ReadOnly = true;
            butRemoveItem.Enabled = false;
            butAddItem.Enabled = false;
           // txtItemCode.Text = "I";
            dtpDate.Value = DateTime.Now;
           // txtcustomercode.Text = "C";
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
            string comQurry = "select TexId from CompnayDetails";
            DataTable dt2 = d.getDetailByQuery(comQurry);
            string taxtid = "";
            foreach (DataRow dr in dt2.Rows)
            {


                taxtid = dr[0].ToString();
            }
            string selectName = "select TexAmount,TexName from CompnayTex where TexId='" + taxtid + "'"; //TexName='" + DB_Main.taxName + "'";
            DataTable dt1 = d.getDetailByQuery(selectName);
            //textBox16.Text = DB_Main.taxName;
            foreach (DataRow dr in dt1.Rows)
            {
                //txtTexAmount.Text 

                txttax.Text = dr[0].ToString();
                textBox1.Text= dr[1].ToString();
            }

            if (txtRefNo.Text == "")
            {
                addToCartTable.Columns.RemoveAt(6);
               gridsalesdelivary.DataSource = addToCartTable;
            }
            //string select = "select VAT, CST,GST from CompnayDetails";
            //DataTable d1 = d.getDetailByQuery(select);
            //foreach (DataRow dr1 in d1.Rows)
            //{
            //    textBox2.Text = dr1[0].ToString();
            //    txtDiscount.Text = dr1[1].ToString();
            //    textBox20.Text = dr1[2].ToString();
            //}

        }
       

        private void butRemoveItem_Click(object sender, EventArgs e)
        {
            gridsalesdelivary.DefaultCellStyle.SelectionBackColor = Color.Red;
            butRemoveItem.Enabled = false;
            gridsalesdelivary.Focus();
            gridsalesdelivary.TabIndex = 1;
            txtItemCode.Enabled = false;
            butitembutton.Enabled = true;
            butSaveButton.TabStop = false;
            ButSelectPurchaseOrder.TabStop = false;
            butClose.TabStop = false;
            txtcustomercode.TabStop = true;
            butcustomercode.TabStop = true;
            //if (addToCartTable.Rows.Count > 0)
            //{
            //    string Amount = gridsalesdelivary.SelectedRows[0].Cells[4].Value.ToString();
            //    double totalAmount = Convert.ToDouble(txtTotalAmmount.Text);
            //    totalAmount -= Convert.ToDouble(Amount.Trim());
            //    txtTotalAmmount.Text = totalAmount.ToString();
            //    int index = gridsalesdelivary.SelectedRows[0].Index;
            //    addToCartTable.Rows.RemoveAt(index);

            //    gridsalesdelivary.DataSource = addToCartTable;
            //    if (addToCartTable.Rows.Count == 0)
            //    {
            //        txtTotalAmmount.Text = "0.0";
            //        txtDiscount.Text = "0.0";
            //    }
            //    if (gridsalesdelivary.Rows.Count > 0)
            //    {
            //        butRemoveItem.Enabled = true;
            //    }
            //    else
            //    {
            //        butRemoveItem.Enabled = false;
            //    }
            //}
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
            txtTotalAmmount.Text = "";
            addToCartTable.Clear();
            gridsalesdelivary.DataSource = "";
        }

        private void butSaveButton_Click(object sender, EventArgs e)
        {
              
            gridsalesdelivary.AllowUserToAddRows = false;

            if (txtRefNo.Text == "")
            {
                string s = "0";
                
                DataGridViewRowCollection call = gridsalesdelivary.Rows;
             
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
                    string quent = cellCollection1[6].Value.ToString();
                    string qurry = "select CurrentQuantity from ItemQuantityDetail where ItemId='" + itid + "'";
                    DataTable dt = d.getDetailByQuery(qurry);
                    string currid = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        currid = dr["CurrentQuantity"].ToString();
                    }
                    int quent1 = Convert.ToInt32(que.ToString());
                    // int curentQuntity = Convert.ToInt32(que);
                    int cuentQuantity = Convert.ToInt32(currid);
                    int lastQuantity =cuentQuantity-quent1;
                    // int resivquenty = lastQuantity ;
                    // string currid1 = resivquenty.ToString();
                    string updateQurry = "update ItemQuantityDetail set CurrentQuantity='" + lastQuantity + "'where ItemId='" + itid + "'";
                    int insertedRows2 = d.saveDetails(updateQurry);
                }
                

                string order = "select orderid from orderdetails ";
                DataTable d1 = d.getDetailByQuery(order);
                string id = "";
                string id5 = "";
                foreach (DataRow dr in d1.Rows)
                {
                    id = dr[0].ToString();
                }
                if (id == "")
                {
                    id = "1";
                    string insertquery = "insert into  orderdetails values('" + txtcustomercode.Text + "','" + dtpDate.Text + "','" + txtTotalAmmount.Text + "','" + txtdiccount.Text + "','" + txtdicountamount.Text+ "','" + txttax.Text + "','" + txttaxamount.Text + "','"+txtwithauttaxamount.Text+"')";
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
                            if (ls.Contains(txtitemcode))
                            {
                                continue;
                            }
                            // string txtProductName = cellcollection[1].Value.ToString();
                            string txtRate = cellcollection[2].Value.ToString();
                            string txtQuantity = cellcollection[4].Value.ToString();
                            string txtAmount = cellcollection[5].Value.ToString();
                            string Orderid = id;
                            //string updatequery = "update orderdetails set totalammount='" + txtTotalAmmount.Text + "' where orderid='" + Orderid + "' ";
                            //int update = d.saveDetails(updatequery);
                            string query = "insert into customerorderdescriptions Values('" + Orderid + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";


                            // int insertrow = d.saveDetails(query);
                            show.Add(query);
                        }

                        int inserirow1 = d.saveDetails(show);
                        if (inserirow1 > 0)
                        {

                            if (id5 == "")
                            {
                                string deleteQurry = "delete customerorderdescriptions where Orderid='" + txtRefNo.Text + "'";
                                DataTable dt = d.getDetailByQuery(deleteQurry);
                                //dataGridView1.DataSource = "";


                                DataGridViewRowCollection RowCollection2 = gridsalesdelivary.Rows;
                                List<string> sf1 = new List<string>();
                                for (int a = 0; a < RowCollection2.Count; a++)
                                {

                                    DataGridViewRow currentRow = RowCollection2[a];
                                    DataGridViewCellCollection cellCollection = currentRow.Cells;
                                    string txtItemCode = cellCollection[0].Value.ToString();
                                    if (ls.Contains(txtItemCode))
                                    {
                                        continue;
                                    }
                                    string txtRate = cellCollection[2].Value.ToString();
                                    string txtQuanity = cellCollection[4].Value.ToString();
                                    string txtAmoun = cellCollection[5].Value.ToString();
                                    string OrderID1 = id;
                                   // string updatequery = "update orderdetails set totalammount='" + txtTotalAmmount.Text + "',,'" + txtwithauttaxamount.Text + "','" + txtTotalAmmount.Text + "','" + txtdiccount.Text + "','" + txttax.Text + "','" + txtdicountamount.Text + "','" + txttaxamount.Text + "' where orderid='" + OrderID1 + "' ";
                                    //int update = d.saveDetails(updatequery);
                                    string Query = "insert into customerorderdescriptions Values('" + OrderID1 + "','" + txtItemCode + "','" + txtRate + "','" + txtQuanity + "','" + txtAmoun + "','"+s+"')";
                                    //MessageBox.Show(Query);

                                    sf1.Add(Query);

                                }
                                int insertedRows4 = d.saveDetails(sf1);
                                if (insertedRows4 > 0)
                                {
                                    gridsalesdelivary.AllowUserToAddRows = true;
                                    string salesdelivary = "Insert into salesOrderDelivery values('" + id + "','true','" + dtpDate.Text + "','"+s+"')";
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
                    }
                }
                
            
            
                else
                {
                    int id1 = Convert.ToInt32(id);
                    int id2 = id1 + 1;
                    string Orde = id2.ToString();
                    string insertquery1 = "insert into  orderdetails values('" + txtcustomercode.Text + "','" + dtpDate.Text + "','" + txtTotalAmmount.Text + "','" + txtdiccount.Text + "','" + txtdicountamount.Text + "','" + txttax.Text + "','" + txttaxamount.Text + "','"+txtwithauttaxamount.Text+"')";
                    int insertrows1 = d.saveDetails(insertquery1);
                    if (insertrows1 > 0)
                    {

                        DataGridViewRowCollection rowcollection = gridsalesdelivary.Rows;
                        List<string> show = new List<string>();
                        for (int a = 0; a < rowcollection.Count; a++)
                        {
                            DataGridViewRow currentrow = rowcollection[a];
                            DataGridViewCellCollection cellcollection = currentrow.Cells;
                            string txtitemcode = cellcollection[0].Value.ToString();
                            if (ls.Contains(txtitemcode))
                            {
                                continue;
                            }
                            //string txtProductName = cellcollection[1].Value.ToString();
                            //string compnayname = cellcollection[2].Value.ToString();
                            //string mrp = cellcollection[3].Value.ToString();
                            string txtRate = cellcollection[4].Value.ToString();
                            string txtQuantity = cellcollection[5].Value.ToString();
                            string txtAmount = cellcollection[6].Value.ToString();
                            //string orderid = txtSrNo.Text;
                            // string updatequery = "update orderdetails set totalammount='" + txtTotalAmmount.Text + "' where orderid='" + txtRefNo.Text + "' ";
                            // int update = d.saveDetails(updatequery);
                            string query = "insert into customerorderdescriptions Values('" + Orde + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";

                            //int insertrow = d.saveDetails(query);

                            show.Add(query);
                        }

                        int inserirow1 = d.saveDetails(show);
                        if (inserirow1 > 0)
                        {

                            if (id5 == "")
                            {
                                string deleteQurry = "delete customerorderdescriptions where Orderid='" + txtRefNo.Text + "'";
                                DataTable dt = d.getDetailByQuery(deleteQurry);
                                //dataGridView1.DataSource = "";


                                DataGridViewRowCollection RowCollection2 = gridsalesdelivary.Rows;
                                List<string> sf1 = new List<string>();
                                for (int a = 0; a < RowCollection2.Count; a++)
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
                                    string OrderID1 = id;
                                   // string updatequery = "insert into orderdetails Values('"+txtcustomercode.Text+"','"+dtpDate.Text+"','" + txtTotalAmmount.Text + "','"+txtdiccount.Text+"','"+txtdicountamount.Text+"','"+txttax.Text+"','"+txttaxamount.Text+"','" + txtwithauttaxamount.Text + "')";
                                   // int update = d.saveDetails(updatequery);
                                    string Query = "insert into customerorderdescriptions Values('" + OrderID1 + "','" + txtItemCode + "','" + txtRate + "','" + txtQuanity + "','" + txtAmoun + "')";
                                    //MessageBox.Show(Query);

                                    sf1.Add(Query);

                                }
                                int insertedRows4 = d.saveDetails(sf1);
                                if (insertedRows4 > 0)
                                {
                                    string salesdelivary = "Insert into salesOrderDelivery values('" + Orde + "','true','" + dtpDate.Text + "','"+s+"')";
                                    int insert = d.saveDetails(salesdelivary);
                                    if (insert > 0)
                                    {
                                        MessageBox.Show("details save successfully");
                                        panel2.Visible = true;
                                        DialogResult result = MessageBox.Show("this page is print", "Impotant questiuon", MessageBoxButtons.YesNo);
                                        if (result == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            crystalReportViewer2.Visible = true;
                                            gridsalesdelivary.AllowUserToAddRows = false;
                                            string a = "Data Source=DINESHTIWARI-PC\\SQLEXPRESS;Initial Catalog=SalesMaster;Integrated Security=True";
                                            SqlConnection con = new SqlConnection(a);
                                            con.Open();
                                            string selectquery = "select * from salesorderdelivaryreport where Delivaryid='" + txtSrNo.Text + "'";
                                            SqlCommand cmd = new SqlCommand(selectquery, con);
                                            SqlDataAdapter sd = new SqlDataAdapter(cmd);
                                            DataSet1 ds = new DataSet1();
                                            sd.Fill(ds, "compnaydetails");

                                            //CrystalReport1 cr = new CrystalReport1();
                                            // cr.ParameterFields.Add(textBox1.Text);
                                            // cr.Load("C:\\Users\\dineshtiwari\\Documents\\Visual Studio 2010\\Projects\\report11\\report11\\CrystalReport1.rpt");

                                            CrystalReportsalesdelivary report1 = new CrystalReportsalesdelivary();
                                            report1.SetDataSource(ds.Tables[1]);

                                            crystalReportViewer2.ReportSource = report1;
                                            crystalReportViewer2.Refresh();
                                            con.Close();
                                        }
                                        if (result == System.Windows.Forms.DialogResult.No)
                                        {
                                            crystalReportViewer2.Visible = false;
                                            panel2.Visible = false;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("details save not successfully");


                                    }
                                }

                            }
                        }
                    }
                }
            

                    makeblank();

                
                }


                if (txtRefNo.Text != "")
                {
                    DataGridViewRowCollection cal = gridsalesdelivary.Rows;
                    for (int c = 0; c < cal.Count; c++)
                    {
                        DataGridViewRow currentRow1 = cal[c];
                        DataGridViewCellCollection cellCollection1 = currentRow1.Cells;
                        string itid = cellCollection1[0].Value.ToString();
                        if (ls.Contains(itid))
                        {
                            continue;
                        }
                        string que = cellCollection1[5].Value.ToString();
                        string quent = cellCollection1[6].Value.ToString();



                        string qurry = "select CurrentQuantity from ItemQuantityDetail where ItemId='" + itid + "'";
                        DataTable dt = d.getDetailByQuery(qurry);
                        string currid = "";
                        foreach (DataRow dr in dt.Rows)
                        {
                            currid = dr["CurrentQuantity"].ToString();
                        }
                        int quent1 = Convert.ToInt32(quent);
                        // int curentQuntity = Convert.ToInt32(que);
                        int cuentQuantity = Convert.ToInt32(currid);
                        int lastQuantity = cuentQuantity - quent1;
                        // int resivquenty = lastQuantity ;
                        // string currid1 = resivquenty.ToString();
                        string updateQurry = "update ItemQuantityDetail set CurrentQuantity='" + lastQuantity + "'where ItemId='" + itid + "'";
                        int insertedRows2 = d.saveDetails(updateQurry);
                    }
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
                            if (ls.Contains(txtitemcode))
                            {
                                continue;
                            }
                            // string txtproductname = cellcollection[1].Value.ToString();
                            string txtRate = cellcollection[4].Value.ToString();
                            string txtQuantity = cellcollection[6].Value.ToString();
                            string txtAmount = cellcollection[7].Value.ToString();
                            string Orderid = txtRefNo.Text;
                            //string updatequery = "update orderdetails set totalammount='" + txtTotalAmmount.Text + "','" + txtwithauttaxamount.Text + "','" + txtTotalAmmount.Text + "','" + txtdiccount.Text + "','" + txttax.Text + "','" + txtdicountamount.Text + "','" + txttaxamount.Text + "' where orderid='" + Orderid + "' ";
                            //int update = d.saveDetails(updateque7ry);
                            string query = "insert into customerorderdescriptions Values('" + Orderid + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";

                            show.Add(query);
                        }

                        int inserirow1 = d.saveDetails(show);
                        if (inserirow1 > 0)
                        {
                            string insertquery2 = "insert into salesOrderDelivery values('" + txtRefNo.Text + "','true','" + dtpDate.Text + "','"+txtRefNo.Text+"')";
                            int insert = d.saveDetails(insertquery2);

                            string insertquery1 = "update orderdetails set Discount='" + txtdiccount.Text + "',Discountamount='" + txtdicountamount.Text + "',Tax='" + txttax.Text + "',Taxamount='" + txttaxamount.Text + "',WithautTaxamount='"+txtwithauttaxamount.Text+"' where orderid='" + txtRefNo.Text + "'";
                            int insertrows1 = d.saveDetails(insertquery1);

                            if (insert > 0)
                            {
                                panel2.Visible = true;
                                DialogResult result = MessageBox.Show("this page is print", "Impotant questiuon", MessageBoxButtons.YesNo);
                                if (result == System.Windows.Forms.DialogResult.Yes)
                                {
                                    crystalReportViewer2.Visible = true;
                                    gridsalesdelivary.AllowUserToAddRows = false;
                                    string a = "Data Source=DINESHTIWARI-PC\\SQLEXPRESS;Initial Catalog=SalesMaster;Integrated Security=True";
                                    SqlConnection con = new SqlConnection(a);
                                    con.Open();
                                    string selectquery = "select * from salesorderdelivaryreport where Delivaryid='" + txtSrNo.Text + "'";
                                    SqlCommand cmd = new SqlCommand(selectquery, con);
                                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                                    DataSet1 ds = new DataSet1();
                                    sd.Fill(ds, "compnaydetails");

                                    //CrystalReport1 cr = new CrystalReport1();
                                    // cr.ParameterFields.Add(textBox1.Text);
                                    // cr.Load("C:\\Users\\dineshtiwari\\Documents\\Visual Studio 2010\\Projects\\report11\\report11\\CrystalReport1.rpt");

                                    CrystalReportsalesdelivary2 report1 = new CrystalReportsalesdelivary2();
                                    report1.SetDataSource(ds.Tables[1]);

                                    crystalReportViewer2.ReportSource = report1;
                                    crystalReportViewer2.Refresh();
                                    con.Close();
                                }
                                if (result == System.Windows.Forms.DialogResult.No)
                                {
                                    crystalReportViewer2.Visible = false;
                                    panel2.Visible = false;
                                }
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
        public void createnewsave()
        {
            gridsalesdelivary.AllowUserToAddRows = false;
            if (txtRefNo.Text == "")
            {
                string s = "0";
                DataGridViewRowCollection call = gridsalesdelivary.Rows;
                for (int c = 0; c < call.Count; c++)
                {
                    DataGridViewRow currentRow1 = call[c];
                    DataGridViewCellCollection cellCollection1 = currentRow1.Cells;
                    string itid = cellCollection1[0].Value.ToString();
                    string que = cellCollection1[5].Value.ToString();
                    string quent = cellCollection1[6].Value.ToString();



                    string qurry = "select CurrentQuantity from ItemQuantityDetail where ItemId='" + itid + "'";
                    DataTable dt = d.getDetailByQuery(qurry);
                    string currid = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        currid = dr["CurrentQuantity"].ToString();
                    }
                    int quent1 = Convert.ToInt32(que.ToString());
                    // int curentQuntity = Convert.ToInt32(que);
                    int cuentQuantity = Convert.ToInt32(currid);
                    int lastQuantity = cuentQuantity - quent1;
                    // int resivquenty = lastQuantity ;
                    // string currid1 = resivquenty.ToString();
                    string updateQurry = "update ItemQuantityDetail set CurrentQuantity='" + lastQuantity + "'where ItemId='" + itid + "'";
                    int insertedRows2 = d.saveDetails(updateQurry);
                }

                string order = "select orderid from orderdetails ";
                DataTable d1 = d.getDetailByQuery(order);
                string id = "";
                string id5 = "";
                foreach (DataRow dr in d1.Rows)
                {
                    id = dr[0].ToString();
                }
                if (id == "")
                {
                    id = "1";
                    string insertquery = "insert into  orderdetails values('" + txtcustomercode.Text + "','" + dtpDate.Text + "','" + txtTotalAmmount.Text + "','" + txtdiccount.Text + "','" + txtdicountamount.Text + "','" + txttax.Text + "','" + txttaxamount.Text + "','" + txtwithauttaxamount.Text + "')";
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
                            // string txtProductName = cellcollection[1].Value.ToString();
                            string txtRate = cellcollection[2].Value.ToString();
                            string txtQuantity = cellcollection[4].Value.ToString();
                            string txtAmount = cellcollection[5].Value.ToString();
                            string Orderid = id;
                            //string updatequery = "update orderdetails set totalammount='" + txtTotalAmmount.Text + "' where orderid='" + Orderid + "' ";
                            //int update = d.saveDetails(updatequery);
                            string query = "insert into customerorderdescriptions Values('" + Orderid + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";


                            // int insertrow = d.saveDetails(query);
                            show.Add(query);
                        }

                        int inserirow1 = d.saveDetails(show);
                        if (inserirow1 > 0)
                        {

                            if (id5 == "")
                            {
                                string deleteQurry = "delete customerorderdescriptions where Orderid='" + txtRefNo.Text + "'";
                                DataTable dt = d.getDetailByQuery(deleteQurry);
                                //dataGridView1.DataSource = "";


                                DataGridViewRowCollection RowCollection2 = gridsalesdelivary.Rows;
                                List<string> sf1 = new List<string>();
                                for (int a = 0; a < RowCollection2.Count; a++)
                                {

                                    DataGridViewRow currentRow = RowCollection2[a];
                                    DataGridViewCellCollection cellCollection = currentRow.Cells;
                                    string txtItemCode = cellCollection[0].Value.ToString();
                                    string txtRate = cellCollection[2].Value.ToString();
                                    string txtQuanity = cellCollection[4].Value.ToString();
                                    string txtAmoun = cellCollection[5].Value.ToString();
                                    string OrderID1 = id;
                                    // string updatequery = "update orderdetails set totalammount='" + txtTotalAmmount.Text + "',,'" + txtwithauttaxamount.Text + "','" + txtTotalAmmount.Text + "','" + txtdiccount.Text + "','" + txttax.Text + "','" + txtdicountamount.Text + "','" + txttaxamount.Text + "' where orderid='" + OrderID1 + "' ";
                                    //int update = d.saveDetails(updatequery);
                                    string Query = "insert into customerorderdescriptions Values('" + OrderID1 + "','" + txtItemCode + "','" + txtRate + "','" + txtQuanity + "','" + txtAmoun + "','" + s + "')";
                                    //MessageBox.Show(Query);

                                    sf1.Add(Query);

                                }
                                int insertedRows4 = d.saveDetails(sf1);
                                if (insertedRows4 > 0)
                                {
                                    gridsalesdelivary.AllowUserToAddRows = true;
                                    string salesdelivary = "Insert into salesOrderDelivery values('" + id + "','true','" + dtpDate.Text + "','" + s + "')";
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
                    }
                }


                else
                {
                    int id1 = Convert.ToInt32(id);
                    int id2 = id1 + 1;
                    string Orde = id2.ToString();
                    string insertquery1 = "insert into  orderdetails values('" + txtcustomercode.Text + "','" + dtpDate.Text + "','" + txtTotalAmmount.Text + "','" + txtdiccount.Text + "','" + txtdicountamount.Text + "','" + txttax.Text + "','" + txttaxamount.Text + "','" + txtwithauttaxamount.Text + "')";
                    int insertrows1 = d.saveDetails(insertquery1);
                    if (insertrows1 > 0)
                    {

                        DataGridViewRowCollection rowcollection = gridsalesdelivary.Rows;
                        List<string> show = new List<string>();
                        for (int a = 0; a < rowcollection.Count; a++)
                        {
                            DataGridViewRow currentrow = rowcollection[a];
                            DataGridViewCellCollection cellcollection = currentrow.Cells;
                            string txtitemcode = cellcollection[0].Value.ToString();
                            //string txtProductName = cellcollection[1].Value.ToString();
                            //string compnayname = cellcollection[2].Value.ToString();
                            //string mrp = cellcollection[3].Value.ToString();
                            string txtRate = cellcollection[4].Value.ToString();
                            string txtQuantity = cellcollection[5].Value.ToString();
                            string txtAmount = cellcollection[6].Value.ToString();
                            //string orderid = txtSrNo.Text;
                            // string updatequery = "update orderdetails set totalammount='" + txtTotalAmmount.Text + "' where orderid='" + txtRefNo.Text + "' ";
                            // int update = d.saveDetails(updatequery);
                            string query = "insert into customerorderdescriptions Values('" + Orde + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";

                            //int insertrow = d.saveDetails(query);

                            show.Add(query);
                        }

                        int inserirow1 = d.saveDetails(show);
                        if (inserirow1 > 0)
                        {

                            if (id5 == "")
                            {
                                string deleteQurry = "delete customerorderdescriptions where Orderid='" + txtRefNo.Text + "'";
                                DataTable dt = d.getDetailByQuery(deleteQurry);
                                //dataGridView1.DataSource = "";


                                DataGridViewRowCollection RowCollection2 = gridsalesdelivary.Rows;
                                List<string> sf1 = new List<string>();
                                for (int a = 0; a < RowCollection2.Count; a++)
                                {

                                    DataGridViewRow currentRow = RowCollection2[a];
                                    DataGridViewCellCollection cellCollection = currentRow.Cells;
                                    string txtItemCode = cellCollection[0].Value.ToString();
                                    string txtRate = cellCollection[4].Value.ToString();
                                    string txtQuanity = cellCollection[5].Value.ToString();
                                    string txtAmoun = cellCollection[6].Value.ToString();
                                    string OrderID1 = id;
                                    // string updatequery = "insert into orderdetails Values('"+txtcustomercode.Text+"','"+dtpDate.Text+"','" + txtTotalAmmount.Text + "','"+txtdiccount.Text+"','"+txtdicountamount.Text+"','"+txttax.Text+"','"+txttaxamount.Text+"','" + txtwithauttaxamount.Text + "')";
                                    // int update = d.saveDetails(updatequery);
                                    string Query = "insert into customerorderdescriptions Values('" + OrderID1 + "','" + txtItemCode + "','" + txtRate + "','" + txtQuanity + "','" + txtAmoun + "')";
                                    //MessageBox.Show(Query);

                                    sf1.Add(Query);

                                }
                                int insertedRows4 = d.saveDetails(sf1);
                                if (insertedRows4 > 0)
                                {
                                    string salesdelivary = "Insert into salesOrderDelivery values('" + Orde + "','true','" + dtpDate.Text + "','" + s + "')";
                                    int insert = d.saveDetails(salesdelivary);
                                    if (insert > 0)
                                    {
                                        MessageBox.Show("details save successfully");
                                        panel2.Visible = true;
                                        DialogResult result = MessageBox.Show("this page is print", "Impotant questiuon", MessageBoxButtons.YesNo);
                                        if (result == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            crystalReportViewer2.Visible = true;
                                            gridsalesdelivary.AllowUserToAddRows = false;
                                            string a = "Data Source=NITU;Initial Catalog=SalesMaster;Integrated Security=True";
                                            SqlConnection con = new SqlConnection(a);
                                            con.Open();
                                            string selectquery = "select * from salesorderdelivaryreport where Delivaryid='" + txtSrNo.Text + "'";
                                            SqlCommand cmd = new SqlCommand(selectquery, con);
                                            SqlDataAdapter sd = new SqlDataAdapter(cmd);
                                            DataSet1 ds = new DataSet1();
                                            sd.Fill(ds, "compnaydetails");

                                            //CrystalReport1 cr = new CrystalReport1();
                                            // cr.ParameterFields.Add(textBox1.Text);
                                            // cr.Load("C:\\Users\\dineshtiwari\\Documents\\Visual Studio 2010\\Projects\\report11\\report11\\CrystalReport1.rpt");

                                            CrystalReportsalesdelivary report1 = new CrystalReportsalesdelivary();
                                            report1.SetDataSource(ds.Tables[1]);

                                            crystalReportViewer2.ReportSource = report1;
                                            crystalReportViewer2.Refresh();
                                            con.Close();
                                        }
                                        if (result == System.Windows.Forms.DialogResult.No)
                                        {
                                            crystalReportViewer2.Visible = false;
                                            panel2.Visible = false;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("details save not successfully");


                                    }
                                }

                            }
                        }
                    }
                }


                makeblank();


            }


            if (txtRefNo.Text != "")
            {
                DataGridViewRowCollection cal = gridsalesdelivary.Rows;
                for (int c = 0; c < cal.Count; c++)
                {
                    DataGridViewRow currentRow1 = cal[c];
                    DataGridViewCellCollection cellCollection1 = currentRow1.Cells;
                    string itid = cellCollection1[0].Value.ToString();
                    string que = cellCollection1[5].Value.ToString();
                    string quent = cellCollection1[6].Value.ToString();



                    string qurry = "select CurrentQuantity from ItemQuantityDetail where ItemId='" + itid + "'";
                    DataTable dt = d.getDetailByQuery(qurry);
                    string currid = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        currid = dr["CurrentQuantity"].ToString();
                    }
                    int quent1 = Convert.ToInt32(quent);
                    // int curentQuntity = Convert.ToInt32(que);
                    int cuentQuantity = Convert.ToInt32(currid);
                    int lastQuantity = cuentQuantity - quent1;
                    // int resivquenty = lastQuantity ;
                    // string currid1 = resivquenty.ToString();
                    string updateQurry = "update ItemQuantityDetail set CurrentQuantity='" + lastQuantity + "'where ItemId='" + itid + "'";
                    int insertedRows2 = d.saveDetails(updateQurry);
                }
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
                        string txtRate = cellcollection[4].Value.ToString();
                        string txtQuantity = cellcollection[6].Value.ToString();
                        string txtAmount = cellcollection[7].Value.ToString();
                        string Orderid = txtRefNo.Text;
                        //string updatequery = "update orderdetails set totalammount='" + txtTotalAmmount.Text + "','" + txtwithauttaxamount.Text + "','" + txtTotalAmmount.Text + "','" + txtdiccount.Text + "','" + txttax.Text + "','" + txtdicountamount.Text + "','" + txttaxamount.Text + "' where orderid='" + Orderid + "' ";
                        //int update = d.saveDetails(updateque7ry);
                        string query = "insert into customerorderdescriptions Values('" + Orderid + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";

                        show.Add(query);
                    }

                    int inserirow1 = d.saveDetails(show);
                    if (inserirow1 > 0)
                    {
                        string insertquery2 = "insert into salesOrderDelivery values('" + txtRefNo.Text + "','true','" + dtpDate.Text + "','" + txtRefNo.Text + "')";
                        int insert = d.saveDetails(insertquery2);

                        string insertquery1 = "update orderdetails set Discount='" + txtdiccount.Text + "',Discountamount='" + txtdicountamount.Text + "',Tax='" + txttax.Text + "',Taxamount='" + txttaxamount.Text + "',WithautTaxamount='" + txtwithauttaxamount.Text + "' where orderid='" + txtRefNo.Text + "'";
                        int insertrows1 = d.saveDetails(insertquery1);

                        if (insert > 0)
                        {
                            panel2.Visible = true;
                            DialogResult result = MessageBox.Show("this page is print", "Impotant questiuon", MessageBoxButtons.YesNo);
                            if (result == System.Windows.Forms.DialogResult.Yes)
                            {
                                crystalReportViewer2.Visible = true;
                                gridsalesdelivary.AllowUserToAddRows = false;
                                string a = "Data Source=DINESHTIWARI-PC\\SQLEXPRESS;Initial Catalog=SalesMaster;Integrated Security=True";
                                SqlConnection con = new SqlConnection(a);
                                con.Open();
                                string selectquery = "select * from salesorderdelivaryreport where Delivaryid='" + txtSrNo.Text + "'";
                                SqlCommand cmd = new SqlCommand(selectquery, con);
                                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                                DataSet1 ds = new DataSet1();
                                sd.Fill(ds, "compnaydetails");

                                //CrystalReport1 cr = new CrystalReport1();
                                // cr.ParameterFields.Add(textBox1.Text);
                                // cr.Load("C:\\Users\\dineshtiwari\\Documents\\Visual Studio 2010\\Projects\\report11\\report11\\CrystalReport1.rpt");

                                CrystalReportsalesdelivary2 report1 = new CrystalReportsalesdelivary2();
                                report1.SetDataSource(ds.Tables[1]);

                                crystalReportViewer2.ReportSource = report1;
                                crystalReportViewer2.Refresh();
                                con.Close();
                            }
                            if (result == System.Windows.Forms.DialogResult.No)
                            {
                                crystalReportViewer2.Visible = false;
                                panel2.Visible = false;
                            }
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
            addToCartTable.Columns.Add(new DataColumn("CompnayName"));
            addToCartTable.Columns.Add(new DataColumn("MRP"));
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
            string selectquery = "select o.orderid, o.custid,o.date,o.totalammount,c.CustName,c.CustCompName from orderdetails o join CustomerDetails c on o.Custid=c.Custid";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView2.DataSource = dt;
            comsearchvalue.Focus();
            txtcustomercode.TabStop = false;
            butcustomercode.TabStop = false;
            
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                butAddItem.Focus();
            }

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
                    e.Handled = true;
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
                // string val = s;
                string selectQuery = "select  Custd.CustId as [Customer ID] ,CustName AS Name ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustDesc AS Description,Custad.CustOpeningBalance AS [Opening Balance] , Custad.CustCurrentBalance AS [Current Ballance],CustPanNo AS [PAN NO], CustVatNo AS [VAT NO],CustCSTNo AS [CST NO]  ,CustServicetaxRegnNo AS [Service Tax Regn. No],CustExciseRegnNo AS [Excise Regn. No] ,CustGSTRegnNo AS [GST Regn. No] from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID where " + s + " like '" + txtsearchvalue.Text + "%'";

                // string selectQuery = "select CustId,CustName,CustCompName,CustAddress,CustPhone,Custmobile,CustFax from CustomerDetails where " + s + " like '" + txtsearchvalue.Text + "%'";
                DataTable dt = d.getDetailByQuery(selectQuery);
                dataGridView2.DataSource = dt;
            }
            else if (counter == 1)
            {
                string s1 = comsearchvalue.SelectedValue.ToString();
                // string val1 = s1;
                string selectQuery1 = "select itm.ItemId as[Item Id],itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],ipd.purChasePrice as [Purchase Price],ipd.SalesPrice as[Sales Price],ipd.MrpPrice as[Mrp Price],ipd.Margin as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId  where " + s1 + " like '" + txtsearchvalue.Text + "%'";

                //string selectQuery1 = "select it.itemid,it.ItemName,ip.Mrpprice,iq.CurrentQuantity from ItemDetails it join ItemPriceDetail ip on it.Itemid=ip.Itemid join ItemQuantityDetail iq on ip.ItemId=iq.Itemid where " + s1 + " like '" + txtsearchvalue.Text + "%'";
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

        private void txtcustomercode_TextChanged(object sender, EventArgs e)
        {
           // tab1();
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

        private void gridsalesdelivary_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (txtRefNo.Text == "")
            {
                string itemid = gridsalesdelivary.Rows[e.RowIndex].Cells[0].Value.ToString();
                string selectqurry = "select Ids.ItemName,Ids.ItemCompName,ipd.MrpPrice, ipd.SalesPrice from ItemDetails Ids  join ItemPriceDetail ipd on Ids.ItemId=ipd.ItemId  where Ids.ItemId='" + itemid + "'";
                DataTable dt = d.getDetailByQuery(selectqurry);
                string rate = "";
                foreach (DataRow dr in dt.Rows)
                {
                    gridsalesdelivary.Rows[e.RowIndex].Cells[1].Value = dr[0].ToString();
                    gridsalesdelivary.Rows[e.RowIndex].Cells[2].Value = dr[1].ToString();
                    gridsalesdelivary.Rows[e.RowIndex].Cells[3].Value = dr[2].ToString();
                    // gridPurchaseOrder.Rows[e.RowIndex].Cells[5].Value=dr[3].ToString();

                    rate = dr[3].ToString();
                }
                if (rate != "")
                {
                    if (gridsalesdelivary.Rows[e.RowIndex].Cells[0].Value != null)
                    {
                        int co = gridsalesdelivary.CurrentRow.Index;
                        DataGridViewRow selectedRow = gridsalesdelivary.Rows[0];
                        selectedRow.Selected = true;
                        selectedRow.Cells[4].Selected = true;
                        //gridPurchaseOrder.CurrentCell = gridPurchaseOrder[gridPurchaseOrder.CurrentCell.ColumnIndex + 2, gridPurchaseOrder.CurrentCell.RowIndex];
                        //gridPurchaseOrder.Focus();
                    }
                    gridsalesdelivary.Rows[e.RowIndex].Cells[4].Value = rate;
                    string quantity = gridsalesdelivary.Rows[e.RowIndex].Cells[5].Value.ToString();
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
                    gridsalesdelivary.Rows[e.RowIndex].Cells[6].Value = price.ToString();
                    Double totalammount = Convert.ToDouble(txtTotalAmmount.Text);
                    Double toat = totalammount + price;
                    txtTotalAmmount.Text = toat.ToString();
                }
                else
                {
                    MessageBox.Show("please select your correct row");
                }
            }


            if (txtRefNo.Text != "")
            {
                string id = gridsalesdelivary.Rows[e.RowIndex].Cells[0].Value.ToString();
                string a1 = gridsalesdelivary.Rows[e.RowIndex].Cells[4].Value.ToString();
                // string newquantity = gridsalesdelivary.Rows[e.RowIndex].Cells[3].Value.ToString();
                string select = "select CurrentQuantity from ItemQuantityDetail where itemid='" + id + "'";
                DataTable dt = d.getDetailByQuery(select);
                string s = "";
                foreach (DataRow dr in dt.Rows)
                {
                    s = dr[0].ToString();

                }
                if (s != "")
                {
                    int g = Convert.ToInt32(s);
                    int quantity = Convert.ToInt32(a1);
                    if (quantity < g)
                    {
                        string a = gridsalesdelivary.Rows[e.RowIndex].Cells[4].Value.ToString();
                        string rate = gridsalesdelivary.Rows[e.RowIndex].Cells[2].Value.ToString();
                        quantity = Convert.ToInt32(a);
                        int r = Convert.ToInt32(rate);
                        int totalammount = quantity * r;
                        gridsalesdelivary.Rows[e.RowIndex].Cells[5].Value = totalammount.ToString();
                        //string newquantity = gridsalesdelivary.Rows[e.RowIndex].Cells[3].Value.ToString();
                        string rate1 = gridsalesdelivary.Rows[e.RowIndex].Cells[2].Value.ToString();
                        int quantity1 = Convert.ToInt32(a);
                        int finalquantity = Convert.ToInt32(rate1);
                        finalquantity = quantity1 - quantity;
                        int totalq = quantity1 * finalquantity;
                        int totalammount1 = Convert.ToInt32(txtTotalAmmount.Text);
                        int t = totalammount1 + totalq;
                        txtTotalAmmount.Text = totalammount.ToString();

                        double totalValues = 0.0;
                        foreach (DataGridViewRow row in gridsalesdelivary.Rows)
                        {
                            string amountValue = row.Cells[row.Cells.Count - 1].Value.ToString();
                            totalValues += Convert.ToDouble(amountValue);
                        }
                        txtTotalAmmount.Text = totalValues.ToString();
                    }
                    else if (quantity > g)
                    {
                        MessageBox.Show("Quantity is not available");
                        gridsalesdelivary.Rows[e.RowIndex].Cells[4].Value = "0";
                        //txtAmmount.Text = "0";
                    }
                    else
                    {
                        MessageBox.Show("please select your correct row");
                     gridsalesdelivary.Rows[e.RowIndex].Cells[0].Value = "";
                    }

                }
            }
        }
        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            //tab2();
            //string selectquery1 = "select i.ItemId,i.ItemName,ip.SalesPrice,iq.CurrentQuantity from ItemDetails i join ItemPriceDetail ip on i.ItemId=ip.ItemId join ItemQuantityDetail iq on ip.ItemId=iq.ItemId where i.ItemId='" + txtItemCode.Text + "'";
            //DataTable dt = d.getDetailByQuery(selectquery1);
            //if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        txtProductName.Text = dr[1].ToString();
            //        txtRate.Text = dr[2].ToString();
            //        txtQuantity.ReadOnly = true;
            //        butAddItem.Enabled = true;

            //    }
            //}
            //else
            //{
            //    txtProductName.Text = "";
            //    txtRate.Text = "";
            //    txtQuantity.ReadOnly = true;
            //    txtQuantity.Text = "";
            //    txtAmmount.Text = "";
            //    butAddItem.Enabled = false;

            //}
        }

        private void gridsalesdelivary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gridsalesdelivary.Rows.Count > 0)
            {
                butRemoveItem.Enabled = true;
            }
          
             if (e.KeyChar == (char)Keys.Escape)
            {
                txtItemCode.Enabled= true;
                txtItemCode.Focus();
                gridsalesdelivary.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                txtItemCode.TabIndex = 1;
                butSaveButton.TabStop = true;
                ButSelectPurchaseOrder.TabStop = true;
                butClose.TabStop = true;
            }
             if (e.KeyChar == (char)Keys.Enter)
             {
                if(txtRefNo.Text=="")
                {
                    if (addToCartTable.Rows.Count > 0)
                    {
                        string val = "";

                        //if (ls.Contains(itid))
                        //{
                        //    continue;
                        //}
                        int currentrow = gridsalesdelivary.CurrentRow.Index;
                        string Amount = gridsalesdelivary.Rows[currentrow - 1].Cells[6].Value.ToString();
                        double totalAmount = Convert.ToDouble(txtTotalAmmount.Text);
                        totalAmount -= Convert.ToDouble(Amount.Trim());
                        double withauttax = Convert.ToDouble(txtwithauttaxamount.Text);
                        withauttax -= Convert.ToDouble(Amount.Trim());
                        txtTotalAmmount.Text = totalAmount.ToString();
                        txtwithauttaxamount.Text = withauttax.ToString();
                        int index = gridsalesdelivary.SelectedRows[0].Index;
                        //addToCartTable.Rows.RemoveAt(index-1);
                        gridsalesdelivary.Rows[index - 1].DefaultCellStyle.Font = new Font(new FontFamily("Microsoft Sans Serif"), 9.00F, FontStyle.Strikeout);
                        gridsalesdelivary.Rows[index - 1].DefaultCellStyle.ForeColor = Color.Red;
                      string itemId = gridsalesdelivary.Rows[index - 1].Cells[0].Value.ToString();// I44

                        ls.Add(itemId);

                        gridsalesdelivary.DataSource = addToCartTable;
                    }
                 }
                   if(txtRefNo.Text!="")
                {
                    if (addToCartTable.Rows.Count > 0)
                    {
                        string val = "";

                        //if (ls.Contains(itid))
                        //{
                        //    continue;
                        //}
                        int currentrow = gridsalesdelivary.CurrentRow.Index;
                        string Amount = gridsalesdelivary.Rows[currentrow - 1].Cells[7].Value.ToString();
                        double totalAmount = Convert.ToDouble(txtTotalAmmount.Text);
                        totalAmount -= Convert.ToDouble(Amount.Trim());
                        double withauttax = Convert.ToDouble(txtwithauttaxamount.Text);
                        withauttax -= Convert.ToDouble(Amount.Trim());
                        txtTotalAmmount.Text = totalAmount.ToString();
                        txtwithauttaxamount.Text = withauttax.ToString();
                        int index = gridsalesdelivary.SelectedRows[0].Index;
                        //addToCartTable.Rows.RemoveAt(index-1);
                        gridsalesdelivary.Rows[index - 1].DefaultCellStyle.Font = new Font(new FontFamily("Microsoft Sans Serif"), 9.00F, FontStyle.Strikeout);
                        gridsalesdelivary.Rows[index - 1].DefaultCellStyle.ForeColor = Color.Red;
                        string itemId = gridsalesdelivary.Rows[index - 1].Cells[0].Value.ToString();// I44

                        ls.Add(itemId);

                        gridsalesdelivary.DataSource = addToCartTable;
                    }
           
                     if (addToCartTable.Rows.Count == 0)
                     {
                         txtTotalAmmount.Text = "0.0";
                         txtcst.Text = "0.0";
                     }
                     if (gridsalesdelivary.Rows.Count > 0)
                     {
                         butRemoveItem.Enabled = true;
                         gridsalesdelivary.Rows[gridsalesdelivary.Rows.Count - 1].Selected = true;
                      
                       
                     }
                     if (gridsalesdelivary.Rows.Count == 0)
                     {
                         txtItemCode.Enabled = true;
                         txtItemCode.Focus();
                     }
                     if (gridsalesdelivary.Rows.Count > 0)
                     {
                         txtdiccount.Text = "0";
                         txtdiccount.ReadOnly = true;
                     }
                     if (gridsalesdelivary.Rows.Count > 1)
                     {
                         txtdiccount.ReadOnly = false;
                     }
                     else
                     {
                         butRemoveItem.Enabled = false;
                     }
                     butRemoveItem.Enabled = false;

                 }
             }
        }

        private void txtcustomercode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
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
            if (e.KeyChar == (char)Keys.Enter)
            {
                tab1();
            }
            string selectquery = "select CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from CustomerDetails Where Custid='" + txtcustomercode.Text + "'";
            DataTable dt = d.getDetailByQuery(selectquery);
            if (dt.Rows.Count > 0)
            {
            }
            else if (e.KeyChar == (char)Keys.Enter && dt.Rows != null && dt != null)
            {
                txtcustomercode.Focus();
                MessageBox.Show("Please select your correct Customer id");
            }
        }

        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
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
            if (e.KeyChar == (char)Keys.Escape)
            {
                butRemoveItem.Focus();
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtcustomercode.Text == "C")
                {
                    MessageBox.Show("please enter the customercode");
                    txtcustomercode.Focus();
                }
                else
                {
                    string selectquery1 = "select i.ItemId,i.ItemName,ip.SalesPrice,iq.CurrentQuantity from ItemDetails i join ItemPriceDetail ip on i.ItemId=ip.ItemId join ItemQuantityDetail iq on ip.ItemId=iq.ItemId where i.ItemId='" + txtItemCode.Text + "'";
                    DataTable dt = d.getDetailByQuery(selectquery1);
                    if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            txtProductName.Text = dr[1].ToString();
                            txtRate.Text = dr[2].ToString();
                            txtQuantity.ReadOnly = true;
                            butAddItem.Enabled = true;

                        }
                    }
                    else
                    {
                        txtProductName.Text = "";
                        txtRate.Text = "";
                        txtQuantity.ReadOnly = true;
                        txtQuantity.Text = "";
                        txtAmmount.Text = "";
                        butAddItem.Enabled = false;

                    }
                    txtQuantity.ReadOnly = false;
                    tab7();

                }
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                if (gridsalesdelivary.Rows.Count > 0)
                {
                    butRemoveItem.Focus();
                }
                else
                {
                    butSaveButton.Focus();
                    ButSelectPurchaseOrder.TabStop = true;
                    butClose.TabStop = true;
                }
            }
            string selectquery2 = "select i.ItemId,i.ItemName,ip.MrpPrice,iq.CurrentQuantity from ItemDetails i join ItemPriceDetail ip on i.ItemId=ip.ItemId join ItemQuantityDetail iq on ip.ItemId=iq.ItemId where i.ItemId='" + txtItemCode.Text + "'";
            DataTable dt1 = d.getDetailByQuery(selectquery2);
            if (dt1.Rows.Count > 0)
            {
            }
            else if (e.KeyChar == (char)Keys.Enter && dt1.Rows != null && dt1 != null)
            {
                txtItemCode.Focus();
                MessageBox.Show("Please select your correct Customer Item id");
            }
        }

        private void txtsearchvalue_TextChanged(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                string s = comsearchvalue.SelectedValue.ToString();
                //string val = s;
                string selectQuery = "select  Custd.CustId as [Customer ID] ,CustName AS Name ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustDesc AS Description,Custad.CustOpeningBalance AS [Opening Balance] , Custad.CustCurrentBalance AS [Current Ballance],CustPanNo AS [PAN NO], CustVatNo AS [VAT NO],CustCSTNo AS [CST NO]  ,CustServicetaxRegnNo AS [Service Tax Regn. No],CustExciseRegnNo AS [Excise Regn. No] ,GSTRegnNo AS [GST Regn. No] from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID where " + s + " like '" + txtsearchvalue.Text + "%'";

                // string selectQuery = "select CustId,CustName,CustCompName,CustAddress,CustPhone,Custmobile,CustFax from CustomerDetails where " + val + " like '" + txtsearchvalue.Text + "%'";
                DataTable dt = d.getDetailByQuery(selectQuery);
                dataGridView2.DataSource = dt;
            }
            else if (counter == 1)
            {
                string s1 = comsearchvalue.SelectedValue.ToString();
                string selectQuery1 = "select itm.ItemId as[Item Id],itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],ipd.purChasePrice as [Purchase Price],ipd.SalesPrice as[Sales Price],ipd.MrpPrice as[Mrp Price],ipd.Margin as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId  where " + s1 + " like '" + txtsearchvalue.Text + "%'";

                //string val1 = s1;
                //string selectQuery1 = "select it.itemid,it.ItemName,ip.Mrpprice,iq.CurrentQuantity from ItemDetails it join ItemPriceDetail ip on it.Itemid=ip.Itemid join ItemQuantityDetail iq on ip.ItemId=iq.Itemid where " + val1 + " like '" + txtsearchvalue.Text + "%'";
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

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void dataGridView2_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtsearchvalue.Text = "";

            if (counter == 0)
            {
                DataGridViewCellCollection Collection = dataGridView2.Rows[e.RowIndex].Cells;
                rowcollection(Collection);
                panel2.Visible = false;
                tab1();
                txtcustomercode.TabStop = true;
                butcustomercode.TabStop = true;
            }
            if (counter == 1)
            {
                DataGridViewCellCollection Collection1 = dataGridView2.Rows[e.RowIndex].Cells;
                rowcollection1(Collection1);
                panel2.Visible = false;
                tab2();
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

        private void dataGridView2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            int currentIndex = dataGridView2.CurrentRow.Index;
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (dataGridView2.SelectedRows != null && dataGridView2.SelectedRows.Count > 0)
                {
                    if (dataGridView2.RowCount == currentIndex - 1)
                        currentIndex = currentIndex + 1;
                    if (counter == 0)
                    {
                        DataGridViewCellCollection Collection = dataGridView2.Rows[currentIndex - 1].Cells;
                        rowcollection(Collection);
                        panel2.Visible = false;
                        tab1();
                    }
                    if (counter == 1)
                    {
                        DataGridViewCellCollection Collection1 = dataGridView2.Rows[currentIndex - 1].Cells;
                        rowcollection1(Collection1);
                        panel2.Visible = false;
                        tab2();
                    }


                }
            }
        }

        private void butSaveButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                txtcustomercode.Focus();
            }
        }

        private void ButSelectPurchaseOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtcustomercode.Focus();
        }

        private void butClose_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtcustomercode.Focus();
        }

        private void butRemoveItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                butSaveButton.Focus();
                ButSelectPurchaseOrder.TabStop = true;
                butClose.TabStop = true;
                txtcustomercode.TabStop = true;
                butcustomercode.TabStop = true;
               
            }
        }

        private void txtRefNo_Enter(object sender, EventArgs e)
        {
            //string selectquery2 = "select Orderid from salesOrderDelivery where Orderid='" + txtRefNo.Text + "'";
            //DataTable dt1 = d.getDetailByQuery(selectquery2);
            //if (dt1 != null && dt1.Rows != null && dt1.Rows.Count > 0)
            //{
            //    MessageBox.Show("order details is completed");
            //    //xtRefNo.Text = "";
            //    //gridsalesdelivary.DataSource = "";
            //}
            //else
            //{
            //    butSaveButton.Visible = true;


            //    string selectquery = "select  c.custId, c.CustName,c.CustCompName,c.CustAddress,c.CustPhone,c.CustMobile,c.CustFax,o.orderid from CustomerDetails c join orderdetails o on c.custId=o.custid where o.orderid='" + txtRefNo.Text + "'";
            //    DataTable dt = d.getDetailByQuery(selectquery);
            //    if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            //    {
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            txtcustomercode.Text = dr[0].ToString();
            //            txtCustomerName.Text = dr[1].ToString();
            //            txtCompName.Text = dr[2].ToString();
            //            txtAddress.Text = dr[3].ToString();
            //            txtPhone.Text = dr[4].ToString();
            //            txtMobile.Text = dr[5].ToString();
            //            txtFax.Text = dr[6].ToString();
            //            txtRefNo.Text = dr[7].ToString();
            //        }
            //    }
            //    //else
            //    //{
            //    //    txtRefNo.Text = "";
            //    //    txtCustomerName.Text = "";
            //    //    txtCompName.Text = "";
            //    //    txtAddress.Text = "";
            //    //    txtPhone.Text = "";
            //    //    txtMobile.Text = "";
            //    //    txtFax.Text = "";
            //    //}

            //    int totel = 0;
            //    string selectquery1 = "select it.itemid,iq.ItemName,it.price,it.quantity,it.totalammount from customerorderdescriptions it join ItemDetails iq on it.ItemId=iq.ItemId  where orderid='" + txtRefNo.Text + "'";
            //    DataTable dt3 = d.getDetailByQuery(selectquery1);
            //    int totelrow = addToCartTable.Rows.Count;
            //    for (int a = 0; a < totelrow; a++)
            //    {
            //        addToCartTable.Rows.RemoveAt(0);
            //    }
            //    for (int a = 0; a < dt3.Rows.Count; a++)
            //    {
            //        DataRow dr1 = dt3.Rows[a];
            //        string itemcode = dr1[0].ToString();
            //        string productname = dr1[1].ToString();
            //        string rate = dr1[2].ToString();
            //        string quantity = dr1[3].ToString();
            //        string ammount = dr1[4].ToString();
            //        //string ammount1 = dr1[5].ToString();
            //        int amt = Convert.ToInt32(ammount);
            //        totel = totel + amt;
            //        dr1 = addToCartTable.NewRow();
            //        dr1[0] = itemcode.Trim();
            //        dr1[1] = productname.Trim();
            //        dr1[2] = rate.Trim();
            //        dr1[3] = quantity.Trim();
            //        dr1[4] = quantity.Trim();
            //        dr1[5] = ammount.Trim();
            //        addToCartTable.Rows.Add(dr1);

            //    }

            //    gridsalesdelivary.DataSource = addToCartTable;
            //    txtTotalAmmount.Text = totel.ToString();

            //}
        }

        private void txtRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                addToCartTable.Columns.RemoveAt(6);
                addToCartTable.Columns.Add(new DataColumn("ResivQuantity"));
               addToCartTable.Columns.Add(new DataColumn("Amount"));
                txtRefNo.ReadOnly = true;
                string selectquery2 = "select Orderid from salesOrderDelivery where Orderid='" + txtRefNo.Text + "'";
                DataTable dt1 = d.getDetailByQuery(selectquery2);
                if (dt1 != null && dt1.Rows != null && dt1.Rows.Count > 0)
                {
                    MessageBox.Show("order details is completed");
                   // txtRefNo.Text = "";
                    //gridsalesdelivary.DataSource = "";
                }

            //         else
                //{
                //    button5.Enabled = true;
                //    int totel1 = 0;
                //    string select = "select vo.Orderid,vo.venderId,vod.ItemId,vo.Discount from VendorOrderDesc vod join VendorOrderDetails vo on vod.Orderid=vo.Orderid where vo.Orderid ='" + txtRef.Text + "'";
                //    DataTable dt = dbMainClass.getDetailByQuery(select);
                //    //string dis = "";
                //    if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                //    {
                //        DataRow dr = dt.Rows[0];
                //        string a = dr[1].ToString();
                //        string dis = dr[3].ToString();
                //        txtdis.Text = dis;
                //        string select1 = "select venderId,vName,vCompName,vAddress ,vPhone,vMobile,vFax from VendorDetails where venderId='" + a + "'";
                //        SetVendor(select1);
                //        string selectqurry1 = "select vodd.ItemId,td.ItemName, vodd.Quantity,vodd.Price,vodd.TotalPrice,vod.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId where vod. Orderid ='" + txtRef.Text + "'";
                //        DataTable dt2 = dbMainClass.getDetailByQuery(selectqurry1);
                //        int totalRowCount = addToCartTable.Rows.Count;
                //        for (int rowCount = 0; rowCount < totalRowCount; rowCount++)
                //        {
                //            addToCartTable.Rows.RemoveAt(0);
                //        }

                else
                {
                    butSaveButton.Visible = true;
                    string select = "select vo.orderid,vo.custid,vod.ItemId,vo.Discount from orderdetails vo join customerorderdescriptions vod on vod.Orderid=vo.Orderid where vo.Orderid ='" + txtRefNo.Text + "'";
                    DataTable dt = d.getDetailByQuery(select);
                    string a="";
                    if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        a = dr[1].ToString();

                        string discount = dr[3].ToString();
                       // txtcst.Text = discount;
                    //}
                        string selectquery = "select  c.custId, c.CustName,c.CustCompName,c.CustAddress,c.CustPhone,c.CustMobile,c.CustFax from CustomerDetails c  where  c.custId='" + a + "'";
                        //DataTable dt2 = d.getDetailByQuery(selectquery);
                        SetVendor(selectquery);
                   // "select it.itemid,iq.ItemName,it.price,it.quantity,it.totalammount from customerorderdescriptions it join ItemDetails iq on it.ItemId=iq.ItemId  where orderid='" + txtRefNo.Text + "'"
                        string selectItem = "select cod.ItemId,ad.ItemName,ad.ItemCompName,ipd.MrpPrice,cod.price,cod.quantity,cod.totalammount from orderdetails od join customerorderdescriptions cod on od.orderid=cod.orderid join ItemDetails ad on cod.ItemId=ad.ItemId join ItemPriceDetail ipd on ad.ItemId=ipd.ItemId where od.orderid='" + txtRefNo.Text + "'";
                        DataTable dt3 = d.getDetailByQuery(selectItem);
                        int totalrowcount = addToCartTable.Rows.Count;
                        for (int rowcount = 0; rowcount < totalrowcount; rowcount++)
                        {
                            addToCartTable.Rows.RemoveAt(0);
                        }

                        int totel = 0;

                        for (int b = 0; b < dt3.Rows.Count; b++)
                        {
                            DataRow dr1 = dt3.Rows[b];
                            string itemcode = dr1[0].ToString();
                            if (ls.Contains(itemcode))
                            {
                                continue;
                            }
                            string productname = dr1[1].ToString();
                            string compnayname = dr1[2].ToString();
                            string mrp = dr1[3].ToString();
                            string rate = dr1[4].ToString();
                            string quantity = dr1[5].ToString();
                            string quantity1 = dr1[5].ToString();
                            string ammount = dr1[6].ToString();
                            //string ammount1 = dr1[5].ToString();
                            int amt = Convert.ToInt32(ammount);
                            totel = totel + amt;
                            dr1 = addToCartTable.NewRow();
                            dr1[0] = itemcode.Trim();
                            dr1[1] = productname.Trim();
                            dr1[2] = compnayname.Trim();
                            dr1[3] = mrp.Trim();
                            dr1[4] = rate.Trim();
                            dr1[5] = quantity.Trim();
                            dr1[6] = quantity.Trim();
                            dr1[7] = ammount.Trim();
                            addToCartTable.Rows.Add(dr1);

                        }
                       // gridsalesdelivary.DataSource = null;
                        gridsalesdelivary.DataSource = addToCartTable;
                        txtTotalAmmount.Text = totel.ToString();

                    }
                    if (gridsalesdelivary.Rows.Count > 1)
                    {
                        txtdiccount.ReadOnly = false;
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
                    txtRefNo.ReadOnly = false;
                    makeblank();

                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }


        private void SetVendor(string r)
        {
            DataTable dt = d.getDetailByQuery(r);
            foreach (DataRow dr in dt.Rows)
            {
                txtcustomercode.Text = dr[0].ToString();
                txtCustomerName.Text = dr[1].ToString();
                txtCompName.Text = dr[2].ToString();
                txtAddress.Text = dr[3].ToString();
                txtPhone.Text = dr[4].ToString();
                txtMobile.Text = dr[5].ToString();
                txtFax.Text = dr[6].ToString();
                //txtRefNo.Text = dr[7].ToString();
            }
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            double totalAmount = 0.00;
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtRefNo.Text == "")
                {
                    if (e.KeyChar == '\b')
                    {
                        foreach (DataRow dr in addToCartTable.Rows)
                        {
                            totalAmount += Convert.ToDouble(dr[6].ToString());
                        }
                        double s1 = totalAmount;
                        txtTotalAmmount.Text = s1.ToString();
                        txtdicountamount.Text = "0";
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
                if (txtRefNo.Text != "")
                {
                    if (e.KeyChar == '\b')
                    {
                        foreach (DataRow dr in addToCartTable.Rows)
                        {
                            totalAmount += Convert.ToDouble(dr[7].ToString());
                        }
                        double s1 = totalAmount;
                        txtTotalAmmount.Text = s1.ToString();
                        txtdicountamount.Text = "0";
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
            }


            if (e.KeyChar == (char)Keys.Enter)
            {
               
                if (txtRefNo.Text == "")
                {

                    //discountamount.Text = disa.ToString();
                    foreach (DataRow dr in addToCartTable.Rows)
                    {
                        string itemid = dr[0].ToString();
                        if (ls.Contains(itemid))
                        {
                            continue;
                        }
                        totalAmount += Convert.ToDouble(dr[6].ToString());
                    }
                    double s = totalAmount;
                    string discount = txtdiccount.Text;

                    double amount = 0.0;

                    if (double.TryParse(discount, out amount))
                    {
                        double totaldiscount = Convert.ToDouble(discount);
                        totalAmount = totalAmount - ((totalAmount * totaldiscount) / 100);
                        txtTotalAmmount.Text = totalAmount.ToString();
                        txtwithauttaxamount.Text = s.ToString();
                        double dis = s * totaldiscount / 100;
                        txtdicountamount.Text = dis.ToString();
                    }
                }


                    if (txtRefNo.Text != "")
                    {

                        foreach (DataRow dr in addToCartTable.Rows)
                        {
                            string itemid = dr[0].ToString();
                            if (ls.Contains(itemid))
                            {
                                continue;
                            }
                            totalAmount += Convert.ToDouble(dr[7].ToString());
                        }
                       double s1 = totalAmount;
                        string discount1 = txtdiccount.Text;

                        double amount1 = 0.0;

                        if (double.TryParse(discount1, out amount1))
                        {
                            double totaldiscount = Convert.ToDouble(discount1);
                            totalAmount = totalAmount - ((totalAmount * totaldiscount) / 100);
                            txtTotalAmmount.Text = totalAmount.ToString();
                            txtwithauttaxamount.Text = s1.ToString();
                            double dis = s1 * totaldiscount / 100;
                            txtdicountamount.Text = dis.ToString();

                        }
                    }
                }
            }

            
           
        

        private void txtTotalAmmount_TextChanged(object sender, EventArgs e)
        {
            double totalAmount = 0.00;
           // txtTotalAmmount.Text = "0";
            if (txtTotalAmmount.Text == "")
            {
                txtTotalAmmount.Text = "0";
            }
            if (txtRefNo.Text == "")
            {

                foreach (DataRow dr in addToCartTable.Rows)
                {
                    totalAmount += Convert.ToDouble(dr[6].ToString());
                }
                double s = totalAmount;
                double d = 1;
                double total = Convert.ToDouble(txtTotalAmmount.Text);
                double g = Convert.ToDouble(txttax.Text);
                double tax = d + ((g / 100));
                double taxamount = total / tax;
                double totaltax = total - taxamount;
                txttaxamount.Text = totaltax.ToString();
                double dis = Convert.ToDouble(txtdicountamount.Text);
                double dis1 = total * dis / 100;
                double withauttax = total - dis1;
                txtwithauttaxamount.Text = withauttax.ToString();
                txtwithauttaxamount.Text = s.ToString();
            }
            

            if (txtRefNo.Text != "")
            {
                foreach (DataRow dr in addToCartTable.Rows)
                {
                    totalAmount += Convert.ToDouble(dr[7].ToString());
                }
                double s1 = totalAmount;
                double d1 = 1;
                double total1 = Convert.ToDouble(txtTotalAmmount.Text);
                double g1 = Convert.ToDouble(txttax.Text);
                double tax1 = d1 + ((g1 / 100));
                double taxamount1 = total1 / tax1;
                double totaltax1 = total1 - taxamount1;
                txttaxamount.Text = totaltax1.ToString();
                double dis2 = Convert.ToDouble(txtdiccount.Text);
                double dis3 = s1 * dis2 / 100;
                double withauttax1 = total1 - dis3 ;
                  
                txtwithauttaxamount.Text = withauttax1.ToString();
                txtwithauttaxamount.Text = s1.ToString();
            }
        }

        private void salesdelivary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "S")
            {
                createnewsave();
            }
            if (e.Alt && e.KeyCode.ToString() == "D")
            {
                txtdiccount.Focus();
            }
        }



      
       

       
      

        }

      
    }


