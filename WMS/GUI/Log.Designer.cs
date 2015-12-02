namespace WMS.GUI
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
            this.viewItemButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameLabelHead = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.usageLabel = new System.Windows.Forms.Label();
            this.usageLabelHead = new System.Windows.Forms.Label();
            this.locationLabelHead = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.itemInfoPanel = new System.Windows.Forms.Panel();
            this.logListView = new System.Windows.Forms.ListView();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.itemNoLabel = new System.Windows.Forms.Label();
            this.itemNoLabelHead = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.itemInfoPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.nameLabel.Location = new System.Drawing.Point(172, 59);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 17);
            this.nameLabel.TabIndex = 13;
            this.nameLabel.Text = "Text";
            // 
            // label4
            // 
            this.nameLabelHead.AutoSize = true;
            this.nameLabelHead.Location = new System.Drawing.Point(21, 59);
            this.nameLabelHead.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabelHead.Name = "label4";
            this.nameLabelHead.Size = new System.Drawing.Size(49, 17);
            this.nameLabelHead.TabIndex = 12;
            this.nameLabelHead.Text = "Name:";
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(172, 113);
            this.locationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(35, 17);
            this.locationLabel.TabIndex = 10;
            this.locationLabel.Text = "Text";
            // 
            // usageLabel
            // 
            this.usageLabel.AutoSize = true;
            this.usageLabel.Location = new System.Drawing.Point(172, 87);
            this.usageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usageLabel.Name = "usageLabel";
            this.usageLabel.Size = new System.Drawing.Size(35, 17);
            this.usageLabel.TabIndex = 9;
            this.usageLabel.Text = "Text";
            // 
            // label3
            // 
            this.usageLabelHead.AutoSize = true;
            this.usageLabelHead.Location = new System.Drawing.Point(21, 87);
            this.usageLabelHead.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usageLabelHead.Name = "label3";
            this.usageLabelHead.Size = new System.Drawing.Size(53, 17);
            this.usageLabelHead.TabIndex = 8;
            this.usageLabelHead.Text = "Usage:";
            // 
            // label2
            // 
            this.locationLabelHead.AutoSize = true;
            this.locationLabelHead.Location = new System.Drawing.Point(21, 113);
            this.locationLabelHead.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.locationLabelHead.Name = "label2";
            this.locationLabelHead.Size = new System.Drawing.Size(66, 17);
            this.locationLabelHead.TabIndex = 7;
            this.locationLabelHead.Text = "Location:";
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
            this.itemInfoPanel.Controls.Add(this.itemNoLabel);
            this.itemInfoPanel.Controls.Add(this.logListView);
            this.itemInfoPanel.Controls.Add(this.itemNoLabelHead);
            this.itemInfoPanel.Controls.Add(this.nameLabel);
            this.itemInfoPanel.Controls.Add(this.nameLabelHead);
            this.itemInfoPanel.Controls.Add(this.locationLabel);
            this.itemInfoPanel.Controls.Add(this.usageLabel);
            this.itemInfoPanel.Controls.Add(this.usageLabelHead);
            this.itemInfoPanel.Controls.Add(this.locationLabelHead);
            this.itemInfoPanel.Controls.Add(this.closeButton);
            this.itemInfoPanel.Location = new System.Drawing.Point(433, 47);
            this.itemInfoPanel.Margin = new System.Windows.Forms.Padding(4);
            this.itemInfoPanel.Name = "itemInfoPanel";
            this.itemInfoPanel.Size = new System.Drawing.Size(451, 556);
            this.itemInfoPanel.TabIndex = 6;
            this.itemInfoPanel.Visible = false;
            // 
            // logListView
            // 
            this.logListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.logListView.Location = new System.Drawing.Point(11, 249);
            this.logListView.MultiSelect = false;
            this.logListView.Name = "logListView";
            this.logListView.Size = new System.Drawing.Size(420, 268);
            this.logListView.TabIndex = 15;
            this.logListView.UseCompatibleStateImageBehavior = false;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(29, 5);
            this.SearchTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(188, 22);
            this.SearchTextBox.TabIndex = 7;
            this.SearchTextBox.Enter += new System.EventHandler(this.SearchTextBoxEnter);
            this.SearchTextBox.Leave += new System.EventHandler(this.SearchTextBoxLeave);
            // 
            // itemNoLabel
            // 
            this.itemNoLabel.AutoSize = true;
            this.itemNoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.itemNoLabel.Location = new System.Drawing.Point(171, 25);
            this.itemNoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.itemNoLabel.Name = "itemNoLabel";
            this.itemNoLabel.Size = new System.Drawing.Size(41, 20);
            this.itemNoLabel.TabIndex = 18;
            this.itemNoLabel.Text = "Text";
            // 
            // itemNoLabelHead
            // 
            this.itemNoLabelHead.AutoSize = true;
            this.itemNoLabelHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemNoLabelHead.Location = new System.Drawing.Point(20, 25);
            this.itemNoLabelHead.Name = "itemNoLabelHead";
            this.itemNoLabelHead.Size = new System.Drawing.Size(71, 20);
            this.itemNoLabelHead.TabIndex = 17;
            this.itemNoLabelHead.Text = "Item No.";
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 690);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.itemInfoPanel);
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
        private System.Windows.Forms.Button viewItemButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label nameLabelHead;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Label usageLabel;
        private System.Windows.Forms.Label usageLabelHead;
        private System.Windows.Forms.Label locationLabelHead;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel itemInfoPanel;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.ListView logListView;
        private System.Windows.Forms.Label itemNoLabel;
        private System.Windows.Forms.Label itemNoLabelHead;
    }
}