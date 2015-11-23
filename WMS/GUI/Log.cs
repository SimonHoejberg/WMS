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
        private ILang lang;
        private MySqlDataAdapter inputFromInfo = null;
        public Log(ICore core, ILang lang)
        {
            this.core = core;
            this.lang = lang;
            InitializeComponent();
            UpdateLang(lang);

        }

        public Log(ICore core, string itemNo, ILang lang)
        {
            this.core = core;
            this.lang = lang;
            InitializeComponent();
            inputFromInfo = core.DataHandler.GetDataFromItemNo(itemNo, DataBaseTypes.LOG);
            sortToggle = true;
            UpdateLang(lang);
            sortButton.Text = lang.UNSORT;
        }
        public Form Main { get; set; }

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
            dataGridView.Columns[1].HeaderText = lang.ITEM_NO;
            dataGridView.Columns[2].HeaderText = lang.DESCRIPTION;
            dataGridView.Columns[3].HeaderText = lang.TIMESTAMP;
            dataGridView.Columns[4].HeaderText = lang.USER;
            dataGridView.Columns[5].HeaderText = lang.OPERATION;
            dataGridView.Columns[6].HeaderText = lang.AMOUNT;
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
            if (dataGridView.CurrentCell != null)
            {
                itemInfoPanel.Visible = true;
                int test = dataGridView.CurrentCell.RowIndex;
                string itemNo = dataGridView[1, test].Value.ToString();
                Item item = core.DataHandler.GetItemFromItemNo(itemNo);
                sizeLabel.Text = item.Size.ToString();
                usageLabel.Text = item.Usage.ToString();
                nameLabel.Text = item.Description;
                locationLabel.Text = item.Location;
                logListBox.DataSource = core.DataHandler.GetLog(itemNo);
            }
        }

        private void SortButtonClick(object sender, EventArgs e)
        {
            if(dataGridView.CurrentCell != null && !sortToggle)
            {
                sortToggle = true;
                string temp = dataGridView[1, dataGridView.CurrentCell.RowIndex].Value.ToString();
                UpdateLog(core.DataHandler.GetDataFromItemNo(temp, DataBaseTypes.LOG));
                sortButton.Text = lang.UNSORT;
            }
            else if(sortToggle)
            {
                sortToggle = false;
                UpdateLog();
                sortButton.Text = lang.SORT;
            }
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            itemInfoPanel.Visible = false;
        }

        private void LogLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
            if(inputFromInfo != null)
            {
                UpdateLog(inputFromInfo);
            }
            else
            {
                UpdateLog();
            }
        }

        public void UpdateLang(ILang lang)
        {
            this.lang = lang;
            Text = lang.LOG;
            closeButton.Text = lang.CLOSE;
            viewItemButton.Text = lang.VIEW_ITEM;
            label4.Text = lang.DESCRIPTION;
            label1.Text = lang.SIZE;
            label2.Text = lang.LOCATION;
            label3.Text = lang.USAGE;
            if (sortToggle)
            {
                sortButton.Text = lang.UNSORT;
                sortToggle = false;
            }
            else
            {
                sortButton.Text = lang.SORT;
                sortToggle = true;
            }
            if (dataGridView.ColumnCount > 0)
            {
                dataGridView.Columns[1].HeaderText = lang.ITEM_NO;
                dataGridView.Columns[2].HeaderText = lang.DESCRIPTION;
                dataGridView.Columns[3].HeaderText = lang.TIMESTAMP;
                dataGridView.Columns[4].HeaderText = lang.USER;
                dataGridView.Columns[5].HeaderText = lang.OPERATION;
                dataGridView.Columns[6].HeaderText = lang.AMOUNT;
            }
        }
    }
}
