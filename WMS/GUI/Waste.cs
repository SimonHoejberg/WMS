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
            button1.Text = lang.CHOOSE;
            button2.Text = lang.ADD;
            textBox1.Text = lang.ITEM_NO;
            button10.Text = lang.CANCEL;
            button11.Text = lang.CONFIRM;
            button3.Text = lang.REMOVE_ROW;
            error = lang.ERROR;
            mustBePostive = lang.MUST_BE_A_POSITIVE;
            mustBeAnumber = lang.MUST_BE_A_NUMER;
            bsource = new BindingSource();
            data = new DataTable();
            bsource.DataSource = data;
            dataGridView6.DataSource = bsource;
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
            textBox1.AutoCompleteCustomSource = source;
        }

        public void MakeDataGridView()
        {
            dataGridView6.CellValueChanged -= dataGridView6_CellValueChanged;
            dataGridView6.Columns[0].HeaderText = lang.ITEM_NO;
            dataGridView6.Columns[1].HeaderText = lang.DESCRIPTION;
            dataGridView6.Columns[2].HeaderText = lang.IN_STOCK;
            dataGridView6.Columns[3].HeaderText = lang.LOCATION;
            dataGridView6.Columns[4].Visible = false;
            if (!data.Columns.Contains(lang.AMOUNT))
            {
                data.Columns.Add(lang.AMOUNT);
            }
            if (!data.Columns.Contains(lang.REASON))
            {
                data.Columns.Add(lang.REASON);
            }
            for (int i = 0; i < dataGridView6.ColumnCount; i++)
            {
                dataGridView6.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView6.Columns[i].ReadOnly = true;
            }
            dataGridView6.Columns[5].ReadOnly = false;
            dataGridView6.CellValueChanged += dataGridView6_CellValueChanged;
        }

        private void Waste_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void dataGridView6_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView6.CellValueChanged -= dataGridView6_CellValueChanged;
            if (dataGridView6.Columns[e.ColumnIndex].Equals(dataGridView6.Columns[5]))
            {
                int temp = 0;
                if (!int.TryParse(dataGridView6[e.ColumnIndex, e.RowIndex].Value.ToString(), out temp))
                {
                    MessageBox.Show(mustBeAnumber, error);
                    dataGridView6[e.ColumnIndex, e.RowIndex].Value = null;
                }
                else if (temp < 0)
                {
                    MessageBox.Show(mustBePostive, error);
                    dataGridView6[e.ColumnIndex, e.RowIndex].Value = null;
                }
                else
                {   
                    lastRow = e.RowIndex;
        
                    panel1.Visible = true;
                    listBox1.Focus();
                }
                dataGridView6.CellValueChanged += dataGridView6_CellValueChanged;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView6.CellValueChanged -= dataGridView6_CellValueChanged;
            panel1.Visible = false;
            dataGridView6.Focus();
            dataGridView6[6, lastRow].Value = listBox1.SelectedItem.ToString();
            dataGridView6.CellValueChanged += dataGridView6_CellValueChanged;
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                button1_Click(sender, e);
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
                for (int i = 0; i < dataGridView6.RowCount; i++)
                {
                    if (!(dataGridView6[0, i].Value == null))
                    {
                        core.DataHandler.ActionOnItem('-', dataGridView6[0, i].Value.ToString(), 
                                                      dataGridView6[1, i].Value.ToString(), 
                                                      dataGridView6[5, i].Value.ToString(),
                                                      core.DataHandler.GetUserName(user), 
                                                      dataGridView6[6, i].Value.ToString());
                    }
                }
                data.Clear();
                MessageBox.Show(lang.SUCCESS_WASTE, lang.SUCCESS);
                core.WindowHandler.Update(this);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int temp = 0;
            if (int.TryParse(textBox1.Text, out temp))
            {
                string itemNo = textBox1.Text;
                core.DataHandler.GetDataFromItemNo(itemNo, INFOMATION_DB).Fill(data);
                MakeDataGridView();
            }
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                button2_Click(sender, e);
            }
        }

        public void UpdateLang(ILang lang)
        {
            this.lang = lang;
            Text = lang.WASTE;
            button1.Text = lang.CHOOSE;
            button2.Text = lang.SEACH;
            textBox1.Text = lang.ITEM_NO;
            button10.Text = lang.CANCEL;
            button11.Text = lang.CONFIRM;
            button3.Text = lang.REMOVE_ROW;
            error = lang.ERROR;
            mustBePostive = lang.MUST_BE_A_POSITIVE;
            mustBeAnumber = lang.MUST_BE_A_NUMER;
            if (dataGridView6.ColumnCount > 0)
            {
                dataGridView6.Columns[0].HeaderText = lang.ITEM_NO;
                dataGridView6.Columns[1].HeaderText = lang.DESCRIPTION;
                dataGridView6.Columns[2].HeaderText = lang.IN_STOCK;
                dataGridView6.Columns[3].HeaderText = lang.LOCATION;
                dataGridView6.Columns[5].HeaderText = lang.AMOUNT;
                dataGridView6.Columns[6].HeaderText = lang.REASON;
            }
            MakeList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView6.CurrentCell != null)
            {
                dataGridView6.Rows.RemoveAt(dataGridView6.CurrentCell.RowIndex);
            }
        }

        private void listBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                button1_Click(sender, e);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = lang.ITEM_NO;
        }
    }
}