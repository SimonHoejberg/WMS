using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WMS.Interfaces;
using WMS.WH;

namespace WMS.GUI
{
    //ToDo
    //Usage is not moved with the item when moved
    public partial class Move : Form, IGui
    {
        private ICore core;
        private DataGridViewTextBoxColumn columnQuantity, columnAction, columnIdentification, columnDescription;
        private DataGridViewComboBoxColumn comboColumnLocation, comboColumnNewLocation;
        private AutoCompleteStringCollection itemListA;
        private Dictionary<string, Location> locationData;
        private Dictionary<string, Item> itemData;
        private string idColumnString = "ItemIDColumn", descriptionColumnString = "DescriptionColumn", quantityColumnString = "QuantityColumn", locationColumnString = "LocationColumn", 
            newLocationColumnString = "NewLocationColumn", actionColumnString = "ActionColumn";

        #region Constructor
        public Move(ICore core)
        {
            InitializeComponent();
            this.core = core;
            confirmButton.Text = core.Lang.CONFIRM;
            cancelButton.Text = core.Lang.CANCEL;
            rmoveRowButton.Text = core.Lang.REMOVE_ROW;
            Text = core.Lang.MOVE;
            InitializeDataGridView();
            
        }
        #endregion

        #region Initialize dataGridView
        private void InitializeDataGridView()
        {
            //Dictionaries are used for easy reference and to minimize the need to reference to the database
            locationData = new Dictionary<string, Location>();
            itemData = new Dictionary<string, Item>();
            itemListA = new AutoCompleteStringCollection();

            //Populates the dictionaries (and ItemListA) with data from the database 
            populateItemDictionary(itemListA, itemData);
            PopulateLocationDictionary(locationData);

            moveAddItemTextBox.AutoCompleteCustomSource = itemListA;

            #region 
            //Creates and adds the Columns that makes up the datagridview
            dataGridView.Columns.Add(
                columnIdentification = new DataGridViewTextBoxColumn() //Column used for showing item number
                {
                    Name = idColumnString,
                    HeaderText = core.Lang.ITEM_NO,
                    Width = 300,
                    ReadOnly = true
                });

            dataGridView.Columns.Add(
                columnDescription = new DataGridViewTextBoxColumn() //Column used for showing item Name
                {
                    Name = descriptionColumnString,
                    HeaderText = core.Lang.DESCRIPTION,
                    Width = 300,
                    ReadOnly = true
                });

            dataGridView.Columns.Add(
                comboColumnLocation = new DataGridViewComboBoxColumn() //Column used for showing locations on which the item exists
                {
                    Name = locationColumnString,
                    ValueMember = "LocationString",
                    HeaderText = core.Lang.LOCATION,
                });

            dataGridView.Columns.Add(
                columnQuantity = new DataGridViewTextBoxColumn() //Column used for showing the quantity the user wants to move
                {
                    Name = quantityColumnString,
                    HeaderText = core.Lang.AMOUNT,                    
                });

            dataGridView.Columns.Add(
                comboColumnNewLocation = new DataGridViewComboBoxColumn() //Column used for showing the location the item will be moved to
                {
                    Name = newLocationColumnString,
                    ValueMember = "LocationString",
                    HeaderText = core.Lang.NEW_LOCATION,                    
                });

            dataGridView.Columns.Add(
                columnAction = new DataGridViewTextBoxColumn() //Column used for showing what action is made (move to new location / combine locations)
                {
                    Name = actionColumnString,
                    HeaderText = core.Lang.DESCRIPTION,
                    ReadOnly = true
                });
            #endregion

            /*The CellValueChanged event only fires when the relevant cell loses focus, but we want the event to fire at the exact moment the cell value changes.
              To do this we add a new eventlistner that fires when the dirtyState (Uncommited changes in a cell) changes for a cell. This does have the downside
              that the CellValueChanged event ends up fireing twice, but due to the nature of the system, this is not a problem.*/
            dataGridView.CellValueChanged += new DataGridViewCellEventHandler(DataGridViewCellValueChanged);
            dataGridView.CurrentCellDirtyStateChanged += new EventHandler(DataGridViewCurrentCellDirtyStateChanged);
        }
        #endregion

