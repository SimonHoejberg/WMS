using System;
using System.Windows.Forms;
using WMS.Interfaces;

namespace WMS.GUI
{
    public partial class Main : Form , IMain
    {
        //Properties for objects this class needs to fuction but only can get after creation
        public ICore Core { get; set; }

        public Main()
        {
            InitializeComponent();
        }

        private void MainLoad(object sender, EventArgs e)
        {
            //Disables both the maximize and minimize buttons
            MaximizeBox = false;
            MinimizeBox = false;
            userNameLabel.Text = Core.UserName; //Sets the user name from the login
        }

        #region Window buttons events 
        /*
        Events from button that creates new windows through the windowHandler
        */
        private void InformationButtonClick(object sender, EventArgs e)
        {
            Core.WindowHandler.OpenInformation();
        }

        private void LogButtonClick(object sender, EventArgs e)
        {
            Core.WindowHandler.OpenLog();
        }

        private void MoveButtonClick(object sender, EventArgs e)
        {
            Core.WindowHandler.OpenMove();
        }

        private void RegisterButtonClick(object sender, EventArgs e)
        {
            Core.WindowHandler.OpenRegister();
        }

        private void WasteButtonClick(object sender, EventArgs e)
        {
            Core.WindowHandler.OpenWaste();
        }

        private void ReduceButtonClick(object sender, EventArgs e)
        {
            Core.WindowHandler.OpenReduce();
        }
        #endregion

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            //When main form closes disconnect from the database
            Core.DataHandler.CloseConnectionToServer();
        }

        /// <summary>
        /// Updates the button pictures and flag on main menu
        /// </summary>
        /// <param name="da"></param>
        public void UpdatePics(bool da)
        {
            //Uses the resources to set the pictures
            if (da)
            {
                moveButton.Image = Properties.Resources.move;
                reduceButton.Image = Properties.Resources.reduce;
                registerButton.Image = Properties.Resources.register;
                wasteButton.Image = Properties.Resources.waste;
                flagButton.Image = Properties.Resources.dannebro;
            }
            else
            {
                moveButton.Image = Properties.Resources.moveda;
                reduceButton.Image = Properties.Resources.reduceda;
                registerButton.Image = Properties.Resources.registerda;
                wasteButton.Image = Properties.Resources.wasteda;
                flagButton.Image = Properties.Resources.union_jack_30x18;
            }
            UpdateLang();
        }

        /// <summary>
        /// Updates the labels and normal windows buttons on a window
        /// </summary>
        public void UpdateLang()
        {
            loggedInLabel.Text = Core.Lang.LOGGED_IN_AS;
        }

        private void flagButtonClick(object sender, EventArgs e)
        {
            Core.changeLang();
        }
    }
}
