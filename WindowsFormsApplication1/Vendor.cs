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
    public partial class frmVendorDetails : Form
    {
        
        public frmVendorDetails()
        {
            InitializeComponent();
        }
        public int updateCounter = 0;

        DB_Main dbMainClass = new DB_Main();
        /// <summary>
        ///   To Save Details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVenderSave_Click(object sender, EventArgs e)
        {
            if (updateCounter == 0)
            {
                string saveCommand1 = "insert into VendorDetails values ('" + txtVenderCode.Text + "','" + txtVenderName.Text + "','" + txtCompanyName.Text + "','" + txtVenderAddress.Text + "','" + txtVenderCity.Text + "','" + txtVenderState.Text + "','" + txtVenderZip.Text + "','" + txtVenderCountry.Text + "','" + txtVenderEmailAddress.Text + "','" + txtVenderWebSite.Text + "','" + txtVenderPhone.Text + "', '" + txtVenderMobile.Text + "','" + txtVenderFax.Text + "','" + txtVenderDesc.Text + "')";

                string saveCommand2 = "insert into VendorAccountDetails values ('" + txtVenderCode.Text + "','" + txtVenderCode.Text + "','" + txtVenderOpeningBal.Text + "','" + txtVenderCurrentBal.Text + "')";

                int insertedRows = dbMainClass.saveDetails(saveCommand1, saveCommand2);
                if (insertedRows > 0)
                {
                    btnVenderList.Enabled = true; 
                    MessageBox.Show("Details Saved Successfully");
                    txtVenderName.Focus();
                }
                else
                {
                    MessageBox.Show("Details Not Saved Successfully");
                }
            }
            else if(updateCounter==1)
            {
                string updateCommand1 = "update  VendorDetails  set  vName='" + txtVenderName.Text + "', vCompName= '" + txtCompanyName.Text + "',vAddress='" + txtVenderAddress.Text + "',vCity='" + txtVenderCity.Text + "',vState='" + txtVenderState.Text + "',vZip='" + txtVenderZip.Text + "',vCountry='" + txtVenderCountry.Text + "',vEmail='" + txtVenderEmailAddress.Text + "',vWebAddress='" + txtVenderWebSite.Text + "',vPhone='" + txtVenderPhone.Text + "', vMobile='" + txtVenderMobile.Text + "',vFax='" + txtVenderFax.Text + "',vDesc='" + txtVenderDesc.Text + "' where venderid='"+ txtVenderCode.Text+"'";
                string updateCommand2 = "update   VendorAccountDetails set vOpeningBalance='" + txtVenderOpeningBal.Text + "',vCurrentBalance='" + txtVenderCurrentBal.Text + "' where venderId='" + txtVenderCode.Text + "'";

                int updatedRows = dbMainClass.updateDetails(updateCommand1, updateCommand2);
                if (updatedRows > 0)
                {
                    txtVenderName.Focus();
                    MessageBox.Show("Details Updated Successfully");
                    
                }
                else
                {
                    MessageBox.Show("Details Can not updated");
                }
                updateCounter = 0;
            }
            makeBlank();
            string Id = getId("VENDOR");
            txtVenderCode.Text = Id;
        }

        #region  To Make all Field Blanks
        private void makeBlank() 
        {

            txtVenderCode.Text = "";
            txtVenderName.Text = "";
            txtCompanyName.Text = "";
            txtVenderAddress.Text = "";
            txtVenderCity.Text = "";
            txtVenderState.Text = "";
            txtVenderCountry.Text = "";
            txtVenderZip.Text = "";
            txtVenderEmailAddress.Text = "";
            txtVenderWebSite.Text = "";
            txtVenderPhone.Text = "";
            txtVenderMobile.Text = "";
            txtVenderFax.Text = "";
            txtVenderDesc.Text = "";

            txtVenderOpeningBal.Text = "0";
            txtVenderCurrentBal.Text = "0";

            txtVenderCode.Text = "";
            txtVenderCode.Text = "";
        
        }
        #endregion

        private void btnVenderClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtVenderOpeningBal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(Char.GetNumericValue(e.KeyChar).ToString());
            //MessageBox.Show(e.KeyChar.);

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void txtVenderOpeningBal_TextChanged(object sender, EventArgs e)
        {
            if (txtVenderOpeningBal.Text == "")
            {
                txtVenderCurrentBal.Text = "0";
            }
            else
            {
                string value = txtVenderOpeningBal.Text;
                txtVenderCurrentBal.Text = value;
            }
        }

        private void txtVenderOpeningBal_Enter(object sender, EventArgs e)
        {
            if (txtVenderOpeningBal.Text == "0") 
            {
                txtVenderOpeningBal.Text = "";
            }
        }

        private void txtVenderOpeningBal_Leave(object sender, EventArgs e)
        {
            if (txtVenderOpeningBal.Text == "")
            {
                txtVenderOpeningBal.Text = "0";

            }
        }

        private void frmVendorDetails_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            string Id = getId("VENDOR");
            txtVenderCode.Text = Id;
            if (Id == "V0001") 
            {
                btnVenderList.Enabled = false;
            } 
            else
            {
                btnVenderList.Enabled = true; 
            }
        }

        private string getId(string Table) 
        {
            string Id = dbMainClass.getUniqueID("VENDOR");
            
            if (!Id.Contains("ERROR"))
            {
                if (Id.Length == 2)
                {
                    Id = Id[0].ToString() + "000" + Id[1].ToString();
                }
                else if (Id.Length == 3)
                {
                    Id = Id[0].ToString() + "00" + Id.Substring(1);
                }
                else if (Id.Length == 4)
                {
                    Id = Id[0].ToString() + "0" + Id.Substring(1);
                }
                
            }
            return Id;
        }

        private void btnVenderList_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
           DataTable dt= dbMainClass.getDetails("VENDORDETAILS");
           dataGridView1.DataSource = dt;
          }

        private void setDetails(DataGridViewCellCollection cellCollection) 
        {
            try
            {
                txtVenderCode.Text = cellCollection[0].Value.ToString();
                txtVenderName.Text = cellCollection[1].Value.ToString();
                txtCompanyName.Text = cellCollection[2].Value.ToString();
                txtVenderAddress.Text = cellCollection[3].Value.ToString();
                txtVenderCity.Text = cellCollection[4].Value.ToString();
                txtVenderState.Text = cellCollection[5].Value.ToString();
                txtVenderCountry.Text = cellCollection[7].Value.ToString();
                txtVenderZip.Text = cellCollection[6].Value.ToString();
                txtVenderEmailAddress.Text = cellCollection[8].Value.ToString();
                txtVenderWebSite.Text = cellCollection[9].Value.ToString();
                txtVenderPhone.Text = cellCollection[10].Value.ToString();
                txtVenderMobile.Text = cellCollection[11].Value.ToString();
                txtVenderFax.Text = cellCollection[12].Value.ToString();
                txtVenderDesc.Text = cellCollection[13].Value.ToString();

                txtVenderOpeningBal.Text = cellCollection[14].Value.ToString();
                txtVenderCurrentBal.Text = cellCollection[15].Value.ToString();
            }
            catch (Exception ex) 
            {
            
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
                DataGridViewCellCollection cellCollection= dataGridView1.SelectedRows[0].Cells;
                setDetails(cellCollection);
                    panel1.Visible = false;
                //panel2.Visible = false;
            //    btnVenderSave.Text = "Update";
             updateCounter = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection cellCollection = dataGridView1.SelectedRows[0].Cells;
            setDetails(cellCollection);
            panel1.Visible = false;
            //panel2.Visible = false;
            //    btnVenderSave.Text = "Update";
            updateCounter = 1;
        }

       
    }
}
