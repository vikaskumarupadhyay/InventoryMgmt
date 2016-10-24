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
    public partial class Customer : Form
    {
        DB_Main dbMainClass = new DB_Main();
        public int updateCounter = 0;
        public Customer()
        {
            InitializeComponent();
        }


        // Load Event 
        private void Customer_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            string Id = getId("CUST");
            txtCustCode.Text = Id;

            if (Id == "C0001") 
            {
                btnList.Enabled = false;
            }
            else 
            {
                btnList.Enabled = true;
            }
        }
        // Close again click event
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Save Button Click Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustName.Text))
            {
                MessageBox.Show("please enter your name");
            }
            else
            {
                if (updateCounter == 0)
                {
                    string saveCommand1 = "insert into CustomerDetails values ('" + txtCustCode.Text + "','" + txtCustName.Text + "','" + txtCustCompName.Text + "','" + txtCustAdd.Text + "','" + txtCustCity.Text + "','" + txtCustState.Text + "','" + txtCustZip.Text + "','" + txtCustCountry.Text + "','" + txtCustEmail.Text + "','" + txtCustWebSite.Text + "','" + txtCustPhone.Text + "', '" + txtCustMobile.Text + "','" + txtCustFax.Text + "','" + txtCustDesc.Text + "')";

                    string saveCommand2 = "insert into CustomerAccountDetails values ('" + txtCustCode.Text + "','" + txtCustCode.Text + "','" + txtCustOpeningBal.Text + "','" + txtCustCurrentBalance.Text + "')";

                    int insertedRows = dbMainClass.saveDetails(saveCommand1, saveCommand2);
                    if (insertedRows > 0)
                    {
                        btnList.Enabled = true;
                        txtCustName.Focus();
                        MessageBox.Show("Details Saved Successfully");

                    }
                    else
                    {
                        MessageBox.Show("Details Not Saved Successfully");
                    }
                }
                else if (updateCounter == 1)
                {
                    string updateCommand1 = "update  CustomerDetails  set  CustName='" + txtCustName.Text + "', CustCompName= '" + txtCustCompName.Text + "',CustAddress='" + txtCustAdd.Text + "',CustCity='" + txtCustCity.Text + "',CustState='" + txtCustState.Text + "',CustZip='" + txtCustZip.Text + "',CustCountry='" + txtCustCountry.Text + "',CustEmail='" + txtCustEmail.Text + "',CustWebAddress='" + txtCustWebSite.Text + "',CustPhone='" + txtCustPhone.Text + "', CustMobile='" + txtCustMobile.Text + "',CustFax='" + txtCustFax.Text + "',CustDesc='" + txtCustDesc.Text + "' where Custid='" + txtCustCode.Text + "'";
                    string updateCommand2 = "update   CustomerAccountDetails set CustOpeningBalance='" + txtCustOpeningBal.Text + "',CustCurrentBalance='" + txtCustCurrentBalance.Text + "' where CustId='" + txtCustCode.Text + "'";

                    int updatedRows = dbMainClass.updateDetails(updateCommand1, updateCommand2);
                    if (updatedRows > 0)
                    {
                        txtCustName.Focus();
                        MessageBox.Show("Details Updated Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Details Can not updated");
                    }
                    updateCounter = 0;
                }
                makeBlank();
                string Id = getId("CUSTOMER");
                txtCustCode.Text = Id;

            }
        }
        private string getId(string Table)
        {
            string Id = dbMainClass.getUniqueID(Table);
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

        #region  To Make all Field Blanks
        private void makeBlank()
        {

            txtCustCode.Text = "";
            txtCustName.Text = "";
            txtCustCompName.Text = "";
            txtCustAdd.Text = "";
            txtCustCity.Text = "";
            txtCustState.Text = "";
            txtCustCountry.Text = "";
            txtCustZip.Text = "";
            txtCustEmail.Text = "";
            txtCustWebSite.Text = "";
            txtCustPhone.Text = "";
            txtCustMobile.Text = "";
            txtCustFax.Text = "";
            txtCustDesc.Text = "";

            txtCustOpeningBal.Text = "0";
            txtCustCurrentBalance.Text = "0";
            txtCustCode.Text = "";
            txtCustCode.Text = "";

        }
        #endregion

        private void txtCustOpeningBal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
                else
            {
                if(e.KeyChar=='\b')
                {
                    e.Handled=false;
                }
            else
            {
                e.Handled = true;
            }

        }

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            DataTable dt = dbMainClass.getDetails("CUSTOMER");
            dataGridView1.DataSource = dt;
        }

        private void setDetails(DataGridViewCellCollection cellCollection)
        {
            try
            {
                txtCustCode.Text = cellCollection[0].Value.ToString();
                txtCustName.Text = cellCollection[1].Value.ToString();
                txtCustCompName.Text = cellCollection[2].Value.ToString();
                txtCustAdd.Text = cellCollection[3].Value.ToString();
                txtCustCity.Text = cellCollection[4].Value.ToString();
                txtCustState.Text = cellCollection[5].Value.ToString();
                txtCustCountry.Text = cellCollection[7].Value.ToString();
                txtCustZip.Text = cellCollection[6].Value.ToString();
                txtCustEmail.Text = cellCollection[8].Value.ToString();
                txtCustWebSite.Text = cellCollection[9].Value.ToString();
                txtCustPhone.Text = cellCollection[10].Value.ToString();
                txtCustMobile.Text = cellCollection[11].Value.ToString();
                txtCustFax.Text = cellCollection[12].Value.ToString();
                txtCustDesc.Text = cellCollection[13].Value.ToString();

                txtCustOpeningBal.Text = cellCollection[14].Value.ToString();
                txtCustCurrentBalance.Text = cellCollection[15].Value.ToString();
            }
            catch (Exception ex)
            {

            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewCellCollection cellCollection = dataGridView1.SelectedRows[0].Cells;
            setDetails(cellCollection);
            panel1.Visible = false;
            //panel2.Visible = false;
            //    btnVenderSave.Text = "Update";
            updateCounter = 1;
        }

        private void btnCloseAgain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
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

        private void txtCustPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
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

        private void txtCustMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
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

        private void txtCustOpeningBal_TextChanged(object sender, EventArgs e)
        {
            if (txtCustOpeningBal.Text == " ")
            {
                txtCustCurrentBalance.Text = " ";
            }
            else
            {
                string v = txtCustOpeningBal.Text;
                txtCustCurrentBalance.Text = v;
            }
        }

        private void searchcplumnname_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectquery = "select * from CustomerDetails";
          
        }

    }
}
