﻿namespace WindowsFormsApplication1
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTexId = new System.Windows.Forms.Label();
            this.lblTexName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTexId = new System.Windows.Forms.TextBox();
            this.txtTexName = new System.Windows.Forms.TextBox();
            this.txtTexAmount = new System.Windows.Forms.TextBox();
            this.txtGroupDesc = new System.Windows.Forms.TextBox();
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 187);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TexDetail";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(29, 211);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(150, 211);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 34);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTexId
            // 
            this.lblTexId.AutoSize = true;
            this.lblTexId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTexId.Location = new System.Drawing.Point(17, 33);
            this.lblTexId.Name = "lblTexId";
            this.lblTexId.Size = new System.Drawing.Size(42, 15);
            this.lblTexId.TabIndex = 0;
            this.lblTexId.Text = "Tex ID";
            // 
            // lblTexName
            // 
            this.lblTexName.AutoSize = true;
            this.lblTexName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTexName.Location = new System.Drawing.Point(149, 33);
            this.lblTexName.Name = "lblTexName";
            this.lblTexName.Size = new System.Drawing.Size(64, 15);
            this.lblTexName.TabIndex = 1;
            this.lblTexName.Text = "Tex Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(331, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tex Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Description";
            // 
            // txtTexId
            // 
            this.txtTexId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexId.Location = new System.Drawing.Point(8, 61);
            this.txtTexId.Name = "txtTexId";
            this.txtTexId.Size = new System.Drawing.Size(78, 22);
            this.txtTexId.TabIndex = 4;
            // 
            // txtTexName
            // 
            this.txtTexName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexName.Location = new System.Drawing.Point(109, 61);
            this.txtTexName.Name = "txtTexName";
            this.txtTexName.Size = new System.Drawing.Size(159, 22);
            this.txtTexName.TabIndex = 5;
            // 
            // txtTexAmount
            // 
            this.txtTexAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexAmount.Location = new System.Drawing.Point(302, 61);
            this.txtTexAmount.Name = "txtTexAmount";
            this.txtTexAmount.Size = new System.Drawing.Size(129, 22);
            this.txtTexAmount.TabIndex = 6;
            // 
            // txtGroupDesc
            // 
            this.txtGroupDesc.Location = new System.Drawing.Point(8, 127);
            this.txtGroupDesc.Multiline = true;
            this.txtGroupDesc.Name = "txtGroupDesc";
            this.txtGroupDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGroupDesc.Size = new System.Drawing.Size(428, 47);
            this.txtGroupDesc.TabIndex = 8;
            // 
            // Tex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 262);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Name = "Tex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TexDetail";
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