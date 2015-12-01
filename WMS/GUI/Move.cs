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
    public partial class Move : Form, IGui
    {
        private ICore core;
        private DataGridViewTextBoxColumn ColumnQuantity, columnAction;
        private DataGridViewComboBoxColumn ComboColumnLocation, ComboColumnNewLocation, ComboColumnIdentification;
        private AutoCompleteStringCollection ItemListA;
        private Dictionary<string, Location> locationData;
        private Dictionary<string, Item> itemData;
        private string idColumnString = "ItemIDColumn", quantityColumnString = "QuantityColumn", locationColumnString = "LocationColumn", 
            newLocationColumnString = "NewLocationColumn", actionColumnString = "ActionColumn";

        public Move(ICore core)
        {
            InitializeComponent();
            this.core = core;
            moveConfirmButton.Text = core.Lang.CONFIRM;
            moveCancelButton.Text = core.Lang.CANCEL;
            Text = core.Lang.MOVE;
            InitializeDataGridView(core);
            
        }

        private void InitializeDataGridView(ICore core)
        {
            //Dictionaries are used for easy reference and to minimize the need to refer to the database
            locationData = new Dictionary<string, Location>();
            itemData = new Dictionary<string, Item>();
            ItemListA = new AutoCompleteStringCollection();

            //Populates the dictionaries (and ItemListA) with data from the database 
            populateItemDictionary(ItemListA, itemData);
            PopulateLocationDictionary(locationData);

            moveAddItemTextBox.AutoCompleteCustomSource = ItemListA; 

            #region 
            //Creates the Columns that makes up the datagridview
            moveDataGridView.Columns.Add(
                ComboColumnIdentification = new DataGridViewComboBoxColumn() //Column used for showing item number/Name
                {
                    Name = idColumnString,
                    DataSource = itemData.Values.ToList(),
                    DisplayMember = "Identification",
                    ValueMember = "ItemNo",
                    HeaderText = core.Lang.ITEM_NO + " / " + core.Lang.DESCRIPTION,
                    Width = 300
                });
            moveDataGridView.Columns.Add(
                ComboColumnLocation = new DataGridViewComboBoxColumn() //Column used for showing locations to move from
                {
                    Name = locationColumnString,
                    ValueMember = "LocationString",
                    HeaderText = core.Lang.LOCATION,
                    

                });
            moveDataGridView.Columns.Add(
                ColumnQuantity = new DataGridViewTextBoxColumn() //Column used for showing quantity to move
                {
                    Name = quantityColumnString,
                    HeaderText = core.Lang.AMOUNT,
                    
                });
            moveDataGridView.Columns.Add(
                ComboColumnNewLocation = new DataGridViewComboBoxColumn() //Column used for showing location to move to
                {
                    Name = newLocationColumnString,
                    ValueMember = "LocationString",
                    HeaderText = core.Lang.NEW_LOCATION,
                    
                });
            moveDataGridView.Columns.Add(
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
            moveDataGridView.CellValueChanged += new DataGridViewCellEventHandler(moveDataGridViewCellValueChanged);
            moveDataGridView.CurrentCellDirtyStateChanged += new EventHandler(moveDataGridViewCurrentCellDirtyStateChanged);
        }

        // This event handler manually raises the CellValueChanged event 
        // by calling the CommitEdit method. 
        private void moveDataGridViewCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (moveDataGridView.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                moveDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        //Fires when changes have been comitted to a cell in moveDataGridView
        private void moveDataGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if the change happened in ItemIDColumn
            if (e.RowIndex != -1 && moveDataGridView[e.ColumnIndex, e.RowIndex].OwningColumn == ComboColumnIdentification)
            {
                var LocationCell = moveDataGridView.Rows[e.RowIndex].Cells[locationColumnString] as DataGridViewComboBoxCell;
                LocationCell.Items.Clear();
                List<Location> locList = LocationList(moveDataGridView[e.ColumnIndex, e.RowIndex], locationData);
                foreach (Location lc in locList)
                {
                    LocationCell.Items.Add(lc);
                }
                if (LocationCell.Items.Count != 0)
                {
                    LocationCell.Value = LocationCell.Items[0];
                }

                moveDataGridView.Rows[e.RowIndex].Cells[quantityColumnString].Value = 0;
            }
            //if the change happened in LocationColumn
            else if (e.RowIndex != -1 && moveDataGridView[e.ColumnIndex, e.RowIndex].OwningColumn == ComboColumnLocation)
            {
                //Set new locations
                (moveDataGridView.Rows[e.RowIndex].Cells[newLocationColumnString] as DataGridViewComboBoxCell).Value = DBNull.Value;
                var NewLocationCell = moveDataGridView.Rows[e.RowIndex].Cells[newLocationColumnString] as DataGridViewComboBoxCell;
                NewLocationCell.Items.Clear();
                List<Location> newLocList = NewLocationList(moveDataGridView[e.ColumnIndex, e.RowIndex], locationData);
                foreach (Location lc in newLocList)
                {
                    NewLocationCell.Items.Add(lc);
                }
            }
            //if the change happened in QuantityColumn
            else if (e.RowIndex != -1 && moveDataGridView[e.ColumnIndex, e.RowIndex].OwningColumn == ColumnQuantity)
            {
                int a = 0;

                if (moveDataGridView.Rows[e.RowIndex].Cells[quantityColumnString].Value == null)
                {
                    moveDataGridView.Rows[e.RowIndex].Cells[quantityColumnString].Value = 0;
                }
                bool checkIfInt = Int32.TryParse(moveDataGridView.Rows[e.RowIndex].Cells[quantityColumnString].Value.ToString(), out a);
                if (checkIfInt)
                {
                    int maxQuantity = 0;

                    foreach (Location loc in locationData.Values.ToList())
                    {
                        if (moveDataGridView.Rows[e.RowIndex].Cells[locationColumnString].Value != null && loc.ToString().Equals(moveDataGridView.Rows[e.RowIndex].Cells[locationColumnString].Value.ToString()))
                        {
                            maxQuantity = loc.Quantity;
                        }
                    }

                    if (0 > a)
                    {
                        moveDataGridView.Rows[e.RowIndex].Cells[quantityColumnString].Value = 0;
                    }
                    else if (a > maxQuantity)
                    {
                        moveDataGridView.Rows[e.RowIndex].Cells[quantityColumnString].Value = maxQuantity;
                    }
                }
                else
                {
                    moveDataGridView.Rows[e.RowIndex].Cells[quantityColumnString].Value = 0;
                }
            }
            else if (e.RowIndex != -1 && moveDataGridView[e.ColumnIndex, e.RowIndex].OwningColumn == ComboColumnNewLocation)
            {
                bool combine = false;
                foreach (var a in (moveDataGridView.Rows[e.RowIndex].Cells[locationColumnString] as DataGridViewComboBoxCell).Items)
                {
                    if (a.ToString().Equals(moveDataGridView.Rows[e.RowIndex].Cells[newLocationColumnString].Value.ToString()))
                    {
                        combine = true;
                    }
                }
                if (combine)
                {
                    moveDataGridView.Rows[e.RowIndex].Cells[actionColumnString].Value = "Combine";
                }
                else
                {
                    moveDataGridView.Rows[e.RowIndex].Cells[actionColumnString].Value = "Move";
                }
            }
        }
        //Returns a list of items where the itemNumber is equal to the chosen item in IdentificationColumn
        private List<Item> ItemList(DataGridViewCell eventCell)
        {
            List<Item> input = itemData.Values.ToList();
            return input.Where(x => x.ItemNo.Equals(eventCell.Value)).ToList();
        }

        //Returns a list of locations that are empty or contain the same item as the chosen item in IdentificationColumn
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

        private List<Location> NewLocationList(DataGridViewCell eventCell, Dictionary<string, Location> locDic)
        {
            List<Location> returnList = new List<Location>();
            string a = moveDataGridView.Rows[eventCell.RowIndex].Cells[locationColumnString].Value.ToString();

            foreach (Location loc in locDic.Values)
            {
                if (loc.Quantity == 0 || (loc.ItemNo.Equals(locDic[a].ItemNo) && !loc.LocationString.Equals(locDic[a].LocationString)))
                {
                    returnList.Add(loc);
                }
            }
            return returnList;
        }

        private void moveCancelButton_Click(object sender, EventArgs e)
        {
            CancelBox cancel = new CancelBox(core.Lang);
            cancel.Owner = this;
            DialogResult a = cancel.ShowDialog();

            if (a.Equals(DialogResult.OK))
            {
                ClearDataGridView();
            }
        }

        private void MoveConfirmButtonClick(object sender, EventArgs e)
        {
            string problemList = "";
            bool noProblemsEncountered = true;

            foreach (DataGridViewRow dgvRow in moveDataGridView.Rows)
            {
                if (dgvRow.Index == moveDataGridView.Rows.Count)//We don't want the last and empty row
                {
                    break;
                }
                if (dgvRow.Cells[newLocationColumnString].Value == DBNull.Value)
                    {
                    noProblemsEncountered = false;
                    problemList += ($"\n{core.Lang.VALUE_IN_NEW_LOCATION} {(dgvRow.Index + 1)} {core.Lang.IS_EMPTY}");
                }
                if (dgvRow.Cells[quantityColumnString].Value == DBNull.Value)
                {
                    noProblemsEncountered = false;
                    problemList += ($"\n{core.Lang.VALUE_IN_AMOUNT} {(dgvRow.Index + 1)} {core.Lang.IS_EMPTY}");
                }
                if (dgvRow.Cells[idColumnString].Value == DBNull.Value)
                {
                    noProblemsEncountered = false;
                    problemList += ($"\n{core.Lang.VALUE_IN_ITEM_ID} {(dgvRow.Index + 1)} {core.Lang.IS_EMPTY}");
                }
            }
            if (noProblemsEncountered == true) //Commit changes if no problems.
            {
                DialogResult a = MessageBox.Show(core.Lang.CONFIRM_TEXT, core.Lang.CONFIRM, MessageBoxButtons.OKCancel);
                if (a.Equals(DialogResult.OK))
                {
                    int rowCount = moveDataGridView.Rows.Count;
                    for (int i = 0; i < rowCount; i++)
                    {
                        Location tempOldLoc = locationData[moveDataGridView.Rows[i].Cells[locationColumnString].Value.ToString()];
                        Location tempNewLoc = locationData[moveDataGridView.Rows[i].Cells[newLocationColumnString].Value.ToString()];

                        if (tempOldLoc.ItemNo.Equals(tempNewLoc.ItemNo))
                        {
                            core.DataHandler.ItemMove(tempOldLoc.Id.ToString(), (tempOldLoc.Quantity - Convert.ToInt32(moveDataGridView.Rows[i].Cells[quantityColumnString].Value)).ToString(), 
                                tempOldLoc.ItemNo.ToString());
                            core.DataHandler.ItemMove(tempNewLoc.Id.ToString(), (Convert.ToInt32(moveDataGridView.Rows[i].Cells[quantityColumnString].Value) + tempNewLoc.Quantity).ToString(), 
                                tempOldLoc.ItemNo.ToString());
                            core.DataHandler.ItemMove(tempNewLoc.ItemNo, tempNewLoc.LocationString);
                            core.DataHandler.MoveActionOnItem(tempOldLoc.ItemNo, core.DataHandler.GetItemFromItemNo(tempOldLoc.ItemNo).Description, core.GetTimeStamp(), 
                                Convert.ToInt32(moveDataGridView.Rows[i].Cells[quantityColumnString].Value), core.UserName, $"{tempOldLoc.LocationString} -> {tempNewLoc.LocationString}");
                        }
                        else
                        {
                            core.DataHandler.ItemMove(tempOldLoc.Id.ToString(), (tempOldLoc.Quantity - Convert.ToInt32(moveDataGridView.Rows[i].Cells[quantityColumnString].Value)).ToString(), 
                                tempOldLoc.ItemNo.ToString());
                            core.DataHandler.ItemMove(tempNewLoc.Id.ToString(), Convert.ToInt32(moveDataGridView.Rows[i].Cells[quantityColumnString].Value).ToString(), 
                                tempOldLoc.ItemNo.ToString());
                            core.DataHandler.ItemMove(tempNewLoc.ItemNo, tempNewLoc.LocationString);
                            core.DataHandler.MoveActionOnItem(tempOldLoc.ItemNo, core.DataHandler.GetItemFromItemNo(tempOldLoc.ItemNo).Description, core.GetTimeStamp(), 
                                Convert.ToInt32(moveDataGridView.Rows[i].Cells[quantityColumnString].Value), core.UserName, $"{tempOldLoc.LocationString} -> {tempNewLoc.LocationString}");
                        }
                        
                    }

                    ClearDataGridView();
                    populateItemDictionary(ItemListA, itemData);
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

        private void ClearDataGridView()
        {
            int rowCount = moveDataGridView.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                moveDataGridView.Rows.RemoveAt(0);
            }
        }

        private void moveRemoveRowButton_Click(object sender, EventArgs e)
        {
            if(moveDataGridView.CurrentRow != null)
            {
                moveDataGridView.Rows.Remove(moveDataGridView.CurrentRow);
            }
        }

        public void UpdateLang()
        {
            moveConfirmButton.Text = core.Lang.CONFIRM;
            moveCancelButton.Text = core.Lang.CANCEL;
            moveAddItemButton.Text = core.Lang.ADD;
            moveRemoveRowButton.Text = core.Lang.REMOVE_ROW;
            Text = core.Lang.MOVE;
            moveDataGridView.Columns[quantityColumnString].HeaderText = core.Lang.AMOUNT;
            ComboColumnLocation.HeaderText = core.Lang.LOCATION;
            ComboColumnNewLocation.HeaderText = core.Lang.NEW_LOCATION;
            ComboColumnIdentification.HeaderText = core.Lang.ITEM_NO + " / " + core.Lang.DESCRIPTION;
            columnAction.HeaderText = core.Lang.DESCRIPTION;
        }

        private void moveAddItemButton_Click(object sender, EventArgs e)
        {
            if (itemData.ContainsKey(moveAddItemTextBox.Text))
            {
                moveSearchLabel.Visible = false;
                moveDataGridView.Rows.Add(new DataGridViewRow());
                moveDataGridView.Rows[moveDataGridView.RowCount - 1].Cells[idColumnString].Value = itemData[moveAddItemTextBox.Text].ItemNo;
                moveAddItemTextBox.Text = "";
                
            }
            else
            {
                moveSearchLabel.Visible = true;
            }
        }

        private void moveAddItemTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                moveAddItemButton_Click(this, e);
            }
        }

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

        private void MoveLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        public void UpdateGuiElements()
        {
            populateItemDictionary(ItemListA, itemData);
            PopulateLocationDictionary(locationData);
        }
    }
}
