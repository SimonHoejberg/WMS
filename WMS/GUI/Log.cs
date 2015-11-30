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
using static WMS.Reference.SearchTerms;
using static WMS.Reference.DataBases;
using WMS.WH;

namespace WMS.GUI
{
    public partial class Log : Form , IGui
    {
        private ICore core;
        private bool sortToggle = false;
        private MySqlDataAdapter inputFromInfo = null;
        BindingSource bsource;
        DataTable data;

        public Log(ICore core)
        {
            InitializeComponent();
            bsource = new BindingSource();
            data = new DataTable();
            bsource.DataSource = data;
            dataGridView.DataSource = bsource;
            this.core = core;
            UpdateLang();

        }

        public Log(ICore core, string itemNo)
        {
            this.core = core;
            InitializeComponent();
            bsource = new BindingSource();
            data = new DataTable();
            bsource.DataSource = data;
            dataGridView.DataSource = bsource;
            inputFromInfo = core.DataHandler.GetDataFromItemNo(itemNo, LOG_DB);
            sortToggle = true;
            UpdateLang();
            sortButton.Text = core.Lang.UNSORT;
        }

        private void UpdateLog()
        {
            UpdateLog(core.DataHandler.GetData(LOG_DB));
        }

        private void UpdateLog(MySqlDataAdapter mysqlData)
        {

            mysqlData.Fill(data);
            dataGridView.Columns[0].HeaderText = core.Lang.ITEM_NO;
            dataGridView.Columns[1].HeaderText = core.Lang.DESCRIPTION;
            dataGridView.Columns[2].HeaderText = core.Lang.TIMESTAMP;
            dataGridView.Columns[3].HeaderText = core.Lang.USER;
            dataGridView.Columns[4].HeaderText = core.Lang.OPERATION;
            dataGridView.Columns[5].HeaderText = core.Lang.ORDER_NO;
            dataGridView.Columns[6].HeaderText = core.Lang.AMOUNT;
            dataGridView.Columns[7].HeaderText = core.Lang.OLD_QUANTITY;
            dataGridView.Columns[8].HeaderText = core.Lang.NEW_QUANTITY;

            if (dataGridView.RowCount != 0 && dataGridView[0, 0].Value != null)
            {
                dataGridView.Sort(dataGridView.Columns[2], ListSortDirection.Descending);
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

        private void ViewItemButtonClick(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell != null)
            {
                itemInfoPanel.Visible = true;
                int test = dataGridView.CurrentCell.RowIndex;
                string itemNo = dataGridView[0, test].Value.ToString();
                Item item = core.DataHandler.GetItemFromItemNo(itemNo);
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
                string temp = dataGridView[0, dataGridView.CurrentCell.RowIndex].Value.ToString();
                UpdateLog(core.DataHandler.GetDataFromItemNo(temp, LOG_DB));
                sortButton.Text = core.Lang.UNSORT;
            }
            else if(sortToggle)
            {
                sortToggle = false;
                UpdateLog();
                sortButton.Text = core.Lang.SORT;
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

        public void UpdateLang()
        {
            textBox1.TextChanged -= textBox1_TextChanged;
            Text = core.Lang.LOG;
            closeButton.Text = core.Lang.CLOSE;
            textBox1.Text = $"{core.Lang.ITEM_NO}/{core.Lang.DESCRIPTION}";
            viewItemButton.Text = core.Lang.VIEW_ITEM;
            label4.Text = core.Lang.DESCRIPTION;
            label2.Text = core.Lang.LOCATION;
            label3.Text = core.Lang.USAGE;
            if (sortToggle)
            {
                sortButton.Text = core.Lang.UNSORT;
            }
            else
            {
                sortButton.Text = core.Lang.SORT;
            }
            if (dataGridView.ColumnCount > 0)
            {
                dataGridView.Columns[0].HeaderText = core.Lang.ITEM_NO;
                dataGridView.Columns[1].HeaderText = core.Lang.DESCRIPTION;
                dataGridView.Columns[2].HeaderText = core.Lang.TIMESTAMP;
                dataGridView.Columns[3].HeaderText = core.Lang.USER;
                dataGridView.Columns[4].HeaderText = core.Lang.OPERATION;
                dataGridView.Columns[5].HeaderText = core.Lang.ORDER_NO;
                dataGridView.Columns[6].HeaderText = core.Lang.AMOUNT;
                dataGridView.Columns[7].HeaderText = core.Lang.OLD_QUANTITY;
                dataGridView.Columns[8].HeaderText = core.Lang.NEW_QUANTITY;
            }
            textBox1.TextChanged += textBox1_TextChanged;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int a = 0;
            data.Clear();
            if (int.TryParse(textBox1.Text, out a))
            {
                core.DataHandler.Search(textBox1.Text, LOG_DB, ITEM).Fill(data);
            }
            else
            {
                core.DataHandler.Search(textBox1.Text, LOG_DB, DESCRIPTION).Fill(data);
            }
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.TextChanged -= textBox1_TextChanged;
            textBox1.Text = "";
            textBox1.TextChanged += textBox1_TextChanged;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.TextChanged -= textBox1_TextChanged;
            textBox1.Text = $"{core.Lang.ITEM_NO}/{core.Lang.DESCRIPTION}";
            textBox1.TextChanged += textBox1_TextChanged;
        }
    }
}
