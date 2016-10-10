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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
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
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(659, 225);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Details";
            // 
            // btnItemUnit
            // 
            this.btnItemUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemUnit.Location = new System.Drawing.Point(217, 187);
            this.btnItemUnit.Name = "btnItemUnit";
            this.btnItemUnit.Size = new System.Drawing.Size(28, 24);
            this.btnItemUnit.TabIndex = 13;
            this.btnItemUnit.TabStop = false;
            this.btnItemUnit.Text = "...";
            this.btnItemUnit.UseVisualStyleBackColor = true;
            this.btnItemUnit.Click += new System.EventHandler(this.btnItemUnit_Click);
            // 
            // btnItemGroup
            // 
            this.btnItemGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemGroup.Location = new System.Drawing.Point(217, 144);
            this.btnItemGroup.Name = "btnItemGroup";
            this.btnItemGroup.Size = new System.Drawing.Size(28, 23);
            this.btnItemGroup.TabIndex = 12;
            this.btnItemGroup.TabStop = false;
            this.btnItemGroup.Text = "...";
            this.btnItemGroup.UseVisualStyleBackColor = true;
            this.btnItemGroup.Click += new System.EventHandler(this.btnItemGroup_Click);
            // 
            // cmbItemUnit
            // 
            this.cmbItemUnit.FormattingEnabled = true;
            this.cmbItemUnit.Location = new System.Drawing.Point(46, 188);
            this.cmbItemUnit.Name = "cmbItemUnit";
            this.cmbItemUnit.Size = new System.Drawing.Size(165, 23);
            this.cmbItemUnit.TabIndex = 11;
            this.cmbItemUnit.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // cmbItemItemGroup
            // 
            this.cmbItemItemGroup.FormattingEnabled = true;
            this.cmbItemItemGroup.Location = new System.Drawing.Point(46, 144);
            this.cmbItemItemGroup.Name = "cmbItemItemGroup";
            this.cmbItemItemGroup.Size = new System.Drawing.Size(165, 23);
            this.cmbItemItemGroup.TabIndex = 10;
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
            this.txtItemDesc.Location = new System.Drawing.Point(46, 80);
            this.txtItemDesc.Multiline = true;
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtItemDesc.Size = new System.Drawing.Size(576, 43);
            this.txtItemDesc.TabIndex = 7;
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
            this.txtItemCompName.Location = new System.Drawing.Point(392, 38);
            this.txtItemCompName.Name = "txtItemCompName";
            this.txtItemCompName.Size = new System.Drawing.Size(230, 21);
            this.txtItemCompName.TabIndex = 5;
            // 
            // txtItemProductName
            // 
            this.txtItemProductName.Location = new System.Drawing.Point(147, 38);
            this.txtItemProductName.Name = "txtItemProductName";
            this.txtItemProductName.Size = new System.Drawing.Size(239, 21);
            this.txtItemProductName.TabIndex = 4;
            // 
            // txtItemProductCode
            // 
            this.txtItemProductCode.Location = new System.Drawing.Point(46, 38);
            this.txtItemProductCode.Name = "txtItemProductCode";
            this.txtItemProductCode.ReadOnly = true;
            this.txtItemProductCode.Size = new System.Drawing.Size(95, 21);
            this.txtItemProductCode.TabIndex = 3;
            this.txtItemProductCode.TabStop = false;
            this.txtItemProductCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(389, 20);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 255);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(659, 123);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Price Details";
            // 
            // txtItemMargin
            // 
            this.txtItemMargin.Location = new System.Drawing.Point(419, 87);
            this.txtItemMargin.Name = "txtItemMargin";
            this.txtItemMargin.ReadOnly = true;
            this.txtItemMargin.Size = new System.Drawing.Size(203, 21);
            this.txtItemMargin.TabIndex = 11;
            this.txtItemMargin.TabStop = false;
            this.txtItemMargin.Text = "0";
            this.txtItemMargin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.SystemColors.Control;
            this.textBox11.Location = new System.Drawing.Point(341, 87);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(72, 21);
            this.textBox11.TabIndex = 10;
            this.textBox11.TabStop = false;
            this.textBox11.Text = "Rs.";
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(338, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Margin";
            // 
            // txtItemMrp
            // 
            this.txtItemMrp.Location = new System.Drawing.Point(124, 87);
            this.txtItemMrp.Name = "txtItemMrp";
            this.txtItemMrp.Size = new System.Drawing.Size(211, 21);
            this.txtItemMrp.TabIndex = 8;
            this.txtItemMrp.Text = "0";
            this.txtItemMrp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.Control;
            this.textBox9.Location = new System.Drawing.Point(46, 87);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(72, 21);
            this.textBox9.TabIndex = 7;
            this.textBox9.TabStop = false;
            this.textBox9.Text = "Rs.";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtItemSalesPrice
            // 
            this.txtItemSalesPrice.Location = new System.Drawing.Point(419, 44);
            this.txtItemSalesPrice.Name = "txtItemSalesPrice";
            this.txtItemSalesPrice.Size = new System.Drawing.Size(203, 21);
            this.txtItemSalesPrice.TabIndex = 6;
            this.txtItemSalesPrice.Text = "0";
            this.txtItemSalesPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox7.Location = new System.Drawing.Point(341, 44);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(72, 21);
            this.textBox7.TabIndex = 5;
            this.textBox7.TabStop = false;
            this.textBox7.Text = "Rs.";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtItemPrice
            // 
            this.txtItemPrice.Location = new System.Drawing.Point(124, 44);
            this.txtItemPrice.Name = "txtItemPrice";
            this.txtItemPrice.Size = new System.Drawing.Size(211, 21);
            this.txtItemPrice.TabIndex = 4;
            this.txtItemPrice.Text = "0";
            this.txtItemPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.Location = new System.Drawing.Point(46, 44);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(72, 21);
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
            this.label7.Location = new System.Drawing.Point(338, 26);
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
            this.label12.Location = new System.Drawing.Point(338, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 15);
            this.label12.TabIndex = 1;
            this.label12.Text = "Remaining Quantity";
            // 
            // txtItemOpeningQuant
            // 
            this.txtItemOpeningQuant.Location = new System.Drawing.Point(46, 42);
            this.txtItemOpeningQuant.Name = "txtItemOpeningQuant";
            this.txtItemOpeningQuant.Size = new System.Drawing.Size(289, 21);
            this.txtItemOpeningQuant.TabIndex = 2;
            this.txtItemOpeningQuant.Text = "0";
            this.txtItemOpeningQuant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtItemRemaningQuant
            // 
            this.txtItemRemaningQuant.Location = new System.Drawing.Point(341, 42);
            this.txtItemRemaningQuant.MaximumSize = new System.Drawing.Size(270, 21);
            this.txtItemRemaningQuant.Name = "txtItemRemaningQuant";
            this.txtItemRemaningQuant.ReadOnly = true;
            this.txtItemRemaningQuant.Size = new System.Drawing.Size(270, 21);
            this.txtItemRemaningQuant.TabIndex = 3;
            this.txtItemRemaningQuant.TabStop = false;
            this.txtItemRemaningQuant.Text = "0";
            this.txtItemRemaningQuant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtItemRemaningQuant);
            this.groupBox3.Controls.Add(this.txtItemOpeningQuant);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 378);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(659, 75);
            this.groupBox3.TabIndex = 2;
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
            this.btnItemSave.Location = new System.Drawing.Point(20, 479);
            this.btnItemSave.Name = "btnItemSave";
            this.btnItemSave.Size = new System.Drawing.Size(90, 28);
            this.btnItemSave.TabIndex = 6;
            this.btnItemSave.Text = "Save";
            this.btnItemSave.UseVisualStyleBackColor = true;
            this.btnItemSave.Click += new System.EventHandler(this.btnItemSave_Click);
            // 
            // btnItemClose
            // 
            this.btnItemClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemClose.Location = new System.Drawing.Point(116, 479);
            this.btnItemClose.Name = "btnItemClose";
            this.btnItemClose.Size = new System.Drawing.Size(90, 28);
            this.btnItemClose.TabIndex = 7;
            this.btnItemClose.Text = "Close";
            this.btnItemClose.UseVisualStyleBackColor = true;
            // 
            // btnItemList
            // 
            this.btnItemList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemList.Location = new System.Drawing.Point(605, 5);
            this.btnItemList.Name = "btnItemList";
            this.btnItemList.Size = new System.Drawing.Size(66, 28);
            this.btnItemList.TabIndex = 9;
            this.btnItemList.Text = "List";
            this.btnItemList.UseVisualStyleBackColor = true;
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 519);
            this.Controls.Add(this.btnItemList);
            this.Controls.Add(this.btnItemClose);
            this.Controls.Add(this.btnItemSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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
    }
}