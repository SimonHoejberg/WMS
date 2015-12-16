namespace WMS.GUI
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.removeLineButton = new System.Windows.Forms.Button();
            this.locationPanel = new System.Windows.Forms.Panel();
            this.chooseLocationButton = new System.Windows.Forms.Button();
            this.locationListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.locationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(816, 528);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(897, 528);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmBtn.TabIndex = 6;
            this.confirmBtn.Text = "Confirm";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.ConfirmButtonClick);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 57);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(960, 465);
            this.dataGridView.TabIndex = 5;
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCellValueChanged);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(117, 26);
            this.searchButton.Margin = new System.Windows.Forms.Padding(2);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 9;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButtonClick);
            // 
            // searchTextBox
            // 
            this.searchTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.searchTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.searchTextBox.Location = new System.Drawing.Point(12, 27);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(100, 20);
            this.searchTextBox.TabIndex = 10;
            this.searchTextBox.Enter += new System.EventHandler(this.SearchTextBoxEnter);
            this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchTextBoxKeyDown);
            // 
            // removeLineButton
            // 
            this.removeLineButton.Location = new System.Drawing.Point(707, 528);
            this.removeLineButton.Margin = new System.Windows.Forms.Padding(2);
            this.removeLineButton.Name = "removeLineButton";
            this.removeLineButton.Size = new System.Drawing.Size(75, 23);
            this.removeLineButton.TabIndex = 11;
            this.removeLineButton.Text = "Remove row";
            this.removeLineButton.UseVisualStyleBackColor = true;
            this.removeLineButton.Click += new System.EventHandler(this.RemoveLineButtonClick);
            // 
            // locationPanel
            // 
            this.locationPanel.Controls.Add(this.chooseLocationButton);
            this.locationPanel.Controls.Add(this.locationListBox);
            this.locationPanel.Location = new System.Drawing.Point(356, 182);
            this.locationPanel.Name = "locationPanel";
            this.locationPanel.Size = new System.Drawing.Size(200, 132);
            this.locationPanel.TabIndex = 12;
            this.locationPanel.Visible = false;
            // 
            // chooseLocationButton
            // 
            this.chooseLocationButton.Location = new System.Drawing.Point(122, 101);
            this.chooseLocationButton.Name = "chooseLocationButton";
            this.chooseLocationButton.Size = new System.Drawing.Size(75, 23);
            this.chooseLocationButton.TabIndex = 1;
            this.chooseLocationButton.Text = "Choose";
            this.chooseLocationButton.UseVisualStyleBackColor = true;
            this.chooseLocationButton.Click += new System.EventHandler(this.ChooseLocationButtonClick);
            // 
            // locationListBox
            // 
            this.locationListBox.FormattingEnabled = true;
            this.locationListBox.Location = new System.Drawing.Point(0, 0);
            this.locationListBox.Name = "locationListBox";
            this.locationListBox.Size = new System.Drawing.Size(200, 95);
            this.locationListBox.TabIndex = 0;
            this.locationListBox.DoubleClick += new System.EventHandler(this.LocationListBoxDoubleClick);
            this.locationListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LocationListBoxKeyDown);
            // 
            // Reduce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.locationPanel);
            this.Controls.Add(this.removeLineButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Reduce";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reduce";
            this.Load += new System.EventHandler(this.ReduceLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.locationPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button removeLineButton;
        private System.Windows.Forms.Panel locationPanel;
        private System.Windows.Forms.ListBox locationListBox;
        private System.Windows.Forms.Button chooseLocationButton;
    }
}