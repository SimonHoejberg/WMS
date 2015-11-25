using WMS.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace WMS.WH
{
    public class Warehouse
    {
        private ICore core;
        private string[,] locations;
        private Dictionary<string, string> placedItems = new Dictionary<string, string>();
        private List<Item> notplaced = new List<Item>();
        private Dictionary<int, string> maxMin = new Dictionary<int, string>();
        private List<Item> itemsNotPlaced = new List<Item>();
        private int maxShelf = 0;
        private int maxSpace = 0;

        public Warehouse(ICore core)
        {
            this.core = core;
        }

        public bool PlaceItem(Item item, string location)
        {
            core.DataHandler.ChangeLocation(item.ItemNo, location);
            return true;
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

        public void CreateWH()
        {
            locations = new string[MaxShelf(), MaxSpace()];
            Stopwatch st = new Stopwatch();
            st.Start();
            List<Location> temp = core.DataHandler.LocationToList();
            foreach (Location location in temp)
            {
                locations[location.BestLocation, int.Parse(location.Space) - 1] = location.ItemNo;
            }
            st.Stop();
            System.Console.WriteLine("CW " + st.ElapsedMilliseconds + " ms");
        }


        private bool FindAvaliableSpace(Item item, int shelf, int space)
        {
            int max = core.DataHandler.GetUsage(locations[shelf, 0]);
            int min = core.DataHandler.GetUsage(locations[shelf, (maxSpace - 1)]);

            if ((( max == 0 &&  min == 0) || (max > item.Usage && item.Usage > min)) && (locations[shelf, space] == null || locations[shelf, space].Equals(item.ItemNo)))
            {
                locations[shelf, space] = item.ItemNo;
                PlaceItem(item, shelf.ToString() + "." + space.ToString());
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
                if (!FindAvaliableSpace(item, 0,0))
                {
                    notplaced.Add(item);
                }
            }
            return notplaced;
        }

    }


}
