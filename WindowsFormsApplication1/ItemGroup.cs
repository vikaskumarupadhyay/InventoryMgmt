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
    public partial class ItemGroup : Form
    {
       ComboBox item;
       List<string> GroupList;
        DataColumn dc=new DataColumn ();
        public ItemGroup(ComboBox  item,List<string> GroupList) 
        {
            this.item = item;
            this.GroupList = GroupList;
            InitializeComponent();
        }

        DB_Main dbMainClass = new DB_Main();
        private void ItemGroup_Load(object sender, EventArgs e)
        {   
            string ColumnID= dbMainClass.getUniqueID("GROUP");
            txtGroupID.Text = ColumnID;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int index = item.Items.IndexOf(txtGroupName.Text.ToUpper());
            if (index >= 0) 
            {
                MessageBox.Show("GroupName allready exists");
            }
            else
            {
                string insertQuery = "insert into dbo.ItemGroup values ('" + txtGroupID.Text + "','" + txtGroupName.Text.ToUpper() + "','" + txtGroupDesc.Text + "')";
                int insertedRecord = dbMainClass.saveDetails(insertQuery);
                if (insertedRecord > 0)
                {
                    if (item.Items.Contains("Add New Group"))
                    {
                        item.Items.Remove("Add New Group");
                        item.Items.Insert(0, "Select A Group");
                    }
                    GroupList.Add(txtGroupID.Text);
                    item.Items.Add(txtGroupName.Text);
                    
                    item.SelectedIndex = item.Items.IndexOf(txtGroupName.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Details Can Not Saved");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        

    }
}
