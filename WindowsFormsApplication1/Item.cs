using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Item : Form
    {
        DB_Main dbMainClass = new DB_Main();
        public  DataTable dt = new DataTable();
        public List<string> GroupList = new List<string>();
        public List<string> UnitList = new List<string>();
        public Item() 
        {
            InitializeComponent();
        }
        private void Item_Load(object sender, EventArgs e)
        {

            setID();

            string selectCommandGroup = "select groupID,GROUPNAME,GROUPDESC from dbo.ItemGroup";
            setItemGroupDetail(selectCommandGroup, cmbItemItemGroup, "Group");

            string selectCommandUnit = "select unitID,unitName,unitDESC from dbo.ItemUnitList";
            setItemGroupDetail(selectCommandUnit, cmbItemUnit, "Unit");
        }
        private void setID() 
        {
            string ColumnID = dbMainClass.getId("ITEM");
            txtItemProductCode.Text = ColumnID;
        }

        private void setItemGroupDetail(string Query,ComboBox cmb,string Message)
        {
            //string selectCommand = "select groupID,GROUPNAME,GROUPDESC from dbo.ItemGroup";
            cmb.Items.Clear();
            cmb.Items.Add("Select A "+Message);

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
                cmb.Items.Add("Add New "+Message);
            }
            cmb.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnItemGroup_Click(object sender, EventArgs e)
        {
            ItemGroup IG = new ItemGroup(this.cmbItemItemGroup,GroupList);
            IG.Show();
        }

        private void btnItemUnit_Click(object sender, EventArgs e)
        {
            Unit UN = new Unit(this.cmbItemUnit, UnitList);
            UN.Show();
        }

        private void btnItemSave_Click(object sender, EventArgs e)
        {
            if (cmbItemItemGroup.SelectedIndex != 0 && cmbItemUnit.SelectedIndex != 0)
            {
                string UnitId = UnitList[cmbItemUnit.SelectedIndex - 1];
                string GroupId =GroupList[cmbItemItemGroup.SelectedIndex - 1];

                string saveCommand1 = "insert into ItemDetails values ('" + txtItemProductCode.Text + "','" + txtItemProductName.Text + "','" + txtItemCompName.Text + "','" + txtItemDesc.Text + "','" + GroupId + "','" + UnitId + "')";

                string saveCommand2 = "insert into ItemPriceDetail values ('" + txtItemProductCode.Text + "','" + txtItemPrice.Text + "','" + txtItemSalesPrice.Text + "','" + txtItemMrp.Text + "','" + txtItemMargin.Text + "')";

                string saveCommand3 = "insert into ItemQuantityDetail values ('" + txtItemProductCode.Text + "','" + txtItemOpeningQuant.Text + "','" + txtItemRemaningQuant.Text + "')";

                int insertedRows = dbMainClass.saveDetails(saveCommand1, saveCommand2,saveCommand3);
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

       

       
    }
}
