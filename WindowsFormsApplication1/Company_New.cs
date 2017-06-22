﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelLibrary.SpreadSheet;

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
            string selectqurry = "select cd.CompnayId as[Company ID], cd.OnerName as[Owner Name], cd.Name as[Company Name] ,cd.Address,cd.City,cd.State,cd.Zip,cd.Country,cd.Email as[E-Mail],cd.WebAddress as[Web Address],cd.Phone,cd.Mobile,cd.Fax,cd.PANNO as[PAN NO],cd.VATNO as[VAT NO],cd.CSTNO as[CST NO],cd.ServiceTaxAmmount as[SERVICE TAX NO],cd.ExciseTaxAmmount as[EXCISE NO],cd.GSTTaxAmmount as[GST NO] from CompnayDetails cd join CompnayTex ct on ct.TexId=cd.TexId";
            string selectqurryForActualColumnName = "select top 1 cd.CompnayId, cd.OnerName, cd.Name ,cd.Address,cd.City,cd.State,cd.Zip,cd.Country,cd.Email,cd.WebAddress,cd.Phone,cd.Mobile,cd.Fax,cd.PANNO,cd.VATNO,cd.CSTNO,cd.ServiceTaxAmmount,cd.ExciseTaxAmmount,cd.GSTTaxAmmount from CompnayDetails cd join CompnayTex ct on ct.TexId=cd.TexId";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            DataTable dtOnlyColumnName = dbMainClass.getDetailByQuery(selectqurryForActualColumnName);
            DataTable customDataTable = new DataTable();
            customDataTable.Columns.Add("ActualTableColumnName");
            customDataTable.Columns.Add("AliasTableColumnName");
            //List<string> ls = new List<string>();
            DataColumnCollection d = dt.Columns;
            DataColumnCollection dataColumnForName = dtOnlyColumnName.Columns;
            for (int a = 1; a <d.Count; a++)
            {
                //DataColumn dc = new DataColumn();
                string b = d[a].ToString();
                string actualColumnName = dataColumnForName[a].ToString();
                DataRow dr = customDataTable.NewRow();
                dr["ActualTableColumnName"] = actualColumnName;
                dr["AliasTableColumnName"] = b;
                customDataTable.Rows.Add(dr);
                //  ls.Add(b);
            }

            ComDetails.DataSource = customDataTable;
            ComDetails.ValueMember = "ActualTableColumnName";
            ComDetails.DisplayMember = "AliasTableColumnName";
            dataGridView1.DataSource = dt;

            panel1.Visible = false;
            string selectqury = "select max (CompnayId)  from compnaydetails";
            DataTable dt1 = dbMainClass.getDetailByQuery(selectqury);
            string id = "";
            foreach (DataRow dr in dt1.Rows)
            {
                id = dr[0].ToString();
            }
            if (id == "")
            {
                id = "1";
                txtCompnayCode.Text = "C" + id;
            }
            else
            {
                string id1 = id.Substring(0,1);
                string id2 = id.Substring(1);
                int s = Convert.ToInt32(id2);
                int s1 = s + 1;
                string id3 = id1 + s1.ToString();
                txtCompnayCode.Text = id3;
            }
          txtwonername.Focus();
          string selectCommandGroup = "select TexId,TexName,TexAmount,TexDescription from dbo.CompnayTex";
          setItemGroupDetail(selectCommandGroup, combComp,"Tax");
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
                cmb.Items.Add("Add New " + Message);
            }
            cmb.SelectedIndex = 0;
        }
        private void makeblank()
        {
            //txtCompnayCode.Text = "C";
            txtwonername.Text = "";
            txtCompnayName.Text = "";
            txtCompnayAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
            txtCountry.Text = "";
            txtEmailAddress.Text = "";
            txtWebSite.Text = "";
            txtPhone.Text = "";
            txtMobile.Text = "";
            txtFax.Text = "";
            txtPanNo.Text = "";
            txtVatNo.Text = "";
            txtCstNo.Text = "";
            txtExcise.Text = "";
            txtSarvice.Text = "";
            txtGst.Text = "";
            txtDescription.Text = "";
            txtGst.Text = "";
            combComp.SelectedIndex = 0;
            txtTexAmount.Text = "0";

        }
        private void tabindex1()
        {
            txtSearch.Focus();
            txtSearch.TabIndex = 1;
            dataGridView1.TabIndex = 2;
            butUpdate.TabIndex = 3;
            butAddNewRecord.TabIndex = 4;
            btnPrint.TabIndex = 5;
            btnExportToExcel.TabIndex = 6;
            btnClose.TabIndex = 7;
            tabindex();
        }
   private void tabindex()
        {
            txtCompnayCode.TabStop = false;
            txtwonername.TabStop = false;
            txtCompnayName.TabStop = false;
            txtCompnayAddress.TabStop =false;
            txtCity.TabStop = false;
            txtState.TabStop = false;
            txtZip.TabStop= false;
            txtCountry.TabStop =false;
            txtEmailAddress.TabStop = false;
            txtWebSite.TabStop = false;
            txtPhone.TabStop = false;
            txtMobile.TabStop = false;
            txtFax.TabStop= false;
            txtPanNo.TabStop = false;
            txtVatNo.TabStop = false;
            txtCstNo.TabStop = false;
            txtExcise.TabStop = false;
            txtSarvice.TabStop= false;
            txtGst.TabStop = false;
            txtDescription.TabStop = false;
            btnSave.TabStop = false;
            btnClose.TabStop = false;
            btnList.TabStop = false;
            dtpdate.TabStop = false;
            combComp.TabStop = false;
            txtTexAmount.TabStop = false;
            //txtGst.TabStop = false;
           groupBox2.TabStop =false;
           groupBox1.TabStop = false;
           btnTex.TabStop = false;
        }
 

   private void tabindex2()
   {
       
       btnClose.TabIndex = 29;
       //txtCompnayCode.TabStop = false;
      txtwonername.TabStop = true;
       txtCompnayName.TabStop =true;
       txtCompnayAddress.TabStop = true;
       txtCity.TabStop = true;
       txtState.TabStop = true;
       txtZip.TabStop = true;
       txtCountry.TabStop = true;
       txtEmailAddress.TabStop = true;
       txtWebSite.TabStop = true;
       txtPhone.TabStop = true;
       txtMobile.TabStop = true;
       txtFax.TabStop = true;
       txtPanNo.TabStop = true;
       txtVatNo.TabStop = true;
       txtCstNo.TabStop = true;
       txtExcise.TabStop = true;
       txtSarvice.TabStop = true;
       txtGst.TabStop = true;
       txtDescription.TabStop = true;
       combComp.TabStop = true;
       txtTexAmount.TabStop = true;
       btnTex.TabStop = true;
       txtGst.TabStop = true;
       btnSave.TabStop = true;
       btnList.TabStop = true;
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
            string taxId = "";
            if (combComp.SelectedIndex != 0)
            {
                string name = combComp.SelectedItem.ToString();
                //taxId = TexList[combComp.SelectedIndex-1];
               string select=" select TexId from CompnayTex where TexName='"+name+"'";
               DataTable dt1 = dbMainClass.getDetailByQuery(select);
               foreach (DataRow dr in dt1.Rows)
               {
                   taxId = dr[0].ToString();
               }


            }
            if (updatecounter == 0)
            {
                if (txtCompnayCode.Text == "C1")
                {
                    string insertquery = "insert into CompnayDetails Values ('" + txtCompnayCode.Text + "','" + txtwonername.Text + "','" + txtCompnayName.Text + "','" + txtCompnayAddress.Text + "','" + txtCity.Text + "','" + txtState.Text + "','" + txtZip.Text + "','" + txtCountry.Text + "','" + txtEmailAddress.Text + "','" + txtWebSite.Text + "','" + txtPhone.Text + "','" + txtMobile.Text + "','" + txtFax.Text + "','" + txtPanNo.Text + "','" + txtVatNo.Text + "','" + txtCstNo.Text + "','" + txtSarvice.Text + "','" + txtExcise.Text + "','" + txtGst.Text + "','" + txtDescription.Text + "','" + taxId + "','" + true + "','" + dtpdate.Value.ToString() + "')";
                    int insertrow = dbMainClass.saveDetails(insertquery);
                    if (insertrow > 0)
                    {
                        MessageBox.Show("Details save successfully");
                    }
                    else
                    {
                        MessageBox.Show("Details Not Save successfully");
                    }
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
                    MessageBox.Show("You can not create more than one company!");
                }
            }
            if (updatecounter == 1)
            {
                string updatecommand = "update CompnayDetails set OnerName='" + txtwonername.Text + "', Name='" + txtCompnayName.Text + "',Address='" + txtCompnayAddress.Text + "',City='" + txtCity.Text + "',State='" + txtState.Text + "',Zip='" + txtZip.Text + "',Country='" + txtCountry.Text + "',Email='" + txtEmailAddress.Text + "',WebAddress='" + txtWebSite.Text + "',Phone='" + txtPhone.Text + "',Mobile='" + txtMobile.Text + "',Fax='" + txtFax.Text + "',PANNO='" + txtPanNo.Text + "',VATNO='" + txtVatNo.Text + "',CSTNO='" + txtCstNo.Text + "',ServiceTaxAmmount='" + txtSarvice.Text + "',ExciseTaxAmmount='" + txtExcise.Text + "',GSTTaxAmmount='" + txtGst.Text + "',Description='" + txtDescription.Text + "',RagistrationDate='" + dtpdate.Value.ToString() + "', TexId='" + taxId + "' where CompnayId='" + txtCompnayCode.Text + "' ";
                int updatequrry = dbMainClass.saveDetails(updatecommand);
                if (updatequrry > 0)
                {
                    string updateTax = "update CompnayTex set TexAmount='" + txtTexAmount.Text + "' where TexId='" + taxId + "'";
                    int updatequrry1 = dbMainClass.saveDetails(updateTax);
                    if (updatequrry1 > 0)
                    {
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
                        makeblank();
                    }
                }
               
            }
            btnList.Enabled = true;
            ComDetails.SelectedIndex = 0;
            txtwonername.Focus();
        }


        private void btnList_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            ComDetails.TabIndex = 0;
            panel1.Visible = true;
            string selectQuery1 = "select cd.CompnayId as [Company ID], cd.OnerName as[Owner Name], cd.Name as[Company Name] ,cd.Address,cd.City,cd.State,cd.Zip,cd.Country,cd.Email as[E-Mail],cd.WebAddress as[Web Address],cd.Phone,cd.Mobile,cd.Fax,cd.PANNO as[PAN No],cd.VATNO as[VAT No],cd.CSTNO as[CST No],cd.ServiceTaxAmmount as[SERVICE TAX NO],cd.ExciseTaxAmmount as[EXCISE NO],cd.GSTTaxAmmount as[GST NO],cd.Description,ct.TexName as[Tax Name],ct.TexAmount as[Tax Ammount (%)],cd.RagistrationDate as[Creation Date],cd.Isactive as [Active] from CompnayDetails cd join CompnayTex ct on ct.TexId=cd.TexId ";
            DataTable dt = dbMainClass.getDetailByQuery(selectQuery1);
            dataGridView1.DataSource = dt;
            tabindex1();
            // panel1.Visible = false;
           
        }
        private void setdetails(DataGridViewCellCollection cellcolection)
        {
            try
            {
                txtCompnayCode.Text = cellcolection[0].Value.ToString();
                txtwonername.Text = cellcolection[1].Value.ToString();
                txtCompnayName.Text = cellcolection[2].Value.ToString();
                txtCompnayAddress.Text = cellcolection[3].Value.ToString();
                txtCity.Text = cellcolection[4].Value.ToString();
                txtState.Text = cellcolection[5].Value.ToString();
                txtZip.Text = cellcolection[6].Value.ToString();
                txtCountry.Text = cellcolection[7].Value.ToString();
                txtEmailAddress.Text = cellcolection[8].Value.ToString();
                txtWebSite.Text = cellcolection[9].Value.ToString();
                txtPhone.Text = cellcolection[10].Value.ToString();
                txtMobile.Text = cellcolection[11].Value.ToString();
                txtFax.Text = cellcolection[12].Value.ToString();
                txtPanNo.Text = cellcolection[13].Value.ToString();
                txtVatNo.Text = cellcolection[14].Value.ToString();
                txtCstNo.Text = cellcolection[15].Value.ToString();
                txtSarvice.Text = cellcolection[16].Value.ToString();
                txtExcise.Text = cellcolection[17].Value.ToString();
                txtGst.Text = cellcolection[18].Value.ToString();
                txtDescription.Text = cellcolection[19].Value.ToString();
                combComp.Text = cellcolection[20].Value.ToString();
                txtTexAmount.Text = cellcolection[21].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }


        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
             int currentIndex = dataGridView1.CurrentRow.Index;
             if (e.KeyChar == (char)Keys.Enter)
             {
                 if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
                 {
                     //if (dataGridView1.RowCount == currentIndex + 1)
                     //    currentIndex = currentIndex + 1;
                     DataGridViewCellCollection cellcollection = dataGridView1.Rows[currentIndex].Cells;
                     if (!string.IsNullOrEmpty(cellcollection[0].Value.ToString()))
                     {
                         setdetails(cellcollection);
                         panel1.Visible = false;
                         txtwonername.Focus();
                         tabindex2();

                     }
                 }
             }
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            btnList.Enabled = false;
            updatecounter = 1;
            int currentIndex = dataGridView1.CurrentRow.Index;
            DataGridViewCellCollection cellcollection = dataGridView1.Rows[currentIndex].Cells;
            if (!string.IsNullOrEmpty(cellcollection[0].Value.ToString()))
            {
                setdetails(cellcollection);
                panel1.Visible = false;
                txtwonername.Focus();
                tabindex2();
            }
            else
            {
                MessageBox.Show("Select proper row");
            }
        }

        private void butUpdate_Click_1(object sender, EventArgs e)
        {
            updatecounter = 1;
            int currentIndex = dataGridView1.CurrentRow.Index;
            DataGridViewCellCollection cellcollection = dataGridView1.Rows[currentIndex].Cells;
            if ((string)dataGridView1.SelectedRows[0].Cells[0].Value==null)
            {
                MessageBox.Show("Select proper row");
            }
            else
            {

                setdetails(cellcollection);
                panel1.Visible = false;
                txtwonername.Focus();
                btnList.Enabled = false;
                tabindex2();
            }
           
           
        }

        private void butAddNewRecord_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            txtwonername.Focus();
            tabindex2();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            string s = ComDetails.SelectedValue.ToString();
            string selectQuery1 = "select cd.CompnayId as[Company ID], cd.OnerName as[Owner Name], cd.Name as[Company Name] ,cd.Address,cd.City,cd.State,cd.Zip,cd.Country,cd.Email as[E-Mail],cd.WebAddress as[Web Address],cd.Phone,cd.Mobile,cd.Fax,cd.PANNO as[PAN NO],cd.VATNO as[VAT NO],cd.CSTNO as[CST NO],cd.ServiceTaxAmmount as[SERVICE TAX NO],cd.ExciseTaxAmmount as[EXCISE NO],cd.GSTTaxAmmount as[GST NO] from CompnayDetails cd join CompnayTex ct on ct.TexId=cd.TexId where " + s + " like '" + txtSearch.Text + "%'";

            DataTable dt = dbMainClass.getDetailByQuery(selectQuery1);
            dataGridView1.DataSource = dt;
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            txtwonername.Focus();
            tabindex2();
        }

        private void dataGridView1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            btnList.Enabled = false;
             int currentIndex = dataGridView1.CurrentRow.Index;
             if (e.KeyChar == (char)Keys.Enter)
             {
                 updatecounter = 1;
                 DataGridViewCellCollection cellcollection = dataGridView1.Rows[currentIndex-1].Cells;
                 if (!string.IsNullOrEmpty(cellcollection[0].Value.ToString()))
                 {
                     setdetails(cellcollection);
                     panel1.Visible = false;
                     txtwonername.Focus();
                     tabindex2();
                 }
             }    
        }

       
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
            if (txtTexAmount.Text =="0.00")
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

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.AllowUserToAddRows == true)
            {
                dataGridView1.AllowUserToAddRows = false;
            }
            string FileName = "";
            SaveFileDialog openFileDialog1 = new SaveFileDialog();
            //FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();
            openFileDialog1.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
            openFileDialog1.FileName = "Company Details";
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
                workbook.Save(file);
                dataGridView1.AllowUserToAddRows = true;
            }
            else
            {
                dataGridView1.AllowUserToAddRows = true;
            }
        }

        private void btnList_KeyDown(object sender, KeyEventArgs e)
        {
            
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

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.Focus();
            }
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

        private void txtEmailAddress_Leave(object sender, EventArgs e)
        {
            string email = txtEmailAddress.Text;
            if ((email.LastIndexOf("@") > -1) && (email.LastIndexOf(".") > -1) || string.IsNullOrEmpty(email))
            {
                //MessageBox.Show("Please Enter the Correct Email Address");
            }
            else
            {
                txtEmailAddress.Focus();
                MessageBox.Show("Please enter the email address in correct format!");
            }
        }

        private void txtWebSite_Leave(object sender, EventArgs e)
        {
            string WebSite = txtWebSite.Text;
            if ((WebSite.LastIndexOf("www") > -1) && (WebSite.LastIndexOf(".") > -1) && (WebSite.LastIndexOf("http://") > -1) || string.IsNullOrEmpty(WebSite))
            {
                //MessageBox.Show("Please Enter the Correct Email Address");
            }
            else
            {
                txtWebSite.Focus();
                MessageBox.Show("Please enter the web address in currect format!");
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
            if ((combComp.Items[0].ToString() != "Select  Tax")&&(combComp.SelectedItem == null))
            {
                combComp.Items.Insert(0, "Select  Tax");
                combComp.SelectedIndex = 0;
            }
            else if(combComp.SelectedItem != null)
            {
                DB_Main.taxName = combComp.SelectedItem.ToString();
            }
        }

    }
}