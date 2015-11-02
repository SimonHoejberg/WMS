using System;
using System.Windows.Forms;
using WMS.Interfaces;

namespace WMS.GUI
{
    public partial class Register : Form, IGui
    {
        private ICore core;
        public Register(ICore core)
        {
            this.core = core;
            InitializeComponent();
        }

        public string GetTypeOfWindow()
        {
            return "register";
        }

        public void UpdateGuiElements()
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserIDBox user_dialog = new UserIDBox(core);
            DialogResult a = user_dialog.ShowDialog(); //Dialogresult is either OK or Cancel. OK only if correct userID was entered
        }
    }
}
