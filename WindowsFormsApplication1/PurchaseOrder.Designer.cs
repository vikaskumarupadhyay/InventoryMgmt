namespace WindowsFormsApplication1
{
    partial class PurchaseOrder
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVendorCode = new System.Windows.Forms.TextBox();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.txtVendorCompanyName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVendorAddress = new System.Windows.Forms.TextBox();
            this.txtVendorPhone = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtVendorFax = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtVendorMobile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtSrNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtRemoveItem = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtQuanity = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.gridPurchaseOrder = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPurchaseOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vendor Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vendor Name";
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
            // txtVendorCode
            // 
            this.txtVendorCode.Location = new System.Drawing.Point(23, 34);
            this.txtVendorCode.Name = "txtVendorCode";
            this.txtVendorCode.Size = new System.Drawing.Size(92, 21);
            this.txtVendorCode.TabIndex = 3;
            this.txtVendorCode.Text = "V";
            this.txtVendorCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVendorCode.TextChanged += new System.EventHandler(this.txtVendorCode_TextChanged);
            this.txtVendorCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVendorCode_KeyPress);
            this.txtVendorCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtVendorCode_KeyUp);
            this.txtVendorCode.Leave += new System.EventHandler(this.txtVendorCode_Leave);
            // 
            // txtVendorName
            // 
            this.txtVendorName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtVendorName.Location = new System.Drawing.Point(143, 34);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.ReadOnly = true;
            this.txtVendorName.Size = new System.Drawing.Size(206, 21);
            this.txtVendorName.TabIndex = 4;
            this.txtVendorName.TabStop = false;
            // 
            // txtVendorCompanyName
            // 
            this.txtVendorCompanyName.Location = new System.Drawing.Point(355, 34);
            this.txtVendorCompanyName.Name = "txtVendorCompanyName";
            this.txtVendorCompanyName.ReadOnly = true;
            this.txtVendorCompanyName.Size = new System.Drawing.Size(240, 21);
            this.txtVendorCompanyName.TabIndex = 5;
            this.txtVendorCompanyName.TabStop = false;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Phone";
            // 
            // txtVendorAddress
            // 
            this.txtVendorAddress.Location = new System.Drawing.Point(23, 76);
            this.txtVendorAddress.Multiline = true;
            this.txtVendorAddress.Name = "txtVendorAddress";
            this.txtVendorAddress.ReadOnly = true;
            this.txtVendorAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtVendorAddress.Size = new System.Drawing.Size(572, 33);
            this.txtVendorAddress.TabIndex = 8;
            this.txtVendorAddress.TabStop = false;
            // 
            // txtVendorPhone
            // 
            this.txtVendorPhone.Location = new System.Drawing.Point(23, 130);
            this.txtVendorPhone.Name = "txtVendorPhone";
            this.txtVendorPhone.ReadOnly = true;
            this.txtVendorPhone.Size = new System.Drawing.Size(187, 21);
            this.txtVendorPhone.TabIndex = 9;
            this.txtVendorPhone.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 23);
            this.button1.TabIndex = 10;
            this.button1.TabStop = false;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.txtVendorFax);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtVendorMobile);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtVendorPhone);
            this.groupBox1.Controls.Add(this.txtVendorAddress);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtVendorCompanyName);
            this.groupBox1.Controls.Add(this.txtVendorName);
            this.groupBox1.Controls.Add(this.txtVendorCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 161);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtVendorFax
            // 
            this.txtVendorFax.Location = new System.Drawing.Point(422, 130);
            this.txtVendorFax.Name = "txtVendorFax";
            this.txtVendorFax.ReadOnly = true;
            this.txtVendorFax.Size = new System.Drawing.Size(173, 21);
            this.txtVendorFax.TabIndex = 14;
            this.txtVendorFax.TabStop = false;
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
            // txtVendorMobile
            // 
            this.txtVendorMobile.Location = new System.Drawing.Point(216, 130);
            this.txtVendorMobile.Name = "txtVendorMobile";
            this.txtVendorMobile.ReadOnly = true;
            this.txtVendorMobile.Size = new System.Drawing.Size(200, 21);
            this.txtVendorMobile.TabIndex = 12;
            this.txtVendorMobile.TabStop = false;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpDate);
            this.groupBox2.Controls.Add(this.txtSrNo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(641, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 86);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(67, 49);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(117, 21);
            this.dtpDate.TabIndex = 7;
            this.dtpDate.TabStop = false;
            this.dtpDate.Value = new System.DateTime(2002, 2, 12, 23, 35, 59, 0);
            // 
            // txtSrNo
            // 
            this.txtSrNo.Location = new System.Drawing.Point(67, 22);
            this.txtSrNo.Name = "txtSrNo";
            this.txtSrNo.Size = new System.Drawing.Size(117, 21);
            this.txtSrNo.TabIndex = 6;
            this.txtSrNo.TabStop = false;
            this.txtSrNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 15);
            this.label9.TabIndex = 5;
            this.label9.Text = "Date :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(12, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "Sr. No. :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtRemoveItem);
            this.groupBox3.Controls.Add(this.btnAddItem);
            this.groupBox3.Controls.Add(this.txtAmount);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtQuanity);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtRate);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtProductName);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.txtItemCode);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(15, 165);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(828, 67);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // txtRemoveItem
            // 
            this.txtRemoveItem.Location = new System.Drawing.Point(714, 22);
            this.txtRemoveItem.Name = "txtRemoveItem";
            this.txtRemoveItem.Size = new System.Drawing.Size(90, 33);
            this.txtRemoveItem.TabIndex = 18;
            this.txtRemoveItem.Text = "Remove Item";
            this.txtRemoveItem.UseVisualStyleBackColor = true;
            this.txtRemoveItem.Click += new System.EventHandler(this.txtRemoveItem_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddItem.FlatAppearance.BorderSize = 3;
            this.btnAddItem.Location = new System.Drawing.Point(618, 22);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(90, 33);
            this.btnAddItem.TabIndex = 17;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(532, 35);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(63, 21);
            this.txtAmount.TabIndex = 10;
            this.txtAmount.TabStop = false;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // txtQuanity
            // 
            this.txtQuanity.Location = new System.Drawing.Point(467, 35);
            this.txtQuanity.Name = "txtQuanity";
            this.txtQuanity.Size = new System.Drawing.Size(59, 21);
            this.txtQuanity.TabIndex = 8;
            this.txtQuanity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQuanity.TextChanged += new System.EventHandler(this.txtQuanity_TextChanged);
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
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(400, 35);
            this.txtRate.Name = "txtRate";
            this.txtRate.ReadOnly = true;
            this.txtRate.Size = new System.Drawing.Size(61, 21);
            this.txtRate.TabIndex = 6;
            this.txtRate.TabStop = false;
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(143, 35);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(251, 21);
            this.txtProductName.TabIndex = 4;
            this.txtProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductName_KeyDown);
            this.txtProductName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductName_KeyPress);
            this.txtProductName.Leave += new System.EventHandler(this.txtProductName_Leave);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(116, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(21, 23);
            this.button2.TabIndex = 3;
            this.button2.TabStop = false;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Location = new System.Drawing.Point(23, 35);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(92, 21);
            this.txtItemCode.TabIndex = 2;
            this.txtItemCode.Text = "I";
            this.txtItemCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItemCode.TextChanged += new System.EventHandler(this.txtItemCode_TextChanged);
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtTotalAmount);
            this.panel1.Controls.Add(this.textBox15);
            this.panel1.Controls.Add(this.textBox14);
            this.panel1.Controls.Add(this.textBox21);
            this.panel1.Controls.Add(this.txtTax);
            this.panel1.Controls.Add(this.textBox19);
            this.panel1.Controls.Add(this.textBox18);
            this.panel1.Controls.Add(this.txtDiscount);
            this.panel1.Controls.Add(this.textBox16);
            this.panel1.Controls.Add(this.gridPurchaseOrder);
            this.panel1.Location = new System.Drawing.Point(15, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 261);
            this.panel1.TabIndex = 34;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(738, 233);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(83, 21);
            this.txtTotalAmount.TabIndex = 60;
            this.txtTotalAmount.TabStop = false;
            this.txtTotalAmount.Text = "0.0";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox15
            // 
            this.textBox15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox15.Location = new System.Drawing.Point(709, 233);
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(29, 21);
            this.textBox15.TabIndex = 59;
            this.textBox15.TabStop = false;
            this.textBox15.Text = "Rs";
            this.textBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox14
            // 
            this.textBox14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox14.Location = new System.Drawing.Point(619, 233);
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(90, 21);
            this.textBox14.TabIndex = 58;
            this.textBox14.TabStop = false;
            this.textBox14.Text = "Total Amount";
            this.textBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.textBox21.TabStop = false;
            this.textBox21.Text = "%";
            this.textBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTax
            // 
            this.txtTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTax.Location = new System.Drawing.Point(541, 233);
            this.txtTax.Name = "txtTax";
            this.txtTax.ReadOnly = true;
            this.txtTax.Size = new System.Drawing.Size(46, 21);
            this.txtTax.TabIndex = 56;
            this.txtTax.TabStop = false;
            this.txtTax.Text = "0";
            this.txtTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox19
            // 
            this.textBox19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox19.Location = new System.Drawing.Point(494, 233);
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
            this.textBox18.Location = new System.Drawing.Point(462, 233);
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(26, 21);
            this.textBox18.TabIndex = 54;
            this.textBox18.TabStop = false;
            this.textBox18.Text = "%";
            this.textBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDiscount
            // 
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(417, 233);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(45, 21);
            this.txtDiscount.TabIndex = 53;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // textBox16
            // 
            this.textBox16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox16.Location = new System.Drawing.Point(351, 233);
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(66, 21);
            this.textBox16.TabIndex = 52;
            this.textBox16.TabStop = false;
            this.textBox16.Text = "Discount";
            this.textBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gridPurchaseOrder
            // 
            this.gridPurchaseOrder.AllowUserToAddRows = false;
            this.gridPurchaseOrder.AllowUserToDeleteRows = false;
            this.gridPurchaseOrder.AllowUserToOrderColumns = true;
            this.gridPurchaseOrder.AllowUserToResizeColumns = false;
            this.gridPurchaseOrder.AllowUserToResizeRows = false;
            this.gridPurchaseOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPurchaseOrder.Location = new System.Drawing.Point(3, 3);
            this.gridPurchaseOrder.Name = "gridPurchaseOrder";
            this.gridPurchaseOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPurchaseOrder.Size = new System.Drawing.Size(818, 227);
            this.gridPurchaseOrder.TabIndex = 0;
            this.gridPurchaseOrder.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(20, 521);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 28);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(116, 521);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 29);
            this.btnClose.TabIndex = 36;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // PurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(858, 564);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Order";
            this.Load += new System.EventHandler(this.PurchaseOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPurchaseOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVendorCode;
        private System.Windows.Forms.TextBox txtVendorName;
        private System.Windows.Forms.TextBox txtVendorCompanyName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVendorAddress;
        private System.Windows.Forms.TextBox txtVendorPhone;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtVendorFax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtVendorMobile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtQuanity;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button txtRemoveItem;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtSrNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridPurchaseOrder;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;

    }
}