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
using MySql.Data.MySqlClient;

namespace WMS.GUI
{
    public partial class Log : Form , IGui
    {
        private ICore core;
        private bool sortToggle = false;

        public Log(ICore core)
        {
            this.core = core;
            InitializeComponent();
            UpdateLog();
        }

        private void UpdateLog()
        {
            UpdateLog(core.getData(GetTypeOfWindow()));
        }

        private void UpdateLog(MySqlDataAdapter mysqlData)
        {
            BindingSource bsource = new BindingSource();
            DataTable data = new DataTable();

            bsource.DataSource = data;
            dataGridView5.DataSource = bsource;

            mysqlData.Fill(data);
            for (int i = 0; i < dataGridView5.ColumnCount; i++)
            {
                dataGridView5.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }


        public void UpdateGuiElements()
        {
            UpdateLog();
        }

        public string GetTypeOfWindow()
        {
            return "log";
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void Sort_Click(object sender, EventArgs e)
        {
            if(dataGridView5.CurrentCell != null && !sortToggle)
            {
                sortToggle = true;
                string temp = dataGridView5[1, dataGridView5.CurrentCell.RowIndex].Value.ToString();
                UpdateLog(core.GetFilterLog(temp));
                button9.Text = "Unsort";
            }
            else if(sortToggle)
            {
                sortToggle = false;
                UpdateLog();
                button9.Text = "Sort";
            }
        }
    }
}
