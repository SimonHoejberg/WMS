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
using WMS.Reference;

namespace WMS.GUI
{
    public partial class Main : Form , IMain
    {
        private ICore core;
        public ILang lang { get; set; }

        public Main()
        {
            InitializeComponent();
        }

        private void MainLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            label2.Text = core.UserName;
        }

        public ICore Core { set { core = value; } }

        private void Information_pbox_Click(object sender, EventArgs e)
        {
            core.WindowHandler.OpenInformation();
        }

        private void LogButtonClick(object sender, EventArgs e)
        {
            core.WindowHandler.OpenLog();
        }

        private void MoveButtonClick(object sender, EventArgs e)
        {
            core.WindowHandler.OpenMove();
        }

        private void RegisterButtonClick(object sender, EventArgs e)
        {
            core.WindowHandler.OpenRegister();
        }

        private void WasteButtonClick(object sender, EventArgs e)
        {
            core.WindowHandler.OpenWaste();
        }

        private void ReduceButtonClick(object sender, EventArgs e)
        {
            core.WindowHandler.OpenReduce();
        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            core.DataHandler.CloseConnectionToServer();
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
            core.changeLang();
        }

        public void UpdateLang()
        {
            label1.Text = lang.LOGGED_IN_AS;
        }
    }
}
