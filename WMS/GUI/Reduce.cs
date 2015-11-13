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
            comboBox2.DisplayMember = "Description";

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
                }
            }
            core.WindowHandler.Update(this);
            data.Clear();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (comboBox2.Text != null && (int.TryParse(comboBox2.Text, out a)))
            {
                itemNo = comboBox2.Text;
                DataGridViewMake();
            }
            else if (comboBox2.SelectedValue != null && int.TryParse(comboBox2.SelectedValue.ToString(), out a))
            {
                itemNo = comboBox2.SelectedValue.ToString();
                DataGridViewMake();
            }
        }

        private void DataGridViewMake()
        {
            reduceDataGridView.CellValueChanged -= reduceDataGridView_CellValueChanged;
            core.DataHandler.GetDataFromItemNo(itemNo, WindowTypes.INFO).Fill(data);
            reduceDataGridView.Columns[0].HeaderText = "Item No";
            reduceDataGridView.Columns[1].HeaderText = "Description";
            reduceDataGridView.Columns[2].HeaderText = "In stock";
            reduceDataGridView.Columns[3].HeaderText = "Location";
            //reduceDataGridView.Columns[2].Visible = false;
            reduceDataGridView.Columns[4].Visible = false;
            reduceDataGridView.Columns[5].Visible = false;
            if (!data.Columns.Contains("Quantity"))
            {
                data.Columns.Add("Quantity");
            }
            for (int i = 0; i < reduceDataGridView.ColumnCount; i++)
            {
                reduceDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            reduceDataGridView.CellValueChanged -= reduceDataGridView_CellValueChanged;
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            int a = 0;
            
            if (e.KeyCode == Keys.Enter && int.TryParse(comboBox2.Text, out a))
            {
                itemNo = comboBox2.Text;
                DataGridViewMake();
            }
            else if (e.KeyCode == Keys.Enter && comboBox2.SelectedValue != null && int.TryParse(comboBox2.SelectedValue.ToString(),out a))
            {
                itemNo = comboBox2.SelectedValue.ToString();
                DataGridViewMake();
            }

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
                    MessageBox.Show("Must be a number", "Error");
                    reduceDataGridView[e.ColumnIndex, e.RowIndex].Value = null;
                }
                else if (tempInt < 0)
                {
                    MessageBox.Show("Must be a positive number", "Error");
                    reduceDataGridView[e.ColumnIndex, e.RowIndex].Value = null;
                }
            }
            reduceDataGridView.CellValueChanged += reduceDataGridView_CellValueChanged;
        }
    }
}
