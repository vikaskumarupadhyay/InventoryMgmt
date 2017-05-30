namespace WindowsFormsApplication1
{
    partial class salesorder
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
            this.gridsalesorder = new System.Windows.Forms.DataGridView();
            this.txttotalammount = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.txttax = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.butadditem = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtitemcode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.txtsrno = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtcustfax = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcustmobile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtcustphone = new System.Windows.Forms.TextBox();
            this.txtcustaddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtcustcompname = new System.Windows.Forms.TextBox();
            this.txtcustname = new System.Windows.Forms.TextBox();
            this.txtcustomercode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.butclose = new System.Windows.Forms.Button();
            this.savebutton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtsearchvalue = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Label();
            this.comsearchsalesvalue = new System.Windows.Forms.ComboBox();
            this.butback = new System.Windows.Forms.Button();
            this.discountamount = new System.Windows.Forms.TextBox();
            this.txttaxamount = new System.Windows.Forms.TextBox();
            this.txtwithautaxamount = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridsalesorder)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.gridsalesorder);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(15, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1139, 337);
            this.panel1.TabIndex = 48;
            // 
            // gridsalesorder
            // 
            this.gridsalesorder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridsalesorder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridsalesorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridsalesorder.Location = new System.Drawing.Point(0, 0);
            this.gridsalesorder.Name = "gridsalesorder";
            this.gridsalesorder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridsalesorder.Size = new System.Drawing.Size(1135, 333);
            this.gridsalesorder.StandardTab = true;
            this.gridsalesorder.TabIndex = 0;
            this.gridsalesorder.TabStop = false;
            this.gridsalesorder.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridsalesorder_CellDoubleClick);
            this.gridsalesorder.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridsalesorder_CellEndEdit);
            this.gridsalesorder.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridsalesorder_CellLeave);
            this.gridsalesorder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridsalesorder_KeyPress);
            // 
            // txttotalammount
            // 
            this.txttotalammount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txttotalammount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttotalammount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotalammount.Location = new System.Drawing.Point(1069, 577);
            this.txttotalammount.Name = "txttotalammount";
            this.txttotalammount.ReadOnly = true;
            this.txttotalammount.Size = new System.Drawing.Size(83, 21);
            this.txttotalammount.TabIndex = 56;
            this.txttotalammount.TabStop = false;
            this.txttotalammount.Text = "0";
            this.txttotalammount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txttotalammount.TextChanged += new System.EventHandler(this.txttotalammount_TextChanged);
            // 
            // textBox15
            // 
            this.textBox15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox15.Location = new System.Drawing.Point(1041, 577);
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(29, 21);
            this.textBox15.TabIndex = 55;
            this.textBox15.TabStop = false;
            this.textBox15.Text = "Rs";
            this.textBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox14
            // 
            this.textBox14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox14.Location = new System.Drawing.Point(952, 577);
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(90, 21);
            this.textBox14.TabIndex = 54;
            this.textBox14.TabStop = false;
            this.textBox14.Text = "Total Amount";
            this.textBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox21
            // 
            this.textBox21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox21.Location = new System.Drawing.Point(920, 577);
            this.textBox21.Name = "textBox21";
            this.textBox21.ReadOnly = true;
            this.textBox21.Size = new System.Drawing.Size(26, 21);
            this.textBox21.TabIndex = 53;
            this.textBox21.TabStop = false;
            this.textBox21.Text = "%";
            this.textBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox20
            // 
            this.textBox20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox20.Location = new System.Drawing.Point(876, 577);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(45, 21);
            this.textBox20.TabIndex = 52;
            this.textBox20.TabStop = false;
            this.textBox20.Text = "0.00";
            this.textBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox20.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox20_MouseClick);
            this.textBox20.TextChanged += new System.EventHandler(this.textBox20_TextChanged);
            this.textBox20.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox20_KeyPress);
            this.textBox20.Leave += new System.EventHandler(this.textBox20_Leave);
            // 
            // textBox19
            // 
            this.textBox19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox19.Location = new System.Drawing.Point(830, 577);
            this.textBox19.Name = "textBox19";
            this.textBox19.ReadOnly = true;
            this.textBox19.Size = new System.Drawing.Size(47, 21);
            this.textBox19.TabIndex = 51;
            this.textBox19.TabStop = false;
            this.textBox19.Text = "Disc.";
            this.textBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox18
            // 
            this.textBox18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox18.Location = new System.Drawing.Point(798, 577);
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(26, 21);
            this.textBox18.TabIndex = 50;
            this.textBox18.TabStop = false;
            this.textBox18.Text = "%";
            this.textBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txttax
            // 
            this.txttax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txttax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttax.Location = new System.Drawing.Point(754, 577);
            this.txttax.Name = "txttax";
            this.txttax.Size = new System.Drawing.Size(45, 21);
            this.txttax.TabIndex = 49;
            this.txttax.TabStop = false;
            this.txttax.Text = "0";
            this.txttax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txttax.TextChanged += new System.EventHandler(this.txtdiscount_TextChanged);
            // 
            // textBox16
            // 
            this.textBox16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox16.Location = new System.Drawing.Point(708, 577);
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(47, 21);
            this.textBox16.TabIndex = 48;
            this.textBox16.TabStop = false;
            this.textBox16.Text = "VAT";
            this.textBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.butadditem);
            this.groupBox3.Controls.Add(this.txtAmount);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtQuantity);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtRate);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtProductName);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.txtitemcode);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(15, 165);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1139, 67);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(1033, 22);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 33);
            this.button4.TabIndex = 18;
            this.button4.TabStop = false;
            this.button4.Text = "Remove Item";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.button4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.button4_KeyPress);
            // 
            // butadditem
            // 
            this.butadditem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butadditem.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.butadditem.FlatAppearance.BorderSize = 3;
            this.butadditem.Location = new System.Drawing.Point(937, 22);
            this.butadditem.Name = "butadditem";
            this.butadditem.Size = new System.Drawing.Size(90, 33);
            this.butadditem.TabIndex = 17;
            this.butadditem.TabStop = false;
            this.butadditem.Text = "Add Item";
            this.butadditem.UseVisualStyleBackColor = true;
            this.butadditem.Click += new System.EventHandler(this.butadditem_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmount.Location = new System.Drawing.Point(871, 35);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(48, 21);
            this.txtAmount.TabIndex = 10;
            this.txtAmount.TabStop = false;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(868, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 15);
            this.label14.TabIndex = 9;
            this.label14.Text = "Amount";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(696, 35);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(169, 21);
            this.txtQuantity.TabIndex = 8;
            this.txtQuantity.TabStop = false;
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(693, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 15);
            this.label13.TabIndex = 7;
            this.label13.Text = "Qnty";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(530, 35);
            this.txtRate.Name = "txtRate";
            this.txtRate.ReadOnly = true;
            this.txtRate.Size = new System.Drawing.Size(159, 21);
            this.txtRate.TabIndex = 6;
            this.txtRate.TabStop = false;
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(527, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 15);
            this.label12.TabIndex = 5;
            this.label12.Text = "Rate";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(143, 35);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(381, 21);
            this.txtProductName.TabIndex = 4;
            this.txtProductName.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(116, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 23);
            this.button2.TabIndex = 3;
            this.button2.TabStop = false;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtitemcode
            // 
            this.txtitemcode.Location = new System.Drawing.Point(23, 35);
            this.txtitemcode.Name = "txtitemcode";
            this.txtitemcode.Size = new System.Drawing.Size(92, 21);
            this.txtitemcode.TabIndex = 2;
            this.txtitemcode.Text = "I";
            this.txtitemcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtitemcode.TextChanged += new System.EventHandler(this.txtitemcode_TextChanged);
            this.txtitemcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtitemcode_KeyPress);
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
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dtpdate);
            this.groupBox2.Controls.Add(this.txtsrno);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(929, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 86);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            // 
            // dtpdate
            // 
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdate.Location = new System.Drawing.Point(67, 50);
            this.dtpdate.MaxDate = new System.DateTime(2018, 2, 1, 0, 0, 0, 0);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(135, 21);
            this.dtpdate.TabIndex = 7;
            this.dtpdate.TabStop = false;
            this.dtpdate.Value = new System.DateTime(2002, 2, 12, 23, 35, 59, 0);
            // 
            // txtsrno
            // 
            this.txtsrno.Location = new System.Drawing.Point(67, 22);
            this.txtsrno.Name = "txtsrno";
            this.txtsrno.ReadOnly = true;
            this.txtsrno.Size = new System.Drawing.Size(135, 21);
            this.txtsrno.TabIndex = 6;
            this.txtsrno.TabStop = false;
            this.txtsrno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 53);
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.txtcustfax);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtcustmobile);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtcustphone);
            this.groupBox1.Controls.Add(this.txtcustaddress);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtcustcompname);
            this.groupBox1.Controls.Add(this.txtcustname);
            this.groupBox1.Controls.Add(this.txtcustomercode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(908, 161);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            // 
            // txtcustfax
            // 
            this.txtcustfax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcustfax.Location = new System.Drawing.Point(728, 130);
            this.txtcustfax.Name = "txtcustfax";
            this.txtcustfax.ReadOnly = true;
            this.txtcustfax.Size = new System.Drawing.Size(165, 21);
            this.txtcustfax.TabIndex = 14;
            this.txtcustfax.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(725, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Fax";
            // 
            // txtcustmobile
            // 
            this.txtcustmobile.Location = new System.Drawing.Point(381, 130);
            this.txtcustmobile.Name = "txtcustmobile";
            this.txtcustmobile.ReadOnly = true;
            this.txtcustmobile.Size = new System.Drawing.Size(341, 21);
            this.txtcustmobile.TabIndex = 12;
            this.txtcustmobile.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(378, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mobile";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 2;
            this.button1.TabStop = false;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtcustphone
            // 
            this.txtcustphone.Location = new System.Drawing.Point(23, 130);
            this.txtcustphone.Name = "txtcustphone";
            this.txtcustphone.ReadOnly = true;
            this.txtcustphone.Size = new System.Drawing.Size(352, 21);
            this.txtcustphone.TabIndex = 9;
            this.txtcustphone.TabStop = false;
            // 
            // txtcustaddress
            // 
            this.txtcustaddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcustaddress.Location = new System.Drawing.Point(23, 76);
            this.txtcustaddress.Multiline = true;
            this.txtcustaddress.Name = "txtcustaddress";
            this.txtcustaddress.ReadOnly = true;
            this.txtcustaddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtcustaddress.Size = new System.Drawing.Size(870, 33);
            this.txtcustaddress.TabIndex = 8;
            this.txtcustaddress.TabStop = false;
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
            this.txtcustcompname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcustcompname.Location = new System.Drawing.Point(610, 34);
            this.txtcustcompname.Name = "txtcustcompname";
            this.txtcustcompname.ReadOnly = true;
            this.txtcustcompname.Size = new System.Drawing.Size(283, 21);
            this.txtcustcompname.TabIndex = 5;
            this.txtcustcompname.TabStop = false;
            // 
            // txtcustname
            // 
            this.txtcustname.Location = new System.Drawing.Point(143, 34);
            this.txtcustname.Name = "txtcustname";
            this.txtcustname.ReadOnly = true;
            this.txtcustname.Size = new System.Drawing.Size(461, 21);
            this.txtcustname.TabIndex = 4;
            this.txtcustname.TabStop = false;
            // 
            // txtcustomercode
            // 
            this.txtcustomercode.Location = new System.Drawing.Point(23, 34);
            this.txtcustomercode.Name = "txtcustomercode";
            this.txtcustomercode.Size = new System.Drawing.Size(92, 21);
            this.txtcustomercode.TabIndex = 1;
            this.txtcustomercode.Text = "C";
            this.txtcustomercode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtcustomercode.TextChanged += new System.EventHandler(this.txtcustomercode_TextChanged);
            this.txtcustomercode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcustomercode_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(607, 16);
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
            this.butclose.Location = new System.Drawing.Point(111, 601);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(90, 28);
            this.butclose.TabIndex = 50;
            this.butclose.Text = "Close";
            this.butclose.UseVisualStyleBackColor = true;
            this.butclose.Click += new System.EventHandler(this.button6_Click);
            this.butclose.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.button6_KeyPress);
            // 
            // savebutton
            // 
            this.savebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebutton.Location = new System.Drawing.Point(15, 601);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(90, 28);
            this.savebutton.TabIndex = 49;
            this.savebutton.Text = "Save";
            this.savebutton.UseVisualStyleBackColor = true;
            this.savebutton.Click += new System.EventHandler(this.savebutton_Click);
            this.savebutton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.savebutton_KeyPress);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(586, 577);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(47, 21);
            this.textBox1.TabIndex = 57;
            this.textBox1.Text = "CST";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(632, 577);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(45, 21);
            this.textBox2.TabIndex = 58;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(676, 577);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(26, 21);
            this.textBox3.TabIndex = 59;
            this.textBox3.Text = "%";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.crystalReportViewer1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.butback);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1172, 634);
            this.panel2.TabIndex = 60;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1172, 634);
            this.crystalReportViewer1.TabIndex = 8;
            //this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(12, 105);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1141, 476);
            this.panel3.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1137, 472);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick_1);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress_1);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.txtsearchvalue);
            this.groupBox4.Controls.Add(this.search);
            this.groupBox4.Controls.Add(this.comsearchsalesvalue);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 25);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1141, 73);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(684, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 15);
            this.label15.TabIndex = 1;
            this.label15.Text = "Search";
            // 
            // txtsearchvalue
            // 
            this.txtsearchvalue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsearchvalue.Location = new System.Drawing.Point(687, 42);
            this.txtsearchvalue.Multiline = true;
            this.txtsearchvalue.Name = "txtsearchvalue";
            this.txtsearchvalue.Size = new System.Drawing.Size(1067, 23);
            this.txtsearchvalue.TabIndex = 3;
            this.txtsearchvalue.TextChanged += new System.EventHandler(this.txtsearchvalue_TextChanged_1);
            // 
            // search
            // 
            this.search.AutoSize = true;
            this.search.Location = new System.Drawing.Point(23, 24);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(72, 15);
            this.search.TabIndex = 0;
            this.search.Text = "Search Text";
            // 
            // comsearchsalesvalue
            // 
            this.comsearchsalesvalue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comsearchsalesvalue.FormattingEnabled = true;
            this.comsearchsalesvalue.Location = new System.Drawing.Point(25, 42);
            this.comsearchsalesvalue.Name = "comsearchsalesvalue";
            this.comsearchsalesvalue.Size = new System.Drawing.Size(656, 23);
            this.comsearchsalesvalue.TabIndex = 2;
            // 
            // butback
            // 
            this.butback.Location = new System.Drawing.Point(12, 589);
            this.butback.Name = "butback";
            this.butback.Size = new System.Drawing.Size(90, 28);
            this.butback.TabIndex = 5;
            this.butback.Text = "Back";
            this.butback.UseVisualStyleBackColor = true;
            this.butback.Click += new System.EventHandler(this.butback_Click_1);
            // 
            // discountamount
            // 
            this.discountamount.Location = new System.Drawing.Point(862, 602);
            this.discountamount.Name = "discountamount";
            this.discountamount.Size = new System.Drawing.Size(100, 20);
            this.discountamount.TabIndex = 61;
            // 
            // txttaxamount
            // 
            this.txttaxamount.Location = new System.Drawing.Point(682, 602);
            this.txttaxamount.Name = "txttaxamount";
            this.txttaxamount.Size = new System.Drawing.Size(100, 20);
            this.txttaxamount.TabIndex = 62;
            // 
            // txtwithautaxamount
            // 
            this.txtwithautaxamount.Location = new System.Drawing.Point(1031, 602);
            this.txtwithautaxamount.Name = "txtwithautaxamount";
            this.txtwithautaxamount.Size = new System.Drawing.Size(100, 20);
            this.txtwithautaxamount.TabIndex = 63;
            // 
            // salesorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1172, 634);
            this.Controls.Add(this.txtwithautaxamount);
            this.Controls.Add(this.txttaxamount);
            this.Controls.Add(this.discountamount);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.butclose);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.savebutton);
            this.Controls.Add(this.txttotalammount);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBox21);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox20);
            this.Controls.Add(this.textBox19);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.txttax);
            this.KeyPreview = true;
            this.Name = "salesorder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sales Order";
            this.Load += new System.EventHandler(this.salesorder_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.salesorder_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridsalesorder)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridsalesorder;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button butadditem;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtitemcode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.TextBox txtsrno;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtcustfax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtcustmobile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtcustphone;
        private System.Windows.Forms.TextBox txtcustaddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtcustcompname;
        private System.Windows.Forms.TextBox txtcustomercode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttotalammount;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox txttax;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Button butclose;
        private System.Windows.Forms.Button savebutton;
        private System.Windows.Forms.TextBox txtcustname;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butback;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtsearchvalue;
        private System.Windows.Forms.ComboBox comsearchsalesvalue;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label search;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.TextBox discountamount;
        private System.Windows.Forms.TextBox txttaxamount;
        private System.Windows.Forms.TextBox txtwithautaxamount;
    }
}