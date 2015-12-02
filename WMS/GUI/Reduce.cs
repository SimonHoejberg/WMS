using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WMS.Interfaces;
using WMS.WH;
using static WMS.Reference.DataBases;

namespace WMS.GUI
{
    public partial class Reduce : Form , IGui
    {
        private ICore core;

        //Variables for the datagridview
        private BindingSource bsource;
        private DataTable data;

        private List<Location> locationList;

        public Reduce(ICore core)
        {
            this.core = core;
            InitializeComponent();
            SearchBox();
            UpdateLang();
            bsource = new BindingSource();
            data = new DataTable();
            bsource.DataSource = data;
            dataGridView.DataSource = bsource;
        }

        private void ReduceLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        public void UpdateGuiElements()
        {
            //NOOP
        }


        #region DataGridView Methods and Events

        /// <summary>
        /// Makes the datagridview
        /// </summary>
        private void MakeDataGridView()
        {
            dataGridView.CellValueChanged -= dataGridViewCellValueChanged;
            //Sets the header text on the columns
            dataGridView.Columns[0].HeaderText = core.Lang.ITEM_NO;
            dataGridView.Columns[1].HeaderText = core.Lang.DESCRIPTION;
            dataGridView.Columns[2].HeaderText = core.Lang.IN_STOCK;
            dataGridView.Columns[3].Visible = false;
            dataGridView.Columns[4].Visible = false;

            //Adds the location and amount columns if they have not already been made
            if (!data.Columns.Contains(core.Lang.LOCATION))
            {
                data.Columns.Add(core.Lang.LOCATION);
            }
            if (!data.Columns.Contains(core.Lang.AMOUNT))
            {
                data.Columns.Add(core.Lang.AMOUNT);
            }

            //Sets all columns except the Amount to readonly
            //We do it this way because if the datagridview is readonly we cant change one column to not be readonly
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                if (!dataGridView.Columns[i].HeaderText.Equals(core.Lang.AMOUNT))
                {
                    dataGridView.Columns[i].ReadOnly = true;
                }
                //Sets the size of all columns to automatically resize
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dataGridView.CellValueChanged += dataGridViewCellValueChanged;
        }

        /// <summary>
        /// Checks if the value in the cell is a postive number or tells the user a error 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView.CellValueChanged -= dataGridViewCellValueChanged; //Then event should only fire one time so we disable it if there is a eror
            string amount = dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();

            int output = 0;
            //Check if the input amount is null, if it is an int and if it is greater than 0
            if (amount != null)
            {
                if (!int.TryParse(amount, out output))
                {
                    MessageBox.Show(core.Lang.MUST_BE_A_NUMER, core.Lang.ERROR); //Tells the user that only numbers is allowed
                    dataGridView[e.ColumnIndex, e.RowIndex].Value = null; //Removes the value in the cell
                }
                else if (output < 0)
                {
                    MessageBox.Show(core.Lang.MUST_BE_A_POSITIVE, core.Lang.ERROR); //Tells the user that only positive numbers is allowed
                    dataGridView[e.ColumnIndex, e.RowIndex].Value = null; //Removes the value in the cell
                }
            }
            dataGridView.CellValueChanged += dataGridViewCellValueChanged; //Rebind the event
        }
        #endregion

        #region Buttons Events

