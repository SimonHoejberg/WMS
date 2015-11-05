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
            locationList = new List<Location>();
            for(int a = 1; a <= 15; a++)
            {
                string b = a.ToString();
                locationList.Add(new Location(1, b, 1, 1, 1, 1, 1));
            }

            DataGridViewComboBoxColumn ComboColumnItemNo = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn ComboColumnName = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn ComboColumnLocation = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn ComboColumnQuantity = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn ComboColumnNewLocation = new DataGridViewComboBoxColumn();


            foreach (Item a in core.DataHandler.DataToList("information"))
            {
                ComboColumnItemNo.Items.Add(a);
                ComboColumnName.Items.Add(a);
                ComboColumnLocation.Items.Add(a);
            }

            ComboColumnItemNo.DisplayMember = "ItemNo";
            ComboColumnName.DisplayMember = "Description";
            ComboColumnLocation.DisplayMember = "";

            dataGridView4.Columns.Add(ComboColumnItemNo);
            dataGridView4.Columns.Add(ComboColumnName);

            



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
            foreach (Item item in core.DataHandler.DataToList("information"))
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
            //Searches for empty cells in a row
            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        TryAgain();
                    }
                }

                //Searches for items with the same location as the new location
                //could use a location search
                foreach (Item item in core.DataHandler.DataToList("information"))
                {
                    if (item.Shelf == (int)row.Cells[4].Value)
                    {
                        // Sees if the items are the same and if there's room
                        if (item.ItemNo == (int)row.Cells[0].Value && item.Size - item.InStock >= (int)row.Cells[3].Value)
                        {
                            itemInStockIncrease = item.InStock + (int)row.Cells[3].Value;
                            //itemInStockDecrease = 

                            //core.DataHandler.UpdateProduct(4,,
                            
                            //moves quantity to location
                            //add (int)row.Cells[3].value to item.InStock
                        }
                        else { TryAgain(); }
                    }
                    // something for when shelf and cells[4] are not equal
                }
            }
        }

        //for when errors occur
        private void TryAgain()
        {
            
        }

        private void Move_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
    }
}