        #region DirtyStateChanged event
        /// <summary>
        /// This handler manually raises the CellValueChanged event by calling the CommitEdit method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        #endregion

        #region CellValueChanged event
        /// <summary>
        /// This event Fires when changes have been comitted to a cell in dataGridView. It is used for updataing info for the adjacent cells
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //If the cell that was changed had a rowindex of -1, we want to do nothing, as that cell is a headerCell
            if(e.RowIndex != -1)
            {
                if (dataGridView[e.ColumnIndex, e.RowIndex].OwningColumn == comboColumnLocation)
                {
                    //We want to set a value in the New Location cell. To set a new value, we start by setting the cellvalue to DBNull.Value.
                    (dataGridView.Rows[e.RowIndex].Cells[newLocationColumnString] as DataGridViewComboBoxCell).Value = DBNull.Value;
                    //Sets NewLocationCell to the cell where the user choses the new location, on the row where the event fired
                    var NewLocationCell = dataGridView.Rows[e.RowIndex].Cells[newLocationColumnString] as DataGridViewComboBoxCell;
                    NewLocationCell.Items.Clear(); //Clear the items, if any exist
                    List<Location> newLocList = NewLocationList(dataGridView[e.ColumnIndex, e.RowIndex], locationData);
                    //add items to newLocationCell based on the list gained from the NewLocationList method.

                    foreach (Location lc in newLocList)
                    {
                        NewLocationCell.Items.Add(lc);
                    }
                }
                //If the change happened in the New Location column, do this
                //Here we check what operation is going to happen. Move item to new location, or combine new locations. We set the message in the ActionColumn accordingly.
                else if (dataGridView[e.ColumnIndex, e.RowIndex].OwningColumn == comboColumnNewLocation)
                {
                    bool combine = false;
                    foreach (var a in (dataGridView.Rows[e.RowIndex].Cells[locationColumnString] as DataGridViewComboBoxCell).Items)
                    {
                        if (a.ToString().Equals(dataGridView.Rows[e.RowIndex].Cells[newLocationColumnString].Value.ToString()))
                        {
                            combine = true;
                        }
                    }
                    if (combine)
                    {
                        dataGridView.Rows[e.RowIndex].Cells[actionColumnString].Value = "Combine";
                    }
                    else
                    {
                        dataGridView.Rows[e.RowIndex].Cells[actionColumnString].Value = "Move";
                    }
                }
                //if the change happened in QuantityColumn, do this.
                else if (dataGridView[e.ColumnIndex, e.RowIndex].OwningColumn == columnQuantity)
                {
                    int a = 0;
                    var dgvQuantityCell = dataGridView.Rows[e.RowIndex].Cells[quantityColumnString];
                    var dgvLocCell = dataGridView.Rows[e.RowIndex].Cells[locationColumnString];

                    //If the cellvalue is null, set it to zero
                    if (dgvQuantityCell.Value == null)
                    {
                        dgvQuantityCell.Value = 0;
                    }
                    //Check if the value is an integer
                    bool checkIfInt = Int32.TryParse(dgvQuantityCell.Value.ToString(), out a);
                    //If it is, check if its less than zero or more than the maximum quantity.
                    if (checkIfInt)
                    {
                        int maxQuantity = 0;

                        maxQuantity = locationData[dgvLocCell.Value.ToString()].Quantity;

                        //If less than zero, set the value to zero
                        if (a < 0)
                        {
                            dgvQuantityCell.Value = 0;
                        }
                        //If higher than max, set value to max
                        else if (a > maxQuantity)
                        {
                            dgvQuantityCell.Value = maxQuantity;
                        }
                    }
                    //If not an integer, set the value to max
                    else
                    {
                        dgvQuantityCell.Value = 0;
                    }
                }
            }
        }
        #endregion

