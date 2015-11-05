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
using WMS.Reference;

namespace WMS.GUI
{
    public partial class Reduce : Form , IGui
    {
        private ICore core;
        private bool Run = false;
        private bool First = true;
        BindingSource bsource;
        DataTable data;

       
        public Reduce(ICore core)
        {
            this.core = core;
            InitializeComponent();
            MakeComboBox();
            bsource = new BindingSource();
            data = new DataTable();
            bsource.DataSource = data;
            reduceDataGridView.DataSource = bsource;


        }

        public string GetTypeOfWindow()
        {
            return WindowTypes.REDUCE;
        }

        public void UpdateGuiElements()
        {

        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MakeComboBox()
        {
            comboBox2.DataSource = core.DataHandler.dataToList(WindowTypes.INFO);
            Run = true;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (Run)
            {
                string[] itemNo = new string[5];
                string output = comboBox2.SelectedItem.ToString();
                itemNo = output.Split(' ');

                
                core.DataHandler.GetDataFromItemNo(itemNo[1], WindowTypes.INFO).Fill(data);
                if (First)
                {
                    reduceDataGridView.Columns[2].Visible = false;
                    reduceDataGridView.Columns[4].Visible = false;
                    reduceDataGridView.Columns[5].Visible = false;
                    data.Columns.Add("Quantity");
                    First = false;
                }

                for (int i = 0; i < reduceDataGridView.ColumnCount; i++)
                {
                    reduceDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            
        }

        private void reduceConfirmBtn_Click(object sender, EventArgs e)
        {
            UserIDBox user_dialog = new UserIDBox(core);
            DialogResult a = user_dialog.ShowDialog();
        }

        private void Reduce_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}
