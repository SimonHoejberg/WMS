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
        Dictionary<string, Location> locationData;
        private ILang lang;
        AutoCompleteStringCollection ItemListA;
        Dictionary<string, Item> itemData;
        private string idColumnString = "ItemIDColumn", quantityColumnString = "QuantityColumn", locationColumnString = "LocationColumn", 
            newLocationColumnString = "NewLocationColumn", actionColumnString = "ActionColumn";

        public Move(ICore core, ILang lang)
        {
            InitializeComponent();
            this.core = core;
            this.lang = lang;
            moveConfirmButton.Text = lang.CONFIRM;
            moveCancelButton.Text = lang.CANCEL;
            Text = lang.MOVE;
            InitializeDataGridView(core);
        }

        private void InitializeDataGridView(ICore core)
        {
            itemData = new Dictionary<string, Item>();
            ItemListA = new AutoCompleteStringCollection();

            foreach (Item item in core.DataHandler.InfoToList())
            {
                ItemListA.Add(item.Identification);
                itemData.Add(item.Identification, item);
            }
            moveAddItemTextBox.AutoCompleteCustomSource = ItemListA;

            //Dictionary for easy reference
            locationData = new Dictionary<string, Location>();
            PopulateLocationDictionary(locationData);

            #region 
            //Creates the DataGridViewComboBoxColumns that makes up the datagridview
            moveDataGridView.Columns.Add(
                ComboColumnIdentification = new DataGridViewComboBoxColumn()
                {
                    Name = idColumnString,
                    DataSource = itemData.Values.ToList(),
                    DisplayMember = "Identification",
                    ValueMember = "ItemNo",
                    HeaderText = lang.ITEM_NO + " / " + lang.DESCRIPTION,
                    Width = 300,
                });            
            moveDataGridView.Columns.Add(
                ComboColumnLocation = new DataGridViewComboBoxColumn()
                {
                    Name = locationColumnString,
                    ValueMember = "LocationString",
                    HeaderText = lang.LOCATION,
                    Width = 200

                });
            moveDataGridView.Columns.Add(
                ColumnQuantity = new DataGridViewTextBoxColumn()
                {
                    Name = quantityColumnString,
                    HeaderText = lang.AMOUNT,
                    Width = 130
                });
            moveDataGridView.Columns.Add(
                ComboColumnNewLocation = new DataGridViewComboBoxColumn()
                {
                    Name = newLocationColumnString,
                    ValueMember = "LocationString",
                    HeaderText = lang.NEW_LOCATION,
                    Width = 200
                });
            moveDataGridView.Columns.Add(
                columnAction = new DataGridViewTextBoxColumn()
                {
                    Name = actionColumnString,
                    HeaderText = "Action",
                    Width = 100,
                    ReadOnly = true
                });
            #endregion

            // Add the events to listen for
            moveDataGridView.CellValueChanged += new DataGridViewCellEventHandler(moveDataGridViewCellValueChanged);
            moveDataGridView.CurrentCellDirtyStateChanged += new EventHandler(moveDataGridViewCurrentCellDirtyStateChanged);
        }

        // This event handler manually raises the CellValueChanged event 
        // by calling the CommitEdit method. 
        void moveDataGridViewCurrentCellDirtyStateChanged(object sender, EventArgs e)
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

        private List<Item> ItemList(DataGridViewCell eventCell)
        {
            List<Item> input = itemData.Values.ToList();
            return input.Where(x => x.ItemNo.Equals(eventCell.Value)).ToList();
        }

        private List<Item> DescriptionList(DataGridViewCell eventCell)
        {
            List<Item> input = itemData.Values.ToList();
            return input.Where(x => x.Description.Equals(eventCell.Value)).ToList();
        }

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
            CancelBox cancel = new CancelBox(lang);
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
                if (dgvRow.Index == moveDataGridView.Rows.Count - 1)//We don't want the last and empty row
                {
                    break;
                }
                if (dgvRow.Cells[newLocationColumnString].Value == DBNull.Value)
                {
                    noProblemsEncountered = false;
                    problemList += ($"\n{lang.VALUE_IN_NEW_LOCATION} {(dgvRow.Index + 1)} {lang.IS_EMPTY}");
                }
                if (dgvRow.Cells[quantityColumnString].Value == DBNull.Value)
                {
                    noProblemsEncountered = false;
                    problemList += ($"\n{lang.VALUE_IN_AMOUNT} {(dgvRow.Index + 1)} {lang.IS_EMPTY}");
                }
                if (dgvRow.Cells[idColumnString].Value == DBNull.Value)
                {
                    noProblemsEncountered = false;
                    problemList += ($"\n{lang.VALUE_IN_ITEM_ID} {(dgvRow.Index + 1)} {lang.IS_EMPTY}");
                }
            }
            if (noProblemsEncountered == true) //Commit changes if no problems.
            {
                DialogResult a = MessageBox.Show(lang.CONFIRM_TEXT, lang.CONFIRM, MessageBoxButtons.OKCancel);
                if (a.Equals(DialogResult.OK))
                {
                    int rowCount = moveDataGridView.Rows.Count - 1;
                    for (int i = 0; i < rowCount; i++)
                    {
                        Location tempOldLoc = locationData[moveDataGridView.Rows[i].Cells[locationColumnString].Value.ToString()];
                        Location tempNewLoc = locationData[moveDataGridView.Rows[i].Cells[newLocationColumnString].Value.ToString()];

                        if (tempOldLoc.ItemNo.Equals(tempNewLoc.ItemNo))
                        {
                            core.DataHandler.ItemMove(tempOldLoc.Id.ToString(), (tempOldLoc.Quantity - Convert.ToInt32(moveDataGridView.Rows[i].Cells[quantityColumnString].Value)).ToString(), tempOldLoc.ItemNo.ToString());
                            core.DataHandler.ItemMove(tempNewLoc.Id.ToString(), (Convert.ToInt32(moveDataGridView.Rows[i].Cells[quantityColumnString].Value) + tempNewLoc.Quantity).ToString(), tempOldLoc.ItemNo.ToString());
                            core.DataHandler.ItemMove(tempNewLoc.ItemNo, tempNewLoc.LocationString);
                            core.DataHandler.MoveActionOnItem(tempOldLoc.ItemNo, core.DataHandler.GetItemFromItemNo(tempOldLoc.ItemNo).Description, core.GetTimeStamp(), Convert.ToInt32(moveDataGridView.Rows[i].Cells[quantityColumnString].Value), core.User, $"{tempOldLoc.LocationString} -> {tempNewLoc.LocationString}");
                        }
                        else
                        {
                            core.DataHandler.ItemMove(tempOldLoc.Id.ToString(), (tempOldLoc.Quantity - Convert.ToInt32(moveDataGridView.Rows[i].Cells[quantityColumnString].Value)).ToString(), tempOldLoc.ItemNo.ToString());
                            core.DataHandler.ItemMove(tempNewLoc.Id.ToString(), Convert.ToInt32(moveDataGridView.Rows[i].Cells[quantityColumnString].Value).ToString(), tempOldLoc.ItemNo.ToString());
                            core.DataHandler.ItemMove(tempNewLoc.ItemNo, tempNewLoc.LocationString);
                            core.DataHandler.MoveActionOnItem(tempOldLoc.ItemNo, core.DataHandler.GetItemFromItemNo(tempOldLoc.ItemNo).Description, core.GetTimeStamp(), Convert.ToInt32(moveDataGridView.Rows[i].Cells[quantityColumnString].Value), core.User, $"{tempOldLoc.LocationString} -> {tempNewLoc.LocationString}");
                        }
                        
                    }

                    ClearDataGridView();
                    PopulateLocationDictionary(locationData);
                }
            }
            //give error message if commit could not be done
            else if (noProblemsEncountered == false)
            {
                MessageBox.Show(problemList, lang.ERROR);
            }
        }

        private void ClearDataGridView()
        {
            int rowCount = moveDataGridView.Rows.Count - 1;
            for (int i = 0; i < rowCount; i++)
            {
                moveDataGridView.Rows.RemoveAt(0);
            }
        }

        public void UpdateLang(ILang lang)
        {
            this.lang = lang;
            moveConfirmButton.Text = lang.CONFIRM;
            moveCancelButton.Text = lang.CANCEL;
            Text = lang.MOVE;
            moveDataGridView.Columns[quantityColumnString].HeaderText = lang.AMOUNT;
            ComboColumnLocation.HeaderText = lang.LOCATION;
            ComboColumnNewLocation.HeaderText = lang.NEW_LOCATION;
            ComboColumnIdentification.HeaderText = lang.ITEM_NO + " / " + lang.DESCRIPTION;
        }

        private void moveAddItemButton_Click(object sender, EventArgs e)
        {
            if (itemData.ContainsKey(moveAddItemTextBox.Text))
            {
                moveSearchLabel.Visible = false;
                moveDataGridView.Rows.Add(new DataGridViewRow());
                moveDataGridView.Rows[moveDataGridView.RowCount - 2].Cells[idColumnString].Value = itemData[moveAddItemTextBox.Text].ItemNo;
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
            foreach (Location loc in core.DataHandler.LocationToList()
            {
                if (!dic.ContainsKey(loc.LocationString))
                {
                    dic.Add(loc.LocationString, loc);
                }
            }
        }

        private void MoveLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        public void UpdateGuiElements()
        {

        }
    }
}
