using System;
using System.Data;
using System.Windows.Forms;
using WMS.Interfaces;
using WMS.Reference;
using WMS.WH;

namespace WMS.GUI
{
    public partial class Information : Form, IGui
    {
        private ICore core;
        private string itemNo;
        private ILang lang;

        public Information(ICore core, ILang lang)
        {
            InitializeComponent();
            this.lang = lang;
            this.core = core;
            UpdateInfo();
            UpdateLang(lang);

        }
        private void UpdateInfo()
        {
            BindingSource bsource = new BindingSource();
            DataTable data = new DataTable();

            bsource.DataSource = data;
            dataGridView.DataSource = bsource;

            core.DataHandler.GetData(GetTypeOfWindow()).Fill(data);

            dataGridView.Columns[0].HeaderText = lang.ITEM_NO;
            dataGridView.Columns[1].HeaderText = lang.DESCRIPTION;
            dataGridView.Columns[2].HeaderText = lang.IN_STOCK;
            dataGridView.Columns[3].HeaderText = lang.LOCATION;
            dataGridView.Columns[4].HeaderText = lang.SIZE;
            dataGridView.Columns[5].Visible = false;
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView.Columns[i].ReadOnly = true;
            }
        }

        public void UpdateGuiElements()
        {
            UpdateInfo();
        }

        public string GetTypeOfWindow()
        {
            return WindowTypes.INFO;
        }

        private void ViewItemButtonClick(object sender, System.EventArgs e)
        {

            itemInfoPanel.Visible = true;
            int test = dataGridView.CurrentCell.RowIndex;
            itemNo = dataGridView[0, test].Value.ToString();
            Item item = core.DataHandler.GetItemFromItemNo(itemNo);
            sizeLabel.Text = item.Size.ToString();
            usageLabel.Text = item.Usage.ToString();
            nameLabel.Text = item.Description;
            logListBox.DataSource = core.DataHandler.GetLog(itemNo);
        }

        private void CloseButtonClick(object sender, System.EventArgs e)
        {
            itemInfoPanel.Visible = false;
        }

        private void LogButtonClick(object sender, System.EventArgs e)
        {
            core.WindowHandler.OpenLog(itemNo);
        }

        private void DataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InformationEnter(object sender, System.EventArgs e)
        {

        }

        private void InformationLoad(object sender, System.EventArgs e)
        {
            MaximizeBox = false;
        }

        public void UpdateLang(ILang lang)
        {
            this.lang = lang;
            Text = lang.INFORMATION;
            closeButton.Text = lang.CLOSE;
            viewItemButton.Text = lang.VIEW_ITEM;
            logButton.Text = lang.LOG;
            label4.Text = lang.DESCRIPTION;
            label1.Text = lang.SIZE;
            label2.Text = lang.LOCATION;
            label3.Text = lang.USAGE;
            dataGridView.Columns[0].HeaderText = lang.ITEM_NO;
            dataGridView.Columns[1].HeaderText = lang.DESCRIPTION;
            dataGridView.Columns[2].HeaderText = lang.IN_STOCK;
            dataGridView.Columns[3].HeaderText = lang.LOCATION;
            dataGridView.Columns[4].HeaderText = lang.SIZE;
        }
    }
}
