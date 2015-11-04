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
        public Move(ICore core)
        {
            InitializeComponent();
            this.core = core;

            DataGridViewComboBoxColumn ComboColumnItemNo = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn ComboColumnName = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn ComboColumnLocation = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn ComboColumnQuantity = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn ComboColumnNewLocation = new DataGridViewComboBoxColumn();

            foreach (Item a in core.DataHandler.dataToList("information"))
            {
                ComboColumnItemNo.Items.Add(a);
                ComboColumnName.Items.Add(a);
                ComboColumnLocation.Items.Add(a);
            }

            ComboColumnItemNo.DisplayMember = "ItemNo";
            ComboColumnName.DisplayMember = "Description";
            ComboColumnLocation.DisplayMember = "";

            dataGridView4.Columns.Add(ComboColumnItemNo);

            



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

        }

        //Find optimal location
        private void button6_Click(object sender, EventArgs e)
        {
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
        
        public void ManualMove(DataGridViewRow row)
        {
            //Searches for empty cells
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value == null)
                {
                    TryAgain();
                }
            }

            //Searches for items with the same location as the new location
            foreach (Item item in core.DataHandler.dataToList("information"))
            {
                if (item.Shelf == (int)row.Cells[4].Value && item.ItemNo != (int)row.Cells[0].Value)
                {
                    TryAgain();
                }
                else if (item.Size - item.InStock >= (int)row.Cells[3].Value)
                {
                    //add (int)row.Cells[3].value to item.InStock
                }
                // something for when shelf and cells[4] are not equal
            }
        }

        //for when errors occur
        private void TryAgain()
        {

        }
    }
}
