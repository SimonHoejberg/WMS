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
        private DataGridViewTextBoxColumn columnQuantity, columnAction;
        private DataGridViewComboBoxColumn comboColumnLocation, comboColumnNewLocation, comboColumnIdentification;
        private AutoCompleteStringCollection itemListA;
        private Dictionary<string, Location> locationData;
        private Dictionary<string, Item> itemData;
        private string idColumnString = "ItemIDColumn", quantityColumnString = "QuantityColumn", locationColumnString = "LocationColumn", 
            newLocationColumnString = "NewLocationColumn", actionColumnString = "ActionColumn";

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

        private void InitializeDataGridView()
        {
            //Dictionaries are used for easy reference and to minimize the need to refer to the database
            locationData = new Dictionary<string, Location>();
            itemData = new Dictionary<string, Item>();
            itemListA = new AutoCompleteStringCollection();

            //Populates the dictionaries (and ItemListA) with data from the database 
            populateItemDictionary(itemListA, itemData);
            PopulateLocationDictionary(locationData);

            moveAddItemTextBox.AutoCompleteCustomSource = itemListA; 

            #region 
            //Creates the Columns that makes up the datagridview
            dataGridView.Columns.Add(
                comboColumnIdentification = new DataGridViewComboBoxColumn() //Column used for showing item number/Name
                {
                    Name = idColumnString,
                    DataSource = itemData.Values.ToList(),
                    DisplayMember = "Identification",
                    ValueMember = "ItemNo",
                    HeaderText = core.Lang.ITEM_NO + " / " + core.Lang.DESCRIPTION,
                    Width = 300
                });
            dataGridView.Columns.Add(
                comboColumnLocation = new DataGridViewComboBoxColumn() //Column used for showing locations to move from
                {
                    Name = locationColumnString,
                    ValueMember = "LocationString",
                    HeaderText = core.Lang.LOCATION,
                    

                });
            dataGridView.Columns.Add(
                columnQuantity = new DataGridViewTextBoxColumn() //Column used for showing quantity to move
                {
                    Name = quantityColumnString,
                    HeaderText = core.Lang.AMOUNT,
                    
                });
            dataGridView.Columns.Add(
                comboColumnNewLocation = new DataGridViewComboBoxColumn() //Column used for showing location to move to
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

        // This event handler manually raises the CellValueChanged event 
        // by calling the CommitEdit method. 
        private void DataGridViewCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        //Fires when changes have been comitted to a cell in moveDataGridView
        private void DataGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if the change happened in ItemIDColumn
            if (e.RowIndex != -1 && dataGridView[e.ColumnIndex, e.RowIndex].OwningColumn == comboColumnIdentification)
            {
                var LocationCell = dataGridView.Rows[e.RowIndex].Cells[locationColumnString] as DataGridViewComboBoxCell;
                LocationCell.Items.Clear();
                List<Location> locList = LocationList(dataGridView[e.ColumnIndex, e.RowIndex], locationData);
                foreach (Location lc in locList)
                {
                    LocationCell.Items.Add(lc);
                }
                if (LocationCell.Items.Count != 0)
                {
                    LocationCell.Value = LocationCell.Items[0];
                }

                dataGridView.Rows[e.RowIndex].Cells[quantityColumnString].Value = 0;
            }
            //if the change happened in LocationColumn
            else if (e.RowIndex != -1 && dataGridView[e.ColumnIndex, e.RowIndex].OwningColumn == comboColumnLocation)
            {
                //Set new locations
                (dataGridView.Rows[e.RowIndex].Cells[newLocationColumnString] as DataGridViewComboBoxCell).Value = DBNull.Value;
                var NewLocationCell = dataGridView.Rows[e.RowIndex].Cells[newLocationColumnString] as DataGridViewComboBoxCell;
                NewLocationCell.Items.Clear();
                List<Location> newLocList = NewLocationList(dataGridView[e.ColumnIndex, e.RowIndex], locationData);
                foreach (Location lc in newLocList)
                {
                    NewLocationCell.Items.Add(lc);
                }
            }
            //if the change happened in QuantityColumn
            else if (e.RowIndex != -1 && dataGridView[e.ColumnIndex, e.RowIndex].OwningColumn == columnQuantity)
            {
                int a = 0;

                if (dataGridView.Rows[e.RowIndex].Cells[quantityColumnString].Value == null)
                {
                    dataGridView.Rows[e.RowIndex].Cells[quantityColumnString].Value = 0;
                }
                bool checkIfInt = Int32.TryParse(dataGridView.Rows[e.RowIndex].Cells[quantityColumnString].Value.ToString(), out a);
                if (checkIfInt)
                {
                    int maxQuantity = 0;

                    foreach (Location loc in locationData.Values.ToList())
                    {
                        if (dataGridView.Rows[e.RowIndex].Cells[locationColumnString].Value != null && loc.ToString().Equals(dataGridView.Rows[e.RowIndex].Cells[locationColumnString].Value.ToString()))
                        {
                            maxQuantity = loc.Quantity;
                        }
                    }

                    if (0 > a)
                    {
                        dataGridView.Rows[e.RowIndex].Cells[quantityColumnString].Value = 0;
                    }
                    else if (a > maxQuantity)
                    {
                        dataGridView.Rows[e.RowIndex].Cells[quantityColumnString].Value = maxQuantity;
                    }
                }
                else
                {
                    dataGridView.Rows[e.RowIndex].Cells[quantityColumnString].Value = 0;
                }
            }
            else if (e.RowIndex != -1 && dataGridView[e.ColumnIndex, e.RowIndex].OwningColumn == comboColumnNewLocation)
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

        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            string problemList = "";
            bool noProblemsEncountered = true;

            foreach (DataGridViewRow dgvRow in dataGridView.Rows)
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
                        Location tempOldLoc = locationData[dataGridView.Rows[i].Cells[locationColumnString].Value.ToString()];
                        Location tempNewLoc = locationData[dataGridView.Rows[i].Cells[newLocationColumnString].Value.ToString()];

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

        private void ClearDataGridView()
        {
            int rowCount = moveDataGridView.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                dataGridView.Rows.RemoveAt(0);
            }
        }

        private void RemoveRowButtonClick(object sender, EventArgs e)
        {
            if(dataGridView.CurrentRow != null)
            {
                dataGridView.Rows.Remove(dataGridView.CurrentRow);
            }
        }

        public void UpdateLang()
        {
            confirmButton.Text = core.Lang.CONFIRM;
            cancelButton.Text = core.Lang.CANCEL;
            moveAddItemButton.Text = core.Lang.ADD;
            rmoveRowButton.Text = core.Lang.REMOVE_ROW;
            Text = core.Lang.MOVE;
            dataGridView.Columns[quantityColumnString].HeaderText = core.Lang.AMOUNT;
            comboColumnLocation.HeaderText = core.Lang.LOCATION;
            comboColumnNewLocation.HeaderText = core.Lang.NEW_LOCATION;
            comboColumnIdentification.HeaderText = core.Lang.ITEM_NO + " / " + core.Lang.DESCRIPTION;
            columnAction.HeaderText = core.Lang.DESCRIPTION;
        }

        private void moveAddItemButton_Click(object sender, EventArgs e)
        {
            if (itemData.ContainsKey(moveAddItemTextBox.Text))
            {
                moveSearchLabel.Visible = false;
                dataGridView.Rows.Add(new DataGridViewRow());
                dataGridView.Rows[dataGridView.RowCount - 1].Cells[idColumnString].Value = itemData[moveAddItemTextBox.Text].ItemNo;
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
            populateItemDictionary(itemListA, itemData);
            PopulateLocationDictionary(locationData);
        }
    }
}
