using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WMS.Interfaces;
using WMS.WH;

namespace WMS.GUI
{
    public partial class RegisterFeedBack : Form
    {
        //List for the two list for the listView
        private List<ListViewItem> notPlacedList = new List<ListViewItem>();
        private List<ListViewItem> placedList = new List<ListViewItem>();

        public RegisterFeedBack(ICore core, List<Item> notPlaced, Dictionary<Item,Location> placed)
        {
            InitializeComponent();
            //Language 
            closeButton.Text = core.Lang.CLOSE;
            notPlacedButton.Text = core.Lang.NOT_PLACED;
            placedButton.Text = core.Lang.PLACED;
            //Sets up the listView
            feedbackListView.View = View.Details;
            feedbackListView.Columns.Add(core.Lang.ITEM_NO, 20, HorizontalAlignment.Left);
            feedbackListView.Columns.Add(core.Lang.DESCRIPTION, 20, HorizontalAlignment.Left);
            feedbackListView.Columns.Add(core.Lang.LOCATION, 20, HorizontalAlignment.Left);
            feedbackListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            feedbackListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            //Disables the button for items not placeds if the list is empty
            //else it makes a list of items for the listView
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
            if(placed.Count == 0)
            {
                placedButton.Enabled = false;
                NotPlacedButtonClick(this, new EventArgs()); //Shows the not placed items in the listView because of none placed items
            }
            else
            {
                //Makes a listViewItem for every item with the item no, name and location 
                foreach (KeyValuePair<Item, Location> KvP in placed)
                {
                    ListViewItem lvi = new ListViewItem(KvP.Key.ItemNo);
                    lvi.SubItems.Add(KvP.Key.Description);
                    lvi.SubItems.Add(KvP.Value.Shelf + "." + KvP.Value.Space);
                    placedList.Add(lvi);
                }
                PlacedButtonClick(this, new EventArgs()); //Shows the placed items in the listView
            }
        }

        /// <summary>
        /// Sets the contents of the listView to the placed items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlacedButtonClick(object sender, EventArgs e)
        {
            feedbackListView.Items.Clear();
            foreach (var item in placedList)
            {
                feedbackListView.Items.Add(item);
            }
        }

        /// <summary>
        /// Sets the contents of the listView to the not placed items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotPlacedButtonClick(object sender, EventArgs e)
        {
            feedbackListView.Items.Clear();
            foreach (var item in notPlacedList)
            {
                feedbackListView.Items.Add(item);
            }
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButtonClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
