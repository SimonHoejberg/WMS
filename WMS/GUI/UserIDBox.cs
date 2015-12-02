using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
            //Langauge
            Text = core.Lang.CONFIRM;
            userIdLabel.Text = core.Lang.USER_ID;
            confirmButton.Text = core.Lang.ACCEPT;
            cancelButton.Text = core.Lang.CANCEL;
        }

        //The userId from this dialog
        public string User { get { return getInputFromTextbox; } }

        private void UserIDBoxLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
        }

        /// <summary>
        /// Closes the form if the cancel is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Checks if the user exist on the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            List<string> stringList = core.DataHandler.GetUser(); // Gets the user from the database

            if (stringList.Contains(getInputFromTextbox))
            {
                DialogResult = DialogResult.OK; //Returns the dialogResult Okay
                errorLabel.Text = "";
            }
            else
            {
                errorLabel.Text = core.Lang.INVILD_USER_ID; //Tells the user that the user id does not exist
            }
        }

        /// <summary>
        /// When a button is pressed on the textbox it checks if the key is enter or escape and fires an event based on the key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserIdTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ConfirmButtonClick(this, new EventArgs());
            }
            else if(e.KeyCode == Keys.Escape)
            {
                CancelButtonClick(this, new EventArgs());
            }
        }

    }
}
