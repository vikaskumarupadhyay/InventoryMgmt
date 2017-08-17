using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ExcelLibrary.SpreadSheet;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Customer : Form
    {
        int value = 0;
        DB_Main dbMainClass = new DB_Main();
        public int updateCounter = 0;
        public Customer()
        {
            InitializeComponent();
        }
        public Customer(int value1)
        {
            value = value1;
            InitializeComponent();
        }
     
        private void Customer_Load(object sender, EventArgs e)
        {
            comstate.SelectedIndex = 0;
            comserchvalue.Focus();
            string s = txtCustOpeningBal.Text;
            int decimalCount = '.';
            bool validDecimal = true;
            if (validDecimal && decimalCount<1)
            {
                txtCustOpeningBal.Text = decimalCount.ToString();
            }
           
            if (value == 1)
            {
                //panel2.Visible = true;
                panel1.Visible = true;
                tabindex7();
                panel2.TabStop = false;
              // panel2.TabIndex = 26;
                comserchvalue.Focus();
                comserchvalue.TabStop = true;
                
                // comboBox1.TabIndex = 0;
                // txtSearch.TabIndex = 1;
                // dataGridView1.TabIndex = 2;
                //btnUpdate.TabIndex = 3;
                //button1.TabIndex = 4;
                //butprint.TabIndex = 5;
                //button2.TabIndex = 6;
                //button3.TabIndex = 7;

            }
            else if (value == 0)
            {
                //panel2.Visible = false;
                panel1.Visible = false;
            }

            //txtCURRENTBALANCE.Text = "0";
            //if (value == 1)
            //{
            //    panel1.Visible = true;
            //}
            //else if (value == 0)
            //{
            //    panel1.Visible = false;
             string selectQuery = "select  Custd.CustId as [Customer ID] ,CustName AS [Customer Name] ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustPanNo AS [PAN NO], CustGstNo AS [GST NO],CustDesc as [Description],CustOpeningBalance as[Opening Balance] ,CustCurrentBalance as[Current Balance] from  CustomerDetails Custd join CustomerAccountDetails Custad on Custd.CustID=Custad.CustID ";
             string actualcolumn = "select top 1  Custd.CustId  ,CustName  ,CustCompName  ,CustAddress ,CustCity , CustState  ,CustZip  ,CustCountry  ,CustEmail , CustWebAddress ,CustPhone  ,CustMobile  ,CustFax,CustPanNo ,CustGstNo,CustDesc,Custad.CustOpeningBalance,Custad.CustCurrentBalance from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID ";
            DataTable dt = dbMainClass.getDetailByQuery(selectQuery);
            DataTable onlycolumnname = dbMainClass.getDetailByQuery(actualcolumn);
            DataTable customtable = new DataTable();
            customtable.Columns.Add("Actualtablecolumname");
            customtable.Columns.Add("Aliascolumnname");
            DataColumnCollection c = dt.Columns;
            DataColumnCollection columnofname = onlycolumnname.Columns;
            for(int b = 1; b < c.Count; b++)
            {
                string d = c[b].ToString();
                string actualColumnName = columnofname[b].ToString();
                DataRow dr = customtable.NewRow();
                dr["Actualtablecolumname"] = actualColumnName;
                dr["Aliascolumnname"] = d;
                customtable.Rows.Add(dr);
            }
            comserchvalue.DataSource = customtable;
            comserchvalue.ValueMember = "Actualtablecolumname";
            comserchvalue.DisplayMember = "Aliascolumnname";
            dataGridView1.DataSource = dt;
            
            //panel1.Visible = false;
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

            Cust_SaveDetails();
        }
        //    }
        //}

        public void Cust_SaveDetails()
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
                //else
                //{
                //    if (!this.txtEMAILADDRESS.Text.Contains('@') || !this.txtEMAILADDRESS.Text.Contains('.'))
                //    {
                //        MessageBox.Show("Please select your correct email address");
                //    }
                //    else
                //    {
                //        if (!this.txtWEBSITE.Text.Contains('@') || !this.txtWEBSITE.Text.Contains('.') || !this.txtWEBSITE.Text.Contains('/'))
                //        {
                //            MessageBox.Show("plese select your corect website");
                //        }
                else
                {
                    if (updateCounter == 0)
                    {
                        string saveCommand1 = "insert into CustomerDetails values ('" + txtCustCode.Text + "','" + txtName.Text + "','" + txtCompnyName.Text + "','" + txtAddress.Text + "','" + txtCity.Text + "','" +comstate.SelectedItem.ToString() + "','" + txtZIP.Text + "','" + txtCustCountry.Text + "','" + txtEMAILADDRESS.Text + "','" + txtWEBSITE.Text + "','" + txtTXTPHONE.Text + "', '" + txtMOBILE.Text + "','" + txtFAX.Text + "','" + txtDESCRIPTION.Text + "','" + txtPanno.Text + "','" + txttanno.Text + "')";

                        string saveCommand2 = "insert into CustomerAccountDetails values ('" + txtCustCode.Text + "','" + txtCustCode.Text + "','" + txtCustOpeningBal.Text + "','" + txtCURRENTBALANCE.Text + "')";

                        int insertedRows = dbMainClass.saveDetails(saveCommand1, saveCommand2);
                        if (insertedRows > 0)
                        {
                            btnList.Enabled = true;
                            txtName.Focus();

                            MessageBox.Show("Details saved successfully");

                        }
                        else
                        {
                            MessageBox.Show("Details Not Saved Successfully");
                        }
                    }


                    else if (updateCounter == 1)
                    {
                        string updateCommand1 = "update  CustomerDetails  set Custid='" + txtCustCode.Text + "', CustAddress='" + txtAddress.Text + "',CustPhone='" + txtTXTPHONE.Text + "', CustMobile='" + txtMOBILE.Text + "',CustPanNO='" + txtPanno.Text + "', CustName='" + txtName.Text + "', CustCompName= '" + txtCompnyName.Text + "',CustCity='" + txtCity.Text + "',CustState='" +comstate.SelectedItem.ToString() + "',CustZip='" + txtZIP.Text + "',CustCountry='" + txtCustCountry.Text + "',CustEmail='" + txtEMAILADDRESS.Text + "',CustWebAddress='" + txtWEBSITE.Text + "',CustFax='" + txtFAX.Text + "',CustDesc='" + txtDESCRIPTION.Text + "' where Custid='" + txtCustCode.Text + "'";
                        string updateCommand2 = "update   CustomerAccountDetails set  CustOpeningBalance='" + txtCustOpeningBal.Text + "',CustCurrentBalance='" + txtCURRENTBALANCE.Text + "' where Custid='" + txtCustCode.Text + "'";

                        int updatedRows = dbMainClass.updateDetails(updateCommand1, updateCommand2);
                        if (updatedRows > 0)
                        {
                            MessageBox.Show("Details updated successfully");
                            txtName.Focus();
                            txtCustOpeningBal.ReadOnly = false;
                        }
                        else
                        {
                            MessageBox.Show("Details Update not updated");
                        }
                        updateCounter = 0;
                    }
                    makeblank();
                    blank1();
                    string Id = dbMainClass.getUniqueID("CUSTOMER");
                    txtCustCode.Text = Id;
                    txtName.Focus();
                    btnList.Enabled = true;
                    textBox1.Text = "";
                    comstate.SelectedIndex = 0;
                    tabindex2();
                }
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
            comstate.Text = "";
            txtCustCountry.Text = "";
            txtZIP.Text = "";
            txtEMAILADDRESS.Text = "";
            txtWEBSITE.Text = "";
            txtTXTPHONE.Text = "";
            txtMOBILE.Text = "";
            txtFAX.Text = "";
            txtDESCRIPTION.Text = "";

            txtCustOpeningBal.Text = "0";
            txtCURRENTBALANCE.Text = "0";
            txtCustCode.Text = "";
            txtCustCode.Text = "";

        }
        #endregion

        private void txtCustOpeningBal_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txtCustOpeningBal.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }


        private void btnList_Click(object sender, EventArgs e)
        {
            tabindex();
            panel1.Visible = true;
            string selectQuery = "select Custd.CustId as [Customer ID] ,CustName AS [Customer Name] ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustPanNo AS [PAN NO], CustGstNo AS [GST NO],CustDesc as [Description],CustOpeningBalance as[Opening Balance] ,CustCurrentBalance as[Current Balance] from  CustomerDetails Custd join CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID ";
            DataTable dt = dbMainClass.getDetailByQuery(selectQuery);
            dataGridView1.DataSource = dt;
            //dataGridView1.DataSource = dt;
             panel2.TabStop = false;
            correcttabindexlist();
            textBox1.Focus();
        }
        private void tabindex()
        {
            txtCustCode.TabStop = false;
            txtName.TabStop = false;
            txtCompnyName.TabStop = false;
            txtAddress.TabStop = false;
            txtCity.TabStop = false;
            comstate.TabStop = false;
            txtZIP.TabStop = false;
            txtCustCountry.TabStop = false;
            txtEMAILADDRESS.TabStop = false;
            txtWEBSITE.TabStop = false;
            txtTXTPHONE.TabStop = false;
            txtMOBILE.TabStop = false;
            txtFAX.TabStop = false;
            txtDESCRIPTION.TabStop = false;
            txtCustOpeningBal.TabStop = false;
            txtCURRENTBALANCE.TabStop = false;
            txtPanno.TabStop = false;
            txttanno.TabStop = false;
           
            btnSave.TabStop = false;
            btnClose.TabStop = false;
            btnList.TabStop = false;
            
           
            button1.TabStop = true;
            butaddrecord.TabStop = true;
            butupdate.TabStop = true;
            button2.TabStop = true;
            butclose.TabStop = true;
            comserchvalue.TabStop = true;
            textBox1.TabStop = true;
            dataGridView1.TabStop = true;
            
        }
        private void tabindex7()
        {
            txtCustCode.TabStop = false;
            txtName.TabStop = false;
            txtCompnyName.TabStop = false;
            txtAddress.TabStop = false;
            txtCity.TabStop = false;
            comstate.TabStop = false;
            txtZIP.TabStop = false;
           // txtCustCountry.TabStop = false;
            txtEMAILADDRESS.TabStop = false;
            txtWEBSITE.TabStop = false;
            txtTXTPHONE.TabStop = false;
            txtMOBILE.TabStop = false;
            txtFAX.TabStop = false;
            txtDESCRIPTION.TabStop = false;
            txtCustOpeningBal.TabStop = false;
            txtCURRENTBALANCE.TabStop = false;
            txtPanno.TabStop = false;
            txttanno.TabStop = false;
           
            btnSave.TabStop = false;
            btnClose.TabStop = false;
            btnList.TabStop = false;

          
          

        }
        private void correcttabindexlist()
        {
            comserchvalue.TabIndex = 1;
            textBox1.TabIndex = 2;
            panel2.TabIndex = 2;
            dataGridView1.TabIndex = 3;
            butupdate.TabIndex = 4;
            butaddrecord.TabIndex = 5;
            button1.TabIndex = 6;
            button2.TabIndex = 7;
            butclose.TabIndex = 8;
            
        }
        private void tabindex2()
        {
            txtCustCode.TabStop = true;
            txtName.TabStop = true;
            txtCompnyName.TabStop = true;
            txtAddress.TabStop = true;
            txtCity.TabStop = true;
            comstate.TabStop = true;
            txtZIP.TabStop = true;
            txtEMAILADDRESS.TabStop = true;
            txtWEBSITE.TabStop = true;
            txtTXTPHONE.TabStop = true;
            txtMOBILE.TabStop = true;
            txtFAX.TabStop = true;
            txtDESCRIPTION.TabStop = true;
            txtCustOpeningBal.TabStop = true;
           // txtCURRENTBALANCE.TabStop = true;
            txtPanno.TabStop = true;
            txttanno.TabStop = true;
           
            btnSave.TabStop = true;
            btnClose.TabStop = true;
            btnList.TabStop = true;
            // dataGridView1.TabStop = false;
           
        }
        private void tabindex1()
    {
        //txtAddress.Focus();
            txtCustOpeningBal.ReadOnly = true;
            txtName.Focus();
            txtCompnyName.TabStop = true;
            txtAddress.TabStop = true;
            txtCity.TabStop = true;
            comstate.TabStop = true;
            txtZIP.TabStop = true;
            txtCustCountry.TabStop = true;
            txtTXTPHONE.TabStop = true;
            txtMOBILE.TabStop = true;
            txtFAX.TabStop = true;
            txtPanno.TabStop = true;
           
            txtEMAILADDRESS.TabStop = true;
            txtWEBSITE.TabStop = true;
            txtDESCRIPTION.TabStop = true;
            txttanno.TabStop = true;
            btnSave.TabStop = true;
            btnClose.TabStop = true;
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
                comstate.Text = cellCollection[5].Value.ToString();
                txtZIP.Text = cellCollection[6].Value.ToString();
                txtCustCountry.Text = cellCollection[7].Value.ToString();
                txtEMAILADDRESS.Text = cellCollection[8].Value.ToString();
                txtWEBSITE.Text = cellCollection[9].Value.ToString();
                txtTXTPHONE.Text = cellCollection[10].Value.ToString();
                txtMOBILE.Text = cellCollection[11].Value.ToString();
                txtFAX.Text = cellCollection[12].Value.ToString();
                txtPanno.Text = cellCollection[13].Value.ToString();
                txttanno.Text = cellCollection[14].Value.ToString();
                txtDESCRIPTION.Text = cellCollection[15].Value.ToString();
                txtCustOpeningBal.Text = cellCollection[16].Value.ToString();
                txtCURRENTBALANCE.Text = cellCollection[17].Value.ToString();
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
                    //MessageBox.Show("Please enter numeric data!");
                }
            }
        }

        private void txtCustOpeningBal_TextChanged(object sender, EventArgs e)
        {
            if (txtCustOpeningBal.Text == "")
            {
                txtCURRENTBALANCE.Text = "0.00";
            }
            else
            {
                string v = txtCustOpeningBal.Text;
                txtCURRENTBALANCE.Text = v;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           string s= comserchvalue.SelectedValue.ToString();
          // string val = "Cust"+s;
             string selectQuery = "select  Custd.CustId as [Customer ID] ,CustName AS [Customer Name] ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustPanNo AS [PAN NO], CustGstNo AS [GST NO],CustDesc as [Description],CustOpeningBalance as[Opening Balance] ,CustCurrentBalance as[Current Balance] from  CustomerDetails Custd join CustomerAccountDetails Custad on Custd.CustID=Custad.CustID where " + s + " like '" + textBox1.Text + "%'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQuery);
            dataGridView1.DataSource = dt;

        }

        private void butaddrecord_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            txtName.Focus();
            tabindex2();
        }

        private void butupdate_Click(object sender, EventArgs e)
        {
            updateCounter = 1;
            int currentIndex = dataGridView1.CurrentRow.Index;
            DataGridViewCellCollection cellcollection = dataGridView1.Rows[currentIndex].Cells;
            if ((string)dataGridView1.SelectedRows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Select proper row");
            }
            else
            {

                setDetails(cellcollection);
                panel1.Visible = false;
               // txtwonername.Focus();
                btnList.Enabled = false;
                tabindex1();
            }
            
                //DataGridViewCellCollection cellcollection = dataGridView1.SelectedRows[0].Cells;
                //if (!string.IsNullOrEmpty(cellcollection[0].Value.ToString()))
                //{
                //    setDetails(cellcollection);
                //    panel1.Visible = false;
                //    updateCounter = 1;
                //    btnList.Enabled = false;
                //    blank();
                //    textBox1.Text = "";
                //    tabindex1();
                //}
             
        }
        private void blank()
        {
            txtName.Enabled = true;
            txtCompnyName.Enabled = true;
            txtAddress.Enabled = true;
            txtCity.Enabled = true;
            comstate.Enabled = true;
            txtZIP.Enabled = true;
            txtCustCountry.Enabled = true;
            txtPanno.Enabled = true;
            txttanno.Enabled = true;
            
            txtDESCRIPTION.Enabled = true;
            txtCustOpeningBal.Enabled = true;
            txtWEBSITE.Enabled = true;
            txtEMAILADDRESS.Enabled = true;
            txtCustCode.Enabled = true;
            txtCURRENTBALANCE.Enabled = true;
          
            
        }
        private void blank1()
        {
            txtCustCode.Enabled = true;
            txtName.Enabled = true;
            txtCompnyName.Enabled = true;
            txtAddress.Enabled = true;
            txtCity.Enabled = true;
            comstate.Enabled = true;
            txtZIP.Enabled = true;
            txtCustCountry.Enabled = true;
            txtPanno.Enabled = true;
            txttanno.Enabled = true;
          
            txtDESCRIPTION.Enabled = true;
            txtCustOpeningBal.Enabled = true;
            txtWEBSITE.Enabled = true;
            txtEMAILADDRESS.Enabled = true;
            txtTXTPHONE.Enabled = true;
            txtMOBILE.Enabled = true;
            txtFAX.Enabled = true;
          
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            btnList.Enabled = false;
            updateCounter = 1;
            int currentIndex = dataGridView1.CurrentRow.Index;
            DataGridViewCellCollection cellcollection = dataGridView1.Rows[currentIndex].Cells;
            if (!string.IsNullOrEmpty(cellcollection[0].Value.ToString()))
            {
                setDetails(cellcollection);
                panel1.Visible = false;
                tabindex1();

            }
            else
            {
                MessageBox.Show("Select proper row");
            }
          
        }

        private void butclose_Click(object sender, EventArgs e)
        {
            txtName.Focus();
            tabindex2();
            panel1.Visible = false;
        }
        private void makeblank()
        {

            txtCustCode.Text = "";
            txtName.Text = "";
            txtCompnyName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            comstate.Text = "";
            //txtCustCountry.Text = "";
            txtZIP.Text = "";
            txtEMAILADDRESS.Text = "";
            txtWEBSITE.Text = "";
            txtTXTPHONE.Text = "";
            txtMOBILE.Text = "";
            txtFAX.Text = "";
            txtDESCRIPTION.Text= "";
            txtPanno.Text = "";
            txttanno.Text = "";
           

            txtCustOpeningBal.Text = "0";
            txtCURRENTBALANCE.Text= "0";

            //comserchvalue.SelectedIndex = 0;
            txtCustCode.Text = "";
            txtCustCode.Text= "";

        }

        private void txtPanno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar))
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

        

        private void txtCURRENTBALANCE_Click(object sender, EventArgs e)
        {
            //txtCURRENTBALANCE.Text = string.Empty;
        }

        private void txtEMAILADDRESS_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (txtEMAILADDRESS.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(txtEMAILADDRESS.Text.Trim()))
                {

                    MessageBox.Show("E-mail address format is not correct.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtEMAILADDRESS.Focus();

                }

            }
        }

        private void txtWEBSITE_Leave(object sender, EventArgs e)
        {
            bool isValidUrl = Uri.IsWellFormedUriString(txtWEBSITE.Text, UriKind.Absolute);
            if (txtWEBSITE.Text == "")
            {
                return;
            }
            if (!isValidUrl)
            {
                MessageBox.Show("Web site format is not correct.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtWEBSITE.Focus();
            }
        }

       

        private void dataGridView1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            int currentIndex = dataGridView1.CurrentRow.Index;
            if (currentIndex == 0)
            {
                MessageBox.Show("please select your proper row");
                currentIndex = currentIndex + 1;
                return;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
                {
                //    if (dataGridView1.RowCount == currentIndex - 1)
                //        currentIndex = currentIndex - 1;
                    DataGridViewCellCollection cellcollection = dataGridView1.Rows[currentIndex-1].Cells;
                    setDetails(cellcollection);
                    panel1.Visible = false;
                    updateCounter = 1;
                    btnList.Enabled = false;
                    blank();
                    tabindex1();
                }
              
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRowCollection rowcollection = dataGridView1.Rows;
            List<Class2> class2Collection=new List<Class2>();

            for (int a = 0; a < rowcollection.Count; a++)
            {
                DataGridViewRow currentrow = rowcollection[a];
                DataGridViewCellCollection cellcollecton = currentrow.Cells;

                Class2 gridViewClassObject = new Class2();

                gridViewClassObject.name = cellcollecton[1].Value.ToString();
                gridViewClassObject.address = cellcollecton[3].Value.ToString();
                gridViewClassObject.mobileno = cellcollecton[11].Value.ToString();
                gridViewClassObject.Emailaddress=cellcollecton[8].Value.ToString();
                gridViewClassObject.openingbalance = cellcollecton[14].Value.ToString();
                gridViewClassObject.currentbalance = cellcollecton[15].Value.ToString();
                class2Collection.Add(gridViewClassObject);

            }
            customerprint p = new customerprint(class2Collection);
            p.Show();
        }
        int num = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.AllowUserToAddRows == true)
            {
                dataGridView1.AllowUserToAddRows = false;
            }
            string FileName = "";
            SaveFileDialog openFileDialog1 = new SaveFileDialog();
            //FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();
            openFileDialog1.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
            openFileDialog1.FileName = "Customer Details";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog1.FileName;


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
                this.Close();
                workbook.Save(file);
                dataGridView1.AllowUserToAddRows = true;
            }
            else
            {
                dataGridView1.AllowUserToAddRows = true;
            }
        }

        

        private void Customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "S")
            {

                Cust_SaveDetails();
            }
            /*if (e.KeyCode == Keys.F2)
            {
                tabindex();
                panel1.Visible = true;
                string selectQuery = "select Custd.CustId as [Customer ID] ,CustName AS Name ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustPanNo AS [PAN NO], CustVatNo AS [VAT NO],CustCSTNo AS [CST NO],CustServicetaxRegnNo AS [SERVICE TAX NO],CustExciseRegnNo AS [EXICE NO] ,Gstregnno AS [GST NO],CustDesc as [Description],CustOpeningBalance as[Opening Balance] ,CustCurrentBalance as[Current Balance] from  CustomerDetails Custd join CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID ";
                DataTable dt = dbMainClass.getDetailByQuery(selectQuery);
                dataGridView1.DataSource = dt;
                //dataGridView1.DataSource = dt;
                panel2.TabStop = false;
                correcttabindexlist();
                comserchvalue.Focus();
            }*/
        }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtZIP_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtFAX_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCustOpeningBal_Leave(object sender, EventArgs e)
        {
            decimal x;
            if (decimal.TryParse(txtCustOpeningBal.Text, out x))
            {
                if (txtCustOpeningBal.Text.IndexOf('.') != -1 && txtCustOpeningBal.Text.Split('.')[1].Length > 2)
                {
                    MessageBox.Show("The maximum decimal points are 2!");
                    txtCustOpeningBal.Focus();
                }
                else txtCustOpeningBal.Text = x.ToString("0.00");
            }
            else
            {
                txtCustOpeningBal.Text = "0.00";
                //MessageBox.Show("Data invalid!");
                //txtVenderOpeningBal.Focus();
            }
           
           /* if (txtCustOpeningBal.Text == "")
            {
                txtCustOpeningBal.Text= "0";

            }
            else
            {

                string value = txtCustOpeningBal.Text;
                txtCURRENTBALANCE.Text = value;
            }*/
        }

        private void txtCustOpeningBal_Click(object sender, EventArgs e)
        {
            txtCustOpeningBal.Text = string.Empty;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void comstate_Leave(object sender, EventArgs e)
        {
            if (comstate.SelectedIndex < 0)
            {
                comstate.SelectedIndex = 0;
            } 
        }

       

        private void txtPanno_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;

            if (txtPanno.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex("[A-Z]{5}[0-9]{4}[A-Z]{1}");
                if (!mRegxExpression.IsMatch(txtPanno.Text.Trim()))
                {
                    txtPanno.Focus();
                    MessageBox.Show("Pan Card  format is not correct", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void txttanno_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (txttanno.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex("[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[0-9]{1}[Z]{1}[0-9]{1}$");
                if (!mRegxExpression.IsMatch(txttanno.Text.Trim()))
                {
                    txttanno.Focus();
                    MessageBox.Show("Gst in format is not correct", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || (char.IsDigit(e.KeyChar) || (char.IsWhiteSpace(e.KeyChar))))
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
                    MessageBox.Show("Plese enter correct Value");
                }
            }
        }

        private void txtCompnyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || (char.IsDigit(e.KeyChar) || (char.IsWhiteSpace(e.KeyChar))))
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
                    MessageBox.Show("Plese enter correct Value");
                }
            }
        }

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || (char.IsDigit(e.KeyChar) || (char.IsWhiteSpace(e.KeyChar))))
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
                    MessageBox.Show("Plese enter correct Value");
                }
            }
        }


      

             
   
    }
}