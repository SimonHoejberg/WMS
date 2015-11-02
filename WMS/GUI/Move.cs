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
    }
}
