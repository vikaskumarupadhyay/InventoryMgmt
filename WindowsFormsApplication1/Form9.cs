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
    public partial class Form9 : Form
    {
        public string orderid9;
        DB_Main dbMainClass = new DB_Main();
        DataTable vendorDetails = new DataTable();
        public Form9()
        {
            InitializeComponent();
        }
        public Form9(string a)
        {
            orderid9 = a;
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            Purchase.PurchaseDetails purChaseDetailObj = new Purchase.PurchaseDetails();
            vendorDetails = purChaseDetailObj.GetVendorDetaisInDataTable();
            panel2.Visible = false;
            txtRefNo.Text = orderid9;
            string select = "select Orderid from CustomerOrderInvoice where InvoiceId='" + orderid9 + "'";
            DataTable dt = dbMainClass.getDetailByQuery(select);
            string orderid="";
            foreach (DataRow dr in dt.Rows)
            {
                orderid = dr[0].ToString();
            }
            string select2="select venderId from VendorOrderDetails where Orderid='"+orderid+"'";
            DataTable dt2 = dbMainClass.getDetailByQuery(select2);
            string vendorid = "";
            foreach (DataRow dr2 in dt2.Rows)
            {
                vendorid = dr2[0].ToString();
            }
            string select1 = "select venderId,vName,vCompName,vAddress,vPhone,vMobile,vFax from VendorDetails where venderId='"+vendorid+"'";
            DataTable dt1 = dbMainClass.getDetailByQuery(select1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                txtvendorId.Text = dr1[0].ToString();
                txtVendorName.Text = dr1[1].ToString();
                txtCompanyName.Text = dr1[2].ToString();
                txtAddress.Text = dr1[3].ToString();
                txtPhone.Text = dr1[4].ToString();
                txtMobile.Text = dr1[5].ToString();
                txtFax.Text = dr1[6].ToString();
            }
            string selectqurry = "select vod.ItemId,ide.ItemName,vod.Price,vod.Quantity,vod.TotalPrice from VendorOrderDesc vod join ItemDetails ide on Vod.ItemId=ide.ItemId where vod.Orderid='" + orderid + "'";
            DataTable dt3 = dbMainClass.getDetailByQuery(selectqurry);
            string selectqurry1 = "select TotalPrice from VendorOrderDetails where Orderid='" + orderid + "'";
            DataTable dt4 = dbMainClass.getDetailByQuery(selectqurry1);
            foreach (DataRow dr3 in dt4.Rows)
            {
                txttotalAmount.Text = dr3[0].ToString();
            }
            dataGridView1.DataSource = dt3;
            string selectqurry5 = "select PaymentId from VendorPayment";
            DataTable dt5 = dbMainClass.getDetailByQuery(selectqurry5);
            string id = "";
            foreach (DataRow dr4 in dt5.Rows)
            {
                id = dr4[0].ToString();
            }
            if (id == "")
            {
                id = "1";
                txtSrNo.Text = id;
            }
            else
            {
                int txt = Convert.ToInt32(id);
                int txt1 = txt + 1;
                txtSrNo.Text = txt1.ToString();
            }
           
        }
        private void setVAlue()
        {
            if (vendorDetails.Rows.Count > 0)
            {
                string vendorId = txtvendorId.Text;
                if (vendorId.Trim() != "" && vendorId != null)
                {
                    DataRow[] dr = vendorDetails.Select("[Vender Id ]='" + vendorId + "'");
                    if (dr != null && dr.Length > 0)
                    {
                        //venderId, , vCompName, vAddress, vCity, vState, vZip, vCountry, vEmail, vWebAddress, vPhone, vMobile, vFax, vDesc
                        string vendorName = dr[0]["Name"].ToString();
                        string vendorAddress = dr[0]["Address"].ToString();
                        string vendorCompName = dr[0]["Compnay Name"].ToString();
                        string vendorPhone = dr[0]["Phone"].ToString();
                        string vendorMobile = dr[0]["Mobile"].ToString();
                        string vendorFax = dr[0]["Fax"].ToString();
                        //string Balance = dr[0]["vCurrentBalance"].ToString();


                        txtVendorName.Text = vendorName;
                        txtAddress.Text = vendorAddress;
                        txtCompanyName.Text = vendorCompName;
                        txtPhone.Text = vendorPhone;
                        txtMobile.Text = vendorMobile;
                        txtFax.Text = vendorFax;
                        //txttotalAmount.Text = Balance;
                    }
                    else
                    {
                        txtVendorName.Text = "";
                        txtAddress.Text = "";
                        txtCompanyName.Text = "";
                        txtPhone.Text = "";
                        txtMobile.Text = "";
                        txtFax.Text = "";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            string selectqurry = "select vd.venderId,vd.vName as NAME,vd.vCompName as COMPNAME,vd.vAddress as ADDRESS,vd.vPhone as PHONE,vd.vMobile as MOBILE,vd.vFax as FAX,vad.vCurrentBalance from VendorDetails vd join VendorAccountDetails vad on vd.venderId=vad.venderId";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            List<string> ls = new List<string>();
            DataColumnCollection d = dt.Columns;
            for (int a = 1; a < d.Count; a++)
            {
                DataColumn dc = new DataColumn();
                string b = d[a].ToString();
                ls.Add(b);
            }
            comboBox1.DataSource = ls;
            dataGridView2.DataSource = dt;

        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            string s = comboBox1.SelectedValue.ToString();
            string m = "v" + s;
            string selectQurry = "select venderId,vName as NAME,vCompName as COMPANYNAME,vAddress as ADDRESS,vPhone as PHONE,vMobile as MOBILE,vFax as FAX from VendorDetails where " + m + " like '" + txtSearch.Text + "%'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            dataGridView2.DataSource = dt;
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            panel2.Visible = false;
            DataGridViewCellCollection call = dataGridView2.Rows[e.RowIndex].Cells;
            setDetails(call);
        }
        private void setDetails(DataGridViewCellCollection cellCollection)
        {
            try
            {
               txtvendorId.Text = cellCollection[0].Value.ToString();
                txtVendorName.Text = cellCollection[1].Value.ToString();
                txtCompanyName.Text = cellCollection[2].Value.ToString();
                txtAddress.Text = cellCollection[3].Value.ToString();
                txtPhone.Text = cellCollection[4].Value.ToString();
                txtMobile.Text = cellCollection[5].Value.ToString();
                txtFax.Text = cellCollection[6].Value.ToString();
                txttotalAmount.Text = cellCollection[7].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtvendorId_TextChanged(object sender, EventArgs e)
        {
            if (txtvendorId.Text.Trim() != "" && txtvendorId.Text.StartsWith("V"))
            {
                setVAlue();
                string selectqurry = "select vCurrentBalance from VendorAccountDetails where venderId='" + txtvendorId.Text + "'";
                DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
                string courntbal = "";
                foreach (DataRow dr in dt.Rows)
                {
                    courntbal = dr[0].ToString();
                }
                txttotalAmount.Text = courntbal;
            }
        }

     
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttSave_Click(object sender, EventArgs e)
        {
            string ChaqueDate = varible.bankDate;
            string BankName = varible.bankname;
            string ChaqueNo = varible.chaqueNo;
            if (txtRefNo.Text == "")
            {
                if (radioBottCash.Checked)
                {
                    string insertqurry = "insert into WithoutRefrencePament values('" + txtvendorId.Text + "','" + txttotalAmount.Text + "','" + txtPayAmount.Text + "','" + txtRemaning.Text + "','" + txtpayDate.Text + "')";
                    int insert1 = dbMainClass.saveDetails(insertqurry);
                    if (insert1 > 0)
                    {
                        int bal2 = vendid1();
                        string updat = "update VendorAccountDetails set vCurrentBalance='" + bal2.ToString() + "' where venderId='" + txtvendorId.Text + "'";
                        int insertrow = dbMainClass.saveDetails(updat);
                        if (insertrow > 0)
                        {
                            MessageBox.Show("Details Saved Successfully");
                        }
                        else
                        {
                            MessageBox.Show("Details Not Saved Successfully");
                        }
                    }
                }

                else if (ChaqueReado.Checked)
                {
                    string insertqurry = "insert into WithoutRefrencePament values('" + txtvendorId.Text + "','" + txttotalAmount.Text + "','" + txtPayAmount.Text + "','" + txtRemaning.Text + "','" + txtpayDate.Text + "'";
                    int insert1 = dbMainClass.saveDetails(insertqurry);
                    if (insert1 > 0)
                    {
                        string insertqurry1 = "insert into ChequePement Values('" + txtSrNo.Text + "','" + ChaqueDate + "','" + BankName + "','" + ChaqueNo + "','" + txtPayAmount.Text + "')";
                        int insertrow = dbMainClass.saveDetails(insertqurry1);
                        if (insertrow > 0)
                        {
                            int bal2 = vendid1();
                            string updat = "update VendorAccountDetails set vCurrentBalance='" + bal2.ToString() + "' where venderId='" + txtvendorId.Text + "'";
                            int insertrow1 = dbMainClass.saveDetails(updat);
                            if (insertrow1 > 0)
                            {

                                MessageBox.Show("Details Saved Successfully");
                            }
                            else
                            {
                                MessageBox.Show("Details Not Saved Successfully");
                            }
                        }
                    }
                }
            }
            if (txtRefNo.Text != "")
            {
               
                if (radioBottCash.Checked)
                {
                    string insertqurrey = "insert into VendorPayment Values('" + txtRefNo.Text + "','" + txttotalAmount.Text + "','" + txtPayAmount.Text + "','" + txtRemaning.Text + "','Cash','" + txtpayDate.Text + "')";
                    int insert = dbMainClass.saveDetails(insertqurrey);
                    if (insert > 0)
                    {
                        int bal2 = vendid();
                        string updat = "update VendorAccountDetails set vCurrentBalance='" + bal2.ToString() + "' where venderId='" + txtvendorId.Text + "'";
                        int insertrow = dbMainClass.saveDetails(updat);
                        if (insertrow > 0)
                        {
                            MessageBox.Show("Details Saved Successfully");
                        }
                        else
                        {
                            MessageBox.Show("Details Not Saved Successfully");
                        }
                    }
                }
                else if (ChaqueReado.Checked)
                {
                    string insertqurrey = "insert into VendorPayment Values('" + txtRefNo.Text + "','" + txttotalAmount.Text + "','" + txtPayAmount.Text + "','" + txtRemaning.Text + "','Chaque','" + txtpayDate.Text + "')";
                    int insert = dbMainClass.saveDetails(insertqurrey);
                    if (insert > 0)
                    {
                        string insertqurry = "insert into ChequePement Values('" + txtSrNo.Text + "','" + ChaqueDate + "','" + BankName + "','" + ChaqueNo + "','" + txtPayAmount.Text + "')";
                        int insertrow = dbMainClass.saveDetails(insertqurry);
                        if (insertrow > 0)
                        {
                            int bal2 = vendid();
                            string updat = "update VendorAccountDetails set vCurrentBalance='" + bal2.ToString() + "' where venderId='" + txtvendorId.Text + "'";
                            int insertrow1 = dbMainClass.saveDetails(updat);
                            if (insertrow1 > 0)
                            {

                                MessageBox.Show("Details Saved Successfully");
                            }
                            else
                            {
                                MessageBox.Show("Details Not Saved Successfully");
                            }
                        }
                    }
                }
            }
               
                makeBlank();
                makeBlank1();
                int id = Convert.ToInt32(txtSrNo.Text);
                int id1 = id + 1;
                txtSrNo.Text = id1.ToString();
        }

        private void txtPayAmount_TextChanged(object sender, EventArgs e)
        {
            if (radioBottCash.Checked)
            {
                int total = Convert.ToInt32(txttotalAmount.Text);
                int payamount = Convert.ToInt32(txtPayAmount.Text);
                int arrearAmount = total - payamount;
                txtRemaning.Text = arrearAmount.ToString();
            }
            else if (ChaqueReado.Checked)
            {
                txtPayAmount.Text = varible.chaqueAmount;
                int total = Convert.ToInt32(txttotalAmount.Text);
                int payamount = Convert.ToInt32(txtPayAmount.Text);
                int arrearAmount = total - payamount;
                txtRemaning.Text = arrearAmount.ToString();
            }
            
        }
        private void makeBlank()
        {
            txtvendorId.Text = "V";
            txtVendorName.Text = "";
            txtAddress.Text = "";
            txtCompanyName.Text = "";
            txtPhone.Text = "";
            txtMobile.Text = "";
            txtFax.Text = "";
            dataGridView1.DataSource = "";
            txttotalAmount.Text = "0";
            txtRemaning.Text = "0";
            txtPayAmount.Text = "0";
            txtRefNo.Text = "";
            radioBottCash.Checked = false;
            ChaqueReado.Checked = false;
            txtPayAmount.Clear();
            txtRemaning.Clear();
        }
        private void makeBlank1()
        {
            checkBox1.Checked = false;
             checkBox2.Checked = false;
        }

        private void txtPayAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
        //    int total = Convert.ToInt32(txttotalAmount.Text);
        //    int payamount = Convert.ToInt32(txtPayAmount.Text);
        //    int arrearAmount = total - payamount;
        //    txtRemaning.Text = arrearAmount.ToString();

        }

        private void txtRefNo_TextChanged(object sender, EventArgs e)
        {
            string refqurry = "select InvoiceId from VendorPayment where InvoiceId ='" +txtRefNo.Text + "'";
            DataTable refdt = dbMainClass.getDetailByQuery(refqurry);
            if (refdt != null && refdt.Rows != null && refdt.Rows.Count > 0)
            {
                buttSave.Enabled = false;
            }
            else
            {
                buttSave.Enabled = true;
            }
            checkBox1.Checked = true; 
            string select = "select Orderid from CustomerOrderInvoice where InvoiceId='" + txtRefNo.Text + "'";
            DataTable dt = dbMainClass.getDetailByQuery(select);
            string orderid = "";
            foreach (DataRow dr in dt.Rows)
            {
                orderid = dr[0].ToString();
            }
            string select2 = "select venderId from VendorOrderDetails where Orderid='" + orderid + "'";
            DataTable dt2 = dbMainClass.getDetailByQuery(select2);
            string vendorid = "";
            foreach (DataRow dr2 in dt2.Rows)
            {
                vendorid = dr2[0].ToString();
            }
            string select1 = "select venderId,vName,vCompName,vAddress,vPhone,vMobile,vFax from VendorDetails where venderId='" + vendorid + "'";
            DataTable dt1 = dbMainClass.getDetailByQuery(select1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                txtvendorId.Text = dr1[0].ToString();
                txtVendorName.Text = dr1[1].ToString();
                txtCompanyName.Text = dr1[2].ToString();
                txtAddress.Text = dr1[3].ToString();
                txtPhone.Text = dr1[4].ToString();
                txtMobile.Text = dr1[5].ToString();
                txtFax.Text = dr1[6].ToString();
            }
            string selectqurry = "select vod.ItemId,ide.ItemName,vod.Price,vod.Quantity,vod.TotalPrice from VendorOrderDesc vod join ItemDetails ide on Vod.ItemId=ide.ItemId where vod.Orderid='" + orderid + "'";
            DataTable dt3 = dbMainClass.getDetailByQuery(selectqurry);
            string selectqurry1 = "select TotalPrice from VendorOrderDetails where Orderid='" + orderid + "'";
            DataTable dt4 = dbMainClass.getDetailByQuery(selectqurry1);
            foreach (DataRow dr3 in dt4.Rows)
            {
                txttotalAmount.Text = dr3[0].ToString();
            }
            dataGridView1.DataSource = dt3;

        }
         private int vendid()
        {
             string selectqurry = "select vCurrentBalance from VendorAccountDetails where venderId='" + txtvendorId.Text + "'";
                        DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
                        string courntbal = "";
                        foreach (DataRow dr in dt.Rows)
                        {
                            courntbal = dr[0].ToString();
                        }
                        int bal = Convert.ToInt32(courntbal);
                        int bal1 = Convert.ToInt32(txtRemaning.Text);
                        int bal2 = bal + bal1;
             return bal2;
         }
         private int vendid1()
         {
             string selectqurry = "select vCurrentBalance from VendorAccountDetails where venderId='" + txtvendorId.Text + "'";
             DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
             string courntbal = "";
             foreach (DataRow dr in dt.Rows)
             {
                 courntbal = dr[0].ToString();
             }
             int bal = Convert.ToInt32(courntbal);
             int bal1 = Convert.ToInt32(txtPayAmount.Text);
             int bal2 = bal - bal1;
             return bal2;
         }

        private void txtRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    makeBlank();

                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void ChaqueReado_Click(object sender, EventArgs e)
        {
            ChaquePayment ch = new ChaquePayment(txtPayAmount);
            ch.Show();
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            txtvendorId.ReadOnly = false;
            checkBox1.Checked = false;
            button1.Visible = true;
            txtSrNo.ReadOnly = true;
            txtRefNo.ReadOnly = true;
            makeBlank();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            txtvendorId.ReadOnly = true;
            makeBlank();
            checkBox2.Checked = false;
            button1.Visible = false;
            txtSrNo.ReadOnly = false;
            txtRefNo.ReadOnly =false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

    }
}
