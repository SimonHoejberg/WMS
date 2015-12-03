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
            this.itemNoLabel = new System.Windows.Forms.Label();
            this.logListView = new System.Windows.Forms.ListView();
            this.itemNoLabelHead = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.itemInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewItemButton
            // 
            this.viewItemButton.Location = new System.Drawing.Point(897, 526);
            this.viewItemButton.Name = "viewItemButton";
            this.viewItemButton.Size = new System.Drawing.Size(75, 23);
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
            this.dataGridView.Location = new System.Drawing.Point(12, 30);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(960, 467);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCellDoubleClick);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(129, 48);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(28, 13);
            this.nameLabel.TabIndex = 13;
            this.nameLabel.Text = "Text";
            // 
            // nameLabelHead
            // 
            this.nameLabelHead.AutoSize = true;
            this.nameLabelHead.Location = new System.Drawing.Point(16, 48);
            this.nameLabelHead.Name = "nameLabelHead";
            this.nameLabelHead.Size = new System.Drawing.Size(38, 13);
            this.nameLabelHead.TabIndex = 12;
            this.nameLabelHead.Text = "Name:";
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(129, 92);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(28, 13);
            this.locationLabel.TabIndex = 10;
            this.locationLabel.Text = "Text";
            // 
            // usageLabel
            // 
            this.usageLabel.AutoSize = true;
            this.usageLabel.Location = new System.Drawing.Point(129, 71);
            this.usageLabel.Name = "usageLabel";
            this.usageLabel.Size = new System.Drawing.Size(28, 13);
            this.usageLabel.TabIndex = 9;
            this.usageLabel.Text = "Text";
            // 
            // usageLabelHead
            // 
            this.usageLabelHead.AutoSize = true;
            this.usageLabelHead.Location = new System.Drawing.Point(16, 71);
            this.usageLabelHead.Name = "usageLabelHead";
            this.usageLabelHead.Size = new System.Drawing.Size(41, 13);
            this.usageLabelHead.TabIndex = 8;
            this.usageLabelHead.Text = "Usage:";
            // 
            // locationLabelHead
            // 
            this.locationLabelHead.AutoSize = true;
            this.locationLabelHead.Location = new System.Drawing.Point(16, 92);
            this.locationLabelHead.Name = "locationLabelHead";
            this.locationLabelHead.Size = new System.Drawing.Size(51, 13);
            this.locationLabelHead.TabIndex = 7;
            this.locationLabelHead.Text = "Location:";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(260, 426);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
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
            this.itemInfoPanel.Location = new System.Drawing.Point(325, 38);
            this.itemInfoPanel.Name = "itemInfoPanel";
            this.itemInfoPanel.Size = new System.Drawing.Size(338, 452);
            this.itemInfoPanel.TabIndex = 6;
            this.itemInfoPanel.Visible = false;
            // 
            // itemNoLabel
            // 
            this.itemNoLabel.AutoSize = true;
            this.itemNoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.itemNoLabel.Location = new System.Drawing.Point(128, 20);
            this.itemNoLabel.Name = "itemNoLabel";
            this.itemNoLabel.Size = new System.Drawing.Size(35, 17);
            this.itemNoLabel.TabIndex = 18;
            this.itemNoLabel.Text = "Text";
            // 
            // logListView
            // 
            this.logListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.logListView.Location = new System.Drawing.Point(8, 202);
            this.logListView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.logListView.MultiSelect = false;
            this.logListView.Name = "logListView";
            this.logListView.Size = new System.Drawing.Size(316, 218);
            this.logListView.TabIndex = 15;
            this.logListView.UseCompatibleStateImageBehavior = false;
            // 
            // itemNoLabelHead
            // 
            this.itemNoLabelHead.AutoSize = true;
            this.itemNoLabelHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemNoLabelHead.Location = new System.Drawing.Point(15, 20);
            this.itemNoLabelHead.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.itemNoLabelHead.Name = "itemNoLabelHead";
            this.itemNoLabelHead.Size = new System.Drawing.Size(60, 17);
            this.itemNoLabelHead.TabIndex = 17;
            this.itemNoLabelHead.Text = "Item No.";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(22, 4);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(142, 20);
            this.SearchTextBox.TabIndex = 7;
            this.SearchTextBox.Enter += new System.EventHandler(this.SearchTextBoxEnter);
            this.SearchTextBox.Leave += new System.EventHandler(this.SearchTextBoxLeave);
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.itemInfoPanel);
            this.Controls.Add(this.viewItemButton);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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