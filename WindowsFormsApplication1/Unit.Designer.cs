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
            this.btnUnitClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnitClose.Location = new System.Drawing.Point(144, 188);
            this.btnUnitClose.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnUnitClose.Name = "btnUnitClose";
            this.btnUnitClose.Size = new System.Drawing.Size(120, 31);
            this.btnUnitClose.TabIndex = 5;
            this.btnUnitClose.Text = "Close";
            this.btnUnitClose.UseVisualStyleBackColor = true;
            this.btnUnitClose.Click += new System.EventHandler(this.btnUnitClose_Click);
            // 
            // btnUnitSave
            // 
            this.btnUnitSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnitSave.Location = new System.Drawing.Point(16, 188);
            this.btnUnitSave.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnUnitSave.Name = "btnUnitSave";
            this.btnUnitSave.Size = new System.Drawing.Size(120, 31);
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
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox1.Size = new System.Drawing.Size(631, 167);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Unit Details";
            // 
            // txtUnitDesc
            // 
            this.txtUnitDesc.Location = new System.Drawing.Point(35, 95);
            this.txtUnitDesc.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.txtUnitDesc.Multiline = true;
            this.txtUnitDesc.Name = "txtUnitDesc";
            this.txtUnitDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUnitDesc.Size = new System.Drawing.Size(555, 50);
            this.txtUnitDesc.TabIndex = 5;
            // 
            // txtUnitName
            // 
            this.txtUnitName.Location = new System.Drawing.Point(175, 50);
            this.txtUnitName.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(415, 22);
            this.txtUnitName.TabIndex = 4;
            // 
            // txtUnitId
            // 
            this.txtUnitId.Location = new System.Drawing.Point(35, 50);
            this.txtUnitId.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.txtUnitId.Name = "txtUnitId";
            this.txtUnitId.ReadOnly = true;
            this.txtUnitId.Size = new System.Drawing.Size(132, 22);
            this.txtUnitId.TabIndex = 3;
            this.txtUnitId.TabStop = false;
            this.txtUnitId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Unit Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unit ID";
            // 
            // Unit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 233);
            this.Controls.Add(this.btnUnitClose);
            this.Controls.Add(this.btnUnitSave);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
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