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
    public partial class Tex : Form
    {
        ComboBox item;
      List<string> TexList;
        DataColumn dc = new DataColumn();
        public Tex(ComboBox item, List<string> TexList)
        {
            this.item = item;
            this.TexList = TexList;
            InitializeComponent();
        }
        DB_Main dbMainClass = new DB_Main();
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tex_Load(object sender, EventArgs e)
        {
            string ColumnID = dbMainClass.getUniqueID("TAX");
            txtTexId.Text = ColumnID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTexName.Text))
            {
                txtTexName.Focus();
                MessageBox.Show("Pleas Enter The TexName");
            }
            else
            {
                if (string.IsNullOrEmpty(txtTexAmount.Text))
                {
                    MessageBox.Show("Pleas Enter The TexAmount");

                }
                else
                {
                    int index = item.Items.IndexOf(txtTexName.Text.ToUpper());
                    if (index >= 0)
                    {
                        MessageBox.Show("GroupName allready exists");
                    }
                    else
                    {
                        string insertQuery = "insert into dbo.CompnayTex values ('" + txtTexId.Text + "','" + txtTexName.Text.ToUpper() + "','" + txtTexAmount.Text + "','" + txtGroupDesc.Text + "')";
                        int insertedRecord = dbMainClass.saveDetails(insertQuery);
                        if (insertedRecord > 0)
                        {
                            if (item.Items.Contains("Add New Tax"))
                            {
                                item.Items.Remove("Add New Tax");
                                item.Items.Insert(0, "Select  Tax");
                            }
                            TexList.Add(txtTexId.Text);
                            item.Items.Add(txtTexName.Text);

                            item.SelectedIndex = item.Items.IndexOf(txtTexName.Text);
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

        private void txtTexAmount_MouseEnter(object sender, EventArgs e)
        {

        }

        private void txtTexAmount_Leave(object sender, EventArgs e)
        {
            if (txtTexAmount.Text == "")
            {
                txtTexAmount.Text = "0";
            }
        }

        private void txtTexAmount_MouseClick(object sender, MouseEventArgs e)
        {
            if(txtTexAmount.Text=="0")
            {
                txtTexAmount.Text="";
            }
        }
    }
}
