using System.Data;
using System.Windows.Forms;
using WMS.Interfaces;
using WMS.Reference;

namespace WMS.GUI
{
    public partial class Information : Form , IGui
    {
        private bool run = false;
        private ICore core;
        private string itemNo;
        
        public Information(ICore core)
        {
            InitializeComponent();
            this.core = core;
            updateInfo();
        }
        private void updateInfo()
        {

            BindingSource bsource = new BindingSource();
            DataTable data = new DataTable();

            bsource.DataSource = data;
            dataGridView1.DataSource = bsource;

            core.DataHandler.getData(GetTypeOfWindow()).Fill(data);

            dataGridView1.Columns[0].HeaderText = "Item No";
            dataGridView1.Columns[1].HeaderText = "Description";
            dataGridView1.Columns[2].HeaderText = "In stock";
            dataGridView1.Columns[3].HeaderText = "Location";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            for (int i = 0; i < dataGridView1.ColumnCount; i++) { 
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            run = true;
        }
        private void dataGridView1_cellChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (run)
            {
                string coloumn = dataGridView1.Columns[e.ColumnIndex].Name.ToString();
                string value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                core.DataHandler.UpdateProduct(coloumn, value, id,GetTypeOfWindow());
                core.DataHandler.Update(this);
            }

        }

        public void UpdateGuiElements(){
            updateInfo();
        }

        public string GetTypeOfWindow()
        {
            return WindowTypes.INFO;
        }

        private void viewItemBtn_Click(object sender, System.EventArgs e)
        {
            
            itemInfoPnl.Visible = true;
            int test = dataGridView1.CurrentCell.RowIndex;
            itemNo = dataGridView1[0, test].Value.ToString();
            sizeLbl.Text = dataGridView1[4, test].Value.ToString();
            locationLbl.Text = dataGridView1[3, test].Value.ToString();
            usageLbl.Text = dataGridView1[5, test].Value.ToString();
            nameLbl.Text = dataGridView1[1, test].Value.ToString();
        }

        private void closeBtn_Click(object sender, System.EventArgs e)
        {
            itemInfoPnl.Visible = false;
            sizeLbl.Text = "";
            locationLbl.Text = "";
            usageLbl.Text = "";
        }

        private void logBtn_Click(object sender, System.EventArgs e)
        {
            core.WindowHandler.OpenLog(itemNo);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Information_Enter(object sender, System.EventArgs e)
        {

        }

        private void Information_Load(object sender, System.EventArgs e)
        {
            MaximizeBox = false;
        }
    }
}
