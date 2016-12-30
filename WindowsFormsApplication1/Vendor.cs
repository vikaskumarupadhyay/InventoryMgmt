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

                        //if (string.IsNullOrEmpty(txtVenderPhone.Text) && string.IsNullOrEmpty(txtVenderMobile.Text))
                        //{
                        //    MessageBox.Show("please Enter the  Mobile No. ya Phone No.");
                        //}
                        //else
                        //{
                        //    if (!this.txtVenderEmailAddress.Text.Contains('@') || !this.txtVenderEmailAddress.Text.Contains('.'))
                        //    {
                        //        MessageBox.Show("Please Enter the Correct Email Address");
                        //    }
                        //    else
                        //    {
                                //if (!this.txtVenderWebSite.Text.Contains('@') || !this.txtVenderWebSite.Text.Contains('.') || !this.txtVenderWebSite.Text.Contains("http://"))
                                //{
                                //    MessageBox.Show("Please Enter the Correct Web Site Address");
                                ////}
                                //else
                                //{

                                    if (updateCounter == 0)
                                    {
                                        string saveCommand1 = "insert into VendorDetails values ('" + txtVenderCode.Text + "','" + txtVenderName.Text + "','" + txtCompanyName.Text + "','" + txtVenderAddress.Text + "','" + txtVenderCity.Text + "','" + txtVenderState.Text + "','" + txtVenderZip.Text + "','" + txtVenderCountry.Text + "','" + txtVenderEmailAddress.Text + "','" + txtVenderWebSite.Text + "','" + txtVenderPhone.Text + "', '" + txtVenderMobile.Text + "','" + txtVenderFax.Text + "','" + txtVenderDesc.Text + "','" + txtPanNo.Text + "','" + txtVatNo.Text + "','" + txtCstNo.Text + "','"+txtSarvice.Text+"','"+txtExcise.Text+"','"+txtGst.Text+"')";

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
                                        string updateCommand1 = "update  VendorDetails  set  vName='" + txtVenderName.Text + "', vCompName= '" + txtCompanyName.Text + "',vAddress='" + txtVenderAddress.Text + "',vCity='" + txtVenderCity.Text + "',vState='" + txtVenderState.Text + "',vZip='" + txtVenderZip.Text + "',vCountry='" + txtVenderCountry.Text + "',vEmail='" + txtVenderEmailAddress.Text + "',vWebAddress='" + txtVenderWebSite.Text + "',vPhone='" + txtVenderPhone.Text + "', vMobile='" + txtVenderMobile.Text + "',vFax='" + txtVenderFax.Text + "',vPanNo='" + txtPanNo.Text + "',vVatNo='" + txtVatNo.Text + "',vDesc='" + txtVenderDesc.Text + "',vCstNo='" + txtCstNo.Text + "',vServiceTaxRegnNo='" + txtSarvice.Text + "',vExciseRegnNo='" + txtExcise.Text + "',vGSTRegnNo='"+txtGst.Text+"'  where venderid='" + txtVenderCode.Text + "'";
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
                                    Enabled2();
                                    string Id = dbMainClass.getUniqueID("VENDOR");
                                    txtVenderCode.Text = Id;
                                //}
                            //}
                        }
                    }
                }
            txtVenderName.Focus();

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
            txtCstNo.Text = "";
            txtExcise.Text = "";
            txtGst.Text = "";
            txtSarvice.Text = "";

            txtVenderOpeningBal.Text = "0";
            txtVenderCurrentBal.Text = "0";

            txtVenderCode.Text = "";
            txtVenderCode.Text = "";
            txtVatNo.Text = "";
            txtPanNo.Text = "";
            txtCstNo.Text = "";

        }
        #endregion

        private void btnVenderClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Enabled1()
        {
            //txtVenderAddress.Enabled = false;
           // txtVenderCity.Enabled = false;
            //txtVenderCountry.Enabled = false;
            txtVenderDesc.Enabled = false;
            txtVenderName.Enabled = false;
            txtVenderOpeningBal.Enabled = false;
            txtCompanyName.Enabled = false;
            txtPanNo.Enabled = false;
            txtVatNo.Enabled = false;
            txtCstNo.Enabled = false;
            //txtVenderState.Enabled = false;
            txtVenderWebSite.Enabled = false;
           // txtVenderZip.Enabled = false;
            txtVenderEmailAddress.Enabled = false;
            btnVenderList.Enabled = false;
            txtSarvice.Enabled = false;
            txtExcise.Enabled = false;
            txtGst.Enabled = false;
        }
        private void Enabled2()
        {
            txtVenderAddress.Enabled = true;
            txtVenderCity.Enabled = true;
            txtVenderCountry.Enabled = true;
            txtVenderDesc.Enabled = true;
            txtVenderName.Enabled = true;
            txtVenderOpeningBal.Enabled = true;
            txtCompanyName.Enabled = true;
            txtPanNo.Enabled = true;
            txtVatNo.Enabled = true;
            txtCstNo.Enabled = true;
            txtVenderState.Enabled = true;
            txtVenderWebSite.Enabled = true;
            txtVenderZip.Enabled = true;
            txtVenderEmailAddress.Enabled = true;
            btnVenderList.Enabled = true;
            txtSarvice.Enabled = true;
            txtExcise.Enabled = true;
            txtGst.Enabled = true;
        }
        private void Tabindex()
        {
            txtVenderCode.TabStop = false;
            txtVenderName.TabStop = false;
            txtCompanyName.TabStop = false;
            txtVenderAddress.TabStop = false;
            txtVenderCity.TabStop = false;
            txtVenderState.TabStop = false;
            txtVenderCountry.TabStop = false;
            txtVenderZip.TabStop = false;
            txtVenderEmailAddress.TabStop = false;
            txtVenderWebSite.TabStop = false;
            txtVenderPhone.TabStop = false;
            txtVenderMobile.TabStop = false;
            txtVenderFax.TabStop = false;
            txtVenderDesc.TabStop = false;
            txtSarvice.TabStop = false;
            txtExcise.TabStop = false;
            txtCstNo.TabStop = false;
            txtGst.TabStop = false;

            txtVenderOpeningBal.TabStop = false;
            txtVenderCurrentBal.TabStop = false;
            txtPanNo.TabStop = false;
            txtVatNo.TabStop = false;
            //dataGridView1.TabStop = false;
            btnVenderSave.TabStop = false;
            btnVenderClose.TabStop = false;
            btnVenderList.TabStop = false;
           
        }
        private void Tabindex2()
        {
            //txtVenderCode.TabStop = false;
            //txtVenderName.TabStop = false;
            //txtCompanyName.TabStop = false;
            txtVenderAddress.TabStop = true;
            txtVenderCity.TabStop = true;
            txtVenderState.TabStop = true;
            txtVenderCountry.TabStop = true;
            txtVenderZip.TabStop = true;
            //txtVenderEmailAddress.TabStop = false;
            //txtVenderWebSite.TabStop = false;
            txtVenderPhone.TabStop = true;
            txtVenderMobile.TabStop = true;
            txtVenderFax.TabStop = true;
            //txtVenderDesc.TabStop = false;
            //txtSarvice.TabStop = false;
            //txtExcise.TabStop = false;
            //txtCstNo.TabStop = false;
            //txtGst.TabStop = false;

            //txtVenderOpeningBal.TabStop = false;
            //txtVenderCurrentBal.TabStop = false;
            //txtPanNo.TabStop = false;
            //txtVatNo.TabStop = false;
            //dataGridView1.TabStop = false;
            btnVenderSave.TabStop = true;
            btnVenderClose.TabStop = true;
            btnVenderList.TabStop = true;

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
            //txtVenderOpeningBal.Text = txtVenderCurrentBal.Text;
        }

        private void txtVenderOpeningBal_Enter(object sender, EventArgs e)
        {
            if (txtVenderOpeningBal.Text == "")
            {
                txtVenderOpeningBal.Text = "0";

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
            string selectqurry = "select vd.venderId as [Vender Id ],vd.vName AS Name ,vd.vCompName AS [Company Name] ,vd.vAddress AS Address,vd.vCity AS City,vd. vState AS State ,vd.vZip AS Zip ,vd.vCountry AS Country ,vd.vEmail AS[E-Mail ],vd. vWebAddress AS[Web Address],vd.vPhone AS Phone ,vd.vMobile AS Mobile ,vd.vFax AS Fax ,vd.vPanNo as[PAN No],vd.vVatNo as [VAT No],vd.vCstNo as[CST No],vd.vServiceTaxRegnNo as [Service Tax Regn.No],vd.vExciseRegnNo as [Excise Regn.No],vd.vGSTRegnNo as[GST Regn.No],vd.vDesc AS Description,vad.vOpeningBalance AS [Opening Balance] , vad.vCurrentBalance AS [Current Balance] from  vendorDetails vd join    VendorAccountDetails  vad on vd.venderID=vad.venderID";
            string selectqurryForActualColumnName = "select top 1 vd.venderId ,vd.vName  ,vd.vCompName  ,vd.vAddress ,vd.vCity,vd. vState  ,vd.vZip  ,vd.vCountry  ,vd.vEmail ,vd. vWebAddress ,vd.vPhone  ,vd.vMobile ,vd.vFax ,vd.vPanNo ,vd.vVatNo ,vd.vCstNo,vd.vServiceTaxRegnNo ,vd.vExciseRegnNo ,vd.vGSTRegnNo ,vd.vDesc,vad.vOpeningBalance, vad.vCurrentBalance  from  vendorDetails vd join    VendorAccountDetails  vad on vd.venderID=vad.venderID";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            DataTable dtOnlyColumnName = dbMainClass.getDetailByQuery(selectqurryForActualColumnName);
            DataTable customDataTable = new DataTable();
            customDataTable.Columns.Add("ActualTableColumnName");
            customDataTable.Columns.Add("AliasTableColumnName");
            //List<string> ls = new List<string>();
            DataColumnCollection d = dt.Columns;
            DataColumnCollection dataColumnForName = dtOnlyColumnName.Columns;
            for (int a = 1; a < d.Count; a++)
            {
                //DataColumn dc = new DataColumn();
                string b = d[a].ToString();
                string actualColumnName=dataColumnForName[a].ToString();
                DataRow dr = customDataTable.NewRow();
                dr["ActualTableColumnName"] = actualColumnName;
                dr["AliasTableColumnName"] = b;
                customDataTable.Rows.Add(dr);
                //  ls.Add(b);
            }

            comboBox1.DataSource = customDataTable;
            comboBox1.ValueMember = "ActualTableColumnName";
            comboBox1.DisplayMember = "AliasTableColumnName";

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
            Tabindex();
            comboBox1.Focus();
            panel2.TabStop = false;
            panel2.TabIndex = 26;
            //dataGridView1.TabIndex = 26;
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
                txtVenderDesc.Text = cellCollection[19].Value.ToString();
                txtSarvice.Text = cellCollection[15].Value.ToString();
                txtExcise.Text = cellCollection[16].Value.ToString();
                txtCstNo.Text = cellCollection[17].Value.ToString();
                txtGst.Text = cellCollection[18].Value.ToString();

                txtVenderOpeningBal.Text = cellCollection[20].Value.ToString();
                txtVenderCurrentBal.Text = cellCollection[21].Value.ToString();
                txtPanNo.Text = cellCollection[13].Value.ToString();
                txtVatNo.Text = cellCollection[14].Value.ToString();
               // txtCstNo.Text = cellCollection[15].Value.ToString();
            }
            catch (Exception ex)
            {

            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            DataGridViewCellCollection cellCollection = dataGridView1.Rows[0].Cells;
            setDetails(cellCollection);
            panel1.Visible = false;
            updateCounter = 1;
            Enabled1();
            txtVenderAddress.Focus();
            Tabindex2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection cellCollection = dataGridView1.Rows[e.RowIndex].Cells;
            setDetails(cellCollection);
            panel1.Visible = false;
            updateCounter = 1;
            txtSearch.Text = "";
            comboBox1.SelectedIndex = 0;
            Enabled1();
        }

        private void txtVenderOpeningBal_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            string value = txtVenderOpeningBal.Text;
            txtVenderCurrentBal.Text = value;
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
            //string m = "v" + s;
            string selectQurry = "select vd.venderId as [Vender Id ],vd.vName AS Name ,vd.vCompName AS [Company Name] ,vd.vAddress AS Address,vd.vCity AS City,vd. vState AS State ,vd.vZip AS Zip ,vd.vCountry AS Country ,vd.vEmail AS[E-Mail ],vd. vWebAddress AS[Web Address],vd.vPhone AS Phone ,vd.vMobile AS Mobile ,vd.vFax AS Fax ,vd.vPanNo as[PAN No],vd.vVatNo as [VAT No],vd.vCstNo as[CST No],vd.vServiceTaxRegnNo as [Service Tax Regn.No],vd.vExciseRegnNo as [Excise Regn.No],vd.vGSTRegnNo as[GST Regn.No],vd.vDesc AS Description,vad.vOpeningBalance AS [Opening Balance] , vad.vCurrentBalance AS [Current Balance] from  vendorDetails vd join    VendorAccountDetails  vad on vd.venderID=vad.venderID where " + s + " like '" + txtSearch.Text + "%'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            dataGridView1.DataSource = dt;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPanNo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsLetterOrDigit(e.KeyChar))
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

        private void txtPanNo_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtVenderOpeningBal_Click(object sender, EventArgs e)
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

        private void txtVenderCurrentBal_Click(object sender, EventArgs e)
        {
            //txtVenderCurrentBal.Text = "";
        }

        private void txtVenderCurrentBal_TextChanged(object sender, EventArgs e)
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

        private void txtVenderEmailAddress_Leave(object sender, EventArgs e)
        {
            string email = txtVenderEmailAddress.Text;
            if ((email.LastIndexOf("@") > -1) && (email.LastIndexOf(".") > -1) || string.IsNullOrEmpty(email))
            {
                //MessageBox.Show("Please Enter the Correct Email Address");
            }
            else
            {
                txtVenderEmailAddress.Focus();
                MessageBox.Show("Please Enter the Correct Email Address");
            }
        }

        private void txtVenderWebSite_Leave(object sender, EventArgs e)
        {
            string WebSite = txtVenderWebSite.Text;
            if ((WebSite.LastIndexOf("www") > -1) && (WebSite.LastIndexOf(".") > -1) && (WebSite.LastIndexOf("http://") > -1)|| string.IsNullOrEmpty(WebSite))
            {
                //MessageBox.Show("Please Enter the Correct Email Address");
            }
            else
            {
                txtVenderWebSite.Focus();
                MessageBox.Show("Please Enter the Correct Web Site Address");
            }
        }

        private void txtTinNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVenderMobile_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                //DataGridViewCellCollection cellCollection = dataGridView1.Rows[e.RowIndex].Cells;
                //setDetails(cellCollection);
                //panel1.Visible = false;
                //updateCounter = 1;
                //txtSearch.Text = "";
                //comboBox1.SelectedIndex = 0;
                //Enabled1();

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int currrentIndex = dataGridView1.CurrentRow.Index;
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataGridViewCellCollection cellCollection = dataGridView1.Rows[currrentIndex-1].Cells;
                setDetails(cellCollection);
                panel1.Visible = false;
                updateCounter = 1;
                txtSearch.Text = "";
                comboBox1.SelectedIndex = 0;
                Enabled1();
            }
        }

    }
}
