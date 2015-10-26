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
    public partial class Main : Form
    {
        IGui gui;
        public Main(IGui gui)
        {
            this.gui = gui;
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void information_pbox_Click(object sender, EventArgs e)
        {
            gui.OpenInformation();
        }

        private void log_pbox_Click(object sender, EventArgs e)
        {
            gui.OpenLog();
        }

        private void move_pbox_Click(object sender, EventArgs e)
        {
            gui.OpenMove();
        }

        private void register_pbox_Click(object sender, EventArgs e)
        {
            gui.OpenRegister();
        }

        private void remove_pbox_Click(object sender, EventArgs e)
        {
            gui.OpenRemove();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            gui.OpenWaste();
        }
    }
}
