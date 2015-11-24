using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using WMS.Interfaces;
using WMS.WH;
using System.Diagnostics;

namespace WMS.GUI
{
    public partial class Register : Form, IGui
    {
        private ICore core;
        private BindingSource bsource = new BindingSource();
        private DataTable data = new DataTable();
        private ILang lang;
        private string error;
        private string mustBePostive;
        private string mustBeAnumber;
        private string onlyNumbers;

        public Register(ICore core, ILang lang)
        {
            this.core = core;
            this.lang = lang;
            InitializeComponent();
            updateComboBox();
            comboBox1.SelectedIndex = -1;
            Text = lang.REGISTER;
            textBox1.Text = lang.ORDER_NO;
            confirmBtn.Text = lang.CONFIRM;
            button1.Text = lang.CANCEL;
            error = lang.ERROR;
            mustBePostive = lang.MUST_BE_A_POSITIVE;
            mustBeAnumber = lang.MUST_BE_A_NUMER;
            onlyNumbers = lang.ONLY_NUMBERS;
        }

        public void UpdateGuiElements()
        {

        }
        
        private void updateDataGridView(string orderNo)
        {
            dataGridView.CellValueChanged -= dataGridView2_CellValueChanged;
            data.Clear();
            bsource.DataSource = data;
            dataGridView.DataSource = bsource;
            core.DataHandler.GetDataFromOrderNo(orderNo).Fill(data);

            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].HeaderText = lang.ORDER_NO;
            dataGridView.Columns[2].HeaderText = lang.ITEM_NO;
            dataGridView.Columns[3].HeaderText = lang.DESCRIPTION;
            dataGridView.Columns[4].HeaderText = lang.EXPECTED_AMOUNT;
            if (!data.Columns.Contains(lang.AMOUNT))
            {
                data.Columns.Add(lang.AMOUNT);
            }
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


        private void confirmBtn_Click(object sender, EventArgs e)
        {
            List<Item> tempList = new List<Item>();
            UserIDBox user_dialog = new UserIDBox(core,lang);
            user_dialog.Owner = this;
            DialogResult a = user_dialog.ShowDialog(); //Dialogresult is either OK or Cancel. OK only if correct userID was entered
            if (a.Equals(DialogResult.OK))
            {
                string user = user_dialog.User;
                int count = dataGridView.RowCount;
                for (int i = 0; i < count; i++)
                {
                    if (dataGridView[5, i].Value != null)
                    {
                        string itemNo = dataGridView[2, i].Value.ToString();
                        string description = dataGridView[3, i].Value.ToString();
                        int quantity = int.Parse(dataGridView[5, 1].Value.ToString());
                        core.DataHandler.ActionOnItem('+', itemNo, description, core.GetTimeStamp(), quantity, user, lang.REGISTED);
                        Item item = core.DataHandler.GetItemFromItemNo(itemNo);
                        tempList.Add(item);
                    }
                }
                Console.WriteLine("Reg " + st.ElapsedMilliseconds / 1000 + " s " + st.ElapsedMilliseconds + " ms");
                if (tempList.Count != 0)
                { 
                    core.SortNewItems(tempList);
                    MessageBox.Show(lang.SUCCESS_REGISTER, lang.SUCCESS);
                }
                data.Clear();
                core.WindowHandler.Update(this);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int temp = 0;
                if(int.TryParse(textBox1.Text,out temp))
                {
                    updateDataGridView(textBox1.Text);
                }
                else
                {
                    MessageBox.Show(onlyNumbers, error);
                    textBox1.Text = "";
                }
                
            }

        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView.CellValueChanged -= dataGridView2_CellValueChanged;
            string temp = dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
            int tempInt = 0;
            if (temp != null)
            {
                if (!int.TryParse(temp, out tempInt))
                {
                    MessageBox.Show(mustBeAnumber, error);
                    dataGridView[e.ColumnIndex, e.RowIndex].Value = null;
                }
                else if(tempInt < 0)
                {
                    MessageBox.Show(mustBePostive, error);
                    dataGridView[e.ColumnIndex, e.RowIndex].Value = null;
                }
            }
            dataGridView.CellValueChanged += dataGridView2_CellValueChanged;

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
            CancelBox cancel = new CancelBox(lang);
            cancel.Owner = this;
            DialogResult a = cancel.ShowDialog();

            if (a.Equals(DialogResult.OK))
            {
                data.Clear();
            }
        }

        public void UpdateLang(ILang lang)
        {
            dataGridView.CellValueChanged -= dataGridView2_CellValueChanged;
            this.lang = lang;
            Text = lang.REGISTER;
            textBox1.Text = lang.ORDER_NO;
            confirmBtn.Text = lang.CONFIRM;
            button1.Text = lang.CANCEL;
            error = lang.ERROR;
            mustBePostive = lang.MUST_BE_A_POSITIVE;
            mustBeAnumber = lang.MUST_BE_A_NUMER;
            onlyNumbers = lang.ONLY_NUMBERS;
            if (dataGridView.ColumnCount > 0)
            {
                dataGridView.Columns[1].HeaderText = lang.ORDER_NO;
                dataGridView.Columns[2].HeaderText = lang.ITEM_NO;
                dataGridView.Columns[3].HeaderText = lang.DESCRIPTION;
                dataGridView.Columns[4].HeaderText = lang.EXPECTED_AMOUNT;
                dataGridView.Columns[5].HeaderText = lang.AMOUNT;
            }
            dataGridView.CellValueChanged += dataGridView2_CellValueChanged;
        }
    }
}
