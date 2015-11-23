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
            this.langButton = new System.Windows.Forms.PictureBox();
            this.reduceButton = new System.Windows.Forms.PictureBox();
            this.wasteButton = new System.Windows.Forms.PictureBox();
            this.registerButton = new System.Windows.Forms.PictureBox();
            this.moveButton = new System.Windows.Forms.PictureBox();
            this.logButton = new System.Windows.Forms.PictureBox();
            this.informationButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.langButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reduceButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wasteButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.informationButton)).BeginInit();
            this.SuspendLayout();
            // 
            // langButton
            // 
            this.langButton.BackgroundImage = global::WMS.Properties.Resources.union_jack_30x18;
            this.langButton.Location = new System.Drawing.Point(11, 2);
            this.langButton.Name = "langButton";
            this.langButton.Size = new System.Drawing.Size(30, 18);
            this.langButton.TabIndex = 7;
            this.langButton.TabStop = false;
            this.langButton.Click += new System.EventHandler(this.lang_Click);
            // 
            // reduceButton
            // 
            this.reduceButton.BackgroundImage = global::WMS.Properties.Resources.reduceda;
            this.reduceButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.reduceButton.Location = new System.Drawing.Point(16, 277);
            this.reduceButton.Margin = new System.Windows.Forms.Padding(4);
            this.reduceButton.Name = "reduceButton";
            this.reduceButton.Size = new System.Drawing.Size(128, 75);
            this.reduceButton.TabIndex = 6;
            this.reduceButton.TabStop = false;
            this.reduceButton.Click += new System.EventHandler(this.ReduceButtonClick);
            // 
            // wasteButton
            // 
            this.wasteButton.BackgroundImage = global::WMS.Properties.Resources.wasteda;
            this.wasteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.wasteButton.Location = new System.Drawing.Point(16, 447);
            this.wasteButton.Margin = new System.Windows.Forms.Padding(4);
            this.wasteButton.Name = "wasteButton";
            this.wasteButton.Size = new System.Drawing.Size(128, 75);
            this.wasteButton.TabIndex = 5;
            this.wasteButton.TabStop = false;
            this.wasteButton.Click += new System.EventHandler(this.WasteButtonClick);
            // 
            // registerButton
            // 
            this.registerButton.BackgroundImage = global::WMS.Properties.Resources.registerda;
            this.registerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.registerButton.Location = new System.Drawing.Point(16, 361);
            this.registerButton.Margin = new System.Windows.Forms.Padding(4);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(128, 75);
            this.registerButton.TabIndex = 3;
            this.registerButton.TabStop = false;
            this.registerButton.Click += new System.EventHandler(this.RegisterButtonClick);
            // 
            // moveButton
            // 
            this.moveButton.BackgroundImage = global::WMS.Properties.Resources.moveda;
            this.moveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.moveButton.Location = new System.Drawing.Point(16, 194);
            this.moveButton.Margin = new System.Windows.Forms.Padding(4);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(128, 75);
            this.moveButton.TabIndex = 2;
            this.moveButton.TabStop = false;
            this.moveButton.Click += new System.EventHandler(this.MoveButtonClick);
            // 
            // logButton
            // 
            this.logButton.BackgroundImage = global::WMS.Properties.Resources.log;
            this.logButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logButton.Location = new System.Drawing.Point(16, 110);
            this.logButton.Margin = new System.Windows.Forms.Padding(4);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(128, 75);
            this.logButton.TabIndex = 1;
            this.logButton.TabStop = false;
            this.logButton.Click += new System.EventHandler(this.LogButtonClick);
            // 
            // informationButton
            // 
            this.informationButton.BackgroundImage = global::WMS.Properties.Resources.info;
            this.informationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.informationButton.Location = new System.Drawing.Point(16, 27);
            this.informationButton.Margin = new System.Windows.Forms.Padding(4);
            this.informationButton.Name = "informationButton";
            this.informationButton.Size = new System.Drawing.Size(128, 75);
            this.informationButton.TabIndex = 0;
            this.informationButton.TabStop = false;
            this.informationButton.Click += new System.EventHandler(this.Information_pbox_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(157, 534);
            this.Controls.Add(this.langButton);
            this.Controls.Add(this.reduceButton);
            this.Controls.Add(this.wasteButton);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.informationButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.Load += new System.EventHandler(this.MainLoad);
            ((System.ComponentModel.ISupportInitialize)(this.langButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reduceButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wasteButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registerButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.informationButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox informationButton;
        private System.Windows.Forms.PictureBox logButton;
        private System.Windows.Forms.PictureBox moveButton;
        private System.Windows.Forms.PictureBox registerButton;
        private System.Windows.Forms.PictureBox wasteButton;
        private System.Windows.Forms.PictureBox reduceButton;
        private System.Windows.Forms.PictureBox langButton;
    }
}