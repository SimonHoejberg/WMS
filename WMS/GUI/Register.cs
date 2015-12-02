using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using WMS.Interfaces;
using WMS.WH;

namespace WMS.GUI
{
    public partial class Register : Form, IGui
    {
        private ICore core;
        private BindingSource bsource = new BindingSource();
        private DataTable data = new DataTable();
        private string orderNo;

        public Register(ICore core)
        {
            this.core = core;
            InitializeComponent();
            Search(); //Sets the suggestiongs source
            UpdateLang(); //Sets the language
        }

        private void RegisterLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        public void UpdateGuiElements()
        {
            //NOOP
        }

        #region DataGidView Methods and Events 
        /// <summary>
        /// Updates the dataGridView with the data from the Sql server based on a order no
        /// </summary>
        /// <param name="orderNo"></param>
        private void UpdateDataGridView(string orderNo)
        { 
            dataGridView.CellValueChanged -= DataGridViewCellValueChanged; //Unsubscribes from the event because the event fires when we fill in data
            data.Clear();   //Clears the dataGridView if a new order is choosen
            bsource.DataSource = data;
            dataGridView.DataSource = bsource;
            core.DataHandler.GetDataFromOrderNo(orderNo).Fill(data); //Fills the dataGridView with data from the server

            //Sets up what the columns based on the data from the server with the correct headerText
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].HeaderText = core.Lang.ORDER_NO;
            dataGridView.Columns[2].HeaderText = core.Lang.ITEM_NO;
            dataGridView.Columns[3].HeaderText = core.Lang.DESCRIPTION;
            dataGridView.Columns[4].HeaderText = core.Lang.EXPECTED_AMOUNT;
            
            //Adds a new column that is no on the database if doesnot already exist
            if (!data.Columns.Contains(core.Lang.AMOUNT))
            {
                data.Columns.Add(core.Lang.AMOUNT);
            }

            //Sets the auto size mode and sets the columns to read only
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                if (i < dataGridView.ColumnCount - 1)
                {
                    dataGridView.Columns[i].ReadOnly = true;
                }
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            //Sets the amount from the order to the expected amount
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                dataGridView[5, i].Value = dataGridView[4, i].Value;
            }