        #region Get lists for udating combobox items
        /// <summary>
        /// Returns a list of locations that contain the same item as the item chosen in the eventCell
        /// </summary>
        /// <param name="eventCell"></param>
        /// <param name="locDic"></param>
        /// <returns></returns>
        private List<Location> LocationList(DataGridViewCell eventCell, Dictionary<string, Location> locDic)
        {
            List<Location> returnList = new List<Location>();
            foreach (Location loc in locDic.Values)
            {
                if (loc.ItemNo.Equals(eventCell.Value) && loc.Quantity != 0)
                {
                    returnList.Add(loc);
                }
            }
            return returnList;
        }

        /// <summary>
        /// Returns a list of locations that are empty or contain the same item as the chosen item in IdentificationColumn
        /// </summary>
        /// <param name="eventCell"></param>
        /// <param name="locDic"></param>
        /// <returns></returns>
        private List<Location> NewLocationList(DataGridViewCell eventCell, Dictionary<string, Location> locDic)
        {
            List<Location> returnList = new List<Location>();
            string a = dataGridView.Rows[eventCell.RowIndex].Cells[locationColumnString].Value.ToString();

            foreach (Location loc in locDic.Values)
            {
                if (loc.Quantity == 0 || (loc.ItemNo.Equals(locDic[a].ItemNo) && !loc.LocationString.Equals(locDic[a].LocationString)))
                {
                    returnList.Add(loc);
                }
            }
            return returnList;
        }
        #endregion

        #region Check rows before commit
        /// <summary>
        /// Checks if there is any problems in the datagridview's rows that would prevent a commit
        /// </summary>
        /// <param name="noPro"></param>
        /// <returns></returns>
        private string checkRowsForProblems(out bool noPro)
        {
            string listOfProblems = "";
            bool noProblems = true;

            foreach (DataGridViewRow dgvRow in dataGridView.Rows)
            {
                if (dgvRow.Index == dataGridView.Rows.Count)//We don't want the last and empty row
                {
                    break;
                }
                if (dgvRow.Cells[newLocationColumnString].Value == DBNull.Value)
                {
                    noProblems = false;
                    listOfProblems += ($"\n{core.Lang.VALUE_IN_NEW_LOCATION} {(dgvRow.Index + 1)} {core.Lang.IS_EMPTY}");
                }
                if (dgvRow.Cells[quantityColumnString].Value == DBNull.Value)
                {
                    noProblems = false;
                    listOfProblems += ($"\n{core.Lang.VALUE_IN_AMOUNT} {(dgvRow.Index + 1)} {core.Lang.IS_EMPTY}");
                }
                if (dgvRow.Cells[idColumnString].Value == DBNull.Value)
                {
                    noProblems = false;
                    listOfProblems += ($"\n{core.Lang.VALUE_IN_ITEM_ID} {(dgvRow.Index + 1)} {core.Lang.IS_EMPTY}");
                }
            }
            noPro = noProblems;
            return listOfProblems;
        }
        #endregion

        #region Button events

        #region ConfirmButton event
        /// <summary>
        /// Event that fires when the Confirm button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            //Check if there is any problems that prevent a commit to the database
            bool noProblemsEncountered = true;
            string problemList = checkRowsForProblems(out noProblemsEncountered);

