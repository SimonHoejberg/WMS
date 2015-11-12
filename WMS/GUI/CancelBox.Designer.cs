namespace WMS.GUI
{
    partial class CancelBox
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
            this.userCancel_btn = new System.Windows.Forms.Button();
            this.userConfirm_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userCancel_btn
            // 
            this.userCancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.userCancel_btn.Location = new System.Drawing.Point(179, 79);
            this.userCancel_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userCancel_btn.Name = "userCancel_btn";
            this.userCancel_btn.Size = new System.Drawing.Size(100, 28);
            this.userCancel_btn.TabIndex = 5;
            this.userCancel_btn.Text = "No";
            this.userCancel_btn.UseVisualStyleBackColor = true;
            this.userCancel_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // userConfirm_btn
            // 
            this.userConfirm_btn.Location = new System.Drawing.Point(16, 79);
            this.userConfirm_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userConfirm_btn.Name = "userConfirm_btn";
            this.userConfirm_btn.Size = new System.Drawing.Size(100, 28);
            this.userConfirm_btn.TabIndex = 4;
            this.userConfirm_btn.Text = "Yes";
            this.userConfirm_btn.UseVisualStyleBackColor = true;
            this.userConfirm_btn.Click += new System.EventHandler(this.userConfirm_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Are you sure you want to cancel?";
            // 
            // CancelBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 122);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userCancel_btn);
            this.Controls.Add(this.userConfirm_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CancelBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CancelBox";
            this.Load += new System.EventHandler(this.CancelBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button userCancel_btn;
        private System.Windows.Forms.Button userConfirm_btn;
        private System.Windows.Forms.Label label1;
    }
}