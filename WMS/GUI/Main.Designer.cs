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
            this.information_pbox = new System.Windows.Forms.PictureBox();
            this.log_pbox = new System.Windows.Forms.PictureBox();
            this.move_pbox = new System.Windows.Forms.PictureBox();
            this.register_pbox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.information_pbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.log_pbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.move_pbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.register_pbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // information_pbox
            // 
            this.information_pbox.BackgroundImage = global::WMS.Properties.Resources.placeholder_Information;
            this.information_pbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.information_pbox.Location = new System.Drawing.Point(16, 15);
            this.information_pbox.Margin = new System.Windows.Forms.Padding(4);
            this.information_pbox.Name = "information_pbox";
            this.information_pbox.Size = new System.Drawing.Size(128, 75);
            this.information_pbox.TabIndex = 0;
            this.information_pbox.TabStop = false;
            this.information_pbox.Click += new System.EventHandler(this.information_pbox_Click);
            // 
            // log_pbox
            // 
            this.log_pbox.BackgroundImage = global::WMS.Properties.Resources.placeholder_Log;
            this.log_pbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.log_pbox.Location = new System.Drawing.Point(16, 97);
            this.log_pbox.Margin = new System.Windows.Forms.Padding(4);
            this.log_pbox.Name = "log_pbox";
            this.log_pbox.Size = new System.Drawing.Size(128, 75);
            this.log_pbox.TabIndex = 1;
            this.log_pbox.TabStop = false;
            this.log_pbox.Click += new System.EventHandler(this.log_pbox_Click);
            // 
            // move_pbox
            // 
            this.move_pbox.BackgroundImage = global::WMS.Properties.Resources.placeholder_Move;
            this.move_pbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.move_pbox.Location = new System.Drawing.Point(16, 180);
            this.move_pbox.Margin = new System.Windows.Forms.Padding(4);
            this.move_pbox.Name = "move_pbox";
            this.move_pbox.Size = new System.Drawing.Size(128, 75);
            this.move_pbox.TabIndex = 2;
            this.move_pbox.TabStop = false;
            this.move_pbox.Click += new System.EventHandler(this.move_pbox_Click);
            // 
            // register_pbox
            // 
            this.register_pbox.BackgroundImage = global::WMS.Properties.Resources.placeholder_Register;
            this.register_pbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.register_pbox.Location = new System.Drawing.Point(16, 262);
            this.register_pbox.Margin = new System.Windows.Forms.Padding(4);
            this.register_pbox.Name = "register_pbox";
            this.register_pbox.Size = new System.Drawing.Size(128, 75);
            this.register_pbox.TabIndex = 3;
            this.register_pbox.TabStop = false;
            this.register_pbox.Click += new System.EventHandler(this.register_pbox_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WMS.Properties.Resources.placeholder_Waste;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(16, 345);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 75);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(160, 519);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.register_pbox);
            this.Controls.Add(this.move_pbox);
            this.Controls.Add(this.log_pbox);
            this.Controls.Add(this.information_pbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "Main";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.information_pbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.log_pbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.move_pbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.register_pbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox information_pbox;
        private System.Windows.Forms.PictureBox log_pbox;
        private System.Windows.Forms.PictureBox move_pbox;
        private System.Windows.Forms.PictureBox register_pbox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}