using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMS.Interfaces;

namespace WMS.GUI
{
    public partial class Information : Form , IGui
    {
        bool run = false;
        IBridge bridge;
        
        public Information(IBridge bridge)
        {
            InitializeComponent();
            this.bridge = bridge;
            updateInfo();
        }
        private void updateInfo()
        {

            BindingSource bsource = new BindingSource();
            DataTable data = new DataTable();

            bsource.DataSource = data;
            dataGridView1.DataSource = bsource;

            bridge.getInfo().Fill(data);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Item No:";
            dataGridView1.Columns[2].HeaderText = "Name";
            dataGridView1.Columns[3].HeaderText = "Date";
            dataGridView1.Columns[4].HeaderText = "Bought";
            dataGridView1.Columns[5].HeaderText = "Sold";
            dataGridView1.Columns[6].HeaderText = "Sold Internal";
            dataGridView1.Columns[7].HeaderText = "Sold Custommer";
            dataGridView1.Columns[8].HeaderText = "Adjust";

            run = true;
        }
        private void dataGridView1_cellChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (run)
            {
                string coloumn = dataGridView1.Columns[e.ColumnIndex].Name.ToString();
                string value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                bridge.UpdateProduct(coloumn, value, id);
                //gui.updateLog();
            }

        }

        public void UpdateGuiElements(){

        }
    }
}
