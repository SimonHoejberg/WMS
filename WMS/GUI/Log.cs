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
using WMS.Reference;
using WMS.WH;

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

        public Log(ICore core, string itemNo)
        {
            this.core = core;
            InitializeComponent();
            UpdateLog(core.DataHandler.GetDataFromItemNo(itemNo,DataBaseTypes.LOG));
            sortToggle = true;
            sortButton.Text = "Unsort";
        }

        private void UpdateLog()
        {
            UpdateLog(core.DataHandler.GetData(DataBaseTypes.LOG));
        }

        private void UpdateLog(MySqlDataAdapter mysqlData)
        {
            BindingSource bsource = new BindingSource();
            DataTable data = new DataTable();

            bsource.DataSource = data;
            dataGridView.DataSource = bsource;

            mysqlData.Fill(data);
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }


        public void UpdateGuiElements()
        {
            UpdateLog();
        }

        public string GetTypeOfWindow()
        {
            return WindowTypes.LOG;
        }

        private void ViewItemButtonClick(object sender, EventArgs e)
        {
            itemInfoPanel.Visible = true;
            int test = dataGridView.CurrentCell.RowIndex;
            string itemNo = dataGridView[1, test].Value.ToString();
            Item item = core.DataHandler.GetItemFromItemNo(itemNo);
            sizeLabel.Text = item.Size.ToString();
            usageLabel.Text = item.Usage.ToString();
            nameLabel.Text = item.Description;
            logListBox.DataSource = core.DataHandler.GetLog(itemNo);
        }

        private void SortButtonClick(object sender, EventArgs e)
        {
            if(dataGridView.CurrentCell != null && !sortToggle)
            {
                sortToggle = true;
                string temp = dataGridView[1, dataGridView.CurrentCell.RowIndex].Value.ToString();
                UpdateLog(core.DataHandler.GetDataFromItemNo(temp, DataBaseTypes.LOG));
                sortButton.Text = "Unsort";
            }
            else if(sortToggle)
            {
                sortToggle = false;
                UpdateLog();
                sortButton.Text = "Sort";
            }
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            itemInfoPanel.Visible = false;
        }

        private void LogLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
    }
}
