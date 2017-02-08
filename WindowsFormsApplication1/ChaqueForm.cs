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
    public partial class ChaqueForm : Form
    {
        TextBox s;
        public string srno = "";
        DB_Main d = new DB_Main();
        public ChaqueForm()
        {
            InitializeComponent();
        }
         public ChaqueForm(TextBox txt)
        {
            s = txt;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Value v = new Value();
            Value.Bankdate = dateTimePicker1.Text;
            Value.Bankname = txtBankName.Text;
            Value.chaqueno = txtChaqueno.Text;
            Value.chaqueammount = txtchaqueammount.Text;
            this.Close();
            s.Text = Value.chaqueammount;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
