namespace WindowsFormsApplication1
{
    partial class Customer
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCustCurrentBalance = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.txtCustOpeningBal = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCustDesc = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCustFax = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCustMobile = new System.Windows.Forms.TextBox();
            this.txtCustPhone = new System.Windows.Forms.TextBox();
            this.txtCustWebSite = new System.Windows.Forms.TextBox();
            this.txtCustEmail = new System.Windows.Forms.TextBox();
            this.txtCustCountry = new System.Windows.Forms.TextBox();
            this.txtCustZip = new System.Windows.Forms.TextBox();
            this.txtCustState = new System.Windows.Forms.TextBox();
            this.txtCustCity = new System.Windows.Forms.TextBox();
            this.txtCustAdd = new System.Windows.Forms.TextBox();
            this.txtCustCompName = new System.Windows.Forms.TextBox();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.txtCustCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCloseAgain = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNewRecord = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCustCurrentBalance);
            this.groupBox2.Controls.Add(this.textBox16);
            this.groupBox2.Controls.Add(this.txtCustOpeningBal);
            this.groupBox2.Controls.Add(this.textBox14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 386);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(659, 75);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Account Status";
            // 
            // txtCustCurrentBalance
            // 
            this.txtCustCurrentBalance.Location = new System.Drawing.Point(402, 37);
            this.txtCustCurrentBalance.Name = "txtCustCurrentBalance";
            this.txtCustCurrentBalance.ReadOnly = true;
            this.txtCustCurrentBalance.Size = new System.Drawing.Size(219, 21);
            this.txtCustCurrentBalance.TabIndex = 5;
            this.txtCustCurrentBalance.TabStop = false;
            this.txtCustCurrentBalance.Text = "0";
            this.txtCustCurrentBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(348, 37);
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(48, 21);
            this.textBox16.TabIndex = 4;
            this.textBox16.TabStop = false;
            this.textBox16.Text = "Rs.";
            this.textBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustOpeningBal
            // 
            this.txtCustOpeningBal.Location = new System.Drawing.Point(101, 37);
            this.txtCustOpeningBal.Name = "txtCustOpeningBal";
            this.txtCustOpeningBal.Size = new System.Drawing.Size(241, 21);
            this.txtCustOpeningBal.TabIndex = 3;
            this.txtCustOpeningBal.Text = "0";
            this.txtCustOpeningBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustOpeningBal.TextChanged += new System.EventHandler(this.txtCustOpeningBal_TextChanged);
            this.txtCustOpeningBal.Enter += new System.EventHandler(this.txtCustOpeningBal_Enter);
            this.txtCustOpeningBal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustOpeningBal_KeyPress);
            this.txtCustOpeningBal.Leave += new System.EventHandler(this.txtCustOpeningBal_Leave);
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(46, 37);
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(49, 21);
            this.textBox14.TabIndex = 2;
            this.textBox14.TabStop = false;
            this.textBox14.Text = "Rs.";
            this.textBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(345, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 15);
            this.label15.TabIndex = 1;
            this.label15.Text = "Current Balance";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(43, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "Opening Balance";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCustDesc);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtCustFax);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtCustMobile);
            this.groupBox1.Controls.Add(this.txtCustPhone);
            this.groupBox1.Controls.Add(this.txtCustWebSite);
            this.groupBox1.Controls.Add(this.txtCustEmail);
            this.groupBox1.Controls.Add(this.txtCustCountry);
            this.groupBox1.Controls.Add(this.txtCustZip);
            this.groupBox1.Controls.Add(this.txtCustState);
            this.groupBox1.Controls.Add(this.txtCustCity);
            this.groupBox1.Controls.Add(this.txtCustAdd);
            this.groupBox1.Controls.Add(this.txtCustCompName);
            this.groupBox1.Controls.Add(this.txtCustName);
            this.groupBox1.Controls.Add(this.txtCustCode);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(659, 356);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Details";
            // 
            // txtCustDesc
            // 
            this.txtCustDesc.Location = new System.Drawing.Point(46, 299);
            this.txtCustDesc.Multiline = true;
            this.txtCustDesc.Name = "txtCustDesc";
            this.txtCustDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCustDesc.Size = new System.Drawing.Size(575, 46);
            this.txtCustDesc.TabIndex = 27;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(43, 281);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 15);
            this.label16.TabIndex = 26;
            this.label16.Text = "Description";
            // 
            // txtCustFax
            // 
            this.txtCustFax.Location = new System.Drawing.Point(420, 257);
            this.txtCustFax.Name = "txtCustFax";
            this.txtCustFax.Size = new System.Drawing.Size(201, 21);
            this.txtCustFax.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(417, 239);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 15);
            this.label13.TabIndex = 24;
            this.label13.Text = "Fax";
            // 
            // txtCustMobile
            // 
            this.txtCustMobile.Location = new System.Drawing.Point(244, 257);
            this.txtCustMobile.Name = "txtCustMobile";
            this.txtCustMobile.Size = new System.Drawing.Size(170, 21);
            this.txtCustMobile.TabIndex = 23;
            // 
            // txtCustPhone
            // 
            this.txtCustPhone.Location = new System.Drawing.Point(46, 257);
            this.txtCustPhone.Name = "txtCustPhone";
            this.txtCustPhone.Size = new System.Drawing.Size(192, 21);
            this.txtCustPhone.TabIndex = 22;
            // 
            // txtCustWebSite
            // 
            this.txtCustWebSite.Location = new System.Drawing.Point(46, 215);
            this.txtCustWebSite.Name = "txtCustWebSite";
            this.txtCustWebSite.Size = new System.Drawing.Size(575, 21);
            this.txtCustWebSite.TabIndex = 21;
            // 
            // txtCustEmail
            // 
            this.txtCustEmail.Location = new System.Drawing.Point(46, 173);
            this.txtCustEmail.Name = "txtCustEmail";
            this.txtCustEmail.Size = new System.Drawing.Size(575, 21);
            this.txtCustEmail.TabIndex = 20;
            // 
            // txtCustCountry
            // 
            this.txtCustCountry.Location = new System.Drawing.Point(475, 131);
            this.txtCustCountry.Name = "txtCustCountry";
            this.txtCustCountry.Size = new System.Drawing.Size(146, 21);
            this.txtCustCountry.TabIndex = 19;
            // 
            // txtCustZip
            // 
            this.txtCustZip.Location = new System.Drawing.Point(348, 131);
            this.txtCustZip.Name = "txtCustZip";
            this.txtCustZip.Size = new System.Drawing.Size(121, 21);
            this.txtCustZip.TabIndex = 18;
            // 
            // txtCustState
            // 
            this.txtCustState.Location = new System.Drawing.Point(210, 131);
            this.txtCustState.Name = "txtCustState";
            this.txtCustState.Size = new System.Drawing.Size(132, 21);
            this.txtCustState.TabIndex = 17;
            // 
            // txtCustCity
            // 
            this.txtCustCity.Location = new System.Drawing.Point(46, 131);
            this.txtCustCity.Name = "txtCustCity";
            this.txtCustCity.Size = new System.Drawing.Size(158, 21);
            this.txtCustCity.TabIndex = 16;
            // 
            // txtCustAdd
            // 
            this.txtCustAdd.Location = new System.Drawing.Point(46, 80);
            this.txtCustAdd.Multiline = true;
            this.txtCustAdd.Name = "txtCustAdd";
            this.txtCustAdd.Size = new System.Drawing.Size(575, 30);
            this.txtCustAdd.TabIndex = 15;
            // 
            // txtCustCompName
            // 
            this.txtCustCompName.Location = new System.Drawing.Point(362, 38);
            this.txtCustCompName.Name = "txtCustCompName";
            this.txtCustCompName.Size = new System.Drawing.Size(259, 21);
            this.txtCustCompName.TabIndex = 14;
            // 
            // txtCustName
            // 
            this.txtCustName.Location = new System.Drawing.Point(146, 38);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(210, 21);
            this.txtCustName.TabIndex = 13;
            // 
            // txtCustCode
            // 
            this.txtCustCode.Location = new System.Drawing.Point(46, 38);
            this.txtCustCode.Name = "txtCustCode";
            this.txtCustCode.ReadOnly = true;
            this.txtCustCode.Size = new System.Drawing.Size(94, 21);
            this.txtCustCode.TabIndex = 12;
            this.txtCustCode.TabStop = false;
            this.txtCustCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(241, 239);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 15);
            this.label12.TabIndex = 11;
            this.label12.Text = "Mobile";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 239);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 15);
            this.label11.TabIndex = 10;
            this.label11.Text = "Phone";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 197);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Web Site";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "E-Mail Address";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(472, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Country";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(345, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Zip";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(207, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "State";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "City";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(359, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Company Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Customer Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Code";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(20, 479);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 28);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(116, 479);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 28);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnList
            // 
            this.btnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(605, 5);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(66, 28);
            this.btnList.TabIndex = 10;
            this.btnList.Text = "List";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCloseAgain);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnNewRecord);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 519);
            this.panel1.TabIndex = 11;
            // 
            // btnCloseAgain
            // 
            this.btnCloseAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseAgain.Location = new System.Drawing.Point(259, 479);
            this.btnCloseAgain.Name = "btnCloseAgain";
            this.btnCloseAgain.Size = new System.Drawing.Size(90, 28);
            this.btnCloseAgain.TabIndex = 3;
            this.btnCloseAgain.Text = "Close";
            this.btnCloseAgain.UseVisualStyleBackColor = true;
            this.btnCloseAgain.Click += new System.EventHandler(this.btnCloseAgain_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(163, 479);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 28);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnNewRecord
            // 
            this.btnNewRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewRecord.Location = new System.Drawing.Point(20, 479);
            this.btnNewRecord.Name = "btnNewRecord";
            this.btnNewRecord.Size = new System.Drawing.Size(137, 28);
            this.btnNewRecord.TabIndex = 1;
            this.btnNewRecord.Text = "Add New Records";
            this.btnNewRecord.UseVisualStyleBackColor = true;
            this.btnNewRecord.Click += new System.EventHandler(this.btnNewRecord_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(676, 449);
            this.panel2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(672, 445);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 519);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Customer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Details";
            this.Load += new System.EventHandler(this.Customer_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCustCurrentBalance;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox txtCustOpeningBal;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCustDesc;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCustFax;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCustMobile;
        private System.Windows.Forms.TextBox txtCustPhone;
        private System.Windows.Forms.TextBox txtCustWebSite;
        private System.Windows.Forms.TextBox txtCustEmail;
        private System.Windows.Forms.TextBox txtCustCountry;
        private System.Windows.Forms.TextBox txtCustZip;
        private System.Windows.Forms.TextBox txtCustState;
        private System.Windows.Forms.TextBox txtCustCity;
        private System.Windows.Forms.TextBox txtCustAdd;
        private System.Windows.Forms.TextBox txtCustCompName;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.TextBox txtCustCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCloseAgain;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnNewRecord;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}