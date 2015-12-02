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
            this.userIdTextBox = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.userIdLabel = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userIdTextBox
            // 
            this.userIdTextBox.Location = new System.Drawing.Point(16, 31);
            this.userIdTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.userIdTextBox.Name = "userIdTextBox";
            this.userIdTextBox.PasswordChar = '*';
            this.userIdTextBox.Size = new System.Drawing.Size(261, 22);
            this.userIdTextBox.TabIndex = 1;
            this.userIdTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserIdTextBoxKeyDown);
            // 
            // ConfirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(16, 79);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(4);
            this.confirmButton.Name = "ConfirmButton";
            this.confirmButton.Size = new System.Drawing.Size(100, 28);
            this.confirmButton.TabIndex = 2;
            this.confirmButton.Text = "Accept";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.ConfirmButtonClick);
            // 
            // CancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(179, 79);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "CancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // userIdLabel
            // 
            this.userIdLabel.AutoSize = true;
            this.userIdLabel.Location = new System.Drawing.Point(16, 11);
            this.userIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userIdLabel.Name = "userIdLabel";
            this.userIdLabel.Size = new System.Drawing.Size(55, 17);
            this.userIdLabel.TabIndex = 4;
            this.userIdLabel.Text = "User ID";
            // 
            // ErrorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(16, 59);
            this.errorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.errorLabel.Name = "ErrorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 17);
            this.errorLabel.TabIndex = 5;
            // 
            // UserIDBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 122);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.userIdLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.userIdTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserIDBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Confirmation";
            this.Load += new System.EventHandler(this.UserIDBoxLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userIdTextBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label userIdLabel;
        private System.Windows.Forms.Label errorLabel;

        //Extra properties
        private string getInputFromTextbox { get { return userIdTextBox.Text; } }
    }
}