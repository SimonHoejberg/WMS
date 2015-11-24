﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WMS.Interfaces;
using WMS.Reference;
using WMS.WH;


/*ToDo
- New location list should contain all locations with the same item
- Should no be able to move multiple items to the same location
- Make it so that you can move multiple times from the same location
- Move multiple to same new location if item is the same
- When moving multiple times from the same location, make sure the total quantity does not exceed the quantity on the location
- Make the user able to choose Location first
- 
*/

namespace WMS.GUI
{
    public partial class Move : Form, IGui
    {
        private ICore core;
        private DataGridViewColumn ColumnQuantity;
        private DataGridViewComboBoxColumn ComboColumnLocation, ComboColumnNewLocation, ComboColumnIdentification;
        private ILang lang;

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
            //Dictionary for easy reference
            /*Dictionary<string, Location> comboData = new Dictionary<string, Location>();

            foreach (Location loc in core.DataHandler.LocationToList())
            {
                comboData.Add(loc.LocationString, loc);
            }*/

            //Creates the DataGridViewComboBoxColumns that makes up the datagridview
            ComboColumnLocation = new DataGridViewComboBoxColumn()
            {
                Name = "LocationColumn",
                ValueMember = "LocationString",
                HeaderText = lang.LOCATION,
                Width = 229

            };
            ComboColumnNewLocation = new DataGridViewComboBoxColumn()
            {
                Name = "NewLocationColumn",
                ValueMember = "LocationString",
                HeaderText = lang.NEW_LOCATION,
                Width = 229

            };
            ComboColumnIdentification = new DataGridViewComboBoxColumn()
            {
                Name = "ItemIDColumn",
                DataSource = core.DataHandler.InfoToList(),
                DisplayMember = "Identification",
                ValueMember = "ItemNo",
                HeaderText = lang.ITEM_NO + " / " + lang.DESCRIPTION,
                Width = 300
            };

            ColumnQuantity = new DataGridViewColumn()
            {
                HeaderText = lang.AMOUNT,
                Width = 300
            };

            //Adds DataGridViewComboBoxColumns to DataGridView
            moveDataGridView.Columns.Add(ComboColumnIdentification);
            moveDataGridView.Columns.Add(ComboColumnLocation);
            moveDataGridView.Columns.Add("QuantityColumn", lang.AMOUNT); //Also sets name of column
            moveDataGridView.Columns.Add(ComboColumnNewLocation);

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
            if (e.RowIndex != -1 && moveDataGridView[e.ColumnIndex, e.RowIndex].OwningColumn.Name.Equals("ItemIDColumn"))
            {
                var LocationCell = moveDataGridView.Rows[e.RowIndex].Cells["LocationColumn"] as DataGridViewComboBoxCell;
                LocationCell.Items.Clear();
                List<Location> locList = LocationList(moveDataGridView[e.ColumnIndex, e.RowIndex]);
                foreach (Location lc in locList)
                {
                    LocationCell.Items.Add(lc);
                }
                if(LocationCell.Items.Count != 0)
                {
                    LocationCell.Value = LocationCell.Items[0];
                }
                
                moveDataGridView.Rows[e.RowIndex].Cells["QuantityColumn"].Value = 0;
            }
            //if the change happened in LocationColumn
            else if (e.RowIndex != -1 && moveDataGridView[e.ColumnIndex, e.RowIndex].OwningColumn.Name.Equals("LocationColumn"))
            {
                //Set new locations
                var NewLocationCell = moveDataGridView.Rows[e.RowIndex].Cells["NewLocationColumn"] as DataGridViewComboBoxCell;
                NewLocationCell.Items.Clear();
                List<Location> newLocList = NewLocationList(moveDataGridView[e.ColumnIndex, e.RowIndex]);
                foreach (Location lc in newLocList)
                {
                    Console.WriteLine(lc.ToString());
                    NewLocationCell.Items.Add(lc);
                }
            }
            //if the change happened in QuantityColumn
            else if (e.RowIndex != -1 && moveDataGridView[e.ColumnIndex, e.RowIndex].OwningColumn.Name.Equals("QuantityColumn"))
            {
                int a = 0;

                if (moveDataGridView.Rows[e.RowIndex].Cells["QuantityColumn"].Value == null)
                {
                    moveDataGridView.Rows[e.RowIndex].Cells["QuantityColumn"].Value = 0;
                }
                bool checkIfInt = Int32.TryParse(moveDataGridView.Rows[e.RowIndex].Cells["QuantityColumn"].Value.ToString(), out a);
                if (checkIfInt)
                {
                    int maxQuantity = 0;

                    foreach (Location loc in core.DataHandler.LocationToList())
                    {
                        if (moveDataGridView.Rows[e.RowIndex].Cells["LocationColumn"].Value != null && loc.ToString().Equals(moveDataGridView.Rows[e.RowIndex].Cells["LocationColumn"].Value.ToString()))
                        {
                            maxQuantity = loc.Quantity;
                        }
                    }

                    if (0 > a)
                    {
                        moveDataGridView.Rows[e.RowIndex].Cells["QuantityColumn"].Value = 0;
                    }
                    else if (a > maxQuantity)
                    {
                        moveDataGridView.Rows[e.RowIndex].Cells["QuantityColumn"].Value = maxQuantity;
                    }
                }
                else
                {
                    moveDataGridView.Rows[e.RowIndex].Cells["QuantityColumn"].Value = 0;
                }
            }
        }

