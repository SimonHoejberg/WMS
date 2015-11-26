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
using static WMS.Reference.DataBaseValues;
using static WMS.Reference.DataBaseTypes;
using WMS.WH;

namespace WMS.GUI
{
    public partial class Log : Form , IGui
    {
        private ICore core;
        private bool sortToggle = false;
        private ILang lang;
        private MySqlDataAdapter inputFromInfo = null;
        BindingSource bsource;
        DataTable data;

        public Log(ICore core, ILang lang)
        {
            InitializeComponent();
            bsource = new BindingSource();
            data = new DataTable();
            bsource.DataSource = data;
            dataGridView.DataSource = bsource;
            this.core = core;
            this.lang = lang;
            UpdateLang(lang);

        }

        public Log(ICore core, string itemNo, ILang lang)
        {
            this.core = core;
            this.lang = lang;
            InitializeComponent();
            bsource = new BindingSource();
            data = new DataTable();
            bsource.DataSource = data;
            dataGridView.DataSource = bsource;
            inputFromInfo = core.DataHandler.GetDataFromItemNo(itemNo, LOG);
            sortToggle = true;
            UpdateLang(lang);
            sortButton.Text = lang.UNSORT;
        }

        private void UpdateLog()
        {
            UpdateLog(core.DataHandler.GetData(LOG));
        }

        private void UpdateLog(MySqlDataAdapter mysqlData)
        {

            mysqlData.Fill(data);
            dataGridView.Columns[0].HeaderText = lang.ITEM_NO;
            dataGridView.Columns[1].HeaderText = lang.DESCRIPTION;
            dataGridView.Columns[2].HeaderText = lang.TIMESTAMP;
            dataGridView.Columns[3].HeaderText = lang.USER;
            dataGridView.Columns[4].HeaderText = lang.OPERATION;
            dataGridView.Columns[5].HeaderText = lang.AMOUNT;
            if (dataGridView[0, 0].Value != null)
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
                UpdateLog(core.DataHandler.GetDataFromItemNo(temp, LOG));
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
            textBox1.TextChanged -= textBox1_TextChanged;
            this.lang = lang;
            Text = lang.LOG;
            closeButton.Text = lang.CLOSE;
            textBox1.Text = $"{lang.ITEM_NO}/{lang.DESCRIPTION}";
            viewItemButton.Text = lang.VIEW_ITEM;
            label4.Text = lang.DESCRIPTION;
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
                dataGridView.Columns[0].HeaderText = lang.ITEM_NO;
                dataGridView.Columns[1].HeaderText = lang.DESCRIPTION;
                dataGridView.Columns[2].HeaderText = lang.TIMESTAMP;
                dataGridView.Columns[3].HeaderText = lang.USER;
                dataGridView.Columns[4].HeaderText = lang.OPERATION;
                dataGridView.Columns[5].HeaderText = lang.AMOUNT;
            }
            textBox1.TextChanged += textBox1_TextChanged;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int a = 0;
            data.Clear();
            if (int.TryParse(textBox1.Text, out a))
            {
                core.DataHandler.Search(textBox1.Text, LOG, ITEM).Fill(data);
            }
            else
            {
                core.DataHandler.Search(textBox1.Text, LOG, DESCRIPTION).Fill(data);
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
            textBox1.Text = $"{lang.ITEM_NO}/{lang.DESCRIPTION}";
            textBox1.TextChanged += textBox1_TextChanged;
        }
    }
}
