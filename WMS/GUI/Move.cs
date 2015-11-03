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

            foreach (Item a in core.dataToList("information"))
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

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dataGridView4.SelectedCells)
            {
                if(cell.ColumnIndex == 0)
                {
                    //hent resten af info fra DB
                    //brug itemNo, current location og itemQuantity
                    //smid ind i algoritmen og find en ny spot
                }
            }

        }
    }
}
