namespace WMS.GUI
{
    partial class Login
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
            this.userIDError_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.userIDTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // userIDError_lbl
            // 
            this.userIDError_lbl.AutoSize = true;
            this.userIDError_lbl.ForeColor = System.Drawing.Color.Red;
            this.userIDError_lbl.Location = new System.Drawing.Point(8, 57);
            this.userIDError_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userIDError_lbl.Name = "userIDError_lbl";
            this.userIDError_lbl.Size = new System.Drawing.Size(0, 17);
            this.userIDError_lbl.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "User ID";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(171, 77);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButtonClick);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(8, 77);
            this.loginButton.Margin = new System.Windows.Forms.Padding(4);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(100, 28);
            this.loginButton.TabIndex = 7;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.userLoginButtonClick);
            // 
            // userIDTextbox
            // 
            this.userIDTextbox.Location = new System.Drawing.Point(8, 29);
            this.userIDTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.userIDTextbox.Name = "userIDTextbox";
            this.userIDTextbox.Size = new System.Drawing.Size(261, 22);
            this.userIDTextbox.TabIndex = 6;
            this.userIDTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userIDTextboxKeyDown);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 119);
            this.Controls.Add(this.userIDError_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.userIDTextbox);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userIDError_lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox userIDTextbox;
    }
}