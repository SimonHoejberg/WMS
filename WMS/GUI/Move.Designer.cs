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
            this.moveLoadOptimalButton = new System.Windows.Forms.Button();
            this.moveConfirmButton = new System.Windows.Forms.Button();
            this.moveDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.moveDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // moveCancelButton
            // 
            this.moveCancelButton.Location = new System.Drawing.Point(1088, 647);
            this.moveCancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.moveCancelButton.Name = "moveCancelButton";
            this.moveCancelButton.Size = new System.Drawing.Size(100, 28);
            this.moveCancelButton.TabIndex = 7;
            this.moveCancelButton.Text = "Cancel";
            this.moveCancelButton.UseVisualStyleBackColor = true;
            // 
            // moveLoadOptimalButton
            // 
            this.moveLoadOptimalButton.Location = new System.Drawing.Point(980, 647);
            this.moveLoadOptimalButton.Margin = new System.Windows.Forms.Padding(4);
            this.moveLoadOptimalButton.Name = "moveLoadOptimalButton";
            this.moveLoadOptimalButton.Size = new System.Drawing.Size(100, 28);
            this.moveLoadOptimalButton.TabIndex = 6;
            this.moveLoadOptimalButton.Text = "Load optimal";
            this.moveLoadOptimalButton.UseVisualStyleBackColor = true;
            this.moveLoadOptimalButton.Click += new System.EventHandler(this.moveLoadOptimalButtonClick);
            // 
            // moveConfirmButton
            // 
            this.moveConfirmButton.Location = new System.Drawing.Point(1196, 647);
            this.moveConfirmButton.Margin = new System.Windows.Forms.Padding(4);
            this.moveConfirmButton.Name = "moveConfirmButton";
            this.moveConfirmButton.Size = new System.Drawing.Size(100, 28);
            this.moveConfirmButton.TabIndex = 5;
            this.moveConfirmButton.Text = "Confirm";
            this.moveConfirmButton.UseVisualStyleBackColor = true;
            this.moveConfirmButton.Click += new System.EventHandler(this.MoveConfirmButtonClick);
            // 
            // moveDataGridView
            // 
            this.moveDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.moveDataGridView.Location = new System.Drawing.Point(16, 15);
            this.moveDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.moveDataGridView.Name = "moveDataGridView";
            this.moveDataGridView.Size = new System.Drawing.Size(1280, 594);
            this.moveDataGridView.TabIndex = 4;
            this.moveDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.moveDataGridViewCellValueChanged);
            this.moveDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.MoveDataGridViewRowsAdded);
            // 
            // Move
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 690);
            this.Controls.Add(this.moveCancelButton);
            this.Controls.Add(this.moveLoadOptimalButton);
            this.Controls.Add(this.moveConfirmButton);
            this.Controls.Add(this.moveDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Move";
            this.Text = "Move";
            ((System.ComponentModel.ISupportInitialize)(this.moveDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button moveCancelButton;
        private System.Windows.Forms.Button moveLoadOptimalButton;
        private System.Windows.Forms.Button moveConfirmButton;
        private System.Windows.Forms.DataGridView moveDataGridView;
    }
}