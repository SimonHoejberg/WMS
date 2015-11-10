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
        private DataGridViewComboBoxColumn ComboColumnItemNo, ComboColumnName, ComboColumnLocation, ComboColumnQuantity, ComboColumnNewLocation;

        public Move(ICore core)
        {
            InitializeComponent();
            this.core = core;
            InitializeDataGridView(core);
        }

        private void InitializeDataGridView(ICore core)
        {
            //Creates the DataGridViewComboBoxColumns that makes up the datagridview
            ComboColumnItemNo = new DataGridViewComboBoxColumn();
            ComboColumnName = new DataGridViewComboBoxColumn();
            ComboColumnLocation = new DataGridViewComboBoxColumn();
            ComboColumnQuantity = new DataGridViewComboBoxColumn();
            ComboColumnNewLocation = new DataGridViewComboBoxColumn();

            //Sets the Displaymembers for the DataGridViewComboBoxColumns
            ComboColumnItemNo.DisplayMember = "ItemNo";
            ComboColumnName.DisplayMember = "Description";

            //Sets the Valuemembers for the DataGridViewComboBoxColumns
            ComboColumnItemNo.DisplayMember = "ItemNo";

            //Sets the HeaderTexts for the DataGridViewComboBoxColumns
            ComboColumnItemNo.HeaderText = "Item Number";
            ComboColumnName.HeaderText = "Item Name";
            ComboColumnQuantity.HeaderText = "Quantity";
            ComboColumnLocation.HeaderText = "Location";
            ComboColumnNewLocation.HeaderText = "New Location";

            //Adds DataGridViewComboBoxColumns to DataGridView
            moveDataGridView.Columns.Add(ComboColumnItemNo);
            moveDataGridView.Columns.Add(ComboColumnName);
            moveDataGridView.Columns.Add(ComboColumnQuantity);
            moveDataGridView.Columns.Add(ComboColumnLocation);
            moveDataGridView.Columns.Add(ComboColumnNewLocation);

            //Sets the initial datasources
            ComboColumnItemNo.DataSource = core.DataHandler.DataToList(DataBaseTypes.INFO);
            ComboColumnName.DataSource = core.DataHandler.DataToList(DataBaseTypes.INFO);
            ComboColumnLocation.DataSource = core.DataHandler.DataToList(DataBaseTypes.LOCATION);

            // Add the events to listen for
            moveDataGridView.CellValueChanged += new DataGridViewCellEventHandler(moveDataGridViewCellValueChanged);
            moveDataGridView.CurrentCellDirtyStateChanged += new EventHandler(moveDataGridViewCurrentCellDirtyStateChanged);
        }

        // This event handler manually raises the CellValueChanged event 
        // by calling the CommitEdit method. 
        void moveDataGridViewCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.moveDataGridView.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                moveDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private List<Item> ItemList(DataGridViewCell eventCell)
        {
            List<Item> input = core.DataHandler.DataToList(DataBaseTypes.INFO).Cast<Item>().ToList();
            return input.Where(x => x.ItemNo.Equals(eventCell.Value)).ToList();
        }

        private List<Location> LocationList(DataGridViewCell eventCell)
        {
            List<Location> input = core.DataHandler.DataToList(DataBaseTypes.LOCATION).Cast<Location>().ToList();
            return input.Where(x => x.ItemNo.Equals(eventCell.Value)).ToList();
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
            //Sets originalCell to reference the cell the event was called from
            var dgv = sender as DataGridView;
            var originalCell = dgv[e.ColumnIndex, e.RowIndex];

            DataGridViewCell eventCell = moveDataGridView[e.ColumnIndex, e.RowIndex];

            //If the cellValueChanged was called from the first column, aka. "itemNo" Set the datasource for the second column "ItemName"
            if (e.ColumnIndex == 0)
            {
                //Cell is hardcoded to reference the column next to "itemNo", which should be "ItemName"
                var cell = dgv[e.ColumnIndex + 1, e.RowIndex] as DataGridViewComboBoxCell;
                cell.DataSource = ItemList(eventCell);

                //Cell is hardcoded to reference the column 3 right of "itemNo", which should be "ItemLocation"
                var cell2 = dgv[e.ColumnIndex + 3, e.RowIndex] as DataGridViewComboBoxCell;
                cell2.DataSource = LocationList(eventCell);
            }
        }

       /* public void ManualMove()
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
