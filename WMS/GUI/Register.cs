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
    public partial class Register : Form, IGui
    {
        public Register(ICore core)
        {
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
            UserIDBox user_dialog = new UserIDBox();

            DialogResult a = user_dialog.ShowDialog();

            

            Console.WriteLine(a);
        }
    }
}
