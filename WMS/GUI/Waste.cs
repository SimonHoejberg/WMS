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
    public partial class Waste : Form, IGui
    {
        private List<string> reasons;

        private ICore core;
        private BindingSource bsource;
        private DataTable data;
        private string reason;
        private int lastRow;
        string itemNo;

        public Waste(ICore core)
        {
            this.core = core;
            InitializeComponent();
            updateComboBox();
            this.button1.Text = Lang.CHOOSE;
            this.button2.Text = Lang.SEACH;
            this.textBox1.Text = Lang.ITEM_NO;
            this.button10.Text = Lang.CANCEL;
            this.button11.Text = Lang.CONFIRM;
            bsource = new BindingSource();
            data = new DataTable();
            bsource.DataSource = data;
            dataGridView6.DataSource = bsource;
            reasons = new List<string>();
            MakeList();
        }

        private void MakeList()
        {
            reasons.Add(Lang.BROKEN);
            reasons.Add(Lang.WRONG_ITEM_DELIVRED);
            reasons.Add(Lang.MISSING);

            listBox1.DataSource = reasons;
        }
        public string GetTypeOfWindow()
        {
            return WindowTypes.WASTE;
        }

        public void UpdateGuiElements()
        {

        }

        public void MakeDataGridView()
        {
            dataGridView6.CellValueChanged -= dataGridView6_CellValueChanged;
            if (itemNo != null)
            {
                core.DataHandler.GetDataFromItemNo(itemNo, WindowTypes.INFO).Fill(data);
            }
            dataGridView6.Columns[0].HeaderText = Lang.ITEM_NO;
            dataGridView6.Columns[1].HeaderText = Lang.DESCRIPTION;
            dataGridView6.Columns[2].HeaderText = Lang.IN_STOCK;
            dataGridView6.Columns[3].HeaderText = Lang.LOCATION;
            dataGridView6.Columns[4].Visible = false;
            dataGridView6.Columns[5].Visible = false;
            if (!data.Columns.Contains(Lang.AMOUNT))
            {
                data.Columns.Add(Lang.AMOUNT);
            }
            if (!data.Columns.Contains(Lang.REASON))
            {
                data.Columns.Add(Lang.REASON);
            }
            for (int i = 0; i < dataGridView6.ColumnCount; i++)
            {
                dataGridView6.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView6.Columns[i].ReadOnly = true;
            }
            dataGridView6.Columns[6].ReadOnly = false;
            dataGridView6.Columns[7].ReadOnly = false;
            dataGridView6.CellValueChanged += dataGridView6_CellValueChanged;
        }
        private void updateComboBox()
        {
            comboBox3.DataSource = core.DataHandler.InfoToList();
            comboBox3.DisplayMember = "Identification";
            comboBox3.ValueMember = "itemNo";
        }

        private void Waste_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            itemNo = comboBox3.SelectedValue.ToString();
            updateComboBox();
            MakeDataGridView();
        }

        private void dataGridView6_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView6.CellValueChanged -= dataGridView6_CellValueChanged;
            if (dataGridView6.Columns[e.ColumnIndex].Equals(dataGridView6.Columns[6]))
            {
                int temp = 0;
                if (!int.TryParse(dataGridView6[e.ColumnIndex, e.RowIndex].Value.ToString(), out temp))
                {
                    MessageBox.Show(Lang.MUST_BE_A_NUMBER, Lang.ERROR);
                    dataGridView6[e.ColumnIndex, e.RowIndex].Value = null;
                }
                else if (temp < 0)
                {
                    MessageBox.Show(Lang.MUST_BE_POSITIVE, Lang.ERROR);
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
            dataGridView6[7, lastRow].Value = listBox1.SelectedItem.ToString();
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
            CancelBox cancel = new CancelBox();
            DialogResult a = cancel.ShowDialog();

            if (a.Equals(DialogResult.OK))
            {
                data.Clear();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            UserIDBox user_dialog = new UserIDBox(core);
            DialogResult a = user_dialog.ShowDialog(); //Dialogresult is either OK or Cancel. OK only if correct userID was entered
            if (a.Equals(DialogResult.OK))
            {
                string user = user_dialog.User;
                for (int i = 0; i < dataGridView6.RowCount; i++)
                {
                    if (!(dataGridView6[0, i].Value == null))
                    {
                        core.DataHandler.ActionOnItem('-', dataGridView6[0, i].Value.ToString(), 
                                                      dataGridView6[1, i].Value.ToString(), core.GetTimeStamp(), 
                                                      int.Parse(dataGridView6[6, i].Value.ToString()), user, 
                                                      dataGridView6[7, i].Value.ToString());
                    }
                }
                data.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string itemNo = textBox1.Text;
            comboBox3.DataSource = core.DataHandler.SearchInfoToList(itemNo);
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
    }
}