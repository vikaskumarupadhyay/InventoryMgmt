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
        private void Customer_Load(object sender, EventArgs e)
        {

            //DataTable dt = dbMainClass.getDetails("CustomerDetails");
            List<string> ds = new List<string>();
            ds.Add("Name");
            ds.Add("COMPNAME");
            ds.Add("ADDRESS");
            ds.Add("CITY");
            ds.Add("STATE");
            ds.Add("ZIP");
            ds.Add("COUNTRY");
            ds.Add("EMAIL");
            ds.Add("WEBADDRESS");
            ds.Add("PHONE");
            ds.Add("MOBILE");
            ds.Add("FAX");
            ds.Add("DESC");
            ds.Add("OPENINGBALANCE");
            ds.Add("CURRENTBALANCE");
            comserchvalue.DataSource = ds;
            
            panel1.Visible = false;
            string Id = dbMainClass.getUniqueID("Customerdetail");
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
     
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("please enter your address");
            }
            else
            {
                if (string.IsNullOrEmpty(txtTXTPHONE.Text) && string.IsNullOrEmpty(txtMOBILE.Text))
                {
                    MessageBox.Show("please enter your phone no and mo no");
                }
                if (updateCounter == 0)
                {
                    string saveCommand1 = "insert into CustomerDetails values ('" + txtCustCode.Text + "','" + txtName.Text + "','" + txtCompnyName.Text + "','" + txtAddress.Text + "','" + txtCity.Text + "','" + txtState.Text + "','" + txtZIP.Text + "','" + txtCustCountry.Text + "','" + txtEMAILADDRESS.Text + "','" + txtWEBSITE.Text + "','" + txtTXTPHONE.Text + "', '" + txtMOBILE.Text + "','" + txtFAX.Text + "','" + txtDESCRIPTION.Text + "')";

                    string saveCommand2 = "insert into CustomerAccountDetails values ('" + txtCustCode.Text + "','" + txtCustCode.Text + "','" + txtOPENINGBALANCE.Text + "','" + txtCURRENTBALANCE.Text + "')";

                    int insertedRows = dbMainClass.saveDetails(saveCommand1, saveCommand2);
                    if (insertedRows > 0)
                    {
                        btnList.Enabled = true;
                        txtName.Focus();
                        MessageBox.Show("Details Saved Successfully");

                    }
                    else
                    {
                        MessageBox.Show("Details Not Saved Successfully");
                    }
                }
                else if (updateCounter == 1)
                {
                    string updateCommand1 = "update  CustomerDetails  set CustAddress='" + txtAddress.Text + "',CustPhone='" + txtTXTPHONE.Text + "', CustMobile='" + txtMOBILE.Text + "'";// CustName='" + txtName.Text + "', CustCompName= '" + txtCompnyName.Text + "',CustAddress='" + txtAddress.Text + "',CustCity='" + txtCity.Text + "',CustState='" + txtState.Text + "',CustZip='" + txtZIP.Text + "',CustCountry='" + txtCustCountry.Text + "',CustEmail='" + txtEMAILADDRESS.Text + "',CustWebAddress='" + txtWEBSITE.Text + "',CustPhone='" + txtTXTPHONE.Text + "', CustMobile='" + txtMOBILE.Text + "',CustFax='" + txtFAX.Text + "',CustDesc='" + txtDESCRIPTION.Text + "' where Custid='" + txtCustCode.Text + "'";
                    string updateCommand2 = "update   CustomerAccountDetails setCustId='" + txtCustCode.Text + "'"; //CustOpeningBalance='" + txtOPENINGBALANCE.Text + "',CustCurrentBalance='" + txtCURRENTBALANCE.Text + "' where CustId='" + txtCustCode.Text + "'";

                    int updatedRows = dbMainClass.updateDetails(updateCommand1, updateCommand2);
                    if (updatedRows > 0)
                    {
                        txtName.Focus();
                        MessageBox.Show("Details Updated Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Details Can not updated");
                    }
                    updateCounter = 0;
                }
                makeblank();
                string Id = dbMainClass.getUniqueID("CUSTOMER");
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
            txtName.Text = "";
            txtCompnyName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtCustCountry.Text = "";
            txtZIP.Text = "";
            txtEMAILADDRESS.Text = "";
            txtWEBSITE.Text = "";
            txtTXTPHONE.Text = "";
            txtMOBILE.Text = "";
            txtFAX.Text = "";
            txtDESCRIPTION.Text = "";

            txtOPENINGBALANCE.Text = "0";
            txtCURRENTBALANCE.Text = "0";
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
                txtName.Text = cellCollection[1].Value.ToString();
                txtCompnyName.Text = cellCollection[2].Value.ToString();
                txtAddress.Text = cellCollection[3].Value.ToString();
                txtCity.Text = cellCollection[4].Value.ToString();
                txtState.Text = cellCollection[5].Value.ToString();
                txtZIP.Text = cellCollection[6].Value.ToString();
                txtCustCountry.Text = cellCollection[7].Value.ToString();
                txtEMAILADDRESS.Text = cellCollection[8].Value.ToString();
                txtWEBSITE.Text = cellCollection[9].Value.ToString();
                txtTXTPHONE.Text = cellCollection[10].Value.ToString();
                txtMOBILE.Text = cellCollection[11].Value.ToString();
                txtFAX.Text = cellCollection[12].Value.ToString();
                txtDESCRIPTION.Text = cellCollection[13].Value.ToString();
                txtOPENINGBALANCE.Text = cellCollection[14].Value.ToString();
                txtCURRENTBALANCE.Text = cellCollection[15].Value.ToString();
            }
            catch (Exception ex)
            {

            }

        }

        private void btnCloseAgain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
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
            if (txtOPENINGBALANCE.Text == " ")
            {
                txtCURRENTBALANCE.Text = " ";
            }
            else
            {
                string v = txtOPENINGBALANCE.Text;
                txtCURRENTBALANCE.Text = v;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           string s= comserchvalue.SelectedValue.ToString();
           string val = "Cust"+s;
           string selectQuery = "select cd.custid,cd.CustName,cd.CustCompName,cd.CustAddress,cd.CustCity,cd.CustState,cd.CustZip,cd.CustCountry,cd.CustEmail,cd.CustWebAddress,cd.CustPhone,cd.CustMobile,cd.CustFax,cd.CustDesc,cad.CustOpeningBalance,cad.CustCurrentBalance from CustomerDetails cd join CustomerAccountDetails cad on cd.CustId=cad.CustId  where " +val + " like '" + textBox1.Text + "%'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQuery);
            dataGridView1.DataSource = dt;

        }

        private void butaddrecord_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void butupdate_Click(object sender, EventArgs e)
        {
            DataGridViewCellCollection cellcollection = dataGridView1.Rows[0].Cells;
            setDetails(cellcollection);
            panel1.Visible = false;
            updateCounter = 1;
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = "";
            comserchvalue.SelectedIndex = 0;
            DataGridViewCellCollection cellCollection = dataGridView1.Rows[e.RowIndex].Cells;
            setDetails(cellCollection);
            panel1.Visible = false;
            updateCounter = 1;
           
        }

        private void butclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void makeblank()
        {

            txtCustCode.Text = "";
            txtName.Text = "";
            txtCompnyName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtCustCountry.Text = "";
            txtZIP.Text = "";
            txtEMAILADDRESS.Text = "";
            txtWEBSITE.Text = "";
            txtTXTPHONE.Text = "";
            txtMOBILE.Text = "";
            txtFAX.Text = "";
            txtDESCRIPTION.Text= "";

            txtOPENINGBALANCE.Text = "0";
            txtCURRENTBALANCE.Text= "0";

            txtCustCode.Text = "";
            txtCustCode.Text= "";

        }


      

    }
}
