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
    public partial class Unit : Form
    {
        ComboBox item;
        List<string> UnitList;
        DB_Main dbMainClass = new DB_Main();
        public Unit(ComboBox item, List<string> UnitList)
        {
            this.UnitList = UnitList;
            InitializeComponent();
            this.item = item;
        }

        private void Unit_Load(object sender, EventArgs e)
        {
            string ColumnID = dbMainClass.getUniqueID("UNIT");
            txtUnitId.Text = ColumnID;   
        }

        private void btnUnitClose_Click(object sender, EventArgs e)
        {

        }

        private void btnUnitSave_Click(object sender, EventArgs e)
        {
            int index = item.Items.IndexOf(txtUnitName.Text.ToUpper());
            if (index >= 0)
            {
                MessageBox.Show("Unit allready exists");
            }
            else
            {
                string insertQuery = "insert into dbo.ItemUnitList values ('" + txtUnitId.Text + "','" + txtUnitName.Text.ToUpper() + "','" + txtUnitDesc.Text + "')";
                int insertedRecord = dbMainClass.saveDetails(insertQuery);
                if (insertedRecord > 0)
                {
                    if (item.Items.Contains("Add New Unit"))
                    {
                        item.Items.Remove("Add New Unit");
                        item.Items.Insert(0, "Select A Unit");
                    }
                    UnitList.Add(txtUnitId.Text);
                    item.Items.Add(txtUnitName.Text);
                    item.SelectedIndex = item.Items.IndexOf(txtUnitName.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Details Can Not Saved");
                }
            }
        }
    }
}
