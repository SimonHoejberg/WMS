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
        IBridge bridge;
        public Main(IBridge bridge)
        {
            this.bridge = bridge;
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void information_pbox_Click(object sender, EventArgs e)
        {
            bridge.OpenInformation();
        }

        private void log_pbox_Click(object sender, EventArgs e)
        {
            bridge.OpenLog();
        }

        private void move_pbox_Click(object sender, EventArgs e)
        {
            bridge.OpenMove();
        }

        private void register_pbox_Click(object sender, EventArgs e)
        {
            bridge.OpenRegister();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bridge.OpenWaste();
        }
    }
}
