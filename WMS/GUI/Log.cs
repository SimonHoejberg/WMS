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
        ICore core;

        public Log(ICore core)
        {
            this.core = core;
            InitializeComponent();
            updateLog();
        }

        private void updateLog()
        {
            BindingSource bsource = new BindingSource();
            DataTable data = new DataTable();

            bsource.DataSource = data;
            dataGridView5.DataSource = bsource;

            core.getLog().Fill(data);
        }


        public void UpdateGuiElements()
        {

        }

        public string GetTypeOfWindow()
        {
            throw new NotImplementedException();
        }
    }
}
