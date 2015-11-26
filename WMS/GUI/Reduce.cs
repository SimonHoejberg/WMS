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
using static WMS.Reference.DataBaseValues;
using static WMS.Reference.DataBaseTypes;

namespace WMS.GUI
{
    public partial class Reduce : Form , IGui
    {
        private ICore core;
        private BindingSource bsource;
        private DataTable data;
        private string itemNo;
        private ILang lang;
        private string error;
        private string mustBePostive;
        private string mustBeAnumber;
       
        public Reduce(ICore core, ILang lang)
        {
            this.core = core;
            this.lang = lang;
            InitializeComponent();
            SearchBox();
            searchBtn.Text = lang.SEACH;
            Text = lang.REDUCE;
            reduceConfirmBtn.Text = lang.CONFIRM;
            reduceCancelBtn.Text = lang.CANCEL;
            error = lang.ERROR;
            button1.Text = lang.REMOVE_ROW;
            mustBePostive = lang.MUST_BE_A_POSITIVE;
            mustBeAnumber = lang.MUST_BE_A_NUMER;
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
            DialogResult a = MessageBox.Show(lang.CONFIRM_TEXT, lang.CONFIRM, MessageBoxButtons.OKCancel);
            if (a.Equals(DialogResult.OK))
            {
                for (int i = 0; i < reduceDataGridView.RowCount; i++)
                {
                    if (reduceDataGridView[0, i].Value != null && !(reduceDataGridView[6, i].Value.Equals("0")))
                    {
                        core.DataHandler.ActionOnItem('-',reduceDataGridView[0, i].Value.ToString(), reduceDataGridView[1, i].Value.ToString(), core.GetTimeStamp(),int.Parse(reduceDataGridView[6,i].Value.ToString()), lang.REDUCED);
                    }
                }
                MessageBox.Show(lang.SUCCESS_REDUCE, lang.SUCCESS);
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
                core.DataHandler.GetDataFromItemNo(itemNo, INFO).Fill(data);
            }
            MakeDataGridView();
        }

        private void MakeDataGridView()
        {
            reduceDataGridView.CellValueChanged -= reduceDataGridView_CellValueChanged;
            reduceDataGridView.Columns[0].HeaderText = lang.ITEM_NO;
            reduceDataGridView.Columns[1].HeaderText = lang.DESCRIPTION;
            reduceDataGridView.Columns[2].HeaderText = lang.IN_STOCK;
            reduceDataGridView.Columns[3].HeaderText = lang.LOCATION;
            reduceDataGridView.Columns[4].Visible = false;

            if (!data.Columns.Contains(lang.AMOUNT))
            {
                data.Columns.Add(lang.AMOUNT);
            }
            for (int i = 0; i < reduceDataGridView.ColumnCount; i++)
            {
                if (!reduceDataGridView.Columns[i].HeaderText.Equals(lang.AMOUNT))
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
            reduceDataGridView.CellValueChanged -= reduceDataGridView_CellValueChanged;
            this.lang = lang;
            searchBtn.Text = lang.SEACH;
            Text = lang.REDUCE;
            reduceConfirmBtn.Text = lang.CONFIRM;
            reduceCancelBtn.Text = lang.CANCEL;
            error = lang.ERROR;
            mustBePostive = lang.MUST_BE_A_POSITIVE;
            mustBeAnumber = lang.MUST_BE_A_NUMER;
            button1.Text = lang.REMOVE_ROW;
            if (reduceDataGridView.ColumnCount > 0)
            {
                reduceDataGridView.Columns[0].HeaderText = lang.ITEM_NO;
                reduceDataGridView.Columns[1].HeaderText = lang.DESCRIPTION;
                reduceDataGridView.Columns[2].HeaderText = lang.IN_STOCK;
                reduceDataGridView.Columns[3].HeaderText = lang.LOCATION;
                reduceDataGridView.Columns[4].Visible = false;
                reduceDataGridView.Columns[5].HeaderText = lang.AMOUNT;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (reduceDataGridView.CurrentCell != null)
            {
                reduceDataGridView.Rows.RemoveAt(reduceDataGridView.CurrentCell.RowIndex);
            }
        }
    }
}
