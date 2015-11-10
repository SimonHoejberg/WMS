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
    public class Warehouse2
    {
        private ICore core;
        List<Location> locationList;

        int[,] shelfSpace;
        List<int[,]> shelfUnit;

        List<Item> itemList;

        public Warehouse2(ICore core)
        {
            this.core = core;

            this.shelfUnit = new List<int[,]>();
            this.locationList = new List<Location>();
            this.itemList = new List<Item>();
            itemList = GetItems();
            locationList = GetLocations();


        }

        public List<Item> GetItems()
        {
            List<Item> returnList = new List<Item>();
            List<object> temp = core.DataHandler.DataToList(WindowTypes.INFO);
            returnList = temp.Cast<Item>().ToList();
            return returnList;
        }

        public List<Location> GetLocations()
        {
            List<Location> returnList = new List<Location>();
            List<object> temp = core.DataHandler.DataToList("location");
            returnList = temp.Cast<Location>().ToList();
            return returnList;
        }

        public bool PlaceItem(Item item, int shelfID)
        {
            //Register placement of item in database
            return true;
        }

        /*public bool FindAvaliableSpace(Item product, int shelfID)
        {
            Console.WriteLine("shelfID er :     {0}", shelfID);
            if (product.Size <= (FindMaxSize(shelfID) - EmptySpace(shelfID)))
            {
                PlaceItem(product, shelfID);
                // Console.WriteLine("Yes");
                return true;
            }
            else if (product.Size > ((FindMaxSize(shelfID) - EmptySpace(shelfID))))
            {
                // Console.WriteLine("ok");
                return FindAvaliableSpace(product, shelfID + 1);
            }
            else if (shelfID > numberOfShelf)
            {
                //  Console.WriteLine("whyyyyyy");
                return false;
            }
            //Console.WriteLine("no");
            return false;
        }*/

        public void SaveWarehouseData(string input, List<object> objList)
        {
            if (input.Equals("item"))
            {

            }
        }

        public bool AddShelfUnit(int newShelfID, int newSize)
        {
            //Add shelfUnit to database
            return true;
        }

        /*public List<Item> OptimaleLocation(List<Item> items)
        {
            int i = 0;
            bool j = true;
            int r = 0;
            bool f;
            items.Sort();
            while (j && i < items.Count)
            {
                if (items[i].Description == null)
                {
                    j = false;
                }
                r = items[i].Shelf;
                f = FindAvaliableSpace(items[i], items[i].Shelf);
                if (f == false)
                {
                    Console.WriteLine("False:    Add to List");
                    ItemNotPlaced.Add(items[i]);
                }
                Console.WriteLine("True:    Yeahhhhhhhh");
                i++;
            }
            return ItemNotPlaced;
        }*/

    }


}
