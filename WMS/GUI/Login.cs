using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public string User { get { return userIDTextbox.Text; } }

        private void UserIDBox_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void cancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void userLoginButtonClick(object sender, EventArgs e)
        {
            var stringList = core.DataHandler.GetUser().OfType<string>();

            if (stringList.Contains(userIDTextbox.Text))
            {
                DialogResult = DialogResult.OK;
                userIDError_lbl.Text = "";
            }
            else
            {
                userIDError_lbl.Text = "Wrong username";
            }
        }

        private void userIDTextboxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                userLoginButtonClick(this, new EventArgs());
            }
            else if (e.KeyCode == Keys.Escape)
            {
                cancelButtonClick(this, new EventArgs());
            }
        }
    }
}
