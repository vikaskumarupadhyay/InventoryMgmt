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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        frmVendorDetails F2;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (F2 == null)
            {
                 F2 = new frmVendorDetails(0);
                 F2.MdiParent = this;
                F2.FormClosed += new FormClosedEventHandler(F2_FormClosed);
                F2.Show();
            }
            else
            {
                F2.Activate();
            }

        }

        void F2_FormClosed(object sender, FormClosedEventArgs e)
        {
            F2 = null;
            //throw new NotImplementedException();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Customer F3;
        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (F3 == null)
            {
                F3 = new Customer(0);
                F3.MdiParent = this;
                F3.FormClosed += new FormClosedEventHandler(F3_FormClosed);
                F3.Show();
            }
            else
            {
                F3.Activate();
            }
        }

        void F3_FormClosed(object sender, FormClosedEventArgs e)
        {
            F3 = null;
            //throw new NotImplementedException();
        }
        Item F4;
        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (F4 == null)
            {
                F4 = new Item(0);
                F4.MdiParent = this;
                F4.FormClosed += new FormClosedEventHandler(F4_FormClosed);
                F4.Show();
            }
            else
            {
                F4.Activate();
            }
        }

        void F4_FormClosed(object sender, FormClosedEventArgs e)
        {
            F4 = null;
            //throw new NotImplementedException();
        }

        private void schemeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        PurchaseOrder F6;
        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (F6 == null)
            {

                F6 = new PurchaseOrder();
                F6.MdiParent = this;
                F6.FormClosed += new FormClosedEventHandler(F6_FormClosed);
                F6.Show();
            }
            else
            {
                F6.Activate();
            }
        }

        void F6_FormClosed(object sender, FormClosedEventArgs e)
        {
            F6 = null;
            //throw new NotImplementedException();
        }
        Form7 F7;
        private void deliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (F7 == null)
            {

                F7 = new Form7();
                F7.Show();
                F7.MdiParent = this;
                F7.FormClosed += new FormClosedEventHandler(F7_FormClosed);
            }
            else
            {
                F7.Activate();
            }
        }

        void F7_FormClosed(object sender, FormClosedEventArgs e)
        {
            F7 = null;
            //throw new NotImplementedException();
        }
        Form8 F8;
        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (F8 == null)
            {
                F8 = new Form8();
                F8.Show();
                F8.MdiParent = this;
                F8.FormClosed += new FormClosedEventHandler(F8_FormClosed);
            }
            else
            {
                F8.Activate();
            }
        }

        void F8_FormClosed(object sender, FormClosedEventArgs e)
        {
            F8 = null;
            //throw new NotImplementedException();
        }
        Form9 F9;
        private void vendorPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (F9 == null)
            {
                F9 = new Form9();
                F9.Show();
                F9.MdiParent = this;
                F9.FormClosed += new FormClosedEventHandler(F9_FormClosed);
            }
            else
            {
                F9.Activate();
            }
        }

        void F9_FormClosed(object sender, FormClosedEventArgs e)
        {
            F9 = null;
            //throw new NotImplementedException();
        }
        Form5 F5;
        private void taxCreationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (F5 == null)
            {
                F5 = new Form5();
                F5.Show();
                F5.MdiParent = this;
                F5.FormClosed += new FormClosedEventHandler(F5_FormClosed);
            }
            else
            {
                F5.Activate();
            }
        }

        void F5_FormClosed(object sender, FormClosedEventArgs e)
        {
            F5 = null;
            //throw new NotImplementedException();
        }
        salesinvoice F12;
        private void deliveryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (F12 == null)
            {
                F12 = new salesinvoice();
                F12.Show();
                F12.MdiParent = this;
                F12.FormClosed += new FormClosedEventHandler(F12_FormClosed);
            }
            else
            {
                F12.Activate();
            }
        }

        void F12_FormClosed(object sender, FormClosedEventArgs e)
        {
            F12 = null;
            //throw new NotImplementedException();
        }
        salesorder F10;
        private void quoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (F10 == null)
            {
                F10 = new salesorder();
                F10.Show();
                F10.MdiParent = this;
                F10.FormClosed += new FormClosedEventHandler(F10_FormClosed);
            }
            else
            {
                F10.Activate();
            }
        }

        void F10_FormClosed(object sender, FormClosedEventArgs e)
        {
            F10 = null;
            //throw new NotImplementedException();
        }
        salesdelivary F11;
        private void orderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (F11 == null)
            {
                F11 = new salesdelivary();
                F11.Show();
                F11.MdiParent = this;
                F11.FormClosed += new FormClosedEventHandler(F11_FormClosed);
            }
            else
            {
                F11.Activate();
            }
        }

        void F11_FormClosed(object sender, FormClosedEventArgs e)
        {
            F11 = null;
            //throw new NotImplementedException();
        }
        Form5 F51;
        private void invoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (F51 == null)
            {
                F51 = new Form5();
                F51.Show();
                F51.MdiParent = this;
                F51.FormClosed += new FormClosedEventHandler(F51_FormClosed);
            }
            else
            {
                F51.Activate();
            }
        }

        void F51_FormClosed(object sender, FormClosedEventArgs e)
        {
            F51 = null;
            //throw new NotImplementedException();
        }
       

        private void salesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           // salessearch f = new salessearch();
           // f.Show();
            //f.MdiParent = this;
        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Customer F3 = new Customer(1);
            F3.Show();
            F3.MdiParent = this;
            //Customer_list f = new Customer_list();
            //f.Show();
            //f.MdiParent = this;
        }

    

        private void purchaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PurchasSearch1 f13 = new PurchasSearch1();
            f13.Show();
            f13.MdiParent = this;
        }

        private void vendorListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVendorDetails F2 = new frmVendorDetails(1);
            F2.Show();
            F2.MdiParent = this;
            //VendorList1 f14 = new VendorList1();
            //f14.Show();
            //f14.MdiParent = this;
        }

        private void itemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Item F4 = new Item(1);
            F4.Show();
            F4.MdiParent = this;
            //ItemList1 f15 = new ItemList1();
            //f15.Show();
            //f15.MdiParent = this;
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // this.Hide();
            //Company_New f = new Company_New();
            //if (f.ShowDialog() != DialogResult.OK)
            //{
            //this.Close();
                 Company_New f1 = new Company_New();
                 f1.Show();
                 f1.MdiParent = this;
               
                 //f1.ShowDialog();
             
            //}
           
         
            
        }

        private void salesToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
           salessearch s = new salessearch();
            s.Show();
        }


        public FormClosedEventHandler f2_FormClosed { get; set; }
    }
}
