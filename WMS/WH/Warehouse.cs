using System;
using System.IO;
using WMS.Handlers;
using WMS.Interfaces;
using System.Collections.Generic;
using WMS.Reference;


namespace WMS.WH
{
    public class Warehouse
    {

        private int numberOfShelf;
        Dictionary<int, int> warehouseLayout = new Dictionary<int, int>();
        List<Item> item = new List<Item>();
        List<Location> location = new List<Location>();
        List<Item> ItemNotPlaced = new List<Item>();
        private ICore core;

        public Warehouse(ICore core)
        {
            this.core = core;
            LoadNewItem();
        }

        //Save to Layout
        //Save to Inventory

        public void LoadNewItem()
        {
            List<object> objectTemp = new List<object>();
            objectTemp = core.DataHandler.DataToList(WindowTypes.INFO, null);
            foreach (object items in objectTemp)
            {
                string []temp = items.ToString().Split(':');
                int itemNo = int.Parse(temp[0]);
                string description = temp[1];
                int size = int.Parse(temp[2]);
                int inStock = int.Parse(temp[3]);
                int shelf = int.Parse(temp[4]);
                Item newItemTemp = new Item(itemNo, description, inStock, shelf, size);
                item.Add(newItemTemp);
            }

            foreach(Item t in item)
            {
                Console.WriteLine(t);
            }
            
        }

     /*   public List<Item> getlist()
        {
            List<Item> temp = new List<Item>();
            foreach (Item t in item)
            {
                temp.Add(t);
            }
            return temp;
        }*/

        public int getMaxSize
        {
            set { numberOfShelf = warehouseLayout.Count; }
        }

        public void LoadWarehouseLayout()
        {
            /*using (StreamReader read = new StreamReader("C:\\Users/Claus/Documents/Visual Studio 2015/Projects/WMS/WMS/WH/Layout.txt"))
            {

                while (!read.EndOfStream)
                {
                    string[] tempRead = read.ReadLine().Split(',');
                    int shelfID = int.Parse(tempRead[0]);
                    int shelfSize = int.Parse(tempRead[1]);
                    warehouseLayout.Add(shelfID, shelfSize);
                }
            }*/
            }

        public void print()
        {
            foreach (KeyValuePair<int, int> pair in warehouseLayout)
            {
                Console.WriteLine(pair.Key + " " + pair.Value);

            }

        }

        public void print2()
        {
            foreach (Location t in location)
            {
                Console.WriteLine(t);
            }


        }

        public void print3()
        {
            foreach (Item t in item)
            {
                Console.WriteLine(t);
            }


        }

        public void LoadWarehouseInventory()
        {
           /* using (StreamReader read = new StreamReader("C:\\Users/Claus/Documents/Visual Studio 2015/Projects/WMS/WMS/WH/Inventory.txt"))
            {
                while (!read.EndOfStream)
                {
                    string[] tempRead = read.ReadLine().Split(',');
                    int productSize = int.Parse(tempRead[0]);
                    string itemName = tempRead[1];
                    int shelfNumber = int.Parse(tempRead[2]);
                    int itemNumber = int.Parse(tempRead[3]);
                    Location tempLocal = new Location(productSize, itemName, shelfNumber, itemNumber);
                    location.Add(tempLocal);
                }
            }*/
            }

        public bool AddShelfUnit(int newShelfID, int newSize)
        {
            foreach (Location local in location)
            {
                if (warehouseLayout.Keys.Equals(newShelfID))
                {
                    return false;
                }
                else
                {
                    warehouseLayout.Add(newShelfID, newSize);
                }
            }
            return true;
        }
        //få fra database
     /*   public void RecivedNewOrderNo(List<Item> items)
        {
            this.item = items;
        }*/
        //Lav om så den finder baseret på ?????
        public int FindShelfNumber(Item product)
        {
            foreach (Location local in location)
            {
                if (product.ItemNo.Equals(local))
                {
                    return local.shelfNumber;
                }
            }
            return 0;
        }

        public int EmptySpace(int shelfID)
        {
            int x = 0;
            foreach (Location local in location)
            {
                if (shelfID.Equals(local.shelfNumber))
                {
                    x = x + local.productSize;
                    //  Console.WriteLine(x);
                }
            }

            return x;

        }

        public bool PlaceItem(Item item, int shelfID)
        {

            if (item != null)
            {
                var NewPlace = new Location(item.Size, item.Description, shelfID, item.ItemNo);
                location.Add(NewPlace);
                Console.WriteLine("Placered Item");
                return true;
            }
            else
            {
                Console.WriteLine("Dident Placered Item");
                return false;
            }


        }

        public int FindMaxSize(int shelfID)
        {
            foreach (KeyValuePair<int, int> pair in warehouseLayout)
            {
                if (shelfID.Equals(pair.Key))
                {
                    Console.WriteLine(pair.Value);
                    return pair.Value;
                }
            }
            return 0;
        }

        public bool FindAvaliableSpace(Item product, int shelfID)
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
        }

        public List<Item> OptimaleLocation(List<Item> items)
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
                r = FindShelfNumber(items[i]);
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
        }
                }
}

