using System;
using System.Windows.Forms;
using WMS.Interfaces;

namespace WMS.GUI
{
    public partial class Main : Form , IMain
    {
        //Properties for objects this class needs to fuction but only can get after creation
        public ICore Core { get; set; }
        public ILang lang { get; set; }

        public Main()
        {
            InitializeComponent();
        }

        private void MainLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            userNameLabel.Text = Core.UserName;
        }

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

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            Core.DataHandler.CloseConnectionToServer();
        }

        public void UpdatePics(bool da)
        {
            if (da)
            {
                moveButton.Image = Properties.Resources.move;
                reduceButton.Image = Properties.Resources.reduce;
                registerButton.Image = Properties.Resources.register;
                wasteButton.Image = Properties.Resources.waste;
                langButton.Image = Properties.Resources.dannebro;
            }
            else
            {
                moveButton.Image = Properties.Resources.moveda;
                reduceButton.Image = Properties.Resources.reduceda;
                registerButton.Image = Properties.Resources.registerda;
                wasteButton.Image = Properties.Resources.wasteda;
                langButton.Image = Properties.Resources.union_jack_30x18;
            }
            UpdateLang();
        }

        private void lang_Click(object sender, EventArgs e)
        {
            Core.changeLang();
        }

        public void UpdateLang()
        {
            loggedInLabel.Text = lang.LOGGED_IN_AS;
        }
    }
}
