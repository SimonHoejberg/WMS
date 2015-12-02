using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using WMS.Interfaces;
using WMS.WH;
using static WMS.Reference.SearchTerms;
using static WMS.Reference.DataBases;

namespace WMS.GUI
{
    public partial class Information : Form, IGui
    {
        private ICore core;
        private string itemNo; //Used for the panel because it is needed in more methodes 
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
            UpdateLang(); //Sets the text on buttons, labels etc.
        }

        private void InformationLoad(object sender, System.EventArgs e)
        {
            MaximizeBox = false;
            UpdateInfo();
        }

        /// <summary>
        /// Fills the dataGridView with data from the database
        /// </summary>
        private void UpdateInfo()
        {
            //Fills the data into the dataGridView
            core.DataHandler.GetData(INFOMATION_DB).Fill(data);

            //Sets headertext and visiblity
            dataGridView.Columns[0].HeaderText = core.Lang.ITEM_NO;
            dataGridView.Columns[1].HeaderText = core.Lang.DESCRIPTION;
            dataGridView.Columns[2].HeaderText = core.Lang.IN_STOCK;
            dataGridView.Columns[3].HeaderText = core.Lang.LOCATION;
            dataGridView.Columns[4].Visible = false;
            //Auto sizes colums and sets readonly 
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView.Columns[i].ReadOnly = true;
            }
        }

        /// <summary>
        /// Updates the dataGridView
        /// </summary>
        public void UpdateGuiElements()
        {
            UpdateInfo();
        }

        /// <summary>
        /// Shows the item information panel with information about the item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewItemButtonClick(object sender, System.EventArgs e)
        {
            int row = dataGridView.CurrentCell.RowIndex;
            itemNo = dataGridView[0, row].Value.ToString();
            Item item = core.DataHandler.GetItemFromItemNo(itemNo); //Gets the item 
            
            //Sets the two label
            usageLabel.Text = item.Usage.ToString();
            itemNoLabel.Text = itemNo;
            
            //Finds all the locations where the item is stored
            //And makes a string ("location",) for each location  
            List<Location> locationList = core.DataHandler.LocationToList().FindAll(x => x.ItemNo.Equals(itemNo));
            string temp = "";
            foreach (var location in locationList)
            {
                temp += $"{location.ToString()}, ";
            }
            temp = temp.Remove(temp.Length - 2); //Removes the "," 
            
            //Sets description and location label
            nameLabel.Text = item.Description;
            locationLabel.Text = temp;
            FillLogListView();
            itemInfoPanel.Visible = true;
        }

        /// <summary>
        /// Fills the logListView with logItems from the dataBase
        /// </summary>
        private void FillLogListView()
        {
            List<ListViewItem> items = new List<ListViewItem>(); //Used for the log of a an item to display it in a listview
            logListView.View = View.Details; //Sets the view mode
            //Gets the logItems and 
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

        private void CloseButtonClick(object sender, System.EventArgs e)
        {
            itemInfoPanel.Visible = false;
        }

        private void LogButtonClick(object sender, System.EventArgs e)
        {
            core.WindowHandler.OpenLog(itemNo);
        }

        public void UpdateLang()
        {
            SearchTextBox.TextChanged -= SearchTextBoxTextChanged;
            SearchTextBox.Text = $"{core.Lang.ITEM_NO}/{core.Lang.DESCRIPTION}";
            Text = core.Lang.INFORMATION;
            closeButton.Text = core.Lang.CLOSE;
            viewItemButton.Text = core.Lang.VIEW_ITEM;
            logButton.Text = core.Lang.LOG;
            itemNoLabelHead.Text = core.Lang.ITEM_NO;
            nameLabelHead.Text = core.Lang.DESCRIPTION;
            locationLabelHead.Text = core.Lang.LOCATION;
            usageLabelHead.Text = core.Lang.USAGE;
            if (dataGridView.ColumnCount > 0)
            {
                dataGridView.Columns[0].HeaderText = core.Lang.ITEM_NO;
                dataGridView.Columns[1].HeaderText = core.Lang.DESCRIPTION;
                dataGridView.Columns[2].HeaderText = core.Lang.IN_STOCK;
                dataGridView.Columns[3].HeaderText = core.Lang.LOCATION;
            }
            logListView.Columns[0].Text = core.Lang.TIMESTAMP;
            logListView.Columns[1].Text = core.Lang.OPERATION;
            logListView.Columns[2].Text = core.Lang.AMOUNT;
            logListView.Columns[3].Text = core.Lang.USER;
            logListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            logListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            SearchTextBox.TextChanged += SearchTextBoxTextChanged;
        }


        private void SearchTextBoxTextChanged(object sender, EventArgs e)
        {
            int a = 0;
            data?.Clear();
            if (int.TryParse(SearchTextBox.Text, out a))
            {
                core.DataHandler.Search(SearchTextBox.Text, INFOMATION_DB, ITEM).Fill(data);
            }
            else
            {
                core.DataHandler.Search(SearchTextBox.Text, INFOMATION_DB, DESCRIPTION).Fill(data);
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
    }
}
