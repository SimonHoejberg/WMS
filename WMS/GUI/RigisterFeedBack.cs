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
            feedbackListView.Columns.Add(core.Lang.ITEM_NO, 20, HorizontalAlignment.Left);
            feedbackListView.Columns.Add(core.Lang.DESCRIPTION, 20, HorizontalAlignment.Left);
            feedbackListView.Columns.Add(core.Lang.LOCATION, 20, HorizontalAlignment.Left);
            feedbackListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            feedbackListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            feedbackListView.Columns[2].Width = -2;
            /*if (notPlaced.Count == 0)
            {
                notPlacedButton.Enabled = false;
            }
            else
            {*/
                foreach (var item in notPlaced)
                {
                    ListViewItem lvi = new ListViewItem(item.ItemNo);
                    notPlacedList.Add(lvi);
                }
            //}
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
