using System;
using System.Data;
using System.Windows.Forms;
using WMS.Interfaces;
using WMS.Reference;

namespace WMS.GUI
{
    public partial class Register : Form, IGui
    {
        private ICore core;
        public Register(ICore core)
        {
            this.core = core;
            InitializeComponent();
            updateComboBox();
        }

        public string GetTypeOfWindow()
        {
            return WindowTypes.REGISTER;
        }

        public void UpdateGuiElements()
        {

        }

        private void updateDataGridView(string orderNo)
        {
            dataGridView.CellValueChanged -= dataGridView2_CellValueChanged;
            BindingSource bsource = new BindingSource();
            DataTable data = new DataTable();
            bsource.DataSource = data;
            dataGridView.DataSource = bsource;
            core.DataHandler.GetDataFromOrderNo(orderNo).Fill(data);

            dataGridView.Columns[0].HeaderText = "Order No";
            dataGridView.Columns[1].HeaderText = "Item No";
            dataGridView.Columns[2].HeaderText = "Description";
            dataGridView.Columns[3].HeaderText = "Expected Quantity";
            data.Columns.Add("Quantity");
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                if (i < dataGridView.ColumnCount - 1)
                {
                    dataGridView.Columns[i].ReadOnly = true;
                }
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dataGridView.CellValueChanged += dataGridView2_CellValueChanged;
        }

        private void updateComboBox()
        {
            comboBox1.DataSource = core.DataHandler.OrderToList();
        }

        private void clearDataGridView()
        {
            dataGridView.CellValueChanged -= dataGridView2_CellValueChanged;
            BindingSource bsource = new BindingSource();
            DataTable data = new DataTable();
            bsource.DataSource = data;
            dataGridView.DataSource = bsource;
            dataGridView.CellValueChanged += dataGridView2_CellValueChanged;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserIDBox user_dialog = new UserIDBox(core);
            DialogResult a = user_dialog.ShowDialog(); //Dialogresult is either OK or Cancel. OK only if correct userID was entered
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                updateDataGridView(textBox1.Text);
            }
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            updateDataGridView(((Order)comboBox1.SelectedItem).OrderNo.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearDataGridView();
        }
    }
}
