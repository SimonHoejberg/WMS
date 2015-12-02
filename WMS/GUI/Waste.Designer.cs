namespace WMS.GUI
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
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.reasonPanel = new System.Windows.Forms.Panel();
            this.chooseButton = new System.Windows.Forms.Button();
            this.reasonsListBox = new System.Windows.Forms.ListBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.addLineButton = new System.Windows.Forms.Button();
            this.removeRowButton = new System.Windows.Forms.Button();
            this.locationPanel = new System.Windows.Forms.Panel();
            this.chooseLocationButton = new System.Windows.Forms.Button();
            this.locationListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.reasonPanel.SuspendLayout();
            this.locationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(897, 526);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 7;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(816, 526);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 55);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(960, 446);
            this.dataGridView.TabIndex = 4;
            // 
            // reasonPanel
            // 
            this.reasonPanel.Controls.Add(this.chooseButton);
            this.reasonPanel.Controls.Add(this.reasonsListBox);
            this.reasonPanel.Location = new System.Drawing.Point(394, 208);
            this.reasonPanel.Name = "reasonPanel";
            this.reasonPanel.Size = new System.Drawing.Size(200, 142);
            this.reasonPanel.TabIndex = 8;
            this.reasonPanel.Visible = false;
            // 
            // chooseButton
            // 
            this.chooseButton.Location = new System.Drawing.Point(122, 114);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(75, 23);
            this.chooseButton.TabIndex = 1;
            this.chooseButton.UseVisualStyleBackColor = true;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // reasonsListBox
            // 
            this.reasonsListBox.FormattingEnabled = true;
            this.reasonsListBox.Location = new System.Drawing.Point(0, 0);
            this.reasonsListBox.Name = "reasonsListBox";
            this.reasonsListBox.Size = new System.Drawing.Size(200, 108);
            this.reasonsListBox.TabIndex = 0;
            this.reasonsListBox.DoubleClick += new System.EventHandler(this.reasonsListBox_DoubleClick);
            this.reasonsListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.reasonsListBox_KeyDown);
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
            this.searchTextBox.Enter += new System.EventHandler(this.searchTextBox_Enter);
            this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyDown);
            // 
            // addLineButton
            // 
            this.addLineButton.Location = new System.Drawing.Point(118, 21);
            this.addLineButton.Name = "addLineButton";
            this.addLineButton.Size = new System.Drawing.Size(75, 23);
            this.addLineButton.TabIndex = 10;
            this.addLineButton.UseVisualStyleBackColor = true;
            this.addLineButton.Click += new System.EventHandler(this.addRowButton_Click);
            // 
            // removeRowButton
            // 
            this.removeRowButton.Location = new System.Drawing.Point(701, 526);
            this.removeRowButton.Margin = new System.Windows.Forms.Padding(2);
            this.removeRowButton.Name = "removeRowButton";
            this.removeRowButton.Size = new System.Drawing.Size(75, 23);
            this.removeRowButton.TabIndex = 12;
            this.removeRowButton.Text = "Remove Row";
            this.removeRowButton.UseVisualStyleBackColor = true;
            this.removeRowButton.Click += new System.EventHandler(this.removeRowButton_Click);
            // 
            // locationPanel
            // 
            this.locationPanel.Controls.Add(this.chooseLocationButton);
            this.locationPanel.Controls.Add(this.locationListBox);
            this.locationPanel.Location = new System.Drawing.Point(396, 208);
            this.locationPanel.Name = "locationPanel";
            this.locationPanel.Size = new System.Drawing.Size(200, 142);
            this.locationPanel.TabIndex = 2;
            this.locationPanel.Visible = false;
            // 
            // chooseLocationButton
            // 
            this.chooseLocationButton.Location = new System.Drawing.Point(122, 105);
            this.chooseLocationButton.Name = "chooseLocationButton";
            this.chooseLocationButton.Size = new System.Drawing.Size(75, 23);
            this.chooseLocationButton.TabIndex = 1;
            this.chooseLocationButton.UseVisualStyleBackColor = true;
            this.chooseLocationButton.Click += new System.EventHandler(this.chooseLocationButton_Click);
            // 
            // locationListBox
            // 
            this.locationListBox.FormattingEnabled = true;
            this.locationListBox.Location = new System.Drawing.Point(4, 4);
            this.locationListBox.Name = "locationListBox";
            this.locationListBox.Size = new System.Drawing.Size(193, 95);
            this.locationListBox.TabIndex = 0;
            this.locationListBox.DoubleClick += new System.EventHandler(this.locationListBox_DoubleClick);
            this.locationListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.locationListBox_KeyDown);
            // 
            // Waste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.removeRowButton);
            this.Controls.Add(this.addLineButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.locationPanel);
            this.Controls.Add(this.reasonPanel);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Waste";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Waste";
            this.Load += new System.EventHandler(this.Waste_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.reasonPanel.ResumeLayout(false);
            this.locationPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel reasonPanel;
        private System.Windows.Forms.Button chooseButton;
        private System.Windows.Forms.ListBox reasonsListBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button addLineButton;
        private System.Windows.Forms.Button removeRowButton;
        private System.Windows.Forms.Panel locationPanel;
        private System.Windows.Forms.ListBox locationListBox;
        private System.Windows.Forms.Button chooseLocationButton;
    }
}