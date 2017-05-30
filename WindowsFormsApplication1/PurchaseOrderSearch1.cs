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
    public partial class PurchaseOrderSearch1 : Form
    {
        DB_Main dbMainClass = new DB_Main();
        public PurchaseOrderSearch1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
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
            VendorPrint vp = new VendorPrint(classCollection, 1);
            vp.Show();

        }

        private void BtnExportToExel_Click(object sender, EventArgs e)
        {

            if (dataGridView1.AllowUserToAddRows == true)
            {
                dataGridView1.AllowUserToAddRows = false;
            }
            string FileName = "";
            SaveFileDialog openFileDialog1 = new SaveFileDialog();
            //FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();
            openFileDialog1.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
            openFileDialog1.FileName = "Purchase Order Details";
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
           /*string s = SelectPOrder.SelectedValue.ToString();
           string selectQurry = "SELECT dbo.VendorDetails.venderId as[Vendor ID],dbo.VendorDetails.vName as[Vendor Name], dbo.VendorDetails.vCompName as[Company Name], dbo.VendorDetails.vAddress as[Address], dbo.VendorDetails.vCity as[City], dbo.VendorDetails.vState as[State], dbo.VendorDetails.vZip as[Zip], dbo.VendorDetails.vCountry as[Country], dbo.VendorDetails.vEmail as[Email], dbo.VendorDetails.vWebAddress as[Web Address],dbo.VendorDetails.vPhone as[Phone], dbo.VendorDetails.vMobile as[Mobile], dbo.VendorOrderDetails.Orderid as[Invoice ID], dbo.VendorOrderDetails.OrderDate as[Invoice Date], dbo.VendorOrderDesc.ItemId as[Item ID], dbo.ItemDetails.ItemName as[Item Name], dbo.ItemDetails.ItemCompName as[Company Name], dbo.ItemPriceDetail.MrpPrice as[MRP], dbo.VendorOrderDesc.Price as[Selling Rate], dbo.VendorOrderDesc.Quantity as[Quantity Billed], dbo.VendorOrderDesc.TotalPrice AS [Gross Amount], dbo.VendorOrderDetails.Discount as[Discount Rate],((dbo.VendorOrderDesc.TotalPrice*dbo.VendorOrderDetails.Discount)/100) as [Discount Amount], dbo.VendorOrderDetails.Vat as[Tax], (dbo.VendorOrderDesc.TotalPrice)- ((dbo.VendorOrderDesc.TotalPrice)/(1+(dbo.VendorOrderDetails.Vat/100))) as [Tax Amount], dbo.VendorOrderDetails.TotalPrice as[Net Amount (Including Tax)] FROM  dbo.CustomerOrderDelivery INNER JOIN dbo.VendorOrderDetails ON dbo.CustomerOrderDelivery.Orderid = dbo.VendorOrderDetails.Orderid INNER JOIN dbo.VendorDetails ON dbo.VendorOrderDetails.venderId = dbo.VendorDetails.venderId INNER JOIN dbo.VendorOrderDesc ON dbo.VendorOrderDetails.Orderid = dbo.VendorOrderDesc.Orderid INNER JOIN dbo.ItemDetails ON dbo.VendorOrderDesc.ItemId = dbo.ItemDetails.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId where OrderDate BETWEEN '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "'";
            //"select od.Orderid,od.venderId,itd.ItemName,vod.Quantity,vod.TotalPrice,od.OrderDate,cod.DeliveryDate,coi.InvoiceDate from VendorOrderDetails od join VendorOrderDesc vod on vod.Orderid=od.Orderid join CustomerOrderDelivery cod on cod.Orderid=vod.Orderid join CustomerOrderInvoice coi on coi.Orderid=vod.Orderid join ItemDetails itd on itd.ItemId=vod.ItemId where " + a + "= '" + txtsearch.Text + "'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            dataGridView1.DataSource = dt;*/
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string s = SelectPOrder.SelectedValue.ToString();
            if(s=="Orderid")
            {
                s = "dbo.VendorOrderDesc." + s;
            }
            else if (s =="venderId")
            {
                s = "dbo.VendorDetails." + s;
            }
            else if (s =="ItemId")
            {
                s = "dbo.VendorOrderDesc." + s;
            }
            else if (s =="Column1")
            {
                s = "cast((dbo.VendorOrderDesc.TotalPrice*dbo.VendorOrderDetails.Discount)/100 as numeric(38,2))";
            }
            else if (s =="Column2")
            {
                s = "cast((dbo.VendorOrderDesc.TotalPrice)- ((dbo.VendorOrderDesc.TotalPrice)/(1+(dbo.VendorOrderDetails.Vat/100)))as numeric(38,2))";
            }
            else if (s =="Column3")
            {
                s = "cast((dbo.VendorOrderDesc.TotalPrice)-((dbo.VendorOrderDesc.TotalPrice*dbo.VendorOrderDetails.Discount)/100)as numeric(38,2))";
            }
            else if (s =="OrderDate")
            {
                s = "dbo.VendorOrderDetails." + s;
                
            }
            else if (s =="MrpPrice")
            {
                s = "cast(dbo.ItemPriceDetail.MrpPrice as numeric(38,2))";
            }
            else if (s =="Price")
            {
                s = "cast(dbo.VendorOrderDesc.Price as numeric(38,2))";
            }
            else if (s =="TotalPrice")
            {
                s = "cast(dbo.VendorOrderDesc.TotalPrice as numeric(38,2))";
            }

            string selectQurry = "SELECT dbo.VendorOrderDesc.orderid as [Order ID],dbo.VendorDetails.venderId as[Vendor ID],dbo.VendorDetails.vName as[Vendor Name], dbo.VendorDetails.vCompName as[Company Name], dbo.VendorDetails.vAddress as[Address], dbo.VendorOrderDetails.OrderDate as[Order Date],dbo.VendorOrderDesc.ItemId as[Item ID],dbo.ItemDetails.ItemName as[Item Name],dbo.ItemDetails.ItemCompName as[Item Compnay Name],cast(dbo.ItemPriceDetail.MrpPrice as numeric(38,2)) as[MRP], cast(dbo.VendorOrderDesc.price as numeric(38,2)) as[Selling Rate], dbo.VendorOrderDesc.quantity as [Quantity], cast(dbo.VendorOrderDesc.TotalPrice as numeric(38,2)) as[Gross Amount], dbo.VendorOrderDetails.Discount as[Discount Rate],cast((dbo.VendorOrderDesc.TotalPrice*dbo.VendorOrderDetails.Discount)/100 as numeric(38,2)) as [Discount Amount], dbo.VendorOrderDetails.Vat as[Tax], cast((dbo.VendorOrderDesc.TotalPrice)- ((dbo.VendorOrderDesc.TotalPrice)/(1+(dbo.VendorOrderDetails.Vat/100)))as numeric(38,2)) as [Tax Amount], cast((dbo.VendorOrderDesc.TotalPrice)-((dbo.VendorOrderDesc.TotalPrice*dbo.VendorOrderDetails.Discount)/100)as numeric(38,2)) AS [Net Amount (Including Tax)] FROM dbo.VendorDetails INNER JOIN dbo.VendorOrderDetails ON dbo.VendorDetails.venderId = dbo.VendorOrderDetails.venderId INNER JOIN dbo.VendorOrderDesc ON dbo.VendorOrderDetails.Orderid = dbo.VendorOrderDesc.Orderid INNER JOIN dbo.ItemDetails ON dbo.VendorOrderDesc.ItemId = dbo.ItemDetails.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId  Where " + s + " like'" + textBox5.Text + "%' and VendorOrderDetails.OrderDate  BETWEEN '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "'";
             DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
             dataGridView1.DataSource = dt;
             setvalue();
        }

        private void PurchaseOrderSearch1_Load(object sender, EventArgs e)  
        {
            string select = "select OrderDate from VendorOrderDetails where orderid='"+1+"'";
            DataTable dt3 = dbMainClass.getDetailByQuery(select);
            string date="";
            foreach (DataRow d4 in dt3.Rows)
            {
                date = d4[0].ToString();
            }
            dateTimePicker1.Text = date;
           btnPrint.Enabled = false;
           string selectqurry = "SELECT dbo.VendorOrderDesc.Orderid as[Order ID],dbo.VendorDetails.venderId as[Vendor ID],dbo.VendorDetails.vName as[Vendor Name], dbo.VendorDetails.vCompName as[Company Name], dbo.VendorDetails.vAddress as[Address], dbo.VendorOrderDetails.OrderDate as[Order Date], dbo.VendorOrderDesc.ItemId as[Item ID], dbo.ItemDetails.ItemName as[Item Name], dbo.ItemDetails.ItemCompName as[Company Name], cast(dbo.ItemPriceDetail.MrpPrice as numeric(38,2)) as[MRP], cast(dbo.VendorOrderDesc.Price as numeric(38,2)) as[Selling Rate], dbo.VendorOrderDesc.Quantity as[Quantity Billed], cast(dbo.VendorOrderDesc.TotalPrice as numeric(38,2)) AS [Gross Amount], dbo.VendorOrderDetails.Discount as[Discount Rate],cast((dbo.VendorOrderDesc.TotalPrice*dbo.VendorOrderDetails.Discount)/100 as numeric(38,2)) as [Discount Amount], dbo.VendorOrderDetails.Vat as[Tax], cast((dbo.VendorOrderDesc.TotalPrice)- ((dbo.VendorOrderDesc.TotalPrice)/(1+(dbo.VendorOrderDetails.Vat/100 )))as numeric(38,2)) as [Tax Amount],cast(( dbo.VendorOrderDesc.TotalPrice )-((dbo.VendorOrderDesc.TotalPrice*dbo.VendorOrderDetails.Discount)/100)as numeric(38,2)) as[Net Amount (Including Tax)] FROM dbo.VendorDetails INNER JOIN dbo.VendorOrderDetails ON dbo.VendorDetails.venderId = dbo.VendorOrderDetails.venderId INNER JOIN dbo.VendorOrderDesc ON dbo.VendorOrderDetails.Orderid = dbo.VendorOrderDesc.Orderid INNER JOIN dbo.ItemDetails ON dbo.VendorOrderDesc.ItemId = dbo.ItemDetails.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId";
           string selectqurryForActualColumnName = "select top 1 dbo.VendorOrderDesc.Orderid ,dbo.VendorDetails.venderId ,dbo.VendorDetails.vName , dbo.VendorDetails.vCompName, dbo.VendorDetails.vAddress, dbo.VendorOrderDetails.OrderDate , dbo.VendorOrderDesc.ItemId, dbo.ItemDetails.ItemName, dbo.ItemDetails.ItemCompName , dbo.ItemPriceDetail.MrpPrice , dbo.VendorOrderDesc.Price , dbo.VendorOrderDesc.Quantity, dbo.VendorOrderDesc.TotalPrice , dbo.VendorOrderDetails.Discount ,cast((dbo.VendorOrderDesc.TotalPrice*dbo.VendorOrderDetails.Discount)/100 as numeric(38,2)), dbo.VendorOrderDetails.Vat , cast((dbo.VendorOrderDesc.TotalPrice)- ((dbo.VendorOrderDesc.TotalPrice)/(1+(dbo.VendorOrderDetails.Vat/100)))as numeric(38,2)),cast(( dbo.VendorOrderDesc.TotalPrice)-((dbo.VendorOrderDesc.TotalPrice*dbo.VendorOrderDetails.Discount)/100)as numeric(38,2)) FROM dbo.VendorDetails INNER JOIN dbo.VendorOrderDetails ON dbo.VendorDetails.venderId = dbo.VendorOrderDetails.venderId INNER JOIN dbo.VendorOrderDesc ON dbo.VendorOrderDetails.Orderid = dbo.VendorOrderDesc.Orderid INNER JOIN dbo.ItemDetails ON dbo.VendorOrderDesc.ItemId = dbo.ItemDetails.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId";
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

            SelectPOrder.DataSource = customDataTable;
            SelectPOrder.ValueMember = "ActualTableColumnName";
            SelectPOrder.DisplayMember = "AliasTableColumnName";
            dataGridView1.DataSource = dt;
            //DataGridViewRowCollection RowCollection = gridPurchaseSearch.Rows;
            setvalue();
        }
        public void setvalue()
        {
            double dis;
            double dis1 = 0;
            double tax;
            double tax1 = 0;
            double gross;   
            double wta;
            double wta1 = 0;
            double gross1 = 0;
            for (int a = 0; a < dataGridView1.Rows.Count; a++)
            {
                gross = Convert.ToDouble(dataGridView1.Rows[a].Cells[12].Value);
                gross1 = gross1 + gross;
                dis = Convert.ToDouble(dataGridView1.Rows[a].Cells[14].Value);
                dis1 = dis1 + dis;
                tax = Convert.ToDouble(dataGridView1.Rows[a].Cells[16].Value);
                tax1 = tax1 + tax;
                wta = Convert.ToDouble(dataGridView1.Rows[a].Cells[17].Value);
                wta1 = wta1 + wta;
            }

            TxtGrowsAmount.Text = gross1.ToString();
            TxtDisAmount.Text = dis1.ToString();
            TxtTaxAmount.Text = tax1.ToString();
            TxtWithodTaxAmount.Text = wta1.ToString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateSelect();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateSelect();
        }
        public void dateSelect()
    {
        DateTime date = Convert.ToDateTime(dateTimePicker2.Text);
        if (date > DateTime.Now.Date)
        {

            MessageBox.Show("please enter the currect date");
            dateTimePicker2.Text = DateTime.Now.ToString();

        }
            //string s = SelectPOrder.SelectedValue.ToString();
            string selectQurry = "SELECT dbo.VendorOrderDetails.Orderid as[Order ID],dbo.VendorDetails.venderId as[Vendor ID],dbo.VendorDetails.vName as[Vendor Name], dbo.VendorDetails.vCompName as[Company Name], dbo.VendorDetails.vAddress as[Address], dbo.VendorOrderDetails.OrderDate as[Order Date], dbo.VendorOrderDesc.ItemId as[Item ID], dbo.ItemDetails.ItemName as[Item Name], dbo.ItemDetails.ItemCompName as[Company Name], cast(dbo.ItemPriceDetail.MrpPrice as numeric(38,2)) as[MRP], cast(dbo.VendorOrderDesc.Price as numeric(38,2)) as[Selling Rate], dbo.VendorOrderDesc.Quantity as[Quantity Billed], cast(dbo.VendorOrderDesc.TotalPrice as numeric(38,2)) AS [Gross Amount], dbo.VendorOrderDetails.Discount as[Discount Rate],cast((dbo.VendorOrderDesc.TotalPrice*dbo.VendorOrderDetails.Discount)/100 as numeric(38,2)) as [Discount Amount], dbo.VendorOrderDetails.Vat as[Tax], cast((dbo.VendorOrderDesc.TotalPrice)- ((dbo.VendorOrderDesc.TotalPrice)/(1+(dbo.VendorOrderDetails.Vat/100 )))as numeric(38,2)) as [Tax Amount],cast(( dbo.VendorOrderDesc.TotalPrice )-((dbo.VendorOrderDesc.TotalPrice*dbo.VendorOrderDetails.Discount)/100)as numeric(38,2)) as[Net Amount (Including Tax)] FROM dbo.VendorDetails INNER JOIN dbo.VendorOrderDetails ON dbo.VendorDetails.venderId = dbo.VendorOrderDetails.venderId INNER JOIN dbo.VendorOrderDesc ON dbo.VendorOrderDetails.Orderid = dbo.VendorOrderDesc.Orderid INNER JOIN dbo.ItemDetails ON dbo.VendorOrderDesc.ItemId = dbo.ItemDetails.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId where OrderDate BETWEEN '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "'";
            //"select od.Orderid,od.venderId,itd.ItemName,vod.Quantity,vod.TotalPrice,od.OrderDate,cod.DeliveryDate,coi.InvoiceDate from VendorOrderDetails od join VendorOrderDesc vod on vod.Orderid=od.Orderid join CustomerOrderDelivery cod on cod.Orderid=vod.Orderid join CustomerOrderInvoice coi on coi.Orderid=vod.Orderid join ItemDetails itd on itd.ItemId=vod.ItemId where " + a + "= '" + txtsearch.Text + "'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            dataGridView1.DataSource = dt;
            setvalue();
        }

     
       

       
    }
}
