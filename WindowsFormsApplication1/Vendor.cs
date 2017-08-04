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
using System .IO;
using ExcelLibrary.SpreadSheet;


namespace WindowsFormsApplication1
{
    public partial class frmVendorDetails : Form
    {
        int counter = 0;

        public frmVendorDetails()
        {
            InitializeComponent();
        }
        public frmVendorDetails(int counter1)
        {
            counter = counter1;
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
            Save_Details(); 
        }

        private void Save_Details()
        {
            if (string.IsNullOrEmpty(txtVenderName.Text))
            {
                MessageBox.Show("Please enter the vendor name!");
            }
            else
            {
                if (string.IsNullOrEmpty(txtCompanyName.Text))
                {
                    MessageBox.Show("Please enter the company name!");
                }
                else
                {
                    if (string.IsNullOrEmpty(txtVenderAddress.Text))
                    {
                        MessageBox.Show("Please enter the address!");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtVenderCity.Text))
                        {
                            MessageBox.Show("Please enter city!");
                        }
                        else
                        {

                            if (string.IsNullOrEmpty(txtVenderPhone.Text) && string.IsNullOrEmpty(txtVenderMobile.Text))
                            {
                                MessageBox.Show("please Enter the  Mobile No. ya Phone No.");
                            }
                            else
                            {
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

                                string saveCommand1 = "insert into VendorDetails values ('" + txtVenderCode.Text + "','" + txtVenderName.Text + "','" + txtCompanyName.Text + "','" + txtVenderAddress.Text + "','" + txtVenderCity.Text + "','" + cmbState.SelectedItem.ToString() + "','" + txtVenderZip.Text + "','" + txtVenderCountry.Text + "','" + txtVenderEmailAddress.Text + "','" + txtVenderWebSite.Text + "','" + txtVenderPhone.Text + "', '" + txtVenderMobile.Text + "','" + txtVenderFax.Text + "','" + txtVenderDesc.Text + "','" + txtPanNo.Text + "','" + txtGst.Text + "')";

                                string saveCommand2 = "insert into VendorAccountDetails values ('" + txtVenderCode.Text + "','" + txtVenderCode.Text + "','" + txtVenderOpeningBal.Text + "','" + txtVenderCurrentBal.Text + "')";

                                int insertedRows = dbMainClass.saveDetails(saveCommand1, saveCommand2);
                                if (insertedRows > 0)
                                {
                                    btnVenderList.Enabled = true;
                                    MessageBox.Show("Details saved successfully");
                                    txtVenderName.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Details Not Saved Successfully");
                                }

                            }

                            else if (updateCounter == 1)
                            {
                                string updateCommand1 = "update  VendorDetails  set  vName='" + txtVenderName.Text + "', vCompName= '" + txtCompanyName.Text + "',vAddress='" + txtVenderAddress.Text + "',vCity='" + txtVenderCity.Text + "',vState='" + cmbState.SelectedItem.ToString() + "',vZip='" + txtVenderZip.Text + "',vCountry='" + txtVenderCountry.Text + "',vEmail='" + txtVenderEmailAddress.Text + "',vWebAddress='" + txtVenderWebSite.Text + "',vPhone='" + txtVenderPhone.Text + "', vMobile='" + txtVenderMobile.Text + "',vFax='" + txtVenderFax.Text + "',vPanNo='" + txtPanNo.Text + "',vGSTNo='" + txtGst.Text + "',vDesc='" + txtVenderDesc.Text + "'  where venderid='" + txtVenderCode.Text + "'";
                                string updateCommand2 = "update   VendorAccountDetails set vOpeningBalance='" + txtVenderOpeningBal.Text + "',vCurrentBalance='" + txtVenderCurrentBal.Text + "' where venderId='" + txtVenderCode.Text + "'";

                                int updatedRows = dbMainClass.updateDetails(updateCommand1, updateCommand2);
                                if (updatedRows > 0)
                                {
                                    

                                    MessageBox.Show("Details updated successfully!");
                                    txtVenderName.Focus();
                                    txtVenderOpeningBal.ReadOnly = false;

                                }
                                else
                                {
                                    MessageBox.Show("Details Can not updated");
                                }
                                updateCounter = 0;
                                Enabled2();
                            }
                            makeBlank();
                            //Enabled2();
                            Tabindex1();
                            string Id = dbMainClass.getUniqueID("VENDOR");
                            txtVenderCode.Text = Id;
                            //}
                          }
                        }
                    }
                }
                txtVenderName.Focus();


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
            cmbState.SelectedIndex = 0;
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
            txtGst.Text = "";
            txtPanNo.Text = "";
           
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
            txtGst.Enabled = false;
           // txtCstNo.Enabled = false;
            //txtVenderState.Enabled = false;
            txtVenderWebSite.Enabled = false;
           // txtVenderZip.Enabled = false;
            txtVenderEmailAddress.Enabled = false;
            btnVenderList.Enabled = false;
            //txtSarvice.Enabled = false;
            //txtExcise.Enabled = false;
            //txtGst.Enabled = false;
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
            txtGst.Enabled = true;
            //txtCstNo.Enabled = true;
            cmbState.Enabled = true;
            txtVenderWebSite.Enabled = true;
            txtVenderZip.Enabled = true;
            txtVenderEmailAddress.Enabled = true;
            btnVenderList.Enabled = true;
            //txtSarvice.Enabled = true;
           // txtExcise.Enabled = true;
            //txtGst.Enabled = true;
        }
        private void Tabindex()
        {
            txtVenderCode.TabStop = false;
            txtVenderName.TabStop = false;
            txtCompanyName.TabStop = false;
            txtVenderAddress.TabStop = false;
            txtVenderCity.TabStop = false;
            cmbState.TabStop = false;
            txtVenderCountry.TabStop = false;
            txtVenderZip.TabStop = false;
            txtVenderEmailAddress.TabStop = false;
            txtVenderWebSite.TabStop = false;
            txtVenderPhone.TabStop = false;
            txtVenderMobile.TabStop = false;
            txtVenderFax.TabStop = false;
            txtVenderDesc.TabStop = false;
          
            txtVenderOpeningBal.TabStop = false;
            txtVenderCurrentBal.TabStop = false;
            txtPanNo.TabStop = false;
            txtGst.TabStop = false;
            //dataGridView1.TabStop = false;
            btnVenderSave.TabStop = false;
            btnVenderClose.TabStop = false;
            btnVenderList.TabStop = false;
           
        }
        private void Tabindex2()
        {
            btnVenderList.Enabled = false;
            //txtVenderCode.TabStop = false;
            txtVenderName.TabStop = true;
            txtCompanyName.TabStop = true;
            txtVenderAddress.TabStop = true;
            txtVenderCity.TabStop = true;
            cmbState.TabStop = true;
            txtVenderCountry.TabStop = true;
            txtVenderZip.TabStop = true;
            txtVenderEmailAddress.TabStop = true;
            txtVenderWebSite.TabStop = true;
            txtVenderPhone.TabStop = true;
            txtVenderMobile.TabStop = true;
            txtVenderFax.TabStop = true;
            txtVenderDesc.TabStop = true;
            

            //txtVenderOpeningBal.TabStop = false;
            //txtVenderCurrentBal.TabStop = false;
            txtPanNo.TabStop = true;
            txtGst.TabStop = true;
            //dataGridView1.TabStop = false;
            btnVenderSave.TabStop = true;
            btnVenderClose.TabStop = true;
            btnVenderList.TabStop = true;


        }
        private void Tabindex1()
        {
            txtVenderCode.TabStop = true;
            txtVenderName.TabStop = true;
            txtCompanyName.TabStop = true;
            txtVenderAddress.TabStop = true;
            txtVenderCity.TabStop = true;
            cmbState.TabStop = true;
            txtVenderCountry.TabStop = true;
            txtVenderZip.TabStop = true;
            txtVenderEmailAddress.TabStop = true;
            txtVenderWebSite.TabStop = true;
            txtVenderPhone.TabStop = true;
            txtVenderMobile.TabStop = true;
            txtVenderFax.TabStop = true;
            txtVenderDesc.TabStop = true;
           

            txtVenderOpeningBal.TabStop = true;
            txtVenderCurrentBal.TabStop = false;
            txtPanNo.TabStop = true;
            txtGst.TabStop = true;
            //dataGridView1.TabStop = false;
            btnVenderSave.TabStop = true;
            btnVenderClose.TabStop = true;
            btnVenderList.TabStop = true;
           // btnVenderList.Enabled = false;

        }

        private void txtVenderOpeningBal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
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
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

        //}
