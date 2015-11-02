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
using WMS.Core;

namespace WMS.GUI
{
    public partial class Reduce : Form , IGui
    {
        private ICore core;
        private bool Run = false;
        public Reduce(ICore core)
        {
            this.core = core;
            InitializeComponent();
            MakeComboBox();
        }

        public string GetTypeOfWindow()
        {
            return "reduce";
        }

        public void UpdateGuiElements()
        {

        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MakeComboBox()
        {
            comboBox2.DataSource = core.dataToList("information");
            Run = true;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Run)
            {
                string[] test = new string[5];
                string output = comboBox2.SelectedItem.ToString();
                test = output.Split(' ');
                BindingSource bsource = new BindingSource();
                DataTable data = new DataTable();
                
            }
            
        }
    }
}
