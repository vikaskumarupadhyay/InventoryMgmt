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
    public partial class PurchasSearch1 : Form
    {
        public PurchasSearch1()
        {
            InitializeComponent();
        }
         DB_Main dbMainClass = new DB_Main();
        
        private void PurchasSearch_Load(object sender, EventArgs e)
        {
            tabIndex();
            txtsearch.Focus();
            btnPrint.Enabled = false;
            string select = "select DeliveryDate from CustomerOrderDelivery where Deliveryid='" + 1 + "'";
            DataTable dt3 = dbMainClass.getDetailByQuery(select);
            string date = "";
            foreach (DataRow d4 in dt3.Rows)
            {
                date = d4[0].ToString();
            }
            dateTimePicker1.Text = date;
            /*
            //string selectqurry = "select orderid[Order ID] from DeliveryGridview ";//where Deliveryid='"+txtsearch.Text+"'";
            string selectqurry = "SELECT dbo.CustomerOrderDelivery.Deliveryid, dbo.CustomerOrderDelivery.DeliveryDate, dbo.CompnayDetails.Name, dbo.CompnayDetails.Address,dbo.CompnayDetails.City, dbo.CompnayDetails.State, dbo.CompnayDetails.Zip, dbo.CompnayDetails.Country, dbo.CompnayDetails.Email,dbo.CompnayDetails.WebAddress, dbo.CompnayDetails.Phone, dbo.CompnayDetails.Mobile, dbo.CompnayDetails.Fax, dbo.CompnayDetails.PANNO, dbo.CompnayDetails.VATNO, dbo.CompnayDetails.CSTNO, dbo.CompnayDetails.ServiceTaxAmmount, dbo.CompnayDetails.ExciseTaxAmmount,  dbo.CompnayDetails.GSTTaxAmmount, dbo.VendorDetails.vName, dbo.VendorDetails.vCompName, dbo.VendorDetails.vAddress, dbo.VendorDetails.vCity, dbo.VendorDetails.vState, dbo.VendorDetails.vZip, dbo.VendorDetails.vCountry, dbo.VendorDetails.vEmail, dbo.VendorDetails.vWebAddress,dbo.VendorDetails.vPhone, dbo.VendorDetails.vMobile, dbo.VendorDetails.vFax, dbo.VendorDetails.vPanNo, dbo.VendorDetails.vVatNo, dbo.VendorDetails.vCstNo, dbo.VendorDetails.vServiceTaxRegnNo, dbo.VendorDetails.vGSTRegnNo, dbo.VendorOrderDetails.TotalPrice, dbo.VendorOrderDetails.Discount, dbo.VendorOrderDetails.Vat, dbo.VendorOrderDetails.DisAmount, dbo.VendorOrderDetails.TextTaxAmmount, dbo.VendorOrderDetails.WithoutTexAmount, dbo.VendorOrderDesc.Orderid, dbo.VendorOrderDesc.ItemId, dbo.VendorOrderDesc.Price, dbo.VendorOrderDesc.Quantity, dbo.VendorOrderDesc.TotalPrice AS Expr1, dbo.ItemDetails.ItemName, dbo.ItemPriceDetail.MrpPrice, dbo.ItemPriceDetail.Margin FROM  dbo.CustomerOrderDelivery INNER JOIN dbo.VendorOrderDetails ON dbo.CustomerOrderDelivery.Orderid = dbo.VendorOrderDetails.Orderid INNER JOIN dbo.VendorDetails ON dbo.VendorOrderDetails.venderId = dbo.VendorDetails.venderId INNER JOIN dbo.VendorOrderDesc ON dbo.VendorOrderDetails.Orderid = dbo.VendorOrderDesc.Orderid INNER JOIN dbo.ItemDetails ON dbo.VendorOrderDesc.ItemId = dbo.ItemDetails.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId CROSS JOIN dbo.CompnayDetails";

                             //"select od.Orderid,od.venderId,itd.ItemName,vod.Quantity,vod.TotalPrice,od.OrderDate,cod.DeliveryDate,coi.InvoiceDate from VendorOrderDetails od join VendorOrderDesc vod on od.Orderid=vod.Orderid join CustomerOrderDelivery cod on cod.Orderid=vod.Orderid join CustomerOrderInvoice coi on coi.Orderid=vod.Orderid join ItemDetails itd on itd.ItemId=vod.ItemId";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            List<string> ls = new List<string>();
            DataColumnCollection d = dt.Columns;
            for (int a = 0; a < d.Count; a++)
            {
                DataColumn dc = new DataColumn();
                string b = d[a].ToString();
                ls.Add(b);
            }
            comboPurchasesearch.DataSource = ls;
            gridPurchaseSearch.DataSource = dt;*/

            //string selectqurry = "SELECT dbo.CustomerOrderDelivery.Deliveryid as[Invoice ID], dbo.VendorDetails.venderId as[Vendor ID],dbo.VendorDetails.vName as[Vendor Name], dbo.VendorDetails.vCompName as[Company Name], dbo.VendorDetails.vAddress as[Address], dbo.VendorDetails.vCity as[City], dbo.VendorDetails.vState as[State], dbo.VendorDetails.vZip as[Zip], dbo.VendorDetails.vCountry as[Country], dbo.VendorDetails.vEmail as[Email], dbo.VendorDetails.vWebAddress as[Web Address],dbo.VendorDetails.vPhone as[Phone], dbo.VendorDetails.vMobile as[Mobile], dbo.CustomerOrderDelivery.DeliveryDate as[Invoice Date], dbo.CustomerOrderDelivery.RefNo as[Order Ref. NO], dbo.VendorOrderDesc.ItemId as[Item ID], dbo.ItemDetails.ItemName as[Item Name], dbo.ItemDetails.ItemCompName as[Company Name], dbo.ItemPriceDetail.MrpPrice as[MRP], dbo.VendorOrderDesc.Price as[Selling Rate], dbo.VendorOrderDesc.Quantity as[Quantity Billed], dbo.VendorOrderDesc.TotalPrice AS [Gross Amount], dbo.VendorOrderDetails.Discount as[Discount Rate],((dbo.VendorOrderDesc.TotalPrice*dbo.VendorOrderDetails.Discount)/100) as [Discount Amount], dbo.VendorOrderDetails.Vat as[Tax], (dbo.VendorOrderDesc.TotalPrice)- ((dbo.VendorOrderDesc.TotalPrice)/(1+(dbo.VendorOrderDetails.Vat/100))) as [Tax Amount], dbo.VendorOrderDetails.TotalPrice as[Net Amount (Including Tax)] FROM  dbo.CustomerOrderDelivery INNER JOIN dbo.VendorOrderDetails ON dbo.CustomerOrderDelivery.Orderid = dbo.VendorOrderDetails.Orderid INNER JOIN dbo.VendorDetails ON dbo.VendorOrderDetails.venderId = dbo.VendorDetails.venderId INNER JOIN dbo.VendorOrderDesc ON dbo.VendorOrderDetails.Orderid = dbo.VendorOrderDesc.Orderid INNER JOIN dbo.ItemDetails ON dbo.VendorOrderDesc.ItemId = dbo.ItemDetails.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId ORDER BY Deliveryid ASC";
            string selectqurry = "SELECT dbo.CustomerOrderDelivery.Deliveryid as[Purchase Invoice ID], dbo.CustomerOrderDelivery.RefNo as[P.O. Reference No.],dbo.CustomerOrderDelivery.DeliveryDate as[Invoice Date], dbo.VendorDetails.venderId as[Vendor ID],dbo.VendorDetails.vName as[Vendor Name], dbo.VendorDetails.vCompName as[Company Name], dbo.VendorDetails.vAddress as[Address], dbo.VendorOrderDesc.ItemId as[Item ID], dbo.ItemDetails.ItemName as[Item Name], dbo.ItemDetails.ItemCompName as[Item Company Name],itd.HSN,cast(dbo.ItemPriceDetail.MrpPrice as numeric(38, 2)) as[MRP],cast(dbo.VendorOrderDesc.Price as numeric(38, 2)) as[Selling Rate],dbo.VendorOrderDesc.Quantity as [Quantity Billed],cast((dbo.VendorOrderDesc.Price)* (dbo.VendorOrderDesc.Quantity) as numeric(38,2)) AS [Gross Amount], itd.Discount as[Discount Rate (In %)],cast((dbo.VendorOrderDesc.Price)* (dbo.VendorOrderDesc.Quantity)*(itd.Discount/100) as numeric(38,2)) as [Discount Amount],cast((((dbo.VendorOrderDesc.Price)* (dbo.VendorOrderDesc.Quantity))-(dbo.VendorOrderDesc.Price)* (dbo.VendorOrderDesc.Quantity)*(itd.Discount/100))as numeric(38,2)) as [Taxable Value],(case when dbo.VendorDetails.vState  != (select state from CompnayDetails) then '0.00'else CGST end) as CGST,(case when dbo.VendorDetails.vState != (select state from CompnayDetails) then '0.0'else SGST end) as SGST,(case when dbo.VendorDetails.vState = (select state from CompnayDetails) then '0.00'else itd.IGST end) as IGST,itd.CESS, cast((dbo.VendorOrderDesc.TotalPrice) - ((dbo.VendorOrderDesc.TotalPrice * dbo.VendorOrderDetails.Discount) / 100) as numeric(38, 2)) AS[Net Amount (Including Tax)] ,p.InvoiceAmount as [Invoice Amount] ,p.[Paid Amount] ,p.Balance as[Balance Amount],(case when p.Balance > 0 then 'Delivered' else 'Fully settled' end) as [Delivery Status] FROM dbo.CustomerOrderDelivery INNER JOIN dbo.VendorOrderDetails ON dbo.CustomerOrderDelivery.Orderid = dbo.VendorOrderDetails.orderid INNER JOIN dbo.VendorDetails ON dbo.VendorOrderDetails.venderId = dbo.VendorDetails.venderId INNER JOIN dbo.VendorOrderDesc ON dbo.VendorOrderDetails.orderid = dbo.VendorOrderDesc.Orderid  INNER JOIN dbo.ItemDetails ON dbo.VendorOrderDesc.ItemId = dbo.ItemDetails.ItemId  INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId join ItemTaxDetail itd on itd.ItemId = dbo.ItemPriceDetail.ItemId left join  (select Invoiceid, MAX(InvoiceAmount) as InvoiceAmount, (MAX(InvoiceAmount) - sum(TotalAmount)) as Balance, sum(TotalAmount) as [Paid Amount] from AllPaymentDetailes  join CustomerOrderDelivery on AllPaymentDetailes.Invoiceid = CustomerOrderDelivery.Deliveryid group by Invoiceid) p on CustomerOrderDelivery.Deliveryid = p.Invoiceid  ORDER BY Deliveryid ASC";
            string selectqurryForActualColumnName = "SELECT top 1 dbo.CustomerOrderDelivery.Deliveryid, dbo.CustomerOrderDelivery.RefNo,dbo.CustomerOrderDelivery.DeliveryDate, dbo.VendorDetails.venderId,dbo.VendorDetails.vName, dbo.VendorDetails.vCompName, dbo.VendorDetails.vAddress, dbo.VendorOrderDesc.ItemId, dbo.ItemDetails.ItemName, dbo.ItemDetails.ItemCompName,itd.HSN,cast(dbo.ItemPriceDetail.MrpPrice as numeric(38, 2)),cast(dbo.VendorOrderDesc.Price as numeric(38, 2)),dbo.VendorOrderDesc.Quantity,cast((dbo.VendorOrderDesc.Price)* (dbo.VendorOrderDesc.Quantity) as numeric(38,2)), itd.Discount,cast((dbo.VendorOrderDesc.Price)* (dbo.VendorOrderDesc.Quantity)*(itd.Discount/100) as numeric(38,2)),cast((((dbo.VendorOrderDesc.Price)* (dbo.VendorOrderDesc.Quantity))-(dbo.VendorOrderDesc.Price)* (dbo.VendorOrderDesc.Quantity)*(itd.Discount/100))as numeric(38,2)),(case when dbo.VendorDetails.vState  != (select state from CompnayDetails) then '0.00'else CGST end),(case when dbo.VendorDetails.vState != (select state from CompnayDetails) then '0.0'else SGST end),(case when dbo.VendorDetails.vState = (select state from CompnayDetails) then '0.00'else itd.IGST end),itd.CESS, cast((dbo.VendorOrderDesc.TotalPrice) - ((dbo.VendorOrderDesc.TotalPrice * dbo.VendorOrderDetails.Discount) / 100) as numeric(38, 2)) ,p.InvoiceAmount  ,p.[Paid Amount] ,p.Balance,(case when p.Balance > 0 then 'Delivered' else 'Fully settled' end) FROM dbo.CustomerOrderDelivery INNER JOIN dbo.VendorOrderDetails ON dbo.CustomerOrderDelivery.Orderid = dbo.VendorOrderDetails.orderid INNER JOIN dbo.VendorDetails ON dbo.VendorOrderDetails.venderId = dbo.VendorDetails.venderId INNER JOIN dbo.VendorOrderDesc ON dbo.VendorOrderDetails.orderid = dbo.VendorOrderDesc.Orderid  INNER JOIN dbo.ItemDetails ON dbo.VendorOrderDesc.ItemId = dbo.ItemDetails.ItemId  INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId join ItemTaxDetail itd on itd.ItemId = dbo.ItemPriceDetail.ItemId left join  (select Invoiceid, MAX(InvoiceAmount) as InvoiceAmount, (MAX(InvoiceAmount) - sum(TotalAmount)) as Balance, sum(TotalAmount) as [Paid Amount] from AllPaymentDetailes  join CustomerOrderDelivery on AllPaymentDetailes.Invoiceid = CustomerOrderDelivery.Deliveryid group by Invoiceid) p on CustomerOrderDelivery.Deliveryid = p.Invoiceid ";
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
                string actualColumnName=dataColumnForName[a].ToString();
                DataRow dr = customDataTable.NewRow();
                dr["ActualTableColumnName"] = actualColumnName;
                dr["AliasTableColumnName"] = b;
                customDataTable.Rows.Add(dr);
                //  ls.Add(b);
            }

            comboPurchasesearch.DataSource = customDataTable;
            comboPurchasesearch.ValueMember = "ActualTableColumnName";
            comboPurchasesearch.DisplayMember = "AliasTableColumnName";
            gridPurchaseSearch.DataSource = dt;
            //DataGridViewRowCollection RowCollection = gridPurchaseSearch.Rows;
            commaind();
 
            // duplicate code , commind is doing same task, 
            //double dis;
            //double dis1 = 0;
            //double tax;
            //double tax1 = 0;
            //double gross;
            //double wta;
            //double wta1 = 0;
            //double gross1 = 0;
            //for (int a = 0; a < gridPurchaseSearch.Rows.Count; a++)
            //{
            //    gross = Convert.ToDouble(gridPurchaseSearch.Rows[a].Cells[13].Value);
            //  gross1 = gross1+gross;
            //  dis = Convert.ToDouble(gridPurchaseSearch.Rows[a].Cells[15].Value);
            //  dis1 = dis1 + dis;
            //  tax = Convert.ToDouble(gridPurchaseSearch.Rows[a].Cells[17].Value);
            //  tax1 = tax1 + tax;
            //  wta = Convert.ToDouble(gridPurchaseSearch.Rows[a].Cells[18].Value);
            //  wta1 = wta1 + wta;
            //}

            //TxtGrowsAmount.Text = gross1.ToString();
            //TxtDisAmount.Text = dis1.ToString();
            //TxtTaxAmount.Text = tax1.ToString();
            //TxtWithodTaxAmount.Text = wta1.ToString();
        }
        public void tabIndex()
        {
            panel1.TabIndex=1;
            groupBox2.TabIndex = 0;
            groupBox1.TabIndex = 5;
            dateTimePicker1.TabIndex = 6;
            btnClose.TabIndex = 4;
            ExportToExcel.TabIndex = 3;
            dateTimePicker2.TabIndex = 7;
            comboPurchasesearch.TabIndex = 8;
           // comboPurchasesearch.TabStop = false;
            gridPurchaseSearch.TabIndex = 2;
            txtsearch.TabIndex = 1;

        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string s = comboPurchasesearch.SelectedValue.ToString();
            if (s == "venderId")
            {
                s = "dbo.VendorDetails." + s;
            }
            else if (s == "Deliveryid")
            {
                s = "dbo.CustomerOrderDelivery." + s; ;
            }
            else if (s == "ItemId")
            {
                s = "dbo.VendorOrderDesc." + s;
            }
            else if (s == "DeliveryDate")
            {
                s = " dbo.CustomerOrderDelivery." + s;
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
                s = "cast(( dbo.VendorOrderDesc.TotalPrice)-((dbo.VendorOrderDesc.TotalPrice*dbo.VendorOrderDetails.Discount)/100)as numeric(38,2))";
            }
            else if (s == "MrpPrice")
            {
                s = "cast(dbo.ItemPriceDetail.MrpPrice as numeric(38,2))";
            }
            else if (s == "Price")
            {
                s = "cast(dbo.VendorOrderDesc.Price as numeric(38,2))";
            }
            else if (s == "TotalPrices")
            {
                s = "cast(dbo.VendorOrderDesc.TotalPrice as numeric(38,2))";
            }
            else if (s == "Delivery Status")
            {
                s = "(case when p.Balance > 0 then 'Delivered' else 'Fully settled' end)";
            }
            else if (s == "Paid Amount")
            {
                s = "p.[Paid Amount]";
            }
            else if (s == "Column5")
            {
                s = "cast((((dbo.VendorOrderDesc.Price)* (dbo.VendorOrderDesc.Quantity))-(dbo.VendorOrderDesc.Price)* (dbo.VendorOrderDesc.Quantity)*(itd.Discount/100))as numeric(38,2))";
            }
            else if (s == "Column6")
            {
                s = "(case when dbo.VendorDetails.vState  != (select state from CompnayDetails) then '0.00'else CGST end)";
            }
            else if (s == "Column7")
            {
                s = "(case when dbo.VendorDetails.vState != (select state from CompnayDetails) then '0.0'else SGST end)";
            }
            else if (s == "Column8")
            {
                s = " (case when dbo.VendorDetails.vState = (select state from CompnayDetails) then '0.00'else itd.IGST end)";
            }
            else if (s == "Column9")
            {
                s = " cast((dbo.VendorOrderDesc.TotalPrice) - ((dbo.VendorOrderDesc.TotalPrice * dbo.VendorOrderDetails.Discount) / 100) as numeric(38, 2))";
            }

            string selectQurry = "SELECT dbo.CustomerOrderDelivery.Deliveryid as[Purchase Invoice ID], dbo.CustomerOrderDelivery.RefNo as[P.O. Reference No.],dbo.CustomerOrderDelivery.DeliveryDate as[Invoice Date], dbo.VendorDetails.venderId as[Vendor ID],dbo.VendorDetails.vName as[Vendor Name], dbo.VendorDetails.vCompName as[Company Name],itd.HSN, dbo.VendorDetails.vAddress as[Address], dbo.VendorOrderDesc.ItemId as[Item ID], dbo.ItemDetails.ItemName as[Item Name], dbo.ItemDetails.ItemCompName as[Item Company Name],itd.HSN,cast(dbo.ItemPriceDetail.MrpPrice as numeric(38, 2)) as[MRP],cast(dbo.VendorOrderDesc.Price as numeric(38, 2)) as[Selling Rate],dbo.VendorOrderDesc.Quantity as [Quantity Billed],cast((dbo.VendorOrderDesc.Price)* (dbo.VendorOrderDesc.Quantity) as numeric(38,2)) AS [Gross Amount], itd.Discount as[Discount Rate (In %)],cast((dbo.VendorOrderDesc.Price)* (dbo.VendorOrderDesc.Quantity)*(itd.Discount/100) as numeric(38,2)) as [Discount Amount],cast((((dbo.VendorOrderDesc.Price)* (dbo.VendorOrderDesc.Quantity))-(dbo.VendorOrderDesc.Price)* (dbo.VendorOrderDesc.Quantity)*(itd.Discount/100))as numeric(38,2)) as [Taxable Value],(case when dbo.VendorDetails.vState  != (select state from CompnayDetails) then '0.00'else CGST end) as CGST,(case when dbo.VendorDetails.vState != (select state from CompnayDetails) then '0.0'else SGST end) as SGST,(case when dbo.VendorDetails.vState = (select state from CompnayDetails) then '0.00'else itd.IGST end) as IGST,itd.CESS, cast((dbo.VendorOrderDesc.TotalPrice) - ((dbo.VendorOrderDesc.TotalPrice * dbo.VendorOrderDetails.Discount) / 100) as numeric(38, 2)) AS[Net Amount (Including Tax)] ,p.InvoiceAmount as [Invoice Amount] ,p.[Paid Amount] ,p.Balance as[Balance Amount],(case when p.Balance > 0 then 'Delivered' else 'Fully settled' end) as [Delivery Status] FROM dbo.CustomerOrderDelivery INNER JOIN dbo.VendorOrderDetails ON dbo.CustomerOrderDelivery.Orderid = dbo.VendorOrderDetails.orderid INNER JOIN dbo.VendorDetails ON dbo.VendorOrderDetails.venderId = dbo.VendorDetails.venderId INNER JOIN dbo.VendorOrderDesc ON dbo.VendorOrderDetails.orderid = dbo.VendorOrderDesc.Orderid  INNER JOIN dbo.ItemDetails ON dbo.VendorOrderDesc.ItemId = dbo.ItemDetails.ItemId  INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId join ItemTaxDetail itd on itd.ItemId = dbo.ItemPriceDetail.ItemId left join  (select Invoiceid, MAX(InvoiceAmount) as InvoiceAmount, (MAX(InvoiceAmount) - sum(TotalAmount)) as Balance, sum(TotalAmount) as [Paid Amount] from AllPaymentDetailes  join CustomerOrderDelivery on AllPaymentDetailes.Invoiceid = CustomerOrderDelivery.Deliveryid group by Invoiceid) p on CustomerOrderDelivery.Deliveryid = p.Invoiceid where " + s + " like '" + txtsearch.Text + "%' and  DeliveryDate BETWEEN '" + dateTimePicker1.Text + " " + "0:00:00:000" + "' AND '" + dateTimePicker2.Text + " " + "23:59:00:000" + "'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            gridPurchaseSearch.DataSource = dt;
            commaind();
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataGridViewRowCollection RowCollection = gridPurchaseSearch.Rows;
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

        public void commaind()
        {
            double dis;
            double dis1 = 0;
            double tax;
            double tax1 = 0;
            double gross;
            double wta;
            double wta1 = 0;
            double gross1 = 0;
            int quntity;
            int quntity1 = 0;
            for (int a = 0; a < gridPurchaseSearch.Rows.Count; a++)
            {
                quntity = Convert.ToInt32(gridPurchaseSearch.Rows[a].Cells[13].Value);
                quntity1 = quntity1 + quntity;
                gross = Convert.ToDouble(gridPurchaseSearch.Rows[a].Cells[14].Value);
                gross1 = gross1 + gross;
                dis = Convert.ToDouble(gridPurchaseSearch.Rows[a].Cells[16].Value);
                dis1 = dis1 + dis;
                tax = Convert.ToDouble(gridPurchaseSearch.Rows[a].Cells[22].Value);
                tax1 = tax1 + tax;
                wta = Convert.ToDouble(gridPurchaseSearch.Rows[a].Cells[18].Value);
                wta1 = wta1 + wta;
            }

            TxtGrowsAmount.Text = gross1.ToString();
            TxtDisAmount.Text = dis1.ToString();
            TxtTaxAmount.Text = tax1.ToString();
            TxtWithodTaxAmount.Text = wta1.ToString();
            txtBildQuntity.Text = quntity1.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (gridPurchaseSearch.AllowUserToAddRows == true)
            {
                gridPurchaseSearch.AllowUserToAddRows = false;
            }
            string FileName = "";
            SaveFileDialog openFileDialog1 = new SaveFileDialog();
            //FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();
            openFileDialog1.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
            openFileDialog1.FileName = "Purchase Details";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog1.FileName;

                //}
                //DataGridViewColumnCollection column = dataGridView1.Columns;
                int cout = 0;
                int rowCoumt = 0;
                // column1 = dc.Name.ToString();
                string file = FileName;//+ ".xls"; //System.Configuration.ConfigurationManager.AppSettings["ExcelFilePath1"] + FolderName + "newdoc.xls";
                Workbook workbook = new Workbook();
                Worksheet worksheet = new Worksheet("First Sheet");

                foreach (DataGridViewColumn dc in gridPurchaseSearch.Columns)
                {

                    worksheet.Cells[rowCoumt, cout] = new Cell(dc.Name);
                    cout++;

                }

                //foreach (DataGridViewRow row in dataGridView1.Rows) { }
                DataGridViewRowCollection rowcollection = gridPurchaseSearch.Rows;

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
                gridPurchaseSearch.AllowUserToAddRows = true;
            }
            else
            {
                gridPurchaseSearch.AllowUserToAddRows = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /*string s = comboPurchasesearch.SelectedValue.ToString();
            string selectQurry = "SELECT dbo.VendorDetails.venderId as[Vendor ID],dbo.VendorDetails.vName as[Vendor Name], dbo.VendorDetails.vCompName as[Company Name], dbo.VendorDetails.vAddress as[Address], dbo.VendorDetails.vCity as[City], dbo.VendorDetails.vState as[State], dbo.VendorDetails.vZip as[Zip], dbo.VendorDetails.vCountry as[Country], dbo.VendorDetails.vEmail as[Email], dbo.VendorDetails.vWebAddress as[Web Address],dbo.VendorDetails.vPhone as[Phone], dbo.VendorDetails.vMobile as[Mobile],dbo.CustomerOrderDelivery.Deliveryid as[Invoice ID], dbo.CustomerOrderDelivery.DeliveryDate as[Invoice Date], dbo.CustomerOrderDelivery.RefNo as[Order Ref. NO], dbo.VendorOrderDesc.ItemId as[Item ID], dbo.ItemDetails.ItemName as[Item Name], dbo.ItemDetails.ItemCompName as[Company Name], dbo.ItemPriceDetail.MrpPrice as[MRP], dbo.VendorOrderDesc.Price as[Selling Rate], dbo.VendorOrderDesc.Quantity as[Quantity Billed], dbo.VendorOrderDesc.TotalPrice AS [Gross Amount], dbo.VendorOrderDetails.Discount as[Discount Rate],((dbo.VendorOrderDesc.TotalPrice*dbo.VendorOrderDetails.Discount)/100) as [Discount Amount], dbo.VendorOrderDetails.Vat as[Tax], (dbo.VendorOrderDesc.TotalPrice)- ((dbo.VendorOrderDesc.TotalPrice)/(1+(dbo.VendorOrderDetails.Vat/100))) as [Tax Amount], dbo.VendorOrderDetails.TotalPrice as[Net Amount (Including Tax)] FROM  dbo.CustomerOrderDelivery INNER JOIN dbo.VendorOrderDetails ON dbo.CustomerOrderDelivery.Orderid = dbo.VendorOrderDetails.Orderid INNER JOIN dbo.VendorDetails ON dbo.VendorOrderDetails.venderId = dbo.VendorDetails.venderId INNER JOIN dbo.VendorOrderDesc ON dbo.VendorOrderDetails.Orderid = dbo.VendorOrderDesc.Orderid INNER JOIN dbo.ItemDetails ON dbo.VendorOrderDesc.ItemId = dbo.ItemDetails.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId where DeliveryDate BETWEEN '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "'";
            //"select od.Orderid,od.venderId,itd.ItemName,vod.Quantity,vod.TotalPrice,od.OrderDate,cod.DeliveryDate,coi.InvoiceDate from VendorOrderDetails od join VendorOrderDesc vod on vod.Orderid=od.Orderid join CustomerOrderDelivery cod on cod.Orderid=vod.Orderid join CustomerOrderInvoice coi on coi.Orderid=vod.Orderid join ItemDetails itd on itd.ItemId=vod.ItemId where " + a + "= '" + txtsearch.Text + "'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);

            gridPurchaseSearch.DataSource = dt;
            commaind();*/

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            setDate();
        }
        public void setDate()
        {
            DateTime date = Convert.ToDateTime(dateTimePicker2.Text);
            if (date > DateTime.Now.Date)
            {

                MessageBox.Show("please enter the currect date");
                dateTimePicker2.Text = DateTime.Now.ToString();

            }
            DateTime date1 = Convert.ToDateTime(dateTimePicker1.Text);
            if (date1 > DateTime.Now.Date)
            {

                MessageBox.Show("please enter the currect date");
                 dateTimePicker1.Text = DateTime.Now.ToString();

            }
            //string s = comboPurchasesearch.SelectedValue.ToString();
            string selectQurry = "SELECT dbo.CustomerOrderDelivery.Deliveryid as[Purchase Invoice ID], dbo.CustomerOrderDelivery.RefNo as[P.O. Reference No.],dbo.CustomerOrderDelivery.DeliveryDate as[Invoice Date], dbo.VendorDetails.venderId as[Vendor ID],dbo.VendorDetails.vName as[Vendor Name], dbo.VendorDetails.vCompName as[Company Name], dbo.VendorDetails.vAddress as[Address], dbo.VendorOrderDesc.ItemId as[Item ID], dbo.ItemDetails.ItemName as[Item Name], dbo.ItemDetails.ItemCompName as[Item Company Name],itd.HSN,cast(dbo.ItemPriceDetail.MrpPrice as numeric(38, 2)) as[MRP],cast(dbo.VendorOrderDesc.Price as numeric(38, 2)) as[Selling Rate],dbo.VendorOrderDesc.Quantity as [Quantity Billed],cast((dbo.VendorOrderDesc.Price)* (dbo.VendorOrderDesc.Quantity) as numeric(38,2)) AS [Gross Amount], itd.Discount as[Discount Rate (In %)],cast((dbo.VendorOrderDesc.Price)* (dbo.VendorOrderDesc.Quantity)*(itd.Discount/100) as numeric(38,2)) as [Discount Amount],cast((((dbo.VendorOrderDesc.Price)* (dbo.VendorOrderDesc.Quantity))-(dbo.VendorOrderDesc.Price)* (dbo.VendorOrderDesc.Quantity)*(itd.Discount/100))as numeric(38,2)) as [Taxable Value],(case when dbo.VendorDetails.vState  != (select state from CompnayDetails) then '0.00'else CGST end) as CGST,(case when dbo.VendorDetails.vState != (select state from CompnayDetails) then '0.0'else SGST end) as SGST,(case when dbo.VendorDetails.vState = (select state from CompnayDetails) then '0.00'else itd.IGST end) as IGST,itd.CESS, cast((dbo.VendorOrderDesc.TotalPrice) - ((dbo.VendorOrderDesc.TotalPrice * dbo.VendorOrderDetails.Discount) / 100) as numeric(38, 2)) AS[Net Amount (Including Tax)] ,p.InvoiceAmount as [Invoice Amount] ,p.[Paid Amount] ,p.Balance as[Balance Amount],(case when p.Balance > 0 then 'Delivered' else 'Fully settled' end) as [Delivery Status] FROM dbo.CustomerOrderDelivery INNER JOIN dbo.VendorOrderDetails ON dbo.CustomerOrderDelivery.Orderid = dbo.VendorOrderDetails.orderid INNER JOIN dbo.VendorDetails ON dbo.VendorOrderDetails.venderId = dbo.VendorDetails.venderId INNER JOIN dbo.VendorOrderDesc ON dbo.VendorOrderDetails.orderid = dbo.VendorOrderDesc.Orderid  INNER JOIN dbo.ItemDetails ON dbo.VendorOrderDesc.ItemId = dbo.ItemDetails.ItemId  INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId join ItemTaxDetail itd on itd.ItemId = dbo.ItemPriceDetail.ItemId left join  (select Invoiceid, MAX(InvoiceAmount) as InvoiceAmount, (MAX(InvoiceAmount) - sum(TotalAmount)) as Balance, sum(TotalAmount) as [Paid Amount] from AllPaymentDetailes  join CustomerOrderDelivery on AllPaymentDetailes.Invoiceid = CustomerOrderDelivery.Deliveryid group by Invoiceid) p on CustomerOrderDelivery.Deliveryid = p.Invoiceid where DeliveryDate BETWEEN '" + dateTimePicker1.Text + " " + "0:00:00:000" + "' AND '" + dateTimePicker2.Text + " " + "23:59:00:000" + "'";
            //"select od.Orderid,od.venderId,itd.ItemName,vod.Quantity,vod.TotalPrice,od.OrderDate,cod.DeliveryDate,coi.InvoiceDate from VendorOrderDetails od join VendorOrderDesc vod on vod.Orderid=od.Orderid join CustomerOrderDelivery cod on cod.Orderid=vod.Orderid join CustomerOrderInvoice coi on coi.Orderid=vod.Orderid join ItemDetails itd on itd.ItemId=vod.ItemId where " + a + "= '" + txtsearch.Text + "'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            gridPurchaseSearch.DataSource = dt;
            commaind();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            setDate();
        }
        private void txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtBildQuntity_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGrowsAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtDisAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtTaxAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtWithodTaxAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

       
    }
}
