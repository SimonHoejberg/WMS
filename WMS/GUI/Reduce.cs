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
        private bool First = true;
        BindingSource bsource;
        DataTable data;
       
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
                        core.DataHandler.ReduceItem(reduceDataGridView[0, i].Value.ToString(), reduceDataGridView[1, i].Value.ToString(), int.Parse(reduceDataGridView[6,i].Value.ToString()), user);
                    }
                }
            }

            data.Clear();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (comboBox2.Text != null && (int.TryParse(comboBox2.Text, out a)))
            {
                core.DataHandler.GetDataFromItemNo(comboBox2.Text, WindowTypes.INFO).Fill(data);
            }
            else
            {
                core.DataHandler.GetDataFromItemNo(comboBox2.SelectedValue.ToString(), WindowTypes.INFO).Fill(data);
            }
            
            if (First)
            {
                DataGridViewMake();
            }
        }

        private void DataGridViewMake()
        {
            //reduceDataGridView.Columns[2].Visible = false;
            reduceDataGridView.Columns[4].Visible = false;
            reduceDataGridView.Columns[5].Visible = false;
            data.Columns.Add("Quantity");
            First = false;

            for (int i = 0; i < reduceDataGridView.ColumnCount; i++)
            {
                reduceDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            int a = 0;
            
            if (e.KeyCode == Keys.Enter && int.TryParse(comboBox2.Text, out a))
            {
                core.DataHandler.GetDataFromItemNo(a.ToString(), WindowTypes.INFO).Fill(data);
            }

            else if (e.KeyCode != Keys.Down && e.KeyCode != Keys.Up && e.KeyCode == Keys.Enter)
            {
                string itemNo = comboBox2.SelectedValue.ToString();
                core.DataHandler.GetDataFromItemNo(itemNo, WindowTypes.INFO).Fill(data);
            }

            if (First && e.KeyCode == Keys.Enter)
            {
                DataGridViewMake();
            }
        }

        private void Reduce_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
    }
}
