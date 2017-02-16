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
    public partial class Company_New : Form
    {
        DB_Main d = new DB_Main();
        public int updatecounter = 0;
        public List<string> TexList = new List<string>();
        public DataTable dt = new DataTable();
        public Company_New()
        {
            InitializeComponent();
        }


        private void Compnay_Load(object sender, EventArgs e)
        {
            //txtCompnayCode.Focus();
           // btnList.Enabled = false;
            
            // txtCompnayCode.Text = "C";
            //    string id1 = d.getUniqueID("CompnayDetails");
            //    txtCompnayCode.Text = id1;
            dtpdate.TabStop = false;
            string selectQuery1 = "select OnerName, Name as[Name],Address,City,State,Zip,Country,Email,WebAddress,Phone,Mobile,Fax,PANNO,VATNO,CSTNO,ServiceTaxAmmount,ExciseTaxAmmount,GSTTaxAmmount ,Description,VAT,CST,GST,Isactive,RagistrationDate from CompnayDetails";
            DataTable dt1 = d.getDetailByQuery(selectQuery1);
            ComDetails.DataSource = dt1;
            string val = "";
            List<string> ls = new List<string>();
            foreach (DataColumn dr in dt1.Columns)
            {
                val = dr.ColumnName;
                ls.Add(val);

            }
            ComDetails.DataSource = ls;
            panel1.Visible = false;
            string selectqury = "select CompnayId from compnaydetails";
            DataTable dt = d.getDetailByQuery(selectqury);
            string id = "";
            foreach (DataRow dr in dt.Rows)
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
                int s = Convert.ToInt32(id);
                int s1 = s + 1;
                txtCompnayCode.Text = "C" + s1.ToString();
            }
          txtwonername.Focus();
          string selectCommandGroup = "select TexId,TexName,TexAmount,TexDescription from dbo.CompnayTex";
          setItemGroupDetail(selectCommandGroup, combComp, "TEX");
         
            }
        private void setItemGroupDetail(string Query, ComboBox cmb, string Message)
        {
            //string selectCommand = "select groupID,GROUPNAME,GROUPDESC from dbo.ItemGroup";
            cmb.Items.Clear();
            cmb.Items.Add("Select A " + Message);

            dt = d.getDataBoundToComboBox(Query);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cmb.Items.Add(dr[1].ToString().ToUpper());
                    if (Message.ToUpper() == "TEX")
                    {
                        TexList.Add(dr[0].ToString());
                    }
                    else
                    {
                        //GroupList.Add(dr[0].ToString());
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
            txtCompnayCode.Text = "C";
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
            txtvat.Text = "";
            txtcst.Text="";
            txtGst.Text = "";

        }
        private void tabindex1()
        {
            ComDetails.Focus();
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
            txtvat.TabStop = false;
            txtcst.TabStop = false;
            txtGst.TabStop = false;
            textBox3.TabStop = false;
            checkvat.TabStop = false;
            checkcst.TabStop = false;
           checkBox3.TabStop = false;
           txtcst.TabStop = false;
           txtvat.TabStop = false;
           groupBox2.TabStop =false;
           groupBox1.TabStop = false;
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
       
       //dtpdate.TabStop = true;
       txtvat.TabStop = true;
       txtcst.TabStop = true;
       txtGst.TabStop = true;
       textBox3.TabStop = true;
       btnSave.TabStop = true;
       btnList.TabStop = true;
       btnClose.TabStop = true;
       checkvat.TabStop = true;
       checkcst.TabStop = true;
       checkBox3.TabStop =true;
       txtcst.TabStop =true;
       txtvat.TabStop = true;
       textBox3.TabStop = true;
       groupBox2.TabStop = true;
       groupBox1.TabStop = true;

   }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (updatecounter == 0)
            {
                if (string.IsNullOrEmpty(txtvat.Text) == false || string.IsNullOrEmpty(txtcst.Text) == false || string.IsNullOrEmpty(textBox3.Text) == false)
                {
                    string insertquery = "insert into CompnayDetails (OnerName,Name,Address,City,State,Zip,Country,Email,WebAddress,Phone,Mobile,Fax,PANNO,VATNO,CSTNO,ServiceTaxAmmount,ExciseTaxAmmount,GSTTaxAmmount,Description,VAT,CST,GST,RagistrationDate )Values('" + txtwonername.Text + "','" + txtCompnayName.Text + "','" + txtCompnayAddress.Text + "','" + txtCity.Text + "','" + txtState.Text + "','" + txtZip.Text + "','" + txtCountry.Text + "','" + txtEmailAddress.Text + "','" + txtWebSite.Text + "','" + txtPhone.Text + "','" + txtMobile.Text + "','" + txtFax.Text + "','" + txtPanNo.Text + "','" + txtVatNo.Text + "','" + txtCstNo.Text + "','" + txtSarvice.Text + "','" + txtExcise.Text + "','" + txtGst.Text + "','" + txtDescription.Text + "','" + txtvat.Text + "','" + txtcst.Text + "','" + textBox3.Text + "','" + dtpdate.Text + "')";
                    int insertrow = d.saveDetails(insertquery);
                    if (insertrow > 0)
                    {
                        MessageBox.Show("Details Save successfully");
                    }
                    else
                    {
                        MessageBox.Show("Details save not successfully");
                    }

                }
            }
           
            if (updatecounter == 1)
            {
                string updatecommand = "update CompnayDetails set OnerName='" + txtwonername.Text + "', Name='" + txtCompnayName.Text + "',Address='" + txtCompnayAddress.Text + "',City='" + txtCity.Text + "',State='" + txtState.Text + "',Zip='" + txtZip.Text + "',Country='" + txtCountry.Text + "',Email='" + txtEmailAddress.Text + "',WebAddress='" + txtWebSite.Text + "',Phone='" + txtPhone.Text + "',Mobile='" + txtMobile.Text + "',Fax='" + txtFax.Text + "',PANNO='" + txtPanNo.Text + "',VATNO='" + txtVatNo.Text + "',CSTNO='" + txtCstNo.Text + "',ServiceTaxAmmount='" + txtSarvice.Text + "',ExciseTaxAmmount='" + txtExcise.Text + "',GSTTaxAmmount='" + txtGst.Text + "',Description='" + txtDescription.Text + "',VAT='" + txtvat.Text + "',CST='" + txtcst.Text + "',GST='" + textBox3.Text + "',RagistrationDate='" + dtpdate.Value.ToString() + "'";
                int updatequrry = d.saveDetails(updatecommand);
                if (updatequrry > 0)
                {
                    MessageBox.Show("Details Save successfully");
                }
                else
                {
                    MessageBox.Show("Details save not successfully");
                }
            }

            makeblank();
        }


        private void btnList_Click(object sender, EventArgs e)
        {
           
           
           // ComDetails.TabIndex = 1;

            panel1.Visible = true;
            string selectQuery1 = "select CompnayId,OnerName, Name ,Address,City,State,Zip,Country,Email,WebAddress,Phone,Mobile,Fax,Description,PANNO,VATNO,CSTNO,ServiceTaxAmmount,ExciseTaxAmmount,GSTTaxAmmount,VAT,CST,GST,Isactive,RagistrationDate from CompnayDetails";
            DataTable dt = d.getDetailByQuery(selectQuery1);
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
                txtDescription.Text = cellcolection[13].Value.ToString();
                txtPanNo.Text = cellcolection[14].Value.ToString();
                txtVatNo.Text = cellcolection[15].Value.ToString();
                txtCstNo.Text = cellcolection[16].Value.ToString();
                txtSarvice.Text = cellcolection[17].Value.ToString();
                txtExcise.Text = cellcolection[18].Value.ToString();
                txtGst.Text = cellcolection[19].Value.ToString();
                txtvat.Text = cellcolection[20].Value.ToString();
                txtcst.Text = cellcolection[21].Value.ToString();
                textBox3.Text = cellcolection[22].Value.ToString();
                
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
                     if (dataGridView1.RowCount == currentIndex + 1)
                         currentIndex = currentIndex + 1;
                     DataGridViewCellCollection cellcollection = dataGridView1.Rows[0].Cells;
                     setdetails(cellcollection);
                 }
             }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (checkvat.Checked)
            {
               
            }
        }

        private void checkvat_Click(object sender, EventArgs e)
        {
            if (checkvat.Checked)
            {

                txtvat.ReadOnly = false;
                txtcst.ReadOnly = true;
                textBox3.ReadOnly = true;
                checkcst.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkcst_Click(object sender, EventArgs e)
        {
            if (checkcst.Checked)
            {
                txtcst.ReadOnly = false;
                checkvat.Checked = false;
                textBox3.ReadOnly = true;
                checkBox3.Checked = false;
                txtvat.ReadOnly = true;
            }
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                textBox3.ReadOnly = false;
                txtvat.ReadOnly = true;
                txtcst.ReadOnly = true;
                checkvat.Checked = false;
                checkcst.Checked = false;
            }
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            updatecounter = 1;
            DataGridViewCellCollection cellcollection = dataGridView1.Rows[0].Cells;
            setdetails(cellcollection);
            panel1.Visible = false;
            txtwonername.Focus();
            tabindex2();
        }

        private void butUpdate_Click_1(object sender, EventArgs e)
        {
            updatecounter = 1;
            DataGridViewCellCollection cellcollection = dataGridView1.Rows[0].Cells;
            setdetails(cellcollection);
            panel1.Visible = false;
            txtwonername.Focus();
            tabindex2();
        }

        private void butAddNewRecord_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            string s = ComDetails.SelectedValue.ToString();
            string selectQuery1 = "select CompnayId,OnerName, Name ,Address,City,State,Zip,Country,Email,WebAddress,Phone,Mobile,Fax,Description,PANNO,VATNO,CSTNO,ServiceTaxAmmount,ExciseTaxAmmount,GSTTaxAmmount,VAT,CST,GST,Isactive,RagistrationDate from CompnayDetails where " + s + " like '" + txtSearch.Text + "%'";

            DataTable dt = d.getDetailByQuery(selectQuery1);
            dataGridView1.DataSource = dt;
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void dataGridView1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
             int currentIndex = dataGridView1.CurrentRow.Index;
             if (e.KeyChar == (char)Keys.Enter)
             {
                 updatecounter = 1;
                 DataGridViewCellCollection cellcollection = dataGridView1.Rows[currentIndex-1].Cells;
                 setdetails(cellcollection);
                 panel1.Visible = false;
                 txtwonername.Focus();
                 tabindex2();
                 

             }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tex t = new Tex(this.combComp, TexList);
            t.Show();
           // t.MdiParent = this;
        }

        private void combComp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Name = combComp.SelectedItem.ToString();
            string selectName = "select TexAmount from CompnayTex where TexName='" + Name + "'";
            DataTable dt = d.getDetailByQuery(selectName);
            foreach (DataRow dr in dt.Rows)
            {
                txtTexAmount.Text = dr[0].ToString();
            }
        }

    }
}
