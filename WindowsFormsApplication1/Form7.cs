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
    public partial class Form7 : Form
    {
        DB_Main dbMainClass = new DB_Main();
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            string SELECTqurry = "select venderId,vName,vAddress,vPhone,vMobile,vFax from VendorDetails";
            DataTable dt = dbMainClass.getDetailByQuery(SELECTqurry);
            
            DataRow dr=dt.Rows[0];
            SelectTxt(dr);
                
             //string Value= dr[0].ToString();
            // MessageBox.Show(Value); 

        }

        private void SelectTxt(DataRow dr) 
        {
            textBox1.Text = dr[0].ToString();
            textBox2.Text = dr[1].ToString();
            textBox3.Text = dr[2].ToString();
            textBox4.Text = dr[3].ToString();
            textBox5.Text = dr[4].ToString();
        
        }
             
    }
}
