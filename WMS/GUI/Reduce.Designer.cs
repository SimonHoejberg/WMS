﻿namespace WMS.GUI
{
    partial class Reduce
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
            this.reduceCancelBtn = new System.Windows.Forms.Button();
            this.reduceConfirmBtn = new System.Windows.Forms.Button();
            this.reduceDataGridView = new System.Windows.Forms.DataGridView();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.searchBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.reduceDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // reduceCancelBtn
            // 
            this.reduceCancelBtn.Location = new System.Drawing.Point(816, 528);
            this.reduceCancelBtn.Name = "reduceCancelBtn";
            this.reduceCancelBtn.Size = new System.Drawing.Size(75, 23);
            this.reduceCancelBtn.TabIndex = 7;
            this.reduceCancelBtn.Text = "Cancel";
            this.reduceCancelBtn.UseVisualStyleBackColor = true;
            // 
            // reduceConfirmBtn
            // 
            this.reduceConfirmBtn.Location = new System.Drawing.Point(897, 528);
            this.reduceConfirmBtn.Name = "reduceConfirmBtn";
            this.reduceConfirmBtn.Size = new System.Drawing.Size(75, 23);
            this.reduceConfirmBtn.TabIndex = 6;
            this.reduceConfirmBtn.Text = "Confirm";
            this.reduceConfirmBtn.UseVisualStyleBackColor = true;
            this.reduceConfirmBtn.Click += new System.EventHandler(this.reduceConfirmBtn_Click);
            // 
            // reduceDataGridView
            // 
            this.reduceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reduceDataGridView.Location = new System.Drawing.Point(12, 67);
            this.reduceDataGridView.Name = "reduceDataGridView";
            this.reduceDataGridView.Size = new System.Drawing.Size(960, 455);
            this.reduceDataGridView.TabIndex = 5;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(21, 17);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(225, 21);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.Text = "Search";
            this.comboBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox2_KeyDown);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(251, 17);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(2);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(56, 19);
            this.searchBtn.TabIndex = 9;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // Reduce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.reduceCancelBtn);
            this.Controls.Add(this.reduceConfirmBtn);
            this.Controls.Add(this.reduceDataGridView);
            this.Controls.Add(this.comboBox2);
            this.Name = "Reduce";
            this.Text = "Reduce";
            this.Load += new System.EventHandler(this.Reduce_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reduceDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button reduceCancelBtn;
        private System.Windows.Forms.Button reduceConfirmBtn;
        private System.Windows.Forms.DataGridView reduceDataGridView;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button searchBtn;
    }
}