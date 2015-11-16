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
            this.Text = Lang.LOG;
            this.closeButton.Text = Lang.CLOSE;
            this.viewItemButton.Text = Lang.VIEW_ITEM;
            this.label4.Text = Lang.DESCRIPTION;
            this.label1.Text = Lang.SIZE;
            this.label2.Text = Lang.LOCATION;
            this.label3.Text = Lang.USAGE;
            this.sortButton.Text = Lang.SORT;

        }

        public Log(ICore core, string itemNo)
        {
            this.core = core;
            InitializeComponent();
            UpdateLog(core.DataHandler.GetDataFromItemNo(itemNo,DataBaseTypes.LOG));
            sortToggle = true;
            sortButton.Text = Lang.UNSORT;
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
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].HeaderText = Lang.ITEM_NO;
            dataGridView.Columns[2].HeaderText = Lang.DESCRIPTION;
            dataGridView.Columns[3].HeaderText = Lang.TIMESTAMP;
            dataGridView.Columns[4].HeaderText = Lang.USER;
            dataGridView.Columns[5].HeaderText = Lang.OPERATION;
            dataGridView.Columns[6].HeaderText = Lang.AMOUNT;
            if (dataGridView[0, 0].Value != null)
            {
                dataGridView.Sort(dataGridView.Columns[0], ListSortDirection.Descending);
            }

            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView.Columns[i].ReadOnly = true;
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
                sortButton.Text = Lang.UNSORT;
            }
            else if(sortToggle)
            {
                sortToggle = false;
                UpdateLog();
                sortButton.Text = Lang.SORT;
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
