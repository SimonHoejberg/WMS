namespace WMS.GUI
{
    partial class Move
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
            this.moveCancelButton = new System.Windows.Forms.Button();
            this.moveConfirmButton = new System.Windows.Forms.Button();
            this.moveDataGridView = new System.Windows.Forms.DataGridView();
            this.moveAddItemTextBox = new System.Windows.Forms.TextBox();
            this.moveAddItemButton = new System.Windows.Forms.Button();
            this.moveSearchLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.moveDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // moveCancelButton
            // 
            this.moveCancelButton.Location = new System.Drawing.Point(1088, 647);
            this.moveCancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.moveCancelButton.Name = "moveCancelButton";
            this.moveCancelButton.Size = new System.Drawing.Size(100, 28);
            this.moveCancelButton.TabIndex = 7;
            this.moveCancelButton.Text = "Cancel";
            this.moveCancelButton.UseVisualStyleBackColor = true;
            this.moveCancelButton.Click += new System.EventHandler(this.moveCancelButton_Click);
            // 
            // moveConfirmButton
            // 
            this.moveConfirmButton.Location = new System.Drawing.Point(1196, 647);
            this.moveConfirmButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.moveConfirmButton.Name = "moveConfirmButton";
            this.moveConfirmButton.Size = new System.Drawing.Size(100, 28);
            this.moveConfirmButton.TabIndex = 5;
            this.moveConfirmButton.Text = "Confirm";
            this.moveConfirmButton.UseVisualStyleBackColor = true;
            this.moveConfirmButton.Click += new System.EventHandler(this.MoveConfirmButtonClick);
            // 
            // moveDataGridView
            // 
            this.moveDataGridView.AllowUserToResizeColumns = false;
            this.moveDataGridView.AllowUserToResizeRows = false;
            this.moveDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.moveDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.moveDataGridView.Location = new System.Drawing.Point(16, 65);
            this.moveDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.moveDataGridView.Name = "moveDataGridView";
            this.moveDataGridView.Size = new System.Drawing.Size(1280, 544);
            this.moveDataGridView.TabIndex = 4;
            this.moveDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.moveDataGridViewCellValueChanged);
            // 
            // moveAddItemTextBox
            // 
            this.moveAddItemTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.moveAddItemTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.moveAddItemTextBox.Location = new System.Drawing.Point(16, 15);
            this.moveAddItemTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.moveAddItemTextBox.Name = "moveAddItemTextBox";
            this.moveAddItemTextBox.Size = new System.Drawing.Size(360, 22);
            this.moveAddItemTextBox.TabIndex = 8;
            this.moveAddItemTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.moveAddItemTextBox_KeyUp);
            // 
            // moveAddItemButton
            // 
            this.moveAddItemButton.Location = new System.Drawing.Point(385, 15);
            this.moveAddItemButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.moveAddItemButton.Name = "moveAddItemButton";
            this.moveAddItemButton.Size = new System.Drawing.Size(100, 28);
            this.moveAddItemButton.TabIndex = 9;
            this.moveAddItemButton.Text = "Add";
            this.moveAddItemButton.UseVisualStyleBackColor = true;
            this.moveAddItemButton.Click += new System.EventHandler(this.moveAddItemButton_Click);
            // 
            // moveSearchLabel
            // 
            this.moveSearchLabel.AutoSize = true;
            this.moveSearchLabel.ForeColor = System.Drawing.Color.Red;
            this.moveSearchLabel.Location = new System.Drawing.Point(16, 43);
            this.moveSearchLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.moveSearchLabel.Name = "moveSearchLabel";
            this.moveSearchLabel.Size = new System.Drawing.Size(116, 17);
            this.moveSearchLabel.TabIndex = 10;
            this.moveSearchLabel.Text = "Item doesn\'t exist";
            this.moveSearchLabel.Visible = false;
            // 
            // Move
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 690);
            this.Controls.Add(this.moveSearchLabel);
            this.Controls.Add(this.moveAddItemButton);
            this.Controls.Add(this.moveAddItemTextBox);
            this.Controls.Add(this.moveCancelButton);
            this.Controls.Add(this.moveConfirmButton);
            this.Controls.Add(this.moveDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Move";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Move";
            ((System.ComponentModel.ISupportInitialize)(this.moveDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button moveCancelButton;
        private System.Windows.Forms.Button moveConfirmButton;
        private System.Windows.Forms.DataGridView moveDataGridView;
        private System.Windows.Forms.TextBox moveAddItemTextBox;
        private System.Windows.Forms.Button moveAddItemButton;
        private System.Windows.Forms.Label moveSearchLabel;
    }
}