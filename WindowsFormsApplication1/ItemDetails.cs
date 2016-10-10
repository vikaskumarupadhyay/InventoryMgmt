using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WindowsFormsApplication1
{
    class ItemDetails
    {
        public DataTable getItemNameAndPricingDetails() 
        {
            DataTable dt = new DataTable();
            try {
                string Query = "select pd.ItemID, pd.SalesPrice,pd.PurChasePrice,pd.MrpPrice,pd.Margin, id.ItemName,id.ItemCompName,id.groupid,id.unitid from itempriceDetail pd  join ItemDetails id on pd.itemId=id.itemID";
                DB_Main db = new DB_Main();
                dt= db.getDetailByQuery(Query);
            }
            catch (Exception ex) 
            {
                dt.Clear();
            }
            return dt;
        
        }
    }
}
