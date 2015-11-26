using System;
using System.Data;
using System.Windows.Forms;
using WMS.Interfaces;
using WMS.Reference;
using WMS.WH;
using static WMS.Reference.DataBaseValues;
using static WMS.Reference.DataBaseTypes;

namespace WMS.GUI
{
    public partial class Information : Form, IGui
    {
        private ICore core;
        private string itemNo;
        private ILang lang;
        BindingSource bsource;
        DataTable data;

        public Form Main { get; set; }

        public Information(ICore core, ILang lang)
        {
            InitializeComponent();
            this.lang = lang;
            this.core = core;
            UpdateLang(lang);
            bsource = new BindingSource();
            data = new DataTable();
            bsource.DataSource = data;
            dataGridView.DataSource = bsource;
        }

        private void UpdateInfo()
        {
            core.DataHandler.GetData(INFO).Fill(data);

            dataGridView.Columns[0].HeaderText = lang.ITEM_NO;
            dataGridView.Columns[1].HeaderText = lang.DESCRIPTION;
            dataGridView.Columns[2].HeaderText = lang.IN_STOCK;
            dataGridView.Columns[3].HeaderText = lang.LOCATION;
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

        private void DataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InformationEnter(object sender, System.EventArgs e)
        {

        }

        private void InformationLoad(object sender, System.EventArgs e)
        {
            MaximizeBox = false;
            UpdateInfo();
        }

        public void UpdateLang(ILang lang)
        {
            textBox1.TextChanged -= textBox1_TextChanged;
            this.lang = lang;
            textBox1.Text = $"{lang.ITEM_NO}/{lang.DESCRIPTION}";
            Text = lang.INFORMATION;
            closeButton.Text = lang.CLOSE;
            viewItemButton.Text = lang.VIEW_ITEM;
            logButton.Text = lang.LOG;
            label4.Text = lang.DESCRIPTION;
            label2.Text = lang.LOCATION;
            label3.Text = lang.USAGE;
            if (dataGridView.ColumnCount > 0)
            {
                dataGridView.Columns[0].HeaderText = lang.ITEM_NO;
                dataGridView.Columns[1].HeaderText = lang.DESCRIPTION;
                dataGridView.Columns[2].HeaderText = lang.IN_STOCK;
                dataGridView.Columns[3].HeaderText = lang.LOCATION;
            }
            textBox1.TextChanged += textBox1_TextChanged;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int a = 0;
            data?.Clear();
            if (int.TryParse(textBox1.Text, out a))
            {
                core.DataHandler.Search(textBox1.Text, INFO, ITEM).Fill(data);
            }
            else
            {
                core.DataHandler.Search(textBox1.Text, INFO, DESCRIPTION).Fill(data);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
