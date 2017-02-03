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
            if (value == 1)
            {
                panel1.Visible = true;
            }
            else if (value == 0)
            {
                panel1.Visible = false;
            }
        
            //DataTable dt = dbMainClass.getDetails("CustomerDetails");
            //List<string> ds = new List<string>();
            //ds.Add("Name");
            //ds.Add("CompnayName");
            //ds.Add("Address");
            //ds.Add("City");
            //ds.Add("State");
            //ds.Add("Zip");
            //ds.Add("Country");
            //ds.Add("Email");
            //ds.Add("Webaddress");
            //ds.Add("Phone");
            //ds.Add("Mobile");
            //ds.Add("Fax");
            //ds.Add("Desc");
            //ds.Add("Openingbalance");
            //ds.Add("Currentbalance");
            //ds.Add("PanNo");
            //ds.Add("VatNo");
            //ds.Add("Cstno");
            //ds.Add("ServicetaxregnNo");
            //ds.Add("Exciseregnno");
            //ds.Add("Gstregnno");
            //comserchvalue.DataSource = ds;
          

            string selectQuery = "select  Custd.CustId as [Customer ID] ,CustName AS Name ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustDesc AS Description,Custad.CustOpeningBalance AS [Opening Balance] , Custad.CustCurrentBalance AS [Current Ballance],CustPanNo AS [PAN NO], CustVatNo AS [VAT NO],CustCSTNo AS [CST NO]  ,CustServicetaxRegnNo AS [Service Tax Regn. No],CustExciseRegnNo AS [Excise Regn. No] ,Gstregnno AS [GST Regn. No] from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID ";
            string actualcolumn = "select  Custd.CustId  ,CustName  ,CustCompName  ,CustAddress ,CustCity , CustState  ,CustZip  ,CustCountry  ,CustEmail , CustWebAddress ,CustPhone  ,CustMobile  ,CustFax ,CustDesc ,Custad.CustOpeningBalance , Custad.CustCurrentBalance ,CustPanNo , CustVatNo ,CustCSTNo  ,CustServicetaxRegnNo ,CustExciseRegnNo  ,Gstregnno  from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID ";
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
                                string saveCommand1 = "insert into CustomerDetails values ('" + txtCustCode.Text + "','" + txtName.Text + "','" + txtCompnyName.Text + "','" + txtAddress.Text + "','" + txtCity.Text + "','" + txtState.Text + "','" + txtZIP.Text + "','" + txtCustCountry.Text + "','" + txtEMAILADDRESS.Text + "','" + txtWEBSITE.Text + "','" + txtTXTPHONE.Text + "', '" + txtMOBILE.Text + "','" + txtFAX.Text + "','"+txtDESCRIPTION.Text+"','" + txtPanno.Text + "','" + txttanno.Text + "','"+txtothers.Text+"','"+txtservicetaxno.Text+"','"+txtexiceragisterno.Text+"','"+txtgstragisterno.Text+"')";

                                string saveCommand2 = "insert into CustomerAccountDetails values ('"+txtCustCode.Text+"','" + txtOPENINGBALANCE.Text + "','" + txtCURRENTBALANCE.Text + "')";

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
                                string updateCommand1 = "update  CustomerDetails  set Custid='" + txtCustCode.Text + "', CustAddress='" + txtAddress.Text + "',CustPhone='" + txtTXTPHONE.Text + "', CustMobile='" + txtMOBILE.Text + "',CustPanNO='" + txtPanno.Text + "',CustVatNo='" + txttanno.Text + "',CustCstNo='" + txtothers.Text + "',CustServicetaxregnNo='" + txtservicetaxno.Text + "',CustExciseregnno='" + txtexiceragisterno.Text + "',CustGstregnno='" + txtgstragisterno.Text + "', CustName='" + txtName.Text + "', CustCompName= '" + txtCompnyName.Text + "',CustCity='" + txtCity.Text + "',CustState='" + txtState.Text + "',CustZip='" + txtZIP.Text + "',CustCountry='" + txtCustCountry.Text + "',CustEmail='" + txtEMAILADDRESS.Text + "',CustWebAddress='" + txtWEBSITE.Text + "',CustFax='" + txtFAX.Text + "',CustDesc='" + txtDESCRIPTION.Text + "' where Custid='" + txtCustCode.Text + "'";
                                string updateCommand2 = "update   CustomerAccountDetails set  CustOpeningBalance='" + txtOPENINGBALANCE.Text + "',CustCurrentBalance='" + txtCURRENTBALANCE.Text + "' where Custid='" + txtCustCode.Text + "'";

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
                            blank1();
                            string Id = dbMainClass.getUniqueID("CUSTOMER");
                            txtCustCode.Text = Id;
                            txtName.Focus();
                            btnList.Enabled = true;
                            tabindex2();
                        }
                    }
                }
        //    }
        //}
        
      
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
            
            tabindex();
            panel1.Visible = true;
            DataTable dt = dbMainClass.getDetails("CUSTOMER");
            dataGridView1.DataSource = dt;
            panel2.TabStop = false;
            panel2.TabIndex = 2;
            dataGridView1.TabIndex = 3;
            comserchvalue.Focus();
        }
        private void tabindex()
        {
            txtCustCode.TabStop = false;
            txtName.TabStop = false;
            txtCompnyName.TabStop = false;
            txtAddress.TabStop = false;
            txtCity.TabStop = false;
            txtState.TabStop = false;
            txtZIP.TabStop = false;
            txtCustCountry.TabStop = false;
            txtEMAILADDRESS.TabStop = false;
            txtWEBSITE.TabStop = false;
            txtTXTPHONE.TabStop = false;
            txtMOBILE.TabStop = false;
            txtFAX.TabStop = false;
            txtDESCRIPTION.TabStop = false;
            txtOPENINGBALANCE.TabStop = false;
            txtCURRENTBALANCE.TabStop = false;
            txtPanno.TabStop = false;
            txttanno.TabStop = false;
            txtothers.TabStop = false;
            btnSave.TabStop = false;
            btnClose.TabStop = false;
            btnList.TabStop = false;
           // dataGridView1.TabStop = false;
            txtservicetaxno.TabStop = false;
            txtexiceragisterno.TabStop = false;
            txtgstragisterno.TabStop = false;
        }
        private void tabindex2()
        {
            txtCustCode.TabStop = true;
            txtName.TabStop = true;
            txtCompnyName.TabStop = true;
            txtAddress.TabStop = true;
            txtCity.TabStop = true;
            txtState.TabStop = true;
            txtZIP.TabStop = true;
            txtCustCountry.TabStop = true;
            txtEMAILADDRESS.TabStop = true;
            txtWEBSITE.TabStop = true;
            txtTXTPHONE.TabStop = true;
            txtMOBILE.TabStop = true;
            txtFAX.TabStop = true;
            txtDESCRIPTION.TabStop = true;
            txtOPENINGBALANCE.TabStop = true;
            txtCURRENTBALANCE.TabStop = true;
            txtPanno.TabStop = true;
            txttanno.TabStop = true;
            txtothers.TabStop = true;
            btnSave.TabStop = true;
            btnClose.TabStop = true;
            btnList.TabStop = true;
            // dataGridView1.TabStop = false;
            txtservicetaxno.TabStop = true;
            txtexiceragisterno.TabStop = true;
            txtgstragisterno.TabStop = true;
        }
        private void tabindex1()
    {
        txtAddress.Focus();
         txtAddress.TabStop = true;
            txtCity.TabStop = true;
            txtState.TabStop = true;
            txtZIP.TabStop = true;
        txtCustCountry.TabStop = true;
         txtTXTPHONE.TabStop = true;
            txtMOBILE.TabStop = true;
            txtFAX.TabStop = true;
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
                txtPanno.Text = cellCollection[16].Value.ToString();
                txttanno.Text = cellCollection[17].Value.ToString();
                txtothers.Text = cellCollection[18].Value.ToString();
                txtservicetaxno.Text = cellCollection[19].Value.ToString();
                txtexiceragisterno.Text = cellCollection[20].Value.ToString();
                txtgstragisterno.Text = cellCollection[21].Value.ToString();
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
            if (txtOPENINGBALANCE.Text == "")
            {
                txtCURRENTBALANCE.Text = "";
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
          // string val = "Cust"+s;
           string selectQuery = "select  Custd.CustId as [Customer ID] ,CustName AS Name ,CustCompName AS [Compnay Name] ,CustAddress AS Address,CustCity AS City, CustState AS State ,CustZip AS Zip ,CustCountry AS Country ,CustEmail AS [E-Mail Address] , CustWebAddress AS [Web Address],CustPhone AS Phone ,CustMobile AS Mobile ,CustFax AS Fax ,CustDesc AS Description,Custad.CustOpeningBalance AS [Opening Balance] , Custad.CustCurrentBalance AS [Current Ballance],CustPanNo AS [PAN NO], CustVatNo AS [VAT NO],CustCSTNo AS [CST NO]  ,CustServicetaxRegnNo AS [Service Tax Regn. No],CustExciseRegnNo AS [Excise Regn. No] ,CustGSTRegnNo AS [GST Regn. No] from  CustomerDetails Custd join    CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID where " + s + " like '" + textBox1.Text + "%'";
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
            btnList.Enabled = false;
            blank();
            textBox1.Text = "";
            tabindex1();
        }
        private void blank()
        {
            txtName.Enabled = false;
            txtCompnyName.Enabled = false;
            txtAddress.Enabled = true;
            txtCity.Enabled = true;
            txtState.Enabled = true;
            txtZIP.Enabled = true;
            txtCustCountry.Enabled = true;
            txtPanno.Enabled = false;
            txttanno.Enabled = false;
            txtothers.Enabled = false;
            txtDESCRIPTION.Enabled = false;
            txtOPENINGBALANCE.Enabled = false;
            txtWEBSITE.Enabled = false;
            txtEMAILADDRESS.Enabled = false;
            txtCustCode.Enabled = false;
            txtCURRENTBALANCE.Enabled = false;
            txtservicetaxno.Enabled = false;
            txtexiceragisterno.Enabled = false;
            txtgstragisterno.Enabled = false;
            
        }
        private void blank1()
        {
            txtCustCode.Enabled = true;
            txtName.Enabled = true;
            txtCompnyName.Enabled = true;
            txtAddress.Enabled = true;
            txtCity.Enabled = true;
            txtState.Enabled = true;
            txtZIP.Enabled = true;
            txtCustCountry.Enabled = true;
            txtPanno.Enabled = true;
            txttanno.Enabled = true;
            txtothers.Enabled = true;
            txtDESCRIPTION.Enabled = true;
            txtOPENINGBALANCE.Enabled = true;
            txtWEBSITE.Enabled = true;
            txtEMAILADDRESS.Enabled = true;
            txtTXTPHONE.Enabled = true;
            txtMOBILE.Enabled = true;
            txtFAX.Enabled = true;
            txtservicetaxno.Enabled = true;
            txtexiceragisterno.Enabled = true;
            txtgstragisterno.Enabled = true;
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = "";
            comserchvalue.SelectedIndex = 0;
            DataGridViewCellCollection cellCollection = dataGridView1.Rows[e.RowIndex].Cells;
            setDetails(cellCollection);
            panel1.Visible = false;
            updateCounter = 1;
            tabindex1();
            blank();
           
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
            txtState.Text = "";
            txtCustCountry.Text = "";
            txtZIP.Text = "";
            txtEMAILADDRESS.Text = "";
            txtWEBSITE.Text = "";
            txtTXTPHONE.Text = "";
            txtMOBILE.Text = "";
            txtFAX.Text = "";
            txtDESCRIPTION.Text= "";
            txtPanno.Text = "";
            txttanno.Text = "";
            txtothers.Text = "";

            txtOPENINGBALANCE.Text = "";
            txtCURRENTBALANCE.Text= "";
            txtservicetaxno.Text = "";
            txtexiceragisterno.Text = "";
            txtgstragisterno.Text = "";

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

        private void txtOPENINGBALANCE_Click(object sender, EventArgs e)
        {
            txtOPENINGBALANCE.Text = string.Empty;
        }

        private void txtCURRENTBALANCE_Click(object sender, EventArgs e)
        {
            //txtCURRENTBALANCE.Text = string.Empty;
        }

        private void txtEMAILADDRESS_Leave(object sender, EventArgs e)
        {
            if ((txtEMAILADDRESS.Text.LastIndexOf("@") > -1) && (txtEMAILADDRESS.Text.LastIndexOf(".") > -1) || string.IsNullOrEmpty(txtEMAILADDRESS.Text))
            {
            }
            else
            {
                MessageBox.Show("please select your correct email");
            }
        }

        private void txtWEBSITE_Leave(object sender, EventArgs e)
        {
            if ((txtWEBSITE.Text.LastIndexOf("http://") > -1) && (txtWEBSITE.Text.LastIndexOf(".") > -1) && (txtWEBSITE.Text.LastIndexOf("www") > -1) || string.IsNullOrEmpty(txtEMAILADDRESS.Text))
            {
            }
            else
            {
                MessageBox.Show("please select your correct website");
            }
        }

       

        private void dataGridView1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            int currentIndex = dataGridView1.CurrentRow.Index;
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
                {
                    if (dataGridView1.RowCount == currentIndex + 1)
                        currentIndex = currentIndex + 1;
                    DataGridViewCellCollection cellcollection = dataGridView1.Rows[currentIndex - 1].Cells;
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

      

    }
}
