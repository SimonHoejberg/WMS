using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WMS.Interfaces;
using WMS.WH;

namespace WMS.GUI
{
    public partial class RigisterFeedBack : Form
    {

        private List<ListViewItem> notPlacedList = new List<ListViewItem>();
        private List<ListViewItem> placedList = new List<ListViewItem>();

        public RigisterFeedBack(ICore core, List<Item> notPlaced, Dictionary<Item,Location> placed)
        {
            InitializeComponent();
            closeButton.Text = core.Lang.CLOSE;
            notPlacedButton.Text = core.Lang.NOT_PLACED;
            placedButton.Text = core.Lang.PLACED;
            feedbackListView.View = View.Details;
            feedbackListView.Columns.Add("Item No", 20, HorizontalAlignment.Left);
            feedbackListView.Columns.Add("Description", 20, HorizontalAlignment.Left);
            feedbackListView.Columns.Add("Location", 20, HorizontalAlignment.Left);
            feedbackListView.Columns[0].Width = -2;
            feedbackListView.Columns[1].Width = -2;
            feedbackListView.Columns[2].Width = -2;
            if (notPlaced.Count == 0)
            {
                notPlacedButton.Enabled = false;
            }
            else
            {
                foreach (var item in notPlaced)
                {
                    ListViewItem lvi = new ListViewItem(item.ItemNo);
                    notPlacedList.Add(lvi);
                }
            }
            foreach (KeyValuePair<Item,Location> KvP in placed)
            {
                ListViewItem lvi = new ListViewItem(KvP.Key.ItemNo);
                lvi.SubItems.Add(KvP.Key.Description);
                lvi.SubItems.Add(KvP.Value.Shelf + "." + KvP.Value.Space);
                placedList.Add(lvi);
            }
            foreach (var item in placedList)
            {
                feedbackListView.Items.Add(item);
            }
            
        }

        private void PlacedButtonClick(object sender, EventArgs e)
        {
            feedbackListView.Items.Clear();
            foreach (var item in placedList)
            {
                feedbackListView.Items.Add(item);
            }
        }

        private void NotPlacedButtonClick(object sender, EventArgs e)
        {
            feedbackListView.Items.Clear();
            foreach (var item in notPlacedList)
            {
                feedbackListView.Items.Add(item);
            }
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
