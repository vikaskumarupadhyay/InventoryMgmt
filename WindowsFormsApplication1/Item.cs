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
    public partial class Item : Form
    {
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
        private void Item_Load(object sender, EventArgs e)
        {
            string selectqurry = "select itm.ItemName,itm.ItemCompName,itm.ItemDesc,itm.groupid,itm.Unitid,ipd.purChasePrice,ipd.SalesPrice,ipd.MrpPrice,ipd.Margin,iqd.OpeningQuantity,iqd.CurrentQuantity from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            List<string> ls = new List<string>();
            DataColumnCollection d = dt.Columns;
            for (int a = 0; a < d.Count; a++)
            {
                //DataColumn dc = new DataColumn();
                string b = d[a].ToString();
                ls.Add(b);
            }

            searchCalmn.DataSource = ls;
            panel1.Visible = false;
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

                string saveCommand1 = "update ItemDetails set itemId='" + txtItemProductCode.Text + "',itemName='" + txtItemProductName.Text + "',itemCompName='" + txtItemCompName.Text + "',itemDesc='" + txtItemDesc.Text + "',groupid='" + cmbItemItemGroup.Text + "',Unitid='" + cmbItemUnit.Text + "'where itemId='" + txtItemProductCode.Text + "'";

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
        }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void makeBlank()
        {

            txtItemProductCode.Text = "";
            txtItemProductName.Text = "";
            txtItemCompName.Text = "";
            txtItemDesc.Text = "";
            cmbItemItemGroup.Text = "";
            cmbItemUnit.Text = "";
            txtItemPrice.Text = "";
            txtItemSalesPrice.Text = "";
            txtItemMrp.Text = "";
            txtItemMargin.Text = "0";
            txtItemOpeningQuant.Text = "";
            txtItemRemaningQuant.Text = "0";

        }

        private void btnItemList_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            //SqlConnection con = dbMainClass.openConnection();
            string selectqurry = "select itm.ItemId,itm.ItemName,itm.ItemCompName,itm.ItemDesc,itm.groupid,itm.Unitid,ipd.purChasePrice,ipd.SalesPrice,ipd.MrpPrice,ipd.Margin,iqd.OpeningQuantity,iqd.CurrentQuantity from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid";
            //SqlCommand cmd = new SqlCommand(selectqurry, con);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //sda.Fill(ds);
            //DataTable dt = ds.Tables[0];
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            dataGridView1.DataSource = dt;
        }

        private void buttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttAddNewRecord_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void buttUpdate_Click(object sender, EventArgs e)
        {

            DataGridViewCellCollection cellCollection = dataGridView1.SelectedRows[0].Cells;
            setDetails(cellCollection);
            panel1.Visible = false;
            updatecounter = 1;

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
            string txt = txtItemOpeningQuant.Text;
            txtItemRemaningQuant.Text = txt;
        }

        private void txtItemMrp_Leave(object sender, EventArgs e)
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
            //int totelmrp = mrp - pPrice;
            //txtItemMargin.Text = totelmrp.ToString();
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
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
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
            //int totelmrp = mrp - pPrice;
            //txtItemMargin.Text = totelmrp.ToString();

        }

        private void txtItemMrp_TextChanged(object sender, EventArgs e)
        {

            if (txtItemPrice.Text == "")
            {
                txtItemPrice.Text = "0";
            }
            if (txtItemMrp.Text == "")
            {
                txtItemMrp.Text = "0";
            }
            int pPrice = Convert.ToInt32(txtItemPrice.Text);
            int mrp = Convert.ToInt32(txtItemMrp.Text);
            int totelmrp =mrp- pPrice ;
            txtItemMargin.Text = totelmrp.ToString();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string s = searchCalmn.SelectedValue.ToString();
            string selectQurry = "select itm.ItemId,itm.ItemName,itm.ItemCompName,itm.ItemDesc,itm.groupid,itm.Unitid,ipd.purChasePrice,ipd.SalesPrice,ipd.MrpPrice,ipd.Margin,iqd.OpeningQuantity,iqd.CurrentQuantity from ItemDetails itm join ItemPriceDetail ipd on itm.itemid=ipd.itemid join ItemQuantityDetail iqd on ipd.itemid=iqd.itemid  where "+s+" like '"+txtSearch.Text+"%'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            dataGridView1.DataSource = dt;
        }
    }

}
