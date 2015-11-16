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

        public Information(ICore core)
        {
            InitializeComponent();
            this.core = core;
            UpdateInfo();
            this.Text = Lang.INFORMATION;
            this.closeButton.Text = Lang.CLOSE;
            this.viewItemButton.Text = Lang.VIEW_ITEM;
            this.logButton.Text = Lang.LOG;
            this.label4.Text = Lang.DESCRIPTION;
            this.label1.Text = Lang.SIZE;
            this.label2.Text = Lang.LOCATION;
            this.label3.Text = Lang.USAGE;

        }
        private void UpdateInfo()
        {
            BindingSource bsource = new BindingSource();
            DataTable data = new DataTable();

            bsource.DataSource = data;
            dataGridView.DataSource = bsource;

            core.DataHandler.GetData(GetTypeOfWindow()).Fill(data);

            dataGridView.Columns[0].HeaderText = Lang.ITEM_NO;
            dataGridView.Columns[1].HeaderText = Lang.DESCRIPTION;
            dataGridView.Columns[2].HeaderText = Lang.IN_STOCK;
            dataGridView.Columns[3].HeaderText = Lang.LOCATION;
            dataGridView.Columns[4].HeaderText = Lang.SIZE;
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
    }
}
