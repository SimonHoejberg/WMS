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
            this.reduceCancelBtn = new System.Windows.Forms.Button();
            this.reduceConfirmBtn = new System.Windows.Forms.Button();
            this.reduceDataGridView = new System.Windows.Forms.DataGridView();
            this.searchBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.locationPanel = new System.Windows.Forms.Panel();
            this.chooseLocationButton = new System.Windows.Forms.Button();
            this.locationListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.reduceDataGridView)).BeginInit();
            this.locationPanel.SuspendLayout();
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
            this.reduceCancelBtn.Click += new System.EventHandler(this.reduceCancelBtn_Click);
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
            this.reduceDataGridView.AllowUserToAddRows = false;
            this.reduceDataGridView.AllowUserToResizeColumns = false;
            this.reduceDataGridView.AllowUserToResizeRows = false;
            this.reduceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reduceDataGridView.Location = new System.Drawing.Point(12, 57);
            this.reduceDataGridView.Name = "reduceDataGridView";
            this.reduceDataGridView.Size = new System.Drawing.Size(960, 465);
            this.reduceDataGridView.TabIndex = 5;
            this.reduceDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.reduceDataGridView_CellValueChanged);
            this.reduceDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.reduceDataGridView_RowsAdded);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(117, 26);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(2);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 9;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox1.Location = new System.Drawing.Point(12, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(707, 528);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.chooseLocationButton.Click += new System.EventHandler(this.chooseLocationButton_Click);
            // 
            // locationListBox
            // 
            this.locationListBox.FormattingEnabled = true;
            this.locationListBox.Location = new System.Drawing.Point(0, 0);
            this.locationListBox.Name = "locationListBox";
            this.locationListBox.Size = new System.Drawing.Size(200, 95);
            this.locationListBox.TabIndex = 0;
            this.locationListBox.DoubleClick += new System.EventHandler(this.locationListBox_DoubleClick);
            this.locationListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.locationListBox_KeyDown);
            // 
            // Reduce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.locationPanel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.reduceCancelBtn);
            this.Controls.Add(this.reduceConfirmBtn);
            this.Controls.Add(this.reduceDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Reduce";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reduce";
            this.Load += new System.EventHandler(this.Reduce_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reduceDataGridView)).EndInit();
            this.locationPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button reduceCancelBtn;
        private System.Windows.Forms.Button reduceConfirmBtn;
        private System.Windows.Forms.DataGridView reduceDataGridView;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel locationPanel;
        private System.Windows.Forms.ListBox locationListBox;
        private System.Windows.Forms.Button chooseLocationButton;
    }
}