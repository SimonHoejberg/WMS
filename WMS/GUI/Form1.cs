using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMS.Interfaces;

namespace WMS
{
    public partial class Form1 : Form
    {
        ICore bridge;
        bool run = false;
        public Form1(ICore bridge)
        {
            this.bridge = bridge;
            InitializeComponent();
            updateInfo();
            registrationGrid();
            updateLog();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = registerTab;
        }

        private void reduceBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = reduceTab;
        }

        private void moveBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = moveTab;
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = infoTab;
        }

        private void logBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = logTab;
        }

        private void wasteBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = wasteTab;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }
        private void dataGridView1_cellChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (run)
            {
                string coloumn = dataGridView1.Columns[e.ColumnIndex].Name.ToString();
                string value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                
                bridge.UpdateProduct(coloumn, value, id);
                updateLog();
            }

        }
        private void registrationGrid()
        {
            DataTable data = new DataTable();
            BindingSource source = new BindingSource();
            
            data.Columns.Add("Item No"); 
            data.Columns.Add("Name");
            data.Columns.Add("Ordered");
            data.Columns.Add("Delivered");
            data.Rows.Add("212158", "Tire", 8, 8);
            source.DataSource = data;
            dataGridView2.DataSource = source;
            dataGridView2.Columns[1].Width = 250;

            
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

        private void updateLog()
        {
            BindingSource bsource = new BindingSource();
            DataTable data = new DataTable();

            bsource.DataSource = data;
            dataGridView5.DataSource = bsource;

            bridge.getLog().Fill(data);
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to continue!");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }
    }
}
