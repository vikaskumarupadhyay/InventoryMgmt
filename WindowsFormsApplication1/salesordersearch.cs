using System;
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
    public partial class salesordersearch : Form
    {
        DB_Main d = new DB_Main();
        public salesordersearch()
        {
            InitializeComponent();
        }
        public double getTotalAmounts()
        {
            double totalValue = 0.0;
            double s;
            for (int a = 0; a < dataGridView1.Rows.Count; a++)
            {
                s = Convert.ToDouble(dataGridView1.Rows[a].Cells[11].Value);
                totalValue = totalValue + s;

            }
            return totalValue;
        }
        public double getquantitybuiled()
        {
            double totalValue = 0.0;
            double s;
            for (int a = 0; a < dataGridView1.Rows.Count; a++)
            {
                s = Convert.ToDouble(dataGridView1.Rows[a].Cells[10].Value);
                totalValue = totalValue + s;

            }
            return totalValue;
        }
        public double getdiscountamount()
        {
            double totalValue = 0.0;
            double s;
            for (int a = 0; a < dataGridView1.Rows.Count; a++)
            {
                s = Convert.ToDouble(dataGridView1.Rows[a].Cells[13].Value);
                totalValue = totalValue + s;

            }
            return totalValue;
        }
        public double gettaxamount()
        {
            double totalValue = 0.0;
            double s;
            for (int a = 0; a < dataGridView1.Rows.Count; a++)
            {
                s = Convert.ToDouble(dataGridView1.Rows[a].Cells[15].Value);
                totalValue = totalValue + s;

            }
            return totalValue;
        }
        public double getwithauttaxamount()
        {
            double totalValue = 0.0;
            double s;
            for (int a = 0; a < dataGridView1.Rows.Count; a++)
            {
                s = Convert.ToDouble(dataGridView1.Rows[a].Cells[16].Value);
                totalValue = totalValue + s;

            }
            return totalValue;
        }
        private void salesordersearch_Load(object sender, EventArgs e)
        {
            string select = "select date from orderdetails where orderid='" + 1 + "'";
            DataTable dt2 = d.getDetailByQuery(select);
            string num = "";
            foreach (DataRow dr in dt2.Rows)
            {
                num = dr[0].ToString();
            }
            dateTimePicker1.Text = num;

            btnprint.Enabled = false;

            try
            {

                string selectquery = "SELECT dbo.customerorderdescriptions.orderid as [Order ID],dbo.CustomerDetails.custId as[Customer ID], dbo.CustomerDetails.CustName as[Customer Name], dbo.CustomerDetails.CustCompName as[Compnay Name], dbo.orderdetails.date as [Order Date],dbo.customerorderdescriptions.ItemId as[Item ID],dbo.ItemDetails.ItemName as[Item Name],dbo.ItemDetails.ItemCompName as[Item Compnay Name],cast(dbo.ItemPriceDetail.MrpPrice as numeric(38,2)) as[MRP], cast(dbo.customerorderdescriptions.price as numeric(38,2)) as[Selling Rate], dbo.customerorderdescriptions.quantity as [Quantity], cast(dbo.customerorderdescriptions.totalammount as numeric(38,2))as[Gross Amount],dbo.orderdetails.Discount as[Discount Rate],cast((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100 as numeric(38,2)) as [Discount Amount], dbo.orderdetails.Tax as[Tax], cast((dbo.customerorderdescriptions.totalammount)- ((dbo.customerorderdescriptions.totalammount)/(1+(dbo.orderdetails.Tax/100)))as numeric(38,2)) as [Tax Amount], cast((dbo.customerorderdescriptions.totalammount)-((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100)as numeric(38,2)) AS [Net Amount (Including Tax)] FROM dbo.CompnayDetails CROSS JOIN dbo.ItemDetails INNER JOIN dbo.customerorderdescriptions ON dbo.ItemDetails.ItemId = dbo.customerorderdescriptions.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId INNER JOIN dbo.orderdetails ON dbo.customerorderdescriptions.orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId";
                string actualcolumn = "SELECT top 1 dbo.customerorderdescriptions.orderid ,dbo.CustomerDetails.custId, dbo.CustomerDetails.CustName, dbo.CustomerDetails.CustCompName, dbo.orderdetails.date,dbo.customerorderdescriptions.ItemId ,dbo.ItemDetails.ItemName,dbo.ItemDetails.ItemCompName,dbo.ItemPriceDetail.MrpPrice,dbo.customerorderdescriptions.price, dbo.customerorderdescriptions.quantity,dbo.customerorderdescriptions.totalammount, dbo.orderdetails.Discount,cast((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100 as numeric(38,2)), dbo.orderdetails.Tax, cast((dbo.customerorderdescriptions.totalammount)- ((dbo.customerorderdescriptions.totalammount)/(1+(dbo.orderdetails.Tax/100)))as numeric(38,2)), cast((dbo.customerorderdescriptions.totalammount)-((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100)as numeric(38,2)) FROM dbo.CompnayDetails CROSS JOIN dbo.ItemDetails INNER JOIN dbo.customerorderdescriptions ON dbo.ItemDetails.ItemId = dbo.customerorderdescriptions.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId INNER JOIN dbo.orderdetails ON dbo.customerorderdescriptions.orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId";
                DataTable dt = d.getDetailByQuery(selectquery);
                // DataTable dt1 = d.getDetailByQuery(actualcolumn);
                DataTable dtOnlyColumnName = d.getDetailByQuery(actualcolumn);
                DataTable customDataTable = new DataTable();
                customDataTable.Columns.Add("ActualTableColumnName");
                customDataTable.Columns.Add("AliasTableColumnName");
                //List<string> ls = new List<string>();
                DataColumnCollection d1 = dt.Columns;
                DataColumnCollection dataColumnForName = dtOnlyColumnName.Columns;
                for (int a = 0; a < d1.Count; a++)
                {
                    //DataColumn dc = new DataColumn();
                    string b = d1[a].ToString();
                    string actualColumnName = dataColumnForName[a].ToString();
                    DataRow dr = customDataTable.NewRow();
                    dr["ActualTableColumnName"] = actualColumnName;
                    dr["AliasTableColumnName"] = b;
                    customDataTable.Rows.Add(dr);
                    //  ls.Add(b);
                }

                comsalesordersearch.DataSource = customDataTable;
                comsalesordersearch.ValueMember = "ActualTableColumnName";
                comsalesordersearch.DisplayMember = "AliasTableColumnName";
                dataGridView1.DataSource = dt;
                double grosa = getTotalAmounts();
                txtGrossAmount.Text = grosa.ToString();
                double disa = getdiscountamount();
                Txtdisamount.Text = disa.ToString();
                double taxamount = gettaxamount();
                txttaxamount.Text = taxamount.ToString();
                double withaut = getwithauttaxamount();
                txtwithauttaxamount.Text = withaut.ToString();
                double qtybuiled = getquantitybuiled();
                txtquantitybuiled.Text = qtybuiled.ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string s = comsalesordersearch.SelectedValue.ToString();
            if (s == "orderid")
            {
                s = "dbo.customerorderdescriptions."+s;
            }
                else if(s=="MrpPrice")
                {
                    s = "cast(dbo.ItemPriceDetail.MrpPrice as numeric(34,2))";
                }
            else if (s =="price")
            {
                s = "cast(dbo.customerorderdescriptions.price as numeric(38,2))";
            }
            else if (s =="totalammount")
            {
                s = "cast(dbo.customerorderdescriptions.totalammount as numeric(38,2))";
            }
            else if (s == "custId")
            {
                s = "dbo.CustomerDetails." + s;
            }
            else if (s == "date")
            {
                s = "dbo.orderdetails." + s;
            }
            else if (s == "ItemId")
            {
                s = "dbo.customerorderdescriptions." + s;
            }

            else if (s == "Column1")
            {
                s = "cast((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100 as numeric(38,2))";
            }
            else if (s == "Column2")
            {
                s = "cast((dbo.customerorderdescriptions.totalammount)- ((dbo.customerorderdescriptions.totalammount)/(1+(dbo.orderdetails.Tax/100)))as numeric(38,2))";
            }
            else if (s == "Column3")
            {
                s = "cast((dbo.customerorderdescriptions.totalammount)-((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100)as numeric(38,2))";
            }
            string selectquery = "SELECT dbo.customerorderdescriptions.orderid as [Order ID],dbo.CustomerDetails.custId as[Customer ID], dbo.CustomerDetails.CustName as[Customer Name], dbo.CustomerDetails.CustCompName as[Compnay Name], dbo.orderdetails.date as [Order Date],dbo.customerorderdescriptions.ItemId as[Item ID],dbo.ItemDetails.ItemName as[Item Name],dbo.ItemDetails.ItemCompName as[Item Compnay Name],cast(dbo.ItemPriceDetail.MrpPrice as numeric(38,2)) as[MRP], cast(dbo.customerorderdescriptions.price as numeric(38,2)) as[Selling Rate], dbo.customerorderdescriptions.quantity as [Quantity], cast(dbo.customerorderdescriptions.totalammount as numeric(38,2)) as[Gross Amount], dbo.orderdetails.Discount as[Discount Rate],cast((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100 as numeric(38,2)) as [Discount Amount], dbo.orderdetails.Tax as[Tax], cast((dbo.customerorderdescriptions.totalammount)- ((dbo.customerorderdescriptions.totalammount)/(1+(dbo.orderdetails.Tax/100)))as numeric(38,2)) as [Tax Amount], cast((dbo.customerorderdescriptions.totalammount)-((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100)as numeric(38,2)) AS [Net Amount (Including Tax)] FROM dbo.CompnayDetails CROSS JOIN dbo.ItemDetails INNER JOIN dbo.customerorderdescriptions ON dbo.ItemDetails.ItemId = dbo.customerorderdescriptions.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId INNER JOIN dbo.orderdetails ON dbo.customerorderdescriptions.orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId  Where " + s + " like'" + txtsearch.Text + "%' and date BETWEEN '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "'";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string s = comsalesordersearch.SelectedValue.ToString();
            string selectquery = "SELECT dbo.CustomerDetails.custId as[Customer ID], dbo.CustomerDetails.CustName as[Customer Name], dbo.CustomerDetails.CustCompName as[Compnay Name],dbo.CustomerDetails.CustAddress as [Address], dbo.CustomerDetails.CustCity as[City], dbo.CustomerDetails.CustState as[State], dbo.CustomerDetails.CustZip as[Zip], dbo.CustomerDetails.CustCountry as [Country],dbo.CustomerDetails.CustEmail as[Email], dbo.CustomerDetails.CustWebAddress as[Web Address], dbo.CustomerDetails.CustPhone as[Phone], dbo.CustomerDetails.CustMobile as [Mobile],dbo.customerorderdescriptions.orderid as [Order ID], dbo.orderdetails.date as [Order Date],dbo.customerorderdescriptions.ItemId as[Item ID],dbo.ItemDetails.ItemName as[Item Name],dbo.ItemDetails.ItemCompName as[Item Compnay Name],dbo.ItemPriceDetail.MrpPrice as[Mrp], dbo.customerorderdescriptions.price as[Selling Rate], dbo.customerorderdescriptions.quantity as [Quantity], dbo.customerorderdescriptions.totalammount as[Gross Amount], dbo.orderdetails.Discount as[Discount Rate],((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100) as [Discount Amount], dbo.orderdetails.Tax as[Tax], (dbo.customerorderdescriptions.totalammount)- ((dbo.customerorderdescriptions.totalammount)/(1+(dbo.orderdetails.Tax/100))) as [Tax Amount], dbo.orderdetails.totalammount AS [Net Amount (Including Tax)] FROM dbo.CompnayDetails CROSS JOIN dbo.ItemDetails INNER JOIN dbo.customerorderdescriptions ON dbo.ItemDetails.ItemId = dbo.customerorderdescriptions.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId INNER JOIN dbo.orderdetails ON dbo.customerorderdescriptions.orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId   where date BETWEEN '" + dateTimePicker1.Value.Date + "' AND '" + dateTimePicker2.Value.Date + "'";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView1.DataSource = dt;*/
        }

        //private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        //{
        //    string s = comsalesordersearch.SelectedValue.ToString();
        //    string selectquery = "SELECT dbo.CustomerDetails.custId as[Customer ID], dbo.CustomerDetails.CustName as[Customer Name], dbo.CustomerDetails.CustCompName as[Compnay Name],dbo.CustomerDetails.CustAddress as [Address], dbo.CustomerDetails.CustCity as[City], dbo.CustomerDetails.CustState as[State], dbo.CustomerDetails.CustZip as[Zip], dbo.CustomerDetails.CustCountry as [Country],dbo.CustomerDetails.CustEmail as[Email], dbo.CustomerDetails.CustWebAddress as[Web Address], dbo.CustomerDetails.CustPhone as[Phone], dbo.CustomerDetails.CustMobile as [Mobile],dbo.customerorderdescriptions.orderid as [Order ID], dbo.orderdetails.date as [Order Date],dbo.customerorderdescriptions.ItemId as[Item ID],dbo.ItemDetails.ItemName as[Item Name],dbo.ItemDetails.ItemCompName as[Item Compnay Name],dbo.ItemPriceDetail.MrpPrice as[Mrp], dbo.customerorderdescriptions.price as[Selling Rate], dbo.customerorderdescriptions.quantity as [Quantity], dbo.customerorderdescriptions.totalammount as[Gross Amount], dbo.orderdetails.Discount as[Discount Rate],((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100) as [Discount Amount], dbo.orderdetails.Tax as[Tax], (dbo.customerorderdescriptions.totalammount)- ((dbo.customerorderdescriptions.totalammount)/(1+(dbo.orderdetails.Tax/100))) as [Tax Amount], dbo.orderdetails.totalammount AS [Net Amount (Including Tax)] FROM dbo.CompnayDetails CROSS JOIN dbo.ItemDetails INNER JOIN dbo.customerorderdescriptions ON dbo.ItemDetails.ItemId = dbo.customerorderdescriptions.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId INNER JOIN dbo.orderdetails ON dbo.customerorderdescriptions.orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId   where date BETWEEN '" + dateTimePicker1.Value.Date + "' AND '" + dateTimePicker2.Value.Date + "'";
        //    DataTable dt = d.getDetailByQuery(selectquery);
        //    dataGridView1.DataSource = dt;
        //}

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            DateTime date = Convert.ToDateTime(dateTimePicker2.Text);
            if (date > DateTime.Now.Date)
            {
                MessageBox.Show("plese select your correct date");
                dateTimePicker2.Text = DateTime.Now.ToString();
            }
            //string selectquery = "SELECT dbo.CustomerDetails.custId as[Customer ID], dbo.CustomerDetails.CustName as[Customer Name], dbo.CustomerDetails.CustCompName as[Compnay Name],dbo.CustomerDetails.CustAddress as [Address], dbo.CustomerDetails.CustCity as[City], dbo.CustomerDetails.CustState as[State], dbo.CustomerDetails.CustZip as[Zip], dbo.CustomerDetails.CustCountry as [Country],dbo.CustomerDetails.CustEmail as[Email], dbo.CustomerDetails.CustWebAddress as[Web Address], dbo.CustomerDetails.CustPhone as[Phone], dbo.CustomerDetails.CustMobile as [Mobile],dbo.customerorderdescriptions.orderid as [Order ID], dbo.orderdetails.date as [Order Date],dbo.customerorderdescriptions.ItemId as[Item ID],dbo.ItemDetails.ItemName as[Item Name],dbo.ItemDetails.ItemCompName as[Item Compnay Name],dbo.ItemPriceDetail.MrpPrice as[Mrp], dbo.customerorderdescriptions.price as[Selling Rate], dbo.customerorderdescriptions.quantity as [Quantity], dbo.customerorderdescriptions.totalammount as[Gross Amount], dbo.orderdetails.Discount as[Discount Rate],((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100) as [Discount Amount], dbo.orderdetails.Tax as[Tax], (dbo.customerorderdescriptions.totalammount)- ((dbo.customerorderdescriptions.totalammount)/(1+(dbo.orderdetails.Tax/100))) as [Tax Amount], dbo.orderdetails.totalammount AS [Net Amount (Including Tax)] FROM dbo.CompnayDetails CROSS JOIN dbo.ItemDetails INNER JOIN dbo.customerorderdescriptions ON dbo.ItemDetails.ItemId = dbo.customerorderdescriptions.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId INNER JOIN dbo.orderdetails ON dbo.customerorderdescriptions.orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId   where date BETWEEN '" + dateTimePicker1.Value.Date + "' AND '" + dateTimePicker2.Value.Date + "'";
           // string s = comsalesordersearch.SelectedValue.ToString();
            string selectquery = "SELECT dbo.customerorderdescriptions.orderid as [Order ID],dbo.CustomerDetails.custId as[Customer ID], dbo.CustomerDetails.CustName as[Customer Name], dbo.CustomerDetails.CustCompName as[Compnay Name], dbo.orderdetails.date as [Order Date],dbo.customerorderdescriptions.ItemId as[Item ID],dbo.ItemDetails.ItemName as[Item Name],dbo.ItemDetails.ItemCompName as[Item Compnay Name],dbo.ItemPriceDetail.MrpPrice as[MRP], dbo.customerorderdescriptions.price as[Selling Rate], dbo.customerorderdescriptions.quantity as [Quantity], dbo.customerorderdescriptions.totalammount as[Gross Amount], dbo.orderdetails.Discount as[Discount Rate],cast((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100 as numeric(38,2)) as [Discount Amount], dbo.orderdetails.Tax as[Tax], cast((dbo.customerorderdescriptions.totalammount)- ((dbo.customerorderdescriptions.totalammount)/(1+(dbo.orderdetails.Tax/100)))as numeric(38,2)) as [Tax Amount], cast((dbo.customerorderdescriptions.totalammount)-((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100)as numeric(38,2)) AS [Net Amount (Including Tax)] FROM dbo.CompnayDetails CROSS JOIN dbo.ItemDetails INNER JOIN dbo.customerorderdescriptions ON dbo.ItemDetails.ItemId = dbo.customerorderdescriptions.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId INNER JOIN dbo.orderdetails ON dbo.customerorderdescriptions.orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId   where date BETWEEN '" + dateTimePicker1.Value.Date + "' AND '" + dateTimePicker2.Value.Date + "'";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView1.DataSource = dt;
            double s1 = getTotalAmounts();
            txtGrossAmount.Text = s1.ToString();
            double disa = getdiscountamount();
            Txtdisamount.Text = disa.ToString();
            double taxa = gettaxamount();
            txttaxamount.Text = taxa.ToString();
            double witha = getwithauttaxamount();
            txtwithauttaxamount.Text = witha.ToString();

        }
  
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {

            if (dataGridView1.AllowUserToAddRows == true)
            {
                dataGridView1.AllowUserToAddRows = false;
            }
            string FileName = "";
            SaveFileDialog openFileDialog1 = new SaveFileDialog();
            //FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();
            openFileDialog1.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
            openFileDialog1.FileName = "Sales Order Details";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog1.FileName;

            }
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            DateTime date = Convert.ToDateTime(dateTimePicker2.Text);
            if (date > DateTime.Now.Date)
            {
                MessageBox.Show("plese select your correct date");
                dateTimePicker2.Text = DateTime.Now.ToString();
            }
            //string selectquery = "SELECT dbo.CustomerDetails.custId as[Customer ID], dbo.CustomerDetails.CustName as[Customer Name], dbo.CustomerDetails.CustCompName as[Compnay Name],dbo.CustomerDetails.CustAddress as [Address], dbo.CustomerDetails.CustCity as[City], dbo.CustomerDetails.CustState as[State], dbo.CustomerDetails.CustZip as[Zip], dbo.CustomerDetails.CustCountry as [Country],dbo.CustomerDetails.CustEmail as[Email], dbo.CustomerDetails.CustWebAddress as[Web Address], dbo.CustomerDetails.CustPhone as[Phone], dbo.CustomerDetails.CustMobile as [Mobile],dbo.customerorderdescriptions.orderid as [Order ID], dbo.orderdetails.date as [Order Date],dbo.customerorderdescriptions.ItemId as[Item ID],dbo.ItemDetails.ItemName as[Item Name],dbo.ItemDetails.ItemCompName as[Item Compnay Name],dbo.ItemPriceDetail.MrpPrice as[Mrp], dbo.customerorderdescriptions.price as[Selling Rate], dbo.customerorderdescriptions.quantity as [Quantity], dbo.customerorderdescriptions.totalammount as[Gross Amount], dbo.orderdetails.Discount as[Discount Rate],((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100) as [Discount Amount], dbo.orderdetails.Tax as[Tax], (dbo.customerorderdescriptions.totalammount)- ((dbo.customerorderdescriptions.totalammount)/(1+(dbo.orderdetails.Tax/100))) as [Tax Amount], dbo.orderdetails.totalammount AS [Net Amount (Including Tax)] FROM dbo.CompnayDetails CROSS JOIN dbo.ItemDetails INNER JOIN dbo.customerorderdescriptions ON dbo.ItemDetails.ItemId = dbo.customerorderdescriptions.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId INNER JOIN dbo.orderdetails ON dbo.customerorderdescriptions.orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId   where date BETWEEN '" + dateTimePicker1.Value.Date + "' AND '" + dateTimePicker2.Value.Date + "'";
            // string s = comsalesordersearch.SelectedValue.ToString();
            string selectquery = "SELECT dbo.customerorderdescriptions.orderid as [Order ID],dbo.CustomerDetails.custId as[Customer ID], dbo.CustomerDetails.CustName as[Customer Name], dbo.CustomerDetails.CustCompName as[Compnay Name], dbo.orderdetails.date as [Order Date],dbo.customerorderdescriptions.ItemId as[Item ID],dbo.ItemDetails.ItemName as[Item Name],dbo.ItemDetails.ItemCompName as[Item Compnay Name],dbo.ItemPriceDetail.MrpPrice as[MRP], dbo.customerorderdescriptions.price as[Selling Rate], dbo.customerorderdescriptions.quantity as [Quantity], dbo.customerorderdescriptions.totalammount as[Gross Amount], dbo.orderdetails.Discount as[Discount Rate],cast((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100 as numeric(38,2)) as [Discount Amount], dbo.orderdetails.Tax as[Tax], cast((dbo.customerorderdescriptions.totalammount)- ((dbo.customerorderdescriptions.totalammount)/(1+(dbo.orderdetails.Tax/100)))as numeric(38,2)) as [Tax Amount], cast((dbo.customerorderdescriptions.totalammount)-((dbo.customerorderdescriptions.totalammount*dbo.orderdetails.Discount)/100)as numeric(38,2)) AS [Net Amount (Including Tax)] FROM dbo.CompnayDetails CROSS JOIN dbo.ItemDetails INNER JOIN dbo.customerorderdescriptions ON dbo.ItemDetails.ItemId = dbo.customerorderdescriptions.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId INNER JOIN dbo.orderdetails ON dbo.customerorderdescriptions.orderid = dbo.orderdetails.orderid INNER JOIN dbo.CustomerDetails ON dbo.orderdetails.custid = dbo.CustomerDetails.custId   where date BETWEEN '" + dateTimePicker1.Value.Date + "' AND '" + dateTimePicker2.Value.Date + "'";
            DataTable dt = d.getDetailByQuery(selectquery);
            dataGridView1.DataSource = dt;
            double s1 = getTotalAmounts();
            txtGrossAmount.Text = s1.ToString();
            double disa = getdiscountamount();
            Txtdisamount.Text = disa.ToString();
            double taxa = gettaxamount();
            txttaxamount.Text = taxa.ToString();
            double witha = getwithauttaxamount();
            txtwithauttaxamount.Text = witha.ToString();
            double qtybuiled = getquantitybuiled();
            txtquantitybuiled.Text = qtybuiled.ToString();
        }


    }
}
