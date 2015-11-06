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
    public partial class Main : Form , IMain
    {
        ICore core;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Width = 136;
            this.Height = 556;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        public ICore Core { set { this.core = value; } }

        private void information_pbox_Click(object sender, EventArgs e)
        {
            core.WindowHandler.OpenInformation();
        }

        private void log_pbox_Click(object sender, EventArgs e)
        {
            core.WindowHandler.OpenLog();
        }

        private void move_pbox_Click(object sender, EventArgs e)
        {
            core.WindowHandler.OpenMove();
        }

        private void register_pbox_Click(object sender, EventArgs e)
        {
            core.WindowHandler.OpenRegister();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            core.WindowHandler.OpenWaste();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            core.WindowHandler.OpenReduce();
        }
    }
}
