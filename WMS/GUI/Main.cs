﻿using System;
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
        private ICore core;
        public Main()
        {
            InitializeComponent();
        }

        private void MainLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
        }

        public ICore Core { set { this.core = value; } }

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
    }
}
