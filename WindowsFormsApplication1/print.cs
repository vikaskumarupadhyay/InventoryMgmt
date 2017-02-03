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
    public partial class print : Form
    {
        int s = 1;
        DB_Main dbMainClass = new DB_Main();
        Class2 s1 = new Class2();
        List<Class2> class2Collection = new List<Class2>();
        public print(List<Class2> class2Obejct)
        {
            class2Collection = class2Obejct;
            InitializeComponent();
        }
        //public void addnew(int c,string name)
        //{
        //    System.Windows.Forms.TextBox obj=new System.Windows.Forms.TextBox();
        //    this.Controls.Add(obj);
        //    obj.Top=c;
        //    obj.Left=80;
        //    obj.Height = 60;
        //    obj.Width = 75;
        //    obj.BackColor = Color.Green;
        //    obj.Text=name;
           
        //    //string selectQuery = "select  CustName AS Name ,CustAddress AS Address,CustEmail AS [E-Mail Address] ,CustMobile AS Mobile ,Custad.CustOpeningBalance AS [Opening Balance] , Custad.CustCurrentBalance AS [Current Ballance] from  CustomerDetails Custd join CustomerAccountDetails  Custad on Custd.CustID=Custad.CustID ";

        //    //DataTable dt = dbMainClass.getDetailByQuery(selectQuery);
        //    //DataColumnCollection d = dt.Columns;
        //    //List<string> ls = new List<string>();
        //    //foreach (DataRow dr in dt.Rows)
        //    //{
        //    //    obj.Text = dr["name"].ToString();
        //    //    //textBox2.Text = dr["address"].ToString();
        //    //}
           

        //}
        //public void  label1(int a)
        //{

        //    System.Windows.Forms.Label obj1 = new System.Windows.Forms.Label();
        //    this.Controls.Add(obj1);
        //    obj1.Top = a;
        //    obj1.Left = 100;
        //   // obj.Width = 750;
        //    obj1.Text = "Address";
          
         
        //   // return obj1;
        //}
      
        public void group(string name,string address,string contactno,string email,string openingbalance,string currentbalance,int top )
        {

            //System.Windows.Forms.GroupBox obj5 = new System.Windows.Forms.GroupBox();
            GroupBox s = new GroupBox();
            this.Controls.Add(s);
            s.Top = top;
            s.Width = 750;
            s.Height = 90;
            s.Left = 80;
           // System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
            TextBox t = new TextBox();
            t.Top = 10;
            t.Width = 700;
            t.Height = 40;
            t.Left = 20;
            t.BackColor = Color.Green;
            s.Controls.Add(t);
            t.Text = name;
           // System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
            Label t1 = new Label();
            this.Controls.Add(t1);
            t1.Top = 40;
            t1.Left = 30;
            t1.Text = "Address";
            s.Controls.Add(t1);
            
           // System.Windows.Forms.Label lbl1 = new System.Windows.Forms.Label();
            Label t2 = new Label();
            t2.Top = 40;
            t2.Left = 180; 
            t2.Text = "ContactNo";
            s.Controls.Add(t2);
            //System.Windows.Forms.Label lbl2 = new System.Windows.Forms.Label();
            Label t3 = new Label();
            this.Controls.Add(t3);
            t3.Top = 40;
            t3.Left = 350;
            t3.Text = "Emailaddress";
            s.Controls.Add(t3);
           // System.Windows.Forms.Label lbl3 = new System.Windows.Forms.Label();
            Label t4 = new Label();
            this.Controls.Add(t4);
            t4.Top = 40;
            t4.Left = 500;
            t4.Text = "OpeningBalance";
            s.Controls.Add(t4);
           // System.Windows.Forms.Label lbl4 = new System.Windows.Forms.Label();
            Label t5 = new Label();
            this.Controls.Add(t5);
            t5.Top = 40;
            t5.Left = 650;
            t5.Text = "CurrentBalance";
            s.Controls.Add(t5);

           // System.Windows.Forms.Label lbl5 = new System.Windows.Forms.Label();
            Label t6 = new Label();
            this.Controls.Add(t6);
            t6.Top = 65;
            t6.Left = 30;
            s.Controls.Add(t6);
            t6.Text = address;
        
           // System.Windows.Forms.Label lbl6 = new System.Windows.Forms.Label();
            Label t7 = new Label();
            this.Controls.Add(t7);
            t7.Top = 65;
            t7.Left = 180;
            s.Controls.Add(t7);
            t7.Text = contactno;
           // System.Windows.Forms.Label lbl7 = new System.Windows.Forms.Label();
            Label t8 = new Label();
            this.Controls.Add(t8);
            t8.Top = 65;
            t8.Left = 350;
            s.Controls.Add(t8);
            t8.Text = email;
           // System.Windows.Forms.Label lbl8 = new System.Windows.Forms.Label();
            Label t9 = new Label();
            this.Controls.Add(t9);
            t9.Top = 65;
            t9.Left = 500;
            s.Controls.Add(t9);
            t9.Text = openingbalance;
           // System.Windows.Forms.Label lbl9 = new System.Windows.Forms.Label();
            Label t10 = new Label();
            this.Controls.Add(t10);
            t10.Top = 65;
            t10.Left = 650;
            s.Controls.Add(t10);
            t10.Text = currentbalance;
           // System.Windows.Forms.Label lbl10 = new System.Windows.Forms.Label();
            Label t11 = new Label();
            this.Controls.Add(t11);
            t11.Top = 65;
            t11.Left = 600;
            s.Controls.Add(t11);
           

            // obj.Width = 750;
           // obj5.Text = "Current balance";

       
        }
       
        private void print_Load(object sender, EventArgs e)
        {
            int j = 5;
            int h = 0;
            string name = "";
            string Address = "";
            string Contactno = "";
            string Email = "";
            string openingbalance = "";
            string currentbalance = "";
            for (int a = 0; a < class2Collection.Count; a++)
            {
                
                s1 = class2Collection[a];
                    name = s1.name;
                    Address = s1.address;
                   Contactno = s1.mobileno;
                   Email = s1.Emailaddress;
                 openingbalance = s1.openingbalance;
                 currentbalance = s1.currentbalance;
                h = 20 * a * j;
                group(name,Address,Contactno,Email,openingbalance,currentbalance,h);
                //label1(60);

               // label1(29);
            }
           
           
         
        }
    
    }
}