            dataGridView.CellValueChanged += DataGridViewCellValueChanged; //Resubscribes to the event
        }

        /// <summary>
        /// When a cell in the dataGridView changes this event is fired to check if content in cell is okay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView.CellValueChanged -= DataGridViewCellValueChanged; //Stop the event from fireing again
            string value = dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
            int tempInt = 0; //only use to find out if it is a number
            //Shows error messages if the something is wrong in the cell that changes and set the value to null
            if (value != null)
            {
                if (!int.TryParse(value, out tempInt))
                {
                    MessageBox.Show(core.Lang.MUST_BE_A_NUMER, core.Lang.ERROR);
                    dataGridView[e.ColumnIndex, e.RowIndex].Value = null;
                }
                else if (tempInt < 0)
                {
                    MessageBox.Show(core.Lang.MUST_BE_A_POSITIVE, core.Lang.ERROR);
                    dataGridView[e.ColumnIndex, e.RowIndex].Value = null;
                }
            }
            dataGridView.CellValueChanged += DataGridViewCellValueChanged; //Subscribes to the event again

        }
        #endregion

        #region SearchTextBox Events and Methods

        /// <summary>
        /// Sets up the suggestions in the textbox
        /// </summary>
        private void Search()
        {
            var source = new AutoCompleteStringCollection();
            List<Order> temp = core.DataHandler.OrderToList();
            foreach (var item in temp)
            {
                source.Add(item.OrderNo.ToString());
            }
            searchTextBox.AutoCompleteCustomSource = source;
        }

        /// <summary>
        /// Removes the predefined text when the user enters the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBoxEnter(object sender, EventArgs e)
        {
            searchTextBox.Text = "";
        }

        /// <summary>
        /// Sets the predefined text when the user leaves the textbox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBoxLeave(object sender, EventArgs e)
        {
            searchTextBox.Text = core.Lang.ORDER_NO;
        }

        /// <summary>
        /// When the user presses the enter button when in the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchButtonClick(sender, e); //Fire the clickButton event
            }
        }
        #endregion

        #region Button Events
        /// <summary>
        /// Shows a cancel dialog box 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButtonClick(object sender, EventArgs e)
        {
            CancelBox cancel = new CancelBox(core.Lang); //Makes the cancel dialog box with the proper language
            cancel.Owner = this; //Sets the owner so it shows in the middle of this window
            DialogResult a = cancel.ShowDialog();
            if (a.Equals(DialogResult.OK))
            {
                data.Clear();
            }
        }

        /// <summary>
        /// Updates the dataGridView with the order number 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButtonClick(object sender, EventArgs e)
        {
            //Makes sure that the order number only is numbers else it shows an error message to the user
            int temp = 0;
            if (int.TryParse(searchTextBox.Text, out temp))
            {
                UpdateDataGridView(searchTextBox.Text);
            }
            else
            {
                MessageBox.Show(core.Lang.ONLY_NUMBERS, core.Lang.ERROR);
                searchTextBox.Text = "";
            }
        }

        /// <summary>
        /// When the user clicks on confirm makes a list of the items an sort them in warehouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            List<Item> tempList = new List<Item>(); //Makes a temporary list used to store items for the sort algoritme
            DialogResult a = MessageBox.Show(core.Lang.CONFIRM_TEXT, core.Lang.CONFIRM, MessageBoxButtons.OKCancel); //Shows a dialogbox with confirmation they need to accept
            if (a.Equals(DialogResult.OK))
            {
                orderNo = dataGridView[1, 0].Value.ToString(); //Gets the order number from the data
                int count = dataGridView.RowCount;
                for (int i = 0; i < count; i++)
                {
                    if (dataGridView[5, i].Value != null)
                    {
                        //Gets the diffent values
                        string itemNo = dataGridView[2, i].Value.ToString();
                        string description = dataGridView[3, i].Value.ToString();
                        int quantity = int.Parse(dataGridView[5, i].Value.ToString());

                        //Makes a new item from the order values, and gets the usage if the item has been used before and adds it to the list
                        Item item = new Item(itemNo, description, quantity, null, core.DataHandler.GetUsage(itemNo));
                        tempList.Add(item);
                    }
                }
                //For us in displaying feedback to the user
                Dictionary<Item, Location> itemsPlaced;
                List<Item> itemsNotPlaced;
                if (tempList.Count != 0)
                {
                    itemsNotPlaced = core.SortNewItems(tempList, orderNo, out itemsPlaced); //Calls the algoritme
                    RegisterFeedBack regFeedback = new RegisterFeedBack(core, itemsNotPlaced, itemsPlaced);
                    regFeedback.Owner = this;
                    regFeedback.ShowDialog();
                }
                data.Clear(); // Clear the dataGridView
                core.WindowHandler.Update(this); //Update the gui's on all other windows then this  
            }
        }
        #endregion

        #region Language
        public void UpdateLang()
        {
            dataGridView.CellValueChanged -= DataGridViewCellValueChanged;
            Text = core.Lang.REGISTER;
            searchTextBox.Text = core.Lang.ORDER_NO;
            confirmButton.Text = core.Lang.CONFIRM;
            cancelButton.Text = core.Lang.CANCEL;
            searchButton.Text = core.Lang.SEARCH;
            if (dataGridView.ColumnCount > 0)
            {
                dataGridView.Columns[1].HeaderText = core.Lang.ORDER_NO;
                dataGridView.Columns[2].HeaderText = core.Lang.ITEM_NO;
                dataGridView.Columns[3].HeaderText = core.Lang.DESCRIPTION;
                dataGridView.Columns[4].HeaderText = core.Lang.EXPECTED_AMOUNT;
                dataGridView.Columns[5].HeaderText = core.Lang.AMOUNT;
            }
            dataGridView.CellValueChanged += DataGridViewCellValueChanged;
        }
        #endregion
    }
}
