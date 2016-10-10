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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVendorDetails F2 = new frmVendorDetails();
            F2.Show();
            F2.MdiParent = this;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer F3 = new Customer();
            F3.Show();
            F3.MdiParent = this;
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Item F4 = new Item();
            F4.Show();
            F4.MdiParent = this;
        }

        private void schemeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseOrder F6 = new PurchaseOrder();
            F6.Show();
            F6.MdiParent = this;
        }

        private void deliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 F7 = new Form7();
            F7.Show();
            F7.MdiParent = this;
        }

        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 F8 = new Form8();
            F8.Show();
            F8.MdiParent = this;
        }

        private void vendorPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 F9 = new Form9();
            F9.Show();
            F9.MdiParent = this;
        }

        private void taxCreationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 F5 = new Form5();
            F5.Show();
            F5.MdiParent = this;
        }

        private void deliveryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form12 F12 = new Form12();
            F12.Show();
            F12.MdiParent = this;
        }

        private void quoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 F10 = new Form10();
            F10.Show();
            F10.MdiParent = this;
        }

        private void orderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form11 F11 = new Form11();
            F11.Show();
            F11.MdiParent = this;
        }

        private void invoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form5 F5 = new Form5();
            F5.Show();
            F5.MdiParent = this;
        }
    }
}
