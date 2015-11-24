using WMS.Interfaces;
using System.Collections.Generic;

namespace WMS.WH
{
    public class Warehouse
    {
        private ICore core;
        private Item[,] locations;
        private Dictionary<string, string> placedItems = new Dictionary<string, string>();
        private List<Item> notplaced = new List<Item>();
        private Dictionary<int, string> maxMin = new Dictionary<int, string>();

        private List<Item> itemsNotPlaced = new List<Item>();

        public Warehouse(ICore core)
        {
            this.core = core;
            locations = new Item[6, 3];
        }

        public bool PlaceItem(Item item, string location)
        {
            core.DataHandler.ChangeLocation(item.ItemNo, location);
            return true;
        }

        private int MaxSpace()
        {
            return 3;
        }

        private int MaxShelf()
        {
            return 6;
        }

        public void CreateWH()
        {
            List<Item> temp = core.DataHandler.InfoToList();
            foreach (Item item in temp)
            {
                string[] tempS = item.Location.Split('.');
                if (tempS.Length == 2)
                {
                    locations[int.Parse(tempS[0]), int.Parse(tempS[1])] = item;
                }
            }
        }


        private bool FindAvaliableSpace(Item item, int shelf, int space)
        {

            if ((GetUsage(locations[shelf, 0]) == 0 && GetUsage(locations[shelf,(MaxSpace()-1)]) == 0) || (GetUsage(locations[shelf, 0]) > item.Usage && item.Usage > GetUsage(locations[shelf, (MaxSpace() - 1)])))
            {

                if (locations[shelf, space] == null || locations[shelf, space].ItemNo.Equals(item.ItemNo))
                {
                    locations[shelf, space] = item;
                    PlaceItem(item, shelf.ToString() + "." + space.ToString());
                    return true;
                }
                else
                {
                    if (space < (MaxSpace() - 1))
                    {
                        space++;
                    }
                    else if (shelf < (MaxShelf() - 1))
                    {
                        space = 0;
                        shelf++;
                    }
                    else
                    {
                        return false;
                    }
                    return FindAvaliableSpace(item, shelf, space);
                }
            }
            else
            {
                if (space < (MaxSpace() - 1))
                {
                    space++;
                }
                else if (shelf < (MaxShelf() - 1))
                {
                    space = 0;
                    shelf++;
                }
                else
                {
                    return false;
                }
                return FindAvaliableSpace(item, shelf, space);
            }
        }

        private int GetUsage(Item itemNo)
        {
            if (itemNo != null)
            {
                return itemNo.Usage;
            }
            else
            {
                return 0;
            }
        }

        public List<Item> FindOptimalLocation(List<Item> items)
        {
            items.Sort();
            foreach (Item item in items)
            {
                if (!FindAvaliableSpace(item, 0,0))
                {
                    notplaced.Add(item);
                }
            }
            return notplaced;
        }

    }


}
