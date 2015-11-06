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
using WMS.WH;

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
            comboBox2.DataSource = core.DataHandler.DataToList(WindowTypes.INFO);
            Run = true;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void reduceConfirmBtn_Click(object sender, EventArgs e)
        {
            UserIDBox user_dialog = new UserIDBox(core);
            DialogResult a = user_dialog.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            core.DataHandler.GetDataFromItemNo(comboBox2.Text, WindowTypes.INFO).Fill(data);
            if (First)
            {
                DataGridViewMake();
            }
        }

        private void DataGridViewMake()
        {
            reduceDataGridView.Columns[2].Visible = false;
            reduceDataGridView.Columns[4].Visible = false;
            reduceDataGridView.Columns[5].Visible = false;
            data.Columns.Add("Quantity");
            First = false;

            for (int i = 0; i < reduceDataGridView.ColumnCount; i++)
            {
                reduceDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            int a = 0;
            string[] b = new string[3];
            if (e.KeyCode == Keys.Enter && int.TryParse(comboBox2.Text, out a))
            {
                core.DataHandler.GetDataFromItemNo(comboBox2.Text, WindowTypes.INFO).Fill(data);
            }
            else if (e.KeyCode != Keys.Down && e.KeyCode != Keys.Up && e.KeyCode == Keys.Enter)
            {
                b = comboBox2.Text.Split(' ');
                core.DataHandler.GetDataFromItemNo(b[1], WindowTypes.INFO).Fill(data);
            }
            if (First && e.KeyCode == Keys.Enter)
            {
                DataGridViewMake();
            }
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            if (Run)
            {
                string[] itemNo = new string[5];
                string output = comboBox2.SelectedItem.ToString();
                itemNo = output.Split(' ');


                core.DataHandler.GetDataFromItemNo(itemNo[1], WindowTypes.INFO).Fill(data);
                if (First)
                {
                    DataGridViewMake();
                }
            }
        }

        private void Reduce_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
    }
}