            if (noProblemsEncountered == true) //Commit changes if no problems.
            {
                //Prompt the user with a final confirmation box
                DialogResult a = MessageBox.Show(core.Lang.CONFIRM_TEXT, core.Lang.CONFIRM, MessageBoxButtons.OKCancel);
                if (a.Equals(DialogResult.OK))
                {
                    int rowCount = dataGridView.Rows.Count;
                    string oldLocNewQuantity = "0";
                    string itemName = "0";
                    string oldLocNewItemNumber = "0";
                    int quantityColumnInt = 0;
                    Location tempOldLoc;
                    Location tempNewLoc;

                    for (int i = 0; i < rowCount; i++)
                    {
                        tempOldLoc = locationData[dataGridView.Rows[i].Cells[locationColumnString].Value.ToString()];
                        tempNewLoc = locationData[dataGridView.Rows[i].Cells[newLocationColumnString].Value.ToString()];

                        itemName = core.DataHandler.GetItemFromItemNo(tempOldLoc.ItemNo).Description;
                        quantityColumnInt = Convert.ToInt32(dataGridView.Rows[i].Cells[quantityColumnString].Value);
                        oldLocNewQuantity = (tempOldLoc.Quantity - quantityColumnInt).ToString();

                        if (Convert.ToInt32(oldLocNewQuantity) != quantityColumnInt)
                        {
                            oldLocNewItemNumber = tempOldLoc.ItemNo;
                        }

                        //If we move to a location containing the same item
                        if (tempOldLoc.ItemNo.Equals(tempNewLoc.ItemNo) && tempNewLoc.Quantity != 0)
                        {
                            //Update old location with new values
                            core.DataHandler.ItemMove(tempOldLoc.Id.ToString(), oldLocNewQuantity, oldLocNewItemNumber);

                            //Update new location with new values
                            core.DataHandler.ItemMove(tempNewLoc.Id.ToString(), (quantityColumnInt + tempNewLoc.Quantity).ToString(), tempOldLoc.ItemNo.ToString());

                            //Update the item information database with new values
                            core.DataHandler.ItemMove(tempNewLoc.ItemNo, tempNewLoc.LocationString);

                            //save changes to the log
                            core.DataHandler.MoveActionOnItem(tempOldLoc.ItemNo, itemName, core.GetTimeStamp(), quantityColumnInt, core.UserName, $"{tempOldLoc.LocationString} -> {tempNewLoc.LocationString}");
                        }
                        else
                        {
                            //Update old location with new values
                            core.DataHandler.ItemMove(tempOldLoc.Id.ToString(), oldLocNewQuantity, oldLocNewItemNumber);

                            //Update new location with new values
                            core.DataHandler.ItemMove(tempNewLoc.Id.ToString(), quantityColumnInt.ToString(), tempOldLoc.ItemNo.ToString());

                            //Update the item information database with new values
                            core.DataHandler.ItemMove(tempNewLoc.ItemNo, tempNewLoc.LocationString);

                            //save changes to the log
                            core.DataHandler.MoveActionOnItem(tempOldLoc.ItemNo, itemName, core.GetTimeStamp(), quantityColumnInt, core.UserName, $"{tempOldLoc.LocationString} -> {tempNewLoc.LocationString}");
                        }

                    }

                    ClearDataGridView();
                    populateItemDictionary(itemListA, itemData);
                    PopulateLocationDictionary(locationData);
                    core.WindowHandler.Update(this);

                }
            }
            //give error message if commit could not be done
            else if (noProblemsEncountered == false)
            {
                MessageBox.Show(problemList, core.Lang.ERROR);
            }
        }
        #endregion

        /// <summary>
        /// Event that fires when the Cancel button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButtonClick(object sender, EventArgs e)
        {
            CancelBox cancel = new CancelBox(core.Lang);
            cancel.Owner = this;
            DialogResult a = cancel.ShowDialog();

            if (a.Equals(DialogResult.OK))
            {
                ClearDataGridView();
            }
        }

        /// <summary>
        /// Removes the currently selected row in the dataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveRowButtonClick(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                dataGridView.Rows.Remove(dataGridView.CurrentRow);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moveAddItemButton_Click(object sender, EventArgs e)
        {
            if (itemData.ContainsKey(moveAddItemTextBox.Text))
            {
                //Set Item in added row
                dataGridView.Rows.Add(new DataGridViewRow());
                dataGridView.Rows[dataGridView.RowCount - 1].Cells[idColumnString].Value = itemData[moveAddItemTextBox.Text].ItemNo;
                dataGridView.Rows[dataGridView.RowCount - 1].Cells[descriptionColumnString].Value = itemData[moveAddItemTextBox.Text].Description;

                //Set Location and location list in added row
                var LocationCell = dataGridView.Rows[dataGridView.RowCount - 1].Cells[locationColumnString] as DataGridViewComboBoxCell;
                LocationCell.Items.Clear();

                //Sets the list for the CoboboxCell LocationCell which contains the items. This is done in a foreach loop as datasource causes problems.
                List<Location> locList = LocationList(dataGridView.Rows[dataGridView.RowCount - 1].Cells[idColumnString], locationData);
                foreach (Location lc in locList)
                {
                    LocationCell.Items.Add(lc);
                }
                //If items exist in the´location list set the selected value in the LocationCell to item nr. 1
                if (LocationCell.Items.Count != 0)
                {
                    LocationCell.Value = LocationCell.Items[0];
                }

                //Reset search box
                moveSearchLabel.Visible = false;
                moveAddItemTextBox.Text = "";

                //Sets the quantity to 0 to make sure a null reference can't happen.
                dataGridView.Rows[dataGridView.RowCount - 1].Cells[quantityColumnString].Value = 0;

            }
            else
            {
                moveSearchLabel.Visible = true;
            }
        }
        #endregion

        #region Populate dictionaries
        private void PopulateLocationDictionary(Dictionary<string, Location> dic)
        {
            dic.Clear();
            foreach (Location loc in core.DataHandler.LocationToList())
            {
                if (!dic.ContainsKey(loc.LocationString))
                {
                    dic.Add(loc.LocationString, loc);
                }
            }
        }
        
        private void populateItemDictionary(AutoCompleteStringCollection itemList, Dictionary<string, Item> dic)
        {
            itemList.Clear();
            dic.Clear();
            foreach (Item item in core.DataHandler.InfoToList())
            { 
                itemList.Add(item.Identification);
                dic.Add(item.Identification, item);
            }
        }
        #endregion

        #region ClearDataGridView and MoveAddItemTextBox_KeyUp
        private void moveAddItemTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                moveAddItemButton_Click(this, e);
            }
        }

        /// <summary>
        /// Clears all rows from the dataGridView
        /// </summary>
        private void ClearDataGridView()
        {
            int rowCount = dataGridView.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                dataGridView.Rows.RemoveAt(0);
            }
        }
        #endregion

        #region GUI update functions
        /// <summary>
        /// Updates all GUI elemets with respect to the chosen language.
        /// </summary>
        public void UpdateLang()
        {
            dataGridView.CellValueChanged -= DataGridViewCellValueChanged;
            confirmButton.Text = core.Lang.CONFIRM;
            cancelButton.Text = core.Lang.CANCEL;
            moveAddItemButton.Text = core.Lang.ADD;
            rmoveRowButton.Text = core.Lang.REMOVE_ROW;
            Text = core.Lang.MOVE;
            dataGridView.Columns[quantityColumnString].HeaderText = core.Lang.AMOUNT;
            comboColumnLocation.HeaderText = core.Lang.LOCATION;
            comboColumnNewLocation.HeaderText = core.Lang.NEW_LOCATION;
            columnIdentification.HeaderText = core.Lang.ITEM_NO;
            columnDescription.HeaderText = core.Lang.DESCRIPTION;
            columnAction.HeaderText = core.Lang.DESCRIPTION;
            dataGridView.CellValueChanged += DataGridViewCellValueChanged;
        }

        private void MoveLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        public void UpdateGuiElements()
        {
            populateItemDictionary(itemListA, itemData);
            PopulateLocationDictionary(locationData);
        }
        #endregion
    }
}