        private List<Item> ItemList(DataGridViewCell eventCell)
        {
            List<Item> input = core.DataHandler.InfoToList();
            return input.Where(x => x.ItemNo.Equals(eventCell.Value)).ToList();
        }

        private List<Item> DescriptionList(DataGridViewCell eventCell)
        {
            List<Item> input = core.DataHandler.InfoToList();
            return input.Where(x => x.Description.Equals(eventCell.Value)).ToList();
        }

        private List<Location> LocationList(DataGridViewCell eventCell)
        {
            List<Location> input = core.DataHandler.LocationToList();
            return input.Where(x => x.ItemNo.Equals(eventCell.Value)).ToList();
        }

        private List<Location> NewLocationList(DataGridViewCell eventCell)
        {
            List<Location> input = core.DataHandler.LocationToList();
            return input.Where((x => x.ItemNo.Equals("0"))).ToList();
        }

        private void moveCancelButton_Click(object sender, EventArgs e)
        {
            CancelBox cancel = new CancelBox(lang);
            cancel.Owner = this;
            DialogResult a = cancel.ShowDialog();

            if (a.Equals(DialogResult.OK))
            {
                int rowCount = moveDataGridView.Rows.Count - 1;
                for (int i = 0; i < rowCount; i++)
                {
                    moveDataGridView.Rows.RemoveAt(0);
                }
            }
        }

