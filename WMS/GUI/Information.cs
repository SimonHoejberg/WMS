using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using WMS.Interfaces;
using WMS.WH;
using static WMS.Reference.SearchTerms;
using static WMS.Reference.DataBases;
using System.Text.RegularExpressions;

namespace WMS.GUI
{
    public partial class Information : Form, IGui
    {
        private ICore core;
        private BindingSource bsource;
        private DataTable data;

        public Information(ICore core)
        {
            InitializeComponent();
            this.core = core;
            bsource = new BindingSource();
            data = new DataTable();
            bsource.DataSource = data;
            dataGridView.DataSource = bsource;
            //For use in the view item panel
            logListView.Columns.Add(core.Lang.TIMESTAMP, 40, HorizontalAlignment.Left);
            logListView.Columns.Add(core.Lang.OPERATION, 20, HorizontalAlignment.Left);
            logListView.Columns.Add(core.Lang.AMOUNT, 20, HorizontalAlignment.Left);
            logListView.Columns.Add(core.Lang.USER, 20, HorizontalAlignment.Left);
            //Makes the label word warp
            locationLabel.AutoSize = false;
            locationLabel.MaximumSize = new Size(150, 0);
            locationLabel.AutoSize = true;
            UpdateLang(); //Sets the text on buttons, labels etc.
        }

        private void InformationLoad(object sender, System.EventArgs e)
        {
            MaximizeBox = false;
            UpdateInfo();
        }

        /// <summary>
        /// Updates the dataGridView
        /// </summary>
        public void UpdateGuiElements()
        {
            data.Clear();
            UpdateInfo();
        }

        #region DataGridView Methods
        /// <summary>
        /// Fills the dataGridView with data from the database
        /// </summary>
        private void UpdateInfo()
        {
            //Fills the data into the dataGridView
            core.DataHandler.GetData(INFOMATION_DB).Fill(data);

            //Sets headertext and visiblity
            dataGridView.Columns["itemNo"].HeaderText = core.Lang.ITEM_NO;
            dataGridView.Columns["description"].HeaderText = core.Lang.DESCRIPTION;
            dataGridView.Columns["inStock"].HeaderText = core.Lang.IN_STOCK;
            dataGridView.Columns["location1"].HeaderText = core.Lang.LOCATION;
            dataGridView.Columns["itemUsage"].Visible = false;
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //Auto sizes colums
            }
            dataGridView.ReadOnly = true; //Sets so the dataGridView is only
        }
        #endregion

        #region View item information panel Events and Methods  
        /// <summary>
        /// Shows the item information panel with information about the item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewItemButtonClick(object sender, System.EventArgs e)
        {
            int row = dataGridView.CurrentCell.RowIndex;
            string itemNo = dataGridView[0, row].Value.ToString();
            Item item = core.DataHandler.GetItemFromItemNo(itemNo); //Gets the item 

            //Sets the two label
            usageLabel.Text = item.Usage.ToString();
            itemNoLabel.Text = itemNo;

            //Finds all the locations where the item is stored
            //And makes a string ("location : amount",) for each location  
            List<Location> locationList = core.DataHandler.LocationToList().FindAll(x => x.ItemNo.Equals(itemNo) && x.Quantity > 0);
            string locationString = "";
            foreach (var location in locationList)
            {
                locationString += $"{location.ToString()} : {location.Quantity}, ";
            }
            locationString = locationString.Remove(locationString.Length - 2); //Removes the "," from the end

            //Sets description and location label
            nameLabel.Text = item.Description;
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
        private void CloseButtonClick(object sender, System.EventArgs e)
        {
            itemInfoPanel.Visible = false;
        }
        #endregion

        #region Search Textbox Events
        /// <summary>
        /// When the user types something in the search textbox it it filters the dataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBoxTextChanged(object sender, EventArgs e)
        {
            Regex specialChars = new Regex("^[a-åA-Å0-9]*.");
            int outValue = 0; //use for the int try parse only
            data.Clear();
            //Determines if search should search by item no or description
            if (int.TryParse(searchTextBox.Text, out outValue))
            {
                core.DataHandler.Search(searchTextBox.Text, INFOMATION_DB, ITEM).Fill(data);
            }
            else if (searchTextBox.Text.Equals(specialChars))
            {
                core.DataHandler.Search(searchTextBox.Text, INFOMATION_DB, DESCRIPTION).Fill(data);
            }
            else
            {
                core.DataHandler.GetData(INFOMATION_DB);
            }
        }

        /// <summary>
        /// When the user focuses the textbox it removes the predefined text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBoxEnter(object sender, EventArgs e)
        {
            searchTextBox.TextChanged -= SearchTextBoxTextChanged; //Stops the event from fireing
            searchTextBox.Text = ""; //Removes text
            searchTextBox.TextChanged += SearchTextBoxTextChanged;
        }

        /// <summary>
        /// When the user leaves the control it resets the predefined text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBoxLeave(object sender, EventArgs e)
        {
            searchTextBox.TextChanged -= SearchTextBoxTextChanged; //Stops the event from fireing
            searchTextBox.Text = $"{core.Lang.ITEM_NO}/{core.Lang.DESCRIPTION}"; //Sets the text
            searchTextBox.TextChanged += SearchTextBoxTextChanged;
        }
        #endregion

        #region Language
        /// <summary>
        /// Updates the buttons, labels text to the correct lang
        /// </summary>
        public void UpdateLang()
        {
            searchTextBox.TextChanged -= SearchTextBoxTextChanged;
            searchTextBox.Text = $"{core.Lang.ITEM_NO}/{core.Lang.DESCRIPTION}";
            Text = core.Lang.INFORMATION;
            closeButton.Text = core.Lang.CLOSE;
            viewItemButton.Text = core.Lang.VIEW_ITEM;
            itemNoLabelHead.Text = core.Lang.ITEM_NO;
            nameLabelHead.Text = core.Lang.DESCRIPTION;
            locationLabelHead.Text = $"{core.Lang.LOCATION} : {core.Lang.AMOUNT}";
            usageLabelHead.Text = core.Lang.USAGE;
            if (dataGridView.ColumnCount > 0)
            {
                dataGridView.Columns["itemNo"].HeaderText = core.Lang.ITEM_NO;
                dataGridView.Columns["description"].HeaderText = core.Lang.DESCRIPTION;
                dataGridView.Columns["inStock"].HeaderText = core.Lang.IN_STOCK;
                dataGridView.Columns["location1"].HeaderText = core.Lang.LOCATION;
            }
            logListView.Columns[0].Text = core.Lang.TIMESTAMP;
            logListView.Columns[1].Text = core.Lang.OPERATION;
            logListView.Columns[2].Text = core.Lang.AMOUNT;
            logListView.Columns[3].Text = core.Lang.USER;
            logListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            logListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            searchTextBox.TextChanged += SearchTextBoxTextChanged;
        }
        #endregion

    }
}

