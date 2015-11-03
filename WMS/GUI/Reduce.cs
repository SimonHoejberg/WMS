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
        private bool First = true;
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
                string[] itemNo = new string[5];
                string output = comboBox2.SelectedItem.ToString();
                itemNo = output.Split(' ');

                BindingSource bsource = new BindingSource();
                DataTable data = new DataTable();

                bsource.DataSource = data;
                dataGridView3.DataSource = bsource;
                /*for (int i = 0; i < 10; i++)
                {
                    data.Rows[i].Add(" ");
                }*/

                if (First)
                {
                    core.GetDataFromItemNo(itemNo[1], "information").Fill(data);
                    First = false;
                }
                else
                {
                    data.Rows.Add(core.GetDataFromItemNo(itemNo[1], "information"));
                }
                core.GetDataFromItemNo(itemNo[1], "information").Fill(data);

                dataGridView3.Columns[2].Visible = false;
                dataGridView3.Columns[4].Visible = false;
                dataGridView3.Columns[5].Visible = false;
                data.Columns.Add("Quantity");
                for (int i = 0; i < dataGridView3.ColumnCount; i++)
                {
                    dataGridView3.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            
        }
    }
}
