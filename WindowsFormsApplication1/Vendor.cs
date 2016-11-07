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
            if (string.IsNullOrEmpty(txtVenderName.Text))
            {
                MessageBox.Show("please Enter the name");
            }
            else
            {
                if (string.IsNullOrEmpty(txtCompanyName.Text))
                {
                    MessageBox.Show("please Enter the Company name");
                }
                else
                {
                    if (string.IsNullOrEmpty(txtVenderAddress.Text))
                    {
                        MessageBox.Show("please Enter the Address");
                    }
                    else
                    {

                        if (string.IsNullOrEmpty(txtVenderPhone.Text) && string.IsNullOrEmpty(txtVenderMobile.Text))
                        {
                            MessageBox.Show("please Enter the  Mobile No. ya Phone No.");
                        }
                        else
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

                            else if (updateCounter == 1)
                            {
                                string updateCommand1 = "update  VendorDetails  set  vName='" + txtVenderName.Text + "', vCompName= '" + txtCompanyName.Text + "',vAddress='" + txtVenderAddress.Text + "',vCity='" + txtVenderCity.Text + "',vState='" + txtVenderState.Text + "',vZip='" + txtVenderZip.Text + "',vCountry='" + txtVenderCountry.Text + "',vEmail='" + txtVenderEmailAddress.Text + "',vWebAddress='" + txtVenderWebSite.Text + "',vPhone='" + txtVenderPhone.Text + "', vMobile='" + txtVenderMobile.Text + "',vFax='" + txtVenderFax.Text + "',vDesc='" + txtVenderDesc.Text + "' where venderid='" + txtVenderCode.Text + "'";
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
                            string Id =dbMainClass.getUniqueID("VENDOR");
                            txtVenderCode.Text = Id;
                        }
                    }
                }
            }
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

        private void txtVenderOpeningBal_TextChanged(object sender, EventArgs e)
        {
            if (txtVenderOpeningBal.Text == "")
            {
                MessageBox.Show("please enter the opening bal1");
            }
            //else
            //{
            //    string value = txtVenderOpeningBal.Text;
            //    txtVenderCurrentBal.Text = value;
            //}
            // txtVenderOpeningBal.Text = txtVenderCurrentBal.Text;
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
            else
            {
                string value = txtVenderOpeningBal.Text;
                txtVenderCurrentBal.Text = value;
            }
        }

        private void frmVendorDetails_Load(object sender, EventArgs e)
        {
            string selectqurry = "select  vName as NAME, vCompName as COMPNAME,vAddress as ADDRESS,vCity as CITY,vState as STATE,vZip as ZIP,vCountry as COUNTRY,vEmail as EMAIL,vWebAddress as WEBADDRESS,vPhone as PHONE,vMobile as MOBILE,vFax as FAX,vDesc as DESCription from VendorDetails";
          DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            List<string> ls = new List<string>();
            DataColumnCollection d = dt.Columns;
            for (int a = 0; a < d.Count; a++)
            {
                DataColumn dc = new DataColumn();
                string b = d[a].ToString();
                ls.Add(b);
            }
            comboBox1.DataSource = ls;
            panel1.Visible = false;
            string Id = dbMainClass.getUniqueID("VENDOR");
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
            DataTable dt = dbMainClass.getDetails("VENDORDETAILS");
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

            DataGridViewCellCollection cellCollection = dataGridView1.SelectedRows[0].Cells;
            setDetails(cellCollection);
            panel1.Visible = false;
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
            updateCounter = 1;
            txtSearch.Text = "";
            comboBox1.SelectedIndex =0;
        }

        private void txtVenderOpeningBal_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            //string value = txtVenderOpeningBal.Text;
            //txtVenderCurrentBal.Text = value;
        }

        private void txtVenderPhone_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void txtVenderMobile_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = comboBox1.SelectedValue.ToString();
            string m = "v" + s;
            string selectQurry = "select * from VendorDetails where " + m + " like '" + txtSearch.Text + "%'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            dataGridView1.DataSource = dt;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
