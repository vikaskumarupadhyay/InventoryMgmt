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
    public partial class PurchaseOrder : Form
    {
        List<string> ls = new List<string>();
        public bool ValidationFails = false;
        public PurchaseOrder()
        {
            InitializeComponent();
        }
        public int counter = 0;
        DB_Main dbMainClass = new DB_Main();
        DataTable vendorDetails = new DataTable();
        DataTable ItemDetails = new DataTable();
        DataTable addToCartTable = new DataTable();
        private DataGridViewEditMode EditOnKeystroke;

        private void PurchaseOrder_Load(object sender, EventArgs e)
        {

            txtDiscount.ReadOnly = true;
            txtVendorCode.Select(txtVendorCode.Text.Length, 0);
            txtItemCode.Select(txtItemCode.Text.Length, 0);
            txtdis.ReadOnly = true;
            //PurchesCrystalReportViewer.Visible = false;
            txtwithautaxamount.Visible = false;
            DisAmmount.Visible = false;
            TextTaxAmmount.Visible = false;
            DisAmmount.Text = "0";
            txtdis.Text = "0.00";
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
                    MessageBox.Show("Entered vendor code is not valid. Please enter valid vendor code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                else if ((e.KeyChar == 'V' || e.KeyChar == 'v') && string.IsNullOrWhiteSpace(txtVendorCode.Text))
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
                    txtAmount.Text = "0.00";
                }
            }
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
        #region /////////// AddToList Clicked ///////////////
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            btnSave.TabStop = true;
            btnClose.TabStop = true;
            if ((txtQuanity.Text == "") || (txtQuanity.Text == "0"))
            {
                MessageBox.Show("Entered Quantity should not less than one.",
    "Information",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning);
                // MessageBox.Show("Entered Quantity should not less than one. Please enter valid quantity!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuanity.Text = "1";
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
                int quntity1 = 0;
                int counter = 0;
                string itemname1 = product(txtItemCode.Text);
                if (itemname1 != txtProductName.Text)
                {
                    MessageBox.Show("Your Item ID and Item Name do not match. Please press enter key!", "Information",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning);
                    return;
                }
                else
                {

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
                        quntity = dr3[4].ToString();
                        rate = dr3[3].ToString();
                        ammount = dr3[5].ToString();


                        if (itemid == txtItemCode.Text)
                        {
                            if (quntity == "")
                            {
                                quntity = "0";
                            }
                            int q1 = Convert.ToInt32(quntity);
                            int q2 = Convert.ToInt32(txtQuanity.Text);
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
                        string itemname2 = product(txtItemCode.Text);
                        if (itemname2 != txtProductName.Text)
                        {
                            MessageBox.Show("Please Select correct ItemCode");
                        }
                        else
                        {
                            string selectq = "select ids.ItemCompName,cast(ipd.MrpPrice as numeric(38,2)),itd.HSN,itd.CGST,itd.SGST,itd.IGST,itd.CESS from ItemPriceDetail ipd join ItemDetails ids on ipd.ItemId=ids.ItemId join ItemTaxDetail itd on ipd.ItemId=itd.ItemId where ipd.ItemId='" + txtItemCode.Text + "'";
                            DataTable dta = dbMainClass.getDetailByQuery(selectq);
                            string ConpanyName = "";
                            string Mrp = "";
                            string Hsn = "";
                            string Cgst = "";
                            string Sgst = "";
                            string Igst= "";
                            string Cess = "";
                            foreach (DataRow dr1 in dta.Rows)
                            {
                                ConpanyName = dr1[0].ToString();
                                Mrp = dr1[1].ToString();
                                Hsn = dr1[2].ToString();
                                Cgst = dr1[3].ToString();
                                Sgst = dr1[4].ToString();
                                Igst = dr1[5].ToString();
                                Cess = dr1[6].ToString();
                            }

                            txtRemoveItem.Enabled = true;
                            DataRow dr = addToCartTable.NewRow();
                            dr[0] = txtItemCode.Text.Trim();
                            dr[1] = txtProductName.Text.Trim();
                            dr[2] = Hsn.Trim();
                            dr[3] = txtRate.Text.Trim();
                            dr[4] = txtQuanity.Text.Trim();
                            dr[5] =
                            dr[6] = txtAmount.Text.Trim();
                            //dr[7] = Hsn.Trim();
                            dr[7] = Cgst.Trim();
                            dr[8] = Sgst.Trim();
                            dr[9] = Igst.Trim(); ;
                            dr[10]=Cess.Trim();
                            int q1 = Convert.ToInt32(txtQuanity.Text.Trim());
                            int q2 = Convert.ToInt32(txtQuantityBild.Text);
                            int q3 = q1 + q2;
                            txtQuantityBild.Text = q3.ToString();
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
                    }
                    //if (gridPurchaseOrder.Rows.Count > 1)
                    //{
                    //    txtdis.ReadOnly = false;
                    //}
                    txtItemCode.Select(txtItemCode.Text.Length, 0);
                }
            }
        }
        #endregion

        #region /////////// add Column to AddToCraft DataTable///////////////
        private void setAddToCraftTable()
        {
            addToCartTable.Columns.Add(new DataColumn("Item Code"));
            addToCartTable.Columns.Add(new DataColumn("Item Name"));
            addToCartTable.Columns.Add(new DataColumn("HSN"));
            addToCartTable.Columns.Add(new DataColumn("Rate"));
            addToCartTable.Columns.Add(new DataColumn("Quantity"));
            //addToCartTable.Columns.Add(new DataColumn("Total"));
            addToCartTable.Columns.Add(new DataColumn("Discount"));
            addToCartTable.Columns.Add(new DataColumn("Taxable Value"));
            addToCartTable.Columns.Add(new DataColumn("CGST (%)"));
            addToCartTable.Columns.Add(new DataColumn("SGST (%)"));
            addToCartTable.Columns.Add(new DataColumn("IGST (%)"));
            addToCartTable.Columns.Add(new DataColumn("CESS (%)"));
            addToCartTable.Columns.Add(new DataColumn("Total Ammount"));

            //addToCartTable.Columns.Add(new DataColumn("TexAmount"));
        }
        #endregion

        private void txtRemoveItem_Click(object sender, EventArgs e)
        {
            gridPurchaseOrder.DefaultCellStyle.SelectionBackColor = Color.Red;
            gridPurchaseOrder.Focus();
            gridPurchaseOrder.SelectionMode =DataGridViewSelectionMode.FullRowSelect;
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
            string selectqurry = "select vd.venderId as [Vendor ID ],vd.vName AS [Vendor Name] ,vd.vCompName AS [Company Name] ,vd.vAddress AS Address,vd.vCity AS City,vd. vState AS State ,vd.vZip AS Zip ,vd.vCountry AS Country ,vd.vEmail AS[E-Mail ],vd. vWebAddress AS[Web Address],vd.vPhone AS Phone ,vd.vMobile AS Mobile ,vd.vFax AS Fax ,vd.vPanNo as[PAN NO],vd.vGSTNo as [GST NO],vd.vDesc AS [Description],vad.vOpeningBalance AS [Opening Balance] , vad.vCurrentBalance AS [Current Balance] from  vendorDetails vd join    VendorAccountDetails  vad on vd.venderID=vad.venderID";
            string selectqurryForActualColumnName = "select top 1 vd.venderId ,vd.vName  ,vd.vCompName  ,vd.vAddress ,vd.vCity,vd. vState  ,vd.vZip  ,vd.vCountry  ,vd.vEmail ,vd. vWebAddress ,vd.vPhone  ,vd.vMobile ,vd.vFax ,vd.vPanNo ,vd.vGSTNo ,vd.vDesc,vad.vOpeningBalance, vad.vCurrentBalance  from  vendorDetails vd join    VendorAccountDetails  vad on vd.venderID=vad.venderID";
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
            txtsearch.Focus();

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
            string selectqurry = "select  itm.ItemId as [Item ID],itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],cast(ipd.purChasePrice as numeric(38,2)) as [Purchase Price],cast(ipd.MrpPrice as numeric(38,2)) as[MRP] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId where iqd.CurrentQuantity>0";
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
            string select = "select  itm.ItemId as [Item ID],itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],cast(ipd.purChasePrice as numeric(38,2)) as [Purchase Price],cast(ipd.SalesPrice as numeric(38,2)) as[Sales Price],cast(ipd.MrpPrice as numeric(38,2)) as[MRP],cast(ipd.Margin as numeric(38,2)) as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId where iqd.CurrentQuantity>0";
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
            if (txtProductName.Text != "")
            {
                MessageBox.Show("please add item");
                txtQuanity.Focus();
            }
            else if (txtVendorCode.Text == "V")
            {
                MessageBox.Show("Please enter vendor code first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVendorCode.Focus();
                txtVendorCode.Select(txtVendorCode.Text.Length, 0);
            }
            else if (gridPurchaseOrder.CurrentRow == null)
            {
                MessageBox.Show("Please enter item code first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridPurchaseOrder.Focus();
            }
            else
            {
                if (ls.Count == gridPurchaseOrder.Rows.Count - 1)
                {
                    MessageBox.Show("Please enter item code first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    gridPurchaseOrder.Focus();
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
                DataGridViewRowCollection RowCollection1 = gridPurchaseOrder.Rows;
                for (int a = 0; a < RowCollection1.Count; a++)
                {

                    DataGridViewRow currentRow1 = RowCollection1[a];
                    if (currentRow1.Cells[0].Value != null && (!string.IsNullOrWhiteSpace(currentRow1.Cells[0].Value.ToString())))
                    {
                        DataGridViewCellCollection cellCollection1 = currentRow1.Cells;
                        string txtQuanit = cellCollection1[4].Value.ToString();
                        if (txtQuanit == "0" || txtQuanit == "")
                        {
                            MessageBox.Show("Please enter Valid Quantity");
                            gridPurchaseOrder.AllowUserToAddRows = true;
                            gridPurchaseOrder.Focus();
                            return;
                        }
                        string txtAmoun = cellCollection1[11].Value.ToString();
                        if (txtAmoun == "0.00" || txtAmoun == "")
                        {
                            gridPurchaseOrder.Focus();
                            MessageBox.Show("Please enter Valid Quantity");
                            gridPurchaseOrder.AllowUserToAddRows = true;
                            return;
                        }
                    }
                }
                int count = 0;

                if (txtDiscount.Text == "")
                {
                    txtDiscount.Text = "0";
                }
                else
                {

                    if(txtwithautaxamount.Text=="")
                    {
                        txtwithautaxamount.Text = "0.00";
                    }
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
                        if (ls.Contains(txtItemCod) && gridPurchaseOrder.Rows[count].DefaultCellStyle.Font != null)
                        {
                            count++;
                            continue;
                        }

                        string txtQuanit = cellCollection[4].Value.ToString();
                       
                        string txtRate = cellCollection[3].Value.ToString();
                        string txtAmoun = cellCollection[11].Value.ToString();
                       
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

                            //PurchesCrystalReportViewer.Visible = true;

                            // panel2.Visible = true;
                            ReportDocument crReportDocument;
                            crReportDocument = new ReportDocument();
                            frmViewReport View = new frmViewReport();
                            crReportDocument.Load(Application.StartupPath + "//Report//PurchesCrystalReport.rpt");
                            //string conntion = "Data Source=DELL-PC;Initial Catalog=SalesMaster;User ID=sa; Password=dell@12345;";
                            SqlConnection con = dbMainClass.openConnection();//new SqlConnection(conntion);
                            string selectqurry = "select * from VwPurchesOrderDatils where OrderId='" + txtSrNo.Text + "'";
                            SqlCommand cmd = new SqlCommand(selectqurry, con);
                            SqlDataAdapter sda = new SqlDataAdapter(cmd);

                            PurchSet ds = new PurchSet();
                            sda.Fill(ds, "VwPurchesOrderDatils");
                            crReportDocument.SetDataSource(ds.Tables[1]);
                            //Start Preview                          
                            View.CrViewer.ReportSource = crReportDocument;
                            View.CrViewer.Refresh();
                            View.Show();
                            //End Preview
                           // PurchesCrystalReportViewer.Visible = false;
                            txtTotalAmount.Text = "0.00";
                            panel2.Visible = false;
                            txtItemCode.TabStop = false;
                            button2.TabStop = false;
                            btnSave.TabStop = false;
                            btnClose.TabStop = false;
                            //Start Print
                            // crReportDocument.PrintToPrinter(1, false, 0, 0);
                            //End  Print


                           
                                if (result1 == System.Windows.Forms.DialogResult.No)
                                {
                                    PurchesCrystalReportViewer.Visible = false;
                                    txtTotalAmount.Text = "0.00";
                                    panel2.Visible = false;
                                }
                                gridPurchaseOrder.AllowUserToAddRows = true;
                                //gridPurchaseOrder.DataSource = addToCartTable;
                                //OrderID(txtSrNo.Text);
                                makeBlank();

                            //PurchesCrystalReport cryRpt = new PurchesCrystalReport();
                            ////ReportDocument cryRpt = new ReportDocument();
                            ////cryRpt.Load("C:\\Users\\Umesh\\Documents\\visual studio 2010\\Projects\\WindowsFormsApplication5\\WindowsFormsApplication5\\PurchesCrystalReport.rpt");
                            //cryRpt.SetDataSource(ds.Tables[1]);
                            //PurchesCrystalReportViewer.ReportSource = cryRpt;
                            //PurchesCrystalReportViewer.Refresh();


                        }
                        if (result1 == System.Windows.Forms.DialogResult.No)
                        {
                            //PurchesCrystalReportViewer.Visible = false;
                            txtTotalAmount.Text = "0.00";
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
            gridPurchaseOrder.Focus();
            gridPurchaseOrder.AllowUserToAddRows = true;
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
            txtQuantityBild.Text = "0";
            txtTotalAmount.Text = "0.00";
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
                    MessageBox.Show("Entered Quantity should not less than one.",
    "Information",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning);
                    txtQuanity.Text = "1";
                    txtQuanity.Focus();
                    txtQuanity.SelectAll();
                    //txtAmount.Text = "0.00";
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
          gridPurchaseOrder.Focus();
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
            if (txtQuanity.Text != "")
            {
                txtQuanity.TabStop = true;
                txtQuanity.Focus();
                txtQuanity.SelectAll();
            }
            else
            {
                txtQuanity.TabStop = false;
            }
            txtItemCode.TabStop = true;
            button2.TabStop = true;
            txtDiscount.TabStop = false;
            btnAddItem.TabStop = true;
            txtRemoveItem.TabStop = true;
            txtVendorCode.TabStop = true;
            button1.TabStop = true;

        }

        private void gridPurchaseOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
           /* //try
            //{
            //    if (e.ColumnIndex == 1)
            //    {


            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                var dgvcount = gridPurchaseOrder.Rows.Count;
                gridPurchaseOrder.CurrentCell = gridPurchaseOrder.Rows[dgvcount - 2].Cells[0];
                gridPurchaseOrder.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                txtItemCode.Focus();
                txtItemCode.Select(txtItemCode.Text.Length, 0);
                txtRemoveItem.Enabled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                int selectewIndex = gridPurchaseOrder.CurrentCell.RowIndex;
                int selectewIndexActual = gridPurchaseOrder.SelectedRows[0].Index;

                Color backGroundColor = gridPurchaseOrder.DefaultCellStyle.SelectionBackColor;
                if (backGroundColor.Name == "DodgerBlue" || backGroundColor.Name == "Highlight")
                {

                    //        if (gridPurchaseOrder.CurrentCell.ColumnIndex == 1)
                    //        {
                    //            gridPurchaseOrder.CurrentCell = gridPurchaseOrder.CurrentRow.Cells[0];
                    //        }
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message.ToString());
                    //}
                    #region commented code
                    //if (e.KeyChar == Convert.ToChar(Keys.Escape))
                    //{
                    //    var dgvcount = gridPurchaseOrder.Rows.Count;
                    //    gridPurchaseOrder.CurrentCell = gridPurchaseOrder.Rows[dgvcount - 2].Cells[0];
                    //    gridPurchaseOrder.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                    //    txtItemCode.Focus();
                    //    txtItemCode.Select(txtItemCode.Text.Length, 0);
                    //    txtRemoveItem.Enabled = true;
                    //}
                    //if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    //{
                    //    int selectewIndex = gridPurchaseOrder.CurrentCell.RowIndex;
                    //    int selectewIndexActual = gridPurchaseOrder.SelectedRows[0].Index;

                    //    Color backGroundColor = gridPurchaseOrder.DefaultCellStyle.SelectionBackColor;
                    //    if (backGroundColor.Name == "DodgerBlue" || backGroundColor.Name == "Highlight")
                    //    {


                    //        MessageBox.Show("Please click on 'Remove Button' to remove item!");
                    //        txtRemoveItem.Focus();
                    //        return;

                    //    }
                    //    if (addToCartTable.Rows.Count > 0)
                    //    {
                    //        if (txtTotalAmount.Text == "")
                    //        {
                    //            txtTotalAmount.Text = "0";
                    //        }
                    //        int index = gridPurchaseOrder.SelectedRows[0].Index;
                    //        string itemId = gridPurchaseOrder.Rows[index - 1].Cells[0].Value.ToString();
                    //        if ((!ls.Contains(itemId)) || (gridPurchaseOrder.Rows[index - 1].DefaultCellStyle.Font == null))
                    //        {
                    //            int courentrow = gridPurchaseOrder.CurrentRow.Index;
                    //            string Amount = gridPurchaseOrder.Rows[courentrow - 1].Cells[6].Value.ToString();
                    //            string quantity = gridPurchaseOrder.Rows[courentrow - 1].Cells[5].Value.ToString();
                    //            int q1 = Convert.ToInt32(txtQuantityBild.Text);
                    //            q1 -= Convert.ToInt32(quantity.Trim());
                    //            txtQuantityBild.Text = q1.ToString();

                    //            if (Amount == "")
                    //            {
                    //                Amount = "0";
                    //            }
                    //            double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
                    //            totalAmount -= Convert.ToDouble(Amount.Trim());
                    //            txtTotalAmount.Text = totalAmount.ToString("##0.00");
                    //            //int index = gridPurchaseOrder.SelectedRows[0].Index;
                    //            //addToCartTable.Rows.RemoveAt(index-1);
                    //            gridPurchaseOrder.Rows[index - 1].DefaultCellStyle.Font = new Font(new FontFamily("Microsoft Sans Serif"), 9.00F, FontStyle.Strikeout);
                    //            gridPurchaseOrder.Rows[index - 1].DefaultCellStyle.ForeColor = Color.Red;
                    //            //string itemId = gridPurchaseOrder.Rows[index - 1].Cells[0].Value.ToString();// I44

                    //            ls.Add(itemId);
                    //            //gridPurchaseOrder.DataSource = addToCartTable;
                    //            if (addToCartTable.Rows.Count == 0)
                    //            {
                    //                txtTotalAmount.Text = "0.00";
                    //                //txtDiscount.Text = "0.0";
                    //            }
                    //            if (ls.Count == gridPurchaseOrder.Rows.Count - 1)
                    //            {
                    //                btnSave.TabStop = false;
                    //                btnClose.TabStop = false;
                    //                txtItemCode.Focus();
                    //                txtItemCode.Select(txtItemCode.Text.Length, 0);
                    //                gridPurchaseOrder.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                    //            }
                    //            if (gridPurchaseOrder.Rows.Count > 0)
                    //            {
                    //                // gridPurchaseOrder.Rows[gridPurchaseOrder.Rows.Count - 1].Selected = true;
                    //            }
                    //            if (gridPurchaseOrder.Rows.Count > 0)
                    //            {
                    //                txtdis.Text = "0.00";
                    //                txtdis.ReadOnly = true;
                    //            }
                    //            if (gridPurchaseOrder.Rows.Count > 1)
                    //            {
                    //                txtdis.ReadOnly = false;
                    //            }
                    //            else
                    //            {
                    //                //txtRemoveItem.Enabled = false;
                    //            }
                    //        }
                    //        else if ((!ls.Contains(itemId)) || (gridPurchaseOrder.Rows[index - 1].DefaultCellStyle.Font != null))
                    //        {
                    //            MessageBox.Show("Item already deleted!");
                    //        }
                    //    }
                    //}
                    ////}
                    //if (e.KeyChar == Convert.ToChar(Keys.Escape))
                    //{
                    //    var dgvcount = gridPurchaseOrder.Rows.Count;
                    //    gridPurchaseOrder.CurrentCell = gridPurchaseOrder.Rows[dgvcount - 2].Cells[0];
                    //    gridPurchaseOrder.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                    //    txtItemCode.Focus();
                    //    txtItemCode.Select(txtItemCode.Text.Length, 0);
                    //    txtRemoveItem.Enabled = true;
                    //}
                    #endregion
                }
            }*/
        }


        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {


            string getId = "select ItemId from ItemDetails where ItemId ='" + txtItemCode.Text + "'";
            DataTable dt = dbMainClass.getDetailByQuery(getId);
            if (e.KeyChar == (Char)Keys.Enter)
            {
                if (txtVendorCode.Text == "V")
                {
                    MessageBox.Show("Please enter vendor code first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        string salep = "";
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
                        btnSave.TabStop = false;
                        btnClose.TabStop = false;
                    }
                    else
                    {
                        MessageBox.Show("Entered item code is not valid. Please enter valid item code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    txtProductName.Text = "";
                    txtQuanity.Text = "";
                    txtQuanity.ReadOnly = true;
                    btnAddItem.Enabled = false;
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
            if (txtProductName.Text != "")
            {
                txtQuanity.Focus();
                txtQuanity.TabStop = true;
                btnAddItem.TabStop = true;
                txtRemoveItem.TabStop = true;
                txtItemCode.TabStop = true;
                txtVendorCode.TabStop = true;
                button1.TabStop = true;
                button2.TabStop = true;
            }

            else if (txtVendorCode.Text == "V")
            {
                txtVendorCode.Focus();
                txtVendorCode.Select(txtVendorCode.Text.Length, 0);
                button1.TabStop = true;
                txtVendorCode.TabStop = true;
            }
            else if (txtVendorCode.Text != "V")
            {
                gridPurchaseOrder.Focus();
                txtItemCode.Select(txtItemCode.Text.Length, 0);

                if (gridPurchaseOrder.RowCount > 1)
                {
                    IndexTex2();
                    btnClose.TabStop = true;
                    btnSave.TabStop = true;
                }
                if (ls.Count == dataGridView1.Rows.Count - 1)
                {
                    btnClose.TabStop = false;
                    btnSave.TabStop = false;
                }
            }

        }

        private void txtsearch_TextChanged_1(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                string s = comboBox1.SelectedValue.ToString();
                //string m = "v" + s;
                string selectQurry = "select vd.venderId as [Vendor ID ],vd.vName AS [Vendor Name] ,vd.vCompName AS [Company Name] ,vd.vAddress AS Address,vd.vCity AS City,vd. vState AS State ,vd.vZip AS Zip ,vd.vCountry AS Country ,vd.vEmail AS[E-Mail ],vd. vWebAddress AS[Web Address],vd.vPhone AS Phone ,vd.vMobile AS Mobile ,vd.vFax AS Fax ,vd.vPanNo as[PAN NO],vd.vGSTNo as [GST NO],vd.vDesc AS [Description],vad.vOpeningBalance AS [Opening Balance] , vad.vCurrentBalance AS [Current Balance] from  vendorDetails vd join    VendorAccountDetails  vad on vd.venderID=vad.venderID where " + s + " like '" + txtsearch.Text + "%'";
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
                    DataGridViewCellCollection CellCollection = dataGridView1.Rows[currentIndex - 1].Cells;
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
            try
            {
                if (e.ColumnIndex == 1)
                {

                    if (gridPurchaseOrder.CurrentCell.ColumnIndex == 1)
                    {
                        gridPurchaseOrder.CurrentCell = gridPurchaseOrder.Rows[gridPurchaseOrder.CurrentRow.Index-1] .Cells[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Distxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            double totalAmount = 0.00;
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //if (txtdis.Text.IndexOf('.') != -1 && txtdis.Text.Split('.')[1].Length == 2)
                //{
                //    MessageBox.Show("The maximum decimal points are 2!");
                //    e.Handled = true;
                //}
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
            //double d = 1;
            //double total = Convert.ToDouble(txtTotalAmount.Text);
            //double g = Convert.ToDouble(txtDiscount.Text);
            //double tax = d + ((g / 100));
            //double taxamount = total / tax;
            //double totaltax = total - taxamount;
            //TextTaxAmmount.Text = totaltax.ToString("###0.00");
        }

        private void DisAmmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void Distxt_TextChanged(object sender, EventArgs e)
        {
          /*
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
                //txtdis.Text = totalDiscount.ToString("###0.00");
                //txtdis.Select(txtdis.Text.Length, 0);

                // DisAmmount.Text = totalDiscount.ToString();
            }*/

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
            if (txtdis.Text == "")
            {
                txtdis.Text = "0.00";
            }
            Double totalDiscount = Convert.ToDouble(txtdis.Text);
            txtdis.Text = totalDiscount.ToString("###0.00");
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

        private void txtdis_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtdis.Text == "0.00")
            {
                txtdis.Text = "";
            }
            else if (txtdis.Text != "0.00")
            {

            }
        }

        private void txtTotalAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                if (txtTotalAmount.Text.IndexOf('.') != -1 && txtTotalAmount.Text.Split('.')[1].Length == 2)
                {
                    //MessageBox.Show("The maximum decimal points are 2!");
                    e.Handled = true;
                }
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
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtwithautaxamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                if (txtwithautaxamount.Text.IndexOf('.') != -1 && txtwithautaxamount.Text.Split('.')[1].Length == 2)
                {
                    //MessageBox.Show("The maximum decimal points are 2!");
                    e.Handled = true;
                }
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
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void DisAmmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                if (DisAmmount.Text.IndexOf('.') != -1 && DisAmmount.Text.Split('.')[1].Length == 2)
                {
                    //MessageBox.Show("The maximum decimal points are 2!");
                    e.Handled = true;
                }
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
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void TextTaxAmmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                if (TextTaxAmmount.Text.IndexOf('.') != -1 && TextTaxAmmount.Text.Split('.')[1].Length == 2)
                {
                    //MessageBox.Show("The maximum decimal points are 2!");
                    e.Handled = true;
                }
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
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void PurchesCrystalReportViewer_Load(object sender, EventArgs e)
        {

        }

        private void gridPurchaseOrder_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                   
                    if (gridPurchaseOrder.CurrentCell.ColumnIndex == 1)
                    {
                        gridPurchaseOrder.CurrentCell = gridPurchaseOrder.Rows[gridPurchaseOrder.CurrentRow.Index - 1].Cells[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void gridPurchaseOrder_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
               
                        if (e.KeyCode == Keys.Enter)
                        {
                            if (txtVendorCode.Text == "V")
                            {
                                MessageBox.Show("Please Enter the Vendor Code");
                                GetCurrentRowOFGridView().Cells[0].Value = "";
                                gridPurchaseOrder.CurrentCell = GetCurrentRowOFGridView().Cells[0];
                                txtVendorCode.Focus();
                                txtVendorCode.Select(txtVendorCode.Text.Length, 0);
                                return;
                            }
                    if (gridPurchaseOrder.Rows[0].Cells[0].Value == null)
                    {
                        return;
                    }
                    string itemId = gridPurchaseOrder.Rows[0].Cells[0].Value.ToString();

                    if (itemId =="")
                    {
                        return;
                    }
                    else
                    {
                   
                            string company = "select state from CompnayDetails";
                            DataTable dt3 = dbMainClass.getDetailByQuery(company);
                            string companystate = "";
                            foreach (DataRow dr in dt3.Rows)
                            {
                                companystate = dr[0].ToString();
                            }
                            string vendorState = "select vState from VendorDetails where venderId='" + txtVendorCode.Text + "'";
                            DataTable dt2 = dbMainClass.getDetailByQuery(vendorState);
                            string vendorstate = "";
                            foreach (DataRow dr2 in dt2.Rows)
                            {
                                vendorstate = dr2[0].ToString();
                            }

                            itemId = GetCurrentRowOFGridView().Cells[0].Value.ToString();
                            string item = "";
                            string selectQurry = "select ItemId from ItemDetails";
                            DataTable dt1 = dbMainClass.getDetailByQuery(selectQurry);
                            foreach (DataRow dr1 in dt1.Rows)
                            {
                                item = dr1[0].ToString();
                                if (item == itemId)
                                {
                                    break;
                                }

                            }
                            if (item == itemId)
                            {


                                string selectqurry = "select Ids.ItemName,itd.HSN, ipd.purChasePrice,itd.CGST,itd.SGST,itd.IGST,itd.CESS,itd.Discount from ItemDetails Ids  join ItemPriceDetail ipd on Ids.ItemId=ipd.ItemId join ItemTaxDetail itd on ipd.ItemId=itd.ItemId  where Ids.ItemId='" + itemId + "'";
                                DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
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
                               // char ch = Convert.ToChar(quantity);
                                if (!quantity.All(char.IsNumber))
                                {
                                    quantity = "0";
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
                                    price = 0.00;
                                }

                                double total = Convert.ToDouble(price.ToString());
                                double g = Convert.ToDouble(GetCurrentRowOFGridView().Cells[5].Value.ToString());
                                GetCurrentRowOFGridView().Cells[4].Value = q1.ToString();
                                double di = price * g / 100;
                                Double discontA = setDisAmount();
                                DisAmmount.Text = discontA.ToString("###0.00");
                                price = price - di;
                                GetCurrentRowOFGridView().Cells[6].Value = price.ToString("###0.00");
                                Double gst = Convert.ToDouble(GetCurrentRowOFGridView().Cells[8].Value.ToString());
                                Double cgst = Convert.ToDouble(GetCurrentRowOFGridView().Cells[7].Value.ToString());
                                Double taxv = Convert.ToDouble(GetCurrentRowOFGridView().Cells[6].Value.ToString());
                                Double igst = Convert.ToDouble(GetCurrentRowOFGridView().Cells[9].Value.ToString());
                                Double csst = Convert.ToDouble(GetCurrentRowOFGridView().Cells[10].Value.ToString());
                                double g2 = price * gst / 100;
                                taxv = taxv + g2;
                                //Double taxgst = TaxAmount(8, prices1);
                                double g1 = price * cgst / 100;
                                taxv = taxv + g1;
                                // Double taxcgst = TaxAmount(7, prices1);
                                Double g3 = price * igst / 100;
                                taxv = taxv + g3;
                                //Double taxigst = TaxAmount(9, prices1);
                                Double csst1 = price * csst / 100;
                                taxv = taxv + csst1;
                                //Double taxcess = TaxAmount(10, prices1);
                                Double TotalTax = TaxAmount(); //taxgst + taxcgst + taxigst + taxcess;
                                TextTaxAmmount.Text = TotalTax.ToString("###0.00");
                                GetCurrentRowOFGridView().Cells[11].Value = taxv.ToString("###0.00");
                                Double rat = Convert.ToDouble(GetCurrentRowOFGridView().Cells[11].Value.ToString());
                                Double withtotalammount = WithTaxAmount();
                                txtwithautaxamount.Text = withtotalammount.ToString("###0.00");
                                Double Quantity = setAmount(4);
                                txtQuantityBild.Text = Quantity.ToString();
                                Double toat = setAmount();
                                txtTotalAmount.Text = toat.ToString("###0.00");
                                gridPurchaseOrder.CurrentCell = GetCurrentRowOFGridView().Cells[4];

                                if (q1 != 0)
                                {
                                    gridPurchaseOrder.CurrentCell = gridPurchaseOrder.Rows[gridPurchaseOrder.CurrentRow.Index + 1].Cells[0];
                                }
                                //if (GetCurrentRowOFGridView().Cells[0].Value != null)
                                //{
                                //    int co = gridPurchaseOrder.CurrentRow.Index;
                                //    DataGridViewRow selectedRow = GetCurrentRowOFGridView();
                                //    selectedRow.Selected = true;
                                //    selectedRow.Cells[4].Selected = true;
                                //    // gridPurchaseOrder.CurrentCell = gridPurchaseOrder.CurrentRow.Cells[5];//[gridPurchaseOrder.CurrentCell.ColumnIndex + 2, gridPurchaseOrder.CurrentCell.RowIndex];
                                //    //gridPurchaseOrder.Focus();
                                //}

                                //}
                            }
                            else
                            {
                                if (item != itemId)
                                {

                                    MessageBox.Show("please select your correct itemid");
                                    //gridPurchaseOrder.Rows[gridPurchaseOrder.CurrentRow.Index-1].Cells[0].Value = "";
                                    gridPurchaseOrder.CurrentCell = gridPurchaseOrder.Rows[gridPurchaseOrder.CurrentRow.Index].Cells[0];
                                    if(gridPurchaseOrder.CurrentRow.Index>0)
                                    {
                                    gridPurchaseOrder.Rows.RemoveAt(gridPurchaseOrder.CurrentRow.Index-1);
                                    }
                                }
                                if (itemId == item)
                                {
                                    MessageBox.Show("please select your correct row ");
                                    gridPurchaseOrder.Rows[gridPurchaseOrder.CurrentRow.Index].Cells[0].Value = "";
                                    GetCurrentRowOFGridView().Cells[0].Selected = true;
                                    //gridPurchaseOrder.AllowUserToAddRows = false;
                                }
                            }

                        }

                    }
               // }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public Double TaxAmount()
        {
            Double amount = 0.00;
            DataGridViewRowCollection RowCollection = gridPurchaseOrder.Rows;
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

        public Double setDisAmount()
        {
            Double disamount = 0.00;
            DataGridViewRowCollection RowCollection = gridPurchaseOrder.Rows;
            for (int a = 0; a < RowCollection.Count - 1; a++)
            {

                DataGridViewRow currentRow = RowCollection[a];
                DataGridViewCellCollection cellCollection = currentRow.Cells;
                if (!string.IsNullOrWhiteSpace(cellCollection[5].Value.ToString()))
                {
                    string addamount = cellCollection[5].Value.ToString();
                    string addamount1 = cellCollection[3].Value.ToString();
                    string addamount2 = cellCollection[4].Value.ToString();
                    //if (!addamount2.All(char.IsNumber))
                    //{
                    //    addamount2 = "0";
                    //}
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
            DataGridViewRowCollection RowCollection = gridPurchaseOrder.Rows;
            for (int a = 0; a < RowCollection.Count - 1; a++)
            {

                DataGridViewRow currentRow = RowCollection[a];
                DataGridViewCellCollection cellCollection = currentRow.Cells;
                if (!string.IsNullOrWhiteSpace(cellCollection[4].Value.ToString()))
                {
                    string addamount = cellCollection[4].Value.ToString();
                    string addamount1 = cellCollection[3].Value.ToString();
                    //if (!addamount.All(char.IsNumber))
                    //{
                    //    addamount = "0";
                    //}
                    Double amount1 = Convert.ToDouble(addamount.ToString());
                    Double amount2 = Convert.ToDouble(addamount1.ToString());
                    Double Amount = amount2 * amount1;
                    amount = amount + Amount;
                }

            }
            return amount;
        }
        public Double setAmount(int value)
        {
            Double amount = 0.00;
            DataGridViewRowCollection RowCollection = gridPurchaseOrder.Rows;
            for (int a = 0; a < RowCollection.Count-1; a++)
            {

                DataGridViewRow currentRow = RowCollection[a];
                DataGridViewCellCollection cellCollection = currentRow.Cells;
                if (!string.IsNullOrWhiteSpace(cellCollection[value].Value.ToString()))
                {
                    string addamount = cellCollection[value].Value.ToString();
                    //if (!addamount.All(char.IsNumber))
                    //{
                    //    addamount = "0";
                    //}
               Double amount1=Convert.ToDouble(addamount.ToString());
               amount = amount + amount1;
                }
              
            }
            return amount;
        }
        public Double setAmount()
        {
            Double amount = 0.00;
            DataGridViewRowCollection RowCollection = gridPurchaseOrder.Rows;
            for (int a = 0; a < RowCollection.Count - 1; a++)
            {

                DataGridViewRow currentRow = RowCollection[a];
                DataGridViewCellCollection cellCollection = currentRow.Cells;
                if (!string.IsNullOrWhiteSpace(cellCollection[11].Value.ToString()))
                {
                    string addamount = cellCollection[11].Value.ToString();
                    Double amount1 = Convert.ToDouble(addamount.ToString());
                    amount = amount + amount1;
                }

            }
            return amount;
        }

        private void gridPurchaseOrder_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            ValidationFails = false;
            int col = e.ColumnIndex;
            if (col == 4) 
            {
                string value= e.FormattedValue.ToString();
                if (value != "")
                {
                    int quantiy;
                    bool validNumber = int.TryParse(value, out quantiy);
                    if (validNumber == false || quantiy == 0)
                    {
                        MessageBox.Show("Please Enter Int value");

                        e.Cancel = true;
                        gridPurchaseOrder.AllowUserToAddRows = true;
                        ValidationFails = true;
                    }
                }
                else
                {
                    int columIndex =Convert.ToInt32 (gridPurchaseOrder.CurrentRow.Index.ToString());
                    MessageBox.Show("Please Enter Int value");
                    gridPurchaseOrder.Focus();
                    return;
                }
            }
        }

        private DataGridViewRow GetCurrentRowOFGridView()
        {
            int index = gridPurchaseOrder.CurrentRow.Index;
            if (ValidationFails == false)
            {
                if (index == 0)
                {
                    index = index;
                }
                else
                {

                    index = index - 1;
                }
            }
            return gridPurchaseOrder.Rows[index];
        }
    }
}