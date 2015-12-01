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
            this.moveRemoveRowButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.moveDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // moveCancelButton
            // 
            this.moveCancelButton.Location = new System.Drawing.Point(816, 526);
            this.moveCancelButton.Name = "moveCancelButton";
            this.moveCancelButton.Size = new System.Drawing.Size(75, 23);
            this.moveCancelButton.TabIndex = 7;
            this.moveCancelButton.Text = "Cancel";
            this.moveCancelButton.UseVisualStyleBackColor = true;
            this.moveCancelButton.Click += new System.EventHandler(this.moveCancelButton_Click);
            // 
            // moveConfirmButton
            // 
            this.moveConfirmButton.Location = new System.Drawing.Point(897, 526);
            this.moveConfirmButton.Name = "moveConfirmButton";
            this.moveConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.moveConfirmButton.TabIndex = 5;
            this.moveConfirmButton.Text = "Confirm";
            this.moveConfirmButton.UseVisualStyleBackColor = true;
            this.moveConfirmButton.Click += new System.EventHandler(this.MoveConfirmButtonClick);
            // 
            // moveDataGridView
            // 
            this.moveDataGridView.AllowUserToAddRows = false;
            this.moveDataGridView.AllowUserToDeleteRows = false;
            this.moveDataGridView.AllowUserToResizeColumns = false;
            this.moveDataGridView.AllowUserToResizeRows = false;
            this.moveDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.moveDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.moveDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.moveDataGridView.Location = new System.Drawing.Point(12, 53);
            this.moveDataGridView.Name = "moveDataGridView";
            this.moveDataGridView.Size = new System.Drawing.Size(960, 442);
            this.moveDataGridView.TabIndex = 4;
            this.moveDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.moveDataGridViewCellValueChanged);
            // 
            // moveAddItemTextBox
            // 
            this.moveAddItemTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.moveAddItemTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.moveAddItemTextBox.Location = new System.Drawing.Point(12, 12);
            this.moveAddItemTextBox.Name = "moveAddItemTextBox";
            this.moveAddItemTextBox.Size = new System.Drawing.Size(271, 20);
            this.moveAddItemTextBox.TabIndex = 8;
            this.moveAddItemTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.moveAddItemTextBox_KeyUp);
            // 
            // moveAddItemButton
            // 
            this.moveAddItemButton.Location = new System.Drawing.Point(289, 12);
            this.moveAddItemButton.Name = "moveAddItemButton";
            this.moveAddItemButton.Size = new System.Drawing.Size(75, 23);
            this.moveAddItemButton.TabIndex = 9;
            this.moveAddItemButton.Text = "Add Line";
            this.moveAddItemButton.UseVisualStyleBackColor = true;
            this.moveAddItemButton.Click += new System.EventHandler(this.moveAddItemButton_Click);
            // 
            // moveSearchLabel
            // 
            this.moveSearchLabel.AutoSize = true;
            this.moveSearchLabel.ForeColor = System.Drawing.Color.Red;
            this.moveSearchLabel.Location = new System.Drawing.Point(12, 35);
            this.moveSearchLabel.Name = "moveSearchLabel";
            this.moveSearchLabel.Size = new System.Drawing.Size(88, 13);
            this.moveSearchLabel.TabIndex = 10;
            this.moveSearchLabel.Text = "Item doesn\'t exist";
            this.moveSearchLabel.Visible = false;
            // 
            // moveRemoveRowButton
            // 
            this.moveRemoveRowButton.Location = new System.Drawing.Point(679, 526);
            this.moveRemoveRowButton.Name = "moveRemoveRowButton";
            this.moveRemoveRowButton.Size = new System.Drawing.Size(89, 23);
            this.moveRemoveRowButton.TabIndex = 11;
            this.moveRemoveRowButton.Text = "Fjern række";
            this.moveRemoveRowButton.UseVisualStyleBackColor = true;
            this.moveRemoveRowButton.Click += new System.EventHandler(this.moveRemoveRowButton_Click);
            // 
            // Move
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.moveRemoveRowButton);
            this.Controls.Add(this.moveSearchLabel);
            this.Controls.Add(this.moveAddItemButton);
            this.Controls.Add(this.moveAddItemTextBox);
            this.Controls.Add(this.moveCancelButton);
            this.Controls.Add(this.moveConfirmButton);
            this.Controls.Add(this.moveDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        private System.Windows.Forms.Button moveRemoveRowButton;
    }
}