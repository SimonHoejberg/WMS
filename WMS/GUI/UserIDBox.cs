﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMS.Core;
using WMS.Interfaces;
using WMS.Reference;

namespace WMS.GUI
{
    public partial class UserIDBox : Form
    {
        private ICore core;
        private ILang lang;

        public UserIDBox(ICore core, ILang lang)
        {
            this.core = core;
            this.lang = lang;
            InitializeComponent();
            Text = lang.CONFIRM;
            label1.Text = lang.USER_ID;
            userConfirm_btn.Text = lang.ACCEPT;
            userCancel_btn.Text = lang.CANCEL;
        }

        public string User { get { return getInputFromTextbox; } }

        private void UserIDBox_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void userConfirm_btn_Click(object sender, EventArgs e)
        {
            var stringList = core.DataHandler.GetUser().OfType<string>();
            
            if (stringList.Contains(getInputFromTextbox))
            {
                DialogResult = DialogResult.OK;
                userIDError_lbl.Text = "";
            }
            else
            {
                userIDError_lbl.Text = lang.INVILD_USER_ID;
            }
        }

        private void userID_tbx_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                userConfirm_btn_Click(this, new EventArgs());
            }
            else if(e.KeyCode == Keys.Escape)
            {
                button2_Click(this, new EventArgs());
            }
        }

    }
}
