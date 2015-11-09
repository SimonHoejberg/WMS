﻿namespace WMS.GUI
{
    partial class Information
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
            this.viewItemBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.itemInfoPnl = new System.Windows.Forms.Panel();
            this.nameLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sizeLbl = new System.Windows.Forms.Label();
            this.locationLbl = new System.Windows.Forms.Label();
            this.usageLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.logBtn = new System.Windows.Forms.Button();
            this.logLstBox = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.itemInfoPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewItemBtn
            // 
            this.viewItemBtn.Location = new System.Drawing.Point(1196, 647);
            this.viewItemBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.viewItemBtn.Name = "viewItemBtn";
            this.viewItemBtn.Size = new System.Drawing.Size(100, 28);
            this.viewItemBtn.TabIndex = 3;
            this.viewItemBtn.Text = "View Item";
            this.viewItemBtn.UseVisualStyleBackColor = true;
            this.viewItemBtn.Click += new System.EventHandler(this.viewItemBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 39);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1280, 572);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // itemInfoPnl
            // 
            this.itemInfoPnl.Controls.Add(this.nameLbl);
            this.itemInfoPnl.Controls.Add(this.label4);
            this.itemInfoPnl.Controls.Add(this.sizeLbl);
            this.itemInfoPnl.Controls.Add(this.locationLbl);
            this.itemInfoPnl.Controls.Add(this.usageLbl);
            this.itemInfoPnl.Controls.Add(this.label3);
            this.itemInfoPnl.Controls.Add(this.label2);
            this.itemInfoPnl.Controls.Add(this.label1);
            this.itemInfoPnl.Controls.Add(this.closeBtn);
            this.itemInfoPnl.Controls.Add(this.logBtn);
            this.itemInfoPnl.Controls.Add(this.logLstBox);
            this.itemInfoPnl.Location = new System.Drawing.Point(411, 47);
            this.itemInfoPnl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.itemInfoPnl.Name = "itemInfoPnl";
            this.itemInfoPnl.Size = new System.Drawing.Size(451, 556);
            this.itemInfoPnl.TabIndex = 4;
            this.itemInfoPnl.Visible = false;
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(123, 59);
            this.nameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(0, 17);
            this.nameLbl.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Name:";
            // 
            // sizeLbl
            // 
            this.sizeLbl.AutoSize = true;
            this.sizeLbl.Location = new System.Drawing.Point(119, 108);
            this.sizeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sizeLbl.Name = "sizeLbl";
            this.sizeLbl.Size = new System.Drawing.Size(0, 17);
            this.sizeLbl.TabIndex = 11;
            // 
            // locationLbl
            // 
            this.locationLbl.AutoSize = true;
            this.locationLbl.Location = new System.Drawing.Point(119, 140);
            this.locationLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.locationLbl.Name = "locationLbl";
            this.locationLbl.Size = new System.Drawing.Size(0, 17);
            this.locationLbl.TabIndex = 10;
            // 
            // usageLbl
            // 
            this.usageLbl.AutoSize = true;
            this.usageLbl.Location = new System.Drawing.Point(119, 172);
            this.usageLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usageLbl.Name = "usageLbl";
            this.usageLbl.Size = new System.Drawing.Size(0, 17);
            this.usageLbl.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 172);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Usage:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Location:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Size:";
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(193, 524);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(100, 28);
            this.closeBtn.TabIndex = 5;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // logBtn
            // 
            this.logBtn.Location = new System.Drawing.Point(331, 524);
            this.logBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logBtn.Name = "logBtn";
            this.logBtn.Size = new System.Drawing.Size(100, 28);
            this.logBtn.TabIndex = 4;
            this.logBtn.Text = "Log";
            this.logBtn.UseVisualStyleBackColor = true;
            this.logBtn.Click += new System.EventHandler(this.logBtn_Click);
            // 
            // logLstBox
            // 
            this.logLstBox.FormattingEnabled = true;
            this.logLstBox.ItemHeight = 16;
            this.logLstBox.Location = new System.Drawing.Point(4, 233);
            this.logLstBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logLstBox.Name = "logLstBox";
            this.logLstBox.Size = new System.Drawing.Size(441, 244);
            this.logLstBox.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(953, 166);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 9;
            // 
            // Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 690);
            this.Controls.Add(this.itemInfoPnl);
            this.Controls.Add(this.viewItemBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Information";
            this.Text = "Information";
            this.Load += new System.EventHandler(this.Information_Load);
            this.Enter += new System.EventHandler(this.Information_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.itemInfoPnl.ResumeLayout(false);
            this.itemInfoPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button viewItemBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel itemInfoPnl;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button logBtn;
        private System.Windows.Forms.ListBox logLstBox;
        private System.Windows.Forms.Label sizeLbl;
        private System.Windows.Forms.Label locationLbl;
        private System.Windows.Forms.Label usageLbl;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Label label4;
    }
}