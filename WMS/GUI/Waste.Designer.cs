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
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
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
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(816, 526);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 6;
            this.button10.Text = "Cancel";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(12, 23);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 5;
            this.comboBox3.Text = "Search";
            // 
            // dataGridView6
            // 
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14});
            this.dataGridView6.Location = new System.Drawing.Point(12, 50);
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.Size = new System.Drawing.Size(960, 446);
            this.dataGridView6.TabIndex = 4;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Item No";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Name";
            this.Column12.Name = "Column12";
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Location";
            this.Column13.Name = "Column13";
            // 
            // Column14
            // 
            this.Column14.HeaderText = "Quantity";
            this.Column14.Name = "Column14";
            // 
            // Waste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.dataGridView6);
            this.Name = "Waste";
            this.Text = "Waste";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.DataGridView dataGridView6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
    }
}