        /// <summary>
        /// Event fired when the confirm button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            //Checks the result from the dialog box
            DialogResult a = MessageBox.Show(core.Lang.CONFIRM_TEXT, core.Lang.CONFIRM, MessageBoxButtons.OKCancel);
            if (a.Equals(DialogResult.OK))
            {
                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    if (dataGridView[0, i].Value != null && !(dataGridView[5, i].Value.Equals("0")))
                    {
                        //Gets the location id from the location list
                        string locationId = locationList.Find(x => x.LocationString.Equals(dataGridView[5, i].Value.ToString())).Id;
                        //Sends the data to the mysql server
                        core.DataHandler.ActionOnItem('-', dataGridView[0, i].Value.ToString(),
                                                      dataGridView[1, i].Value.ToString(),
                                                      dataGridView[6, i].Value.ToString(),
                                                      core.Lang.REDUCED, locationId);
                    }
                }
                //Message box to tell the user that the items are reduced with success
                MessageBox.Show(core.Lang.SUCCESS_REDUCE, core.Lang.SUCCESS);
                core.WindowHandler.Update(this);
                //Clears the datagridview
                data.Clear();
            }
        }

        /// <summary>
        /// When the user presses on the search button it fills data in the dataGridView 
        /// and fills in the location if only one or shows a panel with choices
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButtonClick(object sender, EventArgs e)
        {
            //Makes sure it is a number and positive
            int outValue = 0;
            if (int.TryParse(searchTextBox.Text, out outValue) && outValue > 0)
            {
                locationList = core.DataHandler.LocationToList(); //Gets the locations from the server
                string itemNo = searchTextBox.Text;
                core.DataHandler.GetDataFromItemNo(itemNo, INFOMATION_DB).Fill(data); //Fills the data from the item no in to the dataGridView
                MakeDataGridView(); //And Names the columns
                //Determines if the item has one or more locations
                if (locationList.FindAll(x => x.ItemNo.Equals(itemNo)).Count > 1)
                {
                    //If more locations it finds all the locations and lists them in a listBox
                    //Shows the panel and giv the listBox focus
                    locationListBox.DataSource = locationList.FindAll(x => x.ItemNo.Equals(itemNo));
                    locationPanel.Visible = true; 
                    locationListBox.Focus();
                }
                else
                {
                    //Unbinds the event and fills the location cell with the one location of the item and rebinds the event
                    dataGridView.CellValueChanged -= dataGridViewCellValueChanged;
                    dataGridView[5, dataGridView.RowCount - 1].Value = locationList.Find(x => x.ItemNo.Equals(itemNo));
                    dataGridView.CellValueChanged += dataGridViewCellValueChanged;
                }
            }
        }

        /// <summary>
        /// When the user pressed on the cancel bow shows a form with cancel text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButtonClick(object sender, EventArgs e)
        {
            CancelBox cancel = new CancelBox(core.Lang); //Makes the costume cancel box 
            cancel.Owner = this; //Sets the owner because it then shows up in the middle of the parent 
            DialogResult a = cancel.ShowDialog();

            //Removes all the data in dataGridView
            if (a.Equals(DialogResult.OK))
            {
                data.Clear();
            }
        }

        /// <summary>
        /// When the user has choosen a location by pressing on the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseLocationButtonClick(object sender, EventArgs e)
        {
            dataGridView.CellValueChanged -= dataGridViewCellValueChanged;
            locationPanel.Visible = false; //Hides the location panel so you only can choose once 
            searchTextBox.Focus();
            dataGridView[5, dataGridView.RowCount - 1].Value = locationListBox.SelectedItem; //Sets the value in the cell
            dataGridView.CellValueChanged += dataGridViewCellValueChanged;
        }

        /// <summary>
        /// Removes the highlighted row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveLineButtonClick(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell != null)
            {
                dataGridView.Rows.RemoveAt(dataGridView.CurrentCell.RowIndex);
            }
        }
        #endregion

        #region SearchBox Events and Methods

        /// <summary>
        /// Creates the autofill for the searchbox
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

        /// <summary>
        /// Event to clear the searchtextbox when entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBoxEnter(object sender, EventArgs e)
        {
            searchTextBox.Text = "";
        }

        /// <summary>
        /// Event that fires when enter is pressed which then fires SearchButtonClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SearchButtonClick(sender, e);
            }
        }
        #endregion

        #region LocationListBox Events

        /// <summary>
        /// Event fired when an item in the locationListBox is double clicked
        /// Fires the ChooseLocationButtonClick event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocationListBoxDoubleClick(object sender, EventArgs e)
        {
            ChooseLocationButtonClick(sender, e);
        }

        /// <summary>
        /// Event fired when the enter button is pressed
        /// Fires the ChooseLocationButtonClick event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocationListBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                ChooseLocationButtonClick(sender, e);
            }
        }
        #endregion
        
        #region Language
        public void UpdateLang()
        {
            dataGridView.CellValueChanged -= dataGridViewCellValueChanged;
            searchButton.Text = core.Lang.ADD;
            Text = core.Lang.REDUCE;
            confirmBtn.Text = core.Lang.CONFIRM;
            cancelButton.Text = core.Lang.CANCEL;
            removeLineButton.Text = core.Lang.REMOVE_ROW;
            searchTextBox.Text = core.Lang.ITEM_NO;
            if (dataGridView.ColumnCount > 0)
            {
                dataGridView.Columns[0].HeaderText = core.Lang.ITEM_NO;
                dataGridView.Columns[1].HeaderText = core.Lang.DESCRIPTION;
                dataGridView.Columns[2].HeaderText = core.Lang.IN_STOCK;
                dataGridView.Columns[5].HeaderText = core.Lang.LOCATION;
                dataGridView.Columns[6].HeaderText = core.Lang.AMOUNT;
            }
            dataGridView.CellValueChanged += dataGridViewCellValueChanged;
        }
        #endregion
    }
}
