using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace WindowsFormsApplication1
{
    public partial class VendorPrint : Form
    {
        Bitmap bmpImage;
        int number = 0;
        printclass pc = new printclass();
        List<printclass> ls1 = new List<printclass>();
        DB_Main dbMainClass = new DB_Main();
        public VendorPrint()
        {
            InitializeComponent();
        }
        public VendorPrint(List<printclass> ls,int num)
        {
            ls1 = ls;
            number = num;
            InitializeComponent();
            
        }

        private void VendorPrint_Load(object sender, EventArgs e)
        {
            if (number == 1)
            {
                butPrint.Visible = false;
                string name = "";
                string Address = "";
                string phone = "";
                string email = "";
                string open = "";
                string cournt = "";
                int num1 = 4;
                int num3 = 0;
                for (int num = 0; num < ls1.Count; num++)
                {
                    pc = ls1[num];
                    name = pc.Name;
                    Address = pc.Address;
                    phone = pc.Phone;
                    email = pc.Email;
                    open = pc.OpningBalnce;
                    cournt = pc.CurrentBalnce;
                    num3 = 20 * num * num1;
                    Label2(num3, name, Address, phone, email, open, cournt);

                }
            }
            butten();
            if (number == 2)
            {
                butPrint.Visible = false;
                string name = "";
                string Address = "";
                string phone = "";
                string email = "";
                string open = "";
                string cournt = "";
                string mrp = "";
                int num1 = 4;
                int num3 = 0;
                for (int num = 0; num < ls1.Count; num++)
                {
                    pc = ls1[num];
                    name = pc.Name;
                    Address = pc.Address;
                    phone = pc.Phone;
                    email = pc.Email;
                    open = pc.OpningBalnce;
                    cournt = pc.CurrentBalnce;
                    mrp = pc.mrp;
                    num3 = 20 * num * num1;
                    grup(num3, name, Address, phone, email, open, cournt,mrp);

                }
            }
           
        }

        public void Label2(int e,string name, string Address, string Phone, string email, string open, string corrent)
        {
            System.Windows.Forms.GroupBox txt = new System.Windows.Forms.GroupBox();
            this.Controls.Add(txt);
             System.Windows.Forms.TextBox txt1 = new System.Windows.Forms.TextBox();
             txt1.Text = name;
             txt1.Top = 10;
             txt1.Left = 5;
             txt1.Width = 650;
             txt1.Height = 15;
             txt1.BackColor = Color.Green;
             System.Windows.Forms.Label txt2 = new System.Windows.Forms.Label();
             txt2.Top = 30;
             txt2.Left = 10;
             txt2.Text = "Address";
             System.Windows.Forms.Label txt3 = new System.Windows.Forms.Label();
             txt3.Top = 30;
             txt3.Left = 120;
             txt3.Text = "Contacts";
             System.Windows.Forms.Label txt4 = new System.Windows.Forms.Label();
             txt4.Top = 30;
             txt4.Left = 300;
             txt4.Text = "Email";
             System.Windows.Forms.Label txt5 = new System.Windows.Forms.Label();
             txt5.Top = 30;
             txt5.Left = 450;
             txt5.Text = "OpeningBalance";
             System.Windows.Forms.Label txt6 = new System.Windows.Forms.Label();
             txt6.Top = 30;
             txt6.Left = 600;
             txt6.Text = "CourrentBalance";
             txt.Controls.Add(txt1);
             txt.Controls.Add(txt2);
             txt.Controls.Add(txt3);
             txt.Controls.Add(txt4);
             txt.Controls.Add(txt5);
             txt.Controls.Add(txt6);
            txt.Top = e;
            txt.Left = 20;
            txt.Height = 80;
            txt.Width = 700;
            txt.Text = "";
            System.Windows.Forms.Label txt7 = new System.Windows.Forms.Label();
            txt7.Top = 60;
            txt7.Left = 10;
            txt7.Text = Address;
            System.Windows.Forms.Label txt8 = new System.Windows.Forms.Label();
            txt8.Top = 60;
            txt8.Left = 120;
            txt8.Text = Phone;
            System.Windows.Forms.Label txt9 = new System.Windows.Forms.Label();
            txt9.Top = 60;
            txt9.Left = 300;
            txt9.Text = email;
            System.Windows.Forms.Label txt10 = new System.Windows.Forms.Label();
            txt10.Top = 60;
            txt10.Left = 450;
            txt10.Text = open;
            System.Windows.Forms.Label txt11 = new System.Windows.Forms.Label();
            txt11.Top = 60;
            txt11.Left = 600;
            txt11.ForeColor = Color.Red;
            txt11.Text = corrent;
            txt.Controls.Add(txt7);
            txt.Controls.Add(txt8);
            txt.Controls.Add(txt9);
            txt.Controls.Add(txt10);
            txt.Controls.Add(txt11);
        }
        public void grup(int e, string name, string Address, string Phone, string email, string open, string corrent,string mrp)
        {
            System.Windows.Forms.GroupBox txt = new System.Windows.Forms.GroupBox();
            this.Controls.Add(txt);
            System.Windows.Forms.TextBox txt1 = new System.Windows.Forms.TextBox();
            txt1.Text = name;
            txt1.Top = 10;
            txt1.Left = 5;
            txt1.Width = 750;
            txt1.Height = 15;
            txt1.BackColor = Color.Green;
            System.Windows.Forms.Label txt2 = new System.Windows.Forms.Label();
            txt2.Top = 30;
            txt2.Left = 10;
            txt2.Text = "ItemName";
            System.Windows.Forms.Label txt3 = new System.Windows.Forms.Label();
            txt3.Top = 30;
            txt3.Left = 120;
            txt3.Text = "CompanyName";
            System.Windows.Forms.Label txt4 = new System.Windows.Forms.Label();
            txt4.Top = 30;
            txt4.Left = 300;
            txt4.Text = "PurchasPrise";
            System.Windows.Forms.Label txt5 = new System.Windows.Forms.Label();
            txt5.Top = 30;
            txt5.Left = 450;
            txt5.Text = "SalePrise";
            System.Windows.Forms.Label txt6 = new System.Windows.Forms.Label();
            txt6.Top = 30;
            txt6.Left = 600;
            txt6.Text = "OpeningQuntty";
            System.Windows.Forms.Label txt12 = new System.Windows.Forms.Label();
            txt12.Top = 30;
            txt12.Left = 700;
            txt12.Text = "CourrentQuntty";
            txt.Controls.Add(txt12);
            txt.Controls.Add(txt1);
            txt.Controls.Add(txt2);
            txt.Controls.Add(txt3);
            txt.Controls.Add(txt4);
            txt.Controls.Add(txt5);
            txt.Controls.Add(txt6);
            txt.Top = e;
            txt.Left = 20;
            txt.Height = 80;
            txt.Width = 700;
            txt.Text = "";
            System.Windows.Forms.Label txt7 = new System.Windows.Forms.Label();
            txt7.Top = 60;
            txt7.Left = 10;
            txt7.Text = Address;
            System.Windows.Forms.Label txt8 = new System.Windows.Forms.Label();
            txt8.Top = 60;
            txt8.Left = 120;
            txt8.Text = Phone;
            System.Windows.Forms.Label txt9 = new System.Windows.Forms.Label();
            txt9.Top = 60;
            txt9.Left = 300;
            txt9.Text = email;
            System.Windows.Forms.Label txt10 = new System.Windows.Forms.Label();
            txt10.Top = 60;
            txt10.Left = 450;
            txt10.Text = open;
            System.Windows.Forms.Label txt11 = new System.Windows.Forms.Label();
            txt11.Top = 60;
            txt11.Left = 600;
            txt11.ForeColor = Color.Red;
            txt11.Text = corrent;
            System.Windows.Forms.Label txt13 = new System.Windows.Forms.Label();
            txt13.Top = 60;
            txt13.Left = 600;
            txt13.ForeColor = Color.Red;
            txt13.Text = mrp;
            txt.Controls.Add(txt7);
            txt.Controls.Add(txt8);
            txt.Controls.Add(txt9);
            txt.Controls.Add(txt10);
            txt.Controls.Add(txt11);
            txt.Controls.Add(txt13);
        }
        public void butten()
        {
            System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
            this.Controls.Add(btn);
            btn.Width = 10;
            btn.Height = 10;
            btn.BackColor = Color.Pink;
        }
        private void butPrint_Click(object sender, EventArgs e)
        {

            Graphics graphics = this.CreateGraphics();
            bmpImage = new Bitmap(this.Size.Width, this.Size.Height, graphics);
            Graphics mainGraphics = Graphics.FromImage(bmpImage);
            mainGraphics.CopyFromScreen(this.Location.X,this.Location.Y,0,0,this.Size);
            printDialog1.Document = printDocument1;
            printDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmpImage,0,0);
            printDocument1.Print();
        }
       
    }
}
