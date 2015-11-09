using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMS.Core;
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
    public partial class moveLoadOptimal : Form, IGui
    {
        private ICore core;
        public List<Location> locationList;
        DataGridViewComboBoxColumn ComboColumnItemNo, ComboColumnName, ComboColumnLocation, ComboColumnQuantity, ComboColumnNewLocation;

        public moveLoadOptimal(ICore core)
        {
            InitializeComponent();
            this.core = core;

            //Creates the DataGridViewComboBoxColumns that makes up the datagridview
            ComboColumnItemNo = new DataGridViewComboBoxColumn();
            ComboColumnName = new DataGridViewComboBoxColumn();
            ComboColumnLocation = new DataGridViewComboBoxColumn();
            ComboColumnQuantity = new DataGridViewComboBoxColumn();
            ComboColumnNewLocation = new DataGridViewComboBoxColumn();

            //Sets the Displaymembers for the DataGridViewComboBoxColumns
            ComboColumnItemNo.DisplayMember = "ItemNoString";
            ComboColumnName.DisplayMember = "Description";
            ComboColumnLocation.DisplayMember = "LocationToString";

            //Sets the Valuemembers for the DataGridViewComboBoxColumns
            ComboColumnItemNo.DisplayMember = "ItemNoString";

            //Sets the HeaderTexts for the DataGridViewComboBoxColumns
            ComboColumnItemNo.HeaderText = "Item Number";
            ComboColumnName.HeaderText = "Item Name";
            ComboColumnQuantity.HeaderText = "Quantity";
            ComboColumnLocation.HeaderText = "Location";
            ComboColumnNewLocation.HeaderText = "New Location";

            //Adds DataGridViewComboBoxColumns to DataGridView
            moveMain_dgv.Columns.Add(ComboColumnItemNo);
            moveMain_dgv.Columns.Add(ComboColumnName);
            moveMain_dgv.Columns.Add(ComboColumnQuantity);
            moveMain_dgv.Columns.Add(ComboColumnLocation);
            moveMain_dgv.Columns.Add(ComboColumnNewLocation);

            //Sets the initial datasources
            ComboColumnItemNo.DataSource = core.DataHandler.DataToList(WindowTypes.INFO, this);
            ComboColumnName.DataSource = core.DataHandler.DataToList(WindowTypes.INFO, this);
            ComboColumnLocation.DataSource = core.DataHandler.DataToList("location", this);

            // Add the events to listen for
            moveMain_dgv.CellValueChanged += new DataGridViewCellEventHandler(moveMain_dgv_CellValueChanged);
            moveMain_dgv.CurrentCellDirtyStateChanged += new EventHandler(moveMain_dgv_CurrentCellDirtyStateChanged);
        }

        // This event handler manually raises the CellValueChanged event 
        // by calling the CommitEdit method. 
        void moveMain_dgv_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.moveMain_dgv.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                moveMain_dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        //Returns list for DataSource
        private List<object> getListForDatasource(string listType, DataGridViewCell eventCell)
        {
            List<object> returnList = new List<object>();

            if (listType.Equals("item"))
            {
                foreach (Item item in core.DataHandler.DataToList("information", this))
                {
                    if (eventCell.Value.Equals(item.ItemNo.ToString()))
                    {
                        returnList.Add(item);
                    }
                }
            }

            else if (listType.Equals("location"))
            {
                foreach (Location location in core.DataHandler.DataToList("location", this))
                {
                    if (eventCell.Value.Equals(location.LocItem.ItemNo.ToString()))
                    {
                        returnList.Add(location);
                    }
                }
            }

            return returnList;
        }

        private void moveLoadOptimal_btn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in moveMain_dgv.Rows)
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

        private void moveMain_dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Sets originalCell to reference the cell the event was called from
            var dgv = sender as DataGridView;
            var originalCell = dgv[e.ColumnIndex, e.RowIndex];

            DataGridViewCell eventCell = moveMain_dgv[e.ColumnIndex, e.RowIndex];

            //If the cellValueChanged was called from the first column, aka. "itemNo" Set the datasource for the second column "ItemName"
            if (e.ColumnIndex == 0)
            {
                //Cell is hardcoded to reference the column next to "itemNo", which should be "ItemName"
                var cell = dgv[e.ColumnIndex + 1, e.RowIndex] as DataGridViewComboBoxCell;
                cell.DataSource = getListForDatasource("item", eventCell);

                //Cell is hardcoded to reference the column next to "itemNo", which should be "ItemName"
                var cell2 = dgv[e.ColumnIndex + 3, e.RowIndex] as DataGridViewComboBoxCell;
                cell2.DataSource = getListForDatasource("location", eventCell);
            }
        }

        public void ManualMove()
        {
            int itemInStockIncrease = 0;
            int itemInStockDecrease = 0;

            //Checks the types of the different cells
            for (int i = 0; i < moveMain_dgv.Columns.Count; i++)
            {

                if (!(TypeChecker(moveMain_dgv.Rows[i])))
                {
                    TryAgain();

                    //temporary
                    return;
                }
            }

            foreach (DataGridViewRow row in moveMain_dgv.Rows)
            {
                //Searches for items with the same location as the new location
                //could use a location search
                foreach (Item item in core.DataHandler.DataToList(WindowTypes.INFO, this))
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

                            //moves quantity to location
                            //add (int)row.Cells[3].value to item.InStock
                        }
                        else { TryAgain(); }
                    }
                    // something for when shelf and cells[4] are not equal
                }
            }
        }

        private bool TypeChecker(DataGridViewRow row)
        {
            bool typeInt = true;
            int tempInt;

            for (int i = 0; i < 5; i++)
            {
                if (i != 1 && (string.IsNullOrEmpty(row.Cells[i].Value.ToString()) || !int.TryParse(row.Cells[i].Value.ToString(), out tempInt)))
                {
                    Console.WriteLine("mistake at:" + i.ToString() + " " + row.Cells[i].Value.GetType().ToString());
                    typeInt = false;
                }
                else Console.WriteLine("worked at:" + i.ToString());
            }
            return typeInt;
        }

        public string GetTypeOfWindow()
        {
            return "move";
        }

        public void FilterColumn(string a)
        {

        }

        private void moveMain_dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //things to do when a new row is added (e.g. disable some cells, change styles for cells)
            DataGridViewCellStyle a = new DataGridViewCellStyle();
            a.SelectionForeColor = Color.AliceBlue;
            (moveMain_dgv[0, e.RowIndex] as DataGridViewComboBoxCell).Style = a;
        }

        public void UpdateGuiElements()
        {

        }

        //for when errors occur
        private void TryAgain()
        {

        }

        private void Move_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void moveConfirm_btn_Click(object sender, EventArgs e)
        {
            //Current button event is made for testing the confirmation box. (passowd/userID)
            ManualMove();
        }
    }
}
