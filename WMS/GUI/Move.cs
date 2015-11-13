using System;
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
*/

namespace WMS.GUI
{
    public partial class Move : Form, IGui
    {
        private ICore core;
        private DataGridViewComboBoxColumn ComboColumnIdentification, ComboColumnLocation, ComboColumnNewLocation;
        private DataGridViewColumn ColumnQuantity;

        public Move(ICore core)
        {
            InitializeComponent();
            this.core = core;
            InitializeDataGridView(core);
        }

        private void InitializeDataGridView(ICore core)
        {
            //Creates the DataGridViewComboBoxColumns that makes up the datagridview
            ComboColumnLocation = new DataGridViewComboBoxColumn();
            ComboColumnNewLocation = new DataGridViewComboBoxColumn();
            ComboColumnIdentification = new DataGridViewComboBoxColumn(); //New!

            ColumnQuantity = new DataGridViewColumn();

            //Names?
            ComboColumnIdentification.Name = "ItemIDColumn";
            ComboColumnLocation.Name = "LocationColumn";
            ComboColumnNewLocation.Name = "NewLocationColumn";

            //Sets the Displaymembers for the DataGridViewComboBoxColumns
            ComboColumnIdentification.DisplayMember = "Identification";

            //ValueMembers
            ComboColumnIdentification.ValueMember = "ItemNo";
            ComboColumnLocation.ValueMember = "LocString";
            ComboColumnNewLocation.ValueMember = "LocString";

            //Sets the HeaderTexts for the DataGridViewComboBoxColumns
            ColumnQuantity.HeaderText = "Quantity";
            ComboColumnLocation.HeaderText = "Location";
            ComboColumnNewLocation.HeaderText = "New Location";
            ComboColumnIdentification.HeaderText = "Item Number/Name";

            //Adds DataGridViewComboBoxColumns to DataGridView
            moveDataGridView.Columns.Add(ComboColumnIdentification);
            moveDataGridView.Columns.Add(ComboColumnLocation);
            moveDataGridView.Columns.Add("QuantityColumn", "Quantity"); //Also sets name of column
            moveDataGridView.Columns.Add(ComboColumnNewLocation);

            //Set width of columns, Width of datagridview is ca. 917 (as of writing this)
            DataGridViewColumn column1 = moveDataGridView.Columns[0];
            DataGridViewColumn column2 = moveDataGridView.Columns[1];
            DataGridViewColumn column3 = moveDataGridView.Columns[2];
            DataGridViewColumn column4 = moveDataGridView.Columns[3];
            column1.Width = 230;
            column2.Width = 229;
            column3.Width = 229;
            column4.Width = 229;

            //Sets the initial datasources
            ComboColumnIdentification.DataSource = core.DataHandler.InfoToList();
            //ComboColumnLocation.DataSource = core.DataHandler.LocationToList();

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
            if (moveDataGridView[e.ColumnIndex, e.RowIndex].OwningColumn.Name.Equals("ItemIDColumn"))
            {
                var LocationCell = moveDataGridView.Rows[e.RowIndex].Cells["LocationColumn"] as DataGridViewComboBoxCell;
                LocationCell.Items.Clear();
                List<Location> locList = LocationList(moveDataGridView[e.ColumnIndex, e.RowIndex]);
                foreach (Location lc in locList)
                {
                    LocationCell.Items.Add(lc);
                }
                LocationCell.Value = LocationCell.Items[0];
                moveDataGridView.Rows[e.RowIndex].Cells["QuantityColumn"].Value = 0;
            }
            //if the change happened in LocationColumn
            else if (moveDataGridView[e.ColumnIndex, e.RowIndex].OwningColumn.Name.Equals("LocationColumn"))
            {
                //Set new locations
                var NewLocationCell = moveDataGridView.Rows[e.RowIndex].Cells["NewLocationColumn"] as DataGridViewComboBoxCell;
                NewLocationCell.Items.Clear();
                List<Location> newLocList = NewLocationList(moveDataGridView[e.ColumnIndex, e.RowIndex]);
                foreach (Location lc in newLocList)
                {
                    Console.WriteLine(lc.LocString);
                    NewLocationCell.Items.Add(lc);
                }
            }
            //if the change happened in QuantityColumn
            else if (moveDataGridView[e.ColumnIndex, e.RowIndex].OwningColumn.Name.Equals("QuantityColumn"))
            {
                int a = 0;

                bool checkIfInt = Int32.TryParse(moveDataGridView.Rows[e.RowIndex].Cells["QuantityColumn"].Value.ToString(), out a);
                if (checkIfInt)
                {
                    int maxQuantity = 0;

                    foreach (Location loc in core.DataHandler.LocationToList())
                    {
                        if (moveDataGridView.Rows[e.RowIndex].Cells["LocationColumn"].Value != null && loc.LocString.Equals(moveDataGridView.Rows[e.RowIndex].Cells["LocationColumn"].Value.ToString()))
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
            foreach(Location loc in input)
            {
                Console.WriteLine(loc.ItemNo);
            }
            return input.Where((x => x.ItemNo.Equals("0"))).ToList();
        }
        
        public string GetTypeOfWindow()
        {
            return "move";
        }

        public void UpdateGuiElements()
        {

        }

        private void moveCancelButton_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Are you sure you want to remove all edits from the list?", "Confirm Cancel", MessageBoxButtons.YesNo);
            if(result1 == DialogResult.Yes)
            {
                int rowCount = moveDataGridView.Rows.Count - 1;
                for (int i = 0; i < rowCount; i++)
                {
                    moveDataGridView.Rows.RemoveAt(0);
                }
            }
        }

        private void MoveLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
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

                if (dgvRow.Cells["ItemIDColumn"].Value != null && dgvRow.Cells["LocationColumn"].Value != null && dgvRow.Cells["QuantityColumn"].Value != null && dgvRow.Cells["NewLocationColumn"].Value != null)
                {
                    //Commit changes to database
                }
                else 
                {
                    if (dgvRow.Cells["ItemIDColumn"].Value == null)
                    {
                        noProblemsEncountered = false;
                        problemList += ("\nValue in ItemID on row " + (dgvRow.Index + 1) + " is empty!");
                    }
                    if(dgvRow.Cells["LocationColumn"].Value == null)
                    {
                        noProblemsEncountered = false;
                        problemList += ("\nValue in Location on row " + (dgvRow.Index + 1) + " is empty!");
                    }
                    if (dgvRow.Cells["QuantityColumn"].Value == null)
                    {
                        noProblemsEncountered = false;
                        problemList += ("\nValue in Quantity on row " + (dgvRow.Index + 1) + " is empty!");
                    }
                    if (dgvRow.Cells["NewLocationColumn"].Value == null)
                    {
                        noProblemsEncountered = false;
                        problemList += ("\nValue in New Location on row " + (dgvRow.Index + 1) + " is empty!");
                    }
                    //Fix attempt to move multiple items to the same location
                }
            }
            if(noProblemsEncountered == true)
            {
                UserIDBox user_dialog = new UserIDBox(core);
                user_dialog.Owner = this;
                DialogResult a = user_dialog.ShowDialog(); //Dialogresult is either OK or Cancel. OK only if correct userID was entered
                if (a.Equals(DialogResult.OK))
                {
                    //Reduce Item on on location
                    
                    //Increase items on new location

                }
            }
            //give error message if commit could not be done
            else if (noProblemsEncountered == false)
            {
                MessageBox.Show(problemList, "Changes could not be comitted!");
            }
        }
    }
}
