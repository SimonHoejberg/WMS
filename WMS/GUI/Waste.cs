using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WMS.Interfaces;
using WMS.WH;
using static WMS.Reference.DataBases;

namespace WMS.GUI
{
    public partial class Waste : Form, IGui
    {
        private ICore core;
        
        //Lists for reasons and locations
        private List<string> reasons;
        private List<Location> locationList;

        //Variables for the datagridview
        private BindingSource bsource;
        private DataTable data;

        //Integer used to input reason in the datagridview
        private int lastRow;

        public Waste(ICore core)
        {
            this.core = core;
            InitializeComponent();
            SearchBox();
            UpdateLang();
            bsource = new BindingSource();
            data = new DataTable();
            bsource.DataSource = data;
            dataGridView.DataSource = bsource;
            MakeList();
        }

        private void WasteLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        public void UpdateGuiElements() { /*NOOP*/ }


        #region DataGridView Events and Methods
        /// <summary>
        /// Makes the datagridview
        /// </summary>
        private void MakeDataGridView()
        {
            //Turn the cellvaluechanged event off, so it does not fire
            dataGridView.CellValueChanged -= DataGridViewCellValueChanged;
            //Set the header text on the columns
            dataGridView.Columns["itemNo"].HeaderText = core.Lang.ITEM_NO;
            dataGridView.Columns["description"].HeaderText = core.Lang.DESCRIPTION;
            dataGridView.Columns["inStock"].HeaderText = core.Lang.IN_STOCK;
            dataGridView.Columns["location1"].Visible = false;
            dataGridView.Columns["itemUsage"].Visible = false;
            //If the location, amount and reason columns does not exist we make them
            if (!data.Columns.Contains(core.Lang.LOCATION))
            {
                data.Columns.Add(core.Lang.LOCATION);
                dataGridView.Columns[5].Name = "location";
            }
            if (!data.Columns.Contains(core.Lang.AMOUNT))
            {
                data.Columns.Add(core.Lang.AMOUNT);
                dataGridView.Columns[6].Name = "amount";
            }
            if (!data.Columns.Contains(core.Lang.REASON))
            {
                data.Columns.Add(core.Lang.REASON);
                dataGridView.Columns[7].Name = "reason";
            }
            //Sets the all columns to readonly except the amount column
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                if (!(dataGridView.Columns[i].Name == "amount"))
                {
                    dataGridView.Columns[i].ReadOnly = true;
                }
                //Set the size of all columns
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            //Turn the cellvaluechanged event on again
            dataGridView.CellValueChanged += DataGridViewCellValueChanged;
        }

        /// <summary>
        /// Fires the cellvaluechanged event when a cell in the datagridview is changed
        /// </summary>
        private void DataGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView.CellValueChanged -= DataGridViewCellValueChanged;
            //Checks if the amount column has changed
            if (dataGridView.Columns[e.ColumnIndex].Equals(dataGridView.Columns["amount"]))
            {
                string instockString = dataGridView["inStock", e.RowIndex].Value.ToString();
                int inStock = int.Parse(instockString);
                int amount = 0;
                //Checks if the input is an integer and if its less than 0
                if (!int.TryParse(dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString(), out amount))
                {
                    MessageBox.Show(core.Lang.MUST_BE_A_NUMER, core.Lang.ERROR);
                    dataGridView[e.ColumnIndex, e.RowIndex].Value = null;
                }
                else if (amount < 0)
                {
                    MessageBox.Show(core.Lang.MUST_BE_A_POSITIVE, core.Lang.ERROR);
                    dataGridView[e.ColumnIndex, e.RowIndex].Value = null;
                }
                else if(amount > inStock)
                {
                    dataGridView.CellValueChanged += DataGridViewCellValueChanged;
                    dataGridView[e.ColumnIndex, e.RowIndex].Value = inStock;
                }
                else
                {
                    lastRow = e.RowIndex;
                    reasonPanel.Visible = true;
                    reasonsListBox.Focus();
                }
            }
            dataGridView.CellValueChanged += DataGridViewCellValueChanged;
        }
        #endregion

