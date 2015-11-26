﻿namespace WMS.GUI
{
    partial class Log
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
            this.sortButton = new System.Windows.Forms.Button();
            this.viewItemButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.usageLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.itemInfoPanel = new System.Windows.Forms.Panel();
            this.logListBox = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.itemInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(1088, 647);
            this.sortButton.Margin = new System.Windows.Forms.Padding(4);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(100, 28);
            this.sortButton.TabIndex = 5;
            this.sortButton.Text = "Sort";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.SortButtonClick);
            // 
            // viewItemButton
            // 
            this.viewItemButton.Location = new System.Drawing.Point(1196, 647);
            this.viewItemButton.Margin = new System.Windows.Forms.Padding(4);
            this.viewItemButton.Name = "viewItemButton";
            this.viewItemButton.Size = new System.Drawing.Size(100, 28);
            this.viewItemButton.TabIndex = 4;
            this.viewItemButton.Text = "View Item";
            this.viewItemButton.UseVisualStyleBackColor = true;
            this.viewItemButton.Click += new System.EventHandler(this.ViewItemButtonClick);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(16, 37);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1280, 575);
            this.dataGridView.TabIndex = 3;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(119, 59);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 17);
            this.nameLabel.TabIndex = 13;
            this.nameLabel.Text = "Text";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Name:";
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(119, 140);
            this.locationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(35, 17);
            this.locationLabel.TabIndex = 10;
            this.locationLabel.Text = "Text";
            // 
            // usageLabel
            // 
            this.usageLabel.AutoSize = true;
            this.usageLabel.Location = new System.Drawing.Point(119, 172);
            this.usageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usageLabel.Name = "usageLabel";
            this.usageLabel.Size = new System.Drawing.Size(35, 17);
            this.usageLabel.TabIndex = 9;
            this.usageLabel.Text = "Text";
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
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(347, 524);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(100, 28);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButtonClick);
            // 
            // itemInfoPanel
            // 
            this.itemInfoPanel.Controls.Add(this.logListBox);
            this.itemInfoPanel.Controls.Add(this.nameLabel);
            this.itemInfoPanel.Controls.Add(this.label4);
            this.itemInfoPanel.Controls.Add(this.locationLabel);
            this.itemInfoPanel.Controls.Add(this.usageLabel);
            this.itemInfoPanel.Controls.Add(this.label3);
            this.itemInfoPanel.Controls.Add(this.label2);
            this.itemInfoPanel.Controls.Add(this.closeButton);
            this.itemInfoPanel.Location = new System.Drawing.Point(433, 47);
            this.itemInfoPanel.Margin = new System.Windows.Forms.Padding(4);
            this.itemInfoPanel.Name = "itemInfoPanel";
            this.itemInfoPanel.Size = new System.Drawing.Size(451, 556);
            this.itemInfoPanel.TabIndex = 6;
            this.itemInfoPanel.Visible = false;
            // 
            // logListBox
            // 
            this.logListBox.FormattingEnabled = true;
            this.logListBox.ItemHeight = 16;
            this.logListBox.Location = new System.Drawing.Point(4, 236);
            this.logListBox.Margin = new System.Windows.Forms.Padding(4);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(441, 244);
            this.logListBox.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(29, 5);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(188, 22);
            this.textBox1.TabIndex = 7;
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 690);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.itemInfoPanel);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.viewItemButton);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Log";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log";
            this.Load += new System.EventHandler(this.LogLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.itemInfoPanel.ResumeLayout(false);
            this.itemInfoPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.Button viewItemButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Label usageLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel itemInfoPanel;
        private System.Windows.Forms.ListBox logListBox;
        private System.Windows.Forms.TextBox textBox1;
    }
}