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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        public ICore Core { set { this.core = value; } }

        private void information_pbox_Click(object sender, EventArgs e)
        {
            core.OpenInformation();
        }

        private void log_pbox_Click(object sender, EventArgs e)
        {
            core.OpenLog();
        }

        private void move_pbox_Click(object sender, EventArgs e)
        {
            core.OpenMove();
        }

        private void register_pbox_Click(object sender, EventArgs e)
        {
            core.OpenRegister();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            core.OpenWaste();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            core.OpenReduce();
        }
    }
}
