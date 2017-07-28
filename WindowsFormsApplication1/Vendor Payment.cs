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
        DataTable addToCartTable = new DataTable();
        public string orderid9;
        Double BalAmount = 0;
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
            
            panel4.Visible = false;
            button1.Enabled = false;
            //button1.Visible = false;
            Purchase.PurchaseDetails purChaseDetailObj = new Purchase.PurchaseDetails();
            vendorDetails = purChaseDetailObj.GetVendorDetaisInDataTable();
            string select = "select DeliveryDate from CustomerOrderDelivery where Deliveryid='" + 1 + "'";
            DataTable dt3 = dbMainClass.getDetailByQuery(select);
            string date = "";
            foreach (DataRow d4 in dt3.Rows)
            {
                date = d4[0].ToString();
            }
            dateTimePicker4.Text = date;
            /* panel2.Visible = false;
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
             int totel = 0;
             string selectqurry1 = "select vodd.ItemId,td.ItemName, vodd.Quantity,vodd.Price,vodd.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId where vod. Orderid='" + orderid + "'";
             DataTable dt4 = dbMainClass.getDetailByQuery(selectqurry1);
             int totalRowCount = addToCartTable.Rows.Count;
             for (int rowCount = 0; rowCount < totalRowCount; rowCount++)
             {
                 addToCartTable.Rows.RemoveAt(0);
             }

             for (int d = 0; d < dt4.Rows.Count; d++)
             {
                 DataRow dr2 = dt4.Rows[d];
                 string txtItemCode = dr2[0].ToString();
                 string txtRate = dr2[1].ToString();
                 string txtQuanity = dr2[2].ToString();
                 string txtAmoun = dr2[3].ToString();
                 string txtitemNmae = dr2[4].ToString();
                 //totel = dr2[5].ToString();
                 int amt = Convert.ToInt32(txtitemNmae);
                 totel = totel + amt;
             }
             dataGridView1.DataSource = dt4;
             txttotalAmount.Text = totel.ToString();*/
            pnlPayment.Visible = false;
            string selectqurry5 = "select Id from AllPaymentDetailes";
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
           tabindex();
            makePayment1();
            //tabindex1();
        }
        public void makePayment1()
        {
            string selectqurry = "select CustomerOrderDelivery.Deliveryid as[Purchase Invoice ID],CustomerOrderDelivery.DeliveryDate as[Invoice Date],VendorOrderDetails.venderId as [Vendor ID], VendorDetails.vName as[Vendor Name],VendorDetails.vCompName as[Company Name], VendorDetails.vAddress as[Address],(select Sum(VendorOrderDesc.Quantity) from VendorOrderDesc where VendorOrderDesc.Orderid= VendorOrderDetails.Orderid) as[Quantity Billed],VendorOrderDetails.WithoutTexAmount as[Gross Amount],VendorOrderDetails.DisAmount as[Dicount Amount],cast((VendorOrderDetails.WithoutTexAmount)-(VendorOrderDetails.DisAmount)as numeric(38, 2))as[Taxable Value],case when VendorDetails .vState != (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.CGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end as[CGst],case when VendorDetails .vState != (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.SGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end as[SGst],case when VendorDetails .vState = (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.IGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end as[IGst],(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.CESS)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)as[CESS],cast(((VendorOrderDetails.WithoutTexAmount)-(VendorOrderDetails.DisAmount))+(VendorOrderDetails.TextTaxAmmount) as numeric(38, 2)) AS[Net Amount (Including Tax)],VendorOrderDetails.TotalPrice as[Invoice Amount],p.[Paid Amount],p.Balance as [Balance Amount],(case when p.Balance > 0 then 'Delivered' else 'Fully settled' end) as [Delivery Status] from VendorOrderDetails join VendorDetails on VendorDetails.venderId =VendorOrderDetails.venderId join CustomerOrderDelivery on VendorOrderDetails.Orderid=CustomerOrderDelivery.Orderid left join  (select Invoiceid, (MAX(InvoiceAmount) - sum(TotalAmount)) as Balance , sum(TotalAmount) as [Paid Amount] from AllPaymentDetailes  join CustomerOrderDelivery on AllPaymentDetailes.Invoiceid=CustomerOrderDelivery.Deliveryid  group by Invoiceid) p on CustomerOrderDelivery.Deliveryid=p.Invoiceid";
            string selectqurryForActualColumnName = "select top 1 CustomerOrderDelivery.Deliveryid ,CustomerOrderDelivery.DeliveryDate ,VendorOrderDetails.venderId , VendorDetails.vName ,VendorDetails.vCompName , VendorDetails.vAddress ,(select Sum(VendorOrderDesc.Quantity) from VendorOrderDesc where VendorOrderDesc.Orderid= VendorOrderDetails.Orderid) ,VendorOrderDetails.WithoutTexAmount ,VendorOrderDetails.DisAmount ,cast((VendorOrderDetails.WithoutTexAmount)-(VendorOrderDetails.DisAmount)as numeric(38, 2)),case when VendorDetails .vState != (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.CGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end ,case when VendorDetails .vState != (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.SGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end ,case when VendorDetails .vState = (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.IGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end ,(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.CESS)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid),cast(((VendorOrderDetails.WithoutTexAmount)-(VendorOrderDetails.DisAmount))+(VendorOrderDetails.TextTaxAmmount) as numeric(38, 2)) ,VendorOrderDetails.TotalPrice ,p.[Paid Amount],p.Balance ,(case when p.Balance > 0 then 'Delivered' else 'Fully settled' end)  from VendorOrderDetails join VendorDetails on VendorDetails.venderId =VendorOrderDetails.venderId join CustomerOrderDelivery on VendorOrderDetails.Orderid=CustomerOrderDelivery.Orderid left join  (select Invoiceid, (MAX(InvoiceAmount) - sum(TotalAmount)) as Balance , sum(TotalAmount) as [Paid Amount] from AllPaymentDetailes  join CustomerOrderDelivery on AllPaymentDetailes.Invoiceid=CustomerOrderDelivery.Deliveryid  group by Invoiceid) p on CustomerOrderDelivery.Deliveryid=p.Invoiceid";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            DataTable dtOnlyColumnName = dbMainClass.getDetailByQuery(selectqurryForActualColumnName);
            DataTable customDataTable = new DataTable();
            customDataTable.Columns.Add("ActualTableColumnName");
            customDataTable.Columns.Add("AliasTableColumnName");
            //List<string> ls = new List<string>();
            DataColumnCollection d = dt.Columns;
            DataColumnCollection dataColumnForName = dtOnlyColumnName.Columns;
            for (int a = 0; a < d.Count; a++)
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

            comboBox1.DataSource = customDataTable;
            comboBox1.ValueMember = "ActualTableColumnName";
            comboBox1.DisplayMember = "AliasTableColumnName";
            dataGridView2.DataSource = dt;

        }
        public void Tabindex2()
        {
            dataGridView1.Focus();
            panel1.TabStop = true;
            dataGridView1.TabStop = true;
            buttSave.TabStop = true;
            button4.TabStop = true;
            panel1.TabIndex = 0;
            dataGridView1.TabIndex = 1;
            buttSave.TabIndex = 2;
            button4.TabIndex = 3;
        }
        public void tabindex()
        {
            txtvendorId.TabStop = false;
            txtVendorName.TabStop = false;
            txtAddress.TabStop = false;
            txtPhone.TabStop = false;
            txtFax.TabStop = false;
            dataGridView1.TabStop = false;
            txttotalAmount.TabStop = false;
            btnSave.TabStop = false;
            btnClose.TabStop = false;
            panel1.TabStop = false;
            groupBox10.TabStop = false;
            groupBox11.TabStop = false;
            txtCompanyName.TabStop = false;
            txtMobile.TabStop = false;
            txtRefNo.TabStop = false;
            txtpayDate.TabStop = false;
            buttSave.TabStop = false;
            button4.TabStop = false;
            button2.TabStop = false;
            //groupBox1.TabStop = false;
            comboBox1.Focus();
        }
        public void tabindex1()
        {
            
            comboBox1.TabIndex = 0;
            txtSearch.TabIndex = 1;
            dataGridView2.TabIndex = 2;
            button2.TabIndex = 3;
            dateTimePicker4.TabIndex = 4;
            dateTimePicker3.TabIndex = 5;
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
            if (s == "Column1")
            {
                s = "(select Sum(VendorOrderDesc.Quantity) from VendorOrderDesc where VendorOrderDesc.Orderid= VendorOrderDetails.Orderid)";
            }
           else if (s == "Column2")
            {
                s = "cast((VendorOrderDetails.WithoutTexAmount)-(VendorOrderDetails.DisAmount)as numeric(38, 2))";
            }
            else if (s == "Orderid")
            {
                s = "VendorOrderDetails." + s + "";//.Orderid";
            }
            else if (s == "venderId")
            {
                s = "VendorOrderDetails." + s + "";
            }
            else if (s == "Paid Amount")
            {
                s = "p.[Paid Amount] ";
            }
            else if (s == "Column3")
            {
                s = "case when VendorDetails .vState != (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.CGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end";
            }
            else if (s == "Column4")
            {
                s = "case when VendorDetails .vState != (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.SGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end";
            }
            else if (s == "Column5")
            {
                s = "case when VendorDetails .vState != (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.IGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end";
            }
            else if (s == "Column6")
            {
                s = "case when VendorDetails .vState != (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.CESS)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end";
            }
            else if (s == "Column7")
            {
                s = "cast(((VendorOrderDetails.WithoutTexAmount)-(VendorOrderDetails.DisAmount))+(VendorOrderDetails.TextTaxAmmount)";
            }
            else if (s == "Column8")
            {
                s = "(case when p.Balance > 0 then 'Delivered' else 'Fully settled' end)";
            }
            //string m = "v" + s;

            string selectQurry = "select CustomerOrderDelivery.Deliveryid as[Purchase Invoice ID],CustomerOrderDelivery.DeliveryDate as[Invoice Date],VendorOrderDetails.venderId as [Vendor ID], VendorDetails.vName as[Vendor Name],VendorDetails.vCompName as[Company Name], VendorDetails.vAddress as[Address],(select Sum(VendorOrderDesc.Quantity) from VendorOrderDesc where VendorOrderDesc.Orderid= VendorOrderDetails.Orderid) as[Quantity Billed],VendorOrderDetails.WithoutTexAmount as[Gross Amount],VendorOrderDetails.DisAmount as[Dicount Amount],cast((VendorOrderDetails.WithoutTexAmount)-(VendorOrderDetails.DisAmount)as numeric(38, 2))as[Taxable Value],case when VendorDetails .vState != (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.CGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end as[CGst],case when VendorDetails .vState != (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.SGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end as[SGst],case when VendorDetails .vState = (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.IGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end as[IGst],(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.CESS)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)as[CESS],cast(((VendorOrderDetails.WithoutTexAmount)-(VendorOrderDetails.DisAmount))+(VendorOrderDetails.TextTaxAmmount) as numeric(38, 2)) AS[Net Amount (Including Tax)],VendorOrderDetails.TotalPrice as[Invoice Amount],p.[Paid Amount],p.Balance as [Balance Amount],(case when p.Balance > 0 then 'Delivered' else 'Fully settled' end) as [Delivery Status] from VendorOrderDetails join VendorDetails on VendorDetails.venderId =VendorOrderDetails.venderId join CustomerOrderDelivery on VendorOrderDetails.Orderid=CustomerOrderDelivery.Orderid left join  (select Invoiceid, (MAX(InvoiceAmount) - sum(TotalAmount)) as Balance , sum(TotalAmount) as [Paid Amount] from AllPaymentDetailes  join CustomerOrderDelivery on AllPaymentDetailes.Invoiceid=CustomerOrderDelivery.Deliveryid  group by Invoiceid) p on CustomerOrderDelivery.Deliveryid=p.Invoiceid where " + s + " like '" + txtSearch.Text + "%'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            dataGridView2.DataSource = dt;
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Tabindex2();
            // panel2.Visible = false;
            DataGridViewCellCollection call = dataGridView2.Rows[e.RowIndex].Cells;
            if (!string.IsNullOrEmpty(call[0].Value.ToString()))
            {
                setDetails(call); 
                //int id = Convert.ToInt32(txtSrNo.Text);
                //int id1 = id -1;



                string selectQurry = "select payment.PaymentDate as[Invoice Date],(select Sum(VendorOrderDesc.Quantity) from VendorOrderDesc where VendorOrderDesc.Orderid= VendorOrderDetails.Orderid) as[Quantity Billed],VendorOrderDetails.WithoutTexAmount as[Gross Amount],VendorOrderDetails.DisAmount as[Dicount Amount],cast((VendorOrderDetails.WithoutTexAmount)-(VendorOrderDetails.DisAmount)as numeric(38, 2))as[Taxable Value],case when VendorDetails .vState != (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.CGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end as[CGst],case when VendorDetails .vState != (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.SGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end as[SGst],case when VendorDetails .vState = (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.IGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end as[IGst],(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.CESS)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)as[CESS],cast(((VendorOrderDetails.WithoutTexAmount)-(VendorOrderDetails.DisAmount))+(VendorOrderDetails.TextTaxAmmount) as numeric(38, 2)) AS[Net Amount (Including Tax)],VendorOrderDetails.TotalPrice as[Invoice Amount],payment.TotalAmount as[Paid Amount] ,payment.BalanceAmount as[Balance Amount] from VendorOrderDetails join VendorDetails on VendorDetails.venderId=VendorOrderDetails.venderId join CustomerOrderDelivery on VendorOrderDetails.Orderid=CustomerOrderDelivery.Orderid join AllPaymentDetailes payment on CustomerOrderDelivery.Deliveryid=payment.Invoiceid where CustomerOrderDelivery.Deliveryid='" + txtRefNo.Text + "'";
                DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
                string balance = "";
                foreach (DataRow dr in dt.Rows)
                {
                    balance = dr[12].ToString();
                }
                if (balance == "0.00")
                {
                    buttSave.Enabled = false;
                    panel2.Visible = false;
                    dataGridView1.DataSource = dt;
                    double d;
                    double d1 = 0;
                    DataGridViewRowCollection call1 = dataGridView1.Rows;
                    for (int c = 0; c < call1.Count; c++)
                    {
                        DataGridViewRow currentRow1 = call1[c];
                        DataGridViewCellCollection cellCollection1 = currentRow1.Cells;
                        d = Convert.ToDouble(cellCollection1[12].Value.ToString());
                        d1 = d1 + d;
                    }
                    Double Amount1 = BalAmount - d1;
                    txttotalAmount.Text = Amount1.ToString("###0.00");
                }
                else
                {
                    buttSave.Enabled = true;
                    panel2.Visible = false;
                    dataGridView1.DataSource = dt;
                    double d;
                    double d1 = 0;
                    DataGridViewRowCollection call1 = dataGridView1.Rows;
                    for (int c = 0; c < call1.Count; c++)
                    {
                        DataGridViewRow currentRow1 = call1[c];
                        DataGridViewCellCollection cellCollection1 = currentRow1.Cells;
                        d = Convert.ToDouble(cellCollection1[12].Value.ToString());
                        d1 = d1 + d;
                        //amount = d1;
                    }
                    Double Amount1 = BalAmount;
                    txttotalAmount.Text = Amount1.ToString("###0.00");
                   // txtInvoiceAmount.Text = Amount1.ToString("###0.00"); 
                   // txtBalance.Text = Amount1.ToString("###0.00"); 
                }
            }

        }
        private void setDetails(DataGridViewCellCollection cellCollection)
        {
            try
            {
                txtRefNo.Text = cellCollection[0].Value.ToString();
                txtvendorId.Text = cellCollection[2].Value.ToString();
                txtVendorName.Text = cellCollection[3].Value.ToString();
                txtCompanyName.Text = cellCollection[4].Value.ToString();
                txtAddress.Text = cellCollection[5].Value.ToString();
                // txtPhone.Text = cellCollection[4].Value.ToString();
                // txtMobile.Text = cellCollection[5].Value.ToString();
                //txtFax.Text = cellCollection[6].Value.ToString();
               // txttotalAmount.Text = cellCollection[14].Value.ToString();
               
                txtInvoiceAmount.Text = cellCollection[17].Value.ToString();
                BalAmount = Convert.ToDouble(cellCollection[17].Value.ToString());
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

               // txttotalAmount.Text = courntbal;
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            txtSearch.Text = "";
        }
        int counter = 0;
        private void buttSave_Click(object sender, EventArgs e)
        {
            counter = 0;
            /* string ChaqueDate = varible.bankDate;
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
                   string insertqurry = "insert into WithoutRefrencePament values('" + txtvendorId.Text + "','" + txttotalAmount.Text + "','" + txtPayAmount.Text + "','" + txtRemaning.Text + "','" + txtpayDate.Value.ToString() + "'";
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
                    string insertqurrey = "insert into VendorPayment Values('" + txtRefNo.Text + "','" + txttotalAmount.Text + "','" + txtPayAmount.Text + "','" + txtRemaning.Text + "','Cash','" + txtpayDate.Value.ToString() + "')";
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
                    string insertqurrey = "insert into VendorPayment Values('" + txtRefNo.Text + "','" + txttotalAmount.Text + "','" + txtPayAmount.Text + "','" + txtRemaning.Text + "','Chaque','" + txtpayDate.Value.ToString() + "')";
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
               */
            pnlPayment.Visible = true;
            CashAmount.Focus();
            BlankPaymentPage1();
            CashAmount.SelectAll();
            //makeBlank();
            //makeBlank1();
            //int id = Convert.ToInt32(txtSrNo.Text);
            //int id1 = id + 1;
            //txtSrNo.Text = id1.ToString();
        }

        private void txtPayAmount_TextChanged(object sender, EventArgs e)
        {

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
           
            txtRefNo.Text = "";
            
        }
        private void makeBlank1()
        {
           
        }

        private void txtPayAmount_KeyPress(object sender, KeyPressEventArgs e)
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
            //    int total = Convert.ToInt32(txttotalAmount.Text);
            //    int payamount = Convert.ToInt32(txtPayAmount.Text);
            //    int arrearAmount = total - payamount;
            //    txtRemaning.Text = arrearAmount.ToString();

        }

        private void txtRefNo_TextChanged(object sender, EventArgs e)
        {
            //int totel = 0;
            //string refqurry = "select InvoiceId from VendorPayment where InvoiceId ='" + txtRefNo.Text + "'";
            //DataTable refdt = dbMainClass.getDetailByQuery(refqurry);
            //if (refdt != null && refdt.Rows != null && refdt.Rows.Count > 0)
            //{
            //    MessageBox.Show("This Invoice completed");
            //    txtRefNo.Text = "";
            //    txtvendorId.Focus();
            //    //buttSave.Enabled = false;
            //    //checkBox1.Checked = true;
            //    //string select = "select Deliveryid from CustomerOrderInvoice where InvoiceId='" + txtRefNo.Text + "'";
            //    //DataTable dt = dbMainClass.getDetailByQuery(select);
            //    //string orderid = "";
            //    //foreach (DataRow dr in dt.Rows)
            //    //{
            //    //    orderid = dr[0].ToString();
            //    //}
            //    ////int totel = 0;
            //    //string selc = "select * from CustomerOrderDelivery where Deliveryid ='" + orderid + "'";
            //    //DataTable dt2 = dbMainClass.getDetailByQuery(selc);
            //    //if (dt2 != null && dt2.Rows != null && dt2.Rows.Count > 0)
            //    //{
            //    //    DataRow dr0 = dt2.Rows[0];
            //    //    string c = dr0[1].ToString();
            //    //    // MessageBox.Show(c);
            //    //    string select1 = "select vo.Orderid,vo.venderId,vod.ItemId from VendorOrderDesc vod join VendorOrderDetails vo on vod.Orderid=vo.Orderid where vo.Orderid='" + c + "'";
            //    //    DataTable dt1 = dbMainClass.getDetailByQuery(select1);

            //    //    //dataGridView1.DataSource = dt;
            //    //    DataRow dr = dt1.Rows[0];
            //    //    string a = dr[1].ToString();
            //    //    string select2 = "select venderId,vName,vCompName,vAddress ,vPhone,vMobile,vFax from VendorDetails where venderId='" + a + "'";
            //    //    DataTable dt3 = dbMainClass.getDetailByQuery(select2);
            //    //    foreach (DataRow dr5 in dt3.Rows)
            //    //    {
            //    //        txtvendorId.Text = dr5[0].ToString();
            //    //        txtVendorName.Text = dr5[1].ToString();
            //    //        txtCompanyName.Text = dr5[2].ToString();
            //    //        txtAddress.Text = dr5[3].ToString();
            //    //        txtPhone.Text = dr5[4].ToString();
            //    //        txtMobile.Text = dr5[5].ToString();
            //    //        txtFax.Text = dr5[6].ToString();
            //    //    }
            //    //    //string b = dr[2].ToString();
            //    //    string selectqurry1 = "select vodd.ItemId,td.ItemName, vodd.Quantity,vodd.Price,vodd.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId where vod. Orderid='" + c + "'";
            //    //    DataTable dt4 = dbMainClass.getDetailByQuery(selectqurry1);
            //    //    int totalRowCount = addToCartTable.Rows.Count;
            //    //    for (int rowCount = 0; rowCount < totalRowCount; rowCount++)
            //    //    {
            //    //        addToCartTable.Rows.RemoveAt(0);
            //    //    }

            //    //    for (int d = 0; d < dt4.Rows.Count; d++)
            //    //    {
            //    //        DataRow dr2 = dt4.Rows[d];
            //    //        string txtItemCode = dr2[0].ToString();
            //    //        string txtRate = dr2[1].ToString();
            //    //        string txtQuanity = dr2[2].ToString();
            //    //        string txtAmoun = dr2[3].ToString();
            //    //        string txtitemNmae = dr2[4].ToString();
            //    //        //totel = dr2[5].ToString();
            //    //        int amt = Convert.ToInt32(txtitemNmae);
            //    //        totel = totel + amt;
            //    //    }
            //    //    dataGridView1.DataSource = dt4;
            //    //    txttotalAmount.Text = totel.ToString();
            //    //}
            //}
            //else
            //{
            //    buttSave.Enabled = true;
            //    checkBox1.Checked = true;
            //    string select = "select Deliveryid from CustomerOrderInvoice where InvoiceId='" + txtRefNo.Text + "'";
            //    DataTable dt = dbMainClass.getDetailByQuery(select);
            //    string orderid = "";
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        orderid = dr[0].ToString();
            //    }
            //    //int totel = 0;
            //    string selc = "select * from CustomerOrderDelivery where Deliveryid ='" + orderid + "'";
            //    DataTable dt2 = dbMainClass.getDetailByQuery(selc);
            //    if (dt2 != null && dt2.Rows != null && dt2.Rows.Count > 0)
            //    {
            //        DataRow dr0 = dt2.Rows[0];
            //        string c = dr0[1].ToString();
            //        // MessageBox.Show(c);
            //        string select1 = "select vo.Orderid,vo.venderId,vod.ItemId from VendorOrderDesc vod join VendorOrderDetails vo on vod.Orderid=vo.Orderid where vo.Orderid='" + c + "'";
            //        DataTable dt1 = dbMainClass.getDetailByQuery(select1);

            //        //dataGridView1.DataSource = dt;
            //        DataRow dr = dt1.Rows[0];
            //        string a = dr[1].ToString();
            //        string select2 = "select venderId,vName,vCompName,vAddress ,vPhone,vMobile,vFax from VendorDetails where venderId='" + a + "'";
            //        DataTable dt3 = dbMainClass.getDetailByQuery(select2);
            //        foreach (DataRow dr5 in dt3.Rows)
            //        {
            //            txtvendorId.Text = dr5[0].ToString();
            //            txtVendorName.Text = dr5[1].ToString();
            //            txtCompanyName.Text = dr5[2].ToString();
            //            txtAddress.Text = dr5[3].ToString();
            //            txtPhone.Text = dr5[4].ToString();
            //            txtMobile.Text = dr5[5].ToString();
            //            txtFax.Text = dr5[6].ToString();
            //        }
            //        //string b = dr[2].ToString();
            //        string selectqurry1 = "select vodd.ItemId,td.ItemName, vodd.Quantity,vodd.Price,vodd.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId where vod. Orderid='" + c + "'";
            //        DataTable dt4 = dbMainClass.getDetailByQuery(selectqurry1);
            //        int totalRowCount = addToCartTable.Rows.Count;
            //        for (int rowCount = 0; rowCount < totalRowCount; rowCount++)
            //        {
            //            addToCartTable.Rows.RemoveAt(0);
            //        }

            //        for (int d = 0; d < dt4.Rows.Count; d++)
            //        {
            //            DataRow dr2 = dt4.Rows[d];
            //            string txtItemCode = dr2[0].ToString();
            //            string txtRate = dr2[1].ToString();
            //            string txtQuanity = dr2[2].ToString();
            //            string txtAmoun = dr2[3].ToString();
            //            string txtitemNmae = dr2[4].ToString();
            //            //totel = dr2[5].ToString();
            //            int amt = Convert.ToInt32(txtitemNmae);
            //            totel = totel + amt;
            //        }
            //        dataGridView1.DataSource = dt4;
            //        txttotalAmount.Text = totel.ToString();
            //    }
            //}
        }
        //private int vendid()
        //{
        //    string selectqurry = "select vCurrentBalance from VendorAccountDetails where venderId='" + txtvendorId.Text + "'";
        //    DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
        //    string courntbal = "";
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        courntbal = dr[0].ToString();
        //    }
        //    int bal = Convert.ToInt32(courntbal);
        //    //int bal1 = Convert.ToInt32(txtRemaning.Text);
        //    //int bal2 = bal + bal1;
        //    //return bal2;
        //}
        //private int vendid1()
        //{
        //    string selectqurry = "select vCurrentBalance from VendorAccountDetails where venderId='" + txtvendorId.Text + "'";
        //    DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
        //    string courntbal = "";
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        courntbal = dr[0].ToString();
        //    }
        //    int bal = Convert.ToInt32(courntbal);
        //    //int bal1 = Convert.ToInt32(txtPayAmount.Text);
        //    //int bal2 = bal - bal1;
        //    //return bal2;
        //}

        private void txtRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                int totel = 0;
                string refqurry = "select InvoiceId from VendorPayment where InvoiceId ='" + txtRefNo.Text + "'";
                DataTable refdt = dbMainClass.getDetailByQuery(refqurry);
                if (refdt != null && refdt.Rows != null && refdt.Rows.Count > 0)
                {
                    MessageBox.Show("This Invoice completed");
                    txtRefNo.Text = "";
                    txtvendorId.Focus();
                }
                else
                {
                    buttSave.Enabled = true;
                    //checkBox1.Checked = true;
                    string select = "select Deliveryid from CustomerOrderInvoice where InvoiceId='" + txtRefNo.Text + "'";
                    DataTable dt = dbMainClass.getDetailByQuery(select);
                    string orderid = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        orderid = dr[0].ToString();
                    }
                    //int totel = 0;
                    string selc = "select * from CustomerOrderDelivery where Deliveryid ='" + orderid + "'";
                    DataTable dt2 = dbMainClass.getDetailByQuery(selc);
                    if (dt2 != null && dt2.Rows != null && dt2.Rows.Count > 0)
                    {
                        DataRow dr0 = dt2.Rows[0];
                        string c = dr0[1].ToString();
                        // MessageBox.Show(c);
                        string select1 = "select vo.Orderid,vo.venderId,vod.ItemId from VendorOrderDesc vod join VendorOrderDetails vo on vod.Orderid=vo.Orderid where vo.Orderid='" + c + "'";
                        DataTable dt1 = dbMainClass.getDetailByQuery(select1);

                        //dataGridView1.DataSource = dt;
                        DataRow dr = dt1.Rows[0];
                        string a = dr[1].ToString();
                        string select2 = "select venderId,vName,vCompName,vAddress ,vPhone,vMobile,vFax from VendorDetails where venderId='" + a + "'";
                        DataTable dt3 = dbMainClass.getDetailByQuery(select2);
                        foreach (DataRow dr5 in dt3.Rows)
                        {
                            txtvendorId.Text = dr5[0].ToString();
                            txtVendorName.Text = dr5[1].ToString();
                            txtCompanyName.Text = dr5[2].ToString();
                            txtAddress.Text = dr5[3].ToString();
                            txtPhone.Text = dr5[4].ToString();
                            txtMobile.Text = dr5[5].ToString();
                            txtFax.Text = dr5[6].ToString();
                        }
                        //string b = dr[2].ToString();
                        string selectqurry1 = "select vodd.ItemId,td.ItemName, vodd.Quantity,vodd.Price,vodd.TotalPrice from VendorOrderDetails vod join VendorOrderDesc vodd on vod.Orderid=vodd.Orderid join ItemDetails td on td.ItemId=vodd.ItemId where vod. Orderid='" + c + "'";
                        DataTable dt4 = dbMainClass.getDetailByQuery(selectqurry1);
                        int totalRowCount = addToCartTable.Rows.Count;
                        for (int rowCount = 0; rowCount < totalRowCount; rowCount++)
                        {
                            addToCartTable.Rows.RemoveAt(0);
                        }

                        for (int d = 0; d < dt4.Rows.Count; d++)
                        {
                            DataRow dr2 = dt4.Rows[d];
                            string txtItemCode = dr2[0].ToString();
                            string txtRate = dr2[1].ToString();
                            string txtQuanity = dr2[2].ToString();
                            string txtAmoun = dr2[3].ToString();
                            string txtitemNmae = dr2[4].ToString();
                            //totel = dr2[5].ToString();
                            int amt = Convert.ToInt32(txtitemNmae);
                            totel = totel + amt;
                        }
                        dataGridView1.DataSource = dt4;
                        txttotalAmount.Text = totel.ToString();
                    }
                }
            }
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
            //// txtPayAmount.Text = "0";
            //ChaquePayment ch = new ChaquePayment(txtPayAmount);
            //ch.Show();

        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            txtvendorId.ReadOnly = false;
           // checkBox1.Checked = false;
            button1.Visible = true;
            txtSrNo.ReadOnly = true;
            txtRefNo.ReadOnly = true;
            makeBlank();
            //txtPayAmount.Text = "0";
            //txtRemaning.Text = "0";
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            txtvendorId.ReadOnly = true;
            makeBlank();
            //checkBox2.Checked = false;
            button1.Visible = false;
            txtSrNo.ReadOnly = false;
            txtRefNo.ReadOnly = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Tabindex2();
                DataGridViewCellCollection call = dataGridView2.SelectedRows[0].Cells;
                if (!string.IsNullOrEmpty(call[0].Value.ToString()))
                {
                    setDetails(call);
                    //int id = Convert.ToInt32(txtSrNo.Text);
                    //int id1 = id -1;



                    string selectQurry = "select payment.PaymentDate as[Invoice Date],(select Sum(VendorOrderDesc.Quantity) from VendorOrderDesc where VendorOrderDesc.Orderid= VendorOrderDetails.Orderid) as[Quantity Billed],VendorOrderDetails.WithoutTexAmount as[Gross Amount],VendorOrderDetails.DisAmount as[Dicount Amount],cast((VendorOrderDetails.WithoutTexAmount)-(VendorOrderDetails.DisAmount)as numeric(38, 2))as[Taxable Value],case when VendorDetails .vState != (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.CGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end as[CGst],case when VendorDetails .vState != (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.SGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end as[SGst],case when VendorDetails .vState = (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.IGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end as[IGst],(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.CESS)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)as[CESS],cast(((VendorOrderDetails.WithoutTexAmount)-(VendorOrderDetails.DisAmount))+(VendorOrderDetails.TextTaxAmmount) as numeric(38, 2)) AS[Net Amount (Including Tax)],VendorOrderDetails.TotalPrice as[Invoice Amount],payment.TotalAmount as[Paid Amount] ,payment.BalanceAmount as[Balance Amount] from VendorOrderDetails join VendorDetails on VendorDetails.venderId=VendorOrderDetails.venderId join CustomerOrderDelivery on VendorOrderDetails.Orderid=CustomerOrderDelivery.Orderid join AllPaymentDetailes payment on CustomerOrderDelivery.Deliveryid=payment.Invoiceid where CustomerOrderDelivery.Deliveryid='" + txtRefNo.Text + "'";
                    DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
                    string balance = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        balance = dr[12].ToString();
                    }
                    if (balance == "0.00")
                    {
                        buttSave.Enabled = false;
                        panel2.Visible = false;
                        dataGridView1.DataSource = dt;
                        double d;
                        double d1 = 0;
                        DataGridViewRowCollection call1 = dataGridView1.Rows;
                        for (int c = 0; c < call1.Count; c++)
                        {
                            DataGridViewRow currentRow1 = call1[c];
                            DataGridViewCellCollection cellCollection1 = currentRow1.Cells;
                            d = Convert.ToDouble(cellCollection1[12].Value.ToString());
                            d1 = d1 + d;
                        }
                        Double Amount1 = BalAmount - d1;
                        txttotalAmount.Text = Amount1.ToString("###0.00");
                    }
                    else
                    {
                        buttSave.Enabled = true;
                        panel2.Visible = false;
                        dataGridView1.DataSource = dt;
                        double d;
                        double d1 = 0;
                        DataGridViewRowCollection call1 = dataGridView1.Rows;
                        for (int c = 0; c < call1.Count; c++)
                        {
                            DataGridViewRow currentRow1 = call1[c];
                            DataGridViewCellCollection cellCollection1 = currentRow1.Cells;
                            d = Convert.ToDouble(cellCollection1[12].Value.ToString());
                            d1 = d1 + d;
                            //amount = d1;
                        }
                        Double Amount1 = BalAmount;
                        txttotalAmount.Text = Amount1.ToString("###0.00");
                        // txtInvoiceAmount.Text = Amount1.ToString("###0.00"); 
                        // txtBalance.Text = Amount1.ToString("###0.00"); 
                    }
                }

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlPayment.Visible = false;
            panel2.Visible = false;
            //this.Close();
            
            
        }
        public void allvisible()
        {
            txtCardNumber.ReadOnly = true;
            txtDebitBankName.ReadOnly = true;
            CmbCardType.Enabled = false;
            txtChequeBankName.ReadOnly = true;
            txtChequeNumber.ReadOnly = true;
            txtCompanyName.ReadOnly = true;
            CmbCompany.Enabled = false;
            dateTimePicker1.Enabled = false;
            txtTransactionNumber.ReadOnly = true;
            dateTimePicker2.Enabled = false;
            EWalletCompanyName.ReadOnly = true;
            //label23.Visible = false;
            //label25.Visible = false;
            //label26.Visible = false;
            //label28.Visible = false;
            //label30.Visible = false;
            //label31.Visible = false;
            //label32.Visible = false;
            //label34.Visible = false;
            //label35.Visible = false;
            //label36.Visible = false;
            txtCardNumber.TabStop = true;
            txtDebitBankName.TabStop = true;
            txtChequeBankName.TabStop = true;
            txtChequeNumber.TabStop = true;
            txtTransactionNumber.TabStop = false;
            EWalletCompanyName.TabStop = false;
        }
        private void pnlPayment_Paint(object sender, PaintEventArgs e)
        {
            //txtInvoiceid.Text = txtRefNo.Text;
            //txtInvoiceAmount.Text = amount.ToString("###0.00");
            //txtBalance.Text = txttotalammount.Text;
            //txtNetAmount.Text = txtTotalAmount1.Text;
            //Double Amount = Convert.ToDouble(txtTotalAmount1.Text);
            //Double Amount1 = Convert.ToDouble(txtBalance.Text);
            //double amount4 = Convert.ToDouble(txtRturned.Text);
            //Double Amount2 = Amount1 - Amount;
            //double amount5 = Amount2 + amount4;
            //string Amount3 = amount5.ToString();
            //txtBalance.Text = amount5.ToString("##0.00");
           
            txtInvoiceid.Text = txtRefNo.Text;

            txtInvoiceAmount.Text = BalAmount.ToString("###0.00");
            txtBalance.Text = txttotalAmount.Text;
            txtNetAmount.Text = txtTotalAmount1.Text;
            Double Amount = Convert.ToDouble(txtTotalAmount1.Text);
            Double Amount1 = Convert.ToDouble(txtBalance.Text);
            double amount4 = Convert.ToDouble(txtRturned.Text);
            Double Amount2 = Amount1 - Amount;
            double amount5 = Amount2 + amount4;
            string Amount3 = amount5.ToString();
            txtBalance.Text = amount5.ToString("##0.00");
            allvisible();
            CmbPageName.SelectedIndex = 0;
            CmbCardType.SelectedIndex = 0;
            CmbCompany.SelectedIndex = 0;
            buttSave.TabStop = false;
            button4.TabStop = false;
            panel1.TabStop = false;
            dataGridView1.TabStop = false;
            btnClose.TabStop = true;
            btnSave.TabStop = true;
        }

        private void CashAmount_TextChanged(object sender, EventArgs e)
        {
            if (CashAmount.Text == "")
            {
                CashAmount.Text = "0.00";
                CashAmount.SelectAll();
                value();
            }
            if (CashAmount.Text != "0.00")
            {
                string amount = CashAmount.Text;
                //    //CashAmount.Text = amount;
                //    double amount1 = 0.0;
                //    if (double.TryParse(amount, out amount1))
                //    {

                //        txtTotalAmount1.Text = CashAmount.Text;
                //        //txtBalance.Text = amount2.ToString("##0.00");
                //    }

                //}
                value();
            }
        }

        private void CashAmount_Leave(object sender, EventArgs e)
        {
            Double amount2 = Convert.ToDouble(txtTotalAmount1.Text);
            Double tot = Convert.ToDouble(txtBalance.Text);
            if (tot < amount2)
            {
                txtRturned.ReadOnly = false;
            }
            decimal x;
            if (decimal.TryParse(CashAmount.Text, out x))
            {
                if (CashAmount.Text.IndexOf('.') != -1 && CashAmount.Text.Split('.')[1].Length > 2)
                {
                    MessageBox.Show("The maximum decimal points are 2!");
                    CashAmount.Focus();
                }
                else CashAmount.Text = x.ToString("0.00");
            }
            else
            {
                CashAmount.Text = "0.00";
                //MessageBox.Show("Data invalid!");
                //txtVenderOpeningBal.Focus();
            }
        }

        private void txtCreditAmount_Leave(object sender, EventArgs e)
        {
            Double amount2 = Convert.ToDouble(txtTotalAmount1.Text);
            Double tot = Convert.ToDouble(txtBalance.Text);
            if (tot < amount2)
            {
                txtRturned.ReadOnly = false;
            }
            if (txtCreditAmount.Text == "0.00")
            {
               // credittext1();
            }
            if (txtCreditAmount.Text != "0.00")
            {
               // credittext();
            }
            decimal x;
            if (decimal.TryParse(txtCreditAmount.Text, out x))
            {
                if (txtCreditAmount.Text.IndexOf('.') != -1 && txtCreditAmount.Text.Split('.')[1].Length > 2)
                {
                    MessageBox.Show("The maximum decimal points are 2!");
                    txtCreditAmount.Focus();
                }
                else txtCreditAmount.Text = x.ToString("0.00");
            }
            else
            {
                txtCreditAmount.Text = "0.00";
                //MessageBox.Show("Data invalid!");
                //txtVenderOpeningBal.Focus();
            }
        }

        private void txtChequeAmount_Leave(object sender, EventArgs e)
        {
            Double amount2 = Convert.ToDouble(txtTotalAmount1.Text);
            Double tot = Convert.ToDouble(txtBalance.Text);
            if (tot < amount2)
            {
                txtRturned.ReadOnly = false;
            }
            if (txtCreditAmount.Text == "0.00")
            {
                //credittext1();
            }
          
        if (txtCreditAmount.Text != "0.00")
            {
                //credittext();
                decimal x;
                if (decimal.TryParse(txtChequeAmount.Text, out x))
                {
                    if (txtChequeAmount.Text.IndexOf('.') != -1 && txtChequeAmount.Text.Split('.')[1].Length > 2)
                    {
                        MessageBox.Show("The maximum decimal points are 2!");
                        txtChequeAmount.Focus();
                    }
                    else txtChequeAmount.Text = x.ToString("0.00");
                }
                else
                {
                    txtChequeAmount.Text = "0.00";
                    //MessageBox.Show("Data invalid!");
                    //txtVenderOpeningBal.Focus();
                }
            }

        }

        private void txtEwalletAmount_Leave(object sender, EventArgs e)
        {
            Double amount2 = Convert.ToDouble(txtTotalAmount1.Text);
            Double tot = Convert.ToDouble(txtBalance.Text);
            if (tot < amount2)
            {
                txtRturned.ReadOnly = false;
            }
            if (txtEwalletAmount.Text == "0.00")
            {
                //Ewalled1();
            }
            else
            {
                //Ewalled();
            }
            decimal x;
            if (decimal.TryParse(txtEwalletAmount.Text, out x))
            {
                if (txtEwalletAmount.Text.IndexOf('.') != -1 && txtEwalletAmount.Text.Split('.')[1].Length > 2)
                {
                    MessageBox.Show("The maximum decimal points are 2!");
                    txtEwalletAmount.Focus();
                }
                else txtEwalletAmount.Text = x.ToString("0.00");
            }
            else
            {
                txtEwalletAmount.Text = "0.00";
                //MessageBox.Show("Data invalid!");
                //txtVenderOpeningBal.Focus();
            }
        }

        private void txtCouponAmount_Leave(object sender, EventArgs e)
        {
            Double amount2 = Convert.ToDouble(txtTotalAmount1.Text);
            Double tot = Convert.ToDouble(txtBalance.Text);
            if (tot < amount2)
            {
                txtRturned.ReadOnly = false;
            }
            if (txtCouponAmount.Text == "0.00")
            {
                //CmbCompany.Visible = false;
                // label23.Visible = false;
            }
            else
            {
                //CmbCompany.Visible = true;
                //label23.Visible = true;
            }
            decimal x;
            if (decimal.TryParse(txtCouponAmount.Text, out x))
            {
                if (txtCouponAmount.Text.IndexOf('.') != -1 && txtCouponAmount.Text.Split('.')[1].Length > 2)
                {
                    MessageBox.Show("The maximum decimal points are 2!");
                    txtCouponAmount.Focus();
                }
                else txtCouponAmount.Text = x.ToString("0.00");
            }
            else
            {
                txtCouponAmount.Text = "0.00";
                //MessageBox.Show("Data invalid!");
                //txtVenderOpeningBal.Focus();
            }
        }

        private void txtTotalAmount1_TextChanged(object sender, EventArgs e)
        {
            if(txtTotalAmount1.Text=="")
            {
                txtTotalAmount1.Text="0.00";
           }
           //string netAmount = txtTotalAmount1.Text;
           //Double Amount = Convert.ToDouble(netAmount);
           // Double Amount1 = Convert.ToDouble(txttotalAmount.Text);
           // Double Amount2 = Amount1 - Amount;
           // string Amount3 = Amount2.ToString();
           // txtNetAmount.Text = txtTotalAmount1.Text;
           // txtBalance.Text = Amount2.ToString("##0.00");
            txtNetAmount.Text = txtTotalAmount1.Text;
            Double Amount = Convert.ToDouble(txtTotalAmount1.Text);
            Double Amount1 = Convert.ToDouble(txttotalAmount.Text);
            Double Amount2 = Amount1 - Amount;
            string Amount3 = Amount2.ToString();
            txtBalance.Text = Amount2.ToString("##0.00");
        }

        private void CashAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //if (CashAmount.Text.IndexOf('.') != -1 && CashAmount.Text.Split('.')[1].Length == 2)
                //{
                //MessageBox.Show("The maximum decimal points are 2!");
                e.Handled = false;
                //}
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    //if (CashAmount.Text == "")
                    //{
                    //    txttotalAmount.Text = "0.00";
                    //    // txtBalance.Text = "0.00";
                    //}
                   
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        public void credittext()
        {
            txtCardNumber.ReadOnly = false;
            txtDebitBankName.ReadOnly = false;
            CmbCardType.Enabled = true;
            txtCardNumber.TabStop = true;
            txtDebitBankName.TabStop = true;
        }
        public void credittext1()
        {
            txtCardNumber.ReadOnly = true;
            txtDebitBankName.ReadOnly = true;
            CmbCardType.Enabled = false;
            txtCardNumber.TabStop = false;
            txtDebitBankName.TabStop = false;
        }
        private void txtCreditAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtCreditAmount.Text == "0.00")
            {
                //credittext1();
                
            }
          else  if (txtCreditAmount.Text == "")
            {
                txtCreditAmount.Text = "0.00";
                txtCreditAmount.SelectAll();
                value();
            }
           else if (txtCreditAmount.Text != "0.00")
            {
               // credittext();
                value();
                
                //string amount = txtCreditAmount.Text;
                //double amount1 = 0.0;
                //if (double.TryParse(amount, out amount1))
                //{
                //    txtCreditAmount.Text = amount;
                //    Double Amount = Convert.ToDouble(txtCreditAmount.Text);
                //    Double Amount1 = Convert.ToDouble(CashAmount.Text);
                //    Double amount2 = Amount + Amount1;
                //    //string Amount2 = amount2.ToString();
                //    txtTotalAmount1.Text = amount2.ToString("##0.00");
                //}

            }
        }
        public void chequetxt()
        {
            txtChequeBankName.ReadOnly = false;
            txtChequeNumber.ReadOnly = false;
            dataGridView1.Enabled = false;
            txtChequeBankName.TabStop = false;
            txtChequeNumber.TabStop = false;

        }
        public void chequetxt1()
        {
            txtChequeBankName.ReadOnly = true;
            txtChequeNumber.ReadOnly = true;
            dataGridView1.Enabled = true;
            txtChequeBankName.TabStop = true;
            txtChequeNumber.TabStop = true;
        }
        private void txtChequeAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtChequeAmount.Text == "0.00")
            {
                //chequetxt1();
            }
           else if (txtChequeAmount.Text == "")
            {
                txtChequeAmount.Text = "0.00";
                txtChequeAmount.SelectAll();
                value();
            }
           else if (txtChequeAmount.Text != "0.00")
            {
                //chequetxt();
                value();
                //string amount = txtChequeAmount.Text;
                //double amount1 = 0.0;
                //if (double.TryParse(amount, out amount1))
                //{
                //    txtChequeAmount.Text = amount;
                //    //txtNetAmount.Text = amount;
                //    Double Amount = Convert.ToDouble(txtCreditAmount.Text);
                //    Double Amount1 = Convert.ToDouble(CashAmount.Text);
                //    Double Amount3 = Convert.ToDouble(txtChequeAmount.Text);
                //    Double amount2 = Amount + Amount1 + Amount3;
                //    //string Amount2 = amount2.ToString();
                //    txtTotalAmount1.Text = amount2.ToString("##0.00");
                //}
            }
        }

        private void txtCouponAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtCouponAmount.Text == "0.00")
            {
                //CmbCompany.Enabled = true;
                //label23.Visible = false;
            }
           else if (txtCouponAmount.Text == "")
            {
                txtCouponAmount.Text = "0.00";
                txtChequeAmount.SelectAll();
                value();
            }
            if (txtCouponAmount.Text != "0.00")
            {
                //CmbCompany.Enabled = false;
                //label23.Visible = true;
                value();
                //string amount = txtCouponAmount.Text;
                ////txtCouponAmount.Text = amount;
                //double amount1 = 0.0;
                //if (double.TryParse(amount, out amount1))
                //{
                //    Double Amount = Convert.ToDouble(txtCreditAmount.Text);
                //    Double Amount1 = Convert.ToDouble(CashAmount.Text);
                //    Double Amount3 = Convert.ToDouble(txtChequeAmount.Text);
                //    Double Amount4 = Convert.ToDouble(txtEwalletAmount.Text);
                //    Double Amount5 = Convert.ToDouble(txtCouponAmount.Text);
                //    Double amount2 = Amount + Amount1 + Amount3 + Amount4 + Amount5;
                //    string Amount2 = amount2.ToString();
                //    txtTotalAmount1.Text = amount2.ToString("##0.00");
                //}
            }
        }
        public void Ewalled()
        {
            txtTransactionNumber.ReadOnly = false;
            EWalletCompanyName.ReadOnly = false;
            dataGridView2.Enabled = false;
            txtTransactionNumber.TabStop = false;
            EWalletCompanyName.TabStop = false;

        }
        public void Ewalled1()
        {

            txtTransactionNumber.ReadOnly = true;
            EWalletCompanyName.ReadOnly = true;
            dataGridView2.Enabled = true;
            txtTransactionNumber.TabStop = false;
            EWalletCompanyName.TabStop = false;
        }
        private void BlankPaymentPage()
        {
            CashAmount.Text = "0.00";
            txtCreditAmount.Text = "0.00";
            txtDebitBankName.Text = "";
            txtCardNumber.Text = "";
            CmbCardType.SelectedIndex = 0;
            txtChequeAmount.Text = "0.00";
            txtChequeBankName.Text = "";
            txtChequeNumber.Text = "";
           // txtWAmount.Text = "0.00";
            txtEwalletAmount.Text = "0.00";
            EWalletCompanyName.Text = "";
            txtTransactionNumber.Text = "";
            txtCouponAmount.Text = "0.00";
            CmbCompany.SelectedIndex = 0;
            txtTotalAmount1.Text = "0.00";
            txtBalance.Text = "0.00";
            txtRturned.Text = "0.00";
            txtNetAmount.Text = "0.00";


        }
        private void BlankPaymentPage1()
        {
            CashAmount.Text = "0.00";
            txtCreditAmount.Text = "0.00";
            txtDebitBankName.Text = "";
            txtCardNumber.Text = "";
            CmbCardType.SelectedIndex = 0;
            txtChequeAmount.Text = "0.00";
            txtChequeBankName.Text = "";
            txtChequeNumber.Text = "";
            // txtWAmount.Text = "0.00";
            txtEwalletAmount.Text = "0.00";
            EWalletCompanyName.Text = "";
            txtTransactionNumber.Text = "";
            txtCouponAmount.Text = "0.00";
            CmbCompany.SelectedIndex = 0;
            txtTotalAmount1.Text = "0.00";
            //txtBalance.Text = "0.00";
            txtRturned.Text = "0.00";
            txtNetAmount.Text = "0.00";


        }
        public void value()
        {

            Double Amount5 = Convert.ToDouble(txtCouponAmount.Text);
            Double Amount = Convert.ToDouble(txtCreditAmount.Text);
            Double Amount1 = Convert.ToDouble(CashAmount.Text);
            Double Amount3 = Convert.ToDouble(txtChequeAmount.Text);
            Double Amount4 = Convert.ToDouble(txtEwalletAmount.Text);
            Double amount2 = Amount + Amount1 + Amount3 + Amount4 + Amount5;
            string Amount2 = amount2.ToString("###0.00");
            txtTotalAmount1.Text = Amount2;
        }
           
        private void txtEwalletAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtEwalletAmount.Text == "0")
            {
                //Ewalled1();
            }
          else  if (txtEwalletAmount.Text == "")
            {
                txtEwalletAmount.Text = "0.00";
                txtEwalletAmount.SelectAll();
                value();
             }
            else if (txtEwalletAmount.Text != "0")
            {
                //Ewalled();
                value();
                //string amount = txtEwalletAmount.Text;
                //double amount1 = 0.0;
                //if (double.TryParse(amount, out amount1))
                //{
                //    txtEwalletAmount.Text = amount;
                //    Double Amount = Convert.ToDouble(txtCreditAmount.Text);
                //    Double Amount1 = Convert.ToDouble(CashAmount.Text);
                //    Double Amount3 = Convert.ToDouble(txtChequeAmount.Text);
                //    Double Amount4 = Convert.ToDouble(txtEwalletAmount.Text);
                //    Double amount2 = Amount + Amount1 + Amount3 + Amount4;
                //    string Amount2 = amount2.ToString();
                //    txtTotalAmount1.Text = Amount2;
                //}
            }
        }

        private void txtCreditAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //if (txtCreditAmount.Text.IndexOf('.') != -1 && txtCreditAmount.Text.Split('.')[1].Length == 2)
                //{
                //    //MessageBox.Show("The maximum decimal points are 2!");
                e.Handled = false;
                //}
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
        Double BalAmunt = 0;
        Double bal2 = 0;
        private void txtRturned_TextChanged(object sender, EventArgs e)
        {
            
            if (txtBalance.Text == "")
            {
                txtBalance.Text = "0.00";
            }
            if (txtRturned.Text == "")
            {
                txtRturned.Text = "0.00";
            }
             
            if (BalAmunt == 0)
            {
                BalAmunt =Convert.ToDouble( txtBalance.Text);
            }
            if (bal2 == 0)
            {
                bal2 = Convert.ToDouble(txtBalance.Text) * -1;
            }
            Double return3 = Convert.ToDouble(txtRturned.Text);
            if (bal2 <return3)
            {
                MessageBox.Show("please corrct Amount");
                txtRturned.Focus();
                txtRturned.SelectAll();
                txtBalance.Text = BalAmunt.ToString("###0.00");
            }
            else
            {
                string sub = BalAmunt.ToString();
                string return1 = txtRturned.Text;
                double amount1 = 0.0;
                if (double.TryParse(sub, out amount1))
                {
                    double bal = Convert.ToDouble(sub);
                    if (double.TryParse(return1, out amount1))
                    {
                        double ReturnAmount = Convert.ToDouble(txtRturned.Text);
                        double bal1 = bal + ReturnAmount;
                        txtBalance.Text = bal1.ToString();
                    }
                }
            }
        }

        private void txtRturned_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //if (txtRturned.Text.IndexOf('.') != -1 && txtRturned.Text.Split('.')[1].Length == 2)
                //{
                //    //MessageBox.Show("The maximum decimal points are 2!");
                //    e.Handled = true;
                //}
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    //txtBalance.Text = "0";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtChequeAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //if (txtChequeAmount.Text.IndexOf('.') != -1 && txtChequeAmount.Text.Split('.')[1].Length == 2)
                //{
                //    //MessageBox.Show("The maximum decimal points are 2!");
                e.Handled = false;
                //}
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                   // txtBalance.Text = "0";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtEwalletAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //if (txtEwalletAmount.Text.IndexOf('.') != -1 && txtEwalletAmount.Text.Split('.')[1].Length == 2)
                //{
                //    //MessageBox.Show("The maximum decimal points are 2!");
                e.Handled = false;
                //}
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    //txtBalance.Text = "0";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void txtCouponAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) || e.KeyChar == '.'))
            {
                //    if (txtCouponAmount.Text.IndexOf('.') != -1 && txtCouponAmount.Text.Split('.')[1].Length == 2)
                //    {
                //        //MessageBox.Show("The maximum decimal points are 2!");
                e.Handled = false;
                //}
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    //txtBalance.Text = "0";
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    //MessageBox.Show("Plese enter numeric value!");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

           
          
            DateTime d = DateTime.Now;
            string insertQurry1 = "insert into AllPaymentDetailes Values('" + txtInvoiceid.Text + "','" + CashAmount.Text + "','" + txtCreditAmount.Text + "','" + txtDebitBankName.Text + "','" + txtCardNumber.Text + "','" + CmbCardType.SelectedItem.ToString() + "','" + txtChequeAmount.Text + "','" + txtChequeBankName.Text + "','" + txtChequeNumber.Text + "','" + dateTimePicker1.Value.ToString() + "','" + txtEwalletAmount.Text + "','" + EWalletCompanyName.Text + "','" + txtTransactionNumber.Text + "','" + dateTimePicker2.Value.ToString() + "','" + txtCouponAmount.Text + "','" + CmbCompany.SelectedItem.ToString() + "','" + txtInvoiceAmount.Text + "','" + txtTotalAmount1.Text + "','" + txtBalance.Text + "','" + txtRturned.Text + "','" + txtNetAmount.Text + "','"+d+"')";
            int insertedRows = dbMainClass.saveDetails(insertQurry1);
            if (insertedRows > 0)
            {
                string qurry = "select vCurrentBalance from VendorAccountDetails where venderId='" + txtvendorId.Text + "'";
                DataTable dt = dbMainClass.getDetailByQuery(qurry);
                string balabce = "";
                foreach (DataRow dr in dt.Rows)
                {
                    balabce = dr[0].ToString();
                }

                double bal = Convert.ToDouble(balabce.ToString());
                double balan = Convert.ToDouble(txtTotalAmount1.Text);
                double b = bal - balan;

                string updateQ = "update VendorAccountDetails set vCurrentBalance='" + b + "'where venderId='" + txtvendorId.Text + "'";
                int insertedRows3 = dbMainClass.saveDetails(updateQ);
                if (insertedRows3 > 0)
                {
                    MessageBox.Show("Details Saved Successfully");
                    makePayment1();
                    BlankPaymentPage();
                    pnlPayment.Visible = false;
                    panel2.Visible = true;
                }
                else
                {
                    MessageBox.Show("Details Not Saved Successfully");
                }
            }
   
        }

       

        private void txtCreditAmount_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
      
        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            setDate();
        }
        public void setDate()
        {
            DateTime date = Convert.ToDateTime(dateTimePicker3.Text);
            if (date > DateTime.Now.Date)
            {

                MessageBox.Show("please enter the currect date");
                dateTimePicker3.Text = DateTime.Now.ToString();

            }
            DateTime date1 = Convert.ToDateTime(dateTimePicker4.Text);
            if (date1 > DateTime.Now.Date)
            {

                MessageBox.Show("please enter the currect date");
                dateTimePicker4.Text = DateTime.Now.ToString();

            }
            //string s = comboPurchasesearch.SelectedValue.ToString();

            string selectQurry = "select CustomerOrderDelivery.Deliveryid as[Purchase Invoice ID],CustomerOrderDelivery.DeliveryDate as[Invoice Date],VendorOrderDetails.venderId as [Vendor ID], VendorDetails.vName as[Vendor Name],VendorDetails.vCompName as[Company Name], VendorDetails.vAddress as[Address],(select Sum(VendorOrderDesc.Quantity) from VendorOrderDesc where VendorOrderDesc.Orderid= VendorOrderDetails.Orderid) as[Quantity Billed],VendorOrderDetails.WithoutTexAmount as[Gross Amount],VendorOrderDetails.DisAmount as[Dicount Amount],cast((VendorOrderDetails.WithoutTexAmount)-(VendorOrderDetails.DisAmount)as numeric(38, 2))as[Taxable Value],case when VendorDetails .vState != (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.CGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end as[CGst],case when VendorDetails .vState != (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.SGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end as[SGst],case when VendorDetails .vState = (select state from CompnayDetails) then '0.00'else(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.IGST)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)end as[IGst],(select cast(sum(((((voc.Price*voc.Quantity))-(((voc.Price*voc.Quantity)*itd.Discount)/100))*itd.CESS)/100)as numeric(38, 2)) from ItemTaxDetail itd join VendorOrderDesc voc on itd.ItemId=voc.ItemId where voc.Orderid=VendorOrderDetails.Orderid)as[CESS],VendorOrderDetails.TextTaxAmmount as[Gst,Cgst,Sgst in Tax Amount],cast(((VendorOrderDetails.WithoutTexAmount)-(VendorOrderDetails.DisAmount))+(VendorOrderDetails.TextTaxAmmount) as numeric(38, 2)) AS[Net Amount (Including Tax)],VendorOrderDetails.TotalPrice as[Invoice Amount],p.[Paid Amount],p.Balance as [Balance Amount],(case when p.Balance > 0 then 'Delivered' else 'Fully settled' end) as [Delivery Status] from VendorOrderDetails join VendorDetails on VendorDetails.venderId =VendorOrderDetails.venderId join CustomerOrderDelivery on VendorOrderDetails.Orderid=CustomerOrderDelivery.Orderid left join  (select Invoiceid, (MAX(InvoiceAmount) - sum(TotalAmount)) as Balance , sum(TotalAmount) as [Paid Amount] from AllPaymentDetailes  join CustomerOrderDelivery on AllPaymentDetailes.Invoiceid=CustomerOrderDelivery.Deliveryid  group by Invoiceid) p on CustomerOrderDelivery.Deliveryid=p.Invoiceid where DeliveryDate BETWEEN '" + dateTimePicker4.Value.ToString() + "' AND '" + dateTimePicker3.Value.ToString() + "'";
            //"select od.Orderid,od.venderId,itd.ItemName,vod.Quantity,vod.TotalPrice,od.OrderDate,cod.DeliveryDate,coi.InvoiceDate from VendorOrderDetails od join VendorOrderDesc vod on vod.Orderid=od.Orderid join CustomerOrderDelivery cod on cod.Orderid=vod.Orderid join CustomerOrderInvoice coi on coi.Orderid=vod.Orderid join ItemDetails itd on itd.ItemId=vod.ItemId where " + a + "= '" + txtsearch.Text + "'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            dataGridView2.DataSource = dt;
        }
             
        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            setDate();
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
           
        }

       

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            button2.TabStop = true;
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                panel4.Visible = true;
                int currentIndex = dataGridView1.CurrentRow.Index;
                DataGridViewCellCollection call = dataGridView1.SelectedRows[0].Cells;
                string itid = "";
                if (!string.IsNullOrEmpty(call[0].Value.ToString()))
                {
                     itid = call[0].Value.ToString();
                }
               DateTime paymentdate = Convert.ToDateTime(itid);
            string selectQurry = "select * from AllPaymentDetailes where PaymentDate ='" + paymentdate + "'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            foreach (DataRow dr in dt.Rows)
            {
                showCashAmount.Text = dr[2].ToString();
                showCreditDebitCard.Text = dr[3].ToString();
                if (showCreditDebitCard.Text != "0.00")
                {
                    creCardType.Text = dr[6].ToString();
                }
                creBankName.Text = dr[4].ToString();
                creCardNumber.Text = dr[5].ToString();
                showChequeAmount.Text = dr[7].ToString();
                if (showChequeAmount.Text == "0.00")
                {
                    chChequeDate.Text = null;
                }
                else
                {
                    chChequeDate.Text = dr[10].ToString();
                }
               
                cheBankName.Text = dr[8].ToString();
                chChequeNumber.Text = dr[9].ToString();
                EWalletAmount.Text = dr[11].ToString();
                if (EWalletAmount.Text == "0.00")
                {

                    EWalleTransactionDate.Text = null;
                }
                else
                {
                   // Date ed = Convert.ToDateTime(dr[14].ToString());
                    EWalleTransactionDate.Text = dr[14].ToString();
                }
              
                EWalletCompanyName.Text = dr[12].ToString();
                EWalleTransactionNumber.Text = dr[13].ToString();
                if (showCouponAmount.Text != "0.00")
                {
                    coponCompanyName.Text = dr[16].ToString();
                }
                showCouponAmount.Text = dr[15].ToString();

            }
        }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            panel4.Visible = true;
            DataGridViewCellCollection call = dataGridView1.Rows[e.RowIndex].Cells;
            string itid = call[0].Value.ToString();
            DateTime paymentdate = Convert.ToDateTime(itid);
            string selectQurry = "select * from AllPaymentDetailes where PaymentDate ='" + paymentdate + "'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            foreach (DataRow dr in dt.Rows)
            {
                showCashAmount.Text = dr[2].ToString();
                showCreditDebitCard.Text = dr[3].ToString();
                if (showCreditDebitCard.Text != "0.00")
                {
                    creCardType.Text = dr[6].ToString();
                }
                creBankName.Text = dr[4].ToString();
                creCardNumber.Text = dr[5].ToString();
                showChequeAmount.Text = dr[7].ToString();
                if (showChequeAmount.Text == "0.00")
                {
                    chChequeDate.Text = null;
                }
                else
                {
                    chChequeDate.Text = dr[10].ToString();
                }
               
                cheBankName.Text = dr[8].ToString();
                chChequeNumber.Text = dr[9].ToString();
                EWalletAmount.Text = dr[11].ToString();
                if (EWalletAmount.Text == "0.00")
                {

                    EWalleTransactionDate.Text = null;
                }
                else
                {
                   // Date ed = Convert.ToDateTime(dr[14].ToString());
                    EWalleTransactionDate.Text = dr[14].ToString();
                }
              
                EWalletCompanyName.Text = dr[12].ToString();
                EWalleTransactionNumber.Text = dr[13].ToString();
                if (showCouponAmount.Text != "0.00")
                {
                    coponCompanyName.Text = dr[16].ToString();
                }
                showCouponAmount.Text = dr[15].ToString();

            }
        }

       

    }
}
