namespace WindowsFormsApplication1
{
    partial class Item
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnItemUnit = new System.Windows.Forms.Button();
            this.btnItemGroup = new System.Windows.Forms.Button();
            this.cmbItemUnit = new System.Windows.Forms.ComboBox();
            this.cmbItemItemGroup = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtItemDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtItemCompName = new System.Windows.Forms.TextBox();
            this.txtItemProductName = new System.Windows.Forms.TextBox();
            this.txtItemProductCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtItemMargin = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtItemMrp = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.txtItemSalesPrice = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.txtItemPrice = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtItemOpeningQuant = new System.Windows.Forms.TextBox();
            this.txtItemRemaningQuant = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnItemSave = new System.Windows.Forms.Button();
            this.btnItemClose = new System.Windows.Forms.Button();
            this.btnItemList = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.searchCalmn = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.butPrint = new System.Windows.Forms.Button();
            this.buttClose2 = new System.Windows.Forms.Button();
            this.buttUpdate = new System.Windows.Forms.Button();
            this.buttAddNewRecord = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnItemUnit);
            this.groupBox1.Controls.Add(this.btnItemGroup);
            this.groupBox1.Controls.Add(this.cmbItemUnit);
            this.groupBox1.Controls.Add(this.cmbItemItemGroup);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtItemDesc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtItemCompName);
            this.groupBox1.Controls.Add(this.txtItemProductName);
            this.groupBox1.Controls.Add(this.txtItemProductCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1148, 225);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Details";
            // 
            // btnItemUnit
            // 
            this.btnItemUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemUnit.Location = new System.Drawing.Point(345, 187);
            this.btnItemUnit.Name = "btnItemUnit";
            this.btnItemUnit.Size = new System.Drawing.Size(28, 24);
            this.btnItemUnit.TabIndex = 8;
            this.btnItemUnit.Text = "...";
            this.btnItemUnit.UseVisualStyleBackColor = true;
            this.btnItemUnit.Click += new System.EventHandler(this.btnItemUnit_Click);
            // 
            // btnItemGroup
            // 
            this.btnItemGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemGroup.Location = new System.Drawing.Point(345, 144);
            this.btnItemGroup.Name = "btnItemGroup";
            this.btnItemGroup.Size = new System.Drawing.Size(28, 23);
            this.btnItemGroup.TabIndex = 6;
            this.btnItemGroup.Text = "...";
            this.btnItemGroup.UseVisualStyleBackColor = true;
            this.btnItemGroup.Click += new System.EventHandler(this.btnItemGroup_Click);
            // 
            // cmbItemUnit
            // 
            this.cmbItemUnit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbItemUnit.FormattingEnabled = true;
            this.cmbItemUnit.Location = new System.Drawing.Point(46, 188);
            this.cmbItemUnit.Name = "cmbItemUnit";
            this.cmbItemUnit.Size = new System.Drawing.Size(293, 23);
            this.cmbItemUnit.TabIndex = 7;
            this.cmbItemUnit.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // cmbItemItemGroup
            // 
            this.cmbItemItemGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbItemItemGroup.FormattingEnabled = true;
            this.cmbItemItemGroup.Location = new System.Drawing.Point(46, 144);
            this.cmbItemItemGroup.Name = "cmbItemItemGroup";
            this.cmbItemItemGroup.Size = new System.Drawing.Size(293, 23);
            this.cmbItemItemGroup.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Unit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Item Group";
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemDesc.Location = new System.Drawing.Point(46, 80);
            this.txtItemDesc.Multiline = true;
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtItemDesc.Size = new System.Drawing.Size(1082, 43);
            this.txtItemDesc.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description";
            // 
            // txtItemCompName
            // 
            this.txtItemCompName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemCompName.Location = new System.Drawing.Point(722, 38);
            this.txtItemCompName.Name = "txtItemCompName";
            this.txtItemCompName.Size = new System.Drawing.Size(406, 21);
            this.txtItemCompName.TabIndex = 3;
            // 
            // txtItemProductName
            // 
            this.txtItemProductName.Location = new System.Drawing.Point(147, 38);
            this.txtItemProductName.Name = "txtItemProductName";
            this.txtItemProductName.Size = new System.Drawing.Size(569, 21);
            this.txtItemProductName.TabIndex = 2;
            // 
            // txtItemProductCode
            // 
            this.txtItemProductCode.Location = new System.Drawing.Point(46, 38);
            this.txtItemProductCode.Name = "txtItemProductCode";
            this.txtItemProductCode.ReadOnly = true;
            this.txtItemProductCode.Size = new System.Drawing.Size(95, 21);
            this.txtItemProductCode.TabIndex = 1;
            this.txtItemProductCode.TabStop = false;
            this.txtItemProductCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(719, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Company Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Code";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtItemMargin);
            this.groupBox2.Controls.Add(this.textBox11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtItemMrp);
            this.groupBox2.Controls.Add(this.textBox9);
            this.groupBox2.Controls.Add(this.txtItemSalesPrice);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.txtItemPrice);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 283);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1148, 123);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Price Details";
            // 
            // txtItemMargin
            // 
            this.txtItemMargin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemMargin.Location = new System.Drawing.Point(720, 87);
            this.txtItemMargin.Name = "txtItemMargin";
            this.txtItemMargin.ReadOnly = true;
            this.txtItemMargin.Size = new System.Drawing.Size(408, 21);
            this.txtItemMargin.TabIndex = 11;
            this.txtItemMargin.TabStop = false;
            this.txtItemMargin.Text = "0";
            this.txtItemMargin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.SystemColors.Control;
            this.textBox11.Location = new System.Drawing.Point(666, 87);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(48, 21);
            this.textBox11.TabIndex = 10;
            this.textBox11.TabStop = false;
            this.textBox11.Text = "Rs.";
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(663, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Margin";
            // 
            // txtItemMrp
            // 
            this.txtItemMrp.Location = new System.Drawing.Point(100, 87);
            this.txtItemMrp.Name = "txtItemMrp";
            this.txtItemMrp.Size = new System.Drawing.Size(560, 21);
            this.txtItemMrp.TabIndex = 14;
            this.txtItemMrp.Text = "0";
            this.txtItemMrp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItemMrp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtItemMrp_MouseClick);
            this.txtItemMrp.TextChanged += new System.EventHandler(this.txtItemMrp_TextChanged);
            this.txtItemMrp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemMrp_KeyPress);
            this.txtItemMrp.Leave += new System.EventHandler(this.txtItemMrp_Leave);
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.Control;
            this.textBox9.Location = new System.Drawing.Point(46, 87);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(48, 21);
            this.textBox9.TabIndex = 7;
            this.textBox9.TabStop = false;
            this.textBox9.Text = "Rs.";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtItemSalesPrice
            // 
            this.txtItemSalesPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemSalesPrice.Location = new System.Drawing.Point(720, 44);
            this.txtItemSalesPrice.Name = "txtItemSalesPrice";
            this.txtItemSalesPrice.Size = new System.Drawing.Size(408, 21);
            this.txtItemSalesPrice.TabIndex = 13;
            this.txtItemSalesPrice.Text = "0";
            this.txtItemSalesPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItemSalesPrice.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtItemSalesPrice_MouseClick);
            this.txtItemSalesPrice.TextChanged += new System.EventHandler(this.txtItemSalesPrice_TextChanged);
            this.txtItemSalesPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemSalesPrice_KeyPress);
            this.txtItemSalesPrice.Leave += new System.EventHandler(this.txtItemSalesPrice_Leave);
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox7.Location = new System.Drawing.Point(666, 44);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(48, 21);
            this.textBox7.TabIndex = 5;
            this.textBox7.TabStop = false;
            this.textBox7.Text = "Rs.";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtItemPrice
            // 
            this.txtItemPrice.Location = new System.Drawing.Point(100, 45);
            this.txtItemPrice.Name = "txtItemPrice";
            this.txtItemPrice.Size = new System.Drawing.Size(560, 21);
            this.txtItemPrice.TabIndex = 12;
            this.txtItemPrice.Text = "0";
            this.txtItemPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItemPrice.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtItemPrice_MouseClick);
            this.txtItemPrice.TextChanged += new System.EventHandler(this.txtItemPrice_TextChanged);
            this.txtItemPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemPrice_KeyPress);
            this.txtItemPrice.Leave += new System.EventHandler(this.txtItemPrice_Leave);
            this.txtItemPrice.MouseEnter += new System.EventHandler(this.txtItemPrice_MouseEnter);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.Location = new System.Drawing.Point(46, 44);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(48, 21);
            this.textBox5.TabIndex = 3;
            this.textBox5.TabStop = false;
            this.textBox5.Text = "Rs.";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "M.R.P.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(663, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Sales Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Purchase Price";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(663, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 15);
            this.label12.TabIndex = 1;
            this.label12.Text = "Remaining Quantity";
            // 
            // txtItemOpeningQuant
            // 
            this.txtItemOpeningQuant.Location = new System.Drawing.Point(46, 42);
            this.txtItemOpeningQuant.Name = "txtItemOpeningQuant";
            this.txtItemOpeningQuant.Size = new System.Drawing.Size(614, 21);
            this.txtItemOpeningQuant.TabIndex = 16;
            this.txtItemOpeningQuant.Text = "0";
            this.txtItemOpeningQuant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItemOpeningQuant.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtItemOpeningQuant_MouseClick);
            this.txtItemOpeningQuant.TextChanged += new System.EventHandler(this.txtItemOpeningQuant_TextChanged);
            this.txtItemOpeningQuant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemOpeningQuant_KeyPress);
            this.txtItemOpeningQuant.Leave += new System.EventHandler(this.txtItemOpeningQuant_Leave);
            // 
            // txtItemRemaningQuant
            // 
            this.txtItemRemaningQuant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemRemaningQuant.Location = new System.Drawing.Point(666, 42);
            this.txtItemRemaningQuant.Name = "txtItemRemaningQuant";
            this.txtItemRemaningQuant.ReadOnly = true;
            this.txtItemRemaningQuant.Size = new System.Drawing.Size(462, 21);
            this.txtItemRemaningQuant.TabIndex = 3;
            this.txtItemRemaningQuant.TabStop = false;
            this.txtItemRemaningQuant.Text = "0";
            this.txtItemRemaningQuant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtItemRemaningQuant);
            this.groupBox3.Controls.Add(this.txtItemOpeningQuant);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 412);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1148, 79);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Quantity Details";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Opening Quantity";
            // 
            // btnItemSave
            // 
            this.btnItemSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemSave.Location = new System.Drawing.Point(14, 501);
            this.btnItemSave.Name = "btnItemSave";
            this.btnItemSave.Size = new System.Drawing.Size(90, 28);
            this.btnItemSave.TabIndex = 17;
            this.btnItemSave.Text = "Save";
            this.btnItemSave.UseVisualStyleBackColor = true;
            this.btnItemSave.Click += new System.EventHandler(this.btnItemSave_Click);
            // 
            // btnItemClose
            // 
            this.btnItemClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemClose.Location = new System.Drawing.Point(110, 501);
            this.btnItemClose.Name = "btnItemClose";
            this.btnItemClose.Size = new System.Drawing.Size(90, 28);
            this.btnItemClose.TabIndex = 18;
            this.btnItemClose.Text = "Close";
            this.btnItemClose.UseVisualStyleBackColor = true;
            this.btnItemClose.Click += new System.EventHandler(this.btnItemClose_Click);
            // 
            // btnItemList
            // 
            this.btnItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnItemList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemList.Location = new System.Drawing.Point(1094, 23);
            this.btnItemList.Name = "btnItemList";
            this.btnItemList.Size = new System.Drawing.Size(66, 28);
            this.btnItemList.TabIndex = 19;
            this.btnItemList.Text = "List";
            this.btnItemList.UseVisualStyleBackColor = true;
            this.btnItemList.Click += new System.EventHandler(this.btnItemList_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.butPrint);
            this.panel1.Controls.Add(this.buttClose2);
            this.panel1.Controls.Add(this.buttUpdate);
            this.panel1.Controls.Add(this.buttAddNewRecord);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1172, 548);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(12, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1150, 386);
            this.panel2.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1146, 382);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(334, 501);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 28);
            this.button2.TabIndex = 6;
            this.button2.Text = "Export To Excel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.searchCalmn);
            this.groupBox4.Controls.Add(this.txtSearch);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 25);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1150, 73);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Item Search";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(22, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 15);
            this.label13.TabIndex = 5;
            this.label13.Text = "Select Search";
            // 
            // searchCalmn
            // 
            this.searchCalmn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchCalmn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchCalmn.FormattingEnabled = true;
            this.searchCalmn.Location = new System.Drawing.Point(25, 42);
            this.searchCalmn.Name = "searchCalmn";
            this.searchCalmn.Size = new System.Drawing.Size(656, 24);
            this.searchCalmn.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(687, 42);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(430, 24);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(684, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 15);
            this.label14.TabIndex = 6;
            this.label14.Text = "Search";
            // 
            // butPrint
            // 
            this.butPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butPrint.Location = new System.Drawing.Point(253, 501);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(75, 28);
            this.butPrint.TabIndex = 5;
            this.butPrint.Text = "Print";
            this.butPrint.UseVisualStyleBackColor = true;
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // buttClose2
            // 
            this.buttClose2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttClose2.Location = new System.Drawing.Point(471, 501);
            this.buttClose2.Name = "buttClose2";
            this.buttClose2.Size = new System.Drawing.Size(90, 28);
            this.buttClose2.TabIndex = 7;
            this.buttClose2.Text = "Close";
            this.buttClose2.UseVisualStyleBackColor = true;
            this.buttClose2.Click += new System.EventHandler(this.buttClose_Click);
            // 
            // buttUpdate
            // 
            this.buttUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttUpdate.Location = new System.Drawing.Point(14, 501);
            this.buttUpdate.Name = "buttUpdate";
            this.buttUpdate.Size = new System.Drawing.Size(90, 28);
            this.buttUpdate.TabIndex = 3;
            this.buttUpdate.Text = "Update";
            this.buttUpdate.UseVisualStyleBackColor = true;
            this.buttUpdate.Click += new System.EventHandler(this.buttUpdate_Click);
            // 
            // buttAddNewRecord
            // 
            this.buttAddNewRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttAddNewRecord.Location = new System.Drawing.Point(110, 501);
            this.buttAddNewRecord.Name = "buttAddNewRecord";
            this.buttAddNewRecord.Size = new System.Drawing.Size(137, 28);
            this.buttAddNewRecord.TabIndex = 4;
            this.buttAddNewRecord.Text = "Add New Record";
            this.buttAddNewRecord.UseVisualStyleBackColor = true;
            this.buttAddNewRecord.Click += new System.EventHandler(this.buttAddNewRecord_Click);
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 549);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnItemList);
            this.Controls.Add(this.btnItemClose);
            this.Controls.Add(this.btnItemSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Item";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Details";
            this.Load += new System.EventHandler(this.Item_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtItemCompName;
        private System.Windows.Forms.TextBox txtItemProductName;
        private System.Windows.Forms.TextBox txtItemProductCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbItemUnit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtItemDesc;
        private System.Windows.Forms.Button btnItemUnit;
        private System.Windows.Forms.Button btnItemGroup;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox txtItemPrice;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txtItemMrp;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox txtItemSalesPrice;
        private System.Windows.Forms.TextBox txtItemMargin;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtItemOpeningQuant;
        private System.Windows.Forms.TextBox txtItemRemaningQuant;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnItemSave;
        private System.Windows.Forms.Button btnItemClose;
        private System.Windows.Forms.Button btnItemList;
        public System.Windows.Forms.ComboBox cmbItemItemGroup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttClose2;
        private System.Windows.Forms.Button buttUpdate;
        private System.Windows.Forms.Button buttAddNewRecord;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox searchCalmn;
        private System.Windows.Forms.Button butPrint;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
    }
}