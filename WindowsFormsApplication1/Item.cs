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
    public partial class Item : Form
    {
        int value = 0;
        ItemDetails itm = new ItemDetails();
        public int updatecounter = 0;
        DB_Main dbMainClass = new DB_Main();
        public DataTable dt = new DataTable();
        public List<string> GroupList = new List<string>();
        public List<string> UnitList = new List<string>();
        public Item()
        {
            InitializeComponent();
        }
        public Item(int value1)
        {
            value = value1;
            InitializeComponent();
        }
        private void Item_Load(object sender, EventArgs e)
        {
            if (value == 1)
            {
                panel1.Visible = true;
            }
            else if (value == 0)
            {
                panel1.Visible = false;
            }
            string selectqurry = "select  itm.ItemId,itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],ipd.purChasePrice as [Purchase Price],ipd.SalesPrice as[Sales Price],ipd.MrpPrice as[Mrp Price],ipd.Margin as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId";
            string selectqurryForActualColumnName = "select top 1  itm.ItemId, itm.ItemName,itm.ItemCompName ,itm.ItemDesc ,ig.groupName,iul.unitName ,ipd.purChasePrice ,ipd.SalesPrice ,ipd.MrpPrice ,ipd.Margin ,iqd.OpeningQuantity ,iqd.CurrentQuantity from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            DataTable dtOnlyColumnName = dbMainClass.getDetailByQuery(selectqurryForActualColumnName);
            DataTable customDataTable = new DataTable();
            customDataTable.Columns.Add("ActualTableColumnName");
            customDataTable.Columns.Add("AliasTableColumnName");
            DataColumnCollection d = dt.Columns;
            DataColumnCollection dataColumnForName = dtOnlyColumnName.Columns;
            for (int a = 1; a < d.Count; a++)
            {
                string b = d[a].ToString();
                string actualColumnName = dataColumnForName[a].ToString();
                DataRow dr = customDataTable.NewRow();
                dr["ActualTableColumnName"] = actualColumnName;
                dr["AliasTableColumnName"] = b;
                customDataTable.Rows.Add(dr);
            }

            searchCalmn.DataSource = customDataTable;
            searchCalmn.ValueMember = "ActualTableColumnName";
            searchCalmn.DisplayMember = "AliasTableColumnName";
            dataGridView1.DataSource = dt;
           // panel1.Visible = false;
            string Id = dbMainClass.getUniqueID("ItemDetails");
            txtItemProductCode.Text=Id;
            if (Id == "l0001")
            {
                btnItemList.Enabled = false;
            }
            else
            {
                btnItemList.Enabled = true;
            }

            //setID();

            string selectCommandGroup = "select groupID,GROUPNAME,GROUPDESC from dbo.ItemGroup";
            setItemGroupDetail(selectCommandGroup, cmbItemItemGroup, "Group");

            string selectCommandUnit = "select unitID,unitName,unitDESC from dbo.ItemUnitList";
            setItemGroupDetail(selectCommandUnit, cmbItemUnit, "Unit");
        }

        private void setItemGroupDetail(string Query, ComboBox cmb, string Message)
        {
            //string selectCommand = "select groupID,GROUPNAME,GROUPDESC from dbo.ItemGroup";
            cmb.Items.Clear();
            cmb.Items.Add("Select A " + Message);

            dt = dbMainClass.getDataBoundToComboBox(Query);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cmb.Items.Add(dr[1].ToString().ToUpper());
                    if (Message.ToUpper() == "UNIT")
                    {
                        UnitList.Add(dr[0].ToString());
                    }
                    else
                    {
                        GroupList.Add(dr[0].ToString());
                    }
                }
                dt.Dispose();
            }
            else if (dt != null && dt.Rows.Count == 0)
            {
                cmb.Items.Clear();
                cmb.Items.Add("Add New " + Message);
            }
            cmb.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnItemGroup_Click(object sender, EventArgs e)
        {
            ItemGroup IG = new ItemGroup(this.cmbItemItemGroup, GroupList);
            IG.Show();
        }

        private void btnItemUnit_Click(object sender, EventArgs e)
        {
            Unit UN = new Unit(this.cmbItemUnit, UnitList);
            UN.Show();
        }

        private void btnItemSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItemProductName.Text))
            {
                MessageBox.Show("please select your itemname");
            }
            else
            {
                if(string.IsNullOrEmpty(txtItemCompName.Text))
                {
                    MessageBox.Show("please select your compnay name");
                }
                else
                {
                    if(string.IsNullOrEmpty(txtItemDesc.Text))
                    {
                        MessageBox.Show("please select your description");
                    }
                    else
                    {
                        if(string.IsNullOrEmpty(cmbItemItemGroup.Text))
                        {
                            MessageBox.Show("please select your item group");
                        }
                        else
                        {
                            if(string.IsNullOrEmpty(cmbItemUnit.Text))
                            {
                                MessageBox.Show("plese select your unit");
                            }
                            else
                            {
                                if(string.IsNullOrEmpty(txtItemPrice.Text))
                                {
                                    MessageBox.Show("please select your itemprice");
                                }
                                else
                                {
                                    if(string.IsNullOrEmpty(txtItemSalesPrice.Text))
                                    {
                                        MessageBox.Show("please select your sales price");
                                   }
                                    else
                                    {
                                        if(string.IsNullOrEmpty(txtItemMrp.Text))
                                        {
                                            MessageBox.Show("please select your mrp");
                                    }
                                        else
                                        {
                                            if(string.IsNullOrEmpty(txtItemMargin.Text))
                                            {
                                                MessageBox.Show("please select your margin");
                                            }
                                            else
                                            {
                                                if(string.IsNullOrEmpty(txtItemOpeningQuant.Text))
                                                {
                                                    MessageBox.Show("please select your opening quantity");
                                                }
                                            
            if (updatecounter == 0)
            {
                if (cmbItemItemGroup.SelectedIndex != 0 && cmbItemUnit.SelectedIndex != 0)
                {
                    string UnitId = UnitList[cmbItemUnit.SelectedIndex - 1];
                    string GroupId = GroupList[cmbItemItemGroup.SelectedIndex - 1];

                    string saveCommand1 = "insert into ItemDetails values ('" + txtItemProductCode.Text + "','" + txtItemProductName.Text + "','" + txtItemCompName.Text + "','" + txtItemDesc.Text + "','" + GroupId + "','" + UnitId + "')";

                    string saveCommand2 = "insert into ItemPriceDetail values ('" + txtItemProductCode.Text + "','" + txtItemPrice.Text + "','" + txtItemSalesPrice.Text + "','" + txtItemMrp.Text + "','" + txtItemMargin.Text + "')";

                    string saveCommand3 = "insert into ItemQuantityDetail values ('" + txtItemProductCode.Text + "','" + txtItemOpeningQuant.Text + "','" + txtItemRemaningQuant.Text + "')";

                    int insertedRows = dbMainClass.saveDetails(saveCommand1, saveCommand2, saveCommand3);
                    if (insertedRows > 0)
                    {
                        //btnList.Enabled = true;
                        txtItemProductName.Focus();
                        MessageBox.Show("Details Saved Successfully");

                    }
                    else
                    {
                        MessageBox.Show("Details Not Saved Successfully");
                    }

                }
            }
            else if (updatecounter == 1)
            {
                //string groupname = cmbItemItemGroup.Text;

                string saveCommand1 = "update ItemDetails set itemId='" + txtItemProductCode.Text + "',itemName='" + txtItemProductName.Text + "',itemCompName='" + txtItemCompName.Text + "',itemDesc='" + txtItemDesc.Text + "'where itemId='" + txtItemProductCode.Text + "'";

                string saveCommand2 = "update ItemPriceDetail  set  purChasePrice='" + txtItemPrice.Text + "', SalesPrice='" + txtItemSalesPrice.Text + "', MrpPrice='" + txtItemMrp.Text + "',Margin='" + txtItemMargin.Text + "'where itemId='" + txtItemProductCode.Text + "'";

                string saveCommand3 = "update ItemQuantityDetail set OpeningQuantity='" + txtItemOpeningQuant.Text + "',CurrentQuantity='" + txtItemRemaningQuant.Text + "' where itemId='" + txtItemProductCode.Text + "'";

                int insertedRows = dbMainClass.saveDetails(saveCommand1, saveCommand2, saveCommand3);
                if (insertedRows > 0)
                {

                    txtItemProductName.Focus();
                    MessageBox.Show("Details Saved Successfully");

                }
                else
                {
                    MessageBox.Show("Details Not Saved Successfully");
                }
               
            }
            makeBlank();
            string Id = dbMainClass.getUniqueID("ItemDetails");
            txtItemProductCode.Text = Id;
            btnItemList.Enabled = true;
        }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            txtItemProductName.Focus();
        }
        private void makeBlank()
        {

            txtItemProductCode.Text = "";
            txtItemProductName.Text = "";
            txtItemCompName.Text = "";
            txtItemDesc.Text = "";
            cmbItemItemGroup.Text = "Select A Group";
            cmbItemUnit.Text = "Select A Unit";
            txtItemPrice.Text = "";
            txtItemSalesPrice.Text = "0";
            txtItemMrp.Text = "0";
            txtItemMargin.Text = "0";
            txtItemOpeningQuant.Text = "0";
            txtItemRemaningQuant.Text = "0";

        }

        private void btnItemList_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            //SqlConnection con = dbMainClass.openConnection();
            string selectqurry = "select  itm.ItemId as[Item Id],itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],ipd.purChasePrice as [Purchase Price],ipd.SalesPrice as[Sales Price],ipd.MrpPrice as[Mrp Price],ipd.Margin as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            dataGridView1.DataSource = dt;
            tabindix();
            searchCalmn.Focus();
        }

        private void buttClose_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            tabindix1();
            txtItemProductName.Focus();
        }

        private void buttAddNewRecord_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            tabindix1();
            txtItemProductName.Focus();
        }

        private void buttUpdate_Click(object sender, EventArgs e)
        {

            DataGridViewCellCollection cellCollection = dataGridView1.SelectedRows[0].Cells;
            setDetails(cellCollection);
            panel1.Visible = false;
            updatecounter = 1;
            tabindix1();
            txtItemProductName.Focus();
            btnItemList.Enabled = false;

        }
        private void setDetails(DataGridViewCellCollection cellCollection)
        {
            try
            {
                txtItemProductCode.Text = cellCollection[0].Value.ToString();
                txtItemProductName.Text = cellCollection[1].Value.ToString();
                txtItemCompName.Text = cellCollection[2].Value.ToString();
                txtItemDesc.Text = cellCollection[3].Value.ToString();
                cmbItemItemGroup.Text = cellCollection[4].Value.ToString();
                cmbItemUnit.Text = cellCollection[5].Value.ToString();
                txtItemPrice.Text = cellCollection[6].Value.ToString();
                txtItemSalesPrice.Text = cellCollection[7].Value.ToString();
                txtItemMrp.Text = cellCollection[8].Value.ToString();
                txtItemMargin.Text = cellCollection[9].Value.ToString();
                txtItemOpeningQuant.Text = cellCollection[10].Value.ToString();
                txtItemRemaningQuant.Text = cellCollection[11].Value.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSearch.Text = "";
            searchCalmn.SelectedIndex = 0;
            DataGridViewCellCollection cellCollection = dataGridView1.Rows[e.RowIndex].Cells;
                setDetails(cellCollection);
            panel1.Visible = false;
            updatecounter = 1;
            txtItemProductName.Focus();
            btnItemList.Enabled = false;
        }
        private string getId(string Table)
        {
            string Id = dbMainClass.getUniqueID("ItemDetails");
            //string id1 = "";
            if (!Id.Contains("ERROR"))
            {


                if (Id.Length == 2)
                {
                    Id = Id[0].ToString() + "" + Id[1].ToString();
                }
                if (Id.Length == 3)
                {
                    Id = Id[0].ToString() + "" + Id.Substring(1);
                }
                else if (Id.Length == 4)
                {
                    Id = Id[0].ToString() + "" + Id.Substring(1);
                }

            }
            return Id;
        }

        private void txtItemOpeningQuant_TextChanged(object sender, EventArgs e)
        {
            if (txtItemOpeningQuant.Text =="")
            {
                txtItemRemaningQuant.Text ="0";
            }
            if (txtItemOpeningQuant.Text != "")
            {
                string txt = txtItemOpeningQuant.Text;
                txtItemRemaningQuant.Text = txt;
            }
        }

        private void txtItemMrp_Leave(object sender, EventArgs e)
        {
            //if (txtItemPrice.Text == "")
            //{
            //    txtItemPrice.Text = "0";
            //}
            if (txtItemMrp.Text == "")
            {
                txtItemMrp.Text = "0";
            }
            //int pPrice = Convert.ToInt32(txtItemPrice.Text);
            //int mrp = Convert.ToInt32(txtItemMrp.Text);
            //int totelmrp = mrp - pPrice;
            //txtItemMargin.Text = totelmrp.ToString();
        }
        private void tabindix()
        {
            txtItemProductCode.TabStop = false;
            txtItemProductName.TabStop = false;
            txtItemCompName.TabStop = false;
            txtItemDesc.TabStop = false;
            txtItemMargin.TabStop = false;
            txtItemMrp.TabStop = false;
            txtItemOpeningQuant.TabStop = false;
            txtItemPrice.TabStop = false;
            txtItemRemaningQuant.TabStop = false;
            txtItemSalesPrice.TabStop = false;
            cmbItemItemGroup.TabStop = false;
            cmbItemUnit.TabStop = false;
            btnItemList.TabStop = false;
            btnItemGroup.TabStop = false;
            panel1.TabStop = false;
            btnItemUnit.TabStop = false;
            btnItemSave.TabStop = false;
            btnItemClose.TabStop = false;
        }
        private void tabindix1()
        {
            txtItemProductCode.TabStop = true;
            txtItemProductName.TabStop = true;
            txtItemCompName.TabStop = true;
            txtItemDesc.TabStop = true;
            txtItemMargin.TabStop = false;
            txtItemMrp.TabStop = true;
            txtItemOpeningQuant.TabStop = true;
            txtItemPrice.TabStop = true;
            txtItemRemaningQuant.TabStop = false;
            txtItemSalesPrice.TabStop = true;
            cmbItemItemGroup.TabStop = true;
            cmbItemUnit.TabStop = true;
            btnItemList.TabStop = true;
            btnItemGroup.TabStop = true;
            panel1.TabStop = true;
            btnItemUnit.TabStop = true;
            btnItemSave.TabStop = true;
            btnItemClose.TabStop = true;
        }
        private void txtItemMrp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    if (txtItemMrp.Text == "")
                    {
                        txtItemMrp.Text = "0";
                    }
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
           
            //if (txtItemMrp.Text == "")
            //{
            //    txtItemMrp.Text = "0";
            //}
            //int pPrice = Convert.ToInt32(txtItemPrice.Text);
            //int mrp = Convert.ToInt32(txtItemMrp.Text);
            //int totelmrp = mrp - pPrice;
            //txtItemMargin.Text = totelmrp.ToString();

        }

        private void txtItemMrp_TextChanged(object sender, EventArgs e)
        {

            //if (txtItemPrice.Text == "")
            //{
            //    txtItemPrice.Text = "0";
            //}
            //if (txtItemMrp.Text == "")
            //{
            //    txtItemMrp.Text = "0";
            //}
            //int pPrice = Convert.ToInt32(txtItemPrice.Text);
            //int mrp = Convert.ToInt32(txtItemMrp.Text);
            //int totelmrp =mrp- pPrice ;
            //txtItemMargin.Text = totelmrp.ToString();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string s = searchCalmn.SelectedValue.ToString();
            string selectQurry = "select itm.ItemId as[Item Id],itm.ItemName as[Item Name],itm.ItemCompName as [Company Name],itm.ItemDesc as [Item Description],ig.groupName as [Group Name],iul.unitName as [Unit Name],ipd.purChasePrice as [Purchase Price],ipd.SalesPrice as[Sales Price],ipd.MrpPrice as[Mrp Price],ipd.Margin as[Margin],iqd.OpeningQuantity as [Opening Quantity],iqd.CurrentQuantity as[Current Quantity] from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid join ItemGroup ig on itm.groupid=ig.groupID join ItemUnitList iul on itm.Unitid=iul.UnitId  where " + s + " like '" + txtSearch.Text + "%'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            dataGridView1.DataSource = dt;
        }

        private void btnItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
             int currentIndex = dataGridView1.CurrentRow.Index;
             if (e.KeyChar == (char)Keys.Enter)
             {
                 txtSearch.Text = "";
                 searchCalmn.SelectedIndex = 0;
                 DataGridViewCellCollection cellCollection = dataGridView1.Rows[currentIndex-1].Cells;
                 setDetails(cellCollection);
                 panel1.Visible = false;
                 updatecounter = 1;
                 tabindix1();
                 txtItemProductName.Focus();
                 btnItemList.Enabled =false;
             }

        }

        private void txtItemSalesPrice_TextChanged(object sender, EventArgs e)
        {
            string num=txtItemPrice.Text;
            string num1=txtItemSalesPrice.Text;
            if (num == "")
                {
                    num = "0";
                }
            if (num1 == "")
                {
                    num1 = "0";
                }
                double pPrice = Convert.ToDouble(num);
                double mrp = Convert.ToDouble(num1);
                double totelmrp = mrp - pPrice;
                txtItemMargin.Text = totelmrp.ToString();

        }

        private void txtItemPrice_TextChanged(object sender, EventArgs e)
        {
            string value = txtItemSalesPrice.Text;
            string value1 = txtItemPrice.Text;
            if (value == "0")
            {
            if (value1 == "")
                {
                    value1 = "0";
                }
            if (value == "")
                {
                    value = "0";
                }
                double pPrice = Convert.ToDouble(value1);
                double mrp = Convert.ToDouble(value);
              double totelmrp = mrp - pPrice;
                txtItemMargin.Text = "0";//totelmrp.ToString();
           }
            if (value != "0")
            {
                if (value1 == "")
                {
                    value1 = "0";
                }
                if (value == "")
                {
                    value = "0";
                }
                double pPrice = Convert.ToDouble(value1);
                double mrp = Convert.ToDouble(value);
                double totelmrp = mrp - pPrice;
                txtItemMargin.Text = totelmrp.ToString();
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            DataGridViewRowCollection RowCollection = dataGridView1.Rows;
            List<printclass> classCollection = new List<printclass>();
            for (int a = 0; a < RowCollection.Count; a++)
            {

                DataGridViewRow currentRow = RowCollection[a];
                DataGridViewCellCollection cellCollection = currentRow.Cells;
                printclass classObject = new printclass();
                classObject.Name = cellCollection[1].Value.ToString();
                classObject.Address = cellCollection[2].Value.ToString();
                classObject.Phone = cellCollection[6].Value.ToString();
                classObject.Email = cellCollection[7].Value.ToString();
                classObject.OpningBalnce = cellCollection[8].Value.ToString();
                classObject.CurrentBalnce = cellCollection[10].Value.ToString();
                classObject.mrp = cellCollection[11].Value.ToString();
                classCollection.Add(classObject);
            }
            VendorPrint vp = new VendorPrint(classCollection,2);
            vp.Show();
        }

        private void txtItemSalesPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
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
        }

        private void txtItemPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
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
        }

        private void txtItemPrice_Leave(object sender, EventArgs e)
        {
            if (txtItemPrice.Text == "")
            {
                txtItemPrice.Text = "0";
            }

        }

        private void txtItemSalesPrice_Leave(object sender, EventArgs e)
        {
            if (txtItemSalesPrice.Text == "")
            {
                txtItemSalesPrice.Text = "0";
            }
        }

        private void txtItemPrice_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void txtItemPrice_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtItemPrice.Text == "0")
            {
                txtItemPrice.Text = "";
            }
        }

        private void txtItemMrp_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtItemMrp.Text == "0")
            {
                txtItemMrp.Text = "";
            }

        }

        private void txtItemSalesPrice_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtItemSalesPrice.Text == "0")
            {
                txtItemSalesPrice.Text = "";
            }

        }

        private void txtItemOpeningQuant_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtItemOpeningQuant.Text == "0")
            {
                txtItemOpeningQuant.Text = "";
               txtItemRemaningQuant.Text = "0";
            }
        }

        private void txtItemOpeningQuant_Leave(object sender, EventArgs e)
        {
            if (txtItemOpeningQuant.Text =="")
            {
                txtItemRemaningQuant.Text = "0";
            }

            string txt = txtItemOpeningQuant.Text;
            txtItemRemaningQuant.Text = txt;
        }

        private void txtItemOpeningQuant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                
                if (e.KeyChar == '\b')
                {
                    //txtItemRemaningQuant.Text = "0";
                    e.Handled = false;
                   
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
    }

}
