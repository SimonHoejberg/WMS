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

        //Error messages
        private string error;
        private string mustBePostive;
        private string mustBeAnumber;

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

        private void Waste_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        public void UpdateGuiElements() { /*NOOP*/ }


        #region Datagridview Events and Methods
        /// <summary>
        /// Makes the datagridview
        /// </summary>
        private void MakeDataGridView()
        {
            //Turn the cellvaluechanged event off, so it does not fire
            dataGridView.CellValueChanged -= dataGridView_CellValueChanged;
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
            dataGridView.CellValueChanged += dataGridView_CellValueChanged;
        }

        /// <summary>
        /// Fires the cellvaluechanged event when a cell in the datagridview is changed
        /// </summary>
        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView.CellValueChanged -= dataGridView_CellValueChanged;
            //Checks if the amount column has changed
            if (dataGridView.Columns[e.ColumnIndex].Equals(dataGridView.Columns["amount"]))
            {
                int output = 0;
                //Checks if the input is an integer and if its less than 0
                if (!int.TryParse(dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString(), out output))
                {
                    MessageBox.Show(mustBeAnumber, error);
                    dataGridView[e.ColumnIndex, e.RowIndex].Value = null;
                }
                else if (output < 0)
                {
                    MessageBox.Show(mustBePostive, error);
                    dataGridView[e.ColumnIndex, e.RowIndex].Value = null;
                }
                else
                {
                    lastRow = e.RowIndex;

                    reasonPanel.Visible = true;
                    reasonsListBox.Focus();
                }
            }
            dataGridView.CellValueChanged += dataGridView_CellValueChanged;
        }
        #endregion

        #region Textbox Events and Methods
        /// <summary>
        /// Removes the value in the textbox
        /// </summary>
        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            searchTextBox.Text = "";
        }

        /// <summary>
        /// Event fires when the enter key is pressed and adds a new row
        /// </summary>
        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                addRowButton_Click(sender, e);
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

        #region Button Events
        /// <summary>
        /// Sets the location column in the datagridview to the selected item in the locationListBox
        /// </summary>
        private void chooseLocationButton_Click(object sender, EventArgs e)
        {
            dataGridView.CellValueChanged -= dataGridView_CellValueChanged;
            locationPanel.Visible = false;
            dataGridView.Focus();
            dataGridView["location", dataGridView.RowCount - 1].Value = locationListBox.SelectedItem;
            Location location = ((Location)locationListBox.SelectedItem);
            searchTextBox.Focus();
            dataGridView.CellValueChanged += dataGridView_CellValueChanged;
        }

        /// <summary>
        /// Sets the reason column in the datagridview to the selected item in the reasonsListBox
        /// </summary>
        private void chooseButton_Click(object sender, EventArgs e)
        {
            dataGridView.CellValueChanged -= dataGridView_CellValueChanged;
            reasonPanel.Visible = false;
            dataGridView.Focus();
            dataGridView["reason", lastRow].Value = reasonsListBox.SelectedItem.ToString();
            dataGridView.CellValueChanged += dataGridView_CellValueChanged;
        }

        /// <summary>
        /// Removes the selected row in the datagridview
        /// </summary>
        private void removeRowButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell != null)
            {
                dataGridView.Rows.RemoveAt(dataGridView.CurrentCell.RowIndex);
            }
        }

        /// <summary>
        /// Adds a row with the information from the information database
        /// </summary>
        private void addRowButton_Click(object sender, EventArgs e)
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
        }

        /// <summary>
        /// Prompts the user with a custom dialogbox
        /// </summary>
        private void confirmButton_Click(object sender, EventArgs e)
        {
            UserIDBox user_dialog = new UserIDBox(core);
            DialogResult a = user_dialog.ShowDialog();
            //Checks the dialog result
            if (a.Equals(DialogResult.OK))
            {
                //Gets the user from the userid
                string user = user_dialog.User;
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
        private void cancelButton_Click(object sender, EventArgs e)
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

        #region Listbox Events and Methods
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
        /// Event fired when an item in the reasonsListbox is doubleclicked
        /// </summary>
        private void reasonsListBox_DoubleClick(object sender, EventArgs e)
        {
            chooseButton_Click(sender, e);
        }

        /// <summary>
        /// Event fired when the enter key is pressed in the reasonsListBox
        /// </summary>
        private void reasonsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                chooseButton_Click(sender, e);
            }
        }

        /// <summary>
        /// Event fired when the enter key is pressed in the locationListBox
        /// </summary>
        private void locationListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                chooseLocationButton_Click(sender, e);
            }
        }

        /// <summary>
        /// Event fired when an item in the locationListbox is doubleclicked
        /// </summary>
        private void locationListBox_DoubleClick(object sender, EventArgs e)
        {
            chooseLocationButton_Click(sender, e);
        }
        #endregion

        #region UpdateLang
        public void UpdateLang()
        {
            dataGridView.CellValueChanged -= dataGridView_CellValueChanged;
            Text = core.Lang.WASTE;
            chooseButton.Text = core.Lang.CHOOSE;
            addLineButton.Text = core.Lang.SEARCH;
            searchTextBox.Text = core.Lang.ITEM_NO;
            cancelButton.Text = core.Lang.CANCEL;
            confirmButton.Text = core.Lang.CONFIRM;
            removeRowButton.Text = core.Lang.REMOVE_ROW;
            chooseLocationButton.Text = core.Lang.CHOOSE;
            error = core.Lang.ERROR;
            mustBePostive = core.Lang.MUST_BE_A_POSITIVE;
            mustBeAnumber = core.Lang.MUST_BE_A_NUMER;
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
            dataGridView.CellValueChanged -= dataGridView_CellValueChanged;
        }
        #endregion
        
    }
}