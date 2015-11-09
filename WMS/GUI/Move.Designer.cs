namespace WMS.GUI
{
    partial class moveLoadOptimal
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
            this.moveCancel_btn = new System.Windows.Forms.Button();
            this.moveLoadOptimal_btn = new System.Windows.Forms.Button();
            this.moveConfirm_btn = new System.Windows.Forms.Button();
            this.moveMain_dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.moveMain_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // moveCancel_btn
            // 
            this.moveCancel_btn.Location = new System.Drawing.Point(816, 526);
            this.moveCancel_btn.Name = "moveCancel_btn";
            this.moveCancel_btn.Size = new System.Drawing.Size(75, 23);
            this.moveCancel_btn.TabIndex = 7;
            this.moveCancel_btn.Text = "Cancel";
            this.moveCancel_btn.UseVisualStyleBackColor = true;
            // 
            // moveLoadOptimal_btn
            // 
            this.moveLoadOptimal_btn.Location = new System.Drawing.Point(735, 526);
            this.moveLoadOptimal_btn.Name = "moveLoadOptimal_btn";
            this.moveLoadOptimal_btn.Size = new System.Drawing.Size(75, 23);
            this.moveLoadOptimal_btn.TabIndex = 6;
            this.moveLoadOptimal_btn.Text = "Load optimal";
            this.moveLoadOptimal_btn.UseVisualStyleBackColor = true;
            this.moveLoadOptimal_btn.Click += new System.EventHandler(this.moveLoadOptimal_btn_Click);
            // 
            // moveConfirm_btn
            // 
            this.moveConfirm_btn.Location = new System.Drawing.Point(897, 526);
            this.moveConfirm_btn.Name = "moveConfirm_btn";
            this.moveConfirm_btn.Size = new System.Drawing.Size(75, 23);
            this.moveConfirm_btn.TabIndex = 5;
            this.moveConfirm_btn.Text = "Confirm";
            this.moveConfirm_btn.UseVisualStyleBackColor = true;
            this.moveConfirm_btn.Click += new System.EventHandler(this.moveConfirm_btn_Click);
            // 
            // moveMain_dgv
            // 
            this.moveMain_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.moveMain_dgv.Location = new System.Drawing.Point(12, 12);
            this.moveMain_dgv.Name = "moveMain_dgv";
            this.moveMain_dgv.Size = new System.Drawing.Size(960, 483);
            this.moveMain_dgv.TabIndex = 4;
            this.moveMain_dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.moveMain_dgv_CellValueChanged);
            this.moveMain_dgv.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.moveMain_dgv_RowsAdded);
            // 
            // moveLoadOptimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.moveCancel_btn);
            this.Controls.Add(this.moveLoadOptimal_btn);
            this.Controls.Add(this.moveConfirm_btn);
            this.Controls.Add(this.moveMain_dgv);
            this.Name = "moveLoadOptimal";
            this.Text = "Move";
            ((System.ComponentModel.ISupportInitialize)(this.moveMain_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button moveCancel_btn;
        private System.Windows.Forms.Button moveLoadOptimal_btn;
        private System.Windows.Forms.Button moveConfirm_btn;
        private System.Windows.Forms.DataGridView moveMain_dgv;
    }
}