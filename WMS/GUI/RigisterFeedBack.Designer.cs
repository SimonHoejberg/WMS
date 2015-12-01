namespace WMS.GUI
{
    partial class RigisterFeedBack
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
            this.placedButton = new System.Windows.Forms.Button();
            this.notPlacedButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.feedbackListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // placedButton
            // 
            this.placedButton.Location = new System.Drawing.Point(12, 12);
            this.placedButton.Name = "placedButton";
            this.placedButton.Size = new System.Drawing.Size(124, 23);
            this.placedButton.TabIndex = 1;
            this.placedButton.Text = "Placed";
            this.placedButton.UseVisualStyleBackColor = true;
            this.placedButton.Click += new System.EventHandler(this.PlacedButtonClick);
            // 
            // notPlacedButton
            // 
            this.notPlacedButton.Location = new System.Drawing.Point(146, 12);
            this.notPlacedButton.Name = "notPlacedButton";
            this.notPlacedButton.Size = new System.Drawing.Size(124, 23);
            this.notPlacedButton.TabIndex = 2;
            this.notPlacedButton.Text = "Not Placed";
            this.notPlacedButton.UseVisualStyleBackColor = true;
            this.notPlacedButton.Click += new System.EventHandler(this.NotPlacedButtonClick);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(195, 364);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButtonClick);
            // 
            // feedbackListView
            // 
            this.feedbackListView.Location = new System.Drawing.Point(12, 41);
            this.feedbackListView.Name = "feedbackListView";
            this.feedbackListView.Size = new System.Drawing.Size(258, 317);
            this.feedbackListView.TabIndex = 4;
            this.feedbackListView.UseCompatibleStateImageBehavior = false;
            // 
            // RigisterFeedBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 399);
            this.Controls.Add(this.feedbackListView);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.notPlacedButton);
            this.Controls.Add(this.placedButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RigisterFeedBack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button placedButton;
        private System.Windows.Forms.Button notPlacedButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ListView feedbackListView;
    }
}