        #region Search TextBox Events and Methods
        /// <summary>
        /// Removes the value in the textbox
        /// </summary>
        private void SearchTextBoxEnter(object sender, EventArgs e)
        {
            searchTextBox.Text = "";
        }

        /// <summary>
        /// Event fires when the enter key is pressed and adds a new row
        /// </summary>
        private void SearchTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                AddRowButtonClick(sender, e);
            }
        }

        /// <summary>
        /// Makes the autocomplete source for the searchtextbox
        /// </summary>
        public void SearchBox()
        {
            var source = new AutoCompleteStringCollection();
            foreach (Item item in core.DataHandler.InfoToList())
            {
                source.Add(item.ItemNo);
            }
            searchTextBox.AutoCompleteCustomSource = source;
        }
        #endregion

        #region Reason Button and List Events and Methods

        /// <summary>
        /// Makes a list of reasons
        /// </summary>
        private void MakeList()
        {
            reasons = new List<string>();
            reasons.Add(core.Lang.BROKEN);
            reasons.Add(core.Lang.WRONG_ITEM_DELIVRED);
            reasons.Add(core.Lang.MISSING);

            reasonsListBox.DataSource = reasons;
        }

        /// <summary>
        /// Sets the reason column in the datagridview to the selected item in the reasonsListBox
        /// </summary>
        private void ChooseReasonButtonClick(object sender, EventArgs e)
        {
            dataGridView.CellValueChanged -= DataGridViewCellValueChanged;
            reasonPanel.Visible = false;
            dataGridView.Focus();
            dataGridView["reason", lastRow].Value = reasonsListBox.SelectedItem.ToString();
            dataGridView.CellValueChanged += DataGridViewCellValueChanged;
        }

        /// <summary>
        /// Event fired when an item in the reasonsListbox is doubleclicked
        /// </summary>
        private void ReasonsListBoxDoubleClick(object sender, EventArgs e)
        {
            ChooseReasonButtonClick(sender, e);
        }

        /// <summary>
        /// Event fired when the enter key is pressed in the reasonsListBox
        /// </summary>
        private void ReasonsListBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                ChooseReasonButtonClick(sender, e);
            }
        }
        #endregion

        #region Location Button and List Events and Methods

        /// <summary>
        /// Sets the location column in the datagridview to the selected item in the locationListBox
        /// </summary>
        private void ChooseLocationButtonClick(object sender, EventArgs e)
        {
            dataGridView.CellValueChanged -= DataGridViewCellValueChanged;
            locationPanel.Visible = false;
            dataGridView.Focus();
            dataGridView["location", dataGridView.RowCount - 1].Value = locationListBox.SelectedItem;
            dataGridView["inStock", dataGridView.RowCount - 1].Value = ((Location)locationListBox.SelectedItem).Quantity;
            searchTextBox.Focus();
            dataGridView.CellValueChanged += DataGridViewCellValueChanged;
        }

        /// <summary>
        /// Event fired when the enter key is pressed in the locationListBox
        /// </summary>
        private void LocationListBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                ChooseLocationButtonClick(sender, e);
            }
        }

        /// <summary>
        /// Event fired when an item in the locationListbox is doubleclicked
        /// </summary>
        private void LocationListBoxDoubleClick(object sender, EventArgs e)
        {
            ChooseLocationButtonClick(sender, e);
        }
        #endregion

        #region Misc Button Events
        /// <summary>
        /// Removes the selected row in the datagridview
        /// </summary>
        private void RemoveRowButtonClick(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell != null)
            {
                dataGridView.Rows.RemoveAt(dataGridView.CurrentCell.RowIndex);
            }
        }

        /// <summary>
        /// Adds a row with the information from the information database
        /// </summary>
        private void AddRowButtonClick(object sender, EventArgs e)
        {
            int output = 0;
            if (int.TryParse(searchTextBox.Text, out output))
            {
                string itemNo = searchTextBox.Text;
                //Fills the datatable with information from the database
                core.DataHandler.GetDataFromItemNo(itemNo, INFOMATION_DB).Fill(data);
                MakeDataGridView();
                //Creates a list with all locations from the database
                locationList = core.DataHandler.LocationToList();
                //Checks how many locations an item has and if it has more than 1 it opens the locationPanel
                if (locationList.FindAll(x => x.ItemNo.Equals(itemNo)).Count > 1)
                {
                    locationListBox.DataSource = locationList.FindAll(x => x.ItemNo.Equals(itemNo));
                    locationListBox.DisplayMember = "LocationAndQuantity";
                    locationPanel.Visible = true;
                    locationListBox.Focus();
                }
                //If there is only 1 location it just inputs that in the datagridview
                else
                {
                    dataGridView["location", dataGridView.RowCount - 1].Value = locationList.Find(x => x.ItemNo.Equals(itemNo));
                    searchTextBox.Focus();
                }
            }
            else
            {
                MessageBox.Show(core.Lang.ONLY_NUMBERS, core.Lang.ERROR);
                searchTextBox.Text = "";
            }
        }

        /// <summary>
        /// Prompts the user with a custom dialogbox
        /// </summary>
        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            UserIDBox dialog = new UserIDBox(core);
            DialogResult a = dialog.ShowDialog();
            //Checks the dialog result
            if (a.Equals(DialogResult.OK))
            {
                //Gets the user from the userid
                string user = dialog.User;
                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    if (!(dataGridView[0, i].Value == null))
                    {
                        //Gets the location id from the locationList
                        string locId = locationList.Find(x => x.LocationString.Equals(dataGridView["location", i].Value.ToString())).Id;
                        //Updates the database with the proper information
                        core.DataHandler.ActionOnItem('-', dataGridView["itemNo", i].Value.ToString(),
                                                      dataGridView["description", i].Value.ToString(),
                                                      dataGridView["amount", i].Value.ToString(),
                                                      core.DataHandler.GetUserName(user),
                                                      dataGridView["reason", i].Value.ToString(), locId);
                    }
                }
                //clears the datatable which clears the datagrid
                data.Clear();
                //Prompts the user with a dialogbox telling it succeeded 
                MessageBox.Show(core.Lang.SUCCESS_WASTE, core.Lang.SUCCESS);
                core.WindowHandler.Update(this);
            }
        }

        /// <summary>
        /// Prompts the user with a dialogbox asking if they want to cancel
        /// </summary>
        private void CancelButtonClick(object sender, EventArgs e)
        {
            CancelBox cancel = new CancelBox(core.Lang);
            DialogResult a = cancel.ShowDialog();
            //checks the user input 
            if (a.Equals(DialogResult.OK))
            {
                data.Clear();
            }
        }
        #endregion

        #region Language
        public void UpdateLang()
        {
            dataGridView.CellValueChanged -= DataGridViewCellValueChanged;
            Text = core.Lang.WASTE;
            chooseButton.Text = core.Lang.CHOOSE;
            addLineButton.Text = core.Lang.SEARCH;
            searchTextBox.Text = core.Lang.ITEM_NO;
            cancelButton.Text = core.Lang.CANCEL;
            confirmButton.Text = core.Lang.CONFIRM;
            removeRowButton.Text = core.Lang.REMOVE_ROW;
            chooseLocationButton.Text = core.Lang.CHOOSE;
            if (dataGridView.ColumnCount > 0)
            {
                dataGridView.Columns["itemNo"].HeaderText = core.Lang.ITEM_NO;
                dataGridView.Columns["description"].HeaderText = core.Lang.DESCRIPTION;
                dataGridView.Columns["inStock"].HeaderText = core.Lang.IN_STOCK;
                dataGridView.Columns["location"].HeaderText = core.Lang.LOCATION;
                dataGridView.Columns["amount"].HeaderText = core.Lang.AMOUNT;
                dataGridView.Columns["reason"].HeaderText = core.Lang.REASON;
            }
            MakeList();
            dataGridView.CellValueChanged -= DataGridViewCellValueChanged;
        }
        #endregion
        
    }
}