        private void MoveConfirmButtonClick(object sender, EventArgs e)
        {
            string problemList = "";
            bool noProblemsEncountered = true;
            bool locUsedTwice = false;
            bool newLocUsedTwice = false;

            foreach (DataGridViewRow dgvRow in moveDataGridView.Rows)
            {
                if (dgvRow.Index == moveDataGridView.Rows.Count - 1)//We don't want the last and empty row
                {
                    break;
                }
                foreach (DataGridViewRow dgvRow2 in moveDataGridView.Rows)
                {
                    if (dgvRow2.Index == moveDataGridView.Rows.Count - 1)//We don't want the last and empty row
                    {
                        break;
                    }
                    /*if (dgvRow.Cells["LocationColumn"].Value.ToString().Equals(dgvRow2.Cells["LocationColumn"].Value.ToString()))
                    {
                        locUsedTwice = true;
                    }
                    if (dgvRow.Cells["NewLocationColumn"].Value.ToString().Equals(dgvRow2.Cells["NewLocationColumn"].Value.ToString()))
                    {
                        newLocUsedTwice = true;
                    */
                }
            }
            Console.WriteLine(locUsedTwice + " " + newLocUsedTwice);
            //Check if multiple items are moved to the same location
            foreach (DataGridViewRow dgvRow in moveDataGridView.Rows)
            {
                if (dgvRow.Index == moveDataGridView.Rows.Count - 1)//We don't want the last and empty row
                {
                    break;
                }
                if (dgvRow.Cells["ItemIDColumn"].Value == null)
                {
                    noProblemsEncountered = false;
                    problemList += ("\n" + lang.VALUE_IN_ITEM_ID + " " + (dgvRow.Index + 1) + " " + lang.IS_EMPTY);
                }
                if (dgvRow.Cells["LocationColumn"].Value == null)
                {
                    noProblemsEncountered = false;
                    problemList += ("\n" + lang.VALUE_IN_LOCATION + " " + (dgvRow.Index + 1) + " " + lang.IS_EMPTY);
                }
                if (dgvRow.Cells["QuantityColumn"].Value == null)
                {
                    noProblemsEncountered = false;
                    problemList += ("\n" + lang.VALUE_IN_AMOUNT + " " + (dgvRow.Index + 1) + " " + lang.IS_EMPTY);
                }
                if (dgvRow.Cells["NewLocationColumn"].Value == null)
                {
                    noProblemsEncountered = false;
                    problemList += ("\n" + lang.VALUE_IN_NEW_LOCATION + " " + (dgvRow.Index + 1) + " " + lang.IS_EMPTY);
                }
                if (locUsedTwice == true)
                {
                    noProblemsEncountered = false;
                    problemList += ("\n" + lang.ATTEMPT_TO_MOVE_FROM_SAME_LOCATION_TWICE);
                }
                if (newLocUsedTwice == true)
                {
                    noProblemsEncountered = false;
                    problemList += ("\n" + lang.ATTEMPT_TO_MOVE_MUTIPLE_ITEM_TO_SAME_LOCATION);
                }

                //Fix attempt to move multiple items to the same location

            }
            if (noProblemsEncountered == true) //Commit changes if no problems.
            {
                UserIDBox user_dialog = new UserIDBox(core, lang);
                user_dialog.Owner = this;
                DialogResult a = user_dialog.ShowDialog(); //Dialogresult is either OK or Cancel. OK only if correct userID was entered
                if (a.Equals(DialogResult.OK))
                {
                    int rowCount = moveDataGridView.Rows.Count - 1;
                    for (int i = 0; i < rowCount; i++)
                    {
                        string[] oldLoc = moveDataGridView.Rows[i].Cells["LocationColumn"].Value.ToString().Split(':');
                        string[] newLoc = (moveDataGridView.Rows[i].Cells["NewLocationColumn"].Value as string).Split(':');
                        Location tempOldLoc = null;
                        Location tempNewLoc = null;

                        foreach (Location loc in core.DataHandler.LocationToList())
                        {
                            if(loc.Shelf.ToString().Equals(oldLoc[0]) && loc.ShelfNo.ToString().Equals(oldLoc[1]))
                            {
                                tempOldLoc = loc;
                                break;
                            }
                        }
                        foreach (Location loc in core.DataHandler.LocationToList())
                        {
                            if (loc.Shelf.ToString().Equals(newLoc[0]) && loc.ShelfNo.ToString().Equals(newLoc[1]))
                            {
                                tempNewLoc = loc;
                                break;
                            }
                        }
                        //Console.WriteLine($"{tempOldLoc.ItemNo} {tempOldLoc.LocationString}");
                        core.DataHandler.ItemMove(tempOldLoc.Id.ToString(), (tempOldLoc.Quantity - Convert.ToInt32(moveDataGridView.Rows[i].Cells["QuantityColumn"].Value)).ToString(), tempOldLoc.ItemNo.ToString());
                        core.DataHandler.ItemMove(tempNewLoc.Id.ToString(), Convert.ToInt32(moveDataGridView.Rows[i].Cells["QuantityColumn"].Value).ToString(), tempOldLoc.ItemNo.ToString());
                    }

                    ClearDataGridView();
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
            moveDataGridView.Columns["QuantityColumn"].HeaderText = lang.AMOUNT;
            ComboColumnLocation.HeaderText = lang.LOCATION;
            ComboColumnNewLocation.HeaderText = lang.NEW_LOCATION;
            ComboColumnIdentification.HeaderText = lang.ITEM_NO + " / " + lang.DESCRIPTION;
        }

        private void MoveLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        public string GetTypeOfWindow()
        {
            return WindowTypes.MOVE;
        }

        public void UpdateGuiElements()
        {

        }
    }
}
