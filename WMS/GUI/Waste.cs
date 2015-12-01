using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WMS.Interfaces;
using WMS.WH;
using static WMS.Reference.DataBases;

namespace WMS.GUI
{
    public partial class Waste : Form, IGui
    {
        private List<string> reasons;
        private List<Location> locationList;
        private ICore core;
        private BindingSource bsource;
        private DataTable data;
        private int lastRow;
        private string error;
        private string mustBePostive;
        private string mustBeAnumber;
        private Dictionary<string, string> locationIds = new Dictionary<string, string>();

        public Waste(ICore core)
        {
            this.core = core;
            InitializeComponent();
            locationList = core.DataHandler.LocationToList();
            SearchBox();
            Text = core.Lang.WASTE;
            chooseButton.Text = core.Lang.CHOOSE;
            addLineButton.Text = core.Lang.ADD;
            searchTextBox.Text = core.Lang.ITEM_NO;
            button10.Text = core.Lang.CANCEL;
            button11.Text = core.Lang.CONFIRM;
            button3.Text = core.Lang.REMOVE_ROW;
            chooseLocationButton.Text = core.Lang.CHOOSE;
            error = core.Lang.ERROR;
            mustBePostive = core.Lang.MUST_BE_A_POSITIVE;
            mustBeAnumber = core.Lang.MUST_BE_A_NUMER;
            bsource = new BindingSource();
            data = new DataTable();
            bsource.DataSource = data;
            wasteDataGridView.DataSource = bsource;
            MakeList();
        }

        private void MakeList()
        {
            reasons = new List<string>();
            reasons.Add(core.Lang.BROKEN);
            reasons.Add(core.Lang.WRONG_ITEM_DELIVRED);
            reasons.Add(core.Lang.MISSING);

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
            wasteDataGridView.Columns[0].HeaderText = core.Lang.ITEM_NO;
            wasteDataGridView.Columns[1].HeaderText = core.Lang.DESCRIPTION;
            wasteDataGridView.Columns[2].HeaderText = core.Lang.IN_STOCK;
            wasteDataGridView.Columns[3].Visible = false;
            wasteDataGridView.Columns[4].Visible = false;
            if (!data.Columns.Contains(core.Lang.LOCATION))
            {
                data.Columns.Add(core.Lang.LOCATION);
            }
            if (!data.Columns.Contains(core.Lang.AMOUNT))
            {
                data.Columns.Add(core.Lang.AMOUNT);
            }
            if (!data.Columns.Contains(core.Lang.REASON))
            {
                data.Columns.Add(core.Lang.REASON);
            }
            
            for (int i = 0; i < wasteDataGridView.ColumnCount; i++)
            {
                wasteDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                wasteDataGridView.Columns[i].ReadOnly = true;
            }
            wasteDataGridView.Columns[6].ReadOnly = false;
            wasteDataGridView.CellValueChanged += wasteDataGridView_CellValueChanged;
        }

        private void Waste_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void wasteDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            wasteDataGridView.CellValueChanged -= wasteDataGridView_CellValueChanged;
            if (wasteDataGridView.Columns[e.ColumnIndex].Equals(wasteDataGridView.Columns[6]))
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
            }
                wasteDataGridView.CellValueChanged += wasteDataGridView_CellValueChanged;
            }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            wasteDataGridView.CellValueChanged -= wasteDataGridView_CellValueChanged;
            panel1.Visible = false;
            wasteDataGridView.Focus();
            wasteDataGridView[7, lastRow].Value = listBox1.SelectedItem.ToString();
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
            CancelBox cancel = new CancelBox(core.Lang);
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
                for (int i = 0; i < wasteDataGridView.RowCount; i++)
                {
                    if (!(wasteDataGridView[0, i].Value == null))
                    {
                        string locId = locationList.Find(x => x.LocationString.Equals(wasteDataGridView[5, i].Value.ToString())).Id;
                        core.DataHandler.ActionOnItem('-', wasteDataGridView[0, i].Value.ToString(), 
                                                      wasteDataGridView[1, i].Value.ToString(), 
                                                      wasteDataGridView[6, i].Value.ToString(),
                                                      core.DataHandler.GetUserName(user), 
                                                      wasteDataGridView[7, i].Value.ToString(),locId);
                    }
                }
                data.Clear();
                MessageBox.Show(core.Lang.SUCCESS_WASTE, core.Lang.SUCCESS);
                core.WindowHandler.Update(this);
            }
        }

        private void addLineButton_Click(object sender, EventArgs e)
        {
            int temp = 0;
            if (int.TryParse(searchTextBox.Text, out temp))
            {
                string itemNo = searchTextBox.Text;
                core.DataHandler.GetDataFromItemNo(itemNo, INFOMATION_DB).Fill(data);
                MakeDataGridView();
                if (locationList.FindAll(x => x.ItemNo.Equals(itemNo)).Count > 1)
                {
                    listBox2.DataSource = locationList.FindAll(x => x.ItemNo.Equals(itemNo));
                    locationPanel.Visible = true;
                    listBox2.Focus();
                }
                else
                {
                    wasteDataGridView[5,wasteDataGridView.RowCount - 1].Value = locationList.Find(x => x.ItemNo.Equals(itemNo));
                }
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

        public void UpdateLang()
        {
            Text = core.Lang.WASTE;
            chooseButton.Text = core.Lang.CHOOSE;
            addLineButton.Text = core.Lang.SEARCH;
            searchTextBox.Text = core.Lang.ITEM_NO;
            button10.Text = core.Lang.CANCEL;
            button11.Text = core.Lang.CONFIRM;
            button3.Text = core.Lang.REMOVE_ROW;
            chooseLocationButton.Text = core.Lang.CHOOSE;
            error = core.Lang.ERROR;
            mustBePostive = core.Lang.MUST_BE_A_POSITIVE;
            mustBeAnumber = core.Lang.MUST_BE_A_NUMER;
            if (wasteDataGridView.ColumnCount > 0)
            {
                wasteDataGridView.Columns[0].HeaderText = core.Lang.ITEM_NO;
                wasteDataGridView.Columns[1].HeaderText = core.Lang.DESCRIPTION;
                wasteDataGridView.Columns[2].HeaderText = core.Lang.IN_STOCK;
                wasteDataGridView.Columns[5].HeaderText = core.Lang.LOCATION;
                wasteDataGridView.Columns[6].HeaderText = core.Lang.AMOUNT;
                wasteDataGridView.Columns[7].HeaderText = core.Lang.REASON;
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
            searchTextBox.Text = core.Lang.ITEM_NO;
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            chooseButton_Click(sender, e);
        }

        private void chooseLocationButton_Click(object sender, EventArgs e)
        {
            wasteDataGridView.CellValueChanged -= wasteDataGridView_CellValueChanged;
            locationPanel.Visible = false;
            wasteDataGridView.Focus();
            wasteDataGridView[5, wasteDataGridView.RowCount - 1].Value = listBox2.SelectedItem;
            Location location = ((Location)listBox2.SelectedItem);
            locationIds.Add(location.ToString(), location.Id);
            wasteDataGridView.CellValueChanged += wasteDataGridView_CellValueChanged;
        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                chooseLocationButton_Click(sender, e);
            }
        }
    }
}