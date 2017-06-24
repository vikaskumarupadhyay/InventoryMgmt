namespace WindowsFormsApplication1
{
    partial class PurchasSearch1
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
            this.gridPurchaseSearch = new System.Windows.Forms.DataGridView();
            this.comboPurchasesearch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.ExportToExcel = new System.Windows.Forms.Button();
            this.TxtTaxAmount = new System.Windows.Forms.TextBox();
            this.TxtDisAmount = new System.Windows.Forms.TextBox();
            this.TxtWithodTaxAmount = new System.Windows.Forms.TextBox();
            this.TxtGrowsAmount = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.txtBildQuntity = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridPurchaseSearch)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridPurchaseSearch
            // 
            this.gridPurchaseSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPurchaseSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPurchaseSearch.Location = new System.Drawing.Point(0, 0);
            this.gridPurchaseSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gridPurchaseSearch.Name = "gridPurchaseSearch";
            this.gridPurchaseSearch.ReadOnly = true;
            this.gridPurchaseSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPurchaseSearch.Size = new System.Drawing.Size(1329, 460);
            this.gridPurchaseSearch.StandardTab = true;
            this.gridPurchaseSearch.TabIndex = 0;
            // 
            // comboPurchasesearch
            // 
            this.comboPurchasesearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboPurchasesearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPurchasesearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPurchasesearch.FormattingEnabled = true;
            this.comboPurchasesearch.Location = new System.Drawing.Point(35, 40);
            this.comboPurchasesearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboPurchasesearch.Name = "comboPurchasesearch";
            this.comboPurchasesearch.Size = new System.Drawing.Size(337, 22);
            this.comboPurchasesearch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Field";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Type Text";
            // 
            // txtsearch
            // 
            this.txtsearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearch.Location = new System.Drawing.Point(380, 40);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtsearch.Multiline = true;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(321, 22);
            this.txtsearch.TabIndex = 4;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            this.txtsearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsearch_KeyDown);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(34, 40);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(271, 22);
            this.dateTimePicker1.TabIndex = 5;
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
            this.dateTimePicker2.TabIndex = 6;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(329, 621);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 31);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(201, 620);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 31);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ExportToExcel
            // 
            this.ExportToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportToExcel.Location = new System.Drawing.Point(16, 620);
            this.ExportToExcel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ExportToExcel.Name = "ExportToExcel";
            this.ExportToExcel.Size = new System.Drawing.Size(177, 31);
            this.ExportToExcel.TabIndex = 10;
            this.ExportToExcel.Text = "Export To Excel";
            this.ExportToExcel.UseVisualStyleBackColor = true;
            this.ExportToExcel.Click += new System.EventHandler(this.button3_Click);
            // 
            // TxtTaxAmount
            // 
            this.TxtTaxAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTaxAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTaxAmount.Location = new System.Drawing.Point(1178, 15);
            this.TxtTaxAmount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtTaxAmount.Multiline = true;
            this.TxtTaxAmount.Name = "TxtTaxAmount";
            this.TxtTaxAmount.ReadOnly = true;
            this.TxtTaxAmount.Size = new System.Drawing.Size(141, 22);
            this.TxtTaxAmount.TabIndex = 15;
            this.TxtTaxAmount.TabStop = false;
            this.TxtTaxAmount.Text = "0.00";
            this.TxtTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtTaxAmount.TextChanged += new System.EventHandler(this.TxtTaxAmount_TextChanged);
            // 
            // TxtDisAmount
            // 
            this.TxtDisAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDisAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDisAmount.Location = new System.Drawing.Point(830, 15);
            this.TxtDisAmount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtDisAmount.Multiline = true;
            this.TxtDisAmount.Name = "TxtDisAmount";
            this.TxtDisAmount.ReadOnly = true;
            this.TxtDisAmount.Size = new System.Drawing.Size(141, 22);
            this.TxtDisAmount.TabIndex = 16;
            this.TxtDisAmount.TabStop = false;
            this.TxtDisAmount.Text = "0.00";
            this.TxtDisAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtDisAmount.TextChanged += new System.EventHandler(this.TxtDisAmount_TextChanged);
            // 
            // TxtWithodTaxAmount
            // 
            this.TxtWithodTaxAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtWithodTaxAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtWithodTaxAmount.Location = new System.Drawing.Point(1508, 615);
            this.TxtWithodTaxAmount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtWithodTaxAmount.Name = "TxtWithodTaxAmount";
            this.TxtWithodTaxAmount.ReadOnly = true;
            this.TxtWithodTaxAmount.Size = new System.Drawing.Size(141, 21);
            this.TxtWithodTaxAmount.TabIndex = 17;
            this.TxtWithodTaxAmount.TabStop = false;
            this.TxtWithodTaxAmount.Text = "0.00";
            this.TxtWithodTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtWithodTaxAmount.TextChanged += new System.EventHandler(this.TxtWithodTaxAmount_TextChanged);
            // 
            // TxtGrowsAmount
            // 
            this.TxtGrowsAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtGrowsAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtGrowsAmount.Location = new System.Drawing.Point(487, 15);
            this.TxtGrowsAmount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtGrowsAmount.Multiline = true;
            this.TxtGrowsAmount.Name = "TxtGrowsAmount";
            this.TxtGrowsAmount.ReadOnly = true;
            this.TxtGrowsAmount.Size = new System.Drawing.Size(141, 22);
            this.TxtGrowsAmount.TabIndex = 18;
            this.TxtGrowsAmount.TabStop = false;
            this.TxtGrowsAmount.Text = "0.00";
            this.TxtGrowsAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtGrowsAmount.TextChanged += new System.EventHandler(this.TxtGrowsAmount_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(599, 84);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(310, 23);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 14);
            this.label8.TabIndex = 8;
            this.label8.Text = "To";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 23);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 14);
            this.label7.TabIndex = 7;
            this.label7.Text = "From";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtsearch);
            this.groupBox2.Controls.Add(this.comboPurchasesearch);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(623, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(726, 84);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Purchase Delivery Search";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.gridPurchaseSearch);
            this.panel1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(16, 103);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1333, 464);
            this.panel1.TabIndex = 21;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(457, 15);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(31, 22);
            this.textBox2.TabIndex = 27;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "₹";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(317, 15);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(141, 22);
            this.textBox1.TabIndex = 26;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Gross Amount ";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(800, 15);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(31, 22);
            this.textBox4.TabIndex = 29;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "₹";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(636, 15);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(165, 22);
            this.textBox3.TabIndex = 28;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "Discount Amount";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(1148, 15);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(31, 22);
            this.textBox7.TabIndex = 31;
            this.textBox7.TabStop = false;
            this.textBox7.Text = "₹";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(979, 15);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(170, 22);
            this.textBox6.TabIndex = 30;
            this.textBox6.TabStop = false;
            this.textBox6.Text = "Net Amount (Inc. Tax)";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox9
            // 
            this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(1477, 615);
            this.textBox9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(31, 21);
            this.textBox9.TabIndex = 33;
            this.textBox9.TabStop = false;
            this.textBox9.Text = "₹";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox8
            // 
            this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(1368, 615);
            this.textBox8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(109, 21);
            this.textBox8.TabIndex = 32;
            this.textBox8.TabStop = false;
            this.textBox8.Text = "N A (Inc. Tax)";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBildQuntity
            // 
            this.txtBildQuntity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBildQuntity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBildQuntity.Location = new System.Drawing.Point(168, 15);
            this.txtBildQuntity.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBildQuntity.Multiline = true;
            this.txtBildQuntity.Name = "txtBildQuntity";
            this.txtBildQuntity.ReadOnly = true;
            this.txtBildQuntity.Size = new System.Drawing.Size(141, 22);
            this.txtBildQuntity.TabIndex = 1;
            this.txtBildQuntity.TabStop = false;
            this.txtBildQuntity.Text = "0";
            this.txtBildQuntity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBildQuntity.TextChanged += new System.EventHandler(this.txtBildQuntity_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(11, 15);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(128, 22);
            this.textBox5.TabIndex = 34;
            this.textBox5.TabStop = false;
            this.textBox5.Text = "Billed Quantity";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox10
            // 
            this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(138, 15);
            this.textBox10.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(31, 22);
            this.textBox10.TabIndex = 35;
            this.textBox10.TabStop = false;
            this.textBox10.Text = "₹";
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Controls.Add(this.textBox10);
            this.groupBox3.Controls.Add(this.TxtTaxAmount);
            this.groupBox3.Controls.Add(this.txtBildQuntity);
            this.groupBox3.Controls.Add(this.TxtDisAmount);
            this.groupBox3.Controls.Add(this.TxtGrowsAmount);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.textBox7);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.textBox6);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Location = new System.Drawing.Point(16, 566);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1331, 43);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            // 
            // PurchasSearch1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 690);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TxtWithodTaxAmount);
            this.Controls.Add(this.ExportToExcel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "PurchasSearch1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Details";
            this.Load += new System.EventHandler(this.PurchasSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPurchaseSearch)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridPurchaseSearch;
        private System.Windows.Forms.ComboBox comboPurchasesearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button ExportToExcel;
        private System.Windows.Forms.TextBox TxtTaxAmount;
        private System.Windows.Forms.TextBox TxtDisAmount;
        private System.Windows.Forms.TextBox TxtWithodTaxAmount;
        private System.Windows.Forms.TextBox TxtGrowsAmount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox txtBildQuntity;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}