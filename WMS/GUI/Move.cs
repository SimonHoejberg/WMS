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
- Grey out cells that can not be accessed.
- Generalize functions
- Add functionality to new location
- Clean up code
- Add support for using the "Location" combobox first
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

            //Sets the HeaderTexts for the DataGridViewComboBoxColumns
            ColumnQuantity.HeaderText = "Quantity";
            ComboColumnLocation.HeaderText = "Location";
            ComboColumnNewLocation.HeaderText = "New Location";
            ComboColumnIdentification.HeaderText = "Item Number/Name";

            //Adds DataGridViewComboBoxColumns to DataGridView
            moveDataGridView.Columns.Add(ComboColumnIdentification);
            moveDataGridView.Columns.Add("QuantityColumn", "Quantity");
            moveDataGridView.Columns.Add(ComboColumnLocation);
            moveDataGridView.Columns.Add(ComboColumnNewLocation);

            //Set width of columns
            DataGridViewColumn column1 = moveDataGridView.Columns[0];
            column1.Width = 150;

            //Sets the initial datasources
            ComboColumnIdentification.DataSource = core.DataHandler.InfoToList();
            //ComboColumnLocation.DataSource = core.DataHandler.LocationToList();

            // Add the events to listen for
            /*moveDataGridView.CellValueChanged += new DataGridViewCellEventHandler(moveDataGridViewCellValueChanged);
            moveDataGridView.CurrentCellDirtyStateChanged += new EventHandler(moveDataGridViewCurrentCellDirtyStateChanged);*/
        }

        // This event handler manually raises the CellValueChanged event 
        // by calling the CommitEdit method. 
        /*void moveDataGridViewCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.moveDataGridView.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                moveDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }*/

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

        private List<Location> NewLocationList(DataGridViewCell eventCell, string oldLoc)
        {
            List<Location> input = core.DataHandler.LocationToList();
            return input.Where((x => x.ItemNo.Equals("0") || (x.ItemNo.Equals(eventCell.Value) && x.LocString != oldLoc))).ToList();
        }

        private void moveLoadOptimalButtonClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in moveDataGridView.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[4].Value == null)
                {
                    //use algorithm here
                    //send itemNo, current location and itemQuantity
                    ComboColumnNewLocation.Items.Add("3");
                    row.Cells[4].Value = "3";
                }
            }
        }

        private void moveDataGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*/Sets originalCell to reference the cell the event was called from
            var dgv = sender as DataGridView;
            var originalCell = dgv[e.ColumnIndex, e.RowIndex];

            DataGridViewCell eventCell = moveDataGridView[e.ColumnIndex, e.RowIndex];

            if (e.ColumnIndex == 0) //Name/ID
            { 
                var cell = dgv.Rows[e.RowIndex].Cells["LocationColumn"] as DataGridViewComboBoxCell;
                cell.Value = null;
                cell.DataSource = LocationList(eventCell);
            }
            else if(e.ColumnIndex == 2) //Location
            {

            }*/

            /*If the cellValueChanged was called from the first column, aka. "itemNo" Set the datasource for the second column "ItemName"
            if (e.ColumnIndex == 0)
            {
                //Cell is hardcoded to reference the column next to "itemNo", which should be "ItemName"
                var cell = dgv[e.ColumnIndex + 1, e.RowIndex] as DataGridViewComboBoxCell;
                cell.DataSource = ItemList(eventCell);
                moveDataGridView.Rows[e.RowIndex].Cells["ItemNameColumn"].Value = core.DataHandler.GetItemFromItemNo(originalCell.Value.ToString()).Description;

                //Cell is hardcoded to reference the column 3 right of "itemNo", which should be "ItemLocation"
                var cell2 = dgv[e.ColumnIndex + 3, e.RowIndex] as DataGridViewComboBoxCell;
                cell2.DataSource = LocationList(eventCell);
            }*/
            /*else if (e.ColumnIndex == 1)
            {
                var cell = dgv[e.ColumnIndex - 1, e.RowIndex] as DataGridViewComboBoxCell;
                cell.DataSource = DescriptionList(eventCell);
                moveDataGridView.Rows[e.RowIndex].Cells["ItemNoColumn"].Value = moveDataGridView.Rows[e.RowIndex].Cells["ItemNameColumn"].Value as Item;

            }*/
        }

        /* v.Jonas
        public void manualMove()
        {
            List<Location> LocList = new List<Location>();

            foreach (DataGridViewRow row in moveDataGridView.Rows)
            {
                string unit = (row.Cells[].Value as Location).Unit;
                int shelf = (row.Cells[].Value as Location).Shelf.ToString();


                LocList.Add(new Location())


            }
        }*/

        /*public void ManualMove()
        {
            int itemInStockIncrease = 0;
            int itemInStockDecrease = 0;

            foreach (DataGridViewRow row in moveDataGridView.Rows)
            {
                //Searches for items with the same location as the new location
                //could use a location search
                foreach (Item item in core.DataHandler.DataToList(WindowTypes.INFO))
                {
                    if (item.Shelf == (int)row.Cells[4].Value)
                    {
                        // Sees if the items are the same and if there's room
                        if (int.Parse(item.ItemNo) == (int)row.Cells[0].Value && item.Size - item.InStock >= (int)row.Cells[3].Value)
                        {

                            itemInStockIncrease = item.InStock + (int)row.Cells[3].Value - ((item.InStock + (int)row.Cells[3].Value) % item.Size);
                            itemInStockDecrease = (item.InStock + (int)row.Cells[3].Value) % item.Size;


                            //use an updatefunction to either update the item or location
                            //core.DataHandler.UpdateProduct("4", itemInStockIncrease.ToString(), item.ItemNo.ToString(), WindowTypes.INFO, this);
                        }
                    }
                    // something for when shelf and cells[4] are not equal
                }
            }
        }*/

        public string GetTypeOfWindow()
        {
            return "move";
        }

        private void moveDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Sets originalCell to reference the cell the event was called from
            var dgv = sender as DataGridView;
            var originalCell = dgv[e.ColumnIndex, e.RowIndex];

            DataGridViewCell eventCell = moveDataGridView[e.ColumnIndex, e.RowIndex];

            if (e.ColumnIndex == 0) //Name/ID
            {
                //Set Location cell datasource
                var LocationCell = dgv.Rows[e.RowIndex].Cells["LocationColumn"] as DataGridViewComboBoxCell;
                LocationCell.Items.Clear();
                List<Location> locList = LocationList(eventCell);
                foreach (Location lc in locList)
                {
                    LocationCell.Items.Add(lc);
                }
                //LocationCell.Value = LocationCell.Items[0];

              
            }
            else if(e.ColumnIndex == 2)
            {
                //Set new location cell datasource
                var NewLocationCell = dgv.Rows[e.RowIndex].Cells["NewLocationColumn"] as DataGridViewComboBoxCell;
                NewLocationCell.Items.Clear();
                List<Location> newLocList = NewLocationList(eventCell, dgv.Rows[e.RowIndex].Cells["LocationColumn"].Value.ToString());
                foreach (Location lc in newLocList)
                {
                    NewLocationCell.Items.Add(lc);
                }
                //NewLocationCell.Value = NewLocationCell.Items[0];
            }
            else if (e.ColumnIndex == 1)
            {
                int a = 0;
                
                bool checkIfInt = Int32.TryParse(dgv.Rows[e.RowIndex].Cells["QuantityColumn"].Value.ToString(), out a);
                if (checkIfInt)
                {
                    int maxQuantity = 0;

                    foreach(Location loc in core.DataHandler.LocationToList())
                    {
                        if (dgv.Rows[e.RowIndex].Cells["LocationColumn"].Value != null && loc.LocString.Equals(dgv.Rows[e.RowIndex].Cells["LocationColumn"].Value.ToString()))
                        {
                            maxQuantity = loc.Quantity;
                        }
                    }

                    if(0 > a)
                    {
                        dgv.Rows[e.RowIndex].Cells["QuantityColumn"].Value = 0;
                    }
                    else if (a > maxQuantity)
                    {
                        dgv.Rows[e.RowIndex].Cells["QuantityColumn"].Value = maxQuantity;
                    }

                }
            }
        }

        public void FilterColumn(string a)
        {

        }

        private void MoveDataGridViewRowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //things to do when a new row is added (e.g. disable some cells, change styles for cells)
            DataGridViewCellStyle a = new DataGridViewCellStyle();
            a.SelectionForeColor = Color.AliceBlue;
            (moveDataGridView[0, e.RowIndex] as DataGridViewComboBoxCell).Style = a;
        }

        public void UpdateGuiElements()
        {

        }

        private void MoveLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void MoveConfirmButtonClick(object sender, EventArgs e)
        {
            //Current button event is made for testing the confirmation box. (passowd/userID)
            //ManualMove();
        }
    }
}
