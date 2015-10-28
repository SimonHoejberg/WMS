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
    public partial class Move : Form, IGui
    {
        private ICore core;
        public Move(ICore core)
        {
            InitializeComponent();
            this.core = core;
            test();
        }

        public string GetTypeOfWindow()
        {
            return "move";
        }

        public void UpdateGuiElements()
        {

        }
        public void test()
        {
            listBox1.DataSource = core.dataToList("information");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //Current button event is made for testing the confirmation box. (passowd/userID)

        }
    }
}
