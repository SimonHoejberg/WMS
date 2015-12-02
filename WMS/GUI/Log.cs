using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WMS.Interfaces;
using static WMS.Reference.SearchTerms;
using static WMS.Reference.DataBases;
using WMS.WH;

namespace WMS.GUI
{
    public partial class Log : Form , IGui
    {
        private ICore core;
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
            //For use in the view item panel
            logListView.Columns.Add(core.Lang.TIMESTAMP, 40, HorizontalAlignment.Left);
            logListView.Columns.Add(core.Lang.OPERATION, 20, HorizontalAlignment.Left);
            logListView.Columns.Add(core.Lang.AMOUNT, 20, HorizontalAlignment.Left);
            logListView.Columns.Add(core.Lang.USER, 20, HorizontalAlignment.Left);
            //Makes the label word warp kind of
            locationLabel.AutoSize = false;
            locationLabel.MaximumSize = new Size(150, 0);
            locationLabel.AutoSize = true;
            UpdateLang(); //Sets the text on buttons, labels etc.

        }

        /// <summary>
        /// When the form is show it fills in data to prevent errors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
            UpdateLog();
        }

        /// <summary>
        /// Updates the dataGridView
        /// </summary>
        public void UpdateGuiElements()
        {
            UpdateLog();
        }

        #region DataGridView Methode
        private void UpdateLog()
        {
            data.Clear();
            core.DataHandler.GetData(LOG_DB).Fill(data);
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
        #endregion

        #region View item information panel Events and Methodes
        private void ViewItemButtonClick(object sender, EventArgs e)
        {
                int test = dataGridView.CurrentCell.RowIndex;
                string itemNo = dataGridView[0, test].Value.ToString();
                Item item = core.DataHandler.GetItemFromItemNo(itemNo);
                usageLabel.Text = item.Usage.ToString();
                itemNoLabel.Text = itemNo;
                nameLabel.Text = item.Description;
                List<Location> locationList = core.DataHandler.LocationToList().FindAll(x => x.ItemNo.Equals(itemNo));
                string temp = "";
                foreach (var location in locationList)
                {
                    temp += $"{location.ToString()} : {location.Quantity}, ";
                }
                temp = temp.Remove(temp.Length - 2);
                locationLabel.Text = temp;
                FillLogListView(itemNo);
                itemInfoPanel.Visible = true;
        }

        private void FillLogListView(string itemNo)
        {
            List<ListViewItem> items = new List<ListViewItem>();
            logListView.View = View.Details;
            List<LogItem> logItems = core.DataHandler.GetLog(itemNo);
            foreach (LogItem logItem in logItems)
            {
                ListViewItem lvi = new ListViewItem(logItem.Date);
                lvi.SubItems.Add(logItem.Operation);
                lvi.SubItems.Add(logItem.Amount);
                lvi.SubItems.Add(logItem.User);
                items.Add(lvi);
            }
            foreach (var lviItem in items)
            {
                logListView.Items.Add(lviItem);
            }
            logListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            logListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            itemInfoPanel.Visible = false;
        }
#endregion

        #region Search TextBox Events
        private void SearchTextBoxTextChanged(object sender, EventArgs e)
        {
            int a = 0;
            data.Clear();
            if (int.TryParse(SearchTextBox.Text, out a))
            {
                core.DataHandler.Search(SearchTextBox.Text, LOG_DB, ITEM).Fill(data);
            }
            else
            {
                core.DataHandler.Search(SearchTextBox.Text, LOG_DB, DESCRIPTION).Fill(data);
            }
            
        }

        private void SearchTextBoxEnter(object sender, EventArgs e)
        {
            SearchTextBox.TextChanged -= SearchTextBoxTextChanged;
            SearchTextBox.Text = "";
            SearchTextBox.TextChanged += SearchTextBoxTextChanged;
        }

        private void SearchTextBoxLeave(object sender, EventArgs e)
        {
            SearchTextBox.TextChanged -= SearchTextBoxTextChanged;
            SearchTextBox.Text = $"{core.Lang.ITEM_NO}/{core.Lang.DESCRIPTION}";
            SearchTextBox.TextChanged += SearchTextBoxTextChanged;
        }
        #endregion

        #region Language
        public void UpdateLang()
        {
            SearchTextBox.TextChanged -= SearchTextBoxTextChanged;
            Text = core.Lang.LOG;
            closeButton.Text = core.Lang.CLOSE;
            SearchTextBox.Text = $"{core.Lang.ITEM_NO}/{core.Lang.DESCRIPTION}";
            viewItemButton.Text = core.Lang.VIEW_ITEM;
            itemNoLabelHead.Text = core.Lang.ITEM_NO;
            nameLabelHead.Text = core.Lang.DESCRIPTION;
            locationLabelHead.Text = $"{core.Lang.LOCATION} : {core.Lang.AMOUNT}";
            usageLabelHead.Text = core.Lang.USAGE;
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
            logListView.Columns[0].Text = core.Lang.TIMESTAMP;
            logListView.Columns[1].Text = core.Lang.OPERATION;
            logListView.Columns[2].Text = core.Lang.AMOUNT;
            logListView.Columns[3].Text = core.Lang.USER;
            logListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            logListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            SearchTextBox.TextChanged += SearchTextBoxTextChanged;
        }
        #endregion
    }
}
