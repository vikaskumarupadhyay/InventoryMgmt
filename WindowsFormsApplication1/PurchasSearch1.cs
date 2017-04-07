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
    public partial class PurchasSearch1 : Form
    {
        public PurchasSearch1()
        {
            InitializeComponent();
        }
         DB_Main dbMainClass = new DB_Main();
        
        private void PurchasSearch_Load(object sender, EventArgs e)
        {/*
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
            string selectqurry = "SELECT dbo.CustomerOrderDelivery.Deliveryid as[Deliveri ID], dbo.CustomerOrderDelivery.DeliveryDate as[Delivery Date], dbo.CompnayDetails.Name as[Company Name], dbo.CompnayDetails.Address as[Address],dbo.CompnayDetails.City as[City], dbo.CompnayDetails.State as[State], dbo.CompnayDetails.Zip as[Zip], dbo.CompnayDetails.Country as[Country], dbo.CompnayDetails.Email as[Email],dbo.CompnayDetails.WebAddress as[Web Address], dbo.CompnayDetails.Phone as[Phone], dbo.CompnayDetails.Mobile as[Mobile], dbo.CompnayDetails.Fax as[Fax], dbo.CompnayDetails.PANNO as [PAN NO], dbo.CompnayDetails.VATNO as[VAT NO], dbo.CompnayDetails.CSTNO as[CST NO], dbo.CompnayDetails.ServiceTaxAmmount as[Service TaxAmmount], dbo.CompnayDetails.ExciseTaxAmmount as[Excise TaxAmmount],  dbo.CompnayDetails.GSTTaxAmmount as[GST TaxAmmount], dbo.VendorDetails.vName as[Vendor Name], dbo.VendorDetails.vCompName as[Vendor Company Name], dbo.VendorDetails.vAddress as[Vendor Name], dbo.VendorDetails.vCity as[City], dbo.VendorDetails.vState as[State], dbo.VendorDetails.vZip as[Zip], dbo.VendorDetails.vCountry as[Country], dbo.VendorDetails.vEmail as[Email], dbo.VendorDetails.vWebAddress as[Web Address],dbo.VendorDetails.vPhone as[Phone], dbo.VendorDetails.vMobile as[Mobile], dbo.VendorDetails.vFax as[Fax], dbo.VendorDetails.vPanNo as[PAN NO], dbo.VendorDetails.vVatNo as[VAT NO], dbo.VendorDetails.vCstNo as[CST NO], dbo.VendorDetails.vServiceTaxRegnNo as[Service TaxRegn No], dbo.VendorDetails.vGSTRegnNo as[GST Regn No], dbo.VendorOrderDetails.TotalPrice as[Total Price], dbo.VendorOrderDetails.Discount as[Discount], dbo.VendorOrderDetails.Vat as[VAT], dbo.VendorOrderDetails.DisAmount as[Dis Amount], dbo.VendorOrderDetails.TextTaxAmmount as[TextTaxAmmount], dbo.VendorOrderDetails.WithoutTexAmount as[Without TexAmount], dbo.VendorOrderDesc.Orderid as[Order ID], dbo.VendorOrderDesc.ItemId as[Item ID], dbo.VendorOrderDesc.Price as[Price], dbo.VendorOrderDesc.Quantity as[Quantity], dbo.VendorOrderDesc.TotalPrice AS Expr1, dbo.ItemDetails.ItemName as[Item Name], dbo.ItemPriceDetail.MrpPrice as[Mrp Price], dbo.ItemPriceDetail.Margin as[Margin] FROM  dbo.CustomerOrderDelivery INNER JOIN dbo.VendorOrderDetails ON dbo.CustomerOrderDelivery.Orderid = dbo.VendorOrderDetails.Orderid INNER JOIN dbo.VendorDetails ON dbo.VendorOrderDetails.venderId = dbo.VendorDetails.venderId INNER JOIN dbo.VendorOrderDesc ON dbo.VendorOrderDetails.Orderid = dbo.VendorOrderDesc.Orderid INNER JOIN dbo.ItemDetails ON dbo.VendorOrderDesc.ItemId = dbo.ItemDetails.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId CROSS JOIN dbo.CompnayDetails";
            string selectqurryForActualColumnName = "select top 1 dbo.CustomerOrderDelivery.Deliveryid, dbo.CustomerOrderDelivery.DeliveryDate, dbo.CompnayDetails.Name, dbo.CompnayDetails.Address,dbo.CompnayDetails.City, dbo.CompnayDetails.State, dbo.CompnayDetails.Zip, dbo.CompnayDetails.Country, dbo.CompnayDetails.Email,dbo.CompnayDetails.WebAddress, dbo.CompnayDetails.Phone, dbo.CompnayDetails.Mobile, dbo.CompnayDetails.Fax, dbo.CompnayDetails.PANNO, dbo.CompnayDetails.VATNO, dbo.CompnayDetails.CSTNO, dbo.CompnayDetails.ServiceTaxAmmount, dbo.CompnayDetails.ExciseTaxAmmount,  dbo.CompnayDetails.GSTTaxAmmount, dbo.VendorDetails.vName, dbo.VendorDetails.vCompName, dbo.VendorDetails.vAddress, dbo.VendorDetails.vCity, dbo.VendorDetails.vState, dbo.VendorDetails.vZip, dbo.VendorDetails.vCountry, dbo.VendorDetails.vEmail, dbo.VendorDetails.vWebAddress,dbo.VendorDetails.vPhone, dbo.VendorDetails.vMobile, dbo.VendorDetails.vFax, dbo.VendorDetails.vPanNo, dbo.VendorDetails.vVatNo, dbo.VendorDetails.vCstNo, dbo.VendorDetails.vServiceTaxRegnNo, dbo.VendorDetails.vGSTRegnNo, dbo.VendorOrderDetails.TotalPrice, dbo.VendorOrderDetails.Discount, dbo.VendorOrderDetails.Vat, dbo.VendorOrderDetails.DisAmount, dbo.VendorOrderDetails.TextTaxAmmount, dbo.VendorOrderDetails.WithoutTexAmount, dbo.VendorOrderDesc.Orderid, dbo.VendorOrderDesc.ItemId, dbo.VendorOrderDesc.Price, dbo.VendorOrderDesc.Quantity, dbo.VendorOrderDesc.TotalPrice AS Expr1, dbo.ItemDetails.ItemName, dbo.ItemPriceDetail.MrpPrice, dbo.ItemPriceDetail.Margin FROM  dbo.CustomerOrderDelivery INNER JOIN dbo.VendorOrderDetails ON dbo.CustomerOrderDelivery.Orderid = dbo.VendorOrderDetails.Orderid INNER JOIN dbo.VendorDetails ON dbo.VendorOrderDetails.venderId = dbo.VendorDetails.venderId INNER JOIN dbo.VendorOrderDesc ON dbo.VendorOrderDetails.Orderid = dbo.VendorOrderDesc.Orderid INNER JOIN dbo.ItemDetails ON dbo.VendorOrderDesc.ItemId = dbo.ItemDetails.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId CROSS JOIN dbo.CompnayDetails";
            DataTable dt = dbMainClass.getDetailByQuery(selectqurry);
            DataTable dtOnlyColumnName = dbMainClass.getDetailByQuery(selectqurryForActualColumnName);
            DataTable customDataTable = new DataTable();
            customDataTable.Columns.Add("ActualTableColumnName");
            customDataTable.Columns.Add("AliasTableColumnName");
            //List<string> ls = new List<string>();
            DataColumnCollection d = dt.Columns;
            DataColumnCollection dataColumnForName = dtOnlyColumnName.Columns;
            for (int a = 2; a < d.Count; a++)
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
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string s = comboPurchasesearch.SelectedValue.ToString();
            if (s == "Orderid")
            {
                s = "od.Orderid";
                get(s);
            }
            else if (s == "OrderDate")
            {
                s = "od.OrderDate";
                get1(s);

            }
            else if (s == "DeliveryDate")
            {
                s = "cod.DeliveryDate";
                get1(s);
            }
            else if (s == "InvoiceDate")
            {
                s = "coi.InvoiceDate";
                get1(s);
                //string selectQurry = "select od.Orderid,od.venderId,itd.ItemName,vod.Quantity,vod.TotalPrice,od.OrderDate,cod.DeliveryDate,coi.InvoiceDate from VendorOrderDetails od join VendorOrderDesc vod on vod.Orderid=od.Orderid join CustomerOrderDelivery cod on cod.Orderid=vod.Orderid join CustomerOrderInvoice coi on coi.Orderid=vod.Orderid join ItemDetails itd on itd.ItemId=vod.ItemId where " + s + " = '" + txtsearch.Text + "'";
                //DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
                //gridPurchaseSearch.DataSource = dt;
            }
            else if (s == "TotalPrice")
            {
                s = "vod.TotalPrice";
                get(s);
            }
            else
            {
                get(s);
            }
        }
        private void get(string a)
        {
            string selectQurry = "SELECT dbo.CustomerOrderDelivery.Deliveryid as[Deliveri ID], dbo.CustomerOrderDelivery.DeliveryDate as[Delivery Date], dbo.CompnayDetails.Name as[Company Name], dbo.CompnayDetails.Address as[Address],dbo.CompnayDetails.City as[City], dbo.CompnayDetails.State as[State], dbo.CompnayDetails.Zip as[Zip], dbo.CompnayDetails.Country as[Country], dbo.CompnayDetails.Email as[Email],dbo.CompnayDetails.WebAddress as[Web Address], dbo.CompnayDetails.Phone as[Phone], dbo.CompnayDetails.Mobile as[Mobile], dbo.CompnayDetails.Fax as[Fax], dbo.CompnayDetails.PANNO as [PAN NO], dbo.CompnayDetails.VATNO as[VAT NO], dbo.CompnayDetails.CSTNO as[CST NO], dbo.CompnayDetails.ServiceTaxAmmount as[Service TaxAmmount], dbo.CompnayDetails.ExciseTaxAmmount as[Excise TaxAmmount],  dbo.CompnayDetails.GSTTaxAmmount as[GST TaxAmmount], dbo.VendorDetails.vName as[Vendor Name], dbo.VendorDetails.vCompName as[Vendor Company Name], dbo.VendorDetails.vAddress as[Vendor Name], dbo.VendorDetails.vCity as[City], dbo.VendorDetails.vState as[State], dbo.VendorDetails.vZip as[Zip], dbo.VendorDetails.vCountry as[Country], dbo.VendorDetails.vEmail as[Email], dbo.VendorDetails.vWebAddress as[Web Address],dbo.VendorDetails.vPhone as[Phone], dbo.VendorDetails.vMobile as[Mobile], dbo.VendorDetails.vFax as[Fax], dbo.VendorDetails.vPanNo as[PAN NO], dbo.VendorDetails.vVatNo as[VAT NO], dbo.VendorDetails.vCstNo as[CST NO], dbo.VendorDetails.vServiceTaxRegnNo as[Service TaxRegn No], dbo.VendorDetails.vGSTRegnNo as[GST Regn No], dbo.VendorOrderDetails.TotalPrice as[Total Price], dbo.VendorOrderDetails.Discount as[Discount], dbo.VendorOrderDetails.Vat as[VAT], dbo.VendorOrderDetails.DisAmount as[Dis Amount], dbo.VendorOrderDetails.TextTaxAmmount as[TextTaxAmmount], dbo.VendorOrderDetails.WithoutTexAmount as[Without TexAmount], dbo.VendorOrderDesc.Orderid as[Order ID], dbo.VendorOrderDesc.ItemId as[Item ID], dbo.VendorOrderDesc.Price as[Price], dbo.VendorOrderDesc.Quantity as[Quantity], dbo.VendorOrderDesc.TotalPrice AS Expr1, dbo.ItemDetails.ItemName as[Item Name], dbo.ItemPriceDetail.MrpPrice as[Mrp Price], dbo.ItemPriceDetail.Margin as[Margin] FROM  dbo.CustomerOrderDelivery INNER JOIN dbo.VendorOrderDetails ON dbo.CustomerOrderDelivery.Orderid = dbo.VendorOrderDetails.Orderid INNER JOIN dbo.VendorDetails ON dbo.VendorOrderDetails.venderId = dbo.VendorDetails.venderId INNER JOIN dbo.VendorOrderDesc ON dbo.VendorOrderDetails.Orderid = dbo.VendorOrderDesc.Orderid INNER JOIN dbo.ItemDetails ON dbo.VendorOrderDesc.ItemId = dbo.ItemDetails.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId CROSS JOIN dbo.CompnayDetails where " + a + " like '" + txtsearch.Text + "%'";
                //"select od.Orderid,od.venderId,itd.ItemName,vod.Quantity,vod.TotalPrice,od.OrderDate,cod.DeliveryDate,coi.InvoiceDate from VendorOrderDetails od join VendorOrderDesc vod on vod.Orderid=od.Orderid join CustomerOrderDelivery cod on cod.Orderid=vod.Orderid join CustomerOrderInvoice coi on coi.Orderid=vod.Orderid join ItemDetails itd on itd.ItemId=vod.ItemId where " + a + " like '" + txtsearch.Text + "%'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            gridPurchaseSearch.DataSource = dt;
        }
        private void get1(string a)
        {
            string selectQurry = "SELECT dbo.CustomerOrderDelivery.Deliveryid as[Deliveri ID], dbo.CustomerOrderDelivery.DeliveryDate as[Delivery Date], dbo.CompnayDetails.Name as[Company Name], dbo.CompnayDetails.Address as[Address],dbo.CompnayDetails.City as[City], dbo.CompnayDetails.State as[State], dbo.CompnayDetails.Zip as[Zip], dbo.CompnayDetails.Country as[Country], dbo.CompnayDetails.Email as[Email],dbo.CompnayDetails.WebAddress as[Web Address], dbo.CompnayDetails.Phone as[Phone], dbo.CompnayDetails.Mobile as[Mobile], dbo.CompnayDetails.Fax as[Fax], dbo.CompnayDetails.PANNO as [PAN NO], dbo.CompnayDetails.VATNO as[VAT NO], dbo.CompnayDetails.CSTNO as[CST NO], dbo.CompnayDetails.ServiceTaxAmmount as[Service TaxAmmount], dbo.CompnayDetails.ExciseTaxAmmount as[Excise TaxAmmount],  dbo.CompnayDetails.GSTTaxAmmount as[GST TaxAmmount], dbo.VendorDetails.vName as[Vendor Name], dbo.VendorDetails.vCompName as[Vendor Company Name], dbo.VendorDetails.vAddress as[Vendor Name], dbo.VendorDetails.vCity as[City], dbo.VendorDetails.vState as[State], dbo.VendorDetails.vZip as[Zip], dbo.VendorDetails.vCountry as[Country], dbo.VendorDetails.vEmail as[Email], dbo.VendorDetails.vWebAddress as[Web Address],dbo.VendorDetails.vPhone as[Phone], dbo.VendorDetails.vMobile as[Mobile], dbo.VendorDetails.vFax as[Fax], dbo.VendorDetails.vPanNo as[PAN NO], dbo.VendorDetails.vVatNo as[VAT NO], dbo.VendorDetails.vCstNo as[CST NO], dbo.VendorDetails.vServiceTaxRegnNo as[Service TaxRegn No], dbo.VendorDetails.vGSTRegnNo as[GST Regn No], dbo.VendorOrderDetails.TotalPrice as[Total Price], dbo.VendorOrderDetails.Discount as[Discount], dbo.VendorOrderDetails.Vat as[VAT], dbo.VendorOrderDetails.DisAmount as[Dis Amount], dbo.VendorOrderDetails.TextTaxAmmount as[TextTaxAmmount], dbo.VendorOrderDetails.WithoutTexAmount as[Without TexAmount], dbo.VendorOrderDesc.Orderid as[Order ID], dbo.VendorOrderDesc.ItemId as[Item ID], dbo.VendorOrderDesc.Price as[Price], dbo.VendorOrderDesc.Quantity as[Quantity], dbo.VendorOrderDesc.TotalPrice AS Expr1, dbo.ItemDetails.ItemName as[Item Name], dbo.ItemPriceDetail.MrpPrice as[Mrp Price], dbo.ItemPriceDetail.Margin as[Margin] FROM  dbo.CustomerOrderDelivery INNER JOIN dbo.VendorOrderDetails ON dbo.CustomerOrderDelivery.Orderid = dbo.VendorOrderDetails.Orderid INNER JOIN dbo.VendorDetails ON dbo.VendorOrderDetails.venderId = dbo.VendorDetails.venderId INNER JOIN dbo.VendorOrderDesc ON dbo.VendorOrderDetails.Orderid = dbo.VendorOrderDesc.Orderid INNER JOIN dbo.ItemDetails ON dbo.VendorOrderDesc.ItemId = dbo.ItemDetails.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId CROSS JOIN dbo.CompnayDetails where " + a + " like '" + txtsearch.Text + "%'";
            //"select od.Orderid,od.venderId,itd.ItemName,vod.Quantity,vod.TotalPrice,od.OrderDate,cod.DeliveryDate,coi.InvoiceDate from VendorOrderDetails od join VendorOrderDesc vod on vod.Orderid=od.Orderid join CustomerOrderDelivery cod on cod.Orderid=vod.Orderid join CustomerOrderInvoice coi on coi.Orderid=vod.Orderid join ItemDetails itd on itd.ItemId=vod.ItemId where " + a + "= '" + txtsearch.Text + "'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            gridPurchaseSearch.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string s = comboPurchasesearch.SelectedValue.ToString();
            string selectQurry = "SELECT dbo.CustomerOrderDelivery.Deliveryid as[Deliveri ID], dbo.CustomerOrderDelivery.DeliveryDate as[Delivery Date], dbo.CompnayDetails.Name as[Company Name], dbo.CompnayDetails.Address as[Address],dbo.CompnayDetails.City as[City], dbo.CompnayDetails.State as[State], dbo.CompnayDetails.Zip as[Zip], dbo.CompnayDetails.Country as[Country], dbo.CompnayDetails.Email as[Email],dbo.CompnayDetails.WebAddress as[Web Address], dbo.CompnayDetails.Phone as[Phone], dbo.CompnayDetails.Mobile as[Mobile], dbo.CompnayDetails.Fax as[Fax], dbo.CompnayDetails.PANNO as [PAN NO], dbo.CompnayDetails.VATNO as[VAT NO], dbo.CompnayDetails.CSTNO as[CST NO], dbo.CompnayDetails.ServiceTaxAmmount as[Service TaxAmmount], dbo.CompnayDetails.ExciseTaxAmmount as[Excise TaxAmmount],  dbo.CompnayDetails.GSTTaxAmmount as[GST TaxAmmount], dbo.VendorDetails.vName as[Vendor Name], dbo.VendorDetails.vCompName as[Vendor Company Name], dbo.VendorDetails.vAddress as[Vendor Name], dbo.VendorDetails.vCity as[City], dbo.VendorDetails.vState as[State], dbo.VendorDetails.vZip as[Zip], dbo.VendorDetails.vCountry as[Country], dbo.VendorDetails.vEmail as[Email], dbo.VendorDetails.vWebAddress as[Web Address],dbo.VendorDetails.vPhone as[Phone], dbo.VendorDetails.vMobile as[Mobile], dbo.VendorDetails.vFax as[Fax], dbo.VendorDetails.vPanNo as[PAN NO], dbo.VendorDetails.vVatNo as[VAT NO], dbo.VendorDetails.vCstNo as[CST NO], dbo.VendorDetails.vServiceTaxRegnNo as[Service TaxRegn No], dbo.VendorDetails.vGSTRegnNo as[GST Regn No], dbo.VendorOrderDetails.TotalPrice as[Total Price], dbo.VendorOrderDetails.Discount as[Discount], dbo.VendorOrderDetails.Vat as[VAT], dbo.VendorOrderDetails.DisAmount as[Dis Amount], dbo.VendorOrderDetails.TextTaxAmmount as[TextTaxAmmount], dbo.VendorOrderDetails.WithoutTexAmount as[Without TexAmount], dbo.VendorOrderDesc.Orderid as[Order ID], dbo.VendorOrderDesc.ItemId as[Item ID], dbo.VendorOrderDesc.Price as[Price], dbo.VendorOrderDesc.Quantity as[Quantity], dbo.VendorOrderDesc.TotalPrice AS Expr1, dbo.ItemDetails.ItemName as[Item Name], dbo.ItemPriceDetail.MrpPrice as[Mrp Price], dbo.ItemPriceDetail.Margin as[Margin] FROM  dbo.CustomerOrderDelivery INNER JOIN dbo.VendorOrderDetails ON dbo.CustomerOrderDelivery.Orderid = dbo.VendorOrderDetails.Orderid INNER JOIN dbo.VendorDetails ON dbo.VendorOrderDetails.venderId = dbo.VendorDetails.venderId INNER JOIN dbo.VendorOrderDesc ON dbo.VendorOrderDetails.Orderid = dbo.VendorOrderDesc.Orderid INNER JOIN dbo.ItemDetails ON dbo.VendorOrderDesc.ItemId = dbo.ItemDetails.ItemId INNER JOIN dbo.ItemPriceDetail ON dbo.ItemDetails.ItemId = dbo.ItemPriceDetail.ItemId CROSS JOIN dbo.CompnayDetails where DeliveryDate BETWEEN '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "'";
            //"select od.Orderid,od.venderId,itd.ItemName,vod.Quantity,vod.TotalPrice,od.OrderDate,cod.DeliveryDate,coi.InvoiceDate from VendorOrderDetails od join VendorOrderDesc vod on vod.Orderid=od.Orderid join CustomerOrderDelivery cod on cod.Orderid=vod.Orderid join CustomerOrderInvoice coi on coi.Orderid=vod.Orderid join ItemDetails itd on itd.ItemId=vod.ItemId where " + a + "= '" + txtsearch.Text + "'";
            DataTable dt = dbMainClass.getDetailByQuery(selectQurry);
            gridPurchaseSearch.DataSource = dt;
        }
    }
}
