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

namespace WMS.GUI
{
    public partial class Move : Form, IGui
    {
        
        private ICore core;
        public List<Location> locationList;

        public Move(ICore core)
        {
            InitializeComponent();
            this.core = core;

            //List of locations. Not supposed to be in the final implementation. I can't database, thats why!
            /*locationList = new List<Location>();
            for(int a = 1; a <= 15; a++)
            {
                string b = a.ToString();
                locationList.Add(new Location(1, b, 1, 1, 1, 1, 1));
            }*/


            DataGridViewComboBoxColumn ComboColumnItemNo = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn ComboColumnName = new DataGridViewComboBoxColumn();
            /*DataGridViewComboBoxColumn ComboColumnLocation = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn ComboColumnQuantity = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn ComboColumnNewLocation = new DataGridViewComboBoxColumn();*/


            foreach (Item a in core.DataHandler.DataToList("information",this))
            {
                ComboColumnItemNo.Items.Add(a);
                ComboColumnName.Items.Add(a);
                //ComboColumnLocation.Items.Add(a);
            }

            ComboColumnItemNo.DisplayMember = "ItemNoString";
            ComboColumnName.DisplayMember = "Description";

            ComboColumnItemNo.HeaderText = "Item Number";
            ComboColumnName.HeaderText = "Item Name";

            dataGridView4.Columns.Add(ComboColumnItemNo);
            dataGridView4.Columns.Add(ComboColumnName);

            // Add the events to listen for
            dataGridView4.CellValueChanged += new DataGridViewCellEventHandler(dataGridView4_CellValueChanged);
            dataGridView4.CurrentCellDirtyStateChanged += new EventHandler(dataGridView1_CurrentCellDirtyStateChanged);



        }

        public void FilterColumn(string a)
        {

        }

        public string GetTypeOfWindow()
        {
            return "move";
        }

        public void UpdateGuiElements()
        {
            
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            //Current button event is made for testing the confirmation box. (passowd/userID)
            ManualMove();
        }

        //Find optimal location
        private void button6_Click(object sender, EventArgs e)
        {
            foreach (Item item in core.DataHandler.DataToList(WindowTypes.INFO,this))
            {
                Console.Write("4");
            }

            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[4].Value == null)
                {
                    //use algorithm here
                    //send itemNo, current location and itemQuantity
                    row.Cells[4].Value = 3;
                    
                }
            }
        }
        
        
        public void ManualMove()
        {
            int itemInStockIncrease = 0;
            int itemInStockDecrease = 0;

            //Checks the types of the different cells
            for (int i = 0; i < dataGridView4.Columns.Count; i++)
            {
                if (!(TypeChecker(dataGridView4.Rows[i])))
                {
                        TryAgain();

                    //temporary
                    return;
                    }
                }

            foreach (DataGridViewRow row in dataGridView4.Rows)
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
                            core.DataHandler.UpdateProduct("4", itemInStockIncrease.ToString(), item.ItemNo.ToString(), WindowTypes.INFO, this);
                            
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

        //for when errors occur
        private void TryAgain()
        {
            
        }

        

        // This event handler manually raises the CellValueChanged event 
        // by calling the CommitEdit method. 
        void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dataGridView4.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                dataGridView4.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView4_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;

            var originalCell = dgv[e.ColumnIndex, e.RowIndex];
            var cell = dgv[e.ColumnIndex + 1, e.RowIndex] as DataGridViewComboBoxCell;

            if (cell == null)
            {
                return;
            }

            string test = dataGridView4[e.ColumnIndex, e.RowIndex].Value.ToString();

            cell.DataSource = GetSortedListOfItems(test, "name");
        }
            
        private List<Item> GetSortedListOfItems(string a, string b)
        {
            List<Item> returnList = new List<Item>();

            if (a != null && b.Equals("name"))
            {
                foreach (Item item in core.DataHandler.DataToList("information", this))
                {
                    if (a.Equals(item.ItemNo.ToString()))
                    {
                        Console.WriteLine(item.ItemNo + " " + Convert.ToInt32(a));
                        returnList.Add(item);
                    }
                }
            }

            return returnList;
        }

        private void Move_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
    }
}
