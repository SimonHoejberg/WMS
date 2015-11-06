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
    public partial class Waste : Form , IGui
    {
        public Waste(ICore core)
        {
            InitializeComponent();
        }

        public string GetTypeOfWindow()
        {
            return "waste";
        }

        public void UpdateGuiElements()
        {

        }

        private void Waste_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
    }
}
