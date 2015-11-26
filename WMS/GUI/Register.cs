using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using WMS.Interfaces;
using WMS.WH;

namespace WMS.GUI
{
    public partial class Register : Form, IGui
    {
        private ICore core;
        private BindingSource bsource = new BindingSource();
        private DataTable data = new DataTable();
        private ILang lang;
        private string orderNo;

        public Register(ICore core, ILang lang)
        {
            this.core = core;
            this.lang = lang;
            InitializeComponent();
            UpdateComboBox();
            orderComboBox.SelectedIndex = -1;

            //For the language to switch between Da and En
            Text = lang.REGISTER;
            orderTextBox.Text = lang.ORDER_NO;
            confirmButton.Text = lang.CONFIRM;
            cancelButton.Text = lang.CANCEL;
            searchButton.Text = lang.SEACH;
        }

        /// <summary>
        /// Updates the Gui's elements if needed
        /// </summary>
        public void UpdateGuiElements()
        {
            //NOOP
        }

        /// <summary>
        /// Updates the dataGridView with the data from the Sql server based on a order no
        /// </summary>
        /// <param name="orderNo"></param>
        private void UpdateDataGridView(string orderNo)
        { 
            dataGridView.CellValueChanged -= DataGridViewCellValueChanged; //Unsubscribes from the event because the event fires when we fill in data
            data.Clear();   //Clears the dataGridView if a new order is choosen
            bsource.DataSource = data;
            dataGridView.DataSource = bsource;
            core.DataHandler.GetDataFromOrderNo(orderNo).Fill(data); //Fills the dataGridView with data from the server

            //Sets up what the columns based on the data from the server with the correct headerText
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].HeaderText = lang.ORDER_NO;
            dataGridView.Columns[2].HeaderText = lang.ITEM_NO;
            dataGridView.Columns[3].HeaderText = lang.DESCRIPTION;
            dataGridView.Columns[4].HeaderText = lang.EXPECTED_AMOUNT;
            
            //Adds a new column that is no on the database if doesnot already exist
            if (!data.Columns.Contains(lang.AMOUNT))
            {
                data.Columns.Add(lang.AMOUNT);
            }

            //Sets the auto size mode and sets the columns to read only
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                if (i < dataGridView.ColumnCount - 1)
                {
                    dataGridView.Columns[i].ReadOnly = true;
                }
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            //Sets the amount from the order to the expected amount
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                dataGridView[5, i].Value = dataGridView[4, i].Value;
            }

            dataGridView.CellValueChanged += DataGridViewCellValueChanged; //Resubscribes to the event
        }

        /// <summary>
        /// Sets the data in the combox with data from the server
        /// </summary>
        private void UpdateComboBox()
        {
            orderComboBox.DataSource = core.DataHandler.OrderToList();
        }

        /// <summary>
        /// When the user clicks on confirm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            List<Item> tempList = new List<Item>(); //
            DialogResult a = MessageBox.Show(lang.CONFIRM_TEXT, lang.CONFIRM, MessageBoxButtons.OKCancel);
            if (a.Equals(DialogResult.OK))
            {
                int count = dataGridView.RowCount;
                orderNo = dataGridView[1, 0].Value.ToString();
                for (int i = 0; i < count; i++)
                {
                    if (dataGridView[5, i].Value != null)
                    {
                        string itemNo = dataGridView[2, i].Value.ToString();
                        string description = dataGridView[3, i].Value.ToString();
                        int quantity = int.Parse(dataGridView[5, i].Value.ToString());
                        Item item = new Item(itemNo, description, quantity, null, core.DataHandler.GetUsage(itemNo));
                        tempList.Add(item);
                    }
                }
                if (tempList.Count != 0)
                {
                    core.SortNewItems(tempList, orderNo);
                    MessageBox.Show(lang.SUCCESS_REGISTER, lang.SUCCESS);
                }
                data.Clear();
                core.WindowHandler.Update(this);
            }
        }

        private void OrderTextBoxEnter(object sender, EventArgs e)
        {
            orderTextBox.Text = "";
        }

        private void OrderTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchButtonClick(sender, e);
            }
        }

        private void DataGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView.CellValueChanged -= DataGridViewCellValueChanged;
            string temp = dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
            int tempInt = 0;
            if (temp != null)
            {
                if (!int.TryParse(temp, out tempInt))
                {
                    MessageBox.Show(lang.MUST_BE_A_NUMER, lang.ERROR);
                    dataGridView[e.ColumnIndex, e.RowIndex].Value = null;
                }
                else if (tempInt < 0)
                {
                    MessageBox.Show(lang.MUST_BE_A_POSITIVE, lang.ERROR);
                    dataGridView[e.ColumnIndex, e.RowIndex].Value = null;
                }
            }
            dataGridView.CellValueChanged += DataGridViewCellValueChanged;

        }

        private void RegisterLoad(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void OrderComboBoxSelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateDataGridView(((Order)orderComboBox.SelectedItem).OrderNo.ToString());
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            CancelBox cancel = new CancelBox(lang);
            cancel.Owner = this;
            DialogResult a = cancel.ShowDialog();

            if (a.Equals(DialogResult.OK))
            {
                data.Clear();
            }
        }

        private void SearchButtonClick(object sender, EventArgs e)
        {
            int temp = 0;
            if (int.TryParse(orderTextBox.Text, out temp))
            {
                UpdateDataGridView(orderTextBox.Text);
            }
            else
            {
                MessageBox.Show(lang.ONLY_NUMBERS, lang.ERROR);
                orderTextBox.Text = "";
            }
        }

        #region Lang
        public void UpdateLang(ILang lang)
        {
            dataGridView.CellValueChanged -= DataGridViewCellValueChanged;
            this.lang = lang;
            Text = lang.REGISTER;
            orderTextBox.Text = lang.ORDER_NO;
            confirmButton.Text = lang.CONFIRM;
            cancelButton.Text = lang.CANCEL;
            searchButton.Text = lang.SEACH;
            if (dataGridView.ColumnCount > 0)
            {
                dataGridView.Columns[1].HeaderText = lang.ORDER_NO;
                dataGridView.Columns[2].HeaderText = lang.ITEM_NO;
                dataGridView.Columns[3].HeaderText = lang.DESCRIPTION;
                dataGridView.Columns[4].HeaderText = lang.EXPECTED_AMOUNT;
                dataGridView.Columns[5].HeaderText = lang.AMOUNT;
            }
            dataGridView.CellValueChanged += DataGridViewCellValueChanged;
        }
        #endregion
    }
}
