using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMS.Interfaces;
using WMS.WH;
using static WMS.Reference.SearchTerms;
using static WMS.Reference.DataBases;

namespace WMS.GUI
{
    public partial class Reduce : Form , IGui
    {
        private ICore core;

        //Variables for the datagridview
        private BindingSource bsource;
        private DataTable data;

        //Error messages
        private string error;
        private string mustBePostive;
        private string mustBeAnumber;

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

        private void Reduce_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        public void UpdateGuiElements()
        {

        }

        
        #region DataGridView and related events

        //Makes the datagridview
        private void MakeDataGridView()
        {
            dataGridView.CellValueChanged -= dataGridView_CellValueChanged;
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
            dataGridView.CellValueChanged += dataGridView_CellValueChanged;
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView.CellValueChanged -= dataGridView_CellValueChanged;
            string amount = dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();

            int output = 0;
            //Check if the input amount is null, if it is an int and if it is greater than 0
            if (amount != null)
            {
                if (!int.TryParse(amount, out output))
                {
                    MessageBox.Show(mustBeAnumber, error);
                    dataGridView[e.ColumnIndex, e.RowIndex].Value = null;
                }
                else if (output < 0)
                {
                    MessageBox.Show(mustBePostive, error);
                    dataGridView[e.ColumnIndex, e.RowIndex].Value = null;
                }
            }
            dataGridView.CellValueChanged += dataGridView_CellValueChanged;
        }
        #endregion

        #region Buttons and related events

        //Event fired when the confirm button is clicked
        private void confirmButton_Click(object sender, EventArgs e)
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
                        string locId = locationList.Find(x => x.LocationString.Equals(dataGridView[5, i].Value.ToString())).Id;
                        //Sends the data to the mysql server
                        core.DataHandler.ActionOnItem('-', dataGridView[0, i].Value.ToString(),
                                                      dataGridView[1, i].Value.ToString(),
                                                      dataGridView[6, i].Value.ToString(),
                                                      core.Lang.REDUCED, locId);
                    }
                }
                //Message box to tell the user that the items are reduced with success
                MessageBox.Show(core.Lang.SUCCESS_REDUCE, core.Lang.SUCCESS);
                core.WindowHandler.Update(this);
                //Clears the datagridview
                data.Clear();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int temp = 0;
            if (int.TryParse(searchTextBox.Text, out temp))
            {
                locationList = core.DataHandler.LocationToList();
                string itemNo = searchTextBox.Text;
                core.DataHandler.GetDataFromItemNo(itemNo, INFOMATION_DB).Fill(data);
                MakeDataGridView();
                if (locationList.FindAll(x => x.ItemNo.Equals(itemNo)).Count > 1)
                {
                    locationListBox.DataSource = locationList.FindAll(x => x.ItemNo.Equals(itemNo));
                    locationPanel.Visible = true;
                    locationListBox.Focus();
                }
                else
                {
                    dataGridView.CellValueChanged -= dataGridView_CellValueChanged;
                    dataGridView[5, dataGridView.RowCount - 1].Value = locationList.Find(x => x.ItemNo.Equals(itemNo));
                    dataGridView.CellValueChanged += dataGridView_CellValueChanged;
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CancelBox cancel = new CancelBox(core.Lang);
            cancel.Owner = this;
            DialogResult a = cancel.ShowDialog();

            if (a.Equals(DialogResult.OK))
            {
                data.Clear();
            }
        }

        private void chooseLocationButton_Click(object sender, EventArgs e)
        {
            dataGridView.CellValueChanged -= dataGridView_CellValueChanged;
            locationPanel.Visible = false;
            searchTextBox.Focus();
            dataGridView[5, dataGridView.RowCount - 1].Value = locationListBox.SelectedItem;
            Location location = ((Location)locationListBox.SelectedItem);
            dataGridView.CellValueChanged += dataGridView_CellValueChanged;
        }

        private void removeLineButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell != null)
            {
                dataGridView.Rows.RemoveAt(dataGridView.CurrentCell.RowIndex);
            }
        }
        #endregion

        #region Textboxes and related events

        //Creates the autofill for the searchbox
        public void SearchBox()
        {
            var source = new AutoCompleteStringCollection();

            foreach (Item item in core.DataHandler.InfoToList())
            {
                source.Add(item.ItemNo);
            }
            searchTextBox.AutoCompleteCustomSource = source;
        }

        //Event to clear the searchtextbox when entered
        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            searchTextBox.Text = "";
        }

        //Event that fires when enter is pressed which then fires searchButton_Click
        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                searchButton_Click(sender, e);
            }
        }
        #endregion

        #region Listboxes and related events

        //Event fired when an item in the locationListBox is double clicked
        //Fires the chooseLocationButton_Click event
        private void locationListBox_DoubleClick(object sender, EventArgs e)
        {
            chooseLocationButton_Click(sender, e);
        }

        //Event fired when the enter button is pressed
        //Fires the chooseLocationButton_Click event
        private void locationListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                chooseLocationButton_Click(sender, e);
            }
        }
        #endregion
        
        #region Updates the language
        public void UpdateLang()
        {
            dataGridView.CellValueChanged -= dataGridView_CellValueChanged;
            searchButton.Text = core.Lang.ADD;
            Text = core.Lang.REDUCE;
            confirmBtn.Text = core.Lang.CONFIRM;
            cancelButton.Text = core.Lang.CANCEL;
            error = core.Lang.ERROR;
            mustBePostive = core.Lang.MUST_BE_A_POSITIVE;
            mustBeAnumber = core.Lang.MUST_BE_A_NUMER;
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
            dataGridView.CellValueChanged += dataGridView_CellValueChanged;
        }
        #endregion
    }
}
