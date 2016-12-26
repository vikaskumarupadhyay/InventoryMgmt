using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication1.Entity;
using System.Data;
using System.Data.Common;

namespace WindowsFormsApplication1.Purchase
{
    class PurchaseDetails
    {

        //public SalesMaster_Vendor  getVendorDetais(string vendorId)  
        //{

        //    //Dictionary<string, string> vendorDetails = new Dictionary<string, string>();
            
        //    try
        //    {
            
            
        //    }
        //    catch (Exception ex) 
        //    {
            
        //    }
        
        //}

        public DataTable GetcustomerdetailsInDataTable()
        {

            DataTable dt = new DataTable();
            try
            {
                DB_Main con = new DB_Main();
                dt = con.getDetails("CustomerDetails");
            }
            catch (Exception ex)
            {
                dt.Clear();
            }
            return dt;
        }


        public DataTable GetVendorDetaisInDataTable()
        {

            DataTable dt = new DataTable();
            try
            {
                DB_Main con = new DB_Main(); 
                dt=con.getDetails("VendorDetails");
            }
            catch (Exception ex)
            {
                dt.Clear();
            }
            return dt;
        }
        public DataTable GetItemPriceAndNameDetaisInDataTable() 
        {

            DataTable dt = new DataTable();
            try
            {
                ItemDetails item = new ItemDetails();
                dt = item.getItemNameAndPricingDetails();
            }
            catch (Exception ex)
            {
                dt.Clear();
            }
            return dt;
        }
    
    }


}



