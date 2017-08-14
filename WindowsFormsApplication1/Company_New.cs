using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelLibrary.SpreadSheet;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Company_New : Form
    {
        DB_Main dbMainClass = new DB_Main();
        public int updatecounter = 0;
        public List<string> TexList = new List<string>();
        public DataTable dt = new DataTable();
        public Company_New()
        {
            InitializeComponent();
        }
        private void Compnay_Load(object sender, EventArgs e)
        {
           
            string selectquery = "select * from CompnayDetails";
            DataTable dt = dbMainClass.getDetailByQuery(selectquery);
            if (dt.Rows.Count == null)
            {
                txtCompnayCode.Text = "C1";
            }
            if (dt.Rows.Count > 0)
            {
                txtCompnayCode.Text = dt.Rows[0]["CompnayId"].ToString();
                txtwonername.Text = dt.Rows[0]["OnerName"].ToString();
                txtCompnayName.Text = dt.Rows[0]["Name"].ToString();
                txtCompnayAddress.Text = dt.Rows[0]["Address"].ToString();
                txtCity.Text = dt.Rows[0]["City"].ToString();
                cmbState.Text = dt.Rows[0]["State"].ToString();
                txtZip.Text = dt.Rows[0]["Zip"].ToString();
                txtCountry.Text = dt.Rows[0]["Country"].ToString();
                txtEmailAddress.Text = dt.Rows[0]["Email"].ToString();
                txtWebSite.Text = dt.Rows[0]["WebAddress"].ToString();
                txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                txtFax.Text = dt.Rows[0]["Fax"].ToString();
                txtPanNo.Text = dt.Rows[0]["PANNO"].ToString();
                txtGst.Text = dt.Rows[0]["GSTNo"].ToString();
                txtDescription.Text = dt.Rows[0]["Description"].ToString();
                makeblank();
            }
          
            //string selectqurry = "select cd.CompnayId as[Company ID], cd.OnerName as[Owner Name], cd.Name as[Company Name] ,cd.Address,cd.City,cd.State,cd.Zip,cd.Country,cd.Email as[E-Mail],cd.WebAddress as[Web Address],cd.Phone,cd.Mobile,cd.Fax,cd.PANNO as[PAN NO],cd.GSTNO as[GST NO]from CompnayDetails cd";
            //string selectqurryForActualColumnName = "select top 1 cd.CompnayId, cd.OnerName, cd.Name ,cd.Address,cd.City,cd.State,cd.Zip,cd.Country,cd.Email,cd.WebAddress,cd.Phone,cd.Mobile,cd.Fax,cd.PANNO,cd.GSTNO from CompnayDetails cd";
            //DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            //DataTable dtOnlyColumnName = dbMainClass.getDetailByQuery(selectqurryForActualColumnName);
            //DataTable customDataTable = new DataTable();
            //customDataTable.Columns.Add("ActualTableColumnName");
            //customDataTable.Columns.Add("AliasTableColumnName");
            ////List<string> ls = new List<string>();
            //DataColumnCollection d = dt.Columns;
            //DataColumnCollection dataColumnForName = dtOnlyColumnName.Columns;
            //for (int a = 1; a < d.Count; a++)
            //{
            //    //DataColumn dc = new DataColumn();
            //    string b = d[a].ToString();
            //    string actualColumnName = dataColumnForName[a].ToString();
            //    DataRow dr = customDataTable.NewRow();
            //    dr["ActualTableColumnName"] = actualColumnName;
            //    dr["AliasTableColumnName"] = b;
            //    customDataTable.Rows.Add(dr);
            //    //  ls.Add(b);
            //}

            //ComDetails.DataSource = customDataTable;
            //ComDetails.ValueMember = "ActualTableColumnName";
            //ComDetails.DisplayMember = "AliasTableColumnName";
            //dataGridView1.DataSource = dt;

            //panel1.Visible = false;
            //string selectqury = "select max (CompnayId)  from compnaydetails";
            //DataTable dt1 = dbMainClass.getDetailByQuery(selectqury);
            //string id = "";
            //foreach (DataRow dr in dt1.Rows)
            //{
            //    id = dr[0].ToString();
            //}
            //if (id == "")
            //{
            //    id = "1";
            //    txtCompnayCode.Text = "C" + id;
            //}
            //else
            //{
            //    string id1 = id.Substring(0, 1);
            //    string id2 = id.Substring(1);
            //    int s = Convert.ToInt32(id2);
            //    int s1 = s + 1;
            //    string id3 = id1 + s1.ToString();
            //    txtCompnayCode.Text = id3;
            //}
            //txtwonername.Focus();
            //string selectCommandGroup = "select TexId,TexName,TexAmount,TexDescription from dbo.CompnayTex";
            //setItemGroupDetail(selectCommandGroup, combComp, "Tax");
        }

        private string setdetails()
        {
            throw new NotImplementedException();
        }
        private void setItemGroupDetail(string Query, ComboBox cmb, string Message)
        {
            //string selectCommand = "select groupID,GROUPNAME,GROUPDESC from dbo.ItemGroup";
            cmb.Items.Clear();
            cmb.Items.Add("Select  " + Message);
            dt = dbMainClass.getDataBoundToComboBox(Query);
            if (dt != null && dt.Rows.Count > 0)
            {
                //   cmb.DataSource = dt;
                //  cmb.ValueMember = "";
                // cmb.DisplayMember = "";

                foreach (DataRow dr in dt.Rows)
                {
                    cmb.Items.Add(dr[1].ToString().ToUpper());
                    if (Message.ToLower() == "Tax")
                    {
                        TexList.Add(dr[0].ToString());
                    }
                    else
                    {
                        //TexList.Add(dr[0].ToString());
                    }
                }
                dt.Dispose();
            }
            else if (dt != null && dt.Rows.Count == 0)
            {
                cmb.Items.Clear();
                cmb.Items.Add("Select a " + Message);
            }
            cmb.SelectedIndex = 0;
        }
        private void makeblank()
        {
            //txtCompnayCode.Text = "C";
            txtwonername.ReadOnly =true;
            txtCompnayName.ReadOnly = true;
            txtCompnayAddress.ReadOnly = true;
            txtCity.ReadOnly = true;
            txtZip.ReadOnly = true;
            txtCountry.ReadOnly = true;
            txtEmailAddress.ReadOnly = true;
            txtWebSite.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtMobile.ReadOnly=true;
            txtFax.ReadOnly=true;
            txtPanNo.ReadOnly=true;
            txtGst.ReadOnly=true;
            txtDescription.ReadOnly=true;
            cmbState.Enabled = false;
            //combComp.SelectedIndex = 0;
           // txtTexAmount.Text = "0";

        }
        private void makeblank1()
        {
            //txtCompnayCode.Text = "C";
            txtwonername.ReadOnly = false;
            txtCompnayName.ReadOnly = false;
            txtCompnayAddress.ReadOnly = false;
            txtCity.ReadOnly = false;
            txtZip.ReadOnly = false;
            txtCountry.ReadOnly = false;
            txtEmailAddress.ReadOnly = false;
            txtWebSite.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtMobile.ReadOnly = false;
            txtFax.ReadOnly = false;
            txtPanNo.ReadOnly = false;
            txtGst.ReadOnly = false;
            txtDescription.ReadOnly = false;
            cmbState.Enabled =false;
            //combComp.SelectedIndex = 0;
            // txtTexAmount.Text = "0";

        }
        private void tabindex1()
        {
            //txtSearch.Focus();
            //txtSearch.TabIndex = 1;
            //dataGridView1.TabIndex = 2;
            //butUpdate.TabIndex = 3;
            //butAddNewRecord.TabIndex = 4;
            //btnPrint.TabIndex = 5;
            //btnExportToExcel.TabIndex = 6;
            //btnClose.TabIndex = 7;
            //tabindex();
        }
        private void tabindex()
        {
            txtCompnayCode.TabStop = false;
            txtwonername.TabStop = false;
            txtCompnayName.TabStop = false;
            txtCompnayAddress.TabStop = false;
            txtCity.TabStop = false;
            cmbState.TabStop = false;
            txtZip.TabStop = false;
            txtCountry.TabStop = false;
            txtEmailAddress.TabStop = false;
            txtWebSite.TabStop = false;
            txtPhone.TabStop = false;
            txtMobile.TabStop = false;
            txtFax.TabStop = false;
            txtPanNo.TabStop = false;
            txtGst.TabStop = false;

            txtGst.TabStop = false;
            txtDescription.TabStop = false;
            btnSave.TabStop = false;
            btnClose.TabStop = false;
           // btnList.TabStop = false;
            dtpdate.TabStop = false;
            combComp.TabStop = false;
            txtTexAmount.TabStop = false;
            //txtGst.TabStop = false;
            groupBox2.TabStop = false;
            groupBox1.TabStop = false;
            btnTex.TabStop = false;
        }


        private void tabindex2()
        {

            btnClose.TabIndex = 29;
            //txtCompnayCode.TabStop = false;
            txtwonername.TabStop = true;
            txtCompnayName.TabStop = true;
            txtCompnayAddress.TabStop = true;
            txtCity.TabStop = true;
            cmbState.TabStop = true;
            txtZip.TabStop = true;
            txtCountry.TabStop = true;
            txtEmailAddress.TabStop = true;
            txtWebSite.TabStop = true;
            txtPhone.TabStop = true;
            txtMobile.TabStop = true;
            txtFax.TabStop = true;
            txtPanNo.TabStop = true;
            txtGst.TabStop = true;
            txtDescription.TabStop = true;
            combComp.TabStop = true;
            txtTexAmount.TabStop = true;
            btnTex.TabStop = true;
            btnSave.TabStop = true;
           // btnList.TabStop = true;
            btnClose.TabStop = true;
            groupBox2.TabStop = true;
            groupBox1.TabStop = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Comp_SaveDetails();
        }
        public void Comp_SaveDetails()
        {
            if (updatecounter == 0)
            {
                if (txtCompnayCode.Text == "C1")
                {
                    string insertquery = "insert into CompnayDetails Values ('" + txtCompnayCode.Text + "','" + txtwonername.Text + "','" + txtCompnayName.Text + "','" + txtCompnayAddress.Text + "','" + txtCity.Text + "','" + cmbState.SelectedItem.ToString() + "','" + txtZip.Text + "','" + txtCountry.Text + "','" + txtEmailAddress.Text + "','" + txtWebSite.Text + "','" + txtPhone.Text + "','" + txtMobile.Text + "','" + txtFax.Text + "','" + txtPanNo.Text + "','" + txtGst.Text + "','" + txtDescription.Text + "','" + true + "','" + dtpdate.Value.ToString() + "')";
                    int insertrow = dbMainClass.saveDetails(insertquery);
                    string insertquery1 = "Update CompnayDetails set CompnayId='" + txtCompnayCode.Text + "',OnerName='" + txtwonername.Text + "',Name='" + txtCompnayName.Text + "',Address='" + txtCompnayAddress.Text + "',City='" + txtCity.Text + "',State='" + cmbState.SelectedItem.ToString() + "',Zip='" + txtZip.Text + "',Country='" + txtCountry.Text + "',Email='" + txtEmailAddress.Text + "',WebAddress='" + txtWebSite.Text + "',Phone='" + txtPhone.Text + "',Mobile='" + txtMobile.Text + "',Fax='" + txtFax.Text + "',PANNO='" + txtPanNo.Text + "',GSTNo='" + txtGst.Text + "',Description='" + txtDescription.Text + "',Isactive='" + true + "',RagistrationDate='" + dtpdate.Value.ToString() + "'";
                    int insertrow1 = dbMainClass.saveDetails(insertquery1);
                    if (insertrow1 > 0)
                    {
                        MessageBox.Show("Details save successfully");
                        string id = txtCompnayCode.Text;
                        string id1 = id.Substring(0, 1);
                        string id2 = id.Substring(1);
                        int s = Convert.ToInt32(id2);
                        int s1 = s + 1;
                        string id3 = id1 + s1.ToString();
                        txtCompnayCode.Text = id3;
                    }
                    else
                    {
                        MessageBox.Show("Details Not Save successfully");
                    }

                }
                else
                {
                    MessageBox.Show("You can not create more than one company!");
                }
            }
            if (updatecounter == 1)
            {
                string updatecommand = "update CompnayDetails set OnerName='" + txtwonername.Text + "', Name='" + txtCompnayName.Text + "',Address='" + txtCompnayAddress.Text + "',City='" + txtCity.Text + "',State='" + cmbState.SelectedItem.ToString() + "',Zip='" + txtZip.Text + "',Country='" + txtCountry.Text + "',Email='" + txtEmailAddress.Text + "',WebAddress='" + txtWebSite.Text + "',Phone='" + txtPhone.Text + "',Mobile='" + txtMobile.Text + "',Fax='" + txtFax.Text + "',PANNO='" + txtPanNo.Text + "',GSTNO='" + txtGst.Text + "',Description='" + txtDescription.Text + "',RagistrationDate='" + dtpdate.Value.ToString() + "' where CompnayId='" + txtCompnayCode.Text + "' ";
                int updatequrry = dbMainClass.saveDetails(updatecommand);
                if (updatequrry > 0)
                {
                    //string updateTax = "update CompnayTex set TexAmount='" + txtTexAmount.Text + "' where TexId='" + taxId + "'";
                    //int updatequrry1 = dbMainClass.saveDetails(updateTax);
                    //if (updatequrry1 > 0)
                    //{
                    MessageBox.Show("Details updated successfully");
                    makeblank();
                    string selectqury = "select max (CompnayId) from compnaydetails";
                    DataTable dt1 = dbMainClass.getDetailByQuery(selectqury);
                    string id = "";
                    foreach (DataRow dr in dt1.Rows)
                    {
                        id = dr[0].ToString();
                    }
                    string id1 = id.Substring(0, 1);
                    string id2 = id.Substring(1);
                    int s = Convert.ToInt32(id2);
                    int s1 = s + 1;
                    string id3 = id1 + s1.ToString();
                    txtCompnayCode.Text = id3;

                }
                else
                {
                    MessageBox.Show("Details save not successfully");

                }
                // }

            }
            makeblank();
            //btnList.Enabled = true;
            //ComDetails.SelectedIndex = 0;
            txtwonername.Focus();
        }


        private void btnList_Click(object sender, EventArgs e)
        {
            //txtSearch.Text = "";
            //ComDetails.TabIndex = 0;
            //panel1.Visible = true;
            //string selectQuery1 = "select cd.CompnayId as [Company ID], cd.OnerName as[Owner Name], cd.Name as[Company Name] ,cd.Address,cd.City,cd.State,cd.Zip,cd.Country,cd.Email as[E-Mail],cd.WebAddress as[Web Address],cd.Phone,cd.Mobile,cd.Fax,cd.PANNO as[PAN No],cd.GSTNO as[GST No],cd.Description,cd.RagistrationDate as[Creation Date],cd.Isactive as [Active] from CompnayDetails cd ";
            //DataTable dt = dbMainClass.getDetailByQuery(selectQuery1);
            //dataGridView1.DataSource = dt;
            //tabindex1();
            //// panel1.Visible = false;

        }
        private void setdetails1(DataGridViewCellCollection cellcolection)
        {
            try
            {
                txtCompnayCode.Text = cellcolection[0].Value.ToString();
                txtwonername.Text = cellcolection[1].Value.ToString();
                txtCompnayName.Text = cellcolection[2].Value.ToString();
                txtCompnayAddress.Text = cellcolection[3].Value.ToString();
                txtCity.Text = cellcolection[4].Value.ToString();
                cmbState.Text = cellcolection[5].Value.ToString();
                txtZip.Text = cellcolection[6].Value.ToString();
                txtCountry.Text = cellcolection[7].Value.ToString();
                txtEmailAddress.Text = cellcolection[8].Value.ToString();
                txtWebSite.Text = cellcolection[9].Value.ToString();
                txtPhone.Text = cellcolection[10].Value.ToString();
                txtMobile.Text = cellcolection[11].Value.ToString();
                txtFax.Text = cellcolection[12].Value.ToString();
                txtPanNo.Text = cellcolection[13].Value.ToString();
                txtGst.Text = cellcolection[14].Value.ToString();
                txtDescription.Text = cellcolection[15].Value.ToString();
                //combComp.Text = cellcolection[16].Value.ToString();
                //txtTexAmount.Text = cellcolection[17].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }


        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

            //int currentIndex = dataGridView1.CurrentRow.Index;
            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
            //    {
            //        //if (dataGridView1.RowCount == currentIndex + 1)
            //        //    currentIndex = currentIndex + 1;
            //        DataGridViewCellCollection cellcollection = dataGridView1.Rows[currentIndex].Cells;
            //        if (!string.IsNullOrEmpty(cellcollection[0].Value.ToString()))
            //        {
            //            setdetails1(cellcollection);
            //            panel1.Visible = false;
            //            txtwonername.Focus();
            //            tabindex2();

            //        }
            //    }
            //}
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
        //    btnList.Enabled = false;
        //    updatecounter = 1;
        //    int currentIndex = dataGridView1.CurrentRow.Index;
        //    DataGridViewCellCollection cellcollection = dataGridView1.Rows[currentIndex].Cells;
        //    if (!string.IsNullOrEmpty(cellcollection[0].Value.ToString()))
        //    {
        //        setdetails1(cellcollection);
        //        panel1.Visible = false;
        //        txtwonername.Focus();
        //        tabindex2();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Select proper row");
        //    }
        //}

        //private void butUpdate_Click_1(object sender, EventArgs e)
        //{
        //    updatecounter = 1;
        //    int currentIndex = dataGridView1.CurrentRow.Index;
        //    DataGridViewCellCollection cellcollection = dataGridView1.Rows[currentIndex].Cells;
        //    if ((string)dataGridView1.SelectedRows[0].Cells[0].Value == null)
        //    {
        //        MessageBox.Show("Select proper row");
        //    }
        //    else
        //    {

        //        //setdetails1(cellcollection);
        //        panel1.Visible = false;
        //        txtwonername.Focus();
        //        btnList.Enabled = false;
        //        tabindex2();
        //    }


        }

        private void butAddNewRecord_Click_1(object sender, EventArgs e)
        {
            //panel1.Visible = false;
            txtwonername.Focus();
            tabindex2();
        }

        //private void txtSearch_TextChanged_1(object sender, EventArgs e)
        //{
        //    string s = ComDetails.SelectedValue.ToString();
        //    string selectQuery1 = "select cd.CompnayId as[Company ID], cd.OnerName as[Owner Name], cd.Name as[Company Name] ,cd.Address,cd.City,cd.State,cd.Zip,cd.Country,cd.Email as[E-Mail],cd.WebAddress as[Web Address],cd.Phone,cd.Mobile,cd.Fax,cd.PANNO as[PAN NO],cd.GSTNO as[GST NO] from CompnayDetails cd  where " + s + " like '" + txtSearch.Text + "%'";
        //    DataTable dt = dbMainClass.getDetailByQuery(selectQuery1);
        //    dataGridView1.DataSource = dt;
        //}

        private void butClose_Click(object sender, EventArgs e)
        {
            //panel1.Visible = false;
            txtwonername.Focus();
            tabindex2();
        }

        //private void dataGridView1_KeyPress_1(object sender, KeyPressEventArgs e)
        //{
        //    btnList.Enabled = false;
        //    int currentIndex = dataGridView1.CurrentRow.Index;
        //    if (currentIndex == 0)
        //    {
        //        MessageBox.Show("please select your proper row");
        //        currentIndex = currentIndex + 1;
        //    }
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        updatecounter = 1;
        //        DataGridViewCellCollection cellcollection = dataGridView1.Rows[currentIndex - 1].Cells;
        //        if (!string.IsNullOrEmpty(cellcollection[0].Value.ToString()))
        //        {
        //            setdetails1(cellcollection);
        //            panel1.Visible = false;
        //            txtwonername.Focus();
        //            tabindex2();
        //        }
        //    }
        //}


        private void button1_Click(object sender, EventArgs e)
        {
            Tex t = new Tex(this.combComp, TexList);
            t.Show();

            // t.MdiParent = this;
            dtpdate.TabStop = false;
            btnSave.Focus();
            return;
        }

        private void combComp_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB_Main.taxName = combComp.SelectedItem.ToString();
            string selectName = "select TexAmount from CompnayTex where TexName='" + DB_Main.taxName + "'";
            DataTable dt = dbMainClass.getDetailByQuery(selectName);
            foreach (DataRow dr in dt.Rows)
            {
                txtTexAmount.Text = dr[0].ToString();
            }

        }

        private void txtTexAmount_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtTexAmount.Text == "0.00")
            {
                txtTexAmount.Text = "";
            }
        }

        private void txtTexAmount_Leave(object sender, EventArgs e)
        {
            decimal x;
            if (decimal.TryParse(txtTexAmount.Text, out x))
            {
                if (txtTexAmount.Text.IndexOf('.') != -1 && txtTexAmount.Text.Split('.')[1].Length > 2)
                {
                    MessageBox.Show("The maximum decimal points are 2!");
                    txtTexAmount.Focus();
                }
                else txtTexAmount.Text = x.ToString("0.00");
            }
            else
            {
                txtTexAmount.Text = "0.00";
                //MessageBox.Show("Data invalid!");
                //txtVenderOpeningBal.Focus();
            }
            /*if (txtTexAmount.Text == "")
            {
                txtTexAmount.Text = "0";
            }*/
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
       

        private void Company_New_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "S")
            {

                Comp_SaveDetails();
            }
            /*if (e.KeyCode == Keys.F2)
            {
                txtSearch.Text = "";
                ComDetails.TabIndex = 0;
                panel1.Visible = true;
                string selectQuery1 = "select cd.CompnayId as[Company Id], cd.OnerName as[Owner Name], cd.Name as[Company Name] ,cd.Address,cd.City,cd.State,cd.Zip,cd.Country,cd.Email as[E-Mail],cd.WebAddress as[Web Address],cd.Phone,cd.Mobile,cd.Fax,cd.Description,cd.PANNO as[PAN No],cd.VATNO as[VAT No],cd.CSTNO as[CST No],cd.ServiceTaxAmmount as[Service Tax Ammount],cd.ExciseTaxAmmount as[Excise Tax Ammount],cd.GSTTaxAmmount as[GST Tax Ammount],cd.Isactive,cd.RagistrationDate as[Ragistrtion Date],ct.TexName as[Tax Name],ct.TexAmount as[Tax Ammount] from CompnayDetails cd join CompnayTex ct on ct.TexId=cd.TexId ";
                DataTable dt = dbMainClass.getDetailByQuery(selectQuery1);
                dataGridView1.DataSource = dt;
                tabindex1();
                // panel1.Visible = false;
            }*/
        }

      

        private void txtZip_KeyPress(object sender, KeyPressEventArgs e)
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
                    MessageBox.Show("Plese enter numeric value!");
                }
            }
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        private void txtEmailAddress_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;

            if (txtEmailAddress.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(txtEmailAddress.Text.Trim()))
                {

                    MessageBox.Show("E-mail address format is not correct.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtEmailAddress.Focus();

                }

            }

        }

        private void txtWebSite_Leave(object sender, EventArgs e)
        {
            //Regex mRegxExpression;

      bool isValidUrl= Uri.IsWellFormedUriString(txtWebSite.Text, UriKind.Absolute);
      if (!isValidUrl) 
      {
                  MessageBox.Show("Web site format is not correct.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  txtWebSite.Focus();
      }
          
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
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
                    MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
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
                    MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
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
                    MessageBox.Show("Plese enter numeric value!");

                }
            }
        }

        private void txtTexAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txtTexAmount.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }

            /*string value = txtTexAmount.Text;
            bool moreThanOneDecimalChar = false;
            int g = 0;
            char h = '.';
            for (int a = 0; a < value.Length; a++)
            {
                if (value[a] == '.')
                {
                    g++;
                }
            }
            if (g == 1)
            {
                moreThanOneDecimalChar = true;
            }
            if (moreThanOneDecimalChar == false || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else if (Char.IsLetter(e.KeyChar) || (moreThanOneDecimalChar && e.KeyChar == '.') || Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }*/
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void combComp_DropDown(object sender, EventArgs e)
        {

            if (combComp.Items[0].ToString() == "Select  Tax")
            {
                combComp.Items.RemoveAt(0);
            }
            //else if (combComp.Items[0].ToString() != "Select  Tax")
            //{
            //    combComp.Items.Insert(0,"Select  Tax");
            //}
        }

        private void combComp_Leave(object sender, EventArgs e)
        {
            if ((combComp.Items[0].ToString() != "Select  Tax") && (combComp.SelectedItem == null))
            {
                combComp.Items.Insert(0, "Select  Tax");
                combComp.SelectedIndex = 0;
            }
            else if (combComp.SelectedItem != null)
            {
                DB_Main.taxName = combComp.SelectedItem.ToString();
            }
        }

        private void cmbState_Leave(object sender, EventArgs e)
        {
            if (cmbState.SelectedIndex < 0)
            {
                cmbState.SelectedIndex = 0;
            } 
        }

        private void txtwonername_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && e.KeyChar == (char)Keys.Delete && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtCompnayName_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = e.KeyChar != (char)Keys.Back && e.KeyChar == (char)Keys.Delete && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtCompnayAddress_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = e.KeyChar != (char)Keys.Back && e.KeyChar == (char)Keys.Delete && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = e.KeyChar != (char)Keys.Back && e.KeyChar == (char)Keys.Delete && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void cmbState_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbState.SelectedItem == "Something")
            {
                cmbState.Text = "Something";
            }
            else
            {
                cmbState.Text = "";
                //cmbState.Items.Clear();
            }
        }

        public string email { get; set; }

        private void txtPanNo_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void txtPanNo_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;

            if (txtPanNo.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex("[A-Z]{5}[0-9]{4}[A-Z]{1}");
                if (!mRegxExpression.IsMatch(txtPanNo.Text.Trim()))
                {
                    txtPanNo.Focus();
                    MessageBox.Show("Pan Card  format is not correct", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void txtGst_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (txtGst.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex("[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[0-9]{1}[Z]{1}[0-9]{1}$");
                if (!mRegxExpression.IsMatch(txtGst.Text.Trim()))
                {
                    txtGst.Focus();
                    MessageBox.Show("Gst in format is not correct", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            string selectquery = "select * from CompnayDetails";
            DataTable dt = dbMainClass.getDetailByQuery(selectquery);
            if (dt.Rows.Count == null)
            {
                txtCompnayCode.Text = "C1";
            }
            if (dt.Rows.Count > 0)
            {
                txtCompnayCode.Text = dt.Rows[0]["CompnayId"].ToString();
                txtwonername.Text = dt.Rows[0]["OnerName"].ToString();
                txtCompnayName.Text = dt.Rows[0]["Name"].ToString();
                txtCompnayAddress.Text = dt.Rows[0]["Address"].ToString();
                txtCity.Text = dt.Rows[0]["City"].ToString();
                cmbState.Text = dt.Rows[0]["State"].ToString();
                txtZip.Text = dt.Rows[0]["Zip"].ToString();
                txtCountry.Text = dt.Rows[0]["Country"].ToString();
                txtEmailAddress.Text = dt.Rows[0]["Email"].ToString();
                txtWebSite.Text = dt.Rows[0]["WebAddress"].ToString();
                txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                txtFax.Text = dt.Rows[0]["Fax"].ToString();
                txtPanNo.Text = dt.Rows[0]["PANNO"].ToString();
                txtGst.Text = dt.Rows[0]["GSTNo"].ToString();
                txtDescription.Text = dt.Rows[0]["Description"].ToString();
                makeblank1();
                txtwonername.Focus();
            }          
        }
    }
}