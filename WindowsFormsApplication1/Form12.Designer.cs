namespace WindowsFormsApplication1
{
    partial class salesinvoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txttotalammount = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.txtdiscount = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.gridsalesinvoice = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.butRemoveItem = new System.Windows.Forms.Button();
            this.butAdditem = new System.Windows.Forms.Button();
            this.txtammount = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtquantity = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtrate = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtproductname = new System.Windows.Forms.TextBox();
            this.butitembutton = new System.Windows.Forms.Button();
            this.txtitemcode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.txtSrNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtcustfax = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcustmobile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.butcustbutton = new System.Windows.Forms.Button();
            this.txtcustphone = new System.Windows.Forms.TextBox();
            this.txtcustaddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtcustcompname = new System.Windows.Forms.TextBox();
            this.txtcustname = new System.Windows.Forms.TextBox();
            this.txtCustcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.butclose = new System.Windows.Forms.Button();
            this.butselectpurchasedelivary = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridsalesinvoice)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txttotalammount);
            this.panel1.Controls.Add(this.textBox22);
            this.panel1.Controls.Add(this.textBox15);
            this.panel1.Controls.Add(this.textBox21);
            this.panel1.Controls.Add(this.textBox20);
            this.panel1.Controls.Add(this.textBox19);
            this.panel1.Controls.Add(this.textBox18);
            this.panel1.Controls.Add(this.txtdiscount);
            this.panel1.Controls.Add(this.textBox16);
            this.panel1.Controls.Add(this.gridsalesinvoice);
            this.panel1.Location = new System.Drawing.Point(15, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 261);
            this.panel1.TabIndex = 48;
            // 
            // txttotalammount
            // 
            this.txttotalammount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttotalammount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotalammount.Location = new System.Drawing.Point(738, 233);
            this.txttotalammount.Name = "txttotalammount";
            this.txttotalammount.ReadOnly = true;
            this.txttotalammount.Size = new System.Drawing.Size(83, 21);
            this.txttotalammount.TabIndex = 60;
            this.txttotalammount.TabStop = false;
            this.txttotalammount.Text = "0";
            this.txttotalammount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox22
            // 
            this.textBox22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox22.Location = new System.Drawing.Point(709, 233);
            this.textBox22.Name = "textBox22";
            this.textBox22.ReadOnly = true;
            this.textBox22.Size = new System.Drawing.Size(29, 21);
            this.textBox22.TabIndex = 59;
            this.textBox22.TabStop = false;
            this.textBox22.Text = "Rs";
            this.textBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox15
            // 
            this.textBox15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox15.Location = new System.Drawing.Point(619, 233);
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(90, 21);
            this.textBox15.TabIndex = 58;
            this.textBox15.TabStop = false;
            this.textBox15.Text = "Total Amount";
            this.textBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox21
            // 
            this.textBox21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox21.Location = new System.Drawing.Point(587, 233);
            this.textBox21.Name = "textBox21";
            this.textBox21.ReadOnly = true;
            this.textBox21.Size = new System.Drawing.Size(26, 21);
            this.textBox21.TabIndex = 57;
            this.textBox21.Text = "%";
            this.textBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox20
            // 
            this.textBox20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox20.Location = new System.Drawing.Point(542, 233);
            this.textBox20.Name = "textBox20";
            this.textBox20.ReadOnly = true;
            this.textBox20.Size = new System.Drawing.Size(45, 21);
            this.textBox20.TabIndex = 56;
            this.textBox20.TabStop = false;
            this.textBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox19
            // 
            this.textBox19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox19.Location = new System.Drawing.Point(495, 233);
            this.textBox19.Name = "textBox19";
            this.textBox19.ReadOnly = true;
            this.textBox19.Size = new System.Drawing.Size(47, 21);
            this.textBox19.TabIndex = 55;
            this.textBox19.TabStop = false;
            this.textBox19.Text = "Tax";
            this.textBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox18
            // 
            this.textBox18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox18.Location = new System.Drawing.Point(463, 233);
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(26, 21);
            this.textBox18.TabIndex = 54;
            this.textBox18.TabStop = false;
            this.textBox18.Text = "%";
            this.textBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtdiscount
            // 
            this.txtdiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdiscount.Location = new System.Drawing.Point(418, 233);
            this.txtdiscount.Name = "txtdiscount";
            this.txtdiscount.Size = new System.Drawing.Size(45, 21);
            this.txtdiscount.TabIndex = 53;
            this.txtdiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox16
            // 
            this.textBox16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox16.Location = new System.Drawing.Point(352, 233);
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(66, 21);
            this.textBox16.TabIndex = 52;
            this.textBox16.TabStop = false;
            this.textBox16.Text = "Discount";
            this.textBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gridsalesinvoice
            // 
            this.gridsalesinvoice.AllowUserToAddRows = false;
            this.gridsalesinvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridsalesinvoice.Location = new System.Drawing.Point(3, 3);
            this.gridsalesinvoice.Name = "gridsalesinvoice";
            this.gridsalesinvoice.Size = new System.Drawing.Size(818, 227);
            this.gridsalesinvoice.TabIndex = 0;
            this.gridsalesinvoice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.butRemoveItem);
            this.groupBox3.Controls.Add(this.butAdditem);
            this.groupBox3.Controls.Add(this.txtammount);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtquantity);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtrate);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtproductname);
            this.groupBox3.Controls.Add(this.butitembutton);
            this.groupBox3.Controls.Add(this.txtitemcode);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(15, 165);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(828, 67);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            // 
            // butRemoveItem
            // 
            this.butRemoveItem.Location = new System.Drawing.Point(714, 22);
            this.butRemoveItem.Name = "butRemoveItem";
            this.butRemoveItem.Size = new System.Drawing.Size(90, 33);
            this.butRemoveItem.TabIndex = 18;
            this.butRemoveItem.Text = "Remove Item";
            this.butRemoveItem.UseVisualStyleBackColor = true;
            this.butRemoveItem.Click += new System.EventHandler(this.butRemoveItem_Click);
            // 
            // butAdditem
            // 
            this.butAdditem.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.butAdditem.FlatAppearance.BorderSize = 3;
            this.butAdditem.Location = new System.Drawing.Point(618, 22);
            this.butAdditem.Name = "butAdditem";
            this.butAdditem.Size = new System.Drawing.Size(90, 33);
            this.butAdditem.TabIndex = 17;
            this.butAdditem.Text = "Add Item";
            this.butAdditem.UseVisualStyleBackColor = true;
            this.butAdditem.Click += new System.EventHandler(this.butAdditem_Click);
            // 
            // txtammount
            // 
            this.txtammount.Location = new System.Drawing.Point(532, 35);
            this.txtammount.Name = "txtammount";
            this.txtammount.Size = new System.Drawing.Size(63, 21);
            this.txtammount.TabIndex = 10;
            this.txtammount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(529, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 15);
            this.label14.TabIndex = 9;
            this.label14.Text = "Amount";
            // 
            // txtquantity
            // 
            this.txtquantity.Location = new System.Drawing.Point(467, 35);
            this.txtquantity.Name = "txtquantity";
            this.txtquantity.Size = new System.Drawing.Size(59, 21);
            this.txtquantity.TabIndex = 8;
            this.txtquantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtquantity.TextChanged += new System.EventHandler(this.txtquantity_TextChanged);
            this.txtquantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtquantity_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(464, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 15);
            this.label13.TabIndex = 7;
            this.label13.Text = "Qnty";
            // 
            // txtrate
            // 
            this.txtrate.Location = new System.Drawing.Point(400, 35);
            this.txtrate.Name = "txtrate";
            this.txtrate.Size = new System.Drawing.Size(61, 21);
            this.txtrate.TabIndex = 6;
            this.txtrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(397, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 15);
            this.label12.TabIndex = 5;
            this.label12.Text = "Rate";
            // 
            // txtproductname
            // 
            this.txtproductname.Location = new System.Drawing.Point(143, 35);
            this.txtproductname.Name = "txtproductname";
            this.txtproductname.Size = new System.Drawing.Size(251, 21);
            this.txtproductname.TabIndex = 4;
            // 
            // butitembutton
            // 
            this.butitembutton.Location = new System.Drawing.Point(116, 34);
            this.butitembutton.Name = "butitembutton";
            this.butitembutton.Size = new System.Drawing.Size(21, 23);
            this.butitembutton.TabIndex = 3;
            this.butitembutton.TabStop = false;
            this.butitembutton.Text = "...";
            this.butitembutton.UseVisualStyleBackColor = true;
            this.butitembutton.Click += new System.EventHandler(this.butitembutton_Click);
            // 
            // txtitemcode
            // 
            this.txtitemcode.Location = new System.Drawing.Point(23, 35);
            this.txtitemcode.Name = "txtitemcode";
            this.txtitemcode.Size = new System.Drawing.Size(92, 21);
            this.txtitemcode.TabIndex = 2;
            this.txtitemcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(140, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 15);
            this.label11.TabIndex = 1;
            this.label11.Text = "Product Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Item Code";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtRefNo);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.dtpdate);
            this.groupBox2.Controls.Add(this.txtSrNo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(641, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 109);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(69, 77);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(117, 21);
            this.txtRefNo.TabIndex = 9;
            this.txtRefNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(6, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 15);
            this.label15.TabIndex = 8;
            this.label15.Text = "Ref. No. :";
            // 
            // dtpdate
            // 
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdate.Location = new System.Drawing.Point(69, 50);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(117, 21);
            this.dtpdate.TabIndex = 7;
            this.dtpdate.TabStop = false;
            this.dtpdate.Value = new System.DateTime(2002, 2, 12, 23, 35, 59, 0);
            // 
            // txtSrNo
            // 
            this.txtSrNo.Location = new System.Drawing.Point(69, 23);
            this.txtSrNo.Name = "txtSrNo";
            this.txtSrNo.Size = new System.Drawing.Size(117, 21);
            this.txtSrNo.TabIndex = 6;
            this.txtSrNo.TabStop = false;
            this.txtSrNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 15);
            this.label9.TabIndex = 5;
            this.label9.Text = "Date :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(13, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "Sr. No. :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.txtcustfax);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtcustmobile);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.butcustbutton);
            this.groupBox1.Controls.Add(this.txtcustphone);
            this.groupBox1.Controls.Add(this.txtcustaddress);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtcustcompname);
            this.groupBox1.Controls.Add(this.txtcustname);
            this.groupBox1.Controls.Add(this.txtCustcode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 161);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            // 
            // txtcustfax
            // 
            this.txtcustfax.Location = new System.Drawing.Point(422, 130);
            this.txtcustfax.Name = "txtcustfax";
            this.txtcustfax.Size = new System.Drawing.Size(173, 21);
            this.txtcustfax.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(419, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Fax";
            // 
            // txtcustmobile
            // 
            this.txtcustmobile.Location = new System.Drawing.Point(216, 130);
            this.txtcustmobile.Name = "txtcustmobile";
            this.txtcustmobile.Size = new System.Drawing.Size(200, 21);
            this.txtcustmobile.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mobile";
            // 
            // butcustbutton
            // 
            this.butcustbutton.Location = new System.Drawing.Point(116, 33);
            this.butcustbutton.Name = "butcustbutton";
            this.butcustbutton.Size = new System.Drawing.Size(21, 23);
            this.butcustbutton.TabIndex = 10;
            this.butcustbutton.TabStop = false;
            this.butcustbutton.Text = "...";
            this.butcustbutton.UseVisualStyleBackColor = true;
            this.butcustbutton.Click += new System.EventHandler(this.butcustbutton_Click);
            // 
            // txtcustphone
            // 
            this.txtcustphone.Location = new System.Drawing.Point(23, 130);
            this.txtcustphone.Name = "txtcustphone";
            this.txtcustphone.Size = new System.Drawing.Size(187, 21);
            this.txtcustphone.TabIndex = 9;
            // 
            // txtcustaddress
            // 
            this.txtcustaddress.Location = new System.Drawing.Point(23, 76);
            this.txtcustaddress.Multiline = true;
            this.txtcustaddress.Name = "txtcustaddress";
            this.txtcustaddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtcustaddress.Size = new System.Drawing.Size(572, 33);
            this.txtcustaddress.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Phone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Address";
            // 
            // txtcustcompname
            // 
            this.txtcustcompname.Location = new System.Drawing.Point(355, 34);
            this.txtcustcompname.Name = "txtcustcompname";
            this.txtcustcompname.Size = new System.Drawing.Size(240, 21);
            this.txtcustcompname.TabIndex = 5;
            // 
            // txtcustname
            // 
            this.txtcustname.Location = new System.Drawing.Point(143, 34);
            this.txtcustname.Name = "txtcustname";
            this.txtcustname.Size = new System.Drawing.Size(206, 21);
            this.txtcustname.TabIndex = 4;
            // 
            // txtCustcode
            // 
            this.txtCustcode.Location = new System.Drawing.Point(23, 34);
            this.txtCustcode.Name = "txtCustcode";
            this.txtCustcode.Size = new System.Drawing.Size(92, 21);
            this.txtCustcode.TabIndex = 3;
            this.txtCustcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Company Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Customer Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Code";
            // 
            // butclose
            // 
            this.butclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butclose.Location = new System.Drawing.Point(279, 521);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(90, 29);
            this.butclose.TabIndex = 51;
            this.butclose.Text = "Close";
            this.butclose.UseVisualStyleBackColor = true;
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // butselectpurchasedelivary
            // 
            this.butselectpurchasedelivary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butselectpurchasedelivary.Location = new System.Drawing.Point(116, 520);
            this.butselectpurchasedelivary.Name = "butselectpurchasedelivary";
            this.butselectpurchasedelivary.Size = new System.Drawing.Size(157, 29);
            this.butselectpurchasedelivary.TabIndex = 50;
            this.butselectpurchasedelivary.Text = "Select Purchase Delivery";
            this.butselectpurchasedelivary.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(20, 521);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 28);
            this.button5.TabIndex = 49;
            this.button5.Text = "Save";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView2);
            this.panel2.Location = new System.Drawing.Point(15, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(831, 228);
            this.panel2.TabIndex = 52;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(32, 20);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(780, 190);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // salesinvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(858, 564);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.butclose);
            this.Controls.Add(this.butselectpurchasedelivary);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "salesinvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Invoice";
            this.Load += new System.EventHandler(this.salesinvoice_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridsalesinvoice)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridsalesinvoice;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button butRemoveItem;
        private System.Windows.Forms.Button butAdditem;
        private System.Windows.Forms.TextBox txtammount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtquantity;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtrate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtproductname;
        private System.Windows.Forms.Button butitembutton;
        private System.Windows.Forms.TextBox txtitemcode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtRefNo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.TextBox txtSrNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtcustfax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtcustmobile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button butcustbutton;
        private System.Windows.Forms.TextBox txtcustphone;
        private System.Windows.Forms.TextBox txtcustaddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtcustcompname;
        private System.Windows.Forms.TextBox txtcustname;
        private System.Windows.Forms.TextBox txtCustcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttotalammount;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox txtdiscount;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Button butclose;
        private System.Windows.Forms.Button butselectpurchasedelivary;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}