using System;
using System.IO;
using System.Linq;
using WMS.Handlers;
using WMS.Interfaces;
using System.Collections.Generic;
using WMS.Reference;

namespace WMS.WH
{
    /*Place item, find available space, Algoritmen (kører de to andre)*/
    public class Warehouse
    {
        private ICore core;
        string[,] locations;
        private Dictionary<string, string> placedItems = new Dictionary<string, string>(); 
        private List<Item> notplaced = new List<Item>();

        public Warehouse(ICore core)
        {
            this.core = core;
            locations = new string[5,3];
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

        public void CreateWH()
        {
            Dictionary<string, string> temp = core.DataHandler.warehouseToDictionary();
            foreach (KeyValuePair<string,string> kvp in temp)
            {
                string[] tempS = kvp.Value.Split('.');
                locations[int.Parse(tempS[0]),int.Parse(tempS[1])] = kvp.Key;
            }
        }

        private bool FindAvaliableSpace(Item item)
        {
            int maxLength = MaxLength();
            for (int i = 0; i < 5; i++)
            {
                if(GetUsage(locations[i,0]) > item.Usage && item.Usage < GetUsage(locations[i,maxLength--]))
                {
                    for (int j = 0; j < locations[i,j].Length; j++)
                    {
                        if(locations[i,j]== null)
                        {
                            PlaceItem(item, i.ToString() + "." + j.ToString());
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private int GetUsage(string itemNo)
        {
            if(itemNo != null)
            {
                return core.DataHandler.GetItemFromItemNo(itemNo).Usage;
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
