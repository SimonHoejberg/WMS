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
using static WMS.Reference.SearchTerms;
using static WMS.Reference.DataBases;
using WMS.WH;

namespace WMS.GUI
{
    public partial class Waste : Form, IGui
    {
        private List<string> reasons;
        
        private ICore core;
        private BindingSource bsource;
        private DataTable data;
        private int lastRow;
        private ILang lang;
        private string error;
        private string mustBePostive;
        private string mustBeAnumber;

        public Waste(ICore core, ILang lang)
        {
            this.core = core;
            this.lang = lang;
            InitializeComponent();
            SearchBox();
            Text = lang.WASTE;
            chooseButton.Text = lang.CHOOSE;
            addLineButton.Text = lang.ADD;
            searchTextBox.Text = lang.ITEM_NO;
            button10.Text = lang.CANCEL;
            button11.Text = lang.CONFIRM;
            button3.Text = lang.REMOVE_ROW;
            error = lang.ERROR;
            mustBePostive = lang.MUST_BE_A_POSITIVE;
            mustBeAnumber = lang.MUST_BE_A_NUMER;
            bsource = new BindingSource();
            data = new DataTable();
            bsource.DataSource = data;
            wasteDataGridView.DataSource = bsource;
            MakeList();
        }

        private void MakeList()
        {
            reasons = new List<string>();
            reasons.Add(lang.BROKEN);
            reasons.Add(lang.WRONG_ITEM_DELIVRED);
            reasons.Add(lang.MISSING);

            listBox1.DataSource = reasons;
        }

        public void UpdateGuiElements()
        {

        }

        public void SearchBox()
        {
            var source = new AutoCompleteStringCollection();
            foreach (Item item in core.DataHandler.InfoToList())
            {
                source.Add(item.ItemNo);
            }
            searchTextBox.AutoCompleteCustomSource = source;
        }

        public void MakeDataGridView()
        {
            wasteDataGridView.CellValueChanged -= wasteDataGridView_CellValueChanged;
            wasteDataGridView.Columns[0].HeaderText = lang.ITEM_NO;
            wasteDataGridView.Columns[1].HeaderText = lang.DESCRIPTION;
            wasteDataGridView.Columns[2].HeaderText = lang.IN_STOCK;
            wasteDataGridView.Columns[3].HeaderText = lang.LOCATION;
            wasteDataGridView.Columns[4].Visible = false;
            if (!data.Columns.Contains(lang.AMOUNT))
            {
                data.Columns.Add(lang.AMOUNT);
            }
            if (!data.Columns.Contains(lang.REASON))
            {
                data.Columns.Add(lang.REASON);
            }
            for (int i = 0; i < wasteDataGridView.ColumnCount; i++)
            {
                wasteDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                wasteDataGridView.Columns[i].ReadOnly = true;
            }
            wasteDataGridView.Columns[5].ReadOnly = false;
            wasteDataGridView.CellValueChanged += wasteDataGridView_CellValueChanged;
        }

        private void Waste_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void wasteDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            wasteDataGridView.CellValueChanged -= wasteDataGridView_CellValueChanged;
            if (wasteDataGridView.Columns[e.ColumnIndex].Equals(wasteDataGridView.Columns[5]))
            {
                int temp = 0;
                if (!int.TryParse(wasteDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString(), out temp))
                {
                    MessageBox.Show(mustBeAnumber, error);
                    wasteDataGridView[e.ColumnIndex, e.RowIndex].Value = null;
                }
                else if (temp < 0)
                {
                    MessageBox.Show(mustBePostive, error);
                    wasteDataGridView[e.ColumnIndex, e.RowIndex].Value = null;
                }
                else
                {   
                    lastRow = e.RowIndex;
        
                    panel1.Visible = true;
                    listBox1.Focus();
                }
                wasteDataGridView.CellValueChanged += wasteDataGridView_CellValueChanged;
            }
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            wasteDataGridView.CellValueChanged -= wasteDataGridView_CellValueChanged;
            panel1.Visible = false;
            wasteDataGridView.Focus();
            wasteDataGridView[6, lastRow].Value = listBox1.SelectedItem.ToString();
            wasteDataGridView.CellValueChanged += wasteDataGridView_CellValueChanged;
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                chooseButton_Click(sender, e);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CancelBox cancel = new CancelBox(lang);
            DialogResult a = cancel.ShowDialog();

            if (a.Equals(DialogResult.OK))
            {
                data.Clear();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            UserIDBox user_dialog = new UserIDBox(core,lang);
            DialogResult a = user_dialog.ShowDialog(); //Dialogresult is either OK or Cancel. OK only if correct userID was entered
            if (a.Equals(DialogResult.OK))
            {
                string user = user_dialog.User;
                for (int i = 0; i < wasteDataGridView.RowCount; i++)
                {
                    if (!(wasteDataGridView[0, i].Value == null))
                    {
                        core.DataHandler.ActionOnItem('-', wasteDataGridView[0, i].Value.ToString(), 
                                                      wasteDataGridView[1, i].Value.ToString(), 
                                                      wasteDataGridView[5, i].Value.ToString(),
                                                      core.DataHandler.GetUserName(user), 
                                                      wasteDataGridView[6, i].Value.ToString());
                    }
                }
                data.Clear();
                MessageBox.Show(lang.SUCCESS_WASTE, lang.SUCCESS);
                core.WindowHandler.Update(this);
            }
        }

        private void addLineButton_Click(object sender, EventArgs e)
        {
            int temp = 0;
            if (int.TryParse(searchTextBox.Text, out temp))
            {
                string itemNo = searchTextBox.Text;
                core.DataHandler.GetDataFromItemNo(itemNo, INFO).Fill(data);
                MakeDataGridView();
            }
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            searchTextBox.Text = "";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                addLineButton_Click(sender, e);
            }
        }

        public void UpdateLang(ILang lang)
        {
            this.lang = lang;
            Text = lang.WASTE;
            chooseButton.Text = lang.CHOOSE;
            addLineButton.Text = lang.SEARCH;
            searchTextBox.Text = lang.ITEM_NO;
            button10.Text = lang.CANCEL;
            button11.Text = lang.CONFIRM;
            button3.Text = lang.REMOVE_ROW;
            error = lang.ERROR;
            mustBePostive = lang.MUST_BE_A_POSITIVE;
            mustBeAnumber = lang.MUST_BE_A_NUMER;
            if (wasteDataGridView.ColumnCount > 0)
            {
                wasteDataGridView.Columns[0].HeaderText = lang.ITEM_NO;
                wasteDataGridView.Columns[1].HeaderText = lang.DESCRIPTION;
                wasteDataGridView.Columns[2].HeaderText = lang.IN_STOCK;
                wasteDataGridView.Columns[3].HeaderText = lang.LOCATION;
                wasteDataGridView.Columns[5].HeaderText = lang.AMOUNT;
                wasteDataGridView.Columns[6].HeaderText = lang.REASON;
            }
            MakeList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (wasteDataGridView.CurrentCell != null)
            {
                wasteDataGridView.Rows.RemoveAt(wasteDataGridView.CurrentCell.RowIndex);
            }
        }

        private void listBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                chooseButton_Click(sender, e);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            searchTextBox.Text = lang.ITEM_NO;
        }
    }
}