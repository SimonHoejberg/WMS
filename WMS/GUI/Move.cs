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

            DataGridViewComboBoxColumn ComboColumn = new DataGridViewComboBoxColumn();

            ArrayList row1 = new ArrayList();

            /*foreach (Item a in core.getDataForList())
                row1.Add()

            dataGridView4.Columns.Add(ComboColumn);*/

            




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

        private void button6_Click(object sender, EventArgs e)
        {
/*
            int tempInt = 0;

            foreach (DataGridViewCell cell in dataGridView4.SelectedCells)
            {
                if (cell.ColumnIndex == 0)
                {

                }
                if (cell.ColumnIndex == 4)
                {
                    Console.WriteLine("column: " + cell.Value.ToString());
                    ManualMove(cell.Value.ToString());
                }
            }
            /*    if(cell.ColumnIndex == 0)
                {
                    //hent resten af info fra DB
                    //brug itemNo, current location og itemQuantity
                    //smid ind i algoritmen og find en ny spot

                      
                }

                if(cell.ColumnIndex == 4 && tempItemExist)
                {
                    foreach (Item item in core.dataToList("information"))
                    {

                    }
                } 
            }*/
        }

        // ManualMove should either receive an itemNo or an item.
        public void ManualMove(string newPosition)
        {
            Item tempItem = new Item(42, "test", 30, 2, 30);
            bool tempItemExist = false;
            int nPos = Int32.Parse(newPosition);

            foreach (Item item in core.dataToList("information"))
            {
                //Needs to be able to check something about weight
                if (item.Shelf == nPos)
                {
                    tempItemExist = true;
                }
            }
            tempItem.Shelf = nPos;
            Console.WriteLine(tempItem.Shelf.ToString());
        }

        public Item FindItem(int itemNo)
        {
            foreach (Item item in core.dataToList("information"))
            {
                if (item.ItemNo == itemNo)
                {
                    return item;
                }
            }
            return (new Item(3, "bad item", 0, 1, 1));
        }
    }
}
