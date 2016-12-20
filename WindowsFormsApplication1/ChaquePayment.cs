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
    public partial class ChaquePayment : Form
    {
        DB_Main dbMain = new DB_Main();
       TextBox txtPaymentValue;
        public string Srno = "";
        public ChaquePayment()
        {
            InitializeComponent();
        }
        public ChaquePayment(TextBox txt)
        {
            txtPaymentValue = txt;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            varible v = new varible();
            varible.bankDate = dateTimePicker1.Text;
            varible.bankname = txtBankName.Text;
            varible.chaqueNo = txtChaqueno.Text;
            varible.chaqueAmount = txtChaqueamount.Text;
            this.Close();
            txtPaymentValue.Text = txtChaqueamount.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Chaqueform_Load(object sender, EventArgs e)
        {
           
        }
    }
}
