namespace WindowsFormsApplication1
{
    partial class Tex
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
            this.txtGroupDesc = new System.Windows.Forms.TextBox();
            this.txtTexAmount = new System.Windows.Forms.TextBox();
            this.txtTexName = new System.Windows.Forms.TextBox();
            this.txtTexId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTexName = new System.Windows.Forms.Label();
            this.lblTexId = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGroupDesc);
            this.groupBox1.Controls.Add(this.txtTexAmount);
            this.groupBox1.Controls.Add(this.txtTexName);
            this.groupBox1.Controls.Add(this.txtTexId);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblTexName);
            this.groupBox1.Controls.Add(this.lblTexId);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(753, 169);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tax Details";
            // 
            // txtGroupDesc
            // 
            this.txtGroupDesc.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroupDesc.Location = new System.Drawing.Point(33, 96);
            this.txtGroupDesc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtGroupDesc.Multiline = true;
            this.txtGroupDesc.Name = "txtGroupDesc";
            this.txtGroupDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGroupDesc.Size = new System.Drawing.Size(681, 50);
            this.txtGroupDesc.TabIndex = 8;
            // 
            // txtTexAmount
            // 
            this.txtTexAmount.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexAmount.Location = new System.Drawing.Point(469, 50);
            this.txtTexAmount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTexAmount.Name = "txtTexAmount";
            this.txtTexAmount.Size = new System.Drawing.Size(243, 22);
            this.txtTexAmount.TabIndex = 6;
            this.txtTexAmount.Text = "0";
            this.txtTexAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTexAmount.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtTexAmount_MouseClick);
            this.txtTexAmount.Leave += new System.EventHandler(this.txtTexAmount_Leave);
            // 
            // txtTexName
            // 
            this.txtTexName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexName.Location = new System.Drawing.Point(172, 50);
            this.txtTexName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTexName.Name = "txtTexName";
            this.txtTexName.Size = new System.Drawing.Size(289, 22);
            this.txtTexName.TabIndex = 5;
            // 
            // txtTexId
            // 
            this.txtTexId.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexId.Location = new System.Drawing.Point(33, 50);
            this.txtTexId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTexId.Name = "txtTexId";
            this.txtTexId.ReadOnly = true;
            this.txtTexId.Size = new System.Drawing.Size(131, 22);
            this.txtTexId.TabIndex = 4;
            this.txtTexId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(466, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tax Amount (In %)";
            // 
            // lblTexName
            // 
            this.lblTexName.AutoSize = true;
            this.lblTexName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTexName.Location = new System.Drawing.Point(169, 30);
            this.lblTexName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTexName.Name = "lblTexName";
            this.lblTexName.Size = new System.Drawing.Size(68, 14);
            this.lblTexName.TabIndex = 1;
            this.lblTexName.Text = "Tax Name";
            // 
            // lblTexId
            // 
            this.lblTexId.AutoSize = true;
            this.lblTexId.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTexId.Location = new System.Drawing.Point(29, 30);
            this.lblTexId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTexId.Name = "lblTexId";
            this.lblTexId.Size = new System.Drawing.Size(46, 14);
            this.lblTexId.TabIndex = 0;
            this.lblTexId.Text = "Tex ID";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(16, 190);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 31);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(144, 190);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 31);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Tex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 239);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Tex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tax Details";
            this.Load += new System.EventHandler(this.Tex_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTexName;
        private System.Windows.Forms.Label lblTexId;
        private System.Windows.Forms.TextBox txtTexAmount;
        private System.Windows.Forms.TextBox txtTexName;
        private System.Windows.Forms.TextBox txtTexId;
        private System.Windows.Forms.TextBox txtGroupDesc;

    }
}