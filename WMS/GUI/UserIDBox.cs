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

namespace WMS.GUI
{
    public partial class UserIDBox : Form
    {
        private ICore core;
        public UserIDBox(ICore core)
        {
            this.core = core;
            InitializeComponent();
        }

        private void UserIDBox_Load(object sender, EventArgs e)
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
            //UserData user_obj = core.getUserDataObj();
            int a;
            bool b = Int32.TryParse(this.getInputFromTextbox, out a);
            /*userIDError_lbl.Text = "";
            }
            else
            {
                userIDError_lbl.Text = "Invalid user ID";
            }*/
            
        }
    }
}
