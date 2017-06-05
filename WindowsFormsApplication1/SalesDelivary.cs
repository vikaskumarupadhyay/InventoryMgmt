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
            butAddItem.Enabled = true;
            txtQuantity.Focus();
            txtcustomercode.TabStop = true;
            butcustomercode.TabStop = true;
            txtItemCode.TabStop = true;
            butitembutton.TabStop = true;
            txtQuantity.TabStop = true;
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
            dataGridView2.AllowUserToAddRows = true;
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
            txtItemCode.TabStop = false;
            butitembutton.TabStop = false;
            butAddItem.TabStop = false;
            butRemoveItem.TabStop = false;
            butSaveButton.TabStop = false;
            ButSelectPurchaseOrder.TabStop = false;
            butClose.TabStop = false;
            txtsearchvalue.Focus();
            comsearchvalue.TabIndex = 1;
            txtsearchvalue.TabIndex = 2;
            dataGridView2.TabIndex = 3;
            butback.TabIndex = 4;

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
            txtRate.Text = cell1[7].Value.ToString();
            double rate = Convert.ToDouble(txtRate.Text);
            // maxquantity = Convert.ToInt32((cell1[3].Value.ToString()));
            txtQuantity.Text = "1";
            double quantuty = Convert.ToDouble(txtQuantity.Text);
            double amount = (rate * quantuty);
            txtAmmount.Text = amount.ToString();

        }


        private void butitembutton_Click(object sender, EventArgs e)
        {
            dataGridView2.AllowUserToAddRows = true;
            crystalReportViewer2.Visible = false;
            string selectquery1 = "select  itm.ItemId as [Item Id],itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],cast(ipd.SalesPrice as numeric(38,2)) as[Sales Price],cast(ipd.MrpPrice as numeric(38,2)) as[Mrp Price] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId";
            string actualcolumn = "select top 1  itm.ItemId, itm.ItemName,itm.ItemCompName ,itm.ItemDesc ,ig.groupName,iul.unitName ,cast(ipd.purChasePrice as numeric(38,2)) ,cast(ipd.SalesPrice as numeric(38,2)) ,cast(ipd.MrpPrice as numeric(38,2)),ipd.Margin ,iqd.OpeningQuantity ,iqd.CurrentQuantity from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId";

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
            string selectquery = "select  itm.ItemId as [Item Id],itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],cast(ipd.purChasePrice as numeric(38,2)) as [Purchase Price],cast(ipd.SalesPrice as numeric(38,2)) as[Sales Price],cast(ipd.MrpPrice as numeric(38,2)) as[Mrp Price],ipd.Margin as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId";

            // string selectquery = "select i.Itemid,i.Itemname,ip.MrpPrice,iq.CurrentQuantity from itemdetails i join itempricedetail ip on i.itemid=ip.itemid join itemquantitydetail iq on ip.itemid=iq.itemid";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView2.DataSource = dt;
            txtQuantity.TabStop = false;
            txtcustomercode.TabStop = false;
            butcustomercode.TabStop = false;
            txtItemCode.TabStop = false;
            butitembutton.TabStop = false;
            butAddItem.TabStop = false;
            butRemoveItem.TabStop = false;
            butSaveButton.TabStop = false;
            ButSelectPurchaseOrder.TabStop = false;
            butClose.TabStop = false;
            txtsearchvalue.Focus();
            comsearchvalue.TabIndex = 1;
            txtsearchvalue.TabIndex = 2;
            dataGridView2.TabIndex = 3;
            butback.TabIndex = 4;
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

            if (txtQuantity.Text != "")
            {
                string total = "";
                string itemid = "";
                foreach (DataRow dr3 in addToCartTable.Rows)
                {
                    itemid = dr3[0].ToString();
                    if (itemid == txtItemCode.Text)
                    {
                        total = dr3[5].ToString();
                    }

                }
                if (total == "")
                {
                    total = "0";
                }
                int it = Convert.ToInt32(total);
                int g = Convert.ToInt32(s);

                int quantity = Convert.ToInt32(txtQuantity.Text);
                int h = it + quantity;
                if (h <= g)
                {
                    //    MessageBox.Show("d");

                    // if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                    if ((!string.IsNullOrEmpty(txtQuantity.Text)) && char.IsDigit(txtQuantity.Text, txtQuantity.Text.Length - 1) && (!string.IsNullOrEmpty(txtRate.Text)))
                    {
                        //     txtQuantity.ReadOnly = false;
                        // int que = maxquantity;
                        quantity = Convert.ToInt32(txtQuantity.Text);
                        double rate = Convert.ToDouble(txtRate.Text);
                        txtAmmount.Text = (quantity * rate).ToString("###0.00");
                    }

                }
                else
                {
                    MessageBox.Show("Maximum Quantity is="+s);
                    txtQuantity.Text = "0";
                    txtQuantity.SelectionLength = txtQuantity.Text.Length;
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
            txtRefNo.Enabled = false;
            ButSelectPurchaseOrder.Enabled = false;
            txtItemCode.Focus();
            txtQuantity.ReadOnly=true;
            txtcustomercode.TabStop=true;
            butRemoveItem.Enabled = true;
            txtItemCode.Focus();
             
                string itemid = "";
                string quntity = "";
                string rate = "";
                string prise = "";
            int counter = 0;
          
            //txtQuantity.Enabled = false;
            if (txtRefNo.Text == "")
            {
                
                if (addToCartTable.Columns.Contains("ResivQuantity"))
                {
                   // addToCartTable.Columns.Add(new DataColumn("ResivQuantity"));
                    addToCartTable.Columns.RemoveAt(6);
                }

              
              
                List<string> ls1 = new List<string>();
                foreach (DataRow dr3 in addToCartTable.Rows)
                {
                    //counter = 0;
                    int q3 = 0;
                    //itemid = dr3[0].ToString();
                    string itid = dr3[0].ToString();
                    if (ls.Contains(itid) && gridsalesdelivary.Rows[counter].DefaultCellStyle.Font != null)
                    {
                        counter++;
                        continue;
                    }
                    counter++;
                    quntity = dr3[5].ToString();
                    rate = dr3[4].ToString();
                    prise = dr3[6].ToString();
                    string select1 = "select ItemName from ItemDetails where ItemId='" + txtItemCode.Text + "'";
                    DataTable data1 = d.getDetailByQuery(select1);
                    string itemName = "";
                    foreach (DataRow dr2 in data1.Rows)
                    {
                        itemName = dr2[0].ToString();
                    }
                    if (itemName != txtProductName.Text)
                    {
                        MessageBox.Show("Please Select correct ItemCode");
                        return;
                    }
                  
                    if (itid == txtItemCode.Text)
                    {
                        if (quntity == "")
                        {
                            quntity = "0";
                        }
                        else if (txtQuantity.Text == "0" || txtQuantity.Text == "")
                        {
                            MessageBox.Show("please select you quantity");
                            txtQuantity.Text = "1";
                            txtQuantity.SelectionLength = txtQuantity.Text.Length;
                            txtQuantity.Focus();
                            txtQuantity.ReadOnly = false;
                            return;
                        }
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
                        txtTotalAmmount.Text = rate5.ToString("###0.00");//rate3.ToString();
                        // MessageBox.Show("Please Enter the Quanity");
                         txtItemCode.Text = "I";
                         txtProductName.Text = "";
                         txtRate.Text = "";
                         txtQuantity.Text = "";
                         txtAmmount.Text= "";
                         txtQuantity.ReadOnly = true;
                         butAddItem.Enabled = false;
                         //addToCartTable.Columns.Add("Qtuhjh");
                       // ls1.Add(itemid);

                    }
                }
                if (txtProductName.Text == "" && txtQuantity.Text == "")
                {
                    // MessageBox.Show("please enter the ");
                }
                else
                {
                    //if (txtAmmount.Text == "")
                    //{
                    //    MessageBox.Show("please enter the quantity");
                    //}
                    if (txtQuantity.Text == "0" || txtQuantity.Text == "")
                    {
                        MessageBox.Show("please select you quantity");
                        txtQuantity.Text = "1";
                        txtQuantity.SelectionLength = txtQuantity.Text.Length;
                        txtQuantity.Focus();
                        txtQuantity.ReadOnly = false;
                    }
                    else
                    {
                        string select1 = "select ItemName from ItemDetails where ItemId='" + txtItemCode.Text + "'";
                        DataTable data1 = d.getDetailByQuery(select1);
                        string itemName = "";
                        foreach (DataRow dr2 in data1.Rows)
                        {
                            itemName = dr2[0].ToString();
                        }
                        if (itemName != txtProductName.Text)
                        {
                            MessageBox.Show("Please Select correct ItemCode");
                            return;
                        }
                        else
                        {
                            string selectq = "select ids.ItemCompName,cast(ipd.MrpPrice as numeric(38,2))from ItemPriceDetail ipd join ItemDetails ids on ipd.ItemId=ids.ItemId where ipd.ItemId='" + txtItemCode.Text + "'";
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
                            var cdsds = gridsalesdelivary.Rows.Count;
                            gridsalesdelivary.CurrentCell = gridsalesdelivary.Rows[cdsds - 2].Cells[0];
                            double totalAmount = Convert.ToDouble(txtTotalAmmount.Text);
                            totalAmount += Convert.ToDouble(txtAmmount.Text.Trim());
                            txtTotalAmmount.Text = totalAmount.ToString("###0.00");
                            // txtwithauttaxamount.Text = txtTotalAmmount.Text;

                            txtItemCode.Text = "I";
                            txtProductName.Text = "";
                            txtRate.Text = "";
                            txtQuantity.Text = "";
                            txtAmmount.Text = "";
                            butAddItem.Enabled = false;
                            // }
                        }
                        ButSelectPurchaseOrder.TabStop = true;
                        butClose.TabStop = true;
                        butSaveButton.TabStop = true;
                        txtQuantity.TabStop = false;
                    }
                }
                    if (gridsalesdelivary.Rows.Count > 1)
                    {
                        txtdiccount.ReadOnly = false;
                    }
               
                if (gridsalesdelivary.Rows.Count > 1)
                {
                    txtdiccount.ReadOnly = false;
                }
                txtItemCode.Select(txtItemCode.Text.Length, 0);
            }
           else if (txtRefNo.Text != ""&& gridsalesdelivary.Columns.Count==7)
            {

                List<string> ls1 = new List<string>();
                foreach (DataRow dr3 in addToCartTable.Rows)
                {
                    counter = 0;
                    int q3 = 0;
                    //itemid = dr3[0].ToString();
                    string itid = dr3[0].ToString();
                    if (ls.Contains(itid) && gridsalesdelivary.Rows[counter].DefaultCellStyle.Font != null)
                    {
                        counter++;
                        continue;
                    }
                    counter++;
                    quntity = dr3[5].ToString();
                    rate = dr3[4].ToString();
                    prise = dr3[6].ToString();
                    if (itid == txtItemCode.Text)
                    {
                        if (quntity == "")
                        {
                            quntity = "0";
                        }
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
                        txtTotalAmmount.Text = rate5.ToString("###0.00");//rate3.ToString();
                        // MessageBox.Show("Please Enter the Quanity");
                        txtItemCode.Text = "I";
                        txtProductName.Text = "";
                        txtRate.Text = "";
                        txtQuantity.Text = "";
                        txtAmmount.Text = "";
                        txtQuantity.ReadOnly = true;
                        butAddItem.Enabled = false;
                        //addToCartTable.Columns.Add("Qtuhjh");
                        // ls1.Add(itemid);

                    }
                }
                if (txtProductName.Text == "" && txtQuantity.Text == "")
                {
                    // MessageBox.Show("please enter the ");
                }
                else
                {
                    if (txtAmmount.Text == "")
                    {
                        MessageBox.Show("please enter the quantity");
                    }
                    else
                    {
                        string selectq = "select ids.ItemCompName,cast(ipd.MrpPrice as numeric(38,2))from ItemPriceDetail ipd join ItemDetails ids on ipd.ItemId=ids.ItemId where ipd.ItemId='" + txtItemCode.Text + "'";
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
                        var cdsds = gridsalesdelivary.Rows.Count;
                        gridsalesdelivary.CurrentCell = gridsalesdelivary.Rows[cdsds - 2].Cells[0];
                        double totalAmount = Convert.ToDouble(txtTotalAmmount.Text);
                        totalAmount += Convert.ToDouble(txtAmmount.Text.Trim());
                        txtTotalAmmount.Text = totalAmount.ToString("###0.00");
                        // txtwithauttaxamount.Text = txtTotalAmmount.Text;

                        txtItemCode.Text = "I";
                        txtProductName.Text = "";
                        txtRate.Text = "";
                        txtQuantity.Text = "";
                        txtAmmount.Text = "";
                        butAddItem.Enabled = false;
                        // }
                    }
                }
                if (gridsalesdelivary.Rows.Count > 1)
                {
                    txtdiccount.ReadOnly = false;
                }

                if (gridsalesdelivary.Rows.Count > 1)
                {
                    txtdiccount.ReadOnly = false;
                }
                txtItemCode.Select(txtItemCode.Text.Length, 0);
            }

            else if (txtRefNo.Text != "")
            {
                counter = 0;
                    List<string> ls1 = new List<string>();
                    foreach (DataRow dr3 in addToCartTable.Rows)
                    {
                        
                        int q3 = 0;
                        //itemid = dr3[0].ToString();
                        string itid = dr3[0].ToString();
                        if (ls.Contains(itid) && gridsalesdelivary.Rows[counter].DefaultCellStyle.Font != null)
                        {
                            counter++;
                            continue;
                        }
                        counter++;
                        quntity = dr3[6].ToString();
                        rate = dr3[4].ToString();
                        prise = dr3[7].ToString();
                        string select1 = "select ItemName from ItemDetails where ItemId='" + txtItemCode.Text + "'";
                        DataTable data1 = d.getDetailByQuery(select1);
                        string itemName = "";
                        foreach (DataRow dr2 in data1.Rows)
                        {
                            itemName = dr2[0].ToString();
                        }
                        if (itemName != txtProductName.Text)
                        {
                            MessageBox.Show("Please Select correct ItemCode");
                            return;
                        }
                        if (itid == txtItemCode.Text)
                        {
                            if (quntity == "")
                            {
                                quntity = "0";
                            }
                            int q1 = Convert.ToInt32(quntity);
                            int q2 = Convert.ToInt32(txtQuantity.Text);
                            q3 = q1 + q2;
                            dr3[5] = q3.ToString();
                            dr3[6] = q3.ToString();
                            //dr3[4] = q3.ToString();
                            Double rate1 = Convert.ToDouble(prise);
                            Double rate2 = Convert.ToDouble(txtAmmount.Text);
                            Double rate3 = rate1 + rate2;
                            dr3[7] = rate3.ToString();
                            Double rate4 = Convert.ToDouble(txtTotalAmmount.Text);
                            Double rate5 = rate4 + rate2;
                            txtTotalAmmount.Text = rate5.ToString("###0.00");//rate3.ToString();
                            txtwithauttaxamount.Text=rate5.ToString("###0.00");
                            // MessageBox.Show("Please Enter the Quanity");
                            txtItemCode.Text = "I";
                            txtProductName.Text = "";
                            txtRate.Text = "";
                            txtQuantity.Text = "";
                            txtAmmount.Text = "";
                            txtQuantity.ReadOnly = true;
                            butAddItem.Enabled = false;
                            //addToCartTable.Columns.Add("Qtuhjh");
                            // ls1.Add(itemid);

                        }
                    }
                        if (txtProductName.Text == "" && txtQuantity.Text == "")
                        {
                            //MessageBox.Show("now CurrentQuantity of deadt");
                        }
                        else
                        {
                            //if (txtAmmount.Text == "")
                            //{
                            //    MessageBox.Show("please Enter Quantity");
                            //}
                            if (txtQuantity.Text == "0" || txtQuantity.Text == "")
                            {
                                MessageBox.Show("please select you quantity");
                                txtQuantity.Text = "1";
                                txtQuantity.SelectionLength = txtQuantity.Text.Length;
                                txtQuantity.Focus();
                                txtQuantity.ReadOnly = false;
                            }
                            else
                            {
                                string select1 = "select ItemName from ItemDetails where ItemId='" + txtItemCode.Text + "'";
                                DataTable data1 = d.getDetailByQuery(select1);
                                string itemName = "";
                                foreach (DataRow dr2 in data1.Rows)
                                {
                                    itemName = dr2[0].ToString();
                                }
                                if (itemName != txtProductName.Text)
                                {
                                    MessageBox.Show("Please Select correct ItemCode");
                                    return;
                                }
                                else
                                {
                                    string selectq = "select ids.ItemCompName,cast(ipd.MrpPrice as numeric(38,2))from ItemPriceDetail ipd join ItemDetails ids on ipd.ItemId=ids.ItemId where ipd.ItemId='" + txtItemCode.Text + "'";
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

                                    gridsalesdelivary.DataSource = addToCartTable;
                                    var cdsds = gridsalesdelivary.Rows.Count;
                                    gridsalesdelivary.CurrentCell = gridsalesdelivary.Rows[cdsds - 2].Cells[0];
                                    double totalAmount = Convert.ToDouble(txtTotalAmmount.Text);
                                    totalAmount += Convert.ToDouble(txtAmmount.Text.Trim());
                                    txtTotalAmmount.Text = totalAmount.ToString("###0.00");
                                    txtwithauttaxamount.Text = totalAmount.ToString("###0.00");

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
                            }
                            if (gridsalesdelivary.Rows.Count > 1)
                            {
                                txtdiccount.ReadOnly = false;
                            }
                            txtItemCode.Select(txtItemCode.Text.Length, 0);

                        }
                    }

                }

        private void salesdelivary_Load(object sender, EventArgs e)
        {
            txtSrNo.ReadOnly = true;
            txtcustomercode.Select(txtcustomercode.Text.Length, 0);
            txtItemCode.Select(txtItemCode.Text.Length, 0);
            txtdiccount.ReadOnly = true;
            //dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridsalesdelivary.DataSource = addToCartTable;
            txttaxamount.Visible = false;
            txtdicountamount.Visible = false;
            txtwithauttaxamount.Visible = false;

            txtTotalAmmount.Text = "0";
            txtwithauttaxamount.Text = "0";
            // txtdiccount.ReadOnly = false;
            txttaxamount.Text = "0";
            txtdicountamount.Text = "0.";
            tab();
            txtQuantity.ReadOnly = true;
            butRemoveItem.Enabled = false;
            butAddItem.Enabled = false;
            // txtItemCode.Text = "I";
            dtpDate.Value = DateTime.Now;
            // txtcustomercode.Text = "C";
            panel2.Visible = false;
            pnlSalesPayment.Visible = false;
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
                textBox1.Text = dr[1].ToString();
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
            txtTotalAmmount.Text = "0.00";
            txtdiccount.Text = "0.00";
        }


        private void butRemoveItem_Click(object sender, EventArgs e)
        {
            
            gridsalesdelivary.DefaultCellStyle.SelectionBackColor = Color.Red;
           
            butRemoveItem.Enabled = false;

            gridsalesdelivary.TabIndex = 0;
            gridsalesdelivary.Focus();
        
            txtItemCode.Enabled = true;
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
           // gridsalesdelivary.DataSource = "";
            textBox20.Text = "";
        }

        private void butSaveButton_Click(object sender, EventArgs e)
        {
            if (txtcustomercode.Text == "C" && txtItemCode.Text == "I")
            {
                MessageBox.Show("please select your customer code");
                txtcustomercode.Focus();

                return;
            }

            else if (txtProductName.Text != "")
            {
                MessageBox.Show("please select add item");
                txtQuantity.Focus();
                return;

            }
            else if (gridsalesdelivary.Rows.Count == 1 && txtcustomercode.Text == "C")
            {
                MessageBox.Show("please select your customer id");
                txtcustomercode.Focus();
                txtItemCode.Text = "I";
                return;
            }
            if (ls.Count == gridsalesdelivary.Rows.Count - 1)
            {
                MessageBox.Show("Please Enter The Item");
                txtItemCode.Focus();
                txtItemCode.Select(txtItemCode.Text.Length, 0);
                return;
            }


            else if (gridsalesdelivary.Rows.Count == 1 && txtItemCode.Text == "I")
            {
                MessageBox.Show("please select your item id");
                txtItemCode.Focus();
                return;
            }
            if (txtRefNo.Text != "")
            {
                counter = 0;
                DataGridViewRowCollection cal = gridsalesdelivary.Rows;
                for (int c = 0; c < cal.Count - 1; c++)
                {
                    DataGridViewRow currentRow1 = cal[c];
                    DataGridViewCellCollection cellCollection1 = currentRow1.Cells;
                    string itid = cellCollection1[0].Value.ToString();
                    if (ls.Contains(itid))
                    {
                        counter++;
                        continue;
                    }
                    counter++;
                    string que = cellCollection1[5].Value.ToString();
                    string quent = cellCollection1[6].Value.ToString();



                    string qurry = "select CurrentQuantity from ItemQuantityDetail where ItemId='" + itid + "'";
                    DataTable dt = d.getDetailByQuery(qurry);
                    string currid = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        currid = dr["CurrentQuantity"].ToString();
                    }
                    int currid1 = Convert.ToInt32(currid);
                    int quent1 = Convert.ToInt32(quent);
                    // int curentQuntity = Convert.ToInt32(que);
                    int cuentQuantity = Convert.ToInt32(currid);
                    if (currid1 <= quent1)
                    {
                        MessageBox.Show("please enter valid quantity ");
                        gridsalesdelivary.AllowUserToAddRows = true;
                        return;
                    }
                    crystalReportViewer2.Visible = false;
                    panel2.Visible = false;
                    // createnewsave();
                    //if (pnlSalesPayment.Visible == false)
                    //{
                    //    pnlSalesPayment.Visible = true;
                    //}

                    if (gridsalesdelivary.Rows.Count == 1)
                    {
                        // gridsalesorder.AllowUserToAddRows = true;
                        txtcustomercode.Focus();
                        MessageBox.Show("please select your customer id");
                    }

                    else if (ls.Count == gridsalesdelivary.Rows.Count - 1)
                    {
                        MessageBox.Show("please select your item id");
                        txtItemCode.Focus();
                        return;
                    }
                    else if (gridsalesdelivary.Rows.Count != null)
                    {
                        pnlSalesPayment.Visible = false;
                    }
                    else
                    {

                        if (ls.Count == gridsalesdelivary.Rows.Count - 1)
                        {
                            MessageBox.Show("Please Enter The Item");
                            txtItemCode.Focus();
                            txtItemCode.Select(txtItemCode.Text.Length, 0);
                            //return;//
                        }

                    }

                  
                }
            }
            pnlSalesPayment.Visible = true;
            CmbPageName.SelectedIndex = 0;
            CmbCompany.SelectedIndex = 0;
            CmbCardType.SelectedIndex = 0;
        }
        /*  gridsalesdelivary.AllowUserToAddRows = false;

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
                                        string insertQurry = "insert into SalesPaymentDetailes Values('" + txtInvoiceid.Text + "','" + CashAmount.Text + "','" + txtCreditAmount.Text + "','" + txtDebitBankName.Text + "','" + txtCardNumber.Text + "','" + CmbCardType.SelectedItem.ToString() + "','" + txtChequeAmount.Text + "','" + txtChequeBankName.Text + "','" + txtChequeNumber.Text + "','" + dateTimePicker1.Value.ToString() + "','" + txtEwalletAmount.Text + "','" + EWalletCompanyName.Text + "','" + txtTransactionNumber.Text + "','" + dateTimePicker2.Value.ToString() + "','" + txtCouponAmount.Text + "','" + CmbCompany.SelectedItem.ToString() + "','" + txtInvoiceAmount.Text + "','" + txtTotalAmount1.Text + "','" + txtBalance.Text + "','" + txtRturned.Text + "','" + txtNetAmount.Text + "')";
                                        int insertedRows = d.saveDetails(insertQurry);
                                        if (insertedRows > 0)
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
                             string insertQurry = "insert into SalesPaymentDetailes Values('" + txtInvoiceid.Text + "','" + CashAmount.Text + "','" + txtCreditAmount.Text + "','" + txtDebitBankName.Text + "','" + txtCardNumber.Text + "','" + CmbCardType.SelectedItem.ToString() + "','" + txtChequeAmount.Text + "','" + txtChequeBankName.Text + "','" + txtChequeNumber.Text + "','" + dateTimePicker1.Value.ToString() + "','" + txtEwalletAmount.Text + "','" + EWalletCompanyName.Text + "','" + txtTransactionNumber.Text + "','" + dateTimePicker2.Value.ToString() + "','" + txtCouponAmount.Text + "','" + CmbCompany.SelectedItem.ToString() + "','" + txtInvoiceAmount.Text + "','" + txtTotalAmount1.Text + "','" + txtBalance.Text + "','" + txtRturned.Text + "','" + txtNetAmount.Text + "')";
                                        int insertedRows = d.saveDetails(insertQurry);
                                        if (insertedRows > 0)
                                        {
                                             MessageBox.Show("details save not successfully");
                                          
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
          */

        //}
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
                    counter = 0;
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
                            if (ls.Contains(txtitemcode) && gridsalesdelivary.Rows[counter].DefaultCellStyle.Font != null)
                            {
                                counter++;
                                continue;
                            }
                            counter++;
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
                                counter = 0;
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
                                    if (ls.Contains(txtItemCode) && gridsalesdelivary.Rows[counter].DefaultCellStyle.Font != null)
                                    {
                                        counter++;
                                        continue;
                                    }
                                    counter++;
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
                        counter = 0;
                        DataGridViewRowCollection rowcollection = gridsalesdelivary.Rows;
                        List<string> show = new List<string>();
                        for (int a = 0; a < rowcollection.Count; a++)
                        {
                            DataGridViewRow currentrow = rowcollection[a];
                            DataGridViewCellCollection cellcollection = currentrow.Cells;
                            string txtitemcode = cellcollection[0].Value.ToString();
                            if (ls.Contains(txtitemcode) && gridsalesdelivary.Rows[counter].DefaultCellStyle.Font != null)
                            {
                                counter++;
                                continue;
                            }
                            counter++;
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
                                counter = 0;
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
                                    if (ls.Contains(txtItemCode) && gridsalesdelivary.Rows[counter].DefaultCellStyle.Font != null)
                                    {
                                        counter++;
                                        continue;
                                    }
                                    counter++;
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
                                        string insertQurry = "insert into SalesPaymentDetailes Values('" + txtInvoiceid.Text + "','" + CashAmount.Text + "','" + txtCreditAmount.Text + "','" + txtDebitBankName.Text + "','" + txtCardNumber.Text + "','" + CmbCardType.SelectedItem.ToString() + "','" + txtChequeAmount.Text + "','" + txtChequeBankName.Text + "','" + txtChequeNumber.Text + "','" + dateTimePicker1.Value.ToString() + "','" + txtEwalletAmount.Text + "','" + EWalletCompanyName.Text + "','" + txtTransactionNumber.Text + "','" + dateTimePicker2.Value.ToString() + "','" + txtCouponAmount.Text + "','" + CmbCompany.SelectedItem.ToString() + "','" + txtInvoiceAmount.Text + "','" + txtTotalAmount1.Text + "','" + txtBalance.Text + "','" + txtRturned.Text + "','" + txtNetAmount.Text + "')";
                                        int insertedRows = d.saveDetails(insertQurry);
                                        if (insertedRows > 0)
                                        {

                                            MessageBox.Show("details save successfully");
                                            panel2.Visible = true;
                                            DialogResult result = MessageBox.Show("Do you need to print Sales delivary", "Impotant questiuon", MessageBoxButtons.YesNo);
                                            if (result == System.Windows.Forms.DialogResult.Yes)
                                            {
                                                crystalReportViewer2.Visible = true;
                                                gridsalesdelivary.AllowUserToAddRows = false;
                                                //string a = "Data Source=DINESHTIWARI-PC\\SQLEXPRESS;Initial Catalog=SalesMaster;Integrated Security=True";
                                                SqlConnection con = d.openConnection();//new SqlConnection(a);
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
                                                return;
                                            }
                                            if (result == System.Windows.Forms.DialogResult.No)
                                            {
                                                crystalReportViewer2.Visible = false;
                                                panel2.Visible = false;
                                               // makeblank();
                                                makeblank();
                                                int value1 = Convert.ToInt32(txtSrNo.Text);
                                                int value2 = value1 + 1;
                                                txtSrNo.Text = value2.ToString();
                                                txtcustomercode.Focus();
                                                txtcustomercode.Select(txtcustomercode.Text.Length, 0);
                                                gridsalesdelivary.AllowUserToAddRows = true;
                                                butRemoveItem.Enabled = false;
                                                return;
                                            }
                                           
                                        }
                                    }
                                    else
                                    {
                                        gridsalesdelivary.AllowUserToAddRows = true;
                                       // MessageBox.Show("details save not successfully");


                                    }
                                }

                            }
                        }
                    }
                }
            }

           


            //}
       


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
                    int currid1 = Convert.ToInt32(currid);
                    int quent1 = Convert.ToInt32(quent);
                    // int curentQuntity = Convert.ToInt32(que);
                    int cuentQuantity = Convert.ToInt32(currid);
                   
                        int lastQuantity = cuentQuantity - quent1;
                        // int resivquenty = lastQuantity ;
                        // string currid1 = resivquenty.ToString();
                        string updateQurry = "update ItemQuantityDetail set CurrentQuantity='" + lastQuantity + "'where ItemId='" + itid + "'";
                        int insertedRows2 = d.saveDetails(updateQurry);
                    }
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
                        counter = 0;
                        DataGridViewRow currentrow = rowcollection[a];
                        DataGridViewCellCollection cellcollection = currentrow.Cells;
                        string txtitemcode = cellcollection[0].Value.ToString();
                        if (ls.Contains(txtitemcode) && gridsalesdelivary.Rows[counter].DefaultCellStyle.Font != null)
                        {
                            counter++;
                            continue;
                        }
                        counter++;
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

                        string insertquery1 = "update orderdetails set totalammount='"+txtTotalAmmount.Text+"', Discount='" + txtdiccount.Text + "',Discountamount='" + txtdicountamount.Text + "',Tax='" + txttax.Text + "',Taxamount='" + txttaxamount.Text + "',WithautTaxamount='" + txtwithauttaxamount.Text + "' where orderid='" + txtRefNo.Text + "'";
                        int insertrows1 = d.saveDetails(insertquery1);

                        if (insertrows1 > 0)
                        {
                            string insertQurry = "insert into SalesPaymentDetailes Values('" + txtInvoiceid.Text + "','" + CashAmount.Text + "','" + txtCreditAmount.Text + "','" + txtDebitBankName.Text + "','" + txtCardNumber.Text + "','" + CmbCardType.SelectedItem.ToString() + "','" + txtChequeAmount.Text + "','" + txtChequeBankName.Text + "','" + txtChequeNumber.Text + "','" + dateTimePicker1.Value.ToString() + "','" + txtEwalletAmount.Text + "','" + EWalletCompanyName.Text + "','" + txtTransactionNumber.Text + "','" + dateTimePicker2.Value.ToString() + "','" + txtCouponAmount.Text + "','" + CmbCompany.SelectedItem.ToString() + "','" + txtInvoiceAmount.Text + "','" + txtTotalAmount1.Text + "','" + txtBalance.Text + "','" + txtRturned.Text + "','" + txtNetAmount.Text + "')";
                            int insertedRows=d.saveDetails(insertQurry);
                            if (insertedRows > 0)
                            {
                                MessageBox.Show("details save successfully");

                                panel2.Visible = true;
                                DialogResult result = MessageBox.Show("Do you need to print Sales Delivary", "Impotant questiuon", MessageBoxButtons.YesNo);
                                if (result == System.Windows.Forms.DialogResult.Yes)
                                {
                                    crystalReportViewer2.Visible = true;
                                    gridsalesdelivary.AllowUserToAddRows = false;
                                   // string a = "Data Source=DINESHTIWARI-PC\\SQLEXPRESS;Initial Catalog=SalesMaster;Integrated Security=True";
                                    SqlConnection con = d.openConnection();//new SqlConnection(a);
                                   // con.Open();
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
                                    gridsalesdelivary.AllowUserToAddRows = true;
                                    crystalReportViewer2.Visible = false;
                                    panel2.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            gridsalesdelivary.AllowUserToAddRows = true;
                            //MessageBox.Show("details save not successfully");
                        }

                    }
                }
           // }
            makeblank();
            int value4 = Convert.ToInt32(txtSrNo.Text);
            int value3 = value4 + 1;
            txtSrNo.Text = value3.ToString();
            txtcustomercode.Focus();
            txtcustomercode.Select(txtcustomercode.Text.Length, 0);
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
            addToCartTable.Columns.Add(new DataColumn("CompnayName"));
            addToCartTable.Columns.Add(new DataColumn("MRP"));
            addToCartTable.Columns.Add(new DataColumn("Rate"));
            addToCartTable.Columns.Add(new DataColumn("Quantity"));
            addToCartTable.Columns.Add(new DataColumn("DelivaryQuantity"));
            addToCartTable.Columns.Add(new DataColumn("Amount"));
        }

        private void ButSelectPurchaseOrder_Click(object sender, EventArgs e)
        {
            counter = 2;
            panel2.Visible = true;
            dataGridView2.AllowUserToAddRows = true;
            pnlSalesPayment.Visible = false;
            crystalReportViewer2.Visible = false;
            string selectqurry = "select  orderdetails.orderid as[Orderr ID],orderdetails.custid as [Customer ID], CustomerDetails.CustName as[Customer Name], CustomerDetails.CustAddress as[Customer Address],CustomerDetails.CustCompName as[Customer Compnay Name],orderdetails.date as [Date],(select Sum(customerorderdescriptions.quantity)as [Quantity] from customerorderdescriptions where customerorderdescriptions.orderid= orderdetails.orderid) as[Bild Quanity],orderdetails.WithautTaxamount as[Withaut Tax Amount],orderdetails.Discount as [Discount],orderdetails.Discountamount as [Discount Amount],orderdetails.Tax,orderdetails.Taxamount as [Tax Amount],orderdetails.totalammount as[Total Amount] from orderdetails join CustomerDetails on CustomerDetails.custId=orderdetails.custid";
            string selectqurryForActualColumnName = "select top 1 orderdetails.orderid ,orderdetails.custid , CustomerDetails.CustName, CustomerDetails.CustAddress ,CustomerDetails.CustCompName ,orderdetails.date ,(select Sum(customerorderdescriptions.quantity) from customerorderdescriptions where customerorderdescriptions.orderid= orderdetails.orderid) as [Builed Quantity],orderdetails.WithautTaxamount,orderdetails.Discount,orderdetails.Discountamount,orderdetails.Tax,orderdetails.Taxamount ,orderdetails.totalammount from orderdetails join CustomerDetails on CustomerDetails.custId=orderdetails.custid";
            DataTable dt = d.getDetailByQuery(selectqurry);
            DataTable dtOnlyColumnName = d.getDetailByQuery(selectqurryForActualColumnName);
            DataTable customDataTable = new DataTable();
            customDataTable.Columns.Add("ActualTableColumnName");
            customDataTable.Columns.Add("AliasTableColumnName");
            //List<string> ls = new List<string>();
            DataColumnCollection d1 = dt.Columns;
            DataColumnCollection dataColumnForName = dtOnlyColumnName.Columns;
            for (int a = 0; a < d1.Count; a++)
            {
                //DataColumn dc = new DataColumn();
                string b = d1[a].ToString();
                string actualColumnName = dataColumnForName[a].ToString();
                DataRow dr = customDataTable.NewRow();
                dr["ActualTableColumnName"] = actualColumnName;
                dr["AliasTableColumnName"] = b;
                customDataTable.Rows.Add(dr);
                //  ls.Add(b);
            }

            comsearchvalue.DataSource = customDataTable;
            comsearchvalue.ValueMember = "ActualTableColumnName";
            comsearchvalue.DisplayMember = "AliasTableColumnName";
            dataGridView2.DataSource = dt;
            comsearchvalue.Focus();
            txtcustomercode.TabStop = false;
            butcustomercode.TabStop = false;
          //  addToCartTable.Columns.RemoveAt(6);
            if (!addToCartTable.Columns.Contains("ResivQuantity"))
            {
                addToCartTable.Columns.Add(new DataColumn("ResivQuantity"));
               // addToCartTable.Columns.RemoveAt(6);
            }

            if (!addToCartTable.Columns.Contains("Amount"))
            {
                addToCartTable.Columns.Add(new DataColumn("Amount"));
            }
           

        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if ((txtQuantity.Text == "") || (txtQuantity.Text == "0"))
                {
                   
                    MessageBox.Show("please select your correct quantity");
                    txtQuantity.Text = "1";
                    txtQuantity.Select(txtQuantity.Text.Length, 0);
                    txtQuantity.Focus();
                }
                else
                {
                    butAddItem.Focus();
                }
              

            }

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }


            else
            {
                if (e.KeyChar == '\b')
                {
                    txtQuantity.Focus();
                    butAddItem.Enabled = true;
                    txtAmmount.Text = "";
                    txtQuantity.Text = "";
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
            if (!txtcustomercode.Text.StartsWith("C"))
            {
                txtcustomercode.Text = string.Concat("C", txtcustomercode.Text);
                txtcustomercode.Select(txtcustomercode.Text.Length, 0);
            }
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
            //if (txtRefNo.Text == "")
            //{
            //    string itemid = gridsalesdelivary.Rows[e.RowIndex].Cells[0].Value.ToString();
            //    string selectqurry = "select Ids.ItemName,Ids.ItemCompName,ipd.MrpPrice, ipd.SalesPrice from ItemDetails Ids  join ItemPriceDetail ipd on Ids.ItemId=ipd.ItemId  where Ids.ItemId='" + itemid + "'";
            //    DataTable dt = d.getDetailByQuery(selectqurry);
            //    string rate = "";
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        gridsalesdelivary.Rows[e.RowIndex].Cells[1].Value = dr[0].ToString();
            //        gridsalesdelivary.Rows[e.RowIndex].Cells[2].Value = dr[1].ToString();
            //        gridsalesdelivary.Rows[e.RowIndex].Cells[3].Value = dr[2].ToString();
            //        // gridPurchaseOrder.Rows[e.RowIndex].Cells[5].Value=dr[3].ToString();

            //        rate = dr[3].ToString();
            //    }
            //    if (rate != "")
            //    {
            //        if (gridsalesdelivary.Rows[e.RowIndex].Cells[0].Value != null)
            //        {
            //            int co = gridsalesdelivary.CurrentRow.Index;
            //            DataGridViewRow selectedRow = gridsalesdelivary.Rows[0];
            //            selectedRow.Selected = true;
            //            selectedRow.Cells[4].Selected = true;
            //            //gridPurchaseOrder.CurrentCell = gridPurchaseOrder[gridPurchaseOrder.CurrentCell.ColumnIndex + 2, gridPurchaseOrder.CurrentCell.RowIndex];
            //            //gridPurchaseOrder.Focus();
            //        }
            //        gridsalesdelivary.Rows[e.RowIndex].Cells[4].Value = rate;
            //        string quantity = gridsalesdelivary.Rows[e.RowIndex].Cells[5].Value.ToString();
            //        if (quantity == "")
            //        {
            //            quantity = "0";
            //        }
            //        int q1 = Convert.ToInt32(quantity);
            //        Double rate1 = Convert.ToDouble(rate);
            //        Double price = rate1 * q1;
            //        if (price.ToString() == "")
            //        {
            //            price = 0;
            //        }
            //        gridsalesdelivary.Rows[e.RowIndex].Cells[6].Value = price.ToString();
            //        Double totalammount = Convert.ToDouble(txtTotalAmmount.Text);
            //        Double toat = totalammount + price;
            //        txtTotalAmmount.Text = toat.ToString();
            //    }
            //    else
            //    {
            //        MessageBox.Show("please select your correct row");
            //    }
            //}


            if (txtRefNo.Text != "")
            {
                string id = gridsalesdelivary.Rows[e.RowIndex].Cells[0].Value.ToString();
                string a1 = gridsalesdelivary.Rows[e.RowIndex].Cells[6].Value.ToString();
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
                    double quantity = Convert.ToDouble(a1);
                    if (quantity < g)
                    {
                        string a = gridsalesdelivary.Rows[e.RowIndex].Cells[6].Value.ToString();
                        string rate = gridsalesdelivary.Rows[e.RowIndex].Cells[4].Value.ToString();
                        quantity = Convert.ToInt32(a);
                        double r = Convert.ToDouble(rate);
                        double totalammount = quantity * r;
                        gridsalesdelivary.Rows[e.RowIndex].Cells[7].Value = totalammount.ToString();
                        //string newquantity = gridsalesdelivary.Rows[e.RowIndex].Cells[3].Value.ToString();
                        string rate1 = gridsalesdelivary.Rows[e.RowIndex].Cells[4].Value.ToString();
                        double quantity1 = Convert.ToDouble(a);
                        double finalquantity = Convert.ToDouble(rate1);
                        finalquantity = quantity1 - quantity;
                        double totalq = quantity1 * finalquantity;
                        double totalammount1 = Convert.ToDouble(txtTotalAmmount.Text);
                        double t = totalammount1 + totalq;
                        txtTotalAmmount.Text = totalammount.ToString();

                        double totalValues = 0.0;

                        foreach (DataGridViewRow row in gridsalesdelivary.Rows)
                        {
                            gridsalesdelivary.AllowUserToAddRows = false;
                            string amountValue = row.Cells[row.Cells.Count - 1].Value.ToString();
                            totalValues += Convert.ToDouble(amountValue);


                        }
                        txtTotalAmmount.Text = totalValues.ToString("###0.00");
                    }
                    else if (quantity > g)
                    {
                        MessageBox.Show("Quantity is not available");
                        gridsalesdelivary.Rows[e.RowIndex].Cells[6].Value = s.ToString();
                        int g1 = Convert.ToInt32(s);
                        double quantity1 = Convert.ToDouble(a1);
                        string a = gridsalesdelivary.Rows[e.RowIndex].Cells[6].Value.ToString();
                        string rate = gridsalesdelivary.Rows[e.RowIndex].Cells[4].Value.ToString();
                        quantity = Convert.ToInt32(a);
                        double r = Convert.ToDouble(rate);
                        double totalammount = quantity * r;
                        gridsalesdelivary.Rows[e.RowIndex].Cells[7].Value = totalammount.ToString();
                        //string newquantity = gridsalesdelivary.Rows[e.RowIndex].Cells[3].Value.ToString();
                        string rate1 = gridsalesdelivary.Rows[e.RowIndex].Cells[4].Value.ToString();
                        double quantity2 = Convert.ToDouble(a);
                        double finalquantity = Convert.ToDouble(rate1);
                        finalquantity = quantity2 - quantity;
                        double totalq = quantity2 * finalquantity;
                        double totalammount1 = Convert.ToDouble(txtTotalAmmount.Text);
                        double t = totalammount1 + totalq;
                        txtTotalAmmount.Text = totalammount.ToString();

                        double totalValues = 0.0;

                        //txtAmmount.Text = "0";

                    }
                    else
                    {
                        MessageBox.Show("please select your correct row");
                        gridsalesdelivary.Rows[e.RowIndex].Cells[0].Value = "";
                    }
                    gridsalesdelivary.AllowUserToAddRows = true;

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
                txtItemCode.Enabled = true;
                txtItemCode.Focus();
                gridsalesdelivary.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                txtItemCode.TabIndex = 1;
                butSaveButton.TabStop = true;
                ButSelectPurchaseOrder.TabStop = true;
                butClose.TabStop = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                Color backGroundColor=gridsalesdelivary.DefaultCellStyle.SelectionBackColor;
                
               
                if (backGroundColor.Name == "DodgerBlue" || backGroundColor.Name =="Highlight")
                {
                    MessageBox.Show("Please select your remove button");
                    return;
                }

                if (txtRefNo.Text == "")
                {
                    string itemId = "";
                    if (addToCartTable.Rows.Count > 0)
                    {
                        string val = "";
                        int index = gridsalesdelivary.SelectedRows[0].Index;
                        itemId = gridsalesdelivary.Rows[index - 1].Cells[0].Value.ToString();
                        if ((!ls.Contains(itemId)) || (gridsalesdelivary.Rows[index - 1].DefaultCellStyle.Font == null))
                        {
                            int currentrow = gridsalesdelivary.CurrentRow.Index;
                            string Amount = gridsalesdelivary.Rows[currentrow - 1].Cells[6].Value.ToString();
                            double totalAmount = Convert.ToDouble(txtTotalAmmount.Text);
                            totalAmount -= Convert.ToDouble(Amount.Trim());
                            double withauttax = Convert.ToDouble(txtwithauttaxamount.Text);
                            withauttax -= Convert.ToDouble(Amount.Trim());
                            txtTotalAmmount.Text = totalAmount.ToString();
                            txtwithauttaxamount.Text = withauttax.ToString();
                            //addToCartTable.Rows.RemoveAt(index-1);
                            gridsalesdelivary.Rows[index - 1].DefaultCellStyle.Font = new Font(new FontFamily("Microsoft Sans Serif"), 9.00F, FontStyle.Strikeout);
                            gridsalesdelivary.Rows[index - 1].DefaultCellStyle.ForeColor = Color.Red;


                            ls.Add(itemId);


                            gridsalesdelivary.DataSource = addToCartTable;


                            if (ls.Count == gridsalesdelivary.Rows.Count - 1)
                            {
                                // 
                                //txtItemCode.Enabled= true;
                                gridsalesdelivary.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                                txtItemCode.Focus();
                                butRemoveItem.Enabled = false;
                                // MessageBox.Show("Please select your remove button");

                            }
                        }

                        else if ((!ls.Contains(itemId)) || (gridsalesdelivary.Rows[index - 1].DefaultCellStyle.Font != null))
                        {
                            MessageBox.Show("Item already deleted!");
                            return;
                        }
                       
                       
                    }
                     
                  
                   
                   
                }
            }
                if (txtRefNo.Text != "")
                {
                    Color backGroundColor1 = gridsalesdelivary.DefaultCellStyle.SelectionBackColor;


                    if (backGroundColor1.Name == "DodgerBlue" || backGroundColor1.Name == "Highlight")
                    {
                        MessageBox.Show("Please select your remove button");
                        return;
                    }
                    if (addToCartTable.Rows.Count > 0)
                    {
                        string val = "";
                        gridsalesdelivary.AllowUserToAddRows = true;
                        int index = gridsalesdelivary.SelectedRows[0].Index;
                        string itemId = gridsalesdelivary.Rows[index - 1].Cells[0].Value.ToString();
                        if ((!ls.Contains(itemId)) || (gridsalesdelivary.Rows[index - 1].DefaultCellStyle.Font == null))
                        {
                            int currentrow = gridsalesdelivary.CurrentRow.Index;
                            string Amount = gridsalesdelivary.Rows[currentrow - 1].Cells[7].Value.ToString();
                            double totalAmount = Convert.ToDouble(txtTotalAmmount.Text);
                            totalAmount -= Convert.ToDouble(Amount.Trim());
                            double withauttax = Convert.ToDouble(txtwithauttaxamount.Text);
                            withauttax -= Convert.ToDouble(Amount.Trim());
                            txtTotalAmmount.Text = totalAmount.ToString();
                            txtwithauttaxamount.Text = withauttax.ToString();

                            //addToCartTable.Rows.RemoveAt(index-1);
                            gridsalesdelivary.Rows[index - 1].DefaultCellStyle.Font = new Font(new FontFamily("Microsoft Sans Serif"), 9.00F, FontStyle.Strikeout);
                            gridsalesdelivary.Rows[index - 1].DefaultCellStyle.ForeColor = Color.Red;
                            // I44

                            ls.Add(itemId);

                            gridsalesdelivary.DataSource = addToCartTable;


                            if (addToCartTable.Rows.Count == 0)
                            {
                                txtTotalAmmount.Text = "0.0";
                                txtcst.Text = "0.0";
                            }
                            if (ls.Count == gridsalesdelivary.Rows.Count - 1)
                            {
                                MessageBox.Show("Item already deleted");
                                txtItemCode.Enabled = true;
                                txtItemCode.Focus();
                            }

                            if (gridsalesdelivary.Rows.Count > 0)
                            {
                                butRemoveItem.Enabled = true;
                                gridsalesdelivary.Rows[gridsalesdelivary.Rows.Count - 1].Selected = false;

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
                        else if ((!ls.Contains(itemId)) || (gridsalesdelivary.Rows[index - 1].DefaultCellStyle.Font != null))
                        {
                            MessageBox.Show("Item already deleted!");
                            return;
                        }
                   

                    }
                   
                  
                }
               
            }
        //}

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
            string select = "select CurrentQuantity from ItemQuantityDetail where itemid='" + txtItemCode.Text + "'";
            DataTable dt1 = d.getDetailByQuery(select);
            string s = "";

            foreach (DataRow dr in dt1.Rows)
            {
                s = dr[0].ToString();

            }
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    txtProductName.Text = "";
                    txtRate.Text = "";
                    txtQuantity.Text = "";
                    txtAmmount.Text = "";
                    butAddItem.Enabled = false;
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            txtQuantity.ReadOnly = true;
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (s == "")
                {
                    s = "0";
                }
                if (txtcustomercode.Text == "C")
                {
                    MessageBox.Show("Please enter the customer code first");
                    txtItemCode.Text = "I";
                    txtcustomercode.Focus();
                    return;
                }
                if (txtItemCode.Text == "I")
                {
                    MessageBox.Show("please enter the itemcode");
                    txtQuantity.ReadOnly = true;
                    txtItemCode.Focus();
                    return;
                }



                double quantity = Convert.ToDouble(s);
                // double q = Convert.ToDouble(txtQuantity.Text + "");
                if (quantity== 0)
                {
                    MessageBox.Show("quantity not available");
                    txtQuantity.Text = "";
                    txtAmmount.Text = "";
                }
                else
                {


                    //double qu=Convert.ToDouble(txtQuantity.Text);
                    string selectquery1 = "select i.ItemId,i.ItemName,cast(ip.SalesPrice as numeric(38,2)),iq.CurrentQuantity from ItemDetails i join ItemPriceDetail ip on i.ItemId=ip.ItemId join ItemQuantityDetail iq on ip.ItemId=iq.ItemId where i.ItemId='" + txtItemCode.Text + "'";
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
                            
                            txtQuantity.Text = "1";
                            if (txtQuantity.Text == "")
                            {
                                txtQuantity.Text = "0";
                            }
                            quantity = Convert.ToDouble(txtQuantity.Text);
                            double rate = Convert.ToDouble(txtRate.Text);
                            txtAmmount.Text = (quantity * rate).ToString("###0.00");
                            txtQuantity.ReadOnly = false;
                            butAddItem.Enabled = true;
                            //tab6();
                        }
                    }




                    else
                    {
                        txtProductName.Text = "";
                        txtRate.Text = "";
                        txtQuantity.ReadOnly = true; ;
                        txtQuantity.Text = "";
                        txtAmmount.Text = "";
                        butAddItem.Enabled = false;

                    }

                    txtQuantity.Enabled = true;
                    tab2();
                    butSaveButton.TabStop = false;
                    ButSelectPurchaseOrder.TabStop = false;
                    butClose.TabStop = false;

                }
               

            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                if (gridsalesdelivary.Rows.Count > 0)
                {
                    txtItemCode.Focus();
                }

                else
                {
                    butSaveButton.Focus();
                    butClose.Enabled= true;
                }
            }


            string selectquery2 = "select i.ItemId,i.ItemName,cast(ip.MrpPrice as numeric(38,2)),iq.CurrentQuantity from ItemDetails i join ItemPriceDetail ip on i.ItemId=ip.ItemId join ItemQuantityDetail iq on ip.ItemId=iq.ItemId where i.ItemId='" + txtItemCode.Text + "'";
            DataTable dt2 = d.getDetailByQuery(selectquery2);
            if (dt2.Rows.Count > 0)
            {

            }
            else if (e.KeyChar == (char)Keys.Enter && dt2.Rows != null && dt2 != null && txtcustomercode.Text == "C")
            {

                MessageBox.Show("please enter the customercode");
                txtcustomercode.Focus();
                //txtitemcode.Focus();
                //MessageBox.Show("Please select your item id");
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
                string selectQuery2 = "select  orderdetails.orderid as[Orderr ID],orderdetails.custid as [Customer ID], CustomerDetails.CustName as[Customer Name], CustomerDetails.CustAddress as[Customer Address],CustomerDetails.CustCompName as[Customer Compnay Name],orderdetails.date as [Date],(select Sum(customerorderdescriptions.quantity)as [Quantity] from customerorderdescriptions where customerorderdescriptions.orderid= orderdetails.orderid) as[Bild Quanity],orderdetails.WithautTaxamount as[Withaut Tax Amount],orderdetails.Discount as [Discount],orderdetails.Discountamount as [Discount Amount],orderdetails.Tax,orderdetails.Taxamount as [Tax Amount],orderdetails.totalammount as[Total Amount] from orderdetails join CustomerDetails on CustomerDetails.custId=orderdetails.custid where " + val2 + " like '" + txtsearchvalue.Text + "%'";
                DataTable dt2 = d.getDetailByQuery(selectQuery2);
                dataGridView2.DataSource = dt2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtcustomercode.Text=="C")
            {
                txtcustomercode.Focus();
                butcustomercode.TabStop = true;
                txtcustomercode.TabStop = true;
            }
            else if (txtItemCode.Text == "I")
            {
                txtItemCode.Focus();
                butitembutton.TabStop = true;
                txtItemCode.TabStop = true;
            }
            else if(txtItemCode.Text!="I")
            {
                txtQuantity.Focus();
            }
            panel2.Visible = false;
        }
        private void SetVendor(string r)
        {
            DataTable dt = d.getDetailByQuery(r);
            foreach (DataRow dr in dt.Rows)
            {
                txtcustomercode.Text = dr[0].ToString();
                txtCustomerName.Text = dr[1].ToString();
                txtAddress.Text = dr[2].ToString();
                txtAddress.Text = dr[3].ToString();
                txtPhone.Text = dr[4].ToString();
                txtMobile.Text = dr[5].ToString();
                txtFax.Text = dr[6].ToString();
            }
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
                txtQuantity.Enabled = true;
                txtQuantity.ReadOnly = false;
            }
            if (counter == 2)
            {
                panel2.Visible = false;
                addToCartTable.Columns.RemoveAt(6);
                if (!addToCartTable.Columns.Contains("ResivQuantity"))
                {
                    addToCartTable.Columns.Add(new DataColumn("ResivQuantity"));
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
                    txtRefNo.Text = s;
                    //MessageBox.Show(" "+s +" "+s1);
                    string selectqurry = "select custId,CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from CustomerDetails where custId='" + s1 + "'";
                    SetVendor(selectqurry);

                  string selectqurry1 = "select cod.ItemId,td.ItemName,td.ItemCompName,ipq.MrpPrice,cod.Quantity,cod.Price,cod.totalammount,od.totalammount from orderdetails od join customerorderdescriptions cod on od.Orderid=cod.Orderid join ItemDetails td on td.ItemId=cod.ItemId join ItemPriceDetail ipq on td.ItemId=ipq.ItemId where od. Orderid ='" + s + "'";
                   DataTable dt2 = d.getDetailByQuery(selectqurry1);
                    int totalRowCount = addToCartTable.Rows.Count;
                    for (int rowCount = 0; rowCount < totalRowCount; rowCount++)
                    {
                        addToCartTable.Rows.RemoveAt(0);
                    }
                    double totel1 = 0;
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
                        //if (txtitemNmae == "")
                        //{
                        //    txtitemNmae ="0";
                        //}

                        double amt = Convert.ToDouble(txtitemNmea);
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
                    gridsalesdelivary.DataSource = addToCartTable;
                    txtTotalAmmount.Text = totel1.ToString("###0.00");

                }

            }

        }

        private void dataGridView2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            txtItemCode.Focus();
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
                        txtQuantity.ReadOnly = false;
                    }
                }
                    if (counter == 2)
                    {

                        string itemid = "";
                        string quntity = "";
                        string rate = "";
                        string prise = "";
                        foreach (DataRow dr3 in addToCartTable.Rows)
                        {
                            counter = 0;
                            int q3 = 0;
                            //itemid = dr3[0].ToString();
                            string itid = dr3[0].ToString();
                            if (ls.Contains(itid) && gridsalesdelivary.Rows[counter].DefaultCellStyle.Font != null)
                            {
                                counter++;
                                continue;
                            }
                            counter++;
                            quntity = dr3[5].ToString();
                            rate = dr3[4].ToString();
                            prise = dr3[6].ToString();
                            if (itid == txtItemCode.Text)
                            {
                                if (quntity == "")
                                {
                                    quntity = "0";
                                }
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
                                txtTotalAmmount.Text = rate5.ToString("###0.00");//rate3.ToString();
                                // MessageBox.Show("Please Enter the Quanity");
                                txtItemCode.Text = "I";
                                txtProductName.Text = "";
                                txtRate.Text = "";
                                txtQuantity.Text = "";
                                txtAmmount.Text = "";
                                txtQuantity.ReadOnly = true;
                                //addToCartTable.Columns.Add("Qtuhjh");
                                // ls1.Add(itemid);

                            }
                        }

                          panel2.Visible = false;
                         // int currentIndex = dataGridView2.CurrentRow.Index;
                            addToCartTable.Columns.RemoveAt(6);
                            if (!addToCartTable.Columns.Contains("ResivQuantity")) 
                            {
                                addToCartTable.Columns.Add(new DataColumn("ResivQuantity"));
                                addToCartTable.Columns.RemoveAt(6);
                            }

                            if (!addToCartTable.Columns.Contains("Amount"))
                            {
                                addToCartTable.Columns.Add(new DataColumn("Amount"));
                            }

                            DataGridViewCellCollection CellCollection = dataGridView2.Rows[currentIndex -1].Cells;
                            if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                            {
                                string s = CellCollection[0].Value.ToString();
                                string s1 = CellCollection[1].Value.ToString();
                                txtRefNo.Text = s;
                                //MessageBox.Show(" "+s +" "+s1);
                                string selectqurry = "select custId,CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from CustomerDetails where custId='" + s1 + "'";
                                SetVendor(selectqurry);

                                string selectqurry1 = "select cod.ItemId,td.ItemName,td.ItemCompName,ipq.MrpPrice,cod.Quantity,cod.Price,cod.totalammount,od.totalammount from orderdetails od join customerorderdescriptions cod on od.Orderid=cod.Orderid join ItemDetails td on td.ItemId=cod.ItemId join ItemPriceDetail ipq on td.ItemId=ipq.ItemId where od. Orderid ='" + s + "'";
                                DataTable dt2 = d.getDetailByQuery(selectqurry1);
                                int totalRowCount = addToCartTable.Rows.Count;
                                for (int rowCount = 0; rowCount < totalRowCount; rowCount++)
                                {
                                    addToCartTable.Rows.RemoveAt(0);
                                }
                                double totel1 = 0;
                                for (int c = 0; c < dt2.Rows.Count; c++)
                                {
                                    DataRow dr2 = dt2.Rows[c];
                                    string txtItem = dr2[0].ToString();
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
                                    dr2[0] = txtItem.Trim();
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
                                gridsalesdelivary.DataSource = addToCartTable;
                                txtTotalAmmount.Text = totel1.ToString("###0.00");
                                txtwithauttaxamount.Text = totel1.ToString("###0.00");
                            
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
                butRemoveItem.Enabled = true;
                addToCartTable.Columns.RemoveAt(6);
                if (!addToCartTable.Columns.Contains("ResivQuantity"))
                {
                    addToCartTable.Columns.Add(new DataColumn("ResivQuantity"));
                }
                if (!addToCartTable.Columns.Contains("Amount"))
                {
                    addToCartTable.Columns.Add(new DataColumn("Amount"));
                }
               
                txtRefNo.ReadOnly = true;
                string selectquery2 = "select Orderid from salesOrderDelivery where Orderid='" + txtRefNo.Text + "'";
                DataTable dt1 = d.getDetailByQuery(selectquery2);
                if (dt1 != null && dt1.Rows != null && dt1.Rows.Count > 0)
                {
                    
                    MessageBox.Show("order details is completed");
                    butRemoveItem.Enabled = false;
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
                    addToCartTable.Columns.RemoveAt(6);
                    if (!addToCartTable.Columns.Contains("ResivQuantity"))
                    {
                        addToCartTable.Columns.Add(new DataColumn("ResivQuantity"));
                        addToCartTable.Columns.RemoveAt(6);
                    }
                    if (!addToCartTable.Columns.Contains("Amount"))
                    {
                        addToCartTable.Columns.Add(new DataColumn("Amount"));
                    }
                    butSaveButton.Visible = true;
                    string select = "select vo.orderid,vo.custid,vod.ItemId,vo.Discount from orderdetails vo join customerorderdescriptions vod on vod.Orderid=vo.Orderid where vo.Orderid ='" + txtRefNo.Text + "'";
                    DataTable dt = d.getDetailByQuery(select);
                    string a = "";
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
                        string selectItem = "select cod.ItemId,ad.ItemName,ad.ItemCompName,cast(ipd.MrpPrice as numeric(38,2)),cast(cod.price as numeric(38,2)),cod.quantity,cast(cod.totalammount as numeric(38,2)) from orderdetails od join customerorderdescriptions cod on od.orderid=cod.orderid join ItemDetails ad on cod.ItemId=ad.ItemId join ItemPriceDetail ipd on ad.ItemId=ipd.ItemId where od.orderid='" + txtRefNo.Text + "'";
                        DataTable dt3 = d.getDetailByQuery(selectItem);
                        int totalrowcount = addToCartTable.Rows.Count;
                        for (int rowcount = 0; rowcount < totalrowcount; rowcount++)
                        {
                            addToCartTable.Rows.RemoveAt(0);
                        }

                        double totel = 0;

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
                            double amt = Convert.ToDouble(ammount);
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
                        txtTotalAmmount.Text = totel.ToString("###0.00");
                        txtwithauttaxamount.Text = totel.ToString("###0.00");

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
                    butRemoveItem.Enabled = false;
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



        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            if (Char.IsLetterOrDigit(e.KeyChar)||e.KeyChar=='.')
            {
                e.Handled = false;
            }
            else
            {
                if (txtRefNo.Text == "")
                {
                    double totalAmount = 0.00;
                    counter = 0;
                    if (e.KeyChar == '\b')
                    {
                        foreach (DataRow dr in addToCartTable.Rows)
                        {
                            string itemid = dr[0].ToString();
                            if (ls.Contains(itemid) && gridsalesdelivary.Rows[counter].DefaultCellStyle.Font != null)
                            {
                                counter++;
                                continue;
                            }
                            counter++;
                            totalAmount += Convert.ToDouble(dr[6].ToString());
                        }
                        double s1 = totalAmount;
                        txtTotalAmmount.Text = s1.ToString("###0.00");
                        txtdicountamount.Text = "0";
                        txtwithauttaxamount.Text = s1.ToString();
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
                    double totalAmount = 0.00;
                    counter = 0;
                    if (e.KeyChar == '\b')
                    {
                        counter = 0;
                        foreach (DataRow dr in addToCartTable.Rows)
                        {

                            string itemid = dr[0].ToString();
                            if (ls.Contains(itemid) && gridsalesdelivary.Rows[counter].DefaultCellStyle.Font != null)
                            {
                                counter++;
                                continue;
                            }
                            totalAmount += Convert.ToDouble(dr[7].ToString());
                            counter++;
                        }
                        double s = totalAmount;
                        txtTotalAmmount.Text = s.ToString("###0.00");
                        txtdicountamount.Text = "0";
                        txtwithauttaxamount.Text = s.ToString();
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
                    totalAmount += Convert.ToDouble(dr[6].ToString());
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
                double withauttax1 = total1 - dis3;

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
        private void pnlSalesPayment_Paint_1(object sender, PaintEventArgs e)
        {
            txtInvoiceid.Text = txtSrNo.Text;
            txtInvoiceAmount.Text = txtTotalAmmount.Text + .00;
        }
        private void CashAmount_Leave_1(object sender, EventArgs e)
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

        private void txtCreditAmount_Leave_1(object sender, EventArgs e)
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

        private void txtChequeAmount_Leave_1(object sender, EventArgs e)
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

        private void txtEwalletAmount_Leave_1(object sender, EventArgs e)
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

        private void txtCouponAmount_Leave_1(object sender, EventArgs e)
        {
            if (txtCouponAmount.Text == "")
            {
                txtCouponAmount.Text = "0.00";
            }
            if (txtCouponAmount.Text != "0.00")
            {
                string amount = txtCouponAmount.Text + ".00";
                //txtCouponAmount.Text = amount;
                Double Amount = Convert.ToDouble(txtCreditAmount.Text);
                Double Amount1 = Convert.ToDouble(CashAmount.Text);
                Double Amount3 = Convert.ToDouble(txtChequeAmount.Text);
                Double Amount4 = Convert.ToDouble(txtEwalletAmount.Text);
                Double Amount5 = Convert.ToDouble(txtCouponAmount.Text);
                Double amount2 = Amount + Amount1 + Amount3 + Amount4 + Amount5;
                string Amount2 = amount2.ToString();
                txtTotalAmount1.Text = Amount2 + ".00";
            }
        }

        private void txtTotalAmount1_TextChanged_1(object sender, EventArgs e)
        {
            txtNetAmount.Text = txtTotalAmount1.Text;
            Double Amount = Convert.ToDouble(txtTotalAmount1.Text);
            Double Amount1 = Convert.ToDouble(txtInvoiceAmount.Text);
            Double Amount2 = Amount1 - Amount;
            string Amount3 = Amount2.ToString();
            txtBalance.Text = Amount2 + ".00";
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            createnewsave();
            pnlSalesPayment.Visible = false;
            crystalReportViewer2.Visible = true;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            pnlSalesPayment.Visible = false;
            panel2.Visible = false;
        }

        private void txtdiccount_TextChanged(object sender, EventArgs e)
        {
            txtdiccount.Select(txtdiccount.Text.Length, 0);
            if (txtRefNo.Text == "")
            {
                double totalAmount = 0.00;
                counter = 0;
                //discountamount.Text = disa.ToString();
                foreach (DataRow dr in addToCartTable.Rows)
                {

                    string itemid = dr[0].ToString();
                    if (ls.Contains(itemid) && gridsalesdelivary.Rows[counter].DefaultCellStyle.Font != null)
                    {
                        counter++;
                        continue;
                    }
                    counter++;
                    totalAmount += Convert.ToDouble(dr[6].ToString());
                   
                }
                double s = totalAmount;

                string discount = txtdiccount.Text;


                double amount = 0;
               

                if (double.TryParse(discount, out amount))
                {
                    double totaldiscount = Convert.ToDouble(discount);
                    totalAmount = totalAmount - ((totalAmount * totaldiscount) / 100);
                    txtTotalAmmount.Text = totalAmount.ToString("###0.00");
                    txtwithauttaxamount.Text = s.ToString();
                    double dis = s * totaldiscount / 100;
                    txtdicountamount.Text = dis.ToString("###0.00");
                   // txtdiccount.Text = totaldiscount.ToString("###0.00");

                }
            }


            if (txtRefNo.Text != "")
            {
                double totalAmount = 0.00;
               
                counter = 0;
                foreach (DataRow dr in addToCartTable.Rows)
                {
                    string itemid = dr[0].ToString();
                    if (ls.Contains(itemid) && gridsalesdelivary.Rows[counter].DefaultCellStyle.Font != null)
                    {
                        counter++;
                        continue;
                    }
                    totalAmount += Convert.ToDouble(dr[7].ToString());
                    counter++;
                }
                double s1 = totalAmount;
                string discount1 = txtdiccount.Text;


                double amount1 =0;

                if (double.TryParse(discount1, out amount1))
                {
                    double totaldiscount = Convert.ToDouble(discount1);
                    totalAmount = totalAmount - ((totalAmount * totaldiscount) / 100);
                    txtTotalAmmount.Text = totalAmount.ToString("###0.00");
                    txtwithauttaxamount.Text = s1.ToString();
                    double dis = s1 * totaldiscount / 100;
                    txtdicountamount.Text = dis.ToString();

                }
            }

        }

       

        public Color Highlight { get; set; }

        private void txtdiccount_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtdiccount.Text == "0.00")
            {
                txtdiccount.Text = "";
            }
        }

        private void txtdiccount_Leave(object sender, EventArgs e)
        {
            txtdiccount.Select(txtdiccount.Text.Length, 0);
            if (txtRefNo.Text == "")
            {
                double totalAmount = 0.00;
                counter = 0;
                //discountamount.Text = disa.ToString();
                foreach (DataRow dr in addToCartTable.Rows)
                {

                    string itemid = dr[0].ToString();
                    if (ls.Contains(itemid) && gridsalesdelivary.Rows[counter].DefaultCellStyle.Font != null)
                    {
                        counter++;
                        continue;
                    }
                    counter++;
                    totalAmount += Convert.ToDouble(dr[6].ToString());

                }
                double s = totalAmount;

                string discount = txtdiccount.Text;


                double amount = 0;


                if (double.TryParse(discount, out amount))
                {
                    double totaldiscount = Convert.ToDouble(discount);
                    totalAmount = totalAmount - ((totalAmount * totaldiscount) / 100);
                    txtTotalAmmount.Text = totalAmount.ToString("###0.00");
                    txtwithauttaxamount.Text = s.ToString();
                    double dis = s * totaldiscount / 100;
                    txtdicountamount.Text = dis.ToString("###0.00");
                     txtdiccount.Text = totaldiscount.ToString("###0.00");

                }
                if (txtdiccount.Text == "")
                {
                    txtdiccount.Text = "0.00";
                }
            }


            if (txtRefNo.Text != "")
            {
                double totalAmount = 0.00;

                counter = 0;
                foreach (DataRow dr in addToCartTable.Rows)
                {
                    string itemid = dr[0].ToString();
                    if (ls.Contains(itemid) && gridsalesdelivary.Rows[counter].DefaultCellStyle.Font != null)
                    {
                        counter++;
                        continue;
                    }
                    totalAmount += Convert.ToDouble(dr[7].ToString());
                    counter++;
                }
                double s1 = totalAmount;
                string discount1 = txtdiccount.Text;


                double amount1 = 0;

                if (double.TryParse(discount1, out amount1))
                {
                    double totaldiscount = Convert.ToDouble(discount1);
                    totalAmount = totalAmount - ((totalAmount * totaldiscount) / 100);
                    txtTotalAmmount.Text = totalAmount.ToString("###0.00");
                    txtwithauttaxamount.Text = s1.ToString();
                    double dis = s1 * totaldiscount / 100;
                    txtdicountamount.Text = dis.ToString();
                    txtdiccount.Text = totalAmount.ToString("###0.00");

                }
                if (txtdiccount.Text == "")
                {
                    txtdiccount.Text = "0.00";
                }

            }


        }

       
    }


}


