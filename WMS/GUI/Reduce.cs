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
    public partial class Reduce : Form , IGui
    {
        public Reduce(ICore core)
        {
            InitializeComponent();
        }

        public string GetTypeOfWindow()
        {
            throw new NotImplementedException();
        }

        public void UpdateGuiElements()
        {

        }
    }
}