/*
        private void txtVenderOpeningBal_TextChanged(object sender, EventArgs e)
        {

            if (txtVenderOpeningBal.Text == "")
            {
                txtVenderCurrentBal.Text = "";
            }
            else
            {
                string value = txtVenderOpeningBal.Text;
                txtVenderCurrentBal.Text = value;
            }
           // txtVenderOpeningBal.Text = txtVenderCurrentBal.Text;
        }

        private void txtVenderOpeningBal_Enter(object sender, EventArgs e)
        {
            //if (txtVenderOpeningBal.Text == "")
            //{
            //    txtVenderOpeningBal.Text = "0";

            //}
           
        }

        private void txtVenderOpeningBal_Leave(object sender, EventArgs e)
        {
            decimal x;
            if (decimal.TryParse(txtVenderOpeningBal.Text, out x))
            {
                if (txtVenderOpeningBal.Text.IndexOf('.') != -1 && txtVenderOpeningBal.Text.Split('.')[1].Length > 2)
                {
                    MessageBox.Show("The maximum decimal points are 2!");
                    txtVenderOpeningBal.Focus();
                }
                else txtVenderOpeningBal.Text = x.ToString("0.00");
            }
            else
            {
                txtVenderOpeningBal.Text = "0.00";
                //MessageBox.Show("Data invalid!");
                //txtVenderOpeningBal.Focus();
            }
            /*if (txtVenderOpeningBal.Text == "")
            {
                txtVenderOpeningBal.Text = "0";

            }
            else
            {

                string value = txtVenderOpeningBal.Text;
                txtVenderCurrentBal.Text = value;
            }*/
        }

        private void frmVendorDetails_Load(object sender, EventArgs e)
        {
            cmbState.SelectedIndex = 0;
            if (counter == 1)
            {
                //panel2.Visible = true;
                panel1.Visible = true;
                Tabindex();
                panel2.TabStop = false;
               panel2.TabIndex = 26;
                comboBox1.Focus();
              // comboBox1.TabIndex = 0;
               // txtSearch.TabIndex = 1;
               // dataGridView1.TabIndex = 2;
                //btnUpdate.TabIndex = 3;
                //button1.TabIndex = 4;
                //butprint.TabIndex = 5;
                //button2.TabIndex = 6;
                //button3.TabIndex = 7;
            
            }
            else if (counter == 0)
            {
                //panel2.Visible = false;
                panel1.Visible = false;
            }
            string selectqurry = "select vd.venderId as [Vendor ID ],vd.vName AS [Vendor Name] ,vd.vCompName AS [Company Name] ,vd.vAddress AS Address,vd.vCity AS City,vd. vState AS State ,vd.vZip AS Zip ,vd.vCountry AS Country ,vd.vEmail AS[E-Mail ],vd. vWebAddress AS[Web Address],vd.vPhone AS Phone ,vd.vMobile AS Mobile ,vd.vFax AS Fax ,vd.vPanNo as[PAN NO],vd.vGSTNo as [GST NO],vd.vDesc AS [Description],vad.vOpeningBalance AS [Opening Balance] , vad.vCurrentBalance AS [Current Balance] from  vendorDetails vd join    VendorAccountDetails  vad on vd.venderID=vad.venderID";
                string selectqurryForActualColumnName = "select top 1 vd.venderId ,vd.vName  ,vd.vCompName  ,vd.vAddress ,vd.vCity,vd. vState  ,vd.vZip  ,vd.vCountry  ,vd.vEmail ,vd. vWebAddress ,vd.vPhone  ,vd.vMobile ,vd.vFax ,vd.vPanNo ,vd.vGSTNo ,vd.vDesc,vad.vOpeningBalance, vad.vCurrentBalance  from  vendorDetails vd join    VendorAccountDetails  vad on vd.venderID=vad.venderID";
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
            dataGridView1.DataSource = dt;

            //btnVenderList.Enabled = false;
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
            comboBox1.SelectedIndex = 0;
            txtSearch.Text = "";
            panel1.Visible = true;
            DataTable dt = dbMainClass.getDetails("VENDORDETAILS");
            dataGridView1.DataSource = dt;
            Tabindex();
            txtSearch.Focus();
            panel2.TabStop = false;
            panel2.TabIndex = 26;
            btnUpdate.TabIndex = 4;
            button1.TabIndex = 5;
            butprint.TabIndex = 6;
            button2.TabIndex = 7;
            button3.TabIndex = 8;
            //dataGridView1.TabIndex = 26;
            Enabled2();
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
                cmbState.Text = cellCollection[5].Value.ToString();
                txtVenderCountry.Text = cellCollection[7].Value.ToString();
                txtVenderZip.Text = cellCollection[6].Value.ToString();
                txtVenderEmailAddress.Text = cellCollection[8].Value.ToString();
                txtVenderWebSite.Text = cellCollection[9].Value.ToString();
                txtVenderPhone.Text = cellCollection[10].Value.ToString();
                txtVenderMobile.Text = cellCollection[11].Value.ToString();
                txtVenderFax.Text = cellCollection[12].Value.ToString();
                txtVenderDesc.Text = cellCollection[15].Value.ToString();
                //txtSarvice.Text = cellCollection[16].Value.ToString();
                //txtExcise.Text = cellCollection[17].Value.ToString();
                //txtCstNo.Text = cellCollection[15].Value.ToString();
                //txtGst.Text = cellCollection[18].Value.ToString();

                txtVenderOpeningBal.Text = cellCollection[16].Value.ToString();
                txtVenderCurrentBal.Text = cellCollection[17].Value.ToString();
                txtPanNo.Text = cellCollection[13].Value.ToString();
                txtGst.Text = cellCollection[14].Value.ToString();

               // txtCstNo.Text = cellCollection[15].Value.ToString();
            }
            catch (Exception ex)
            {

            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //txtSearch.Text = "";
            DataGridViewCellCollection cellCollection = dataGridView1.SelectedRows[0].Cells;

                if ((String)dataGridView1.SelectedRows[0].Cells[0].Value == null)
                        {
                            //panel1.Visible = true;
                            MessageBox.Show("Select proper row ! ");
                            dataGridView1.Focus();

                        }
                        else
                        {
                            setDetails(cellCollection);
                            panel1.Visible = false;

                            updateCounter = 1;
                            btnVenderList.Enabled = false;
                            txtVenderOpeningBal.ReadOnly = true;
                            // Enabled1();
                            txtVenderName.Focus();
                            //txtVenderAddress.Focus();
                            Tabindex2();
                            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            Tabindex1();
            txtVenderName.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            Tabindex1();
            txtVenderName.Focus();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection cellCollection = dataGridView1.SelectedRows[0].Cells;
            if (!string.IsNullOrEmpty(cellCollection[0].Value.ToString()))
            {
                setDetails(cellCollection);
                panel1.Visible = false;
                updateCounter = 1;
                //txtVenderAddress.Focus();
                txtVenderName.Focus();
                txtVenderOpeningBal.ReadOnly = true;
                Tabindex2();
                //txtSearch.Text = "";
                //comboBox1.SelectedIndex = 0;
                //Enabled1();
               
            }
            else
            {
                MessageBox.Show("Select proper row ! ");
                dataGridView1.Focus(); 
            }
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
                    //MessageBox.Show("Plese enter numeric value!");
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
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = comboBox1.SelectedValue.ToString();
            //string m = "v" + s;
            string selectQurry = "select vd.venderId as [Vendor ID ],vd.vName AS [Vendor Name] ,vd.vCompName AS [Company Name] ,vd.vAddress AS Address,vd.vCity AS City,vd. vState AS State ,vd.vZip AS Zip ,vd.vCountry AS Country ,vd.vEmail AS[E-Mail ],vd. vWebAddress AS[Web Address],vd.vPhone AS Phone ,vd.vMobile AS Mobile ,vd.vFax AS Fax ,vd.vPanNo as[PAN NO],vd.vGSTNo as [GST NO],vd.vDesc AS Description,vad.vOpeningBalance AS [Opening Balance] , vad.vCurrentBalance AS [Current Balance] from  vendorDetails vd join    VendorAccountDetails  vad on vd.venderID=vad.venderID where " + s + " like '" + txtSearch.Text + "%'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            dataGridView1.DataSource = dt;
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


        private void txtVenderOpeningBal_Click(object sender, EventArgs e)
        {
            //txtVenderOpeningBal.Text = string.Empty;
            //txtVenderOpeningBal.Text = "";
            ////if (txtVenderOpeningBal.Text == "")
            ////{
            ////   // txtVenderOpeningBal.Text = "0";
            ////}
            ////else
            ////{
            ////    string value = txtVenderOpeningBal.Text;
            ////    txtVenderCurrentBal.Text = value;
            //}
        }
        private void txtVenderCurrentBal_TextChanged(object sender, EventArgs e)
        {
            //if (txtVenderOpeningBal.Text == "")
            //{
            //    txtVenderCurrentBal.Text = "0";
            //}
            //else
            //{
            //    string value = txtVenderOpeningBal.Text;
            //    txtVenderCurrentBal.Text = value;
            //}
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
                MessageBox.Show("Please enter valid email address!");
            }
        }

        private void txtVenderWebSite_Leave(object sender, EventArgs e)
        {
            string WebSite = txtVenderWebSite.Text;
            if ((WebSite.LastIndexOf("www") > -1) && (WebSite.LastIndexOf(".") > -1) && (WebSite.LastIndexOf("http://") > -1) && (WebSite.LastIndexOf("com") > -1) || string.IsNullOrEmpty(WebSite))
            {
                //MessageBox.Show("Please Enter the Correct Email Address");
            }
            else
            {
                txtVenderWebSite.Focus();
                MessageBox.Show("Please enter valid web address!");
            }
        }


        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int currentIndex = dataGridView1.CurrentRow.Index;
            if (e.KeyChar == (char)Keys.Enter)
            {

                //if (dataGridView1.RowCount == currentIndex + 1)
                //    currentIndex = currentIndex + 1;

                DataGridViewCellCollection cellCollection = dataGridView1.Rows[currentIndex-1].Cells;
                if (!string.IsNullOrEmpty(cellCollection[0].Value.ToString()))
                {
                    setDetails(cellCollection);
                    panel1.Visible = false;
                    updateCounter = 1;
                    txtSearch.Text = "";
                    comboBox1.SelectedIndex = 0;
                    //Enabled1();
                    //txtVenderAddress.Focus();
                    txtVenderOpeningBal.ReadOnly = true;
                    txtVenderName.Focus();
                    Tabindex2();
                }
            }
        }

        private void butprint_Click(object sender, EventArgs e)
        {
            DataGridViewRowCollection RowCollection = dataGridView1.Rows;
            List<printclass> classCollection = new List<printclass>();
            for (int a = 0; a < RowCollection.Count; a++)
            {

                DataGridViewRow currentRow = RowCollection[a];
                DataGridViewCellCollection cellCollection = currentRow.Cells;
                printclass classObject = new printclass();
                classObject.Name = cellCollection[1].Value.ToString();
                classObject.Address = cellCollection[3].Value.ToString();
                classObject.Phone = cellCollection[11].Value.ToString();
                classObject.Email = cellCollection[8].Value.ToString();
                classObject.OpningBalnce = cellCollection[20].Value.ToString();
                classObject.CurrentBalnce = cellCollection[21].Value.ToString();
                classCollection.Add(classObject);
            }
            VendorPrint vp = new VendorPrint(classCollection,1);
            vp.Show();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void txtVenderOpeningBal_TextChanged_1(object sender, EventArgs e)
        {
            if (txtVenderOpeningBal.Text == "")
            {
                txtVenderCurrentBal.Text = "0.00";
            }
            else
            {
                string value = txtVenderOpeningBal.Text;
                txtVenderCurrentBal.Text = value;
            }
        }

        private void txtVenderOpeningBal_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtVenderOpeningBal.Text == "0.00")
            {
                txtVenderOpeningBal.Text = "";
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.AllowUserToAddRows == true)
            {
                dataGridView1.AllowUserToAddRows = false;
            }
            string FileName = "";
            SaveFileDialog openFileDialog1 = new SaveFileDialog();
           //FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();
            openFileDialog1.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
            openFileDialog1.FileName = "Vendor Details";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog1.FileName;

                // }

                //DataGridViewColumnCollection column = dataGridView1.Columns;
                int cout = 0;
                int rowCoumt = 0;
                // column1 = dc.Name.ToString();
                string file = FileName;//+ ".xls"; //System.Configuration.ConfigurationManager.AppSettings["ExcelFilePath1"] + FolderName + "newdoc.xls";
                Workbook workbook = new Workbook();
                Worksheet worksheet = new Worksheet("First Sheet");

                foreach (DataGridViewColumn dc in dataGridView1.Columns)
                {

                    worksheet.Cells[rowCoumt, cout] = new Cell(dc.Name);
                    cout++;

                }

                //foreach (DataGridViewRow row in dataGridView1.Rows) { }
                DataGridViewRowCollection rowcollection = dataGridView1.Rows;

                int rowindex = 1;
                //int countindex = 0;
                for (int a = 0; a < rowcollection.Count; a++)
                {
                    DataGridViewRow currentrow = rowcollection[a];
                    DataGridViewCellCollection cellcollecton = currentrow.Cells;
                    int countrow = 0;

                    for (int b = 0; b < currentrow.Cells.Count; b++)
                    {
                        worksheet.Cells[rowindex, countrow] = new Cell(currentrow.Cells[b].Value.ToString());
                        // countindex++;
                        countrow++;
                    }
                    // name = cellcollecton[0].Value.ToString() + " , " + cellcollecton[1].Value.ToString() + " , " + cellcollecton[2].Value.ToString() + " , " + cellcollecton[3].Value.ToString() + " , " + cellcollecton[4].Value.ToString() + " , " + cellcollecton[5].Value.ToString() + "  , " + cellcollecton[6].Value.ToString() + " , " + cellcollecton[7].Value.ToString() + " , " + cellcollecton[8].Value.ToString() + " , " + cellcollecton[9].Value.ToString() + " , " + cellcollecton[10].Value.ToString() + " , " + cellcollecton[11].Value.ToString() + " , " + cellcollecton[12].Value.ToString() + ", " + cellcollecton[13].Value.ToString() + " , " + cellcollecton[14].Value.ToString() + " , " + cellcollecton[15].Value.ToString();
                    rowindex++;
                }

                workbook.Worksheets.Add(worksheet);
                workbook.Save(file);
                dataGridView1.AllowUserToAddRows = true;
            }
            else
            {
                dataGridView1.AllowUserToAddRows = true;
            }
               
        }

        private void frmVendorDetails_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Control && e.KeyCode.ToString() == "S")
            {

                Save_Details();
            }
            /*if (e.KeyCode == Keys.F2)
            {
                comboBox1.SelectedIndex = 0;
                txtSearch.Text = "";
                panel1.Visible = true;
                DataTable dt = dbMainClass.getDetails("VENDORDETAILS");
                dataGridView1.DataSource = dt;
                Tabindex();
                comboBox1.Focus();
                panel2.TabStop = false;
                panel2.TabIndex = 26;
                btnUpdate.TabIndex = 4;
                button1.TabIndex = 5;
                butprint.TabIndex = 6;
                button2.TabIndex = 7;
                button3.TabIndex = 8;
                //dataGridView1.TabIndex = 26;
            }*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtVenderPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVenderFax_KeyPress(object sender, KeyPressEventArgs e)
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
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtVenderZip_KeyPress(object sender, KeyPressEventArgs e)
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
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtVenderOpeningBal_Leave(object sender, EventArgs e)
        {
            decimal x;
            if (decimal.TryParse(txtVenderOpeningBal.Text, out x))
            {
                if (txtVenderOpeningBal.Text.IndexOf('.') != -1 && txtVenderOpeningBal.Text.Split('.')[1].Length > 2)
                {
                    MessageBox.Show("The maximum decimal points are 2!");
                    txtVenderOpeningBal.Focus();
                }
                else txtVenderOpeningBal.Text = x.ToString("0.00");
            }
            else
            {
                txtVenderOpeningBal.Text = "0.00";
                //MessageBox.Show("Data invalid!");
                //txtVenderOpeningBal.Focus();
            }
           
        }

        private void cmbState_Leave(object sender, EventArgs e)
        {
            cmbState.SelectedIndex = 0;
        }

    }
}
