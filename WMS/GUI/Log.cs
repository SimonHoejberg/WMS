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
    public partial class Log : Form , IGui
    {
        IBridge bridge;

        public Log(IBridge bridge)
        {
            this.bridge = bridge;
            InitializeComponent();
            updateLog();
        }

        private void updateLog()
        {
            BindingSource bsource = new BindingSource();
            DataTable data = new DataTable();

            bsource.DataSource = data;
            dataGridView5.DataSource = bsource;

            bridge.getLog().Fill(data);
        }


        public void UpdateGuiElements()
        {

        }
    }
}
