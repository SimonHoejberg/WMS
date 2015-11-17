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
using WMS.WH;

namespace WMS.GUI
{
    public partial class Reduce : Form , IGui
    {
        private ICore core;
        private BindingSource bsource;
        private DataTable data;
        private string itemNo;
       
        public Reduce(ICore core)
        {
            this.core = core;
            InitializeComponent();
            MakeComboBox();
            this.searchBtn.Text = Lang.SEACH;
            this.Text = Lang.REDUCE;
            this.reduceConfirmBtn.Text = Lang.CONFIRM;
            this.reduceCancelBtn.Text = Lang.CANCEL;
            bsource = new BindingSource();
            data = new DataTable();
            bsource.DataSource = data;
            reduceDataGridView.DataSource = bsource;
        }

        public string GetTypeOfWindow()
        {
            return WindowTypes.REDUCE;
        }

        public void UpdateGuiElements()
        {

        }

        private void MakeComboBox()
        {
            comboBox2.DataSource = core.DataHandler.InfoToList();
            comboBox2.ValueMember = "ItemNo";
            comboBox2.DisplayMember = "Identification";

        }

        private void reduceConfirmBtn_Click(object sender, EventArgs e)
        {
            UserIDBox user_dialog = new UserIDBox(core);
            DialogResult a = user_dialog.ShowDialog();
            if (a.Equals(DialogResult.OK))
            {
                string user = user_dialog.User;
                for (int i = 0; i < reduceDataGridView.RowCount; i++)
                {
                    if (!(reduceDataGridView[0, i].Value == null))
                    {
                        core.DataHandler.ActionOnItem('-',reduceDataGridView[0, i].Value.ToString(), reduceDataGridView[1, i].Value.ToString(), core.GetTimeStamp(),int.Parse(reduceDataGridView[6,i].Value.ToString()), user,LogOperations.REDUCED);
                    }
                    core.WindowHandler.Update(this);
                    data.Clear();
                }

            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (comboBox2.Text != null && (int.TryParse(comboBox2.Text, out a)))
            {
                itemNo = comboBox2.Text;
                MakeDataGridView();
            }
            else if (comboBox2.SelectedValue != null && int.TryParse(comboBox2.SelectedValue.ToString(), out a))
            {
                itemNo = comboBox2.SelectedValue.ToString();
                MakeDataGridView();
            }
        }

        private void MakeDataGridView()
        {
            reduceDataGridView.CellValueChanged -= reduceDataGridView_CellValueChanged;
            core.DataHandler.GetDataFromItemNo(itemNo, WindowTypes.INFO).Fill(data);
            reduceDataGridView.Columns[0].HeaderText = Lang.ITEM_NO;
            reduceDataGridView.Columns[1].HeaderText = Lang.DESCRIPTION;
            reduceDataGridView.Columns[2].HeaderText = Lang.IN_STOCK;
            reduceDataGridView.Columns[3].HeaderText = Lang.LOCATION;
            reduceDataGridView.Columns[4].Visible = false;
            reduceDataGridView.Columns[5].Visible = false;
            if (!data.Columns.Contains(Lang.AMOUNT))
            {
                data.Columns.Add(Lang.AMOUNT);
            }
            for (int i = 0; i < reduceDataGridView.ColumnCount; i++)
            {
                reduceDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            reduceDataGridView.CellValueChanged -= reduceDataGridView_CellValueChanged;
        }

        private void Reduce_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void reduceDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            reduceDataGridView.CellValueChanged -= reduceDataGridView_CellValueChanged;
            string temp = reduceDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
            int tempInt = 0;
            if (temp != null)
            {
                if (!int.TryParse(temp, out tempInt))
                {
                    MessageBox.Show(Lang.MUST_BE_A_NUMBER, Lang.ERROR);
                    reduceDataGridView[e.ColumnIndex, e.RowIndex].Value = null;
                }
                else if (tempInt < 0)
                {
                    MessageBox.Show(Lang.MUST_BE_POSITIVE, Lang.ERROR);
                    reduceDataGridView[e.ColumnIndex, e.RowIndex].Value = null;
                }
            }
            reduceDataGridView.CellValueChanged += reduceDataGridView_CellValueChanged;
        }

        private void reduceCancelBtn_Click(object sender, EventArgs e)
        {
            CancelBox cancel = new CancelBox();
            cancel.Owner = this;
            DialogResult a = cancel.ShowDialog();

            if (a.Equals(DialogResult.OK))
            {
                data.Clear();
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            itemNo = comboBox2.SelectedValue.ToString();
            MakeComboBox();
            MakeDataGridView();
        }
    }
}
