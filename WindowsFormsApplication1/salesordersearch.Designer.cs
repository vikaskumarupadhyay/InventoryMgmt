namespace WindowsFormsApplication1
{
    partial class salesordersearch
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
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.comsalesordersearch = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnexcel = new System.Windows.Forms.Button();
            this.txtGrossAmount = new System.Windows.Forms.TextBox();
            this.Txtdisamount = new System.Windows.Forms.TextBox();
            this.txttaxamount = new System.Windows.Forms.TextBox();
            this.txtwithauttaxamount = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnprint = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.txtquantitybuiled = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Field";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type Text";
            // 
            // txtsearch
            // 
            this.txtsearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsearch.Location = new System.Drawing.Point(380, 40);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtsearch.Multiline = true;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(321, 22);
            this.txtsearch.TabIndex = 6;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            this.txtsearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsearch_KeyDown);
            // 
            // comsalesordersearch
            // 
            this.comsalesordersearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comsalesordersearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comsalesordersearch.FormattingEnabled = true;
            this.comsalesordersearch.Location = new System.Drawing.Point(35, 40);
            this.comsalesordersearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comsalesordersearch.Name = "comsalesordersearch";
            this.comsalesordersearch.Size = new System.Drawing.Size(337, 22);
            this.comsalesordersearch.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(34, 40);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(271, 22);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(313, 40);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(271, 22);
            this.dateTimePicker2.TabIndex = 3;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1329, 460);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 8;
            // 
            // btnclose
            // 
            this.btnclose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.Location = new System.Drawing.Point(329, 621);
            this.btnclose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(120, 31);
            this.btnclose.TabIndex = 11;
            this.btnclose.Text = "&Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnexcel
            // 
            this.btnexcel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexcel.Location = new System.Drawing.Point(16, 621);
            this.btnexcel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnexcel.Name = "btnexcel";
            this.btnexcel.Size = new System.Drawing.Size(177, 31);
            this.btnexcel.TabIndex = 9;
            this.btnexcel.Text = "E&xport To Excel";
            this.btnexcel.UseVisualStyleBackColor = true;
            this.btnexcel.Click += new System.EventHandler(this.btnexcel_Click);
            // 
            // txtGrossAmount
            // 
            this.txtGrossAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGrossAmount.BackColor = System.Drawing.SystemColors.Control;
            this.txtGrossAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrossAmount.Location = new System.Drawing.Point(396, 15);
            this.txtGrossAmount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtGrossAmount.Multiline = true;
            this.txtGrossAmount.Name = "txtGrossAmount";
            this.txtGrossAmount.ReadOnly = true;
            this.txtGrossAmount.Size = new System.Drawing.Size(121, 22);
            this.txtGrossAmount.TabIndex = 15;
            this.txtGrossAmount.TabStop = false;
            this.txtGrossAmount.Text = "0.00";
            this.txtGrossAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txtdisamount
            // 
            this.Txtdisamount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txtdisamount.BackColor = System.Drawing.SystemColors.Control;
            this.Txtdisamount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtdisamount.Location = new System.Drawing.Point(667, 15);
            this.Txtdisamount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Txtdisamount.Multiline = true;
            this.Txtdisamount.Name = "Txtdisamount";
            this.Txtdisamount.ReadOnly = true;
            this.Txtdisamount.Size = new System.Drawing.Size(121, 22);
            this.Txtdisamount.TabIndex = 16;
            this.Txtdisamount.TabStop = false;
            this.Txtdisamount.Text = "0.00";
            this.Txtdisamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txtdisamount.TextChanged += new System.EventHandler(this.Txtdisamount_TextChanged);
            // 
            // txttaxamount
            // 
            this.txttaxamount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txttaxamount.BackColor = System.Drawing.SystemColors.Control;
            this.txttaxamount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttaxamount.Location = new System.Drawing.Point(898, 15);
            this.txttaxamount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txttaxamount.Multiline = true;
            this.txttaxamount.Name = "txttaxamount";
            this.txttaxamount.ReadOnly = true;
            this.txttaxamount.Size = new System.Drawing.Size(121, 22);
            this.txttaxamount.TabIndex = 17;
            this.txttaxamount.TabStop = false;
            this.txttaxamount.Text = "0.00";
            this.txttaxamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtwithauttaxamount
            // 
            this.txtwithauttaxamount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtwithauttaxamount.BackColor = System.Drawing.SystemColors.Control;
            this.txtwithauttaxamount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtwithauttaxamount.Location = new System.Drawing.Point(1197, 15);
            this.txtwithauttaxamount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtwithauttaxamount.Multiline = true;
            this.txtwithauttaxamount.Name = "txtwithauttaxamount";
            this.txtwithauttaxamount.ReadOnly = true;
            this.txtwithauttaxamount.Size = new System.Drawing.Size(121, 22);
            this.txtwithauttaxamount.TabIndex = 18;
            this.txtwithauttaxamount.TabStop = false;
            this.txtwithauttaxamount.Text = "0.00";
            this.txtwithauttaxamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(599, 84);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 23);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 14);
            this.label8.TabIndex = 7;
            this.label8.Text = "From";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(310, 23);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 6;
            this.label7.Text = "To";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtsearch);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comsalesordersearch);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(623, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(726, 84);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sales Order Search";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(16, 103);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1333, 464);
            this.panel1.TabIndex = 7;
            // 
            // btnprint
            // 
            this.btnprint.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.Location = new System.Drawing.Point(201, 621);
            this.btnprint.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(120, 31);
            this.btnprint.TabIndex = 10;
            this.btnprint.Text = "Print";
            this.btnprint.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(375, 15);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(22, 22);
            this.textBox2.TabIndex = 27;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "₹";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(266, 15);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(110, 22);
            this.textBox1.TabIndex = 26;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Gross Amount ";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(646, 15);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(22, 22);
            this.textBox4.TabIndex = 29;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "₹";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(525, 15);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(122, 22);
            this.textBox3.TabIndex = 28;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "Discount Amount";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(877, 15);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(22, 22);
            this.textBox7.TabIndex = 31;
            this.textBox7.TabStop = false;
            this.textBox7.Text = "₹";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(796, 15);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(82, 22);
            this.textBox6.TabIndex = 30;
            this.textBox6.TabStop = false;
            this.textBox6.Text = "Tax Amount";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox9
            // 
            this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(1176, 15);
            this.textBox9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(22, 22);
            this.textBox9.TabIndex = 33;
            this.textBox9.TabStop = false;
            this.textBox9.Text = "₹";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox8
            // 
            this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(1027, 15);
            this.textBox8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(150, 22);
            this.textBox8.TabIndex = 32;
            this.textBox8.TabStop = false;
            this.textBox8.Text = "Net Amount (Inc. Tax)";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(12, 15);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(105, 22);
            this.textBox5.TabIndex = 6;
            this.textBox5.TabStop = false;
            this.textBox5.Text = "Billed Quantity";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox10
            // 
            this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(116, 15);
            this.textBox10.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(22, 22);
            this.textBox10.TabIndex = 34;
            this.textBox10.TabStop = false;
            this.textBox10.Text = "₹";
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtquantitybuiled
            // 
            this.txtquantitybuiled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtquantitybuiled.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtquantitybuiled.Location = new System.Drawing.Point(137, 15);
            this.txtquantitybuiled.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtquantitybuiled.Multiline = true;
            this.txtquantitybuiled.Name = "txtquantitybuiled";
            this.txtquantitybuiled.ReadOnly = true;
            this.txtquantitybuiled.Size = new System.Drawing.Size(121, 22);
            this.txtquantitybuiled.TabIndex = 35;
            this.txtquantitybuiled.TabStop = false;
            this.txtquantitybuiled.Text = "0";
            this.txtquantitybuiled.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtquantitybuiled);
            this.groupBox3.Controls.Add(this.textBox9);
            this.groupBox3.Controls.Add(this.txtGrossAmount);
            this.groupBox3.Controls.Add(this.textBox10);
            this.groupBox3.Controls.Add(this.Txtdisamount);
            this.groupBox3.Controls.Add(this.textBox8);
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Controls.Add(this.txttaxamount);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.txtwithauttaxamount);
            this.groupBox3.Controls.Add(this.textBox7);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.textBox6);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Location = new System.Drawing.Point(16, 566);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1331, 43);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            // 
            // salesordersearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 690);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnexcel);
            this.Controls.Add(this.btnclose);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "salesordersearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Order Details";
            this.Load += new System.EventHandler(this.salesordersearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.ComboBox comsalesordersearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnexcel;
        private System.Windows.Forms.TextBox txtGrossAmount;
        private System.Windows.Forms.TextBox Txtdisamount;
        private System.Windows.Forms.TextBox txttaxamount;
        private System.Windows.Forms.TextBox txtwithauttaxamount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox txtquantitybuiled;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}