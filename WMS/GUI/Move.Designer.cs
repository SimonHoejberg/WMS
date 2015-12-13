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
            this.cancelButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.moveAddItemTextBox = new System.Windows.Forms.TextBox();
            this.moveAddItemButton = new System.Windows.Forms.Button();
            this.rmoveRowButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(1088, 647);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(1196, 647);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(4);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(100, 28);
            this.confirmButton.TabIndex = 5;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.ConfirmButtonClick);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView.Location = new System.Drawing.Point(16, 65);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1280, 544);
            this.dataGridView.TabIndex = 4;
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCellValueChanged);
            // 
            // moveAddItemTextBox
            // 
            this.moveAddItemTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.moveAddItemTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.moveAddItemTextBox.Location = new System.Drawing.Point(16, 15);
            this.moveAddItemTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.moveAddItemTextBox.Name = "moveAddItemTextBox";
            this.moveAddItemTextBox.Size = new System.Drawing.Size(360, 22);
            this.moveAddItemTextBox.TabIndex = 8;
            this.moveAddItemTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoveAddItemTextBoxKeyDown);
            // 
            // moveAddItemButton
            // 
            this.moveAddItemButton.Location = new System.Drawing.Point(385, 15);
            this.moveAddItemButton.Margin = new System.Windows.Forms.Padding(4);
            this.moveAddItemButton.Name = "moveAddItemButton";
            this.moveAddItemButton.Size = new System.Drawing.Size(100, 28);
            this.moveAddItemButton.TabIndex = 9;
            this.moveAddItemButton.Text = "Add Line";
            this.moveAddItemButton.UseVisualStyleBackColor = true;
            this.moveAddItemButton.Click += new System.EventHandler(this.MoveAddItemButtonClick);
            // 
            // rmoveRowButton
            // 
            this.rmoveRowButton.Location = new System.Drawing.Point(905, 647);
            this.rmoveRowButton.Margin = new System.Windows.Forms.Padding(4);
            this.rmoveRowButton.Name = "rmoveRowButton";
            this.rmoveRowButton.Size = new System.Drawing.Size(119, 28);
            this.rmoveRowButton.TabIndex = 11;
            this.rmoveRowButton.Text = "Fjern række";
            this.rmoveRowButton.UseVisualStyleBackColor = true;
            this.rmoveRowButton.Click += new System.EventHandler(this.RemoveRowButtonClick);
            // 
            // Move
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 690);
            this.Controls.Add(this.rmoveRowButton);
            this.Controls.Add(this.moveAddItemButton);
            this.Controls.Add(this.moveAddItemTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Move";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Move";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox moveAddItemTextBox;
        private System.Windows.Forms.Button moveAddItemButton;
        private System.Windows.Forms.Button rmoveRowButton;
    }
}