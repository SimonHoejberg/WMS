using System;
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

        private void updateDataGridView()
        {

        }

        private void updateComboBox()
        {
            comboBox1.DataSource = core.DataHandler.dataToList(GetTypeOfWindow());
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

        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }
    }
}
