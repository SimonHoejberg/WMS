using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMS.Interfaces;
using WMS.WH;
using static WMS.Reference.SearchTerms;
using static WMS.Reference.DataBases;

namespace WMS.GUI
{
    public partial class Reduce : Form , IGui
    {
        private ICore core;
        private BindingSource bsource;
        private DataTable data;
        private string error;
        private string mustBePostive;
        private string mustBeAnumber;
       
        public Reduce(ICore core)
        {
            this.core = core;
            InitializeComponent();
            SearchBox();
            searchBtn.Text = core.Lang.ADD;
            Text = core.Lang.REDUCE;
            reduceConfirmBtn.Text = core.Lang.CONFIRM;
            reduceCancelBtn.Text = core.Lang.CANCEL;
            error = core.Lang.ERROR;
            button1.Text = core.Lang.REMOVE_ROW;
            mustBePostive = core.Lang.MUST_BE_A_POSITIVE;
            mustBeAnumber = core.Lang.MUST_BE_A_NUMER;
            bsource = new BindingSource();
            data = new DataTable();
            bsource.DataSource = data;
            reduceDataGridView.DataSource = bsource;
        }

        public void SearchBox()
        {
            var source = new AutoCompleteStringCollection();

            foreach (Item item in core.DataHandler.InfoToList())
            {
                source.Add(item.ItemNo);
            }
            textBox1.AutoCompleteCustomSource = source;
        }

        public void UpdateGuiElements()
        {

        }

        private void reduceConfirmBtn_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show(core.Lang.CONFIRM_TEXT, core.Lang.CONFIRM, MessageBoxButtons.OKCancel);
            if (a.Equals(DialogResult.OK))
            {
                for (int i = 0; i < reduceDataGridView.RowCount; i++)
                {
                    if (reduceDataGridView[0, i].Value != null && !(reduceDataGridView[5, i].Value.Equals("0")))
                    {
                        core.DataHandler.ActionOnItem('-', reduceDataGridView[0, i].Value.ToString(), reduceDataGridView[1, i].Value.ToString(),reduceDataGridView[5,i].Value.ToString(), core.Lang.REDUCED, "");
                    }
                }
                MessageBox.Show(core.Lang.SUCCESS_REDUCE, core.Lang.SUCCESS);
                core.WindowHandler.Update(this);
                data.Clear();
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            int temp = 0;
            if (int.TryParse(textBox1.Text, out temp))
            { 
                string itemNo = textBox1.Text;
                core.DataHandler.GetDataFromItemNo(itemNo, INFOMATION_DB).Fill(data);
                MakeDataGridView();
            }
            
        }

        private void MakeDataGridView()
        {
            reduceDataGridView.CellValueChanged -= reduceDataGridView_CellValueChanged;
            reduceDataGridView.Columns[0].HeaderText = core.Lang.ITEM_NO;
            reduceDataGridView.Columns[1].HeaderText = core.Lang.DESCRIPTION;
            reduceDataGridView.Columns[2].HeaderText = core.Lang.IN_STOCK;
            reduceDataGridView.Columns[3].HeaderText = core.Lang.LOCATION;
            reduceDataGridView.Columns[4].Visible = true;

            if (!data.Columns.Contains(core.Lang.AMOUNT))
            {
                data.Columns.Add(core.Lang.AMOUNT);
            }
            for (int i = 0; i < reduceDataGridView.ColumnCount; i++)
            {
                if (!reduceDataGridView.Columns[i].HeaderText.Equals(core.Lang.AMOUNT))
                {
                    reduceDataGridView.Columns[i].ReadOnly = true;
                }
                reduceDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            reduceDataGridView.CellValueChanged += reduceDataGridView_CellValueChanged;
        }

        private void Reduce_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void reduceDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            reduceDataGridView.CellValueChanged -= reduceDataGridView_CellValueChanged;
            string temp = reduceDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
            Regex regex = new Regex("^[0-9]+$");
            int tempInt = 0;
            if (temp != null)
            {
                if (!int.TryParse(temp,out tempInt))
                {
                    MessageBox.Show(mustBeAnumber, error);
                    reduceDataGridView[e.ColumnIndex, e.RowIndex].Value = null;
                }
                else if (tempInt < 0)
                {
                    MessageBox.Show(mustBePostive, error);
                    reduceDataGridView[e.ColumnIndex, e.RowIndex].Value = null;
                }
            }
            reduceDataGridView.CellValueChanged += reduceDataGridView_CellValueChanged;
        }

        private void reduceCancelBtn_Click(object sender, EventArgs e)
        {
            CancelBox cancel = new CancelBox(core.Lang);
            cancel.Owner = this;
            DialogResult a = cancel.ShowDialog();

            if (a.Equals(DialogResult.OK))
            {
                data.Clear();
            }
        }

        public void UpdateLang()
        {
            reduceDataGridView.CellValueChanged -= reduceDataGridView_CellValueChanged;
            searchBtn.Text = core.Lang.ADD;
            Text = core.Lang.REDUCE;
            reduceConfirmBtn.Text = core.Lang.CONFIRM;
            reduceCancelBtn.Text = core.Lang.CANCEL;
            error = core.Lang.ERROR;
            mustBePostive = core.Lang.MUST_BE_A_POSITIVE;
            mustBeAnumber = core.Lang.MUST_BE_A_NUMER;
            button1.Text = core.Lang.REMOVE_ROW;
            if (reduceDataGridView.ColumnCount > 0)
            {
                reduceDataGridView.Columns[0].HeaderText = core.Lang.ITEM_NO;
                reduceDataGridView.Columns[1].HeaderText = core.Lang.DESCRIPTION;
                reduceDataGridView.Columns[2].HeaderText = core.Lang.IN_STOCK;
                reduceDataGridView.Columns[3].HeaderText = core.Lang.LOCATION;
                reduceDataGridView.Columns[4].Visible = false;
                reduceDataGridView.Columns[5].HeaderText = core.Lang.AMOUNT;
            }
            reduceDataGridView.CellValueChanged += reduceDataGridView_CellValueChanged;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                searchBtn_Click(sender, e);
            }
        }

        private void reduceDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
                foreach (Location a in core.DataHandler.LocationToList())
                {
                    if (a.ItemNo.Equals(reduceDataGridView[0,0].Value))
                    {
                        (reduceDataGridView.Rows[0].Cells[5] as DataGridViewComboBoxCell).Items.Add(a.LocationString);
                    }
                }

            (reduceDataGridView.Rows[0].Cells[5] as DataGridViewComboBoxCell).Value = (reduceDataGridView.Rows[0].Cells[5] as DataGridViewComboBoxCell).Items[0];
        }
    }
}
