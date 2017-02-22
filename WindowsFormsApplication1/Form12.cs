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
    public partial class salesinvoice : Form
    {
        DB_Main d = new DB_Main();
        public salesinvoice()
        {
            InitializeComponent();
        }
        public int maxquantity = 0;
        public int counter = 0;
        DataTable vendorDetails = new DataTable();
        DataTable addToCartTable = new DataTable();
        DataTable customerdetails = new DataTable();
        DataTable ItemDetails = new DataTable();
        private void tab2()
        {
            txtCustcode.TabStop = false;
            butcustbutton.TabStop = false;
            txtitemcode.TabStop = false;
            butitembutton.TabStop = false;
            txtquantity.TabStop = false;
            butAdditem.TabStop = false;
            butRemoveItem.TabStop = false;
            butselectpurchasedelivary.TabStop = false;
            butclose.TabStop = false;
            button5.TabStop = false;
            gridsalesinvoice.TabStop = false;
        }
        private void tab3()
        {
            txtitemcode.Focus();
            txtitemcode.TabStop = true;
            butitembutton.TabStop = true;
            txtquantity.TabStop = true;
            butAdditem.TabStop = true;
        }
        private void tab()
        {
            txtitemcode.Focus();
            gridsalesinvoice.TabStop = false;
            butclose.TabStop = false;
            textBox1.TabStop = false;
            textBox2.TabStop = false;
            textBox3.TabStop = false;
            butselectpurchasedelivary.TabStop = false;
            txtitemcode.TabStop = true;
            butitembutton.TabStop = true;
            button5.TabStop = false;
            txtCustcode.TabStop = true;
            button1.TabStop = true;
        }
        private void tab5()
        {
            txtquantity.Focus();
            txtitemcode.TabStop = true;
            butitembutton.TabStop = true;
            butAdditem.TabStop = true;
            butRemoveItem.TabStop = true;
            butcustbutton.TabStop = false;
            gridsalesinvoice.TabStop = false;
            butclose.TabStop = false;
            textBox1.TabStop = false;
            textBox2.TabStop = false;
            textBox3.TabStop = false;
            butselectpurchasedelivary.TabStop = false;
            button5.TabStop = false;
            txtCustcode.TabStop = false;
            button1.TabStop = false;
        }
        private void tab4()
        {
         
            txtCustcode.TabStop = true;
            butcustbutton.TabStop = true;
            gridsalesinvoice.TabStop = false;
            butclose.TabStop = false;
            textBox1.TabStop = false;
            textBox2.TabStop = false;
            textBox3.TabStop = false;
            butselectpurchasedelivary.TabStop = false;
            txtitemcode.TabStop = true;
            button5.TabStop = false;
        }
        private void tab6()
        {
            txtquantity.Focus();
            txtCustcode.TabStop = true;
            butcustbutton.TabStop = true;
            txtitemcode.TabStop = true;
            butitembutton.TabStop = true;
            butAdditem.TabStop = true;
            butRemoveItem.TabStop = true;
            button5.TabStop = true;
            butselectpurchasedelivary.TabStop = true;

            gridsalesinvoice.TabStop = false;
            butclose.TabStop = true;
            textBox1.TabStop = false;
            textBox2.TabStop = false;
            textBox3.TabStop = false;
            butselectpurchasedelivary.TabStop = false;
            txtitemcode.TabStop = false;
            button5.TabStop = false;
        }
        private void butcustbutton_Click(object sender, EventArgs e)
        {
            //string selectquery1 = "select CustName,CustCompName,CustAddress,CustPhone,Custmobile,CustFax from CustomerDetails";
            //DataTable dt1 = d.getDetailByQuery(selectquery1);
            //string val = " ";
            //List<string> sd = new List<string>();
            //foreach (DataColumn dr in dt1.Columns)
            //{
            //    val = dr.ColumnName;
            //    sd.Add(val);
            //}
            //comserchvalue.DataSource = sd;
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
            comserchvalue.DataSource = custometable;
            comserchvalue.ValueMember= "actualcolumnname";
            comserchvalue.DisplayMember = "aliascolumnname";
   
             counter = 0;
            panel2.Visible = true;
            string selectquery = "select  Custd.CustId as [Customer ID] ,CustName AS Name ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustDesc AS Description,Custad.CustOpeningBalance AS [Opening Balance] , Custad.CustCurrentBalance AS [Current Ballance],CustPanNo AS [PAN NO], CustVatNo AS [VAT NO],CustCSTNo AS [CST NO]  ,CustServicetaxRegnNo AS [Service Tax Regn. No],CustExciseRegnNo AS [Excise Regn. No] ,GSTRegnNo AS [GST Regn. No] from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID ";
            
            //string selectquery = "select Custid, CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from customerdetails";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView2.DataSource = dt;
            tab2();
            comserchvalue.Focus();
            comserchvalue.TabIndex = 1;
            txtsearchvalue.TabIndex = 2;
            dataGridView2.TabIndex = 3;
            button1.TabIndex = 4;
        }
            
         public void rowcollection(DataGridViewCellCollection cell)
            {
            txtCustcode.Text = cell[0].Value.ToString();
            txtcustname.Text = cell[1].Value.ToString();
            txtcustcompname.Text= cell[2].Value.ToString();
            txtcustaddress.Text = cell[3].Value.ToString();
            txtcustphone.Text = cell[4].Value.ToString();
            txtcustmobile.Text = cell[5].Value.ToString();
            txtcustfax.Text= cell[6].Value.ToString();
        }
         public void rowcollection1(DataGridViewCellCollection cell1)
         {
             txtitemcode.Text = cell1[0].Value.ToString();
             txtproductname.Text = cell1[1].Value.ToString();
            txtrate.Text = cell1[6].Value.ToString();
            // maxquantity =Convert.ToInt32(cell1[3].Value.ToString());
             txtquantity.Text = "";
             txtammount.Text= "";

         }

         private void butitembutton_Click(object sender, EventArgs e)
         {
             //string selectquery1 = "select it.ItemName,ip.Mrpprice,iq.CurrentQuantity from ItemDetails it join ItemPriceDetail ip on it.Itemid=ip.Itemid join ItemQuantityDetail iq on ip.ItemId=iq.Itemid";
             //DataTable dt1 = d.getDetailByQuery(selectquery1);
             //string val = " ";
             //List<string> sd = new List<string>();
             //foreach (DataColumn dr in dt1.Columns)
             //{
             //    val = dr.ColumnName;
             //    sd.Add(val);
             //}
             //comserchvalue.DataSource = sd;

             string selectquery1 = "select  itm.ItemId as [Item Id],itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],ipd.purChasePrice as [Purchase Price],ipd.SalesPrice as[Sales Price],ipd.MrpPrice as[Mrp Price],ipd.Margin as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId";
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
             comserchvalue.DataSource = custometable;
             comserchvalue.ValueMember = "actualcolumnname";
             comserchvalue.DisplayMember = "aliascolumnname";

             counter = 1;
             panel2.Visible = true;
             string selectquery = "select  itm.ItemId as [Item Id],itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],ipd.purChasePrice as [Purchase Price],ipd.SalesPrice as[Sales Price],ipd.MrpPrice as[Mrp Price],ipd.Margin as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId";
            
            // string selectquery = "select i.Itemid,i.Itemname,ip.MrpPrice,iq.CurrentQuantity from itemdetails i join itempricedetail ip on i.itemid=ip.itemid join itemquantitydetail iq on ip.itemid=iq.itemid";
             DataTable dt = d.getDetailByQuery(selectquery);
             dataGridView2.DataSource = dt;
             tab2();
             comserchvalue.Focus();
             comserchvalue.TabIndex = 1;
             txtsearchvalue.TabIndex = 2;
             dataGridView2.TabIndex = 3;
             button1.TabIndex = 4;
         }
         private void txtquantity_TextChanged(object sender, EventArgs e)
         {
             string select = "select CurrentQuantity from ItemQuantityDetail where itemid='" + txtitemcode.Text + "'";
             DataTable dt = d.getDetailByQuery(select);
             string s = "";
             foreach (DataRow dr in dt.Rows)
             {
                 s = dr[0].ToString();

             }
             if (s != "")
             {
                 int g = Convert.ToInt32(s);
                 int quantity = Convert.ToInt32(txtquantity.Text);
                 if (quantity < g)
                 {
                     //    MessageBox.Show("d");

                     // if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                     if ((!string.IsNullOrEmpty(txtquantity.Text)) && char.IsDigit(txtquantity.Text, txtquantity.Text.Length - 1) && (!string.IsNullOrEmpty(txtrate.Text)))
                     {
                         //     txtQuantity.ReadOnly = false;
                         //int que = maxItemQuantity;
                         quantity = Convert.ToInt32(txtquantity.Text);
                         int rate = Convert.ToInt32(txtrate.Text);
                         txtammount.Text = (quantity * rate).ToString();
                     }
                 }

                 else if (quantity > g)
                 {
                     MessageBox.Show("Quantity is not available");
                     txtquantity.Text = "0";
                     txtammount.Text = "0";
                 }
             }
             //if ((!string.IsNullOrEmpty(txtquantity.Text)) && char.IsDigit(txtquantity.Text,txtquantity.Text.Length-1)&&(!string.IsNullOrEmpty(txtrate.Text)))
             //{
             //    string qurry1 = "select CurrentQuantity from ItemQuantityDetail ";
             //    DataTable dt1 = d.getDetailByQuery(qurry1);
             //    string id1 = " ";
             //    foreach (DataRow dr in dt1.Rows)
             //    {
             //        id1 = dr["CurrentQuantity"].ToString();
             //    }
             //    int que = 0;
             //    int quantity = Convert.ToInt32(txtquantity.Text);
             //    int rate = Convert.ToInt32(txtrate.Text);
             //    que=quantity*rate;
             //    txtammount.Text = que.ToString();
             //    if (que < quantity)
             //    {
             //        txtquantity.Text = "";
             //        txtammount.Text= "";
             //    }
             //}
         }

         private void butAdditem_Click(object sender, EventArgs e)
         {
               if (txtquantity.Text == "")
            {
                txtquantity.Text= "0";
            }
            if (txtammount.Text == "")
            {
                txtammount.Text = "0";
            }

            if (txtquantity.Text == "0")
            {
                MessageBox.Show("please enter the Quantity");
            }
            else if (txtquantity.Text != "0")
            {
                butRemoveItem.Enabled = true;
                button5.TabStop= true;
                butselectpurchasedelivary.TabStop = true;
                butclose.TabStop = true;
                txtCustcode.TabStop = true;
                butcustbutton.TabStop = true;
                butitembutton.TabStop = true;
                butRemoveItem.TabStop = true;
                txtitemcode.TabStop = true;
                txtquantity.TabStop = false;
                DataRow dr = addToCartTable.NewRow();
                dr[0] = txtitemcode.Text.Trim();
                dr[1] = txtproductname.Text.Trim();
                dr[2] = txtrate.Text.Trim();
                dr[3] = txtquantity.Text.Trim();
                dr[4] = txtammount.Text.Trim();
                addToCartTable.Rows.Add(dr);
                gridsalesinvoice.DataSource = addToCartTable;
                double totalAmount = Convert.ToDouble(txttotalammount.Text);
                totalAmount += Convert.ToDouble(txtammount.Text.Trim());
                txttotalammount.Text = totalAmount.ToString();

                txtitemcode.Text = "I";
                txtproductname.Text = "";
                txtrate.Text = "";
                txtquantity.Text = "";
                txtammount.Text = "";
                txtitemcode.Focus();
            }
         }
         private void tabindex()
         {
             butcustbutton.TabStop = true;
             txtitemcode.TabStop = true;
             butitembutton.TabStop = true;
             txtquantity.TabStop = true;
             butAdditem.TabStop = true;
             butRemoveItem.TabStop = true;
             button5.TabStop = false;
             butselectpurchasedelivary.TabStop = false;
             butclose.TabStop = true;
             gridsalesinvoice.TabStop = false;
         }

         private void salesinvoice_Load(object sender, EventArgs e)
         {
             //tabindex();
             tab4();
             txtquantity.ReadOnly = true;
             butRemoveItem.Enabled = false;
             butRemoveItem.Visible = true;
             butAdditem.Visible = true;
             butAdditem.Enabled = false;
             dtpdate.Value = DateTime.Now;
             txtCustcode.Text = "C";
             txtitemcode.Text = "I";
             panel2.Visible = false;
             Purchase.PurchaseDetails purChaseDetailObj = new Purchase.PurchaseDetails();
             vendorDetails = purChaseDetailObj.GetVendorDetaisInDataTable();
             ItemDetails = purChaseDetailObj.GetItemPriceAndNameDetaisInDataTable();
             setAutoCompleteMode(txtproductname, "ItemName", ItemDetails);
             setAddToCraftTable();
             string selectquery = "select  invoiceid from salesinvoice";
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
             //string select = "select VAT, CST,GST from CompnayDetails";
             //DataTable d1 = d.getDetailByQuery(select);
             //foreach (DataRow dr1 in d1.Rows)
             //{
             //    textBox2.Text = dr1[0].ToString();
             //    txtdiscount.Text = dr1[1].ToString();
             //    textBox20.Text = dr1[2].ToString();
             //}
             string selectName = "select TexAmount from CompnayTex where TexName='" + DB_Main.taxName + "'";
             DataTable dt = d.getDetailByQuery(selectName);
             textBox1.Text = DB_Main.taxName;
             foreach (DataRow dr in dt.Rows)
             {
                 //txtTexAmount.Text 
                 textBox2.Text = dr[0].ToString();
             }
         }

         private void butRemoveItem_Click(object sender, EventArgs e)
         {

             butRemoveItem.Enabled = false;
             gridsalesinvoice.Focus();
             gridsalesinvoice.TabIndex = 1;
             txtitemcode.Enabled = false;
             butitembutton.Enabled = true;
             button5.TabStop = false;
             butselectpurchasedelivary.TabStop = false;
             butclose.TabStop = false;
             txtCustcode.TabStop= true;
             butcustbutton.TabStop = true;
            
             //if (addToCartTable.Rows.Count > 0)
             //{
             //    string Amount = gridsalesinvoice.SelectedRows[0].Cells[4].Value.ToString();
             //    double totalAmount = Convert.ToDouble(txttotalammount.Text);
             //    totalAmount -= Convert.ToDouble(Amount.Trim());
             //    txttotalammount.Text = totalAmount.ToString();
             //    int index = gridsalesinvoice.SelectedRows[0].Index;
             //    addToCartTable.Rows.RemoveAt(index);

             //    gridsalesinvoice.DataSource = addToCartTable;
             //    if (addToCartTable.Rows.Count == 0)
             //    {
             //        txttotalammount.Text = "0.0";
             //        txtdiscount.Text = "0.0";
             //    }
             //    if (gridsalesinvoice.Rows.Count > 0)
             //    {
             //        butRemoveItem.Enabled = true;
             //    }
             //    else
             //    {
             //        butRemoveItem.Enabled = false;
             //    }
             //}
         }

         private void button5_Click(object sender, EventArgs e)
         {
             if (txtRefNo.Text == "")
             {
                 string delivary = "select Delivaryid from salesOrderDelivery";
                 DataTable dt3 = d.getDetailByQuery(delivary);
                 string delivaryid = "";
                 foreach (DataRow dr in dt3.Rows)
                 {
                     delivaryid = dr[0].ToString();
                    
                 }
                 int del = Convert.ToInt32(delivaryid);
                 int deli = del + 1;
                 string order = "select orderid from orderdetails ";
                 DataTable d1 = d.getDetailByQuery(order);
                 string id = "";
                 foreach (DataRow dr in d1.Rows)
                 {
                     id = dr[0].ToString();
                 }
                 if (id == "")
                 {
                     id = "1";
                     string insertquery = "insert into  orderdetails values('" + txtCustcode.Text + "','" + dtpdate.Text + "','" + txttotalammount.Text + "')";
                     int insertrows = d.saveDetails(insertquery);
                     if (insertrows > 0)
                     {

                         DataGridViewRowCollection rowcollection = gridsalesinvoice.Rows;
                         List<string> show = new List<string>();
                         for (int a = 0; a < rowcollection.Count; a++)
                         {
                             DataGridViewRow currentrow = rowcollection[a];
                             DataGridViewCellCollection cellcollection = currentrow.Cells;
                             string txtitemcode = cellcollection[0].Value.ToString();
                             string txtProductName = cellcollection[1].Value.ToString();
                             string txtRate = cellcollection[2].Value.ToString();
                             string txtQuantity = cellcollection[3].Value.ToString();
                             string txtAmount = cellcollection[4].Value.ToString();
                             string Orderid = id;
                             string query = "insert into customerorderdescriptions Values('" + Orderid + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";

                             show.Add(query);
                         }

                         int inserirow1 = d.saveDetails(show);
                         if (inserirow1 > 0)
                         {
                             string salesdelivary = "Insert into salesOrderDelivery values('" + id + "','true','" + dtpdate.Text + "')";
                             int insertrow = d.saveDetails(salesdelivary);
                             string invoice = "Insert into salesinvoice values('" + deli + "','" + id + "','" + dtpdate.Text + "')";
                             int insertrow1 = d.saveDetails(invoice);
                             if (insertrow1 > 0)
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
                 else
                 {
                     int id1 = Convert.ToInt32(id);
                     int id2 = id1 + 1;
                     string Orde = id2.ToString();
                     string insertquery1 = "insert into  orderdetails values('" + txtCustcode.Text + "','" + dtpdate.Text + "','" + txttotalammount.Text + "','"+textBox2.Text+"','"+textBox2.Text+"')";
                     int insertrows1 = d.saveDetails(insertquery1);
                     if (insertrows1 > 0)
                     {

                         DataGridViewRowCollection rowcollection1 = gridsalesinvoice.Rows;
                         List<string> show1 = new List<string>();
                         for (int a = 0; a < rowcollection1.Count; a++)
                         {
                             DataGridViewRow currentrow = rowcollection1[a];
                             DataGridViewCellCollection cellcollection = currentrow.Cells;
                             string txtitemcode = cellcollection[0].Value.ToString();
                             string txtProductName = cellcollection[1].Value.ToString();
                             string txtRate = cellcollection[2].Value.ToString();
                             string txtQuantity = cellcollection[3].Value.ToString();
                             string txtAmount = cellcollection[4].Value.ToString();
                             string Orderid = id2.ToString();
                             string query = "insert into customerorderdescriptions Values('" + Orderid + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";

                             show1.Add(query);
                         }

                         int inserirow2 = d.saveDetails(show1);
                         if (inserirow2 > 0)
                         {
                             string salesdelivary = "Insert into salesOrderDelivery values('" + id2.ToString() + "','true','" + dtpdate.Text + "')";
                             int insertrow = d.saveDetails(salesdelivary);
                             string invoice = "Insert into salesinvoice values('" + deli+ "','" + id2.ToString()+ "','" + dtpdate.Text + "')";
                             int insertrow2 = d.saveDetails(invoice);
                             if (insertrow2 > 0)
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
             if (txtRefNo.Text != "")
             {
                 string delivary = "select Delivaryid from salesOrderDelivery";
                 DataTable dt3 = d.getDetailByQuery(delivary);
                 string delivaryid = txtRefNo.Text;
                 //foreach (DataRow dr in dt3.Rows)
                 //{
                 //    delivaryid = dr[0].ToString();

                 //}
                 //int del = Convert.ToInt32(delivaryid);
                 //int deli = del + 1;
               
                     string order = "select Orderid from salesOrderDelivery where Delivaryid ='" + txtRefNo.Text + "' ";
                     DataTable d1 = d.getDetailByQuery(order);
                     string id = "";
                     foreach (DataRow dr in d1.Rows)
                     {
                         id = dr[0].ToString();
                     }
                     string update = "update orderdetails set totalammount='" + txttotalammount.Text + "'where Orderid='" + id + "'";
                     int c = d.saveDetails(update);
                     string deletequrri1 = "delete customerorderdescriptions where OrderId='" + id + "'";
                    DataTable dt1 = d.getDetailByQuery(deletequrri1);
                     string insertquery = "insert into  orderdetails values('" + txtCustcode.Text + "','" + dtpdate.Text + "','" + txttotalammount.Text + "','"+txtdiscount.Text+"','"+txtdiscount.Text+"')";
                     int insertrows = d.saveDetails(insertquery);
                     if (insertrows > 0)
                     {

                         DataGridViewRowCollection rowcollection = gridsalesinvoice.Rows;
                         List<string> show = new List<string>();
                         for (int a = 0; a < rowcollection.Count; a++)
                         {
                             DataGridViewRow currentrow = rowcollection[a];
                             DataGridViewCellCollection cellcollection = currentrow.Cells;
                             string txtitemcode = cellcollection[0].Value.ToString();
                             string txtProductName = cellcollection[1].Value.ToString();
                             string txtRate = cellcollection[2].Value.ToString();
                             string txtQuantity = cellcollection[3].Value.ToString();
                             string txtAmount = cellcollection[4].Value.ToString();
                             // string Orderid = id;
                             string query = "insert into customerorderdescriptions Values('" + id + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";

                             show.Add(query);
                         }

                         int inserirow1 = d.saveDetails(show);
                         if (inserirow1 > 0)
                         {
                             string salesdelivary = "Update  salesOrderDelivery set DeliveryDate='" + dtpdate.Text + "' where delivaryid='" + delivaryid + "'";
                             int insertrow = d.saveDetails(salesdelivary);
                             string invoic = "Insert into salesinvoice values('" + txtRefNo.Text + "','" + id + "','" + dtpdate.Text + "')";
                             int insertrow1 = d.saveDetails(invoic);
                             if (insertrow1 > 0)
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
             
             int id3 = Convert.ToInt32(txtSrNo.Text);
             int id4 = id3 + 1;
             txtSrNo.Text = id4.ToString();
             Form5 s = new Form5(id3.ToString());
             s.Show();
                 makeblank();
                 
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
         private void makeblank()
         {
             txtCustcode.Text = "";
             txtcustname.Text = "";
             txtcustcompname.Text = "";
             txtcustaddress.Text = "";
             txtcustphone.Text = "";
             txtcustmobile.Text = "";
            txtcustfax.Text = "";
             txtRefNo.Text = "";
             addToCartTable.Clear();
            gridsalesinvoice.DataSource = "";
         }

         private void setAddToCraftTable()
         {
             addToCartTable.Columns.Add(new DataColumn("ItemCode"));
             addToCartTable.Columns.Add(new DataColumn("ProductName"));
             addToCartTable.Columns.Add(new DataColumn("Rate"));
             addToCartTable.Columns.Add(new DataColumn("Quantity"));
             addToCartTable.Columns.Add(new DataColumn("Amount"));
         }

         private void butclose_Click(object sender, EventArgs e)
         {
             this.Close();
         }

         private void txtquantity_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (e.KeyChar == (char)Keys.Enter)
             {
                 butAdditem.Focus();
             }
             if (char.IsDigit(e.KeyChar))
             {
                 e.Handled = false;
             }
             else
             {
                 if (e.KeyChar == '\b')
                 {
                     txtammount.Text = "";
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

         private void butselectpurchasedelivary_Click(object sender, EventArgs e)
         {
             string selectquery1 = "select OrderId ,CustId,date,Totalammount from orderdetails";
             DataTable dt1 = d.getDetailByQuery(selectquery1);
             string val = " ";
             List<string> sd = new List<string>();
             foreach (DataColumn dr in dt1.Columns)
             {
                 val = dr.ColumnName;
                 sd.Add(val);
             }
             comserchvalue.DataSource = sd;
             counter = 2;
             panel2.Visible = true;
             string selectquery = "select orderid,custid,date,totalammount from orderdetails";
             DataTable dt = d.getDetailByQuery(selectquery);
             dataGridView2.DataSource = dt;
         }
         private void gridsalesinvoice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
         {
             DataGridViewCellCollection Collection1 = dataGridView2.Rows[e.RowIndex].Cells;
             rowcollection1(Collection1);
             panel1.Visible = false;
         }

         private void txtCustcode_TextChanged(object sender, EventArgs e)
         {
             string selectquery = "select CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from CustomerDetails Where Custid='" + txtCustcode.Text+ "'";
             DataTable dt = d.getDetailByQuery(selectquery);
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
             string selectquery1 = "select i.ItemId,i.ItemName,ip.MrpPrice,iq.CurrentQuantity from ItemDetails i join ItemPriceDetail ip on i.ItemId=ip.ItemId join ItemQuantityDetail iq on ip.ItemId=iq.ItemId where i.ItemId='" + txtitemcode.Text + "'";
             DataTable dt = d.getDetailByQuery(selectquery1);
             if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
             {
                 foreach (DataRow dr in dt.Rows)
                 {
                     txtproductname.Text = dr[1].ToString();
                     txtrate.Text = dr[2].ToString();
                     txtquantity.ReadOnly = false;
                     butAdditem.Enabled = true;
                     tab3();
                 }
             }
             else
             {
                 txtproductname.Text = "";
                 txtrate.Text = "";
                 txtquantity.ReadOnly = true;
                 txtquantity.Text = "";
                 txtammount.Text= "";
                 butAdditem.Enabled = false;
             }
         }

         private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
         {
             
         }

         private void txtsearchvalue_TextChanged_1(object sender, EventArgs e)
         {
             if (counter == 0)
             {
                 string s = comserchvalue.SelectedValue.ToString();
                 //string val = s;
                 string selectQuery = "select  Custd.CustId as [Customer ID] ,CustName AS Name ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustDesc AS Description,Custad.CustOpeningBalance AS [Opening Balance] , Custad.CustCurrentBalance AS [Current Ballance],CustPanNo AS [PAN NO], CustVatNo AS [VAT NO],CustCSTNo AS [CST NO]  ,CustServicetaxRegnNo AS [Service Tax Regn. No],CustExciseRegnNo AS [Excise Regn. No] ,GSTRegnNo AS [GST Regn. No] from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID where " + s + " like '" + txtsearchvalue.Text + "%'";

                 // string selectQuery = "select CustId,CustName,CustCompName,CustAddress,CustPhone,Custmobile,CustFax from CustomerDetails where " + val + " like '" + txtsearchvalue.Text + "%'";
                 DataTable dt = d.getDetailByQuery(selectQuery);
                 dataGridView2.DataSource = dt;
             }
             else if (counter == 1)
             {
                 string s1 = comserchvalue.SelectedValue.ToString();
                 string selectQuery1 = "select itm.ItemId as[Item Id],itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],ipd.purChasePrice as [Purchase Price],ipd.SalesPrice as[Sales Price],ipd.MrpPrice as[Mrp Price],ipd.Margin as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId  where " + s1 + " like '" + txtsearchvalue.Text + "%'";

                 //string val1 = s1;
                 //string selectQuery1 = "select it.itemid,it.ItemName,ip.Mrpprice,iq.CurrentQuantity from ItemDetails it join ItemPriceDetail ip on it.Itemid=ip.Itemid join ItemQuantityDetail iq on ip.ItemId=iq.Itemid where " + val1 + " like '" + txtsearchvalue.Text + "%'";
                 DataTable dt1 = d.getDetailByQuery(selectQuery1);
                 dataGridView2.DataSource = dt1;
             }
             else if (counter == 2)
             {
                 string s2 = comserchvalue.SelectedValue.ToString();
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
                 txtitemcode.Focus();
                 txtitemcode.TabStop = true;
                 butitembutton.TabStop = true;
                 txtCustcode.TabStop = true;
                 butcustbutton.TabStop = true;
             }
             if (counter == 1)
             {
                 DataGridViewCellCollection Collection1 = dataGridView2.Rows[e.RowIndex].Cells;
                 rowcollection1(Collection1);
                 panel2.Visible = false;
              
             }
             if (counter == 2)
             {
                 panel2.Visible = false;
                 panel1.Visible = true;
                 DataGridViewCellCollection dell = dataGridView2.Rows[e.RowIndex].Cells;
                 string val = dell[0].Value.ToString();
                 txtRefNo.Text = val;
                 //string selectquery1 = "select i.itemid,id.itemname,i.price,i.quantity,i.totalprice from customerorderdescriptions i join ItemDetails id on i.itemid=id.ItemId where orderid='" + val + "'";
                 //DataTable dt1 = d.getDetailByQuery(selectquery1);
                 //gridsalesinvoice.DataSource = dt1;
             }
             tab4();
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
                         txtitemcode.Focus();
                         txtitemcode.TabStop= true;
                         butitembutton.TabStop= true;
                         txtCustcode.TabStop = true;
                         butcustbutton.TabStop = true;
                     }
                     if (counter == 1)
                     {
                         DataGridViewCellCollection Collection1 = dataGridView2.Rows[currentIndex - 1].Cells;
                         rowcollection1(Collection1);
                         panel2.Visible = false;
                         tab6();
                     }

                 }
             }
         }
         private void SetVendor(string r)
         {
             DataTable dt = d.getDetailByQuery(r);
             foreach (DataRow dr in dt.Rows)
             {
                 txtCustcode.Text = dr[0].ToString();
                 txtcustname.Text = dr[1].ToString();
                 txtcustcompname.Text = dr[2].ToString();
                 txtcustaddress.Text = dr[3].ToString();
                 txtcustphone.Text = dr[4].ToString();
                 txtcustmobile.Text = dr[5].ToString();
                 txtcustfax.Text = dr[6].ToString();
                 //txtRefNo.Text = dr[7].ToString();
             }
         }

         private void txtRefNo_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (e.KeyChar == Convert.ToChar(Keys.Enter))
             {
                 string selectquery2 = "select Orderid from salesinvoice where Orderid='" + txtRefNo.Text + "'";
                 DataTable dt1 = d.getDetailByQuery(selectquery2);
                 if (dt1 != null && dt1.Rows != null && dt1.Rows.Count > 0)
                 {
                     MessageBox.Show("order details is completed");
                     // txtRefNo.Text = "";
                     //gridsalesdelivary.DataSource = "";
                 }

            

                 else
                 {
                     button5.TabStop= true;
                     string select = "select vo.orderid,vo.custid,vod.ItemId,vo.Discount from orderdetails vo join customerorderdescriptions vod on vod.Orderid=vo.Orderid where vo.Orderid ='" + txtRefNo.Text + "'";
                     DataTable dt = d.getDetailByQuery(select);
                     string a = "";
                     if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                     {
                         DataRow dr = dt.Rows[0];
                         a = dr[1].ToString();

                         string discount = dr[3].ToString();
                         txtdiscount.Text = discount;
                     }
                     string selectquery = "select  c.custId, c.CustName,c.CustCompName,c.CustAddress,c.CustPhone,c.CustMobile,c.CustFax from CustomerDetails c  where  c.custId='" + a + "'";
                     //DataTable dt2 = d.getDetailByQuery(selectquery);
                     SetVendor(selectquery);
                     string selectquery1 = "select it.itemid,iq.ItemName,it.price,it.quantity,it.totalammount from customerorderdescriptions it join ItemDetails iq on it.ItemId=iq.ItemId  where orderid='" + txtRefNo.Text + "'";
                     DataTable dt3 = d.getDetailByQuery(selectquery1);
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
                         string productname = dr1[1].ToString();
                         string rate = dr1[2].ToString();
                         string quantity = dr1[3].ToString();
                         string ammount = dr1[4].ToString();
                         //string ammount1 = dr1[5].ToString();
                         int amt = Convert.ToInt32(ammount);
                         totel = totel + amt;
                         dr1 = addToCartTable.NewRow();
                         dr1[0] = itemcode.Trim();
                         dr1[1] = productname.Trim();
                         dr1[2] = rate.Trim();
                         dr1[3] = quantity.Trim();
                        // dr1[4] = quantity.Trim();
                         dr1[4] = ammount.Trim();
                         addToCartTable.Rows.Add(dr1);

                     }
                    // gridsalesdelivary.DataSource = null;
                     gridsalesinvoice.DataSource = addToCartTable;
                     txttotalammount.Text = totel.ToString();

                 }
                 //}

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
         //    if (e.KeyChar == Convert.ToChar(Keys.Enter))
         //    {
         //    string selectquery = "select Delivaryid from salesinvoice where Delivaryid='" + txtRefNo.Text + "'";
         //    DataTable dt = d.getDetailByQuery(selectquery);
         //    if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
         //    {
         //        MessageBox.Show("delivary details is completed");
         //        txtRefNo.Text = "";
         //        gridsalesinvoice.DataSource = "";


         //    }
         //    else
         //    {
         //        button5.Enabled = true;

         //        string selectquery1 = "select  c.custId, c.CustName,c.CustCompName,c.CustAddress,c.CustPhone,c.CustMobile,c.CustFax,o.Orderid,s.Delivaryid from CustomerDetails c join orderdetails o on c.custId=o.custid join salesOrderDelivery s on o.Orderid=s.OrderId where s.Delivaryid='" + txtRefNo.Text + "'";
         //        DataTable dt1 = d.getDetailByQuery(selectquery1);
         //        string OrderId = "";
         //        if (dt1 != null && dt1.Rows != null && dt1.Rows.Count > 0)
         //        {
         //            foreach (DataRow dr1 in dt1.Rows)
         //            {
         //                txtCustcode.Text = dr1[0].ToString();
         //                txtcustname.Text = dr1[1].ToString();
         //                txtcustcompname.Text = dr1[2].ToString();
         //                txtcustaddress.Text = dr1[3].ToString();
         //                txtcustphone.Text = dr1[4].ToString();
         //                txtcustmobile.Text = dr1[5].ToString();
         //                txtcustfax.Text = dr1[6].ToString();
         //                OrderId = dr1[7].ToString();
         //            }
         //        }

         //        int totel = 0;
         //        string selectquery2 = "select it.itemid,iq.ItemName,it.price,it.quantity,it.totalammount from customerorderdescriptions it join ItemDetails iq on it.ItemId=iq.ItemId where Orderid='" + OrderId + "'";
         //        DataTable dt3 = d.getDetailByQuery(selectquery2);
         //        int totelrow = addToCartTable.Rows.Count;
         //        for (int a = 0; a < totelrow; a++)
         //        {
         //            addToCartTable.Rows.RemoveAt(0);
         //        }
         //        for (int a = 0; a < dt3.Rows.Count; a++)
         //        {
         //            DataRow dr1 = dt3.Rows[a];
         //            string t = dr1[0].ToString();
         //            string t2 = dr1[1].ToString();
         //            string t1 = dr1[2].ToString();
         //            string t3 = dr1[3].ToString();
         //            string totalamt = dr1[4].ToString();
         //            int amt = Convert.ToInt32(totalamt);
         //            totel = totel + amt;
         //            dr1 = addToCartTable.NewRow();
         //            dr1[0] = t.Trim();
         //            dr1[1] = t2.Trim();
         //            dr1[2] = t1.Trim();
         //            dr1[3] = t3.Trim();
         //            dr1[4] = totalamt.Trim();
         //            addToCartTable.Rows.Add(dr1);

         //        }

         //        gridsalesinvoice.DataSource = addToCartTable;
         //        txttotalammount.Text = totel.ToString();

         //    }
         //}
         }

         private void gridsalesinvoice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
         {
             string id = gridsalesinvoice.Rows[e.RowIndex].Cells[0].Value.ToString();
             string a1 = gridsalesinvoice.Rows[e.RowIndex].Cells[3].Value.ToString();
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
                     string a = gridsalesinvoice.Rows[e.RowIndex].Cells[3].Value.ToString();
                     string rate = gridsalesinvoice.Rows[e.RowIndex].Cells[2].Value.ToString();
                     quantity = Convert.ToInt32(a);
                     int r = Convert.ToInt32(rate);
                     int totalammount = quantity * r;
                     gridsalesinvoice.Rows[e.RowIndex].Cells[4].Value = totalammount.ToString();
                     string newquantity = gridsalesinvoice.Rows[e.RowIndex].Cells[3].Value.ToString();
                     int quantity1 = Convert.ToInt32(newquantity);
                     int finalquantity = quantity1 - quantity;
                     int totalq = r * finalquantity;
                     int totalammount1 = Convert.ToInt32(txttotalammount.Text);
                     int t = totalammount1 - totalq;
                     txttotalammount.Text = t.ToString();
                 }
                 else if (quantity > g)
                 {
                     MessageBox.Show("Quantity is not available");
                     gridsalesinvoice.Rows[e.RowIndex].Cells[3].Value = "0";
                     //txtAmmount.Text = "0";
                 }
             }
         }

         private void txtCustcode_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (e.KeyChar == (char)Keys.Enter)
             {
                 tab();
             }
         }

         private void txtitemcode_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (e.KeyChar == (char)Keys.Escape)
             {
                 butRemoveItem.Focus();
             }
             if (e.KeyChar == (char)Keys.Enter)
             {
                 tab5();
             }
             if (e.KeyChar == (char)Keys.Escape)
             {
                 if (gridsalesinvoice.Rows.Count > 0)
                 {
                     butRemoveItem.Focus();
                 }
                 else
                 {
                     button5.Focus();
                     butselectpurchasedelivary.TabStop = true;
                     butclose.TabStop = true;
                 }
             }
         }

         private void gridsalesinvoice_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (e.KeyChar == (char)Keys.Escape)
             {
                 txtitemcode.Enabled = true;
                 butitembutton.Enabled = true;
                 txtitemcode.Focus();
                 txtitemcode.TabStop = true;
                 txtitemcode.TabIndex = 1;
                 button5.TabStop = true;
                 butselectpurchasedelivary.TabStop = true;
                 butclose.TabStop = true;
                
             }
             if (gridsalesinvoice.Rows.Count > 0)
             {
                 butRemoveItem.Enabled = true;
             }

            
             if (e.KeyChar == (char)Keys.Enter)
             {
                 if (addToCartTable.Rows.Count > 0)
                 {
                     string Amount = gridsalesinvoice.SelectedRows[0].Cells[4].Value.ToString();
                     double totalAmount = Convert.ToDouble(txttotalammount.Text);
                     totalAmount -= Convert.ToDouble(Amount.Trim());
                     txttotalammount.Text = totalAmount.ToString();
                     int index = gridsalesinvoice.SelectedRows[0].Index;
                     addToCartTable.Rows.RemoveAt(index);

                     gridsalesinvoice.DataSource = addToCartTable;
                     if (addToCartTable.Rows.Count == 0)
                     {
                         txtammount.Text = "0.0";
                         txtdiscount.Text = "0.0";
                     }
                     if (gridsalesinvoice.Rows.Count > 0)
                     {
                         butRemoveItem.Enabled = true;
                         gridsalesinvoice.Rows[gridsalesinvoice.Rows.Count - 1].Selected = true;
                     }
                     if (gridsalesinvoice.Rows.Count == 0)
                     {
                         txtitemcode.Enabled= true;
                         txtitemcode.Focus();
                     }

                     else
                     {
                         butRemoveItem.Enabled = false;
                     }
                     butRemoveItem.Enabled = false;

                 }
             }
         }

         private void butRemoveItem_KeyPress(object sender, KeyPressEventArgs e)
         {

             if (e.KeyChar == (char)Keys.Escape)
             {
                 button5.Focus();
                 butselectpurchasedelivary.TabStop = true;
                 butclose.TabStop = true;
                 txtCustcode.TabStop = true;
                 butitembutton.TabStop = true;

             }
         }

       

       
    }

    }

