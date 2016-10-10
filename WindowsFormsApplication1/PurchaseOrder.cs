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
    public partial class PurchaseOrder : Form
    {
        public PurchaseOrder()
        {
            InitializeComponent();
        }
        DataTable vendorDetails = new DataTable();
        DataTable ItemDetails = new DataTable();
        DataTable addToCartTable = new DataTable();

        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            
            Purchase.PurchaseDetails purChaseDetailObj=new Purchase.PurchaseDetails ();
            vendorDetails = purChaseDetailObj.GetVendorDetaisInDataTable();
            ItemDetails = purChaseDetailObj.GetItemPriceAndNameDetaisInDataTable();
            setAutoCompleteMode(txtProductName, "ItemName", ItemDetails);
            setAddToCraftTable();
            //setAutoCompleteMode(txtVendorName, "Name", vendorDetails);
        }

        private void txtVendorCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtVendorCode_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
        private void setVAlue() 
        {
            if (vendorDetails.Rows.Count > 0)
            {
                string vendorId = txtVendorCode.Text;
                if (vendorId.Trim() != "" && vendorId != null)
                {
                    DataRow[] dr = vendorDetails.Select("vendorid='"+vendorId+"'");
                    if (dr != null && dr.Length > 0)
                    {
                        //venderId, , vCompName, vAddress, vCity, vState, vZip, vCountry, vEmail, vWebAddress, vPhone, vMobile, vFax, vDesc
                        string vendorName = dr[0]["Name"].ToString();
                        string vendorAddress = dr[0]["Address"].ToString();
                        string vendorCompName = dr[0]["CompanyName"].ToString();
                        string vendorPhone = dr[0]["Phone"].ToString();
                        string vendorMobile = dr[0]["Mobile"].ToString();
                        string vendorFax = dr[0]["Fax"].ToString();

                        txtVendorName.Text = vendorName;
                        txtVendorAddress.Text = vendorAddress;
                        txtVendorCompanyName.Text = vendorCompName;
                        txtVendorPhone.Text = vendorPhone;
                        txtVendorMobile.Text = vendorMobile;
                        txtVendorFax.Text = vendorFax;
                    }
                    else 
                    {
                        txtVendorName.Text ="";
                        txtVendorAddress.Text = "";
                        txtVendorCompanyName.Text ="";
                        txtVendorPhone.Text = "";
                        txtVendorMobile.Text = "";
                        txtVendorFax.Text ="";
                    }
                }
            }
        }

        private void txtVendorCode_Leave(object sender, EventArgs e)
        {
            ///setVAlue();
        }
        private void setAutoCompleteMode(TextBox txt, string ColumnName, DataTable dt) 
        {
            if (dt != null && dt.Rows.Count > 0) 
            {
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                foreach (DataRow dr in dt.Rows) 
                {
                    string value =dr[ColumnName].ToString();
                    collection.Add(value);
                }
                
                txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt.AutoCompleteCustomSource = collection;
           
            }
        }

        private void txtVendorCode_TextChanged(object sender, EventArgs e)
        {
            if (txtVendorCode.Text.Trim() != "" && txtVendorCode.Text.StartsWith("V")) 
            {
                setVAlue();
            }
        }



        private void setitemVlue(string ColumnName,string value)
        {
            if (ItemDetails.Rows.Count > 0)
            {
                string ItemId = txtItemCode.Text;
                if (value.Trim() != "" && value != null)
                {
                    DataRow[] dr = ItemDetails.Select(ColumnName+"='"+value+"'");
                    if (dr != null && dr.Length > 0)
                    {
                        //venderId, , vCompName, vAddress, vCity, vState, vZip, vCountry, vEmail, vWebAddress, vPhone, vMobile, vFax, vDesc
                        string ItemName = dr[0]["ItemName"].ToString();
                        string salesPrice = dr[0]["SalesPrice"].ToString();
                        string itemCode = dr[0]["ItemID"].ToString();
                        txtRate.Text = salesPrice;
                        txtProductName.Text = ItemName;
                        
                        txtItemCode.Text = itemCode;

                        if (ColumnName.StartsWith("ItemId"))
                        {
                            txtQuanity.Focus();
                        }
                    }
                    else
                    {
                        txtRate.Text = "";
                        if (ColumnName.StartsWith("ItemId")) 
                        {
                         txtProductName.Text = "";
                        }
                        else if (ColumnName.StartsWith("ItemName"))
                        {
                            txtItemCode.Text = "";
                        }
                        
                    }
                }
            }
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            string itemCode = txtItemCode.Text;
            setitemVlue("ItemId", itemCode);
            
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            string value = txtProductName.SelectedText;
            string val = txtProductName.Text;
        }

        private void txtProductName_Leave(object sender, EventArgs e)
        {
            string ItemName = txtProductName.Text.Trim();
            setitemVlue("ItemName", ItemName);
        }

        private void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//|| e.KeyCode==Keys.Space) 
            {
                setitemVlue("ItemName", txtProductName.Text.Trim());
                txtQuanity.Focus();
            }
        }

        private void txtQuanity_TextChanged(object sender, EventArgs e)
        {
            string QuantiTy = txtQuanity.Text;
         int result=0;
         if (int.TryParse(QuantiTy, out result)) 
         {
         
             int  TotalQuantity= Convert.ToInt32(QuantiTy);
             if (TotalQuantity > 0)
             {
                 double RatePerPice = Convert.ToDouble(txtRate.Text.Trim());
                 txtAmount.Text = (TotalQuantity * RatePerPice).ToString();
             }
             else 
             {
                 txtAmount.Text = "";
             }
         }
        }

        #region /////////// AddToList Clicked ///////////////
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            DataRow dr= addToCartTable.NewRow();
            dr[0] = txtItemCode.Text.Trim();
            dr[1] = txtProductName.Text.Trim();
            dr[2] = txtRate.Text.Trim();
            dr[3] = txtQuanity.Text.Trim();
            dr[4] = txtAmount.Text.Trim();
            addToCartTable.Rows.Add(dr);
            gridPurchaseOrder.DataSource = addToCartTable;
            double totalAmount=Convert.ToDouble(txtTotalAmount.Text);
         totalAmount += Convert.ToDouble(txtAmount.Text.Trim());
         txtTotalAmount.Text = totalAmount.ToString();

         txtItemCode.Text = "I";
         txtProductName.Text = "";
         txtRate.Text = "";
         txtQuanity.Text = "";
         txtAmount.Text = "0.0";
         txtItemCode.Focus();

        }
        #endregion

        #region /////////// add Column to AddToCraft DataTable///////////////
        private void setAddToCraftTable()
        {
            addToCartTable .Columns.Add(new DataColumn("ItemCode"));
            addToCartTable.Columns.Add(new DataColumn("ProductName"));
            addToCartTable.Columns.Add(new DataColumn("Rate"));
            addToCartTable.Columns.Add(new DataColumn("Quantity"));
            addToCartTable.Columns.Add(new DataColumn("Amount"));
        }
        #endregion

        private void txtRemoveItem_Click(object sender, EventArgs e)
        {
            if (addToCartTable.Rows.Count > 0) 
            {
                string Amount =gridPurchaseOrder.SelectedRows[0].Cells[4].Value.ToString();
                double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
                totalAmount -= Convert.ToDouble(Amount.Trim());
                txtTotalAmount.Text = totalAmount.ToString();
                int index= gridPurchaseOrder.SelectedRows[0].Index;
                 addToCartTable.Rows.RemoveAt(index);
            
                  gridPurchaseOrder.DataSource = addToCartTable;
                  if (addToCartTable.Rows.Count == 0) 
                  {
                      txtTotalAmount.Text = "0.0";
                      txtDiscount.Text = "0.0";
                  }
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            double totalAmount = 0.0;
            foreach (DataRow dr in addToCartTable.Rows) 
            {
                totalAmount += Convert.ToDouble(dr[4].ToString());
            }
            string discountAmount = txtDiscount.Text;
            //double totalAmount = Convert.ToDouble(txtTotalAmount.Text);
            double amount = 0.0;
            if (double.TryParse(discountAmount, out amount))
            {
                 double totalDiscount = Convert.ToDouble(discountAmount);
                 totalAmount = totalAmount - ((totalAmount * totalDiscount) / 100);
                 txtTotalAmount.Text = totalAmount.ToString();
            }
        }

    }
}
