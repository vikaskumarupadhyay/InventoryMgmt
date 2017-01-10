using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Compnay : Form
    {
        DB_Main d = new DB_Main();
        public int updatecounter = 0;
        public Compnay()
        {
            InitializeComponent();
        }
       

        private void Compnay_Load(object sender, EventArgs e)
        {
            // txtCompnayCode.Text = "C";
            //    string id1 = d.getUniqueID("CompnayDetails");
            //    txtCompnayCode.Text = id1;
            string selectQuery1 = "select Name as[Name],Address,City,State,Zip,Country,Email,WebAddress,Phone,Mobile,Fax,Description,PANNO,VATNO,CSTNO,ServiceTaxAmmount,ExciseTaxAmmount,GSTTaxAmmount,Isactive,RagistrationDate from CompnayDetails";
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


        }
        private void makeblank()
        {
            txtCompnayCode.Text = "C";
            txtCompnayName.Text = "";
            txtCompnayAddress.Text = "";
            txtCity.Text = "";
            txtState.Text="";
            txtZip.Text = "";
            txtCountry.Text="";
            txtEmailAddress.Text = "";
            txtWebSite.Text = "";
            txtPhone.Text = "";
            txtMobile.Text = "";
            txtFax.Text = "";
            txtPanNo.Text = "";
            txtVatNo.Text="";
            txtCstNo.Text="";
            txtExcise.Text="";
            txtSarvice.Text = "";
            txtGst.Text = "";
            txtDescription.Text = "";
            

        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (updatecounter == 0)
            {
                string insertquery = "insert into CompnayDetails (Name,Address,City,State,Zip,Country,Email,WebAddress,Phone,Mobile,Fax,PANNO,VATNO,CSTNO,ServiceTaxAmmount,ExciseTaxAmmount,GSTTaxAmmount,Description,RagistrationDate )Values('" + txtCompnayName.Text + "','" + txtCompnayAddress.Text + "','" + txtCity.Text + "','" + txtState.Text + "','" + txtZip.Text + "','" + txtCountry.Text + "','" + txtEmailAddress.Text + "','" + txtWebSite.Text + "','" + txtPhone.Text + "','" + txtMobile.Text + "','" + txtFax.Text + "','" + txtPanNo.Text + "','" + txtVatNo.Text + "','" + txtCstNo.Text + "','" + txtSarvice.Text + "','" + txtExcise.Text + "','" + txtGst.Text + "','" + txtDescription.Text + "','" + dtpdate.Text + "')";
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
            else if (updatecounter == 1)
            {
                string updatecommand = "update CompnayDetails set Name='" + txtCompnayName.Text + "',Address='" + txtCompnayAddress.Text + "',City='" + txtCity.Text + "',State='" + txtState.Text + "',Zip='" + txtZip.Text + "',Country='" + txtCountry.Text + "',Email='" + txtEmailAddress.Text + "',WebAddress='" + txtWebSite.Text + "',Phone='" + txtPhone.Text + "',Mobile='" + txtMobile.Text + "',Fax='" + txtFax.Text + "',Description='" + txtDescription.Text + "',PANNO='" + txtPanNo.Text + "',VATNO='" + txtVatNo.Text + "',CSTNO='" + txtCstNo.Text + "',ServiceTaxAmmount='" + txtSarvice.Text + "',ExciseTaxAmmount='" + txtExcise.Text + "',GSTTaxAmmount='" + txtGst.Text + "',RagistrationDate='" + dtpdate.Text + "'";
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

        private void butAddNewRecord_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            string selectQuery1 = "select CompnayId, Name ,Address,City,State,Zip,Country,Email,WebAddress,Phone,Mobile,Fax,Description,PANNO,VATNO,CSTNO,ServiceTaxAmmount,ExciseTaxAmmount,GSTTaxAmmount,Isactive,RagistrationDate from CompnayDetails";

            DataTable dt = d.getDetailByQuery(selectQuery1);
            dataGridView1.DataSource = dt;
           // panel1.Visible = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string s = ComDetails.SelectedValue.ToString();
            string selectQuery1 = "select CompnayId, Name ,Address,City,State,Zip,Country,Email,WebAddress,Phone,Mobile,Fax,Description,PANNO,VATNO,CSTNO,ServiceTaxAmmount,ExciseTaxAmmount,GSTTaxAmmount,Isactive,RagistrationDate from CompnayDetails where " + s+ " like '" + txtSearch.Text + "%'";

            DataTable dt = d.getDetailByQuery(selectQuery1);
            dataGridView1.DataSource = dt;
        }
        private void setdetails(DataGridViewCellCollection cellcolection)
        {
            try
            {
                txtCompnayCode.Text = cellcolection[0].Value.ToString();
                txtCompnayName.Text = cellcolection[1].Value.ToString();
                txtCompnayAddress.Text = cellcolection[2].Value.ToString();
                txtCity.Text = cellcolection[3].Value.ToString();
                txtState.Text = cellcolection[4].Value.ToString();
                txtZip.Text = cellcolection[5].Value.ToString();
                txtCountry.Text = cellcolection[6].Value.ToString();
                txtEmailAddress.Text = cellcolection[7].Value.ToString();
                txtWebSite.Text = cellcolection[8].Value.ToString();
                txtPhone.Text = cellcolection[9].Value.ToString();
                txtMobile.Text = cellcolection[10].Value.ToString();
                txtFax.Text = cellcolection[11].Value.ToString();
                txtPanNo.Text = cellcolection[12].Value.ToString();
                txtVatNo.Text = cellcolection[13].Value.ToString();
                txtCstNo.Text = cellcolection[14].Value.ToString();
                txtSarvice.Text = cellcolection[15].Value.ToString();
                txtExcise.Text = cellcolection[16].Value.ToString();
                txtGst.Text = cellcolection[17].Value.ToString();
                txtDescription.Text = cellcolection[18].Value.ToString();
             }
            catch(Exception ex)
            {
            }
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            updatecounter = 1;
            DataGridViewCellCollection cellcollection = dataGridView1.Rows[0].Cells;
            setdetails(cellcollection);
            panel1.Visible = false;
         
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            updatecounter = 1;
            DataGridViewCellCollection cellcollection = dataGridView1.Rows[0].Cells;
            setdetails(cellcollection);
            panel1.Visible = false;
        }

       

    }
}
