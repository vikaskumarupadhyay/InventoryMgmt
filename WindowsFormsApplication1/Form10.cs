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
    public partial class salesorder : Form
    {

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
        }
       
        private void tab1()
        {
            txtitemcode.Focus();
            button2.TabStop = true;
            txtitemcode.TabStop = true;
        }
        private void tab2()
        {
            txtQuantity.Focus();
            txtcustomercode.TabStop = false;
            button1.TabStop = false;
            button2.TabStop = true;
            txtitemcode.TabStop = true;
            txtQuantity.TabStop = false;
            butadditem.TabStop = true;
            button4.TabStop = true;
           // gridsalesorder.TabStop = true;
            savebutton.TabStop = false;
            button6.TabStop = false;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
           
           // string selectquery1 = "select CustName as [Name],CustCompName as [Compnay Name],CustAddress as [Address],CustPhone as [Phone],Custmobile as [Mobole],CustFax as [Fax] from CustomerDetails";
            // string actualcolumn = "select CustName ,CustCompName ,CustAddress ,CustPhone ,Custmobile ,CustFax  from CustomerDetails";
            string selectquery1 = "select  Custd.CustId as [Customer ID] ,CustName AS Name ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustDesc AS Description,Custad.CustOpeningBalance AS [Opening Balance] , Custad.CustCurrentBalance AS [Current Ballance],CustPanNo AS [PAN NO], CustVatNo AS [VAT NO],CustCSTNo AS [CST NO]  ,CustServicetaxRegnNo AS [Service Tax Regn. No],CustExciseRegnNo AS [Excise Regn. No] ,Gstregnno AS [GST Regn. No] from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID ";
            string actualcolumn = "select  Custd.CustId  ,CustName  ,CustCompName  ,CustAddress ,CustCity , CustState  ,CustZip  ,CustCountry  ,CustEmail , CustWebAddress ,CustPhone  ,CustMobile  ,CustFax ,CustDesc ,Custad.CustOpeningBalance , Custad.CustCurrentBalance ,CustPanNo , CustVatNo ,CustCSTNo  ,CustServicetaxRegnNo ,CustExciseRegnNo  ,Gstregnno from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID ";
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
            string selectquery = "select  Custd.CustId as [Customer ID] ,CustName AS Name ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustDesc AS Description,Custad.CustOpeningBalance AS [Opening Balance] , Custad.CustCurrentBalance AS [Current Ballance],CustPanNo AS [PAN NO], CustVatNo AS [VAT NO],CustCSTNo AS [CST NO]  ,CustServicetaxRegnNo AS [Service Tax Regn. No],CustExciseRegnNo AS [Excise Regn. No] ,Gstregnno AS [GST Regn. No] from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID ";
            
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
            counter = 1;
            string selectquery1 = "select  itm.ItemId as [Item Id],itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],ipd.purChasePrice as [Purchase Price],ipd.SalesPrice as[Sales Price],ipd.MrpPrice as[Mrp Price],ipd.Margin as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId";
            string actualcolumn = "select top 1  itm.ItemId, itm.ItemName,itm.ItemCompName ,itm.ItemDesc ,ig.groupName,iul.unitName ,ipd.purChasePrice ,ipd.SalesPrice ,ipd.MrpPrice ,ipd.Margin ,iqd.OpeningQuantity ,iqd.CurrentQuantity from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId";
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
            for (int a = 0; a < c.Count; a++)
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

            panel2.Visible = true;
            string selectquery = "select  itm.ItemId as [Item Id],itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],ipd.purChasePrice as [Purchase Price],ipd.SalesPrice as[Sales Price],ipd.MrpPrice as[Mrp Price],ipd.Margin as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId";

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
        }

        public void rowcollection1(DataGridViewCellCollection cell1)
        {
            txtitemcode.Text = cell1[0].Value.ToString();
            txtProductName.Text = cell1[1].Value.ToString();
            txtRate.Text = cell1[6].Value.ToString();
            //maxItemQuantity = Convert.ToInt32((cell1[3].Value.ToString()));
            txtAmount.Text = "";

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
         //   txtQuantity.ReadOnly = true;
            if ((!string.IsNullOrEmpty(txtQuantity.Text)) && char.IsDigit(txtQuantity.Text, txtQuantity.Text.Length - 1)&&(!string.IsNullOrEmpty(txtRate.Text)))
            {
           //     txtQuantity.ReadOnly = false;
                int que = maxItemQuantity;
                int quantity = Convert.ToInt32(txtQuantity.Text);
                int rate = Convert.ToInt32(txtRate.Text);
                txtAmount.Text = (quantity * rate).ToString();
            }

            //else if (que < quantity)
            //{
            //    txtQuantity.Text = "";
            //    txtAmount.Text = "";
            //}
        }
        private void makeblank()
        {
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
            txtQuantity.Text="";
            txtAmount.Text="";
            //txtdiscount.Text = "";
            gridsalesorder.DataSource = "";
            txttotalammount.Text = "0";
            txtsearchvalue.Text = "";
            addToCartTable.Clear();
        }
        private void butadditem_Click(object sender, EventArgs e)
        {
           
              //tab6();
            txtQuantity.TabStop = false;
                button4.Enabled = true;
                DataRow dr = addToCartTable.NewRow();
                dr[0] = txtitemcode.Text.Trim();
                dr[1] = txtProductName.Text.Trim();
                dr[2] = txtRate.Text.Trim();
                dr[3] = txtQuantity.Text.Trim();
               // textBox14.Text = dr[4].ToString();
                dr[4] = txtAmount.Text.Trim();
                addToCartTable.Rows.Add(dr);
                gridsalesorder.DataSource = addToCartTable;
                double totalAmount = Convert.ToDouble(txttotalammount.Text);
                totalAmount += Convert.ToDouble(txtAmount.Text.Trim());
                txttotalammount.Text = totalAmount.ToString();

                txtitemcode.Text = "I";
                txtProductName.Text = "";
                txtRate.Text = "";
                txtQuantity.Text = "";
                //textBox14.Text = "";
                txtAmount.Text = "";
                txtitemcode.Focus();
              
        
        }
    

        private void salesorder_Load(object sender, EventArgs e)
        {
            tab();
          
            comsearchsalesvalue.Focus();
            button4.Enabled = false;
            butadditem.Enabled = false;
            dtpdate.Value = DateTime.Now;
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
            string select = "select VAT, CST,GST from CompnayDetails";
            DataTable d1 = d.getDetailByQuery(select);
            foreach (DataRow dr1 in d1.Rows)
            {
                txtdiscount.Text = dr1[0].ToString();
                textBox2.Text = dr1[1].ToString();
                textBox20.Text = dr1[2].ToString();
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
        private void setAddToCraftTable()
        {
            addToCartTable.Columns.Add(new DataColumn("ItemCode"));
            addToCartTable.Columns.Add(new DataColumn("ProductName"));
            addToCartTable.Columns.Add(new DataColumn("Rate"));
            addToCartTable.Columns.Add(new DataColumn("Quantity"));
            addToCartTable.Columns.Add(new DataColumn("Amount"));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            gridsalesorder.Focus();
            gridsalesorder.TabIndex=1;
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
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
           
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
               
                counter = 0;
                if (counter == 0)
                {
                    string insertquery = "insert into  orderdetails values('" + txtcustomercode.Text + "','" + dtpdate.Text + "','" + txttotalammount.Text + "','"+txtdiscount.Text+"')";
                    int insertrows = d.saveDetails(insertquery);
                   
                   
                    DataGridViewRowCollection rowcollection = gridsalesorder.Rows;
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
                        string Orderid = txtsrno.Text;
                        string query = "insert into customerorderdescriptions Values('" + txtsrno.Text + "','" + txtitemcode + "','" + txtRate + "','" + txtQuantity + "','" + txtAmount + "')";
                       
                        show.Add(query);
                    }

                    int inserirow1 = d.saveDetails(show);
                    if(inserirow1 > 0)
                    {
                        MessageBox.Show("details save successfully");
                    }
                    else
                    {
                        MessageBox.Show("details save not successfully");
                    }
                    int id = Convert.ToInt32(txtsrno.Text);
                    id = id + 1;
                    txtsrno.Text = id.ToString() ;
                    makeblank();
                 
                }
                txtcustomercode.Focus();

            }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                butadditem.Focus();
            }
            if (char.IsDigit(e.KeyChar))
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


        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
          
        }

        private void gridsalesorder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
            DataGridViewCellCollection Collection1 = dataGridView1.Rows[e.RowIndex].Cells;
            rowcollection1(Collection1);
            panel1.Visible = false;
        }

        private void txtcustomercode_TextChanged(object sender, EventArgs e)
        {
           // if (txtcustomercode.Text.Trim() != "" && txtcustomercode.Text.StartsWith("C"))
           // {
               // setvalue();
            ///}
           // tab1();
            string selectquery = "select CustName,CustCompName,CustAddress,CustPhone,CustMobile,CustFax from CustomerDetails Where Custid='" + txtcustomercode.Text + "'";
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
                string selectquery1 = "select i.ItemId,i.ItemName,ip.MrpPrice,iq.CurrentQuantity from ItemDetails i join ItemPriceDetail ip on i.ItemId=ip.ItemId join ItemQuantityDetail iq on ip.ItemId=iq.ItemId where i.ItemId='"+txtitemcode.Text+"'";
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
                        txtQuantity.Text = "";
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
            string discountAmount = txtdiscount.Text;
            //double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
            double amount = 0.0;
            if (double.TryParse(discountAmount, out amount))
            {
                double totalDiscount = Convert.ToDouble(discountAmount);
                totalAmount = totalAmount - ((totalAmount * totalDiscount) / 100);
                txttotalammount.Text = totalAmount.ToString();
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

           
        }



        private void gridsalesorder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gridsalesorder.Rows.Count > 0)
            {
                button4.Enabled = true;
            }

            if (e.KeyChar == (char)Keys.Escape)
            {
                txtitemcode.Enabled = true;
                txtitemcode.Focus();
                txtitemcode.TabIndex = 1;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (addToCartTable.Rows.Count > 0)
                {
                    string Amount = gridsalesorder.SelectedRows[0].Cells[4].Value.ToString();
                    double totalAmount = Convert.ToDouble(txttotalammount.Text);
                    totalAmount -= Convert.ToDouble(Amount.Trim());
                    txttotalammount.Text = totalAmount.ToString();
                    int index = gridsalesorder.SelectedRows[0].Index;
                    addToCartTable.Rows.RemoveAt(index);

                    gridsalesorder.DataSource = addToCartTable;
                    if (addToCartTable.Rows.Count == 0)
                    {
                        txttotalammount.Text = "0.0";
                        txtdiscount.Text = "0.0";
                    }

                    if (gridsalesorder.Rows.Count > 0)
                    {
                        button4.Enabled = true;
                        gridsalesorder.Rows[gridsalesorder.Rows.Count - 1].Selected = true;
                    }
                    if (gridsalesorder.Rows.Count == 0)
                    {
                        txtitemcode.Enabled = true;
                        txtitemcode.Focus();
                    }
                    else
                    {
                        button4.Enabled = false;
                    }
                    txtQuantity.TabStop = false;
                }

                button4.Enabled = false;

            }
        }

        private void txtcustomercode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                    tab1();   
            }
        }

        private void txtitemcode_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar == (char)Keys.Enter)
            {
                tab2();
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                button4.Focus();
            }
        }

        private void txtsearchvalue_TextChanged_1(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                string s = comsearchsalesvalue.SelectedValue.ToString();
                // string val = s;
                string selectQuery = "select  Custd.CustId as [Customer ID] ,CustName AS Name ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustDesc AS Description,Custad.CustOpeningBalance AS [Opening Balance] , Custad.CustCurrentBalance AS [Current Ballance],CustPanNo AS [PAN NO], CustVatNo AS [VAT NO],CustCSTNo AS [CST NO]  ,CustServicetaxRegnNo AS [Service Tax Regn. No],CustExciseRegnNo AS [Excise Regn. No] ,CustGSTRegnNo AS [GST Regn. No] from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID where " + s + " like '" + txtsearchvalue.Text + "%'";

                // string selectQuery = "select Custid as [Customer Id], CustName as Name,CustCompName as[Compnay Name],CustAddress as [Address],CustPhone as[Phone],Custmobile as[Mobile],CustFax as[Fax] from CustomerDetails where " + s + " like '" + txtsearchvalue.Text + "%'";
                DataTable dt = d.getDetailByQuery(selectQuery);
                dataGridView1.DataSource = dt;
            }
            else if (counter == 1)
            {
                string s1 = comsearchsalesvalue.SelectedValue.ToString();
                // string val1 = s1;
                string selectQuery1 = "select itm.ItemId as[Item Id],itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],ipd.purChasePrice as [Purchase Price],ipd.SalesPrice as[Sales Price],ipd.MrpPrice as[Mrp Price],ipd.Margin as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId  where " + s1 + " like '" + txtsearchvalue.Text + "%'";


                //string selectQuery1 = "select it.ItemId as[Item Id], it.ItemName as[Name],ip.Mrpprice as[MRP],iq.CurrentQuantity as[Current Quantity] from ItemDetails it join ItemPriceDetail ip on it.Itemid=ip.Itemid join ItemQuantityDetail iq on ip.ItemId=iq.Itemid where " + s1+ " like '" + txtsearchvalue.Text + "%'";
                DataTable dt1 = d.getDetailByQuery(selectQuery1);
                dataGridView1.DataSource = dt1;
            }
        }

        private void butback_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtQuantity.TabStop = false;
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
                    if (dataGridView1.RowCount == currentIndex + 1)
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
  
    }
}



