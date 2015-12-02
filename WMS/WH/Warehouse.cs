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
        private List<Item> itemsNotPlaced;
        private Dictionary<Item, Location> itemsPlaced;
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
            quickPlace = new Dictionary<string, int>();
            locations = new Location[MaxShelf(), MaxSpace()];
            List<Location> temp = core.DataHandler.LocationToList();
            foreach (Location location in temp)
            {
                if (location.Quantity != 0)
                {
                    locations[location.BestLocation, (int.Parse(location.Space) - 1)] = location;
                    if (!location.ItemNo.Equals("0"))
                    {
                        if (!quickPlace.ContainsKey(location.ItemNo))
                        {
                            quickPlace.Add(location.ItemNo, location.BestLocation);
                        }
                        else
                        {
                            quickPlace.Remove(location.ItemNo);
                            quickPlace.Add(location.ItemNo, location.BestLocation);
                        }
                    }
                }
            }
        }


        private void PlaceItem(string id,string locationShelf,Item item, int shelf, int space)
        {
            core.DataHandler.PlaceItem(id, locationShelf, item.InStock.ToString(), item.ItemNo, item.Usage.ToString(), orderNo, item.Description);
            Location location = new Location(id, locationShelf, space.ToString(), item.ItemNo, item.InStock, shelf, item.Usage);
            locations[shelf, space] = location;
            itemsPlaced.Add(item, location);

        }

        private bool FindAvaliableSpace(Item item, int shelf, int space)
        {
            int max = locations[shelf, 0].Usage;
            int min = locations[shelf, (maxSpace - 1)].Usage;
            if (((max == 0 && min == 0) || (max > item.Usage && locations[shelf, space].ItemNo.Equals("0"))) || (locations[shelf, space].ItemNo.Equals(item.ItemNo)))
            {
                string id = locations[shelf, space].Id;
                string locationShelf = locations[shelf, space].Shelf;

                PlaceItem(id, locationShelf, item, shelf, space);

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


        public List<Item> FindOptimalLocation(List<Item> items, out Dictionary<Item,Location> itemsPlaced)
        {
            this.itemsPlaced = new Dictionary<Item, Location>();
            itemsNotPlaced = new List<Item>();
            items.Sort();
            foreach (Item item in items)
            {
                if (quickPlace.ContainsKey(item.ItemNo))
                {
                    int quickshelf;
                    quickPlace.TryGetValue(item.ItemNo,out quickshelf);
                    if (!FindAvaliableSpace(item, quickshelf, 0))
                    {
                        itemsNotPlaced.Add(item);
                    }
                }
                else
                {
                    if (!FindAvaliableSpace(item, 0, 0))
                    {
                        itemsNotPlaced.Add(item);
                    }
                }
            }
            itemsPlaced = this.itemsPlaced;
            return itemsNotPlaced;
        }

    }


}
