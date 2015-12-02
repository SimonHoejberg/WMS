using System;
using System.Collections.Generic;
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
        /// Disables maximize and minimize button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserIDBoxLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
        }

        /// <summary>
        /// Closes the form when the user click on cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Checks if the user exist on the database and logges in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButtonClick(object sender, EventArgs e)
        {
            List<string> stringList = core.DataHandler.GetUser(); // Gets the user from the database

            if (stringList.Contains(userTextbox.Text))
            {
                core.UserName = core.DataHandler.GetUserName(userTextbox.Text); //Sets the user name in the core to the user who is logged in
                DialogResult = DialogResult.OK; //returns a result
            }
            else
            {
                ErrorLabel.Text = core.Lang.INVILD_USER_ID; //Tells the user that the user id does not exist
            }
        }

        /// <summary>
        /// When a button is pressed on the textbox it checks if the key is enter or escape and fires an event based on the key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserTextboxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginButtonClick(sender, new EventArgs());
            }
            else if (e.KeyCode == Keys.Escape)
            {
                CancelButtonClick(sender, new EventArgs());
            }
        }
    }
}
