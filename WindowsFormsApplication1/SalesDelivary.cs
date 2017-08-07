using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace WindowsFormsApplication1
{
    public partial class salesdelivary : Form
    {
        double amount = 0;
        List<string> ls = new List<string>();
        public bool ValidationFails = false;
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
            gridsalesdelivary.Focus();
            gridsalesdelivary.TabStop = true;
           // txtItemCode.TabStop = true;
           // butitembutton.TabStop = true;
           // txtItemCode.TabStop = true;
            //butitembutton.TabStop = true;
            
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

            string selectquery1 = "select Custd.CustId as [Customer ID] ,CustName AS [Customer Name] ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustPanNo AS [PAN NO], CustGstNo AS [GST NO],CustDesc as [Description],CustOpeningBalance as[Opening Balance] ,CustCurrentBalance as[Current Balance] from  CustomerDetails Custd join CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID ";
            string actualcolumn = "select top 1 Custd.CustId ,CustName,CustCompName ,CustAddress,CustCity, CustState,CustZip,CustCountry,CustEmail, CustWebAddress,CustPhone,CustMobile,CustFax  ,CustPanNo, CustGstNo,CustDesc,CustOpeningBalance,CustCurrentBalance from  CustomerDetails Custd join CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID  ";
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
            dataGridView2.DataSource = dt1;
            counter = 0;
            panel2.Visible = true;
           
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
                int quantity1 = 0;
            int counter = 0;
          
            //txtQuantity.Enabled = false;
            if (txtRefNo.Text == "")
            {
                //if (!addToCartTable.Columns.Contains("ResivQuantity"))
                //{
                //    addToCartTable.Columns.Add(new DataColumn("ResivQuantity"));
                //     addToCartTable.Columns.RemoveAt(7);
                //}

                //if (!addToCartTable.Columns.Contains("Amount"))
                //{
                //    addToCartTable.Columns.Add(new DataColumn("Amount"));
                //}
                //if (addToCartTable.Columns.Contains("ResivQuantity"))
                //{
                //   // addToCartTable.Columns.Add(new DataColumn("ResivQuantity"));
                //    addToCartTable.Columns.RemoveAt(6);
                //}

              
              
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
                        quantity1 = quantity1 + q3;
                        int q4 = Convert.ToInt32(txtqtybuiled.Text);
                        int q5 = q4 - q1;
                        int q6 = quantity1 + q5;
                        txtqtybuiled.Text= q6.ToString();
                        //dr3[4] = q3.ToString();
                        Double rate1 = Convert.ToDouble(prise);
                        Double rate2 = Convert.ToDouble(txtAmmount.Text);
                        Double rate3 = rate1 + rate2;
                        dr3[6] = rate3.ToString("###0.00");
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
                    //le qtybuiled = getquantitybuiled();
                    //txtqtybuiled.Text = qtybuiled.ToString();
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
                            int q1 = Convert.ToInt32(txtQuantity.Text.Trim());
                            int q2 = Convert.ToInt32(txtqtybuiled.Text.Trim());
                            int q3 = q1 + q2;
                            txtqtybuiled.Text = q3.ToString();
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
                        //double qtybuiled = getquantitybuiled();
                        //txtqtybuiled.Text = qtybuiled.ToString();
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
                        quantity1 = quantity1 + q3;
                        int q4 = Convert.ToInt32(txtqtybuiled.Text);
                        int q5 = q4 - q1;
                        int q6 = quantity1 + q5;
                        txtqtybuiled.Text = q6.ToString();
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
                        int q1 = Convert.ToInt32(txtQuantity.Text.Trim());
                        int q2 = Convert.ToInt32(txtqtybuiled.Text.Trim());
                        int q3 = q1 + q2;
                        txtqtybuiled.Text = q3.ToString();
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
                    //double qtybuiled = getquantitybuiled();
                    //txtqtybuiled.Text = qtybuiled.ToString();
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
                            quantity1 = quantity1 + q3;
                            int q4 = Convert.ToInt32(txtqtybuiled.Text);
                            int q5 = q4 - q1;
                            int q6 = quantity1 + q5;
                            txtqtybuiled.Text = q6.ToString();
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
                        //double qtybuiled = getquantitybuiled1();
                        //txtqtybuiled.Text = qtybuiled.ToString();
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
                                    int q1 = Convert.ToInt32(txtQuantity.Text.Trim());
                                    int q2 = Convert.ToInt32(txtqtybuiled.Text.Trim());
                                    int q3 = q1 + q2;
                                    txtqtybuiled.Text = q3.ToString();
                                    addToCartTable.Rows.Add(dr);

                                    gridsalesdelivary.DataSource = addToCartTable;
                                    var cdsds = gridsalesdelivary.Rows.Count;
                                    gridsalesdelivary.CurrentCell = gridsalesdelivary.Rows[cdsds - 2].Cells[0];
                                    double totalAmount = Convert.ToDouble(txtTotalAmmount.Text);
                                    totalAmount += Convert.ToDouble(txtAmmount.Text.Trim());
                                    txtTotalAmmount.Text = totalAmount.ToString("###0.00");
                                    txtwithauttaxamount.Text = totalAmount.ToString("###0.00");
                                    gridsalesdelivary.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                                    txtItemCode.Text = "I";
                                    txtProductName.Text = "";
                                    txtRate.Text = "";
                                    txtQuantity.Text = "";
                                    txtAmmount.Text = "";
                                    txtItemCode.Focus();
                                    txtQuantity.TabStop = false;
                                    txtQuantity.Enabled = false;
                                    butAddItem.Enabled = false;
                                }
                                //double qtybuiled = getquantitybuiled1();
                                //txtqtybuiled.Text = qtybuiled.ToString();
                            }
                            if (gridsalesdelivary.Rows.Count > 1)
                            {
                                txtdiccount.ReadOnly = false;
                                ButSelectPurchaseOrder.Enabled = true;
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
            txttaxamount.Visible = true;
            txtdicountamount.Visible =true;
            txtwithauttaxamount.Visible =true;
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
               // addToCartTable.Columns.RemoveAt(6);
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
            txtqtybuiled.Text = "0";
        }

        private void butSaveButton_Click(object sender, EventArgs e)
        {
             DataGridViewRowCollection cal1 = gridsalesdelivary.Rows;
             for (int c = 0; c < cal1.Count - 1; c++)
             {
                 DataGridViewRow currentRow2 = cal1[c];
                 DataGridViewCellCollection cellCollection2 = currentRow2.Cells;
                 string itid1 = cellCollection2[0].Value.ToString();
                 if (ls.Contains(itid1))
                 {
                     counter++;
                     continue;
                 }
                 counter++;
                 string que1 = cellCollection2[4].Value.ToString();
                 if (que1=="0"||que1 == "")
                 {
                     MessageBox.Show("please select your correct quqntity");
                     gridsalesdelivary.AllowUserToAddRows = true;
                     gridsalesdelivary.CurrentCell = GetCurrentRowOFGridView().Cells[4];
                     return;
                 }
                 string txtAmount = cellCollection2[11].Value.ToString();
                 if (txtAmount == "0.00"||txtAmount=="")
                 {
                     MessageBox.Show("kindly entered valid input");
                     gridsalesdelivary.AllowUserToAddRows = true;
                     gridsalesdelivary.CurrentCell = GetCurrentRowOFGridView().Cells[4];
                     return;
                 }
                
             }
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
                    string que = cellCollection1[4].Value.ToString();
                    if (que == "0" || que == "")
                    {
                        MessageBox.Show("please select your correct quqntity");
                        gridsalesdelivary.AllowUserToAddRows = true;
                        gridsalesdelivary.CurrentCell = GetCurrentRowOFGridView().Cells[4];
                        return;
                    }
                    string txtAmount = cellCollection1[11].Value.ToString();
                    if (txtAmount == "0.00" || txtAmount == "")
                    {
                        MessageBox.Show("kindly entered valid input");
                        gridsalesdelivary.AllowUserToAddRows = true;
                        gridsalesdelivary.CurrentCell = GetCurrentRowOFGridView().Cells[4];
                        return;
                    }
                   
                    string qurry = "select CurrentQuantity from ItemQuantityDetail where ItemId='" + itid + "'";
                    DataTable dt = d.getDetailByQuery(qurry);
                    string currid = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        currid = dr["CurrentQuantity"].ToString();
                    }
                    double currid1 = Convert.ToDouble(currid);
                    double quent1 = Convert.ToDouble(que);
                    // int curentQuntity = Convert.ToInt32(que);
                    double cuentQuantity = Convert.ToDouble(currid);
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
            txtcustomercode.TabStop = false;
            butcustomercode.TabStop = false;
            txtItemCode.TabStop = false;
            butitembutton.TabStop = false;
            butRemoveItem.TabStop = false;
            butSaveButton.TabStop = false;
            ButSelectPurchaseOrder.TabStop = false;
            butClose.TabStop = false;
            salesedelivarytabindex();
            CashAmount.Focus();
            txtBalance.Text = txtTotalAmmount.Text;
            txtRturned.ReadOnly = true;
            

        }
        public void add()
        {
            if (CashAmount.Text == "")
            {
                CashAmount.Text = "0";
                CashAmount.SelectAll();
            }
            else if (txtCreditAmount.Text == "")
            {
                txtCreditAmount.Text = "0";
                txtCreditAmount.SelectAll();
            }
            else if (txtChequeAmount.Text == "")
            {
                txtChequeAmount.Text = "0";
                txtChequeAmount.SelectAll();
            }
            else if (txtEwalletAmount.Text == "")
            {
                txtEwalletAmount.Text = "0";
                txtEwalletAmount.SelectAll();
            }
            else if (txtCouponAmount.Text == "")
            {
                txtCouponAmount.Text = "0";
                txtCouponAmount.SelectAll();
            }
            else
            {
                double cr = Convert.ToDouble(txtCreditAmount.Text);
                double cas = Convert.ToDouble(CashAmount.Text);
                double chaq = Convert.ToDouble(txtChequeAmount.Text);
                double ewelled = Convert.ToDouble(txtEwalletAmount.Text);
                double coup = Convert.ToDouble(txtCouponAmount.Text);
                double d = cr + cas + chaq + ewelled + coup;
                txtTotalAmount1.Text = d.ToString();
            }
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
                    if (ls.Contains(itid))
                    {
                        continue;
                    }
                    string que = cellCollection1[4].Value.ToString();
                   
                    if (que == "")
                    {
                        que = "0";
                    }
                    string quent = cellCollection1[6].Value.ToString();
                    string qurry = "select CurrentQuantity from ItemQuantityDetail where ItemId='" + itid + "'";
                    DataTable dt = d.getDetailByQuery(qurry);
                    string currid = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        currid = dr["CurrentQuantity"].ToString();
                    }
                    if (currid == "")
                    {
                        currid = "0";
                    }
                    double quent1 = Convert.ToDouble(que.ToString());
                    // int curentQuntity = Convert.ToInt32(que);
                     double cuentQuantity = Convert.ToDouble(currid);
                    double lastQuantity = cuentQuantity - quent1;
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
                            string txtRate = cellcollection[3].Value.ToString();
                            string txtQuantity = cellcollection[4].Value.ToString();
                            string txtAmount = cellcollection[11].Value.ToString();
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
                                    string txtRate = cellCollection[3].Value.ToString();
                                    string txtQuanity = cellCollection[4].Value.ToString();
                                    string txtAmoun = cellCollection[11].Value.ToString();
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
                                    salesedelivarytabindex();
                                   
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
                            string txtRate = cellcollection[3].Value.ToString();
                            string txtQuantity = cellcollection[4].Value.ToString();
                            string txtAmount = cellcollection[11].Value.ToString();
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

                            //if (id5 == "")
                            //{
                            //    counter = 0;
                            //    string deleteQurry = "delete customerorderdescriptions where Orderid='" + txtRefNo.Text + "'";
                            //    DataTable dt = d.getDetailByQuery(deleteQurry);
                            //    //dataGridView1.DataSource = "";


                            //    DataGridViewRowCollection RowCollection2 = gridsalesdelivary.Rows;
                            //    List<string> sf1 = new List<string>();
                            //    for (int a = 0; a < RowCollection2.Count; a++)
                            //    {
                                    
                            //        DataGridViewRow currentRow = RowCollection2[a];
                            //        DataGridViewCellCollection cellCollection = currentRow.Cells;
                            //        string txtItemCode = cellCollection[0].Value.ToString();
                            //        if (ls.Contains(txtItemCode) && gridsalesdelivary.Rows[counter].DefaultCellStyle.Font != null)
                            //        {
                            //            counter++;
                            //            continue;
                            //        }
                            //        counter++;
                            //        string txtRate = cellCollection[4].Value.ToString();
                            //        string txtQuanity = cellCollection[5].Value.ToString();
                            //        string txtAmoun = cellCollection[6].Value.ToString();
                            //        string OrderID1 = id;
                            //        // string updatequery = "insert into orderdetails Values('"+txtcustomercode.Text+"','"+dtpDate.Text+"','" + txtTotalAmmount.Text + "','"+txtdiccount.Text+"','"+txtdicountamount.Text+"','"+txttax.Text+"','"+txttaxamount.Text+"','" + txtwithauttaxamount.Text + "')";
                            //        // int update = d.saveDetails(updatequery);
                            //        string Query = "insert into customerorderdescriptions Values('" + OrderID1 + "','" + txtItemCode + "','" + txtRate + "','" + txtQuanity + "','" + txtAmoun + "')";
                            //        //MessageBox.Show(Query);

                            //        sf1.Add(Query);

                            //    }
                               // int insertedRows4 = d.saveDetails(sf1);
                                //if (insertedRows4 > 0)
                               // {
                                    string salesdelivary = "Insert into salesOrderDelivery values('" + Orde + "','true','" + dtpDate.Text + "','"+s+"')";
                                    int insert = d.saveDetails(salesdelivary);
                                    if (insert > 0)
                                    {
                                        string qurry = "select CustCurrentBalance from CustomerAccountDetails where CustId='" +txtcustomercode.Text + "'";
                                        DataTable dt = d.getDetailByQuery(qurry);
                                        string balabce = "";
                                        foreach (DataRow dr in dt.Rows)
                                        {
                                            balabce = dr[0].ToString();
                                        }

                                        double bal = Convert.ToDouble(balabce.ToString());
                                        double balan = Convert.ToDouble(txtBalance.Text);
                                        double b = bal+balan;
                                      
                                        string updateQ = "update CustomerAccountDetails set CustCurrentBalance='" + b + "'where CustId='" + txtcustomercode.Text + "'";
                                        int insertedRows2 = d.saveDetails(updateQ);
                                        DateTime f = DateTime.Now;
                                        string insertQurry = "insert into SalesPaymentDetailes Values('" + txtInvoiceid.Text + "','" + CashAmount.Text + "','" + txtCreditAmount.Text + "','" + txtDebitBankName.Text + "','" + txtCardNumber.Text + "','" + CmbCardType.SelectedItem.ToString() + "','" + txtChequeAmount.Text + "','" + txtChequeBankName.Text + "','" + txtChequeNumber.Text + "','" + dateTimePicker1.Value.ToString() + "','" + txtEwalletAmount.Text + "','" + EWalletCompanyName.Text + "','" + txtTransactionNumber.Text + "','" + dateTimePicker2.Value.ToString() + "','" + txtCouponAmount.Text + "','" + CmbCompany.SelectedItem.ToString() + "','" + txtInvoiceAmount.Text + "','" + txtTotalAmount1.Text + "','" + txtBalance.Text + "','" + txtRturned.Text + "','" + txtNetAmount.Text + "','"+f+"')";
                                        int insertedRows = d.saveDetails(insertQurry);
                                        if (insertedRows > 0)
                                        {

                                            MessageBox.Show("details save successfully");
                                           // panel2.Visible = true;
                                            DialogResult result = MessageBox.Show("Do you need to print Sales delivary", "Impotant questiuon", MessageBoxButtons.YesNo);
                                            if (result == System.Windows.Forms.DialogResult.Yes)
                                            {
                                             
                                               // crystalReportViewer2.Visible = false;
                                               // gridsalesdelivary.AllowUserToAddRows = false;
                                                //string a = "Data Source=DINESHTIWARI-PC\\SQLEXPRESS;Initial Catalog=SalesMaster;Integrated Security=True";
                                                //SqlConnection con = d.openConnection();//new SqlConnection(a);
                                                //string selectquery = "select * from salesorderdelivaryreport where Delivaryid='" + txtSrNo.Text + "'";
                                                //SqlCommand cmd = new SqlCommand(selectquery, con);
                                                //SqlDataAdapter sd = new SqlDataAdapter(cmd);
                                                //DataSet1 ds = new DataSet1();
                                                //sd.Fill(ds, "compnaydetails");

                                                ////CrystalReport1 cr = new CrystalReport1();
                                                //// cr.ParameterFields.Add(textBox1.Text);
                                                //// cr.Load("C:\\Users\\dineshtiwari\\Documents\\Visual Studio 2010\\Projects\\report11\\report11\\CrystalReport1.rpt");

                                                //CrystalReportsalesdelivary report1 = new CrystalReportsalesdelivary();
                                                //report1.SetDataSource(ds.Tables[1]);

                                                //crystalReportViewer2.ReportSource = report1;
                                                //crystalReportViewer2.Refresh();
                                                //con.Close();
                                                ReportDocument crReportDocument;
                                                crReportDocument = new ReportDocument();
                                                frmViewReport View = new frmViewReport();
                                                crReportDocument.Load(Application.StartupPath + "//Report//CrystalReportsalesdelivary.rpt");
                                                //string conntion = "Data Source=DELL-PC;Initial Catalog=SalesMaster;User ID=sa; Password=dell@12345;";
                                                SqlConnection con = d.openConnection();//new SqlConnection(conntion);
                                                string selectqurry = "select * from salesorderdelivaryreport where Delivaryid='" + txtSrNo.Text + "'";
                                                SqlCommand cmd = new SqlCommand(selectqurry, con);
                                                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                                                DataSet1 ds = new DataSet1();
                                                sda.Fill(ds, "compnaydetails");
                                                crReportDocument.SetDataSource(ds.Tables[1]);
                                                //Start Preview                          
                                                View.CrViewer.ReportSource = crReportDocument;
                                                View.CrViewer.Refresh();
                                                View.Show();
                                                //crystalReportViewer2.PrintReport(1, false, 0, 0);
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
                                                txtcustomercode.TabStop = true;
                                                butcustomercode.TabStop = true;
                                                txtRefNo.Enabled = true;
                                                ButSelectPurchaseOrder.Enabled = true;
                                                salesedelivarytabindex();
                                                con.Close();
                                                txtTotalAmmount.Text = "0.00";
                                                return;
                                            }
                                            if (result == System.Windows.Forms.DialogResult.No)
                                            {
                                                crystalReportViewer2.Visible = false;
                                                panel2.Visible = false;
                                               // makeblank();
                                                makeblank();
                                                salesedelivarytabindex();
                                                int value1 = Convert.ToInt32(txtSrNo.Text);
                                                int value2 = value1 + 1;
                                                txtSrNo.Text = value2.ToString();
                                                txtcustomercode.Focus();
                                                txtcustomercode.Select(txtcustomercode.Text.Length, 0);
                                                gridsalesdelivary.AllowUserToAddRows = true;
                                                butRemoveItem.Enabled = false;
                                                txtcustomercode.TabStop = true;
                                                butcustomercode.TabStop = true;
                                                txtRefNo.Enabled = true;
                                                ButSelectPurchaseOrder.Enabled = true;
                                                txtTotalAmmount.Text = "0.00";
                                                return;
                                                
                                            }
                                           
                                        }
                                    }
                                    else
                                    {
                                        gridsalesdelivary.AllowUserToAddRows = true;
                                       // MessageBox.Show("details save not successfully");
                                        txtTotalAmmount.Text = "0.00";


                                    }
                                    
                                }

                            }
                        }
                    }
             //   }
           // }

           


          // }
       


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
                    string que = cellCollection1[4].Value.ToString();
                  
                    //string quent = cellCollection1[6].Value.ToString();
                   // double s1 = Convert.ToDouble(quent);


                    string qurry = "select CurrentQuantity from ItemQuantityDetail where ItemId='" + itid + "'";
                    DataTable dt = d.getDetailByQuery(qurry);
                    string currid = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        currid = dr["CurrentQuantity"].ToString();
                    }
                    double currid1 = Convert.ToDouble(currid);
                    double quent1 = Convert.ToDouble(que);
                    // int curentQuntity = Convert.ToInt32(que);
                    double cuentQuantity = Convert.ToDouble(quent1);
                   
                        double lastQuantity =currid1-cuentQuantity;
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
                        string txtRate = cellcollection[3].Value.ToString();
                        string txtQuantity = cellcollection[4].Value.ToString();
                        string txtAmount = cellcollection[11].Value.ToString();
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
                            DateTime f1 = DateTime.Now;
                            string qurry = "select CustCurrentBalance from CustomerAccountDetails where CustId='" + txtcustomercode.Text + "'";
                            DataTable dt = d.getDetailByQuery(qurry);
                            string balabce = "";
                            foreach (DataRow dr in dt.Rows)
                            {
                                balabce = dr[0].ToString();
                            }

                            double bal = Convert.ToDouble(balabce.ToString());
                            double balan = Convert.ToDouble(txtBalance.Text);
                            double b = bal + balan;

                            string updateQ = "update CustomerAccountDetails set CustCurrentBalance='" + b + "'where CustId='" + txtcustomercode.Text + "'";
                            int insertedRows2 = d.saveDetails(updateQ);
                            string insertQurry = "insert into SalesPaymentDetailes Values('" + txtInvoiceid.Text + "','" + CashAmount.Text + "','" + txtCreditAmount.Text + "','" + txtDebitBankName.Text + "','" + txtCardNumber.Text + "','" + CmbCardType.SelectedItem.ToString() + "','" + txtChequeAmount.Text + "','" + txtChequeBankName.Text + "','" + txtChequeNumber.Text + "','" + dateTimePicker1.Value.ToString() + "','" + txtEwalletAmount.Text + "','" + EWalletCompanyName.Text + "','" + txtTransactionNumber.Text + "','" + dateTimePicker2.Value.ToString() + "','" + txtCouponAmount.Text + "','" + CmbCompany.SelectedItem.ToString() + "','" + txtInvoiceAmount.Text + "','" + txtTotalAmount1.Text + "','" + txtBalance.Text + "','" + txtRturned.Text + "','" + txtNetAmount.Text + "','"+f1+"')";
                            int insertedRows=d.saveDetails(insertQurry);
                            if (insertedRows > 0)
                            {
                                MessageBox.Show("details save successfully");

                               // panel2.Visible = true;
                                DialogResult result = MessageBox.Show("Do you need to print Sales Delivary", "Impotant questiuon", MessageBoxButtons.YesNo);
                                if (result == System.Windows.Forms.DialogResult.Yes)
                                {
                                   // crystalReportViewer2.Visible = false;
                                   // gridsalesdelivary.AllowUserToAddRows = false;
                                   //// string a = "Data Source=DINESHTIWARI-PC\\SQLEXPRESS;Initial Catalog=SalesMaster;Integrated Security=True";
                                   // SqlConnection con = d.openConnection();//new SqlConnection(a);
                                   //// con.Open();
                                   // string selectquery = "select * from salesorderdelivaryreport where Delivaryid='" + txtSrNo.Text + "'";
                                   // SqlCommand cmd = new SqlCommand(selectquery, con);
                                   // SqlDataAdapter sd = new SqlDataAdapter(cmd);
                                   // DataSet1 ds = new DataSet1();
                                   // sd.Fill(ds, "compnaydetails");

                                   // //CrystalReport1 cr = new CrystalReport1();
                                   // // cr.ParameterFields.Add(textBox1.Text);
                                   // // cr.Load("C:\\Users\\dineshtiwari\\Documents\\Visual Studio 2010\\Projects\\report11\\report11\\CrystalReport1.rpt");

                                   // CrystalReportsalesdelivary2 report1 = new CrystalReportsalesdelivary2();
                                   // report1.SetDataSource(ds.Tables[1]);

                                   // crystalReportViewer2.ReportSource = report1;
                                   // crystalReportViewer2.Refresh();
                                   // con.Close();

                                    ReportDocument crReportDocument;
                                    crReportDocument = new ReportDocument();
                                    frmViewReport View = new frmViewReport();
                                    crReportDocument.Load(Application.StartupPath + "//Report//CrystalReportsalesdelivary2.rpt");
                                    //string conntion = "Data Source=DELL-PC;Initial Catalog=SalesMaster;User ID=sa; Password=dell@12345;";
                                    SqlConnection con = d.openConnection();//new SqlConnection(conntion);
                                    string selectqurry = "select * from salesorderdelivaryreport where Delivaryid='" + txtSrNo.Text + "'";
                                    SqlCommand cmd = new SqlCommand(selectqurry, con);
                                    SqlDataAdapter sda = new SqlDataAdapter(cmd);

                                    DataSet1 ds = new DataSet1();
                                    sda.Fill(ds, "compnaydetails");
                                    crReportDocument.SetDataSource(ds.Tables[1]);
                                    //Start Preview                          
                                    View.CrViewer.ReportSource = crReportDocument;
                                    View.CrViewer.Refresh();
                                    View.Show();
                                  
                                    //End Preview

                                    //Start Print
                                    // crReportDocument.PrintToPrinter(1, false, 0, 0);

                                    gridsalesdelivary.AllowUserToAddRows = true;
                                    crystalReportViewer2.Visible = false;
                                    panel2.Visible = false;
                                   // addToCartTable.Columns.RemoveAt(6);
                                    //if (!addToCartTable.Columns.Contains("Revised Quantity"))
                                    //{
                                    //    addToCartTable.Columns.Add(new DataColumn("Revised Quantity"));
                                    //    addToCartTable.Columns.RemoveAt(6);
                                    //}

                                    //if (!addToCartTable.Columns.Contains("Amount"))
                                    //{
                                    //    addToCartTable.Columns.RemoveAt(6);
                                    //    addToCartTable.Columns.Add(new DataColumn("Amount"));
                                    //}
                                    txtcustomercode.Focus();
                                    butRemoveItem.Enabled = false;
                                    txtcustomercode.TabStop = true;
                                    butcustomercode.TabStop = true;
                                    txtRefNo.Enabled = true;
                                    ButSelectPurchaseOrder.Enabled = true;
                                    salesedelivarytabindex();
                                    con.Close();
                                    txtTotalAmmount.Text = "0.00";
                                }
                                if (result == System.Windows.Forms.DialogResult.No)
                                {
                                    gridsalesdelivary.AllowUserToAddRows = true;
                                    crystalReportViewer2.Visible = false;
                                    panel2.Visible = false;
                                    //addToCartTable.Columns.RemoveAt(6);
                                    //if (!addToCartTable.Columns.Contains("Revised Quantity"))
                                    //{
                                    //    addToCartTable.Columns.Add(new DataColumn("Revised Quantity"));
                                    //    addToCartTable.Columns.RemoveAt(6);
                                    //}

                                    //if (!addToCartTable.Columns.Contains("Amount"))
                                    //{
                                    //    addToCartTable.Columns.RemoveAt(6);
                                    //    addToCartTable.Columns.Add(new DataColumn("Amount"));
                                    //}
                                    txtcustomercode.Focus();
                                    butRemoveItem.Enabled = false;
                                    txtcustomercode.TabStop = true;
                                    butcustomercode.TabStop = true;
                                    txtRefNo.Enabled = true;
                                    ButSelectPurchaseOrder.Enabled = true;
                                    txtTotalAmmount.Text = "0.00";
                                }
                            }
                        }
                        else
                        {
                            gridsalesdelivary.AllowUserToAddRows = true;
                            txtTotalAmmount.Text = "0.00";
                            //MessageBox.Show("details save not successfully");
                        }

                    }
                }
           // }
            makeblank();
            salesedelivarytabindex();
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
            addToCartTable.Columns.Add(new DataColumn("Item Code"));
            addToCartTable.Columns.Add(new DataColumn("Item Name"));
            addToCartTable.Columns.Add(new DataColumn("HSN"));
            addToCartTable.Columns.Add(new DataColumn("Rate"));
            addToCartTable.Columns.Add(new DataColumn("Quantity"));
            addToCartTable.Columns.Add(new DataColumn("Discount"));
            addToCartTable.Columns.Add(new DataColumn("Taxable Value"));
            addToCartTable.Columns.Add(new DataColumn("CGST (%)"));
            addToCartTable.Columns.Add(new DataColumn("SGST (%)"));
            addToCartTable.Columns.Add(new DataColumn("IGST (%)"));
            addToCartTable.Columns.Add(new DataColumn("CESS (%)"));
            addToCartTable.Columns.Add(new DataColumn("Total Ammount"));
        }

        private void ButSelectPurchaseOrder_Click(object sender, EventArgs e)
        {
            counter = 2;
            panel2.Visible = true;
            dataGridView2.AllowUserToAddRows = true;
            pnlSalesPayment.Visible = false;
            crystalReportViewer2.Visible = false;
            string selectqurry = "select orderdetails.orderid as [Order ID],orderdetails.date as [order Date],cd.custId as[Customer ID], cd.CustName as[Customer Name],cd.CustCompName as[Compnay Name],cd.CustAddress as [Address],(select sum(customerorderdescriptions.quantity) from customerorderdescriptions where customerorderdescriptions.orderid=orderdetails.orderid) as [Quantity Billed],cast(orderdetails.WithautTaxamount as numeric(38, 2)) as[Gross Amount],orderdetails.Discountamount as [Discount Amount],cast((orderdetails.WithautTaxamount-orderdetails.Discountamount)as numeric(38, 2))as[Taxable Value],Case when cd.CustState != (select top 1 [State] from CompnayDetails )then '0'else (select cast( sum ((((( COD.price*COD.quantity))-( ( ( COD.price*COD.quantity) * IT.Discount) / 100 ))* IT.CGST )/100)as numeric(38, 2))from ItemTaxDetail IT JOIN customerorderdescriptions COD  ON  IT.ItemId=COD.ItemId WHERE COD.orderid=orderdetails.orderid) end as[CGST],Case when cd.CustState != (select top 1 [State] from CompnayDetails )then '0'else(select cast( sum ((((( COD.price*COD.quantity)) -  ( ( ( COD.price*COD.quantity) * IT.Discount) / 100 ) ) * IT.SGST )/100)as numeric(38, 2)) from ItemTaxDetail IT JOIN customerorderdescriptions COD  ON  IT.ItemId=COD.ItemId WHERE COD.orderid=orderdetails.orderid)end as[SGST],Case when cd.CustState = (select top 1 [State] from CompnayDetails )then '0'else(select cast( sum ((((( COD.price*COD.quantity)) -  ( ( ( COD.price*COD.quantity) * IT.Discount) / 100 ) ) * IT.IGST )/100)as numeric(38, 2)) from ItemTaxDetail IT JOIN customerorderdescriptions COD  ON  IT.ItemId=COD.ItemId WHERE COD.orderid=orderdetails.orderid)end as[IGST],(select cast( sum ((((( COD.price*COD.quantity)) -  ( ( ( COD.price*COD.quantity) * IT.Discount) / 100 ) ) * IT.CESS )/100)as numeric(38, 2)) from ItemTaxDetail IT JOIN customerorderdescriptions COD  ON  IT.ItemId=COD.ItemId WHERE COD.orderid=orderdetails.orderid ) as[CESS],cast(((orderdetails.WithautTaxamount)-(orderdetails.Discountamount))+(orderdetails.Taxamount) as numeric(38, 2)) AS[Net Amount (Including Tax)],(case when  exists ( select Orderid from salesOrderDelivery where Orderid =orderdetails.orderid) then 'Delivered' else 'Panding'end) as [Delivery Status] from orderdetails join CustomerDetails  cd on cd.custId =orderdetails.custid ";
            string selectqurryForActualColumnName = "select top 1 orderdetails.orderid,orderdetails.date,cd.custId, cd.CustName,cd.CustCompName,cd.CustAddress,(select sum(customerorderdescriptions.quantity) from customerorderdescriptions where customerorderdescriptions.orderid=orderdetails.orderid),cast(orderdetails.WithautTaxamount as numeric(38, 2)),orderdetails.Discountamount,cast((orderdetails.WithautTaxamount-orderdetails.Discountamount)as numeric(38, 2)),Case when cd.CustState != (select top 1 [State] from CompnayDetails )then '0'else (select cast( sum ((((( COD.price*COD.quantity))-( ( ( COD.price*COD.quantity) * IT.Discount) / 100 ))* IT.CGST )/100)as numeric(38, 2))from ItemTaxDetail IT JOIN customerorderdescriptions COD  ON  IT.ItemId=COD.ItemId WHERE COD.orderid=orderdetails.orderid) end,Case when cd.CustState != (select top 1 [State] from CompnayDetails )then '0'else(select cast( sum ((((( COD.price*COD.quantity)) -  ( ( ( COD.price*COD.quantity) * IT.Discount) / 100 ) ) * IT.SGST )/100)as numeric(38, 2)) from ItemTaxDetail IT JOIN customerorderdescriptions COD  ON  IT.ItemId=COD.ItemId WHERE COD.orderid=orderdetails.orderid)end,Case when cd.CustState = (select top 1 [State] from CompnayDetails )then '0'else(select cast( sum ((((( COD.price*COD.quantity)) -  ( ( ( COD.price*COD.quantity) * IT.Discount) / 100 ) ) * IT.IGST )/100)as numeric(38, 2)) from ItemTaxDetail IT JOIN customerorderdescriptions COD  ON  IT.ItemId=COD.ItemId WHERE COD.orderid=orderdetails.orderid)end,(select cast( sum ((((( COD.price*COD.quantity)) -  ( ( ( COD.price*COD.quantity) * IT.Discount) / 100 ) ) * IT.CESS )/100)as numeric(38, 2)) from ItemTaxDetail IT JOIN customerorderdescriptions COD  ON  IT.ItemId=COD.ItemId WHERE COD.orderid=orderdetails.orderid ),cast(((orderdetails.WithautTaxamount)-(orderdetails.Discountamount))+(orderdetails.Taxamount) as numeric(38, 2)),(case when  exists ( select Orderid from salesOrderDelivery where Orderid =orderdetails.orderid) then 'Delivered' else 'Panding'end) from orderdetails join CustomerDetails  cd on cd.custId =orderdetails.custid ";
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
            //if (!addToCartTable.Columns.Contains("ResivQuantity"))
            //{
            //    addToCartTable.Columns.Add(new DataColumn("ResivQuantity"));
            //   // addToCartTable.Columns.RemoveAt(6);
            //}

            //if (!addToCartTable.Columns.Contains("Amount"))
            //{
            //    addToCartTable.Columns.Add(new DataColumn("Amount"));
            //}
           

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
                   // MessageBox.Show("Please select your remove button");
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
                            string qty = gridsalesdelivary.Rows[currentrow - 1].Cells[5].Value.ToString();
                            double qtybuiled = Convert.ToDouble(txtqtybuiled.Text);
                            qtybuiled -= Convert.ToDouble(qty.Trim());
                            txtqtybuiled.Text = qtybuiled.ToString();
                            txtTotalAmmount.Text = totalAmount.ToString("###0.00");
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
                                txtdiccount.ReadOnly= true;

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
                        //MessageBox.Show("Please select your remove button");
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
                            string qty = gridsalesdelivary.Rows[currentrow - 1].Cells[6].Value.ToString();
                            double qtybuiled = Convert.ToDouble(txtqtybuiled.Text);
                            qtybuiled -= Convert.ToDouble(qty.Trim());
                            txtqtybuiled.Text = qtybuiled.ToString();
                            txtTotalAmmount.Text = totalAmount.ToString("###0.00");
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
                                txtqtybuiled.Text = "0.0";
                            }
                            if (ls.Count == gridsalesdelivary.Rows.Count - 1)
                            {
                                gridsalesdelivary.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                               // MessageBox.Show("Item already deleted");
                                txtItemCode.Enabled = true;
                                txtItemCode.Focus();
                            }

                            if (gridsalesdelivary.Rows.Count > 0)
                            {
                               // butRemoveItem.Enabled = true;
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
                                ButSelectPurchaseOrder.Enabled = false;
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
                string itemid = gridsalesdelivary.Rows[gridsalesdelivary.CurrentRow.Index].Cells[0].Value.ToString();
                if (itemid == "")
                {
                    itemid = gridsalesdelivary.Rows[gridsalesdelivary.CurrentRow.Index].Cells[0].Value.ToString();
                    return;
                }
            }
            string selectquery = "select CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from CustomerDetails Where Custid='" + txtcustomercode.Text + "'";
            DataTable dt = d.getDetailByQuery(selectquery);
            if (dt.Rows.Count > 0)
            {
                
            }
             if (e.KeyChar == (char)Keys.Enter && dt.Rows != null && dt != null)
            {
                gridsalesdelivary.Focus();
                txtcustomercode.TabStop = true;
                butcustomercode.TabStop = true;
                gridsalesdelivary.TabStop = true;
               // MessageBox.Show("Please select your correct Customer id");
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
                string selectQuery = "select Custd.CustId as [Customer ID] ,CustName AS [Customer Name] ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustPanNo AS [PAN NO], CustGstNo AS [GST NO],CustDesc as [Description],CustOpeningBalance as[Opening Balance] ,CustCurrentBalance as[Current Balance] from  CustomerDetails Custd join CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID  where " + s + " like '" + txtsearchvalue.Text + "%'";

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
                if (s2 == "custId")
                {
                    s2 = "cd.custId";
                }
                else if (s2 == "CustName")
                {
                    s2 = "cd.CustName";
                }
                else if (s2 == "CustCompName")
                {
                    s2 = "cd.CustCompName";
                }
                else if (s2 == "CustAddress")
                {
                    s2 = "cd.CustAddress";
                }
                else if (s2 == "Column1")
                {
                    s2 = "(select sum(customerorderdescriptions.quantity) from customerorderdescriptions where customerorderdescriptions.orderid=orderdetails.orderid)";
                }
                else if (s2 == "Column2")
                {
                    s2 = "cast(orderdetails.WithautTaxamount as numeric(38, 2))";
                }
                else if (s2 == "Discountamount")
                {
                    s2 = "orderdetails.Discountamount";
                }
                else if (s2 == "Column3")
                {
                    s2 = "cast((orderdetails.WithautTaxamount-orderdetails.Discountamount)as numeric(38, 2))";
                }
                else if (s2 == "Column4")
                {
                    s2 = "Case when cd.CustState != (select top 1 [State] from CompnayDetails )then '0'else (select cast( sum ((((( COD.price*COD.quantity))-( ( ( COD.price*COD.quantity) * IT.Discount) / 100 ))* IT.CGST )/100)as numeric(38, 2))from ItemTaxDetail IT JOIN customerorderdescriptions COD  ON  IT.ItemId=COD.ItemId WHERE COD.orderid=orderdetails.orderid) end";
                }
                else if (s2 == "Column5")
                {
                    s2 = "Case when cd.CustState != (select top 1 [State] from CompnayDetails )then '0'else(select cast( sum ((((( COD.price*COD.quantity)) -  ( ( ( COD.price*COD.quantity) * IT.Discount) / 100 ) ) * IT.SGST )/100)as numeric(38, 2)) from ItemTaxDetail IT JOIN customerorderdescriptions COD  ON  IT.ItemId=COD.ItemId WHERE COD.orderid=orderdetails.orderid)end";
                }
                else if (s2 == "Column6")
                {
                    s2 = "Case when cd.CustState = (select top 1 [State] from CompnayDetails )then '0'else(select cast( sum ((((( COD.price*COD.quantity)) -  ( ( ( COD.price*COD.quantity) * IT.Discount) / 100 ) ) * IT.IGST )/100)as numeric(38, 2)) from ItemTaxDetail IT JOIN customerorderdescriptions COD  ON  IT.ItemId=COD.ItemId WHERE COD.orderid=orderdetails.orderid)end";
                }
                else if (s2 == "Column7")
                {
                    s2 = "(select cast( sum ((((( COD.price*COD.quantity)) -  ( ( ( COD.price*COD.quantity) * IT.Discount) / 100 ) ) * IT.CESS )/100)as numeric(38, 2)) from ItemTaxDetail IT JOIN customerorderdescriptions COD  ON  IT.ItemId=COD.ItemId WHERE COD.orderid=orderdetails.orderid )";
                }
                else if (s2 == "Column8")
                {
                    s2 = "cast(((orderdetails.WithautTaxamount)-(orderdetails.Discountamount))+(orderdetails.Taxamount) as numeric(38, 2))";
                }
                else if (s2 == "Column9")
                {
                    s2 = "(case when  exists ( select Orderid from salesOrderDelivery where Orderid =orderdetails.orderid) then 'Delivered' else 'Panding'end)";
                }
                string selectQuery2 = "select orderdetails.orderid as [Order ID],orderdetails.date as [order Date],cd.custId as[Customer ID], cd.CustName as[Customer Name],cd.CustCompName as[Compnay Name],cd.CustAddress as [Address],(select sum(customerorderdescriptions.quantity) from customerorderdescriptions where customerorderdescriptions.orderid=orderdetails.orderid) as [Quantity Billed],cast(orderdetails.WithautTaxamount as numeric(38, 2)) as[Gross Amount],orderdetails.Discountamount as [Discount Amount],cast((orderdetails.WithautTaxamount-orderdetails.Discountamount)as numeric(38, 2))as[Taxable Value],Case when cd.CustState != (select top 1 [State] from CompnayDetails )then '0'else (select cast( sum ((((( COD.price*COD.quantity))-( ( ( COD.price*COD.quantity) * IT.Discount) / 100 ))* IT.CGST )/100)as numeric(38, 2))from ItemTaxDetail IT JOIN customerorderdescriptions COD  ON  IT.ItemId=COD.ItemId WHERE COD.orderid=orderdetails.orderid) end as[CGST],Case when cd.CustState != (select top 1 [State] from CompnayDetails )then '0'else(select cast( sum ((((( COD.price*COD.quantity)) -  ( ( ( COD.price*COD.quantity) * IT.Discount) / 100 ) ) * IT.SGST )/100)as numeric(38, 2)) from ItemTaxDetail IT JOIN customerorderdescriptions COD  ON  IT.ItemId=COD.ItemId WHERE COD.orderid=orderdetails.orderid)end as[SGST],Case when cd.CustState = (select top 1 [State] from CompnayDetails )then '0'else(select cast( sum ((((( COD.price*COD.quantity)) -  ( ( ( COD.price*COD.quantity) * IT.Discount) / 100 ) ) * IT.IGST )/100)as numeric(38, 2)) from ItemTaxDetail IT JOIN customerorderdescriptions COD  ON  IT.ItemId=COD.ItemId WHERE COD.orderid=orderdetails.orderid)end as[IGST],(select cast( sum ((((( COD.price*COD.quantity)) -  ( ( ( COD.price*COD.quantity) * IT.Discount) / 100 ) ) * IT.CESS )/100)as numeric(38, 2)) from ItemTaxDetail IT JOIN customerorderdescriptions COD  ON  IT.ItemId=COD.ItemId WHERE COD.orderid=orderdetails.orderid ) as[CESS],cast(((orderdetails.WithautTaxamount)-(orderdetails.Discountamount))+(orderdetails.Taxamount) as numeric(38, 2)) AS[Net Amount (Including Tax)],(case when  exists ( select Orderid from salesOrderDelivery where Orderid =orderdetails.orderid) then 'Delivered' else 'Panding'end) as [Delivery Status] from orderdetails join CustomerDetails  cd on cd.custId =orderdetails.custid where " + s2 + " like '" + txtsearchvalue.Text + "%'";
                DataTable dt2 = d.getDetailByQuery(selectQuery2);
                dataGridView2.DataSource = dt2;
            }
        }
        public void salesedelivarytabindex()
        {
            CashAmount.Text = "0.00";
            txtCreditAmount.Text = "0.00";
            txtChequeAmount.Text = "0.00";
            txtEwalletAmount.Text = "0.00";
            txtCouponAmount.Text = "0.00";
            txtTotalAmount1.Text = "0.00";
            txtBalance.Text = "0.00";
            txtRturned.Text = "0.00";
            txtNetAmount.Text = "0.00";
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtcustomercode.Text=="C")
            {
                txtcustomercode.Focus();
                butcustomercode.TabStop = true;
                txtcustomercode.TabStop = true;
              
            }
           
            else if (ls.Count == gridsalesdelivary.Rows.Count - 1)
            {
                txtItemCode.Focus();
                butitembutton.TabStop = true;
                txtItemCode.TabStop = true;
                butRemoveItem.TabStop = true;
                // butSaveButton.TabStop = true;
                // butClose.TabStop = true;
                // ButSelectPurchaseOrder.TabStop = true;
                txtcustomercode.TabStop = true;
                butcustomercode.TabStop = true;
            }
            else if (gridsalesdelivary.Rows.Count > 1 && txtItemCode.Text == "I")
            {
                txtItemCode.Focus();
                butitembutton.TabStop = true;
                txtItemCode.TabStop = true;
                butRemoveItem.TabStop = true;
                butSaveButton.TabStop = true;
                butClose.TabStop = true;
                ButSelectPurchaseOrder.TabStop = true;
                txtcustomercode.TabStop = true;
                butcustomercode.TabStop = true;
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
            int currentIndex = dataGridView2.CurrentRow.Index;
            if (currentIndex == 0)
            {
                currentIndex = currentIndex + 1;
                MessageBox.Show("please select your proper row");
                dataGridView2.ReadOnly = true;
                return;
            }
            if (counter == 0)
            {

                DataGridViewCellCollection Collection = dataGridView2.Rows[e.RowIndex].Cells;
                if (!string.IsNullOrEmpty(Collection[0].Value.ToString()))
                {
                    rowcollection(Collection);
                    panel2.Visible = false;
                    tab1();
                    txtcustomercode.TabStop = true;
                    butcustomercode.TabStop = true;
                }
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
                
    
                DataGridViewCellCollection CellCollection = dataGridView2.Rows[e.RowIndex].Cells;
                if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                {
                    string s = CellCollection[0].Value.ToString();
                    string s1 = CellCollection[2].Value.ToString();
                    txtRefNo.Text = s;
                    string selectquery2 = "select Orderid from salesOrderDelivery where Orderid='" + s + "'";
                    DataTable dt1 = d.getDetailByQuery(selectquery2);
                    if (dt1 != null && dt1.Rows != null && dt1.Rows.Count > 0)
                    {
                        panel2.Visible = true;
                        MessageBox.Show("order details is completed");
                        makeblank();
                        txtcustomercode.Focus();
                        txtcustomercode.TabStop = true;
                        butcustomercode.TabStop = true;
                        txtcustomercode.Select(txtcustomercode.Text.Length, 0);
                        // addToCartTable.Columns.RemoveAt(6);
                        return;

                    }
                    else
                    {
                        
                        string selectqurry = "select custId,CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from CustomerDetails where custId='" + s1 + "'";
                        SetVendor(selectqurry);
                        string compnay = "select State from CompnayDetails";
                        DataTable dt2 = d.getDetailByQuery(compnay);
                        string companystate = "";
                        foreach (DataRow dr3 in dt2.Rows)
                        {
                            companystate = dr3[0].ToString();
                        }
                        string customer = "select CustState from customerdetails where custId='" + txtcustomercode.Text + "'";
                        DataTable dt3 = d.getDetailByQuery(customer);
                        string customerstate = "";
                        foreach (DataRow dr2 in dt3.Rows)
                        {
                            customerstate = dr2[0].ToString();
                        }
                        string selectQurry = "select ItemId from ItemDetails";
                        DataTable dt = d.getDetailByQuery(selectQurry);
                        string selectItem = "select cod.ItemId,ad.ItemName,itd.HSN,cast(cod.price as numeric(38,2)),cod.quantity,cast((cod.price*cod.quantity)-(cod.price*cod.quantity*itd.Discount/100)as numeric(38,2)),itd.Discount,itd.CGST,itd.SGST,itd.IGST,itd.CESS,cod.totalammount from orderdetails od join customerorderdescriptions cod on od.orderid=cod.orderid join ItemDetails ad on cod.ItemId=ad.ItemId join ItemPriceDetail ipd on ad.ItemId=ipd.ItemId join ItemTaxDetail itd on ipd.ItemId=itd.ItemId where cod.orderid='" + s + "'";
                        DataTable dt4 = d.getDetailByQuery(selectItem);
                        int totalrowcount = addToCartTable.Rows.Count;
                        for (int rowcount = 0; rowcount < totalrowcount; rowcount++)
                        {
                            addToCartTable.Rows.RemoveAt(0);
                        }
                        string txtcgst = "";
                        string txtsgst = "";
                        string txtigst = "";
                        decimal totel = 0;
                        for (int b = 0; b < dt4.Rows.Count; b++)
                        {
                            DataRow dr1 = dt4.Rows[b];
                            string itemcode = dr1[0].ToString();
                            if (ls.Contains(itemcode))
                            {
                                continue;
                            }

                            string itemcod = dr1[0].ToString();
                            string productname = dr1[1].ToString();
                            string hsn = dr1[2].ToString();
                            string rate = dr1[3].ToString();
                            string quantity = dr1[4].ToString();
                            string taxablevalue = dr1[5].ToString();
                            string discoun = dr1[6].ToString();
                            txtcgst = dr1[7].ToString();
                            txtsgst = dr1[8].ToString();
                            txtigst = dr1[9].ToString();
                            string cess = dr1[10].ToString();
                            string totalamout = dr1[11].ToString();
                            decimal amt = Convert.ToDecimal(totalamout);
                            totel = totel + amt;
                            if (companystate != customerstate)
                            {
                                txtcgst = "0.00";
                                txtsgst = "0.00";
                            }
                            if (companystate == customerstate)
                            {
                                txtigst = "0.00";
                            }
                            dr1 = addToCartTable.NewRow();
                            dr1[0] = itemcod.Trim();
                            dr1[1] = productname.Trim();
                            dr1[2] = hsn.Trim();
                            dr1[3] = rate.Trim();
                            dr1[4] = quantity.Trim();
                            dr1[5] = discoun.Trim();
                            dr1[6] = taxablevalue.Trim();

                            dr1[7] = txtcgst.Trim();
                            dr1[8] = txtsgst.Trim();
                            dr1[9] = txtigst.Trim();
                            dr1[10] = cess.Trim();
                            dr1[11] = totalamout.Trim();
                            int q = Convert.ToInt32(quantity.ToString());
                            txtqtybuiled.Text = q.ToString();
                            addToCartTable.Rows.Add(dr1);


                        }

                        //gridsalesdelivary.DataSource = null;
                        panel2.Visible = false;
                        gridsalesdelivary.DataSource = addToCartTable;
                        double setam = setAmount(5);
                        double subtotal = WithTaxAmount(2);
                        txtdicountamount.Text = setam.ToString();
                        txtwithauttaxamount.Text = subtotal.ToString();
                        double taxa = TaxAmount();
                        txttaxamount.Text = taxa.ToString();
                        txtTotalAmmount.Text = totel.ToString("###0.00");
                    }

                }
               
            }

        }

        private void dataGridView2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
           // txtItemCode.Focus();
            int currentIndex = dataGridView2.CurrentRow.Index;
            if (currentIndex == 0)
            {
                currentIndex = currentIndex + 1;
                MessageBox.Show("please select your proper row");
                dataGridView2.ReadOnly = true;
                return;
            }
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
                        DataGridViewCellCollection CellCollection = dataGridView2.Rows[currentIndex-1].Cells;
                        if (!string.IsNullOrEmpty(CellCollection[0].Value.ToString()))
                        {
                            string s = CellCollection[0].Value.ToString();
                            string s1 = CellCollection[2].Value.ToString();
                            txtRefNo.Text = s;
                            string selectquery2 = "select Orderid from salesOrderDelivery where Orderid='" + s + "'";
                            DataTable dt1 = d.getDetailByQuery(selectquery2);
                            if (dt1 != null && dt1.Rows != null && dt1.Rows.Count > 0)
                            {
                                panel2.Visible = true;
                                MessageBox.Show("order details is completed");
                                makeblank();
                                txtcustomercode.Focus();
                                txtcustomercode.TabStop = true;
                                butcustomercode.TabStop = true;
                                txtcustomercode.Select(txtcustomercode.Text.Length, 0);
                                // addToCartTable.Columns.RemoveAt(6);
                                return;

                            }
                            else
                            {

                                string selectqurry = "select custId,CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from CustomerDetails where custId='" + s1 + "'";
                                SetVendor(selectqurry);
                                string compnay = "select State from CompnayDetails";
                                DataTable dt2 = d.getDetailByQuery(compnay);
                                string companystate = "";
                                foreach (DataRow dr3 in dt2.Rows)
                                {
                                    companystate = dr3[0].ToString();
                                }
                                string customer = "select CustState from customerdetails where custId='" + txtcustomercode.Text + "'";
                                DataTable dt3 = d.getDetailByQuery(customer);
                                string customerstate = "";
                                foreach (DataRow dr2 in dt3.Rows)
                                {
                                    customerstate = dr2[0].ToString();
                                }
                                string selectQurry = "select ItemId from ItemDetails";
                                DataTable dt = d.getDetailByQuery(selectQurry);
                                string selectItem = "select cod.ItemId,ad.ItemName,itd.HSN,cast(cod.price as numeric(38,2)),cod.quantity,cast((cod.price*cod.quantity)-(cod.price*cod.quantity*itd.Discount/100)as numeric(38,2)),itd.Discount,itd.CGST,itd.SGST,itd.IGST,itd.CESS,cod.totalammount from orderdetails od join customerorderdescriptions cod on od.orderid=cod.orderid join ItemDetails ad on cod.ItemId=ad.ItemId join ItemPriceDetail ipd on ad.ItemId=ipd.ItemId join ItemTaxDetail itd on ipd.ItemId=itd.ItemId where cod.orderid='" + s + "'";
                                DataTable dt4 = d.getDetailByQuery(selectItem);
                                int totalrowcount = addToCartTable.Rows.Count;
                                for (int rowcount = 0; rowcount < totalrowcount; rowcount++)
                                {
                                    addToCartTable.Rows.RemoveAt(0);
                                }
                                string txtcgst = "";
                                string txtsgst = "";
                                string txtigst = "";
                                decimal totel = 0;
                                for (int b = 0; b < dt4.Rows.Count; b++)
                                {
                                    DataRow dr1 = dt4.Rows[b];
                                    string itemcode = dr1[0].ToString();
                                    if (ls.Contains(itemcode))
                                    {
                                        continue;
                                    }

                                    string itemcod = dr1[0].ToString();
                                    string productname = dr1[1].ToString();
                                    string hsn = dr1[2].ToString();
                                    string rate = dr1[3].ToString();
                                    string quantity = dr1[4].ToString();
                                    string taxablevalue = dr1[5].ToString();
                                    string discoun = dr1[6].ToString();
                                    txtcgst = dr1[7].ToString();
                                    txtsgst = dr1[8].ToString();
                                    txtigst = dr1[9].ToString();
                                    string cess = dr1[10].ToString();
                                    string totalamout = dr1[11].ToString();
                                    decimal amt = Convert.ToDecimal(totalamout);
                                    totel = totel + amt;
                                    if (companystate != customerstate)
                                    {
                                        txtcgst = "0.00";
                                        txtsgst = "0.00";
                                    }
                                    if (companystate == customerstate)
                                    {
                                        txtigst = "0.00";
                                    }
                                    dr1 = addToCartTable.NewRow();
                                    dr1[0] = itemcod.Trim();
                                    dr1[1] = productname.Trim();
                                    dr1[2] = hsn.Trim();
                                    dr1[3] = rate.Trim();
                                    dr1[4] = quantity.Trim();
                                    dr1[5] = discoun.Trim();
                                    dr1[6] = taxablevalue.Trim();

                                    dr1[7] = txtcgst.Trim();
                                    dr1[8] = txtsgst.Trim();
                                    dr1[9] = txtigst.Trim();
                                    dr1[10] = cess.Trim();
                                    dr1[11] = totalamout.Trim();
                                    int q = Convert.ToInt32(quantity.ToString());
                                    txtqtybuiled.Text = q.ToString();
                                    addToCartTable.Rows.Add(dr1);


                                }

                                //gridsalesdelivary.DataSource = null;
                                panel2.Visible = false;
                                gridsalesdelivary.DataSource = addToCartTable;
                                double setam = setAmount(5);
                                double subtotal = WithTaxAmount(2);
                                txtdicountamount.Text = setam.ToString();
                                txtwithauttaxamount.Text = subtotal.ToString();
                                double taxa = TaxAmount();
                                txttaxamount.Text = taxa.ToString();
                                txtTotalAmmount.Text = totel.ToString("###0.00");
                            }
                        }

                    }

                }

            }
        

        public void doubletabindex()
        {
            butRemoveItem.Enabled = true;
            txtcustomercode.TabStop = true;
            butcustomercode.TabStop = true;
            txtItemCode.TabStop = true;
            butitembutton.TabStop = true;
            butRemoveItem.TabStop = true;
            butSaveButton.TabStop = true;
            ButSelectPurchaseOrder.TabStop = true;
            butClose.TabStop = true;
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
       
        public double getquantitybuiled1()
        {
            double totalValue = 0.0;
            double s;
            for (int a = 0; a < gridsalesdelivary.Rows.Count; a++)
            {
                s = Convert.ToDouble(gridsalesdelivary.Rows[a].Cells[6].Value);
                totalValue = totalValue + s;

            }
            return totalValue;
        }
         private void IndexTex2()
        {
            
            if (txtQuantity.Text != "")
            {
                txtQuantity.Focus();
                txtQuantity.TabStop = true;
                txtQuantity.SelectAll();
            }
            else
            {
                txtQuantity.TabStop = false;
            }
            txtItemCode.TabStop = true;
            butitembutton.TabStop= true;
            txtdiccount.TabStop = false;
            butAddItem.TabStop = true;
            butRemoveItem.TabStop = true;
            txtcustomercode.TabStop = true;
            butcustomercode.TabStop = true;
          
          butSaveButton.TabStop = true;
          butClose.TabStop= true;
        }

         private void txtRefNo_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (e.KeyChar == Convert.ToChar(Keys.Enter))
             {
                 //txtdiccount.ReadOnly = true;
                 if (txtRefNo.Text == "")
                 {
                     MessageBox.Show("please enter the Refence Number");
                     txtRefNo.Focus();
                 }
                     
                 else
                 {
                     string selectquery3 = "select orderid from orderdetails where orderid ='" + txtRefNo.Text + "'";
                     DataTable dt5 = d.getDetailByQuery(selectquery3);
                     if (dt5.Rows.Count == 0)
                     {
                         MessageBox.Show("This Order Is Not Available");
                         txtRefNo.Text = "";
                         txtRefNo.Focus();
                         txtcustomercode.Select(txtcustomercode.Text.Length, 0);
                         //button1.TabStop = true;
                         txtcustomercode.TabStop = true;

                         //return;
                     }
                     else
                     {
                        
                         IndexTex2();
                        
                         string selectquery2 = "select Orderid from salesOrderDelivery where Orderid='" + txtRefNo.Text + "'";
                         DataTable dt1 = d.getDetailByQuery(selectquery2);
                         if (dt1 != null && dt1.Rows != null && dt1.Rows.Count > 0)
                         {
                            
                             MessageBox.Show("This Order completed");
                            
                             txtRefNo.Text = "";
                             txtRefNo.Focus();
                             //textVendercod.Select(textVendercod.Text.Length, 0);
                             addToCartTable.Columns.RemoveAt(6);
                             txtcustomercode.TabStop = true;
                             butcustomercode.TabStop = true;

                         }

                         else
                         {
                             ButSelectPurchaseOrder.Enabled = false;
                             txtRefNo.ReadOnly = true;
                            
                             butSaveButton.Visible = true;
                             decimal totel = 0;
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
                                 string compnay = "select State from CompnayDetails";
                                 DataTable dt2 = d.getDetailByQuery(compnay);
                                 string compnayid = "";
                                 foreach (DataRow dr7 in dt2.Rows)
                                 {
                                     compnayid = dr7[0].ToString();
                                 }
                                 string customer = "select CustState from customerdetails where custId='" + txtcustomercode.Text + "'";
                                 DataTable dt3 = d.getDetailByQuery(customer);
                                 string customerid = "";
                                 foreach (DataRow dr1 in dt3.Rows)
                                 {
                                     customerid = dr1[0].ToString();
                                 }
                                 // "select it.itemid,iq.ItemName,it.price,it.quantity,it.totalammount from customerorderdescriptions it join ItemDetails iq on it.ItemId=iq.ItemId  where orderid='" + txtRefNo.Text + "'"
                                 string selectItem = "select cod.ItemId,ad.ItemName,itd.HSN,cast(cod.price as numeric(38,2)),cod.quantity,cast((cod.price*cod.quantity)-(cod.price*cod.quantity*itd.Discount/100)as numeric(38,2)),itd.Discount,itd.CGST,itd.SGST,itd.IGST,itd.CESS,cod.totalammount from orderdetails od join customerorderdescriptions cod on od.orderid=cod.orderid join ItemDetails ad on cod.ItemId=ad.ItemId join ItemPriceDetail ipd on ad.ItemId=ipd.ItemId join ItemTaxDetail itd on ipd.ItemId=itd.ItemId where od.orderid='" + txtRefNo.Text + "'";
                                 DataTable dt4 = d.getDetailByQuery(selectItem);
                                 int totalrowcount = addToCartTable.Rows.Count;
                                 for (int rowcount = 0; rowcount < totalrowcount; rowcount++)
                                 {
                                     addToCartTable.Rows.RemoveAt(0);
                                 }
                                 string txtcgst = "";
                                 string txtsgst = "";
                                 string txtigst = "";
                                 for (int b = 0; b < dt4.Rows.Count; b++)
                                 {
                                     DataRow dr1 = dt4.Rows[b];
                                     string itemcode = dr1[0].ToString();
                                     if (ls.Contains(itemcode))
                                     {
                                         continue;
                                     }
                             
                                     string itemcod = dr1[0].ToString();
                                     string productname = dr1[1].ToString();
                                     string hsn = dr1[2].ToString();
                                     string rate = dr1[3].ToString();
                                     string quantity = dr1[4].ToString();
                                     string taxablevalue = dr1[5].ToString();
                                     string discoun = dr1[6].ToString();
                                      txtcgst = dr1[7].ToString();
                                       txtsgst = dr1[8].ToString();
                                        txtigst = dr1[9].ToString();
                                     string cess = dr1[10].ToString();
                                     string totalamout = dr1[11].ToString();
                                     decimal amt = Convert.ToDecimal(totalamout);
                                     totel = totel + amt;
                                     if (compnayid != compnayid)
                                     {
                                         txtcgst = "0.00";
                                         txtsgst = "0.00";
                                     }
                                     if (compnayid == compnayid)
                                     {
                                         txtigst = "0.00";
                                     }
                                     dr1 = addToCartTable.NewRow();
                                     dr1[0] = itemcod.Trim();
                                     dr1[1] = productname.Trim();
                                     dr1[2] = hsn.Trim();
                                     dr1[3] = rate.Trim();
                                     dr1[4] = quantity.Trim();
                                     dr1[5] = discoun.Trim();
                                     dr1[6] = taxablevalue.Trim();
                                     
                                     dr1[7] = txtcgst.Trim();
                                     dr1[8] = txtsgst.Trim();
                                     dr1[9] = txtigst.Trim();
                                     dr1[10] = cess.Trim();
                                     dr1[11] = totalamout.Trim();
                                     int q = Convert.ToInt32(quantity.ToString());
                                     txtqtybuiled.Text = q.ToString();
                                     addToCartTable.Rows.Add(dr1);

                                    
                                 }
                                
                                  //gridsalesdelivary.DataSource = null;
                                 gridsalesdelivary.DataSource = addToCartTable;
                                 double setam = setAmount(5);
                                 double subtotal = WithTaxAmount(2);
                                 txtdicountamount.Text = setam.ToString();
                                 txtwithauttaxamount.Text = subtotal.ToString();
                                 double taxa = TaxAmount();
                                 txttaxamount.Text = taxa.ToString();
                                txtTotalAmmount.Text = totel.ToString("###0.00");
                                
                                // txtwithauttaxamount.Text = totel.ToString("###0.00");

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
                         butRemoveItem.Enabled = false;
                         txtRefNo.ReadOnly = false;
                         txtqtybuiled.Text = "0.00";
                         makeblank();

                         e.Handled = false;
                     }
                     else
                     {
                         e.Handled = true;
                     }
                 }
             }


        // }



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
           
            //double totalAmount = 0.00;
            //// txtTotalAmmount.Text = "0";
            //if (txtTotalAmmount.Text == "")
            //{
            //    txtTotalAmmount.Text = "0.00";
            //}
            //if (txtRefNo.Text == "")
            //{

            //    foreach (DataRow dr in addToCartTable.Rows)
            //    {
            //        string exceptrow=dr[6].ToString();
            //        if (exceptrow == "")
            //        {
            //            exceptrow = "0.0";
            //        }
            //        totalAmount += Convert.ToDouble(exceptrow);
            //    }
            //    double s = totalAmount;
            //    double d = 1;
            //    double total = Convert.ToDouble(txtTotalAmmount.Text);
            //    double g = Convert.ToDouble(txttax.Text);
            //    double tax = d + ((g / 100));
            //    double taxamount = total / tax;
            //    double totaltax = total - taxamount;
            //    txttaxamount.Text = totaltax.ToString();
            //    double dis = Convert.ToDouble(txtdicountamount.Text);
            //    double dis1 = total * dis / 100;
            //    double withauttax = total - dis1;
            //    txtwithauttaxamount.Text = withauttax.ToString();
            //    txtwithauttaxamount.Text = s.ToString();
            //}


            //if (txtRefNo.Text != "")
            //{
            //    foreach (DataRow dr in addToCartTable.Rows)
            //    {
            //        totalAmount += Convert.ToDouble(dr[6].ToString());
            //    }
            //    double s1 = totalAmount;
            //    double d1 = 1;
            //    double total1 = Convert.ToDouble(txtTotalAmmount.Text);
            //    double g1 = Convert.ToDouble(txttax.Text);
            //    double tax1 = d1 + ((g1 / 100));
            //    double taxamount1 = total1 / tax1;
            //    double totaltax1 = total1 - taxamount1;
            //    txttaxamount.Text = totaltax1.ToString();
            //    double dis2 = Convert.ToDouble(txtdiccount.Text);
            //    double dis3 = s1 * dis2 / 100;
            //    double withauttax1 = total1 - dis3;

            //    txtwithauttaxamount.Text = withauttax1.ToString();
            //    txtwithauttaxamount.Text = s1.ToString();
            //}
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
            Double total = Convert.ToDouble(txtTotalAmmount.Text);
            txtInvoiceAmount.Text = total.ToString("###0.00");
            
            //btnSave.TabStop = true;
            //btnClose.TabStop = true;
        }
        private void CashAmount_Leave_1(object sender, EventArgs e)
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
            add();
        }

        private void txtCreditAmount_Leave_1(object sender, EventArgs e)
        {
            //if (txtCreditAmount.Text == "")
            //{
            //    txtCreditAmount.Text = "0.00";
            //}
            //if (txtCreditAmount.Text != "0.00")
            //{
            //    string amount = txtCreditAmount.Text + ".00";
            //    txtCreditAmount.Text = amount;
            //    Double Amount = Convert.ToDouble(txtCreditAmount.Text);
            //    Double Amount1 = Convert.ToDouble(CashAmount.Text);
            //    Double amount2 = Amount + Amount1;
            //    string Amount2 = amount2.ToString();
            //    txtTotalAmount1.Text = Amount2 + ".00";
            //}
            add();
        }

        private void txtChequeAmount_Leave_1(object sender, EventArgs e)
        {
            if (txtCreditAmount.Text == "0.00")
            {
               // credittext1();
            }
            if (txtCreditAmount.Text != "0.00")
            {
               // credittext();
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
                add();
            }
        }
        //public void Ewalled()
        //{
        //    txtTransactionNumber.ReadOnly = false;
        //    EWalletCompanyName.ReadOnly = false;
        //    dataGridView2.Enabled = false;
        //    txtTransactionNumber.TabStop = false;
        //    EWalletCompanyName.TabStop = false;

        //}
        //public void Ewalled1()
        //{

        //    txtTransactionNumber.ReadOnly = true;
        //    EWalletCompanyName.ReadOnly = true;
        //    dataGridView2.Enabled = true;
        //    txtTransactionNumber.TabStop = false;
        //    EWalletCompanyName.TabStop = false;
        //}
        private void txtEwalletAmount_Leave_1(object sender, EventArgs e)
        {
            if (txtEwalletAmount.Text == "0.00")
            {
               // Ewalled1();
            }
            else
            {
               // Ewalled();
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
            add();
        }

        private void txtCouponAmount_Leave_1(object sender, EventArgs e)
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
            add();
        }

        private void txtTotalAmount1_TextChanged_1(object sender, EventArgs e)
        {
            BalAmunt = 0.00;
            bal2 = 0.00;
            txtNetAmount.Text = txtTotalAmount1.Text;
            Double Amount = Convert.ToDouble(txtTotalAmount1.Text);
            Double Amount1 = Convert.ToDouble(txtInvoiceAmount.Text);
            Double Amount2 = Amount1 - Amount;
            string Amount3 = Amount2.ToString();
            txtBalance.Text = Amount2.ToString("##0.00");
            if (txtRturned.Text == "0.00")
            {
                txtRturned.ReadOnly = true;
            }
            if (Amount1 < Amount)
            {
                txtRturned.ReadOnly = false;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            
            createnewsave();
            pnlSalesPayment.Visible = false;
            crystalReportViewer2.Visible = true;
            txtdiccount.ReadOnly = true;
            txtdiccount.Text = "0.00";
            
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            if (txtcustomercode.Text == "C")
            {
                txtcustomercode.Focus();
                butcustomercode.TabStop = true;
                txtcustomercode.TabStop = true;
               // salesedelivarytabindex();

            }
            else if (gridsalesdelivary.Rows.Count > 1 && txtItemCode.Text == "I")
            {
                txtItemCode.Focus();
                butitembutton.TabStop = true;
                txtItemCode.TabStop = true;
                butRemoveItem.TabStop = true;
                butSaveButton.TabStop = true;
                butClose.TabStop = true;
                ButSelectPurchaseOrder.TabStop = true;
                txtcustomercode.TabStop = true;
                butcustomercode.TabStop = true;
            }
            else if (txtItemCode.Text == "I")
            {
                txtItemCode.Focus();
                butitembutton.TabStop = true;
                txtItemCode.TabStop = true;
            }

            else if (txtItemCode.Text != "I")
            {
                txtQuantity.Focus();
            }
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
                Double totaldicount = Convert.ToDouble(txtdiccount.Text);
                txtdiccount.Text = totaldicount.ToString("###0.00");
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
                    txtdicountamount.Text = dis.ToString("###0.00");

                }
                if (txtdiccount.Text == "")
                {
                    txtdiccount.Text = "0.00";
                }
                Double totaldicount = Convert.ToDouble(txtdiccount.Text);
                txtdiccount.Text= totaldicount.ToString("###0.00");
            }

        }

        private void CashAmount_TextChanged(object sender, EventArgs e)
        {
            add();
            //if (CashAmount.Text != "0")
            //{
            //    //CashAmount.Text = "";
            //    string amount = CashAmount.Text;
            //    //CashAmount.Text = amount;
            //    double amount1 = 0.0;
            //    if (double.TryParse(amount, out amount1))
            //    {
            //        txtTotalAmount1.Text = CashAmount.Text;
            //    }
            //}
        }

        private void CashAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
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
                    add();
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        //public void credittext()
        //{
        //    txtCardNumber.ReadOnly = false;
        //    txtDebitBankName.ReadOnly = false;
        //    CmbCardType.Enabled = true;
        //    txtCardNumber.TabStop = true;
        //    txtDebitBankName.TabStop = true;
        //}
        //public void credittext1()
        //{
        //    txtCardNumber.ReadOnly = true;
        //    txtDebitBankName.ReadOnly = true;
        //    CmbCardType.Enabled = true;
        //    txtCardNumber.TabStop = true;
        //    txtDebitBankName.TabStop = true;
        //}
        //public void chequetxt()
        //{
        //    txtChequeBankName.ReadOnly = false;
        //    txtChequeNumber.ReadOnly = false;
        //    dataGridView2.Enabled = false;
        //    txtChequeBankName.TabStop = false;
        //    txtChequeNumber.TabStop = false;

        //}
        //public void chequetxt1()
        //{
        //    txtChequeBankName.ReadOnly = true;
        //    txtChequeNumber.ReadOnly = true;
        //    dataGridView2.Enabled = true;
        //    txtChequeBankName.TabStop = true;
        //    txtChequeNumber.TabStop = true;
        //}
        private void txtChequeAmount_TextChanged(object sender, EventArgs e)
        {
            add();
            //if (txtChequeAmount.Text == "0.00")
            //{
            //    chequetxt1();
            //}
            //if (txtChequeAmount.Text != "0.00")
            //{
            //    chequetxt();
            //    string amount = txtChequeAmount.Text;
            //    double amount1 = 0.0;
            //    if (double.TryParse(amount, out amount1))
            //    {
            //        txtChequeAmount.Text = amount;
            //        //txtNetAmount.Text = amount;
            //        Double Amount = Convert.ToDouble(txtCreditAmount.Text);
            //        Double Amount1 = Convert.ToDouble(CashAmount.Text);
            //        Double Amount3 = Convert.ToDouble(txtChequeAmount.Text);
            //        Double amount2 = Amount + Amount1 + Amount3;
            //        //string Amount2 = amount2.ToString();
            //        txtTotalAmount1.Text = amount2.ToString("##0.00");
            //    }
            //}
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
                    add();
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtEwalletAmount_TextChanged(object sender, EventArgs e)
        {
            //if (txtEwalletAmount.Text == "")
            //{
            //    Ewalled1();
            //}
            //else if (txtEwalletAmount.Text != "0")
            //{
            //    Ewalled();
            //    string amount = txtEwalletAmount.Text;
            //    double amount1 = 0.0;
            //    if (double.TryParse(amount, out amount1))
            //    {
            //        txtEwalletAmount.Text = amount;
            //        Double Amount = Convert.ToDouble(txtCreditAmount.Text);
            //        Double Amount1 = Convert.ToDouble(CashAmount.Text);
            //        Double Amount3 = Convert.ToDouble(txtChequeAmount.Text);
            //        Double Amount4 = Convert.ToDouble(txtEwalletAmount.Text);
            //        Double amount2 = Amount + Amount1 + Amount3 + Amount4;
            //        string Amount2 = amount2.ToString();
            //        txtTotalAmount1.Text = Amount2;
            //    }
            //}
            add();
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
                    add();
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtCouponAmount_TextChanged(object sender, EventArgs e)
        {
            //if (txtCouponAmount.Text == "0.00")
            //{
            //    CmbCompany.Enabled = true;
            //    //label23.Visible = false;
            //}
            //if (txtCouponAmount.Text != "0.00")
            //{
            //    CmbCompany.Enabled = false;
            //    //label23.Visible = true;
            //    string amount = txtCouponAmount.Text;
            //    //txtCouponAmount.Text = amount;
            //    double amount1 = 0.0;
            //    if (double.TryParse(amount, out amount1))
            //    {
            //        Double Amount = Convert.ToDouble(txtCreditAmount.Text);
            //        Double Amount1 = Convert.ToDouble(CashAmount.Text);
            //        Double Amount3 = Convert.ToDouble(txtChequeAmount.Text);
            //        Double Amount4 = Convert.ToDouble(txtEwalletAmount.Text);
            //        Double Amount5 = Convert.ToDouble(txtCouponAmount.Text);
            //        Double amount2 = Amount + Amount1 + Amount3 + Amount4 + Amount5;
            //        string Amount2 = amount2.ToString();
            //        txtTotalAmount1.Text = amount2.ToString("##0.00");
            //    }
            //}
            add();
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
                    add();
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
        double BalAmunt = 0;
        Double bal2 = 0;
        private void txtRturned_TextChanged(object sender, EventArgs e)
        {
            if (txtRturned.Text == ".")
            {
                txtRturned.Text = "0.00";
                txtRturned.SelectAll();
                return;
            }
            if (txtBalance.Text == "")
            {
                txtBalance.Text = "0.00";
            }
            if (txtRturned.Text == "")
            {
                txtRturned.Text = "0.00";
            }

            if (BalAmunt == 0)
            {
                BalAmunt = Convert.ToDouble(txtBalance.Text);
            }
            if (bal2 == 0)
            {
                bal2 = Convert.ToDouble(txtBalance.Text) * -1;
            }
            Double return3 = Convert.ToDouble(txtRturned.Text);
            if (bal2 < return3)
            {

                MessageBox.Show("please corrct Amount");
                txtRturned.Text = "0.00";
                txtRturned.Focus();
                txtRturned.SelectAll();
                txtBalance.Text = BalAmunt.ToString("###0.00");
            }
            else
            {
                string sub = BalAmunt.ToString();
                string return1 = txtRturned.Text;
                double amount1 = 0.0;
                if (double.TryParse(sub, out amount1))
                {
                    double bal = Convert.ToDouble(sub);
                    if (double.TryParse(return1, out amount1))
                    {
                        double ReturnAmount = Convert.ToDouble(txtRturned.Text);
                        double bal1 = bal + ReturnAmount;
                        txtBalance.Text = bal1.ToString("###0.00");
                    }
                }
            }
        }

        private void txtRturned_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
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
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtCreditAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtCreditAmount.Text == "0.00" && txtCreditAmount.Text == "")
            {
               // credittext1();
                txtTotalAmount1.Text = "0.00";
            }
            if (txtCreditAmount.Text != "0.00")
            {
                //credittext();
                string amount = txtCreditAmount.Text;
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

        private void txtCreditAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
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
         public Double setAmount(int value)
        {
            Double amount = 0.00;
            DataGridViewRowCollection RowCollection = gridsalesdelivary.Rows;
            for (int a = 0; a < RowCollection.Count - 1; a++)
            {

                DataGridViewRow currentRow = RowCollection[a];
                DataGridViewCellCollection cellCollection = currentRow.Cells;
                if (!string.IsNullOrWhiteSpace(cellCollection[value].Value.ToString()))
                {
                    string addamount = cellCollection[value].Value.ToString();
                    Double amount1 = Convert.ToDouble(addamount.ToString());
                    amount = amount + amount1;
                }
            }
            return amount;
        }


        public double WithTaxAmount(int value1)
        {
            Double subtotal = 0.00;
            DataGridViewRowCollection RowCollection1 = gridsalesdelivary.Rows;
            for (int a = 0; a < RowCollection1.Count - 1; a++)
            {

                DataGridViewRow currentRow = RowCollection1[a];
                DataGridViewCellCollection cellCollection = currentRow.Cells;
                if (!string.IsNullOrWhiteSpace(cellCollection[3].Value.ToString()))
                {
                    string addamount = cellCollection[3].Value.ToString();
                    string addamount1 = cellCollection[4].Value.ToString();
                    if (addamount1 != "")
                    {
                        Double amount1 = Convert.ToDouble(addamount.ToString());
                        Double amount2 = Convert.ToDouble(addamount1.ToString());
                        double withau = amount1 * amount2;
                        subtotal = subtotal + withau;
                    }
                }


            }
            return subtotal;
        }

        public Double TaxAmount()
        {

            Double amount = 0.00;
            DataGridViewRowCollection RowCollection = gridsalesdelivary.Rows;
            for (int a = 0; a < RowCollection.Count - 1; a++)
            {

                DataGridViewRow currentRow = RowCollection[a];
                DataGridViewCellCollection cellCollection = currentRow.Cells;
                if (!string.IsNullOrWhiteSpace(cellCollection[6].Value.ToString()))
                {
                    Double price = Convert.ToDouble(cellCollection[6].Value.ToString());
                    string addamount = cellCollection[8].Value.ToString();
                    string addamount1 = cellCollection[7].Value.ToString();
                    string addamount2 = cellCollection[9].Value.ToString();
                    string addamount3 = cellCollection[10].Value.ToString();
                    Double amount1 = Convert.ToDouble(addamount.ToString());
                    Double price1 = price * amount1 / 100;
                    Double amount2 = Convert.ToDouble(addamount1.ToString());
                    Double price2 = price * amount2 / 100;
                    Double amount3 = Convert.ToDouble(addamount2.ToString());
                    Double price3 = price * amount3 / 100;
                    string price7 = price3.ToString("###0.00");
                    Double price8 = Convert.ToDouble(price7);
                    Double amount4 = Convert.ToDouble(addamount3.ToString());
                    Double price4 = price * amount4 / 100;
                    Double price5 = price1 + price2 + price8 + price4;
                    amount = amount + price5;
                }

            }
            return amount;
        }
        private void txtCreditAmount_TextChanged_1(object sender, EventArgs e)
        {
            add();
        }

        private void txtCreditAmount_KeyPress_1(object sender, KeyPressEventArgs e)
        {
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
                    add();
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        public Double setDisAmount()
        {
            Double disamount = 0.00;
            DataGridViewRowCollection RowCollection = gridsalesdelivary.Rows;
;
            for (int a = 0; a < RowCollection.Count - 1; a++)
            {

                DataGridViewRow currentRow = RowCollection[a];
                DataGridViewCellCollection cellCollection = currentRow.Cells;
                if (!string.IsNullOrWhiteSpace(cellCollection[5].Value.ToString()))
                {
                    string addamount = cellCollection[5].Value.ToString();
                    string addamount1 = cellCollection[3].Value.ToString();
                    string addamount2 = cellCollection[4].Value.ToString();
                    if (addamount2 != "")
                    {
                        Double amount1 = Convert.ToDouble(addamount.ToString());
                        double amount2 = Convert.ToDouble(addamount1.ToString());
                        double amount3 = Convert.ToDouble(addamount2.ToString());
                        double rate = amount2 * amount3;
                        double rate1 = rate * amount1 / 100;
                        disamount = disamount + rate1;
                    }
                }


            }
            return disamount;
        }
        public Double WithTaxAmount()
        {
            Double amount = 0.00;
            DataGridViewRowCollection RowCollection = gridsalesdelivary.Rows;
            for (int a = 0; a < RowCollection.Count - 1; a++)
            {

                DataGridViewRow currentRow = RowCollection[a];
                DataGridViewCellCollection cellCollection = currentRow.Cells;
                if (!string.IsNullOrWhiteSpace(cellCollection[4].Value.ToString()))
                {
                    string addamount = cellCollection[4].Value.ToString();
                    string addamount1 = cellCollection[3].Value.ToString();
                    Double amount1 = Convert.ToDouble(addamount.ToString());
                    Double amount2 = Convert.ToDouble(addamount1.ToString());
                    Double Amount = amount2 * amount1;
                    amount = amount + Amount;
                }

            }
            return amount;
        }
        private void gridsalesdelivary_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string itemId = gridsalesdelivary.Rows[0].Cells[0].Value.ToString();
                string opening = "";
                 DataGridViewRowCollection RowCollection =gridsalesdelivary.Rows;
                string itemid2="";
                for (int a = 0; a < RowCollection.Count; a++)
                {
                    DataGridViewRow currentRow = RowCollection[a];
                    DataGridViewCellCollection cellCollection = currentRow.Cells;
                   // itemid2 = cellCollection[0].Value.ToString();
                    string j = "select c.CurrentQuantity,i.ItemId from ItemQuantityDetail c join ItemDetails i on c.ItemId=i.ItemId where i.ItemId='" + itemid2 + "'";
                    DataTable dt5 = d.getDetailByQuery(j);
                    foreach (DataRow dr in dt5.Rows)
                    {
                        opening = dr[0].ToString();
                        double g1 = Convert.ToDouble(opening);
                        for (int g2 = 0; g2 > g1;g2++ )
                        {
                            gridsalesdelivary.CurrentCell = GetCurrentRowOFGridView().Cells[0];
                            return;
                        }
                    }
                }
                if (gridsalesdelivary.Rows[0].Cells[0].Value == null)
                {
                    return;
                }
               
               
                if (itemId == "")
                {
                    return;
                }
                else
                {
                    //string select = "select ItemId from ItemDetails";
                    //DataTable identity = dbMainClass.getDetailByQuery(select);
                    //string ItemId = "";
                    //foreach (DataRow dr1 in identity.Rows)
                    //{
                    //    ItemId = dr1[0].ToString();
                    //}
                    //if (ItemId != itemId)
                    //{
                    //    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index - 1].Cells[0];
                    //    return;
                    //}
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (txtcustomercode.Text == "C")
                        {
                            MessageBox.Show("please select your customer code");
                            gridsalesdelivary.Rows.RemoveAt(0);
                            txtcustomercode.Focus();
                            return;
                        }
                        string company = "select state from CompnayDetails";
                        DataTable dt3 = d.getDetailByQuery(company);
                        string companystate = "";
                        foreach (DataRow dr in dt3.Rows)
                        {
                            companystate = dr[0].ToString();
                        }
                        string vendorState = "select vState from VendorDetails where venderId='" +txtcustomercode.Text + "'";
                        DataTable dt2 = d.getDetailByQuery(vendorState);
                        string vendorstate = "";
                        foreach (DataRow dr2 in dt2.Rows)
                        {
                            vendorstate = dr2[0].ToString();
                        }


                        string itemid = GetCurrentRowOFGridView().Cells[0].Value.ToString();

                        string item = "";
                        string selectQurry = "select ItemId from ItemDetails";
                        DataTable dt1 = d.getDetailByQuery(selectQurry);
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            item = dr1[0].ToString();
                            if (item == itemid)
                            {
                                break;
                            }

                        }
                        if (item == itemid)
                        {
                            string selectqurry = "select Ids.ItemName,itd.HSN, ipd.SalesPrice,itd.CGST,itd.SGST,itd.IGST,itd.CESS,itd.Discount from ItemDetails Ids  join ItemPriceDetail ipd on Ids.ItemId=ipd.ItemId join ItemTaxDetail itd on ipd.ItemId=itd.ItemId  where Ids.ItemId='" + itemid + "'";
                            DataTable dt = d.getDetailByQuery(selectqurry);
                            string rate = "";
                            string gst3 = "";
                            string gst4 = "";
                            string igst1 = "";
                            foreach (DataRow dr in dt.Rows)
                            {
                                gst3 = dr[3].ToString();
                                gst4 = dr[4].ToString();
                                igst1 = dr[5].ToString();
                                if (companystate != vendorstate)
                                {
                                    gst3 = "0.00";
                                    gst4 = "0.00";
                                }
                                if (companystate == vendorstate)
                                {
                                    igst1 = "0.00";
                                }
                                GetCurrentRowOFGridView().Cells[1].Value = dr[0].ToString();
                                GetCurrentRowOFGridView().Cells[2].Value = dr[1].ToString();
                                GetCurrentRowOFGridView().Cells[3].Value = dr[2].ToString();
                                GetCurrentRowOFGridView().Cells[7].Value = gst3.ToString();
                                GetCurrentRowOFGridView().Cells[8].Value = gst4.ToString();
                                GetCurrentRowOFGridView().Cells[9].Value = igst1.ToString();
                                GetCurrentRowOFGridView().Cells[10].Value = dr[6].ToString();
                                GetCurrentRowOFGridView().Cells[5].Value = dr[7].ToString();
                                rate = dr[2].ToString();
                            }

                            GetCurrentRowOFGridView().Cells[3].Value = rate;
                            string quantity = GetCurrentRowOFGridView().Cells[4].Value.ToString();
                            int h;
                            bool he = int.TryParse(quantity, out h);
                            if (he == false)
                            {
                                quantity = "0";
                                GetCurrentRowOFGridView().Cells[4].Value = "0";
                            }
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

                            double total = Convert.ToDouble(price.ToString());
                            double g = Convert.ToDouble(GetCurrentRowOFGridView().Cells[5].Value.ToString());
                            double di = price * g / 100;
                            price = price - di;
                            Double discontA = setDisAmount();
                            txtdicountamount.Text= discontA.ToString("###0.00");
                            GetCurrentRowOFGridView().Cells[4].Value = q1;
                            GetCurrentRowOFGridView().Cells[6].Value = price.ToString("###0.00");
                            Double gst = Convert.ToDouble(GetCurrentRowOFGridView().Cells[8].Value.ToString());
                            Double cgst = Convert.ToDouble(GetCurrentRowOFGridView().Cells[7].Value.ToString());
                            Double taxv = Convert.ToDouble(GetCurrentRowOFGridView().Cells[6].Value.ToString());
                            Double igst = Convert.ToDouble(GetCurrentRowOFGridView().Cells[9].Value.ToString());
                            Double csst = Convert.ToDouble(GetCurrentRowOFGridView().Cells[10].Value.ToString());
                            double g2 = price * gst / 100;
                            taxv = taxv + g2;
                            double g1 = price * cgst / 100;
                            taxv = taxv + g1;
                            Double g3 = price * igst / 100;
                            taxv = taxv + g3;
                            Double csst1 = price * csst / 100;
                            taxv = taxv + csst1;
                            Double TotalTax = TaxAmount();
                            txttaxamount.Text = TotalTax.ToString("###0.00");
                            GetCurrentRowOFGridView().Cells[11].Value = taxv.ToString("###0.00");
                            Double rat = Convert.ToDouble(GetCurrentRowOFGridView().Cells[11].Value.ToString());
                            Double totalammount = Convert.ToDouble(txtTotalAmmount.Text);
                            Double toat = setAmount(11);
                            txtTotalAmmount.Text = toat.ToString("###0.00");
                            Double withtotalammount = WithTaxAmount();
                            txtwithauttaxamount.Text = withtotalammount.ToString("###0.00");
                            Double Quantity = setAmount(4);
                            txtqtybuiled.Text = Quantity.ToString();
                            gridsalesdelivary.CurrentCell = GetCurrentRowOFGridView().Cells[4];

                            if (q1 != 0)
                            {
                                gridsalesdelivary.CurrentCell = gridsalesdelivary.Rows[gridsalesdelivary.CurrentRow.Index + 1].Cells[0];
                            }

                            
                            //if (gridPurchaseOrder.Rows[gridPurchaseOrder.CurrentRow.Index - 1].Cells[0].Value != null)
                            //{
                            //    int co = gridPurchaseOrder.CurrentRow.Index;
                            //    DataGridViewRow selectedRow = gridPurchaseOrder.Rows[gridPurchaseOrder.CurrentRow.Index - 1];
                            //    selectedRow.Selected = true;
                            //    selectedRow.Cells[4].Selected = true;
                            //    // gridPurchaseOrder.CurrentCell = gridPurchaseOrder.CurrentRow.Cells[5];//[gridPurchaseOrder.CurrentCell.ColumnIndex + 2, gridPurchaseOrder.CurrentCell.RowIndex];
                            //    //gridPurchaseOrder.Focus();
                            //}

                            //}
                        }
                        else
                        {

                            if (item != itemid)
                            {
                                if (item != itemid)
                                {
                                    int selectedindex = gridsalesdelivary.CurrentCell.RowIndex;
                                    if (selectedindex > 0)
                                    {
                                        gridsalesdelivary.Rows.RemoveAt(selectedindex - 1);
                                    }


                                    MessageBox.Show("please select your correct itemid");

                                    //gridsalesorder.CurrentCell = gridsalesorder.Rows[gridsalesorder.CurrentRow.Index - 1].Cells[0];

                                }

                            }
                            //if (itemid != item)
                            //{
                            //    MessageBox.Show("please select your correct row ");
                            //    gridsalesdelivary.Rows[gridsalesdelivary.CurrentRow.Index].Cells[0].Value = "";
                            //    gridsalesdelivary.Rows[gridsalesdelivary.CurrentRow.Index].Cells[0].Selected = true;
                            //    //dataGridView1.AllowUserToAddRows = false;
                            //}
                        }

                    }

                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private double GetTotalAmountOfAllITem()
        {
            double totalAmount = 0.0;
            foreach (DataGridViewRow gridViewRow in gridsalesdelivary.Rows)
            {
                if (gridViewRow.Cells[0].Value != null && !string.IsNullOrWhiteSpace(gridViewRow.Cells[0].Value.ToString()))
                {
                    Double totalAmountForEachItem = Convert.ToDouble(gridViewRow.Cells[gridViewRow.Cells.Count - 1].Value);
                    totalAmount += totalAmountForEachItem;
                }
            }
            return totalAmount;
        }

        private void txtRturned_MouseClick(object sender, MouseEventArgs e)
        {
            txtRturned.SelectAll();
        }

        private void CashAmount_MouseClick(object sender, MouseEventArgs e)
        {
            CashAmount.SelectAll();
        }

        private void txtCreditAmount_MouseClick(object sender, MouseEventArgs e)
        {
            txtCreditAmount.SelectAll();
        }

        private void txtChequeAmount_MouseClick(object sender, MouseEventArgs e)
        {
            txtChequeAmount.SelectAll();
        }

        private void txtEwalletAmount_MouseClick(object sender, MouseEventArgs e)
        {
            txtEwalletAmount.SelectAll();
        }

        private void txtCouponAmount_MouseClick(object sender, MouseEventArgs e)
        {
            txtCouponAmount.SelectAll();
        }

        private void gridsalesdelivary_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            ValidationFails = false;
            int col = e.ColumnIndex;
            if (col == 4)
            {
                string value = e.FormattedValue.ToString();
                if (value != "")
                {

                    int quantiy;
                    bool validNumber = int.TryParse(value, out quantiy);
                    if (validNumber == false)
                    {
                        MessageBox.Show("please select your correct quantity");
                        e.Cancel = true;
                        ValidationFails = true;
                    }
                }
            }
        }
        private DataGridViewRow GetCurrentRowOFGridView()
        {

            int index = gridsalesdelivary.CurrentRow.Index;
            if (index == 0)
            {
                index = index + 1;
            }
            if (ValidationFails == false)
            {
                index = index - 1;
            }
            return gridsalesdelivary.Rows[index];
        }

       

       
    }


}


