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
    public partial class Log : Form, IGui
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

        #region DataGridView Method
        /// <summary>
        /// Fills the dataGridView with data from the database
        /// </summary>
        private void UpdateLog()
        {
            data.Clear(); //Clears the dataGridView
            core.DataHandler.GetData(LOG_DB).Fill(data); //Fills with data
            //Sets headerText on every column
            dataGridView.Columns["itemNo"].HeaderText = core.Lang.ITEM_NO;
            dataGridView.Columns["description"].HeaderText = core.Lang.DESCRIPTION;
            dataGridView.Columns["date"].HeaderText = core.Lang.TIMESTAMP;
            dataGridView.Columns["user"].HeaderText = core.Lang.USER;
            dataGridView.Columns["operation"].HeaderText = core.Lang.OPERATION;
            dataGridView.Columns["orderNo"].HeaderText = core.Lang.ORDER_NO;
            dataGridView.Columns["amount"].HeaderText = core.Lang.AMOUNT;
            dataGridView.Columns["prevQuantity"].HeaderText = core.Lang.OLD_QUANTITY;
            dataGridView.Columns["newQuantity"].HeaderText = core.Lang.NEW_QUANTITY;

            //If there is data in the dataGridView sets the sort order on the timestamp column to descending 
            if (dataGridView.RowCount != 0 && dataGridView[0, 0].Value != null)
            {
                dataGridView.Sort(dataGridView.Columns["date"], ListSortDirection.Descending);
            }

            //Auto sizes the columns and disables the headercell click sort
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView.ReadOnly = true; //Sets the dataGridView to readOnly
        }
        #endregion

        #region View item information panel Events and Methods
        private void ViewItemButtonClick(object sender, EventArgs e)
        {
            int test = dataGridView.CurrentCell.RowIndex;
            string itemNo = dataGridView[0, test].Value.ToString();
            Item item = core.DataHandler.GetItemFromItemNo(itemNo); //Gets the item 

            //Sets the labels
            usageLabel.Text = item.Usage.ToString();
            itemNoLabel.Text = itemNo;
            nameLabel.Text = item.Description;

            //Finds all the locations where the item is stored
            //And makes a string ("location : amount",) for each location 
            List<Location> locationList = core.DataHandler.LocationToList().FindAll(x => x.ItemNo.Equals(itemNo));
            string locationString = "";
            foreach (var location in locationList)
            {
                locationString += $"{location.ToString()} : {location.Quantity}, ";
            }
            locationString = locationString.Remove(locationString.Length - 2); //Removes the "," from the end
            //Sets the location label to the formated string
            locationLabel.Text = locationString;
            FillLogListView(itemNo);
            itemInfoPanel.Visible = true;
        }

        /// <summary>
        /// Opens the view item panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewItemButtonClick(sender, e);
        }

        /// <summary>
        /// Fills the logListView with logItems from the dataBase
        /// </summary>
        /// <param name="itemNo"></param>
        private void FillLogListView(string itemNo)
        {
            List<ListViewItem> items = new List<ListViewItem>(); //Used for the log of a an item to display it in a listview
            logListView.View = View.Details; //Sets the view mode
            //Gets the logItems and makes a listView item of it with sub items
            List<LogItem> logItems = core.DataHandler.GetLog(itemNo);
            foreach (LogItem logItem in logItems)
            {
                ListViewItem lvi = new ListViewItem(logItem.Date);
                lvi.SubItems.Add(logItem.Operation);
                lvi.SubItems.Add(logItem.Amount);
                lvi.SubItems.Add(logItem.User);
                items.Add(lvi);
            }
            logListView.Items.Clear();
            //Adds them to the logListView
            foreach (var lviItem in items)
            {
                logListView.Items.Add(lviItem);
            }
            //Resizes the columns based on both the header and content in the cells
            logListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            logListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        /// <summary>
        /// Closes the item information panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButtonClick(object sender, EventArgs e)
        {
            itemInfoPanel.Visible = false;
        }
        #endregion

        #region Search TextBox Events
        /// <summary>
        /// When the user types something in the search textbox it it filters the dataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBoxTextChanged(object sender, EventArgs e)
        {
            int outValue = 0; //use for the int try parse only
            data.Clear();
            //Determines if search should search by item no or description
            if (int.TryParse(SearchTextBox.Text, out outValue))
            {
                core.DataHandler.Search(SearchTextBox.Text, LOG_DB, ITEM).Fill(data);
            }
            else
            {
                core.DataHandler.Search(SearchTextBox.Text, LOG_DB, DESCRIPTION).Fill(data);
            }

        }

        /// <summary>
        /// When the user focuses the textbox it removes the predefined text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBoxEnter(object sender, EventArgs e)
        {
            SearchTextBox.TextChanged -= SearchTextBoxTextChanged; //Stops the event from fireing
            SearchTextBox.Text = ""; //Removes text
            SearchTextBox.TextChanged += SearchTextBoxTextChanged;
        }

        /// <summary>
        /// When the user leaves the control it resets the predefined text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBoxLeave(object sender, EventArgs e)
        {
            SearchTextBox.TextChanged -= SearchTextBoxTextChanged; //Stops the event from fireing
            SearchTextBox.Text = $"{core.Lang.ITEM_NO}/{core.Lang.DESCRIPTION}"; ////Sets the text
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
                dataGridView.Columns["itemNo"].HeaderText = core.Lang.ITEM_NO;
                dataGridView.Columns["description"].HeaderText = core.Lang.DESCRIPTION;
                dataGridView.Columns["date"].HeaderText = core.Lang.TIMESTAMP;
                dataGridView.Columns["user"].HeaderText = core.Lang.USER;
                dataGridView.Columns["operation"].HeaderText = core.Lang.OPERATION;
                dataGridView.Columns["orderNo"].HeaderText = core.Lang.ORDER_NO;
                dataGridView.Columns["amount"].HeaderText = core.Lang.AMOUNT;
                dataGridView.Columns["prevQuantity"].HeaderText = core.Lang.OLD_QUANTITY;
                dataGridView.Columns["newQuantity"].HeaderText = core.Lang.NEW_QUANTITY;
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
