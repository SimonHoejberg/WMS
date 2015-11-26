using WMS.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace WMS.WH
{
    public class Warehouse
    {
        private ICore core;
        private Location[,] locations;
        private Dictionary<string, int> quickPlace = new Dictionary<string, int>();
        private List<Item> notplaced = new List<Item>();
        private Dictionary<int, string> maxMin = new Dictionary<int, string>();
        private List<Item> itemsNotPlaced = new List<Item>();
        private int maxShelf = 0;
        private int maxSpace = 0;
        private string orderNo;

        public Warehouse(ICore core)
        {
            this.core = core;
        }

        private int MaxSpace()
        {
            maxSpace = core.DataHandler.GetMaxSpace();
            return maxSpace;
        }

        private int MaxShelf()
        {
            maxShelf = core.DataHandler.GetMaxShelf();
            return maxShelf;
        }

        public void CreateWH(string orderNo)
        {
            this.orderNo = orderNo;
            locations = new Location[MaxShelf(), MaxSpace()];
            List<Location> temp = core.DataHandler.LocationToList();
            foreach (Location location in temp)
            {
                locations[location.BestLocation, (int.Parse(location.Space) - 1)] = location;
                if (!location.ItemNo.Equals("0"))
                {
                    if (!quickPlace.ContainsKey(location.ItemNo))
                    {
                        quickPlace.Add(location.ItemNo, location.BestLocation);
                    }
                }
            }
        }


        private bool FindAvaliableSpace(Item item, int shelf, int space)
        {
            int max = locations[shelf, 0].Usage;
            int min = locations[shelf, (maxSpace - 1)].Usage;
            if (((max == 0 && min == 0) || (max > item.Usage && item.Usage > min && locations[shelf, space].ItemNo.Equals("0"))) || (locations[shelf, space].ItemNo.Equals(item.ItemNo)))
            {
                string id = locations[shelf, space].Id;
                string locationShelf = locations[shelf, space].Shelf;
                core.DataHandler.PlaceItem(id, locationShelf,item.InStock.ToString(), item.ItemNo,item.Usage.ToString(),orderNo,item.Description);
                locations[shelf, space] = new Location(id, locationShelf, space.ToString(), item.ItemNo, item.InStock, shelf,item.Usage);
                
                return true;
            }
            else
            {
                if (space < (maxSpace - 1))
                {
                    space++;
                }
                else if (shelf < (maxShelf - 1))
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


        public List<Item> FindOptimalLocation(List<Item> items)
        {
            items.Sort();
            foreach (Item item in items)
            {
                if (quickPlace.ContainsKey(item.ItemNo))
                {
                    int quickshelf;
                    quickPlace.TryGetValue(item.ItemNo,out quickshelf);
                    if (!FindAvaliableSpace(item, quickshelf, 0))
                    {
                        notplaced.Add(item);
                    }
                }
                else
                {
                    if (!FindAvaliableSpace(item, 0, 0))
                    {
                        notplaced.Add(item);
                    }
                }
            }
            return notplaced;
        }

    }


}
