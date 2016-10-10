namespace WindowsFormsApplication1
{
    partial class Unit
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
            this.btnUnitClose = new System.Windows.Forms.Button();
            this.btnUnitSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUnitDesc = new System.Windows.Forms.TextBox();
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.txtUnitId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUnitClose
            // 
            this.btnUnitClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnitClose.Location = new System.Drawing.Point(116, 185);
            this.btnUnitClose.Name = "btnUnitClose";
            this.btnUnitClose.Size = new System.Drawing.Size(90, 28);
            this.btnUnitClose.TabIndex = 5;
            this.btnUnitClose.Text = "Close";
            this.btnUnitClose.UseVisualStyleBackColor = true;
            this.btnUnitClose.Click += new System.EventHandler(this.btnUnitClose_Click);
            // 
            // btnUnitSave
            // 
            this.btnUnitSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnitSave.Location = new System.Drawing.Point(20, 185);
            this.btnUnitSave.Name = "btnUnitSave";
            this.btnUnitSave.Size = new System.Drawing.Size(90, 28);
            this.btnUnitSave.TabIndex = 4;
            this.btnUnitSave.Text = "Save";
            this.btnUnitSave.UseVisualStyleBackColor = true;
            this.btnUnitSave.Click += new System.EventHandler(this.btnUnitSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUnitDesc);
            this.groupBox1.Controls.Add(this.txtUnitName);
            this.groupBox1.Controls.Add(this.txtUnitId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 155);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unit Details";
            // 
            // txtUnitDesc
            // 
            this.txtUnitDesc.Location = new System.Drawing.Point(26, 88);
            this.txtUnitDesc.Multiline = true;
            this.txtUnitDesc.Name = "txtUnitDesc";
            this.txtUnitDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUnitDesc.Size = new System.Drawing.Size(428, 47);
            this.txtUnitDesc.TabIndex = 5;
            // 
            // txtUnitName
            // 
            this.txtUnitName.Location = new System.Drawing.Point(132, 46);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(322, 21);
            this.txtUnitName.TabIndex = 4;
            // 
            // txtUnitId
            // 
            this.txtUnitId.Location = new System.Drawing.Point(26, 46);
            this.txtUnitId.Name = "txtUnitId";
            this.txtUnitId.ReadOnly = true;
            this.txtUnitId.Size = new System.Drawing.Size(100, 21);
            this.txtUnitId.TabIndex = 3;
            this.txtUnitId.TabStop = false;
            this.txtUnitId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Unit Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unit ID";
            // 
            // Unit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 226);
            this.Controls.Add(this.btnUnitClose);
            this.Controls.Add(this.btnUnitSave);
            this.Controls.Add(this.groupBox1);
            this.Name = "Unit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unit Details";
            this.Load += new System.EventHandler(this.Unit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUnitClose;
        private System.Windows.Forms.Button btnUnitSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUnitDesc;
        private System.Windows.Forms.TextBox txtUnitName;
        private System.Windows.Forms.TextBox txtUnitId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}