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
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.SuspendLayout();
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(1088, 647);
            this.button9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(100, 28);
            this.button9.TabIndex = 5;
            this.button9.Text = "Sort";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Sort_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(1196, 647);
            this.button8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(100, 28);
            this.button8.TabIndex = 4;
            this.button8.Text = "View Item";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // dataGridView5
            // 
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Location = new System.Drawing.Point(16, 37);
            this.dataGridView5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(1280, 575);
            this.dataGridView5.TabIndex = 3;
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 690);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.dataGridView5);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Log";
            this.Text = "Log";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.DataGridView dataGridView5;
    }
}