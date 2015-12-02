using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WMS.Interfaces;

namespace WMS.GUI
{
    public partial class Login : Form
    {
        private ICore core;

        public Login(ICore core)
        {
            this.core = core;
            InitializeComponent();
        }

        /// <summary>
        /// Disables 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserIDBoxLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void UserLoginButtonClick(object sender, EventArgs e)
        {
            List<string> stringList = core.DataHandler.GetUser();

            if (stringList.Contains(userIDTextbox.Text))
            {
                core.UserName = core.DataHandler.GetUserName(userIDTextbox.Text);
                DialogResult = DialogResult.OK;
                userIDError_lbl.Text = "";
            }
            else
            {
                userIDError_lbl.Text = core.Lang.INVILD_USER_ID;
            }
        }

        private void userIDTextboxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UserLoginButtonClick(this, new EventArgs());
            }
            else if (e.KeyCode == Keys.Escape)
            {
                CancelButtonClick(this, new EventArgs());
            }
        }
    }
}
