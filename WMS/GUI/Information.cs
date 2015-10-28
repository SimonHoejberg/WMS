﻿using System;
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
        ICore core;
        
        public Information(ICore core)
        {
            InitializeComponent();
            this.core = core;
            updateInfo();
        }
        private void updateInfo()
        {

            BindingSource bsource = new BindingSource();
            DataTable data = new DataTable();

            bsource.DataSource = data;
            dataGridView1.DataSource = bsource;

            core.getData(GetTypeOfWindow()).Fill(data);

            dataGridView1.Columns[0].Name = "Item No";
            dataGridView1.Columns[1].Name = "Description";
            dataGridView1.Columns[2].Name = "In stock";
            dataGridView1.Columns[3].Name = "Location";
            for (int i = 0; i < dataGridView1.ColumnCount; i++) { 
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            run = true;
        }
        private void dataGridView1_cellChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (run)
            {
                string coloumn = dataGridView1.Columns[e.ColumnIndex].Name.ToString();
                string value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                core.UpdateProduct(coloumn, value, id,GetTypeOfWindow());
                core.Update(this);
            }

        }

        public void UpdateGuiElements(){
            updateInfo();
        }

        public string GetTypeOfWindow()
        {
            return "information";
        }
    }
}
