namespace WMS.GUI
{
    partial class Main
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
            this.informationButton = new System.Windows.Forms.PictureBox();
            this.logButton = new System.Windows.Forms.PictureBox();
            this.moveButton = new System.Windows.Forms.PictureBox();
            this.registerButton = new System.Windows.Forms.PictureBox();
            this.wasteButton = new System.Windows.Forms.PictureBox();
            this.reduceButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.informationButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wasteButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reduceButton)).BeginInit();
            this.SuspendLayout();
            // 
            // informationButton
            // 
            this.informationButton.BackgroundImage = global::WMS.Properties.Resources.placeholder_Information;
            this.informationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.informationButton.Location = new System.Drawing.Point(16, 15);
            this.informationButton.Margin = new System.Windows.Forms.Padding(4);
            this.informationButton.Name = "informationButton";
            this.informationButton.Size = new System.Drawing.Size(128, 75);
            this.informationButton.TabIndex = 0;
            this.informationButton.TabStop = false;
            this.informationButton.Click += new System.EventHandler(this.Information_pbox_Click);
            // 
            // logButton
            // 
            this.logButton.BackgroundImage = global::WMS.Properties.Resources.placeholder_Log;
            this.logButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logButton.Location = new System.Drawing.Point(16, 97);
            this.logButton.Margin = new System.Windows.Forms.Padding(4);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(128, 75);
            this.logButton.TabIndex = 1;
            this.logButton.TabStop = false;
            this.logButton.Click += new System.EventHandler(this.LogButtonClick);
            // 
            // moveButton
            // 
            this.moveButton.BackgroundImage = global::WMS.Properties.Resources.placeholder_Move;
            this.moveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.moveButton.Location = new System.Drawing.Point(16, 180);
            this.moveButton.Margin = new System.Windows.Forms.Padding(4);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(128, 75);
            this.moveButton.TabIndex = 2;
            this.moveButton.TabStop = false;
            this.moveButton.Click += new System.EventHandler(this.MoveButtonClick);
            // 
            // registerButton
            // 
            this.registerButton.BackgroundImage = global::WMS.Properties.Resources.placeholder_Register;
            this.registerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.registerButton.Location = new System.Drawing.Point(16, 262);
            this.registerButton.Margin = new System.Windows.Forms.Padding(4);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(128, 75);
            this.registerButton.TabIndex = 3;
            this.registerButton.TabStop = false;
            this.registerButton.Click += new System.EventHandler(this.RegisterButtonClick);
            // 
            // wasteButton
            // 
            this.wasteButton.BackgroundImage = global::WMS.Properties.Resources.placeholder_Waste;
            this.wasteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.wasteButton.Location = new System.Drawing.Point(16, 345);
            this.wasteButton.Margin = new System.Windows.Forms.Padding(4);
            this.wasteButton.Name = "wasteButton";
            this.wasteButton.Size = new System.Drawing.Size(128, 75);
            this.wasteButton.TabIndex = 5;
            this.wasteButton.TabStop = false;
            this.wasteButton.Click += new System.EventHandler(this.WasteButtonClick);
            // 
            // reduceButton
            // 
            this.reduceButton.BackgroundImage = global::WMS.Properties.Resources.placeholder_Remove;
            this.reduceButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.reduceButton.Location = new System.Drawing.Point(16, 428);
            this.reduceButton.Margin = new System.Windows.Forms.Padding(4);
            this.reduceButton.Name = "reduceButton";
            this.reduceButton.Size = new System.Drawing.Size(128, 75);
            this.reduceButton.TabIndex = 6;
            this.reduceButton.TabStop = false;
            this.reduceButton.Click += new System.EventHandler(this.ReduceButtonClick);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(157, 509);
            this.Controls.Add(this.reduceButton);
            this.Controls.Add(this.wasteButton);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.informationButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.Load += new System.EventHandler(this.MainLoad);
            ((System.ComponentModel.ISupportInitialize)(this.informationButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wasteButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reduceButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox informationButton;
        private System.Windows.Forms.PictureBox logButton;
        private System.Windows.Forms.PictureBox moveButton;
        private System.Windows.Forms.PictureBox registerButton;
        private System.Windows.Forms.PictureBox wasteButton;
        private System.Windows.Forms.PictureBox reduceButton;
    }
}