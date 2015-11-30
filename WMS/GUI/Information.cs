using System;
using System.Data;
using System.Windows.Forms;
using WMS.Interfaces;
using WMS.WH;
using static WMS.Reference.SearchTerms;
using static WMS.Reference.DataBases;

namespace WMS.GUI
{
    public partial class Information : Form, IGui
    {
        private ICore core;
        private string itemNo;
        private BindingSource bsource;
        private DataTable data;

        public Form Main { get; set; }

        public Information(ICore core)
        {
            InitializeComponent();
            this.core = core;
            UpdateLang();
            bsource = new BindingSource();
            data = new DataTable();
            bsource.DataSource = data;
            dataGridView.DataSource = bsource;
        }

        private void InformationLoad(object sender, System.EventArgs e)
        {
            MaximizeBox = false;
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            core.DataHandler.GetData(INFOMATION_DB).Fill(data);

            dataGridView.Columns[0].HeaderText = core.Lang.ITEM_NO;
            dataGridView.Columns[1].HeaderText = core.Lang.DESCRIPTION;
            dataGridView.Columns[2].HeaderText = core.Lang.IN_STOCK;
            dataGridView.Columns[3].HeaderText = core.Lang.LOCATION;
            dataGridView.Columns[4].Visible = false;
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

        private void ViewItemButtonClick(object sender, System.EventArgs e)
        {

            itemInfoPanel.Visible = true;
            int test = dataGridView.CurrentCell.RowIndex;
            itemNo = dataGridView[0, test].Value.ToString();
            Item item = core.DataHandler.GetItemFromItemNo(itemNo);
            usageLabel.Text = item.Usage.ToString();
            nameLabel.Text = item.Description;
            locationLabel.Text = item.Location;
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

        public void UpdateLang()
        {
            SearchTextBox.TextChanged -= SearchTextBoxTextChanged;
            SearchTextBox.Text = $"{core.Lang.ITEM_NO}/{core.Lang.DESCRIPTION}";
            Text = core.Lang.INFORMATION;
            closeButton.Text = core.Lang.CLOSE;
            viewItemButton.Text = core.Lang.VIEW_ITEM;
            logButton.Text = core.Lang.LOG;
            label4.Text = core.Lang.DESCRIPTION;
            label2.Text = core.Lang.LOCATION;
            label3.Text = core.Lang.USAGE;
            if (dataGridView.ColumnCount > 0)
            {
                dataGridView.Columns[0].HeaderText = core.Lang.ITEM_NO;
                dataGridView.Columns[1].HeaderText = core.Lang.DESCRIPTION;
                dataGridView.Columns[2].HeaderText = core.Lang.IN_STOCK;
                dataGridView.Columns[3].HeaderText = core.Lang.LOCATION;
            }
            SearchTextBox.TextChanged += SearchTextBoxTextChanged;
        }


        private void SearchTextBoxTextChanged(object sender, EventArgs e)
        {
            int a = 0;
            data?.Clear();
            if (int.TryParse(SearchTextBox.Text, out a))
            {
                core.DataHandler.Search(SearchTextBox.Text, INFOMATION_DB, ITEM).Fill(data);
            }
            else
            {
                core.DataHandler.Search(SearchTextBox.Text, INFOMATION_DB, DESCRIPTION).Fill(data);
            }
        }

        private void SearchTextBoxEnter(object sender, EventArgs e)
        {
            SearchTextBox.Text = "";
        }
    }
}
