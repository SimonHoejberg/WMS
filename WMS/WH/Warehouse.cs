using System;
using System.IO;
using System.Linq;
using WMS.Handlers;
using WMS.Interfaces;
using System.Collections.Generic;
using WMS.Reference;

namespace WMS.WH
{
    public class Warehouse
    {
        private ICore core;
        Item[,] locations;
        private Dictionary<string, string> placedItems = new Dictionary<string, string>();
        private List<Item> notplaced = new List<Item>();
        private Dictionary<int, string> maxMin = new Dictionary<int, string>();

        private List<Item> itemsNotPlaced = new List<Item>();



        public Warehouse(ICore core)
        {
            this.core = core;
            locations = new Item[5, 3];
        }

        public bool PlaceItem(Item item, string location)
        {
            core.DataHandler.ChangeLocation(item.ItemNo, location);
            return true;
        }

        private int MaxLength()
        {
            return 2;
        }

        private int GetMaxUsage(List<Item> input, out int output)
        {
            int max = 0;
            int min = 0;
            foreach (Item item in input)
            {
                if (item.Usage > max)
                {
                    max = item.Usage;
                }
                else if (item.Usage < min)
                {
                    min = item.Usage;
                }
            }
            output = min;
            return max;
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
            int i = 0;
            int j = 0;
            List<Item> usage = new List<Item>();
            foreach (var item in locations)
            {
                if (i < 3)
                {
                    if (item != null)
                    {
                        usage.Add(item);

                    }
                    i++;
                }
                else if (i == 3)
                {
                    int min;
                    int max = GetMaxUsage(usage, out min);
                    maxMin.Add(j, max.ToString() + "." + min.ToString());
                    i = 0;
                    j++;
                    usage = new List<Item>();
                }

            }
        }

        private bool FindAvaliableSpace(Item item)
        {
            int maxLength = MaxLength();
            for (int i = 0; i < 5; i++)
            {
                string arr;
                if (maxMin.TryGetValue(i, out arr))
                {
                    string[] tempS = arr.Split('.');
                    int max;
                    int min;
                    int.TryParse(tempS[0], out max);
                    int.TryParse(tempS[1], out min);
                    if (max != 0 && max > item.Usage && item.Usage > min)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (locations[i, j] == null || locations[i, j].ItemNo.Equals(item.ItemNo))
                            {
                                locations[i, j] = item;
                                PlaceItem(item, i.ToString() + "." + j.ToString());
                                return true;
                            }
                            else if(j == 2)
                            {
                                i++;
                                j = -1;
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (locations[i, j] == null || locations[i, j].ItemNo.Equals(item.ItemNo))
                            {
                                locations[i, j] = item;
                                PlaceItem(item, i.ToString() + "." + j.ToString());
                                return true;
                            }
                            else if (j == 2)
                            {
                                i++;
                                j = -1;
                            }
                        }
                    }
                }
            }
            return false;
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
                if (!FindAvaliableSpace(item))
                {
                    notplaced.Add(item);
                }
            }
            return notplaced;
        }

    }


}
