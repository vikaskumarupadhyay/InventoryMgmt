using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace WindowsFormsApplication1
{
    public partial class salesorder : Form
    {
        List<string> ls = new List<string>();
        DB_Main d = new DB_Main();
        public salesorder()
        {
            InitializeComponent();
           

        }
        public int maxItemQuantity = 0;
        public int counter = 0;
        DataTable vendorDetails = new DataTable();
        DataTable addToCartTable = new DataTable();
        DataTable customerdetails = new DataTable();
        DataTable ItemDetails = new DataTable();
        private void tab()
        {
            txtcustomercode.Focus();
            txtcustomercode.TabStop = true;
            button1.TabStop = true;
            button2.TabStop = false;
            txtitemcode.TabStop = false;
            txtQuantity.TabStop = false;
            butadditem.TabStop = false;
            button4.TabStop = false;
            savebutton.TabStop = false;
            button6.TabStop = false;
            textBox1.TabStop = false;
            textBox2.TabStop = false;
            textBox3.TabStop = false;
        }

        private void tab1()
        {
            txtitemcode.Focus();
            button2.TabStop = true;
            txtitemcode.TabStop = true;
            txtcustomercode.TabStop = true;
            button1.TabStop = true;

        }
        private void tab2()
        {
            txtQuantity.Focus();
            txtcustomercode.TabStop = false;
            button1.TabStop = true;
            button2.TabStop = true;
            txtitemcode.TabStop = true;
            button2.TabStop = true;
            txtcustomercode.TabStop = true;
            txtQuantity.TabStop = false;
            butadditem.TabStop = true;

            button4.TabStop = true;
            // gridsalesorder.TabStop = true;
            savebutton.TabStop = false;
            button6.TabStop = false;
            textBox1.TabStop = false;
            textBox2.TabStop = false;
            textBox3.TabStop = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // string selectquery1 = "select CustName as [Name],CustCompName as [Compnay Name],CustAddress as [Address],CustPhone as [Phone],Custmobile as [Mobole],CustFax as [Fax] from CustomerDetails";
            // string actualcolumn = "select CustName ,CustCompName ,CustAddress ,CustPhone ,Custmobile ,CustFax  from CustomerDetails";
            string selectquery1 = "select  Custd.CustId as [Customer ID] ,CustName AS Name ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustDesc AS Description,Custad.CustOpeningBalance AS [Opening Balance] , Custad.CustCurrentBalance AS [Current Ballance],CustPanNo AS [PAN NO], CustVatNo AS [VAT NO],CustCSTNo AS [CST NO]  ,CustServicetaxRegnNo AS [Service Tax Regn. No],CustExciseRegnNo AS [Excise Regn. No],Gstregnno AS[ Gst reg No]  from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID ";
            string actualcolumn = "select  Custd.CustId  ,CustName  ,CustCompName  ,CustAddress ,CustCity , CustState  ,CustZip  ,CustCountry  ,CustEmail , CustWebAddress ,CustPhone  ,CustMobile  ,CustFax ,CustDesc ,Custad.CustOpeningBalance , Custad.CustCurrentBalance ,CustPanNo , CustVatNo ,CustCSTNo  ,CustServicetaxRegnNo ,CustExciseRegnNo,Gstregnno   from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID ";
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
            comsearchsalesvalue.DataSource = custometable;
            comsearchsalesvalue.ValueMember = "actualcolumnname";
            comsearchsalesvalue.DisplayMember = "aliascolumnname";


            counter = 0;
            panel2.Visible = true;
            // string selectquery = "select Custid as [Customer Id], CustName as [Name],CustCompName as [Compnay Name],CustAddress as[Address],CustPhone as [Phone],CustMobile as [Mobile],CustFax as[Fax] from customerdetails";
            string selectquery = "select  Custd.CustId as [Customer ID] ,CustName AS Name ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustDesc AS Description,Custad.CustOpeningBalance AS [Opening Balance] , Custad.CustCurrentBalance AS [Current Ballance],CustPanNo AS [PAN NO], CustVatNo AS [VAT NO],CustCSTNo AS [CST NO]  ,CustServicetaxRegnNo AS [Service Tax Regn. No],CustExciseRegnNo AS [Excise Regn. No],Gstregnno as[gst reg no] from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID ";

            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView1.DataSource = dt;
            txtcustomercode.TabStop = false;
            button1.TabStop = false;
            comsearchsalesvalue.Focus();
            comsearchsalesvalue.TabIndex = 1;
            txtsearchvalue.TabIndex = 2;
            dataGridView1.TabIndex = 3;
            butback.TabIndex = 4;

        }
        public void rowcollection(DataGridViewCellCollection cell)
        {
            txtcustomercode.Text = cell[0].Value.ToString();
            txtcustname.Text = cell[1].Value.ToString();
            txtcustcompname.Text = cell[2].Value.ToString();
            txtcustaddress.Text = cell[3].Value.ToString();
            txtcustphone.Text = cell[4].Value.ToString();
            txtcustmobile.Text = cell[5].Value.ToString();
            txtcustfax.Text = cell[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string selectquery1 = "select  itm.ItemId as [Item Id],itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],cast(ipd.SalesPrice as numeric(38,2))as[Sales Price],cast(ipd.MrpPrice as numeric(38,2))as[Mrp Price] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId";
            string actualcolumn = "select top 1  itm.ItemId, itm.ItemName,itm.ItemCompName ,itm.ItemDesc ,ig.groupName,iul.unitName ,ipd.purChasePrice ,cast(ipd.SalesPrice as numeric(38,2)) ,cast(ipd.MrpPrice as numeric(38,2)),ipd.Margin ,iqd.OpeningQuantity ,iqd.CurrentQuantity from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId";
            //DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            // string selectquery1="select it.ItemName as[Name],ip.Mrpprice as[MRP],iq.CurrentQuantity as[Current Quantity] from ItemDetails it join ItemPriceDetail ip on it.Itemid=ip.Itemid join ItemQuantityDetail iq on ip.ItemId=iq.Itemid";
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
            comsearchsalesvalue.DataSource = custometable;
            comsearchsalesvalue.ValueMember = "actualcolumnname";
            comsearchsalesvalue.DisplayMember = "aliascolumnname";

            counter = 1;

            panel2.Visible = true;
            string selectquery = "select  itm.ItemId as [Item Id],itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],cast(ipd.purChasePrice as numeric(38,2)) as [Purchase Price],cast(ipd.SalesPrice as numeric(38,2))as[Sales Price],cast(ipd.MrpPrice as numeric(38,2))as[Mrp Price],cast(ipd.Margin as numeric(38,2)) as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId";

            //string selectquery = "select i.Itemid as[Item Id],i.Itemname as [Name],ip.MrpPrice as[MRP],iq.CurrentQuantity as [Current Quantity] from itemdetails i join itempricedetail ip on i.itemid=ip.itemid join itemquantitydetail iq on ip.itemid=iq.itemid";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView1.DataSource = dt;
            txtcustomercode.TabStop = false;
            button2.TabStop = false;

            comsearchsalesvalue.Focus();
            comsearchsalesvalue.TabIndex = 1;
            txtsearchvalue.TabIndex = 2;
            dataGridView1.TabIndex = 3;
            butback.TabIndex = 4;
            txtsearchvalue.Text = "";
        }

        public void rowcollection1(DataGridViewCellCollection cell1)
        {
            txtitemcode.Text = cell1[0].Value.ToString();
            txtProductName.Text = cell1[1].Value.ToString();
            txtRate.Text = cell1[7].Value.ToString();
            //maxItemQuantity = Convert.ToInt32((cell1[3].Value.ToString()));
            txtAmount.Text = "";

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            //txtQuantity.Text = string.Empty;
            //string QuantiTy = txtQuantity.Text;
            //int result = 0;
            //if (int.TryParse(QuantiTy, out result))
            //{

            //    int TotalQuantity = Convert.ToInt32(QuantiTy);
            //    if (TotalQuantity > 0)
            //    {
            //        double RatePerPice = Convert.ToDouble(txtRate.Text.Trim());
            //        txtAmount.Text = (TotalQuantity * RatePerPice).ToString();
            //    }
            //    else
            //    {
            //        txtAmount.Text = "";
            //    }
            //}
            //txtQuantity.ReadOnly = true;



            string select = "select CurrentQuantity from ItemQuantityDetail where itemid='" + txtitemcode.Text + "'";
            DataTable dt = d.getDetailByQuery(select);
           string s = "";
            foreach (DataRow dr in dt.Rows)
            {
                s = dr[0].ToString();

            }
           
           
          
            if (txtQuantity.Text != "")
            {
                int g = Convert.ToInt32(s);
                int quantity = Convert.ToInt32(txtQuantity.Text);
                if (quantity <= g)
                {
                    //MessageBox.Show("d");

                    if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                        if ((!string.IsNullOrEmpty(txtQuantity.Text)) && char.IsDigit(txtQuantity.Text, txtQuantity.Text.Length - 1) && (!string.IsNullOrEmpty(txtRate.Text)))
                        {
                            txtQuantity.ReadOnly = false;
                            int que = maxItemQuantity;
                            quantity = Convert.ToInt32(txtQuantity.Text);
                            double rate = Convert.ToDouble(txtRate.Text);
                            txtAmount.Text = (quantity * rate).ToString("###0.00");
                        }
                }

                else if (quantity > g)
                {
                    //int que = maxItemQuantity;
                    //quantity = Convert.ToInt32(txtQuantity.Text);
                    //double rate = Convert.ToDouble(txtRate.Text);
                    //txtAmount.Text = (quantity * rate).ToString("###0.00");
                  //  MessageBox.Show("Quantity is not available");
                   // txtQuantity.Text = "";
                    //txtQuantity.Text = "0";
                   // txtAmount.Text = "";
                }
               
            }


        }





        // MessageBox.Show("successfully");


        //else if (que < quantity)
        //{
        //    txtQuantity.Text = "";
        //    txtAmount.Text = "";
        //}

        private void makeblank()
        {
            txtitemcode.Enabled = true;
            button2.Enabled = true;
            txtcustomercode.Text = "C";
            txtcustname.Text = "";
            txtcustcompname.Text = "";
            txtcustaddress.Text = "";
            txtcustphone.Text = "";
            txtcustmobile.Text = "";
            txtcustfax.Text = "";
            txtitemcode.Text = "I";
            txtProductName.Text = "";
            txtRate.Text = "";
            txtQuantity.Text = "";
            txtAmount.Text = "";
            //txtdiscount.Text = "";
           // gridsalesorder.DataSource = "";
            txttotalammount.Text = "0";
            txtsearchvalue.Text = "";
            addToCartTable.Clear();
        }
        private void butadditem_Click(object sender, EventArgs e)
        {
           
            txtitemcode.Focus();
            txtcustomercode.TabStop = true;
            button1.TabStop = true;
            txttax.TabStop = false;
            string itemid = "";
            string quntity = "";
            string rate = "";
            int counter=0;
            foreach (DataRow dr3 in addToCartTable.Rows)
            {
                int q3 = 0;
                itemid = dr3[0].ToString();
                if (ls.Contains(itemid) && gridsalesorder.Rows[counter].DefaultCellStyle.Font!=null)
                {
                    counter++;
                    continue;
                }
                counter++;
                quntity = dr3[5].ToString();
                rate = dr3[4].ToString();

                if (itemid == txtitemcode.Text)
                {
                    int q1 = Convert.ToInt32(quntity);
                    int q2 = Convert.ToInt32(txtQuantity.Text);
                    q3 = q1 + q2;
                    dr3[5] = q3.ToString();
                    double rate1 = Convert.ToDouble(rate);
                    double rate6 = q3 * rate1;
                    double rate2 = Convert.ToDouble(txtAmount.Text);
                    double rate4 = Convert.ToDouble(txttotalammount.Text);
                    double rate3 = rate4 + rate2;
                    dr3[6] = rate6.ToString();
                    double rate5 = rate4 + rate2;
                    txttotalammount.Text = rate5.ToString("###0.00");//rate3.ToString();
                    // MessageBox.Show("Please Enter the Quanity");
                    txtitemcode.Text = "I";
                    txtProductName.Text = "";
                    txtRate.Text = "";
                    txtQuantity.Text = "";
                    txtAmount.Text = "";
                    txtQuantity.ReadOnly = true;
                }
            
            }




            //if (txtProductName.Text == "" && txtQuantity.Text == "")
            //{
            //    // MessageBox.Show("please enter the ");
            //}
            //else
            // {
            if (txtAmount.Text == "")
            {
                butadditem.Enabled = false;
                // txtAmount.Text = "0";
                // MessageBox.Show("Please Enter the Quanity");
            }
            else
            {
                string selectq = "select ids.ItemCompName,cast(ipd.MrpPrice as numeric(38,2))from ItemPriceDetail ipd join ItemDetails ids on ipd.ItemId=ids.ItemId where ipd.ItemId='" + txtitemcode.Text + "'";
                DataTable dta = d.getDetailByQuery(selectq);
                string ConpanyName = "";
                string Mrp = "";
                foreach (DataRow dr1 in dta.Rows)
                {
                    ConpanyName = dr1[0].ToString();
                    Mrp = dr1[1].ToString();
                }
                button4.Enabled = true;
                DataRow dr = addToCartTable.NewRow();
                dr[0] = txtitemcode.Text.Trim();
                dr[1] = txtProductName.Text.Trim();
                dr[2] = ConpanyName.Trim();
                dr[3] = Mrp.Trim();
                dr[5] = txtQuantity.Text.Trim();
                dr[4] = txtRate.Text.Trim();
                dr[6] = txtAmount.Text.Trim();

                //dr[5] = txtAmount.Text.Trim();
                addToCartTable.Rows.Add(dr);
                gridsalesorder.DataSource = addToCartTable;
                double totalAmount = Convert.ToDouble(txttotalammount.Text);
                totalAmount += Convert.ToDouble(txtAmount.Text.Trim());
                txttotalammount.Text = totalAmount.ToString("###0.00");
                txtwithautaxamount.Text= totalAmount.ToString();

                txtitemcode.Text = "I";
                txtProductName.Text = "";
                txtRate.Text = "";
                txtQuantity.Text = "";
                txtAmount.Text = "";
                // txtItemCode.Focus();
                butadditem.Enabled = false;
                //txtRemoveItem.Focus();
                txtQuantity.TabStop = false;
                txtQuantity.ReadOnly = true;
                //}
               // ls.Clear();
            }
            if (gridsalesorder.Rows.Count > 1)
            {
                textBox20.ReadOnly = false;
            }
            txtitemcode.Select(txtitemcode.Text.Length, 0);
           

        }

        private void salesorder_Load(object sender, EventArgs e)
        {
            txtcustomercode.Select(txtcustomercode.Text.Length, 0);
            txtitemcode.Select(txtitemcode.Text.Length, 0);
            textBox20.ReadOnly = true;

            gridsalesorder.DataSource = addToCartTable;
            discountamount.Visible = false;
            txttaxamount.Visible = false;
            txtwithautaxamount.Visible = false;
           
            crystalReportViewer1.Visible = false;
            tab();
            discountamount.Text = "0";
            txttaxamount.Text = "0";
            comsearchsalesvalue.Focus();
            button4.Enabled = false;
            butadditem.Enabled = false;
            dtpdate.Value = DateTime.Today;
            // txtcustomercode.Text = "C";
            // txtitemcode.Text = "I";
            panel2.Visible = false;
            Purchase.PurchaseDetails purChaseDetailObj = new Purchase.PurchaseDetails();
            vendorDetails = purChaseDetailObj.GetVendorDetaisInDataTable();
            ItemDetails = purChaseDetailObj.GetItemPriceAndNameDetaisInDataTable();
            setAutoCompleteMode(txtProductName, "ItemName", ItemDetails);
            setAddToCraftTable();
            string selectquery = "select orderid from orderdetails";
            DataTable dt3 = d.getDetailByQuery(selectquery);
            string id = "";
            foreach (DataRow dr in dt3.Rows)
            {
                id = dr[0].ToString();
            }
            if (id == "")
            {
                id = "1";
                txtsrno.Text = id;
            }
            else
            {
                int t = Convert.ToInt32(id);
                int t1 = t + 1;
                txtsrno.Text = t1.ToString();
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
                textBox16.Text = dr[1].ToString();
            }
           // gridsalesorder.Rows.Add();

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
            addToCartTable.Columns.Add(new DataColumn("Compnay Name"));
            addToCartTable.Columns.Add(new DataColumn("MRP"));
            addToCartTable.Columns.Add(new DataColumn("Rate"));
            addToCartTable.Columns.Add(new DataColumn("Quantity"));
            addToCartTable.Columns.Add(new DataColumn("Amount"));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gridsalesorder.DefaultCellStyle.SelectionBackColor = Color.Red;
            button4.Enabled = false;
            gridsalesorder.Focus();
            gridsalesorder.TabIndex = 1;
            button2.Enabled = false;
            txtitemcode.Enabled = false;
            //if (addToCartTable.Rows.Count > 0)
            //{
            //    string Amount = gridsalesorder.SelectedRows[0].Cells[4].Value.ToString();
            //    double totalAmount = Convert.ToDouble(txttotalammount.Text);
            //    totalAmount -= Convert.ToDouble(Amount.Trim());
            //    txttotalammount.Text = totalAmount.ToString();
            //    int index = gridsalesorder.SelectedRows[0].Index;
            //    addToCartTable.Rows.RemoveAt(index);

            //    gridsalesorder.DataSource = addToCartTable;
            //    if (addToCartTable.Rows.Count == 0)
            //    {
            //        txttotalammount.Text = "0.0";
            //        txtdiscount.Text = "0.0";
            //    }
            //    if (gridsalesorder.Rows.Count > 0)
            //    {
            //        button4.Enabled = true;
            //    }
            //    else
            //    {
            //        button4.Enabled = false;
            //    }
            // txtQuantity.TabStop = false;
            // }
            //if (gridsalesorder.Rows.Count > 1)
            //{
            //    textBox20.ReadOnly = false;
            //}
          
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
           
            panel2.Visible = false;
            if (gridsalesorder.Rows.Count ==1)
            {
               // gridsalesorder.AllowUserToAddRows = true;
                MessageBox.Show("please select your customer id");
            }

           else if (ls.Count == gridsalesorder.Rows.Count - 1)
            {
                MessageBox.Show("please select your item id");
                txtitemcode.Focus();
                return;
            }

            //if (id == "")
            //{
            //    id = "1";
            //    txtsrno.Text = id;
            //}
            //else
            //{
            //    int t = Convert.ToInt32(id);
            //    int t1 = t + 1;
            //    txtsrno.Text = t1.ToString();
            //}
            //DataGridViewRowCollection call = gridsalesorder.Rows;
            //for (int c = 0; c < call.Count; c++)
            //{
            //        DataGridViewRow currentRow1 = call[c];
            //        DataGridViewCellCollection cellCollection1 = currentRow1.Cells;
            //        string itid = cellCollection1[0].Value.ToString();
            //        string que = cellCollection1[3].Value.ToString();






            //string qurry = "select CurrentQuantity from ItemQuantityDetail where ItemId='" + itid + "'";
            //DataTable dt = d.getDetailByQuery(qurry);
            //string id = "";
            //foreach (DataRow dr in dt.Rows)
            //{
            //    id = dr["CurrentQuantity"].ToString();
            //}

            //int curentQuntity = Convert.ToInt32(que);
            //int cuentQuantity = Convert.ToInt32(id);
            //int lastQuantity = cuentQuantity - curentQuntity;
            //string id1 = lastQuantity.ToString();
            //string updateQurry = "update ItemQuantityDetail set CurrentQuantity='" + id1 + "'where ItemId='" + itid + "'";
            //int insertedRows2 = d.saveDetails(updateQurry);
            //  }
            gridsalesorder.AllowUserToAddRows = false;

            counter = 0;
            if (counter == 0)
            {
               


                DataGridViewRowCollection rowcollection = gridsalesorder.Rows;
                List<string> show = new List<string>();
                for (int a = 0; a < rowcollection.Count; a++)
                {

                    DataGridViewRow currentrow = rowcollection[a];
                    DataGridViewCellCollection cellcollection = currentrow.Cells;
                    string txtitemcode = cellcollection[0].Value.ToString();
                    if (ls.Contains(txtitemcode) && gridsalesorder.Rows[counter].DefaultCellStyle.Font != null)
                    {
                        counter++;
                        continue;
                    }
                    counter++;
                    string txtProductName = cellcollection[1].Value.ToString();
                    string Compnayname = cellcollection[2].Value.ToString();
                    string mrp = cellcollection[3].Value.ToString();
                    string txtRate = cellcollection[4].Value.ToString();
                    string txtQuantity = cellcollection[5].Value.ToString();
                    string txtAmount = cellcollection[6].Value.ToString();
                    string Orderid = txtsrno.Text;
                    string query = "insert into customerorderdescriptions Values('" + txtsrno.Text + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";

                    
                    string insertquery = "insert into  orderdetails values('" + txtcustomercode.Text + "','" + dtpdate.Text + "','" + txttotalammount.Text + "','" + textBox20.Text + "','" + discountamount.Text + "','" + txttax.Text + "','" + txttaxamount.Text + "','" + txtwithautaxamount.Text + "')";
                    int insertrows = d.saveDetails(insertquery);
                    show.Add(query);
                }
                
               

                int inserirow1 = d.saveDetails(show);
                if (inserirow1 > 0)
                {
                    MessageBox.Show("details save successfully");
                   
                    DialogResult result = MessageBox.Show("this page is print", "Impotant questiuon", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        panel2.Visible = true;
                        crystalReportViewer1.Visible = true;
                        gridsalesorder.AllowUserToAddRows = false;
                        // "Data Source=DINESHTIWARI-PC\\SQLEXPRESS;Initial Catalog=SalesMaster;Integrated Security=True";
                        SqlConnection con = new SqlConnection();
                        string a = ConfigurationManager.AppSettings["ConnectionString"];
                        con.ConnectionString = a;
                        con.Open();
                      
                        string selectquery = "select * from salesorderreport where orderid='" + txtsrno.Text + "'";
                        SqlCommand cmd = new SqlCommand(selectquery, con);
                        SqlDataAdapter sd = new SqlDataAdapter(cmd);
                        DataSet1 ds = new DataSet1();
                        sd.Fill(ds, "compnaydetails");

                        //CrystalReport1 cr = new CrystalReport1();
                        // cr.ParameterFields.Add(textBox1.Text);
                        // cr.Load("C:\\Users\\dineshtiwari\\Documents\\Visual Studio 2010\\Projects\\report11\\report11\\CrystalReport1.rpt");

                        CrystalReport1 report1 = new CrystalReport1();
                        report1.SetDataSource(ds.Tables[1]);

                        crystalReportViewer1.ReportSource = report1;
                        crystalReportViewer1.Refresh();
                        con.Close();
                        if (result == System.Windows.Forms.DialogResult.No)
                        {
                            crystalReportViewer1.Visible = false;
                            panel2.Visible = false;
                            
                        }
                        int id = Convert.ToInt32(txtsrno.Text);
                        id = id + 1;
                        txtsrno.Text = id.ToString();
                        makeblank();
                    }
                    else
                    {
                        gridsalesorder.AllowUserToAddRows = true;
                        
                    }
                    makeblank();
                   
                    int id1 = Convert.ToInt32(txtsrno.Text);
                    id1 = id1 + 1;
                    txtsrno.Text = id1.ToString();
                    txtitemcode.Focus();
                    ls.Clear();


                }
              
                

            }
          

            //MessageBox.Show("please select your first item id");
            txtcustomercode.Select(txtcustomercode.Text.Length, 0);
            gridsalesorder.AllowUserToAddRows = true;
            txtcustomercode.Focus();
           
           
        }

        public void cretenew()
        {
            panel2.Visible = false;
            //if (id == "")
            //{
            //    id = "1";
            //    txtsrno.Text = id;
            //}
            //else
            //{
            //    int t = Convert.ToInt32(id);
            //    int t1 = t + 1;
            //    txtsrno.Text = t1.ToString();
            //}
            //DataGridViewRowCollection call = gridsalesorder.Rows;
            //for (int c = 0; c < call.Count; c++)
            //{
            //        DataGridViewRow currentRow1 = call[c];
            //        DataGridViewCellCollection cellCollection1 = currentRow1.Cells;
            //        string itid = cellCollection1[0].Value.ToString();
            //        string que = cellCollection1[3].Value.ToString();



            


            //string qurry = "select CurrentQuantity from ItemQuantityDetail where ItemId='" + itid + "'";
            //DataTable dt = d.getDetailByQuery(qurry);
            //string id = "";
            //foreach (DataRow dr in dt.Rows)
            //{
            //    id = dr["CurrentQuantity"].ToString();
            //}

            //int curentQuntity = Convert.ToInt32(que);
            //int cuentQuantity = Convert.ToInt32(id);
            //int lastQuantity = cuentQuantity - curentQuntity;
            //string id1 = lastQuantity.ToString();
            //string updateQurry = "update ItemQuantityDetail set CurrentQuantity='" + id1 + "'where ItemId='" + itid + "'";
            //int insertedRows2 = d.saveDetails(updateQurry);
            //  }
            gridsalesorder.AllowUserToAddRows = false;

            counter = 0;
            if (counter == 0)
            {
                string insertquery = "insert into  orderdetails values('" + txtcustomercode.Text + "','" + dtpdate.Text + "','" + txttotalammount.Text + "','" + textBox20.Text + "','" + discountamount.Text + "','" + txttax.Text + "','" + txttaxamount.Text + "','" + txtwithautaxamount.Text + "')";
                int insertrows = d.saveDetails(insertquery);


                DataGridViewRowCollection rowcollection = gridsalesorder.Rows;
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
                    string txtProductName = cellcollection[1].Value.ToString();
                    string Compnayname = cellcollection[2].Value.ToString();
                    string mrp = cellcollection[3].Value.ToString();
                    string txtRate = cellcollection[4].Value.ToString();
                    string txtQuantity = cellcollection[5].Value.ToString();
                    string txtAmount = cellcollection[6].Value.ToString();
                    string Orderid = txtsrno.Text;
                    string query = "insert into customerorderdescriptions Values('" + txtsrno.Text + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";

                    show.Add(query);
                }


                int inserirow1 = d.saveDetails(show);
                if (inserirow1 > 0)
                {
                    MessageBox.Show("details save successfully");
                    panel2.Visible = true;
                    DialogResult result = MessageBox.Show("this page is print", "Impotant questiuon", MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        crystalReportViewer1.Visible = true;
                        gridsalesorder.AllowUserToAddRows = false;
                        string a = "Data Source=NITU;Initial Catalog=SalesMaster;Integrated Security=True";
                        SqlConnection con = new SqlConnection(a);
                        con.Open();
                        string selectquery = "select * from salesorderreport where orderid='" + txtsrno.Text + "'";
                        SqlCommand cmd = new SqlCommand(selectquery, con);
                        SqlDataAdapter sd = new SqlDataAdapter(cmd);
                        DataSet1 ds = new DataSet1();
                        sd.Fill(ds, "compnaydetails");

                        //CrystalReport1 cr = new CrystalReport1();
                        // cr.ParameterFields.Add(textBox1.Text);
                        // cr.Load("C:\\Users\\dineshtiwari\\Documents\\Visual Studio 2010\\Projects\\report11\\report11\\CrystalReport1.rpt");

                        CrystalReport1 report1 = new CrystalReport1();
                        report1.SetDataSource(ds.Tables[1]);

                        crystalReportViewer1.ReportSource = report1;
                        crystalReportViewer1.Refresh();
                        con.Close();
                        if (result == System.Windows.Forms.DialogResult.No)
                        {
                            crystalReportViewer1.Visible = false;
                            panel2.Visible = false;
                        }
                        int id = Convert.ToInt32(txtsrno.Text);
                        id = id + 1;
                        txtsrno.Text = id.ToString();
                        makeblank();
                    }
                    else
                    {
                        MessageBox.Show("details save not successfully");
                    }


                }
                txtcustomercode.Focus();

            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            if (e.KeyChar == (char)Keys.Enter)
            {
                if ((txtQuantity.Text == "") || (txtQuantity.Text == "0"))
                {
                    MessageBox.Show("please select your correct quantity");
                    txtQuantity.Focus();
                }
                else
                {
                    butadditem.Focus();
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
                        txtAmount.Text = "";
                        e.Handled = false;
                    
                }
                else
                {
                    e.Handled = true;
                }
                if (txtQuantity.Text == "")
                {
                    MessageBox.Show("please select your correct quantity");
                    txtQuantity.Text = "";
                    txtAmount.Text = "";
                }
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void gridsalesorder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

           DataGridViewCellCollection Collection1 =gridsalesorder.Rows[e.RowIndex].Cells;
            rowcollection1(Collection1);
           // panel1.Visible = false;
        }

        private void txtcustomercode_TextChanged(object sender, EventArgs e)
        {
            if (!txtcustomercode.Text.StartsWith("C"))
            {
                txtcustomercode.Text = string.Concat("C", txtcustomercode.Text);
                txtcustomercode.Select(txtcustomercode.Text.Length, 0);
            }

            // if (txtcustomercode.Text.Trim() != "" && txtcustomercode.Text.StartsWith("C"))

            // {

            // setvalue();
            ///}
            // tab1();
            string selectquery = "select CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from CustomerDetails Where Custid='" + txtcustomercode.Text + "'";
            DataTable dt = d.getDetailByQuery(selectquery);
            // 
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtcustname.Text = dr[0].ToString();
                    txtcustcompname.Text = dr[1].ToString();
                    txtcustaddress.Text = dr[2].ToString();
                    txtcustphone.Text = dr[3].ToString();
                    txtcustmobile.Text = dr[4].ToString();
                    txtcustfax.Text = dr[5].ToString();
                }

            }

            else
            {
                txtcustname.Text = "";
                txtcustcompname.Text = "";
                txtcustaddress.Text = "";
                txtcustphone.Text = "";
                txtcustmobile.Text = "";
                txtcustfax.Text = "";


            }

        }

        private void txtitemcode_TextChanged(object sender, EventArgs e)
        {
            if (!txtitemcode.Text.StartsWith("I"))
            {
                txtitemcode.Text = string.Concat("I", txtitemcode.Text);
                txtitemcode.Select(txtitemcode.Text.Length, 0);
            }


            //int rate = Convert.ToInt32(txtRate.Text);
            //int que = Convert.ToInt32(txtQuantity.Text);
            //txtAmount.Text = (rate * que).ToString();
            //if (txtitemcode.SelectionLength > 0)
            //{
            //    txtQuantity.ReadOnly = true;
            //}
            //else
            //{
            //txtQuantity.ReadOnly = false;
            // tab2();
            //string selectquery1 = "select i.ItemId,i.ItemName,ip.MrpPrice,iq.CurrentQuantity from ItemDetails i join ItemPriceDetail ip on i.ItemId=ip.ItemId join ItemQuantityDetail iq on ip.ItemId=iq.ItemId where i.ItemId='" + txtitemcode.Text + "'";
            //DataTable dt = d.getDetailByQuery(selectquery1);
            //if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        txtProductName.Text = dr[1].ToString();
            //        txtRate.Text = dr[2].ToString();
            //        //txtRate.Text = dr[3].ToString();
            //        //txtQuantity.Text = dr[3].ToString();
            //        // txtAmount.Text = dr[4].ToString();
            //        txtQuantity.Text = "";
            //        txtQuantity.ReadOnly = false;
            //        butadditem.Enabled = true;
            //        //tab6();
            //    }
            //}
            //else
            //{
            //    txtProductName.Text = "";
            //    txtRate.Text = "";
            //    txtQuantity.ReadOnly = true; ;
            //    txtQuantity.Text = "";
            //    txtAmount.Text = "";
            //    butadditem.Enabled = false;

            //}
        }




        private void setvalue()
        {
            if (customerdetails.Rows.Count > 0)
            {
                string Custid = txtcustomercode.Text;
                if (Custid.Trim() != "" && Custid != null)
                {
                    DataRow[] dr = customerdetails.Select("Custid='" + Custid + "'");
                    if (dr != null && dr.Length > 0)
                    {
                        string customername = dr[0]["CustName"].ToString();
                        string customercompnayname = dr[1]["CustCompName"].ToString();
                        string customeraddress = dr[2]["CustAddress"].ToString();
                        string customerphone = dr[3]["CustPhone"].ToString();
                        string customermobile = dr[4]["CustMobile"].ToString();
                        string customerFax = dr[5]["CustFax"].ToString();

                        txtcustname.Text = customername;
                        txtcustcompname.Text = customercompnayname;
                        txtcustaddress.Text = customeraddress;
                        txtcustphone.Text = customerphone;
                        txtcustmobile.Text = customermobile;
                        txtcustfax.Text = customerFax;

                    }
                    else
                    {
                        txtcustname.Text = "";
                        txtcustcompname.Text = "";
                        txtcustaddress.Text = "";
                        txtcustaddress.Text = "";
                        txtcustphone.Text = "";
                        txtcustmobile.Text = "";
                        txtcustfax.Text = "";

                    }
                }
            }
        }



        public DataGridView orderid { get; set; }


        private void txtdiscount_TextChanged(object sender, EventArgs e)
        {
            double totalAmount = 0.0;
            foreach (DataRow dr in addToCartTable.Rows)
            {
                totalAmount += Convert.ToDouble(dr[4].ToString());
            }
            string discountAmount = txttax.Text;
            //double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
            double amount = 0.0;
            if (double.TryParse(discountAmount, out amount))
            {
                double totalDiscount = Convert.ToDouble(discountAmount);
                totalAmount = totalAmount - ((totalAmount * totalDiscount) / 100);
                txttotalammount.Text = totalAmount.ToString();
            }
        }


        private void gridsalesorder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gridsalesorder.Rows.Count > 1)
            {
                button4.Enabled = true;
                
            }

            if (e.KeyChar == (char)Keys.Escape)
            {
                gridsalesorder.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                txtitemcode.Enabled = true;
                txtitemcode.Focus();
                // txtitemcode.TabIndex = 1;
                button2.Enabled = true;

            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //    if (this.gridsalesorder.Rows.Count > 0)
                //    {
                //        gridsalesorder.Rows.RemoveAt(this.gridsalesorder.SelectedRows[0].Index);
                //    }

                if (addToCartTable.Rows.Count > 0)
                {
                    int index = gridsalesorder.SelectedRows[0].Index;
                    string itemId = gridsalesorder.Rows[index - 1].Cells[0].Value.ToString();
                    if ((!ls.Contains(itemId)) || (gridsalesorder.Rows[index - 1].DefaultCellStyle.Font==null))
                    {
                        int current = gridsalesorder.CurrentRow.Index;
                        string Amount = gridsalesorder.Rows[current - 1].Cells[6].Value.ToString();
                        double totalAmount = Convert.ToDouble(txttotalammount.Text);
                        totalAmount -= Convert.ToDouble(Amount.Trim());
                        txttotalammount.Text = totalAmount.ToString();

                        //addToCartTable.Rows.RemoveAt(index - 1);
                        gridsalesorder.Rows[index - 1].DefaultCellStyle.Font = new Font(new FontFamily("Microsoft Sans Serif"), 9.00F, FontStyle.Strikeout);
                        gridsalesorder.Rows[index - 1].DefaultCellStyle.ForeColor = Color.Red;
                        // I44

                        ls.Add(itemId);
                        //int index = gridsalesorder.CurrentCell.RowIndex;
                        //addToCartTable.Rows.RemoveAt(0);
                        gridsalesorder.DataSource = addToCartTable;



                        if (addToCartTable.Rows.Count == 0)
                        {
                            txttotalammount.Text = "0.0";


                            //txtdiscount.Text = "0.0";
                        }
                        if (ls.Count == gridsalesorder.Rows.Count - 1)
                        {
                            txtitemcode.Enabled = true;
                            txtitemcode.Focus();
                        }
                        if (gridsalesorder.Rows.Count == 1)
                        {
                            txtitemcode.Enabled = true;
                            txtitemcode.Focus();
                        }

                        if (gridsalesorder.Rows.Count > 0)
                        {
                            textBox20.Text = "0";
                            textBox20.ReadOnly = true;
                            button4.Enabled = true;
                            gridsalesorder.Rows[gridsalesorder.Rows.Count - 1].Selected = false;
                        }
                        if (gridsalesorder.Rows.Count > 1)
                        {
                            textBox20.ReadOnly = false;
                        }

                        if (gridsalesorder.Rows.Count == 0 && itemId == "")
                        {
                            txtitemcode.Enabled = true;
                            button2.Enabled = true;

                            txtitemcode.Focus();
                        }

                        else
                        {

                            button4.Enabled = false;
                        }
                        txtQuantity.TabStop = false;
                    }
                }


                    button4.Enabled = false;
                    savebutton.TabStop = false;
                    button6.TabStop = false;
                    txtcustomercode.TabStop = true;
                    button1.TabStop = true;
                    button2.TabStop = true;


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
                txtitemcode.Select(txtitemcode.Text.Length, 0);
                tab1();
            }

            if (e.KeyChar == (char)Keys.Escape)
            {
                txtitemcode.Focus();
            }

            string selectquery = "select CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from CustomerDetails Where Custid='" + txtcustomercode.Text + "'";
            DataTable dt = d.getDetailByQuery(selectquery);
            if (dt.Rows.Count > 0)
            {

            }
            else if (e.KeyChar == (char)Keys.Enter && dt.Rows != null && dt != null)
            {
                txtcustomercode.Focus();
                MessageBox.Show("please select your correct customer code ");
            }

        }

        private void txtitemcode_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            string select = "select CurrentQuantity from ItemQuantityDetail where itemid='" + txtitemcode.Text + "'";
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
                if (txtcustomercode.Text == "c")
                {
                    MessageBox.Show("please enter the customercode");
                    txtcustomercode.Focus();
                }
               
             

              
                double quantity = Convert.ToDouble(s);
               // double q = Convert.ToDouble(txtQuantity.Text + "");
                if (quantity < 0)
                {
                    MessageBox.Show("quantity not available");
                    txtQuantity.Text = "";
                    txtAmount.Text = "";
                }
                else
                {
                   
                    
                    //double qu=Convert.ToDouble(txtQuantity.Text);
                    string selectquery1 = "select i.ItemId,i.ItemName,cast(ip.SalesPrice as numeric(38,2)),iq.CurrentQuantity from ItemDetails i join ItemPriceDetail ip on i.ItemId=ip.ItemId join ItemQuantityDetail iq on ip.ItemId=iq.ItemId where i.ItemId='" + txtitemcode.Text + "'";
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
                                quantity = Convert.ToDouble(txtQuantity.Text);
                                double rate = Convert.ToDouble(txtRate.Text);
                                txtAmount.Text = (quantity * rate).ToString("###0.00");
                                txtQuantity.ReadOnly = false;
                                butadditem.Enabled = true;
                                //tab6();
                            }
                        }
                       
                     
                    
                   
                    else
                    {
                        txtProductName.Text = "";
                        txtRate.Text = "";
                        txtQuantity.ReadOnly = true; ;
                        txtQuantity.Text = "";
                        txtAmount.Text = "";
                        butadditem.Enabled = false;

                    }
           
                    txtQuantity.Enabled = true;
                    tab2();

                }
                if (txtitemcode.Text == "I")
                {
                    MessageBox.Show("please enter the itemcode");
                    txtQuantity.ReadOnly = false;
                    txtitemcode.Focus();
                }

            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                if (gridsalesorder.Rows.Count > 0)
                {
                    button4.Focus();
                }

                else
                {
                    savebutton.Focus();
                    button6.TabStop = true;
                }
            }


            string selectquery2 = "select i.ItemId,i.ItemName,cast(ip.MrpPrice as numeric(38,2)),iq.CurrentQuantity from ItemDetails i join ItemPriceDetail ip on i.ItemId=ip.ItemId join ItemQuantityDetail iq on ip.ItemId=iq.ItemId where i.ItemId='" + txtitemcode.Text + "'";
            DataTable dt2 = d.getDetailByQuery(selectquery2);
            if (dt2.Rows.Count > 0)
            {

            }
            else if(e.KeyChar == (char)Keys.Enter && dt2.Rows != null && dt2 != null&&txtcustomercode.Text=="C")
            {
                MessageBox.Show("please enter the customercode");
                txtcustomercode.Focus();
                //txtitemcode.Focus();
                //MessageBox.Show("Please select your item id");
            }
          
            


            
        }


        private void txtsearchvalue_TextChanged_1(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                string s = comsearchsalesvalue.SelectedValue.ToString();
                // string val = s;
                string selectQuery = "select  Custd.CustId as [Customer ID] ,CustName AS Name ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustDesc AS Description,Custad.CustOpeningBalance AS [Opening Balance] , Custad.CustCurrentBalance AS [Current Ballance],CustPanNo AS [PAN NO], CustVatNo AS [VAT NO],CustCSTNo AS [CST NO]  ,CustServicetaxRegnNo AS [Service Tax Regn. No],CustExciseRegnNo AS [Excise Regn. No] ,GSTRegnNo AS [GST Regn. No] from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID where " + s + " like '" + txtsearchvalue.Text + "%'";

                // string selectQuery = "select Custid as [Customer Id], CustName as Name,CustCompName as[Compnay Name],CustAddress as [Address],CustPhone as[Phone],Custmobile as[Mobile],CustFax as[Fax] from CustomerDetails where " + s + " like '" + txtsearchvalue.Text + "%'";
                DataTable dt = d.getDetailByQuery(selectQuery);
                dataGridView1.DataSource = dt;
            }
            else if (counter == 1)
            {
                string s = comsearchsalesvalue.SelectedValue.ToString();
                // string val1 = s1;
                string selectQurry = "select itm.ItemId as[Item Id],itm.ItemName as[Product Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],ipd.purChasePrice as [Purchase Price],ipd.SalesPrice as[Sales Price],ipd.MrpPrice as[Mrp Price],ipd.Margin as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId  where " + s + " like '" + txtsearchvalue.Text + "%'";
                DataTable dt = d.getDetailByQuery(selectQurry);
                //string selectQuery1 = "select itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],ipd.SalesPrice as[Sales Price],ipd.MrpPrice as[Mrp Price] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId  where " + s1 + " like '" + txtsearchvalue.Text + "%'";


                ////string selectQuery1 = "select it.ItemId as[Item Id], it.ItemName as[Name],ip.Mrpprice as[MRP],iq.CurrentQuantity as[Current Quantity] from ItemDetails it join ItemPriceDetail ip on it.Itemid=ip.Itemid join ItemQuantityDetail iq on ip.ItemId=iq.Itemid where " + s1+ " like '" + txtsearchvalue.Text + "%'";
                //DataTable dt1 = d.getDetailByQuery(selectQuery1);
                dataGridView1.DataSource = dt;
            }
        }

        private void butback_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtQuantity.TabStop = false;
            txtQuantity.ReadOnly = false;
            txtsearchvalue.Text = "";
            panel2.Visible = false;
            if (counter == 0)
            {
                DataGridViewCellCollection Collection = dataGridView1.Rows[e.RowIndex].Cells;
                rowcollection(Collection);
                panel2.Visible = false;
                tab1();
                txtcustomercode.TabStop = true;
                button1.TabStop = true;
            }
            if (counter == 1)
            {
                DataGridViewCellCollection Collection1 = dataGridView1.Rows[e.RowIndex].Cells;
                rowcollection1(Collection1);
                panel2.Visible = false;
                tab2();
                txtQuantity.Enabled = true;
                txtQuantity.Focus();
               

            }
            if (counter == 2)
            {
                panel2.Visible = false;
                panel1.Visible = true;
                DataGridViewCellCollection dell = dataGridView1.Rows[e.RowIndex].Cells;
                string val = dell[0].Value.ToString();
                txtsrno.Text = val;
                string selectquery1 = "select i.itemid,id.itemname,i.price,i.quantity,i.totalprice from customerorderdescriptions i join ItemDetails id on i.itemid=id.ItemId where orderid='" + val + "'";
                DataTable dt1 = d.getDetailByQuery(selectquery1);
                gridsalesorder.DataSource = dt1;
            }

            // button2.Focus();
            // tab5();
        }

        private void dataGridView1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            int currentIndex = dataGridView1.CurrentRow.Index;
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
                {
                    if (dataGridView1.RowCount == currentIndex - 1)
                        currentIndex = currentIndex + 1;

                    if (counter == 0)
                    {
                        DataGridViewCellCollection Collection = dataGridView1.Rows[currentIndex - 1].Cells;
                        rowcollection(Collection);
                        panel2.Visible = false;
                        tab1();
                    }
                    if (counter == 1)
                    {
                        DataGridViewCellCollection Collection1 = dataGridView1.Rows[currentIndex - 1].Cells;
                        rowcollection1(Collection1);
                        panel2.Visible = false;
                        tab2();
                    }
                    // tab5();
                }
            }
        }

        private void savebutton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                txtcustomercode.Focus();
            }
        }

        private void button6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                txtcustomercode.Focus();
            }
        }

        private void button4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                savebutton.Focus();
                savebutton.TabStop = false;
                txtcustomercode.TabStop = true;
                button1.TabStop = true;
            }
        }

        private void gridsalesorder_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
                
            //gridsalesorder.AllowUserToAddRows=false;
            txtitemcode.Text = "I";
            string itemid = gridsalesorder.Rows[e.RowIndex].Cells[0].Value.ToString();
            string item = "";
            string selectQurry = "select ItemId from ItemDetails";
            DataTable dt1 = d.getDetailByQuery(selectQurry);
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
                DataTable dt = d.getDetailByQuery(selectqurry);
                string rate = "";
                foreach (DataRow dr in dt.Rows)
                {
                    gridsalesorder.Rows[e.RowIndex].Cells[1].Value = dr[0].ToString();
                    gridsalesorder.Rows[e.RowIndex].Cells[2].Value = dr[1].ToString();
                    gridsalesorder.Rows[e.RowIndex].Cells[3].Value = dr[2].ToString();
                    // gridPurchaseOrder.Rows[e.RowIndex].Cells[5].Value=dr[3].ToString();
                    rate = dr[3].ToString();
                }
                if (gridsalesorder.Rows[e.RowIndex].Cells[0].Value != null)
                {


                    int co = gridsalesorder.CurrentRow.Index;
                    DataGridViewRow selectedRow = gridsalesorder.Rows[0];
                    selectedRow.Selected = true;
                    selectedRow.Cells[4].Selected = true;
                    //gridPurchaseOrder.CurrentCell = gridPurchaseOrder[gridPurchaseOrder.CurrentCell.ColumnIndex + 2, gridPurchaseOrder.CurrentCell.RowIndex];
                    //gridPurchaseOrder.Focus();
                }
                gridsalesorder.Rows[e.RowIndex].Cells[4].Value = rate;

                string quantity = gridsalesorder.Rows[e.RowIndex].Cells[5].Value.ToString();
                if (quantity == "")
                {

                    quantity = "0";
                  

                    //}
                    //rate = gridsalesorder.Rows[e.RowIndex].Cells[4].Value.ToString();
                    //if (rate == "")
                    //{
                    //    rate = "0";
                    }
                string selly="select CurrentQuantity from ItemQuantityDetail where ItemId='"+item+"'";
                DataTable dt3 = d.getDetailByQuery(selly);
                int quntity=0;
                foreach (DataRow dr3 in dt3.Rows)
                {
                    quntity = Convert.ToInt32(dr3[0].ToString());
                }
                int que=Convert.ToInt32(quantity);
                if (quntity <= que)
                {
                    gridsalesorder.Rows[e.RowIndex].Cells[5].Value = "0";
                    gridsalesorder.Rows[e.RowIndex].Cells[6].Value = "0";
                    MessageBox.Show("Plese select your correct Quantity");
                }
                else
                {
                    int q1 = Convert.ToInt32(quantity);
                    Double rate1 = Convert.ToDouble(rate);
                    Double price = rate1 * q1;
                    if (price.ToString() == "")
                    {
                        price = 0;
                    }
                    gridsalesorder.Rows[e.RowIndex].Cells[6].Value = price.ToString();
                    Double totalammount = Convert.ToDouble(txttotalammount.Text);
                    Double toat = totalammount + price;
                    txttotalammount.Text = toat.ToString();
               }
            }
            else
            {

                //if(itemid=="I1")
                //{
                MessageBox.Show("please select your correct row");
                gridsalesorder.Rows[e.RowIndex].Cells[0].Value = "";
                //gridPurchaseOrder.Rows[0].Cells[2].Selected = true;
            }
            //}

               // if (e.ColumnIndex == 0)
              //  {
                   // gridsalesorder.CurrentCell = gridsalesorder.Rows[0].Cells[5];
                   // gridsalesorder.BeginEdit(true);
                //}
                //var cellToFocus= gridsalesorder.Rows[0].Cells[5];
                //cellToFocus.e()
                //gridsalesorder.AllowUserToAddRows = true;




                //string id = gridsalesorder.Rows[e.RowIndex].Cells[0].Value.ToString();
                //string a1 = gridsalesorder.Rows[e.RowIndex].Cells[4].Value.ToString();
                //// string newquantity = gridsalesdelivary.Rows[e.RowIndex].Cells[3].Value.ToString();
                //string select = "select CurrentQuantity from ItemQuantityDetail where itemid='" + id + "'";
                //DataTable dt = d.getDetailByQuery(select);
                //string s = "";
                //foreach (DataRow dr in dt.Rows)
                //{
                //    s = dr[0].ToString();

                //}
                //if (s != "")
                //{
                //    int g = Convert.ToInt32(s);
                //    int quantity = Convert.ToInt32(a1);
                //    if (quantity < g)
                //    {
                //        string a = gridsalesorder.Rows[e.RowIndex].Cells[3].Value.ToString();
                //        string rate = gridsalesorder.Rows[e.RowIndex].Cells[2].Value.ToString();
                //        quantity = Convert.ToInt32(a);
                //        int r = Convert.ToInt32(rate);
                //        int totalammount = quantity * r;
                //        gridsalesorder.Rows[e.RowIndex].Cells[4].Value = totalammount.ToString();
                //        string newquantity = gridsalesorder.Rows[e.RowIndex].Cells[3].Value.ToString();
                //        int quantity1 = Convert.ToInt32(newquantity);
                //        int finalquantity = quantity1 - quantity;
                //        int totalq = r * finalquantity;
                //        int totalammount1 = Convert.ToInt32(txttotalammount.Text);
                //        int t = totalammount1 - totalq;
                //        txttotalammount.Text = t.ToString();
                //    }
                //    else if (quantity > g)
                //    {
                //        MessageBox.Show("Quantity is not available");
                //        gridsalesorder.Rows[e.RowIndex].Cells[4].Value = "0";
                //        //txtAmmount.Text = "0";
                //    }
                //}


         //   }
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
                if (e.KeyChar == '\b')
                {
                    foreach (DataRow dr in addToCartTable.Rows)
                    {
                        string itemid = dr[0].ToString();
                        if (ls.Contains(itemid))
                        {
                            //counter++;
                            continue;
                        }
                       // counter++;
                        totalAmount += Convert.ToDouble(dr[6].ToString());
                    }
                    double s1 = totalAmount;
                    txttotalammount.Text = s1.ToString("###0.00");
                    discountamount.Text = "0";
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

          
            if (e.KeyChar == (char)Keys.Enter)
            {
               

                //discountamount.Text = disa.ToString();
                foreach (DataRow dr in addToCartTable.Rows)
                {
                    string itemid = dr[0].ToString();
                    if (ls.Contains(itemid) && gridsalesorder.Rows[counter].DefaultCellStyle.Font != null)
                    {
                        counter++;
                        continue;
                    }
                    counter++;
                    totalAmount += Convert.ToDouble(dr[6].ToString());
                }
                double s = totalAmount;
                string discount = textBox20.Text;

                double amount = 0.0;

                if (double.TryParse(discount, out amount))
                {
                    double totaldiscount = Convert.ToDouble(discount);
                    totalAmount = totalAmount - ((totalAmount * totaldiscount) / 100);
                    txttotalammount.Text = totalAmount.ToString("###0.00");
                    txtwithautaxamount.Text = s.ToString();
                    double dis = s * totaldiscount / 100;
                    discountamount.Text = dis.ToString();

                }
               


            }
            
           


        }

        private void txttotalammount_TextChanged(object sender, EventArgs e)
        {
            if (txttotalammount.Text == "")
            {
                txttotalammount.Text = "0";
            }
            double d = 1;
            double total = Convert.ToDouble(txttotalammount.Text);
            double g = Convert.ToDouble(txttax.Text);
            double tax = d + ((g / 100));
            double taxamount = total / tax;
            double totaltax = total - taxamount;
            txttaxamount.Text = totaltax.ToString();
            //double dis = Convert.ToDouble(discountamount.Text);
            //double withauttax = total  - dis;
            //txttotaltax.Text= withauttax.ToString();


        }

        private void gridsalesorder_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //string itemid = gridsalesorder.Rows[e.RowIndex].Cells[0].Value.ToString();
            //string quantity = gridsalesorder.Rows[e.RowIndex].Cells[5].Value.ToString();
            //if (itemid == "")
            //{
           // }
        }

        private void salesorder_KeyDown(object sender, KeyEventArgs e)
         
       {
           if (e.Control && e.KeyCode.ToString() == "S")
           {
               cretenew();
           }

           if (e.Alt && e.KeyCode.ToString()=="D")
           {
              textBox20.Focus();
           }
        }

      
      
       
    }
}



