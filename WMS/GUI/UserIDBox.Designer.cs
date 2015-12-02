namespace WMS.GUI
{
    partial class UserIDBox
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
            this.userID_tbx = new System.Windows.Forms.TextBox();
            this.userConfirm_btn = new System.Windows.Forms.Button();
            this.userCancel_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.userIDError_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userID_tbx
            // 
            this.userID_tbx.Location = new System.Drawing.Point(16, 31);
            this.userID_tbx.Margin = new System.Windows.Forms.Padding(4);
            this.userID_tbx.Name = "userID_tbx";
            this.userID_tbx.PasswordChar = '*';
            this.userID_tbx.Size = new System.Drawing.Size(261, 22);
            this.userID_tbx.TabIndex = 1;
            this.userID_tbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userID_tbx_KeyDown);
            // 
            // userConfirm_btn
            // 
            this.userConfirm_btn.Location = new System.Drawing.Point(16, 79);
            this.userConfirm_btn.Margin = new System.Windows.Forms.Padding(4);
            this.userConfirm_btn.Name = "userConfirm_btn";
            this.userConfirm_btn.Size = new System.Drawing.Size(100, 28);
            this.userConfirm_btn.TabIndex = 2;
            this.userConfirm_btn.Text = "Accept";
            this.userConfirm_btn.UseVisualStyleBackColor = true;
            this.userConfirm_btn.Click += new System.EventHandler(this.userConfirm_btn_Click);
            // 
            // userCancel_btn
            // 
            this.userCancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.userCancel_btn.Location = new System.Drawing.Point(179, 79);
            this.userCancel_btn.Margin = new System.Windows.Forms.Padding(4);
            this.userCancel_btn.Name = "userCancel_btn";
            this.userCancel_btn.Size = new System.Drawing.Size(100, 28);
            this.userCancel_btn.TabIndex = 3;
            this.userCancel_btn.Text = "Cancel";
            this.userCancel_btn.UseVisualStyleBackColor = true;
            this.userCancel_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "User ID";
            // 
            // userIDError_lbl
            // 
            this.userIDError_lbl.AutoSize = true;
            this.userIDError_lbl.ForeColor = System.Drawing.Color.Red;
            this.userIDError_lbl.Location = new System.Drawing.Point(16, 59);
            this.userIDError_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userIDError_lbl.Name = "userIDError_lbl";
            this.userIDError_lbl.Size = new System.Drawing.Size(0, 17);
            this.userIDError_lbl.TabIndex = 5;
            // 
            // UserIDBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 122);
            this.Controls.Add(this.userIDError_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userCancel_btn);
            this.Controls.Add(this.userConfirm_btn);
            this.Controls.Add(this.userID_tbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserIDBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Confirmation";
            this.Load += new System.EventHandler(this.UserIDBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userID_tbx;
        private System.Windows.Forms.Button userConfirm_btn;
        private System.Windows.Forms.Button userCancel_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label userIDError_lbl;

        //Extra properties
        private string getInputFromTextbox { get { return userID_tbx.Text; } }
    }
}