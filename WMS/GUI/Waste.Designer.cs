﻿namespace WMS.GUI
{
    partial class Waste
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
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.wasteDataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chooseButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.addLineButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.wasteDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(897, 526);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 7;
            this.button11.Text = "Confirm";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(816, 526);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 6;
            this.button10.Text = "Cancel";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // wasteDataGridView
            // 
            this.wasteDataGridView.AllowUserToAddRows = false;
            this.wasteDataGridView.AllowUserToResizeColumns = false;
            this.wasteDataGridView.AllowUserToResizeRows = false;
            this.wasteDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wasteDataGridView.Location = new System.Drawing.Point(12, 55);
            this.wasteDataGridView.Name = "wasteDataGridView";
            this.wasteDataGridView.Size = new System.Drawing.Size(960, 446);
            this.wasteDataGridView.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chooseButton);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Location = new System.Drawing.Point(394, 208);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 142);
            this.panel1.TabIndex = 8;
            this.panel1.Visible = false;
            // 
            // chooseButton
            // 
            this.chooseButton.Location = new System.Drawing.Point(122, 114);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(75, 23);
            this.chooseButton.TabIndex = 1;
            this.chooseButton.Text = "Choose";
            this.chooseButton.UseVisualStyleBackColor = true;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(200, 108);
            this.listBox1.TabIndex = 0;
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown_1);
            // 
            // searchTextBox
            // 
            this.searchTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.searchTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.searchTextBox.Location = new System.Drawing.Point(12, 23);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(100, 20);
            this.searchTextBox.TabIndex = 9;
            this.searchTextBox.Text = "Item No";
            this.searchTextBox.Enter += new System.EventHandler(this.textBox1_Enter);
            this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.searchTextBox.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // addLineButton
            // 
            this.addLineButton.Location = new System.Drawing.Point(118, 21);
            this.addLineButton.Name = "addLineButton";
            this.addLineButton.Size = new System.Drawing.Size(75, 23);
            this.addLineButton.TabIndex = 10;
            this.addLineButton.UseVisualStyleBackColor = true;
            this.addLineButton.Click += new System.EventHandler(this.addLineButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(701, 526);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Waste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.addLineButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.wasteDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Waste";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Waste";
            this.Load += new System.EventHandler(this.Waste_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wasteDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.DataGridView wasteDataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button chooseButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button addLineButton;
        private System.Windows.Forms.Button button3;
    }
}