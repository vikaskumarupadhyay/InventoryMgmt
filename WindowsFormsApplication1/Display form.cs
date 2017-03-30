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
    public partial class Display_form : Form
    {
        public Display_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = "Data Source=DINESHTIWARI-PC\\SQLEXPRESS;Initial Catalog=SalesMaster;Integrated Security=True";
            SqlConnection con = new SqlConnection(a);
            con.Open();
            string selectquery = "select co.orderid ,co.ItemId,id.ItemName,co.quantity,ipd.MrpPrice,co.price,co.totalammount from customerorderdescriptions co join ItemDetails id on co.ItemId=id.ItemId join ItemPriceDetail ipd on id.ItemId=ipd.ItemId";
            SqlCommand cmd = new SqlCommand(selectquery, con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
           // DataSet3 ds = new DataSet3();
          //  sd.Fill(ds, "compnaydetails");

            //CrystalReport1 cr = new CrystalReport1();
            // cr.ParameterFields.Add(textBox1.Text);
            // cr.Load("C:\\Users\\dineshtiwari\\Documents\\Visual Studio 2010\\Projects\\report11\\report11\\CrystalReport1.rpt");

            CrystalReport1 report1 = new CrystalReport1();
           // report1.SetDataSource(ds.Tables[1]);

           // crystalReportViewer1.ReportSource = report1;
           // crystalReportViewer1.Refresh();
            con.Close();
        }
    }
}
