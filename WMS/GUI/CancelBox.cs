﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS.GUI
{
    public partial class CancelBox : Form
    {
        public CancelBox()
        {
            InitializeComponent();
        }
        
        private void CancelBox_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userConfirm_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void userID_tbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                userConfirm_btn_Click(this, new EventArgs());
            }
            else if (e.KeyCode == Keys.Escape)
            {
                button2_Click(this, new EventArgs());
            }
        }
    }
}