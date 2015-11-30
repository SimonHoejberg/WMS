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
            this.noButton = new System.Windows.Forms.Button();
            this.yesButton = new System.Windows.Forms.Button();
            this.cancelLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userCancel_btn
            // 
            this.noButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.noButton.Location = new System.Drawing.Point(179, 79);
            this.noButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.noButton.Name = "userCancel_btn";
            this.noButton.Size = new System.Drawing.Size(100, 28);
            this.noButton.TabIndex = 5;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.NoButtonClick);
            // 
            // userConfirm_btn
            // 
            this.yesButton.Location = new System.Drawing.Point(16, 79);
            this.yesButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.yesButton.Name = "userConfirm_btn";
            this.yesButton.Size = new System.Drawing.Size(100, 28);
            this.yesButton.TabIndex = 4;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.YesButtonClick);
            // 
            // label1
            // 
            this.cancelLabel.AutoSize = true;
            this.cancelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelLabel.Location = new System.Drawing.Point(12, 32);
            this.cancelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cancelLabel.Name = "label1";
            this.cancelLabel.Size = new System.Drawing.Size(257, 20);
            this.cancelLabel.TabIndex = 6;
            this.cancelLabel.Text = "Are you sure you want to cancel?";
            // 
            // CancelBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 122);
            this.Controls.Add(this.cancelLabel);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.yesButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CancelBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CancelBox";
            this.Load += new System.EventHandler(this.CancelBoxLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Label cancelLabel;
    }
}