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
            LoadWarehouseInventory();
            LoadWarehouseLayout();
            print();
            print2();
            print3();
        }

        //Save to Layout
        //Save to Inventory

        public void LoadNewItem()
        {
            List<object> objectTemp = new List<object>();
            objectTemp = core.DataHandler.DataToList(WindowTypes.INFO,null);
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
            using (StreamReader read = new StreamReader("C:\\Users/Claus/Documents/Visual Studio 2015/Projects/WMS/WMS/WH/Layout.txt"))
            {

                while (!read.EndOfStream)
                {
                    string[] tempRead = read.ReadLine().Split(',');
                    int shelfID = int.Parse(tempRead[0]);
                    int shelfSize = int.Parse(tempRead[1]);
                    warehouseLayout.Add(shelfID, shelfSize);
                }
            }
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
            using (StreamReader read = new StreamReader("C:\\Users/Claus/Documents/Visual Studio 2015/Projects/WMS/WMS/WH/Inventory.txt"))
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
            }
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
                if (product.Description.Equals(local.itemName))
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






























    /*


                List<Item> ItemNotPlaced = new List<Item>();

                public List<Item> ItemList = new List<Item>();
                Item Item = new Item(1564, "adolf", 2, 5, 5);
                Item Item2 = new Item(1534, "hitler", 21, 6, 55);

                private List<Item> algorithm(List<Item> Product)
                {
                    add();
                    int i = 0;
                    bool j = true;
                    int r = 0;
                    bool f;
                    Product.Sort();
                    while (j && i<2)
                    {
                    /*    if (Product[i].Description == null)
                        {
                            j = false;
                        }*
                        r = FindShelfNumber(Product[i]);
                        f = FindAvaliableSpace(Product[i],Space, r);
                        if (f == false)
                        {
                            ItemNotPlaced.Add(Product[i]);
                        }
                        i++;
                    }
                    return ItemNotPlaced;
                }
                //gui classer sender information
                //Move: find item til at flytte,find itemplacering, find alle freespace, og derefter tildel ny placering


                public int FindShelfNumber(Item Product)
                {    
                    var shelfID = FinditemNumber(Product.Description);
                    return shelfID;
                }

                /*
                //Reduced: find_item to reduce and update
                public bool reduceItem(item)
                {
                            = FindItem()
                       }
                //Waste: find item and remove from system
        *
                public bool FindAvaliableSpace(Item Product, List<Location> x, int i)
                {
                    if (Product.Size <= EmptySpace(x[i], WarehouseLayout.shelfsize, i))
                    {
                        PlaceItem(Product, x[i]);
                        Console.WriteLine("Yes");
                        return true;
                    }
                    else if (Product.Size > EmptySpace(x[i], WarehouseLayout.shelfsize, i))
                    {
                        Console.WriteLine("ok");
                        return FindAvaliableSpace(Product, x, i++);
                    }
                    else if (WarehouseLayout.racks > 6)
                    {
                        Console.WriteLine("whyyyyyy");
                        return false;
                    }
                    Console.WriteLine("no");
                    return false;
                }

                public List<Location> Space = new List<Location>();

                Location locale = new Location(0, "mike1", 2, 5, 9, 100, 1564);
                Location locale1 = new Location(0, "mike", 2, 5, 9, 100, 1564);
                Location locale2 = new Location(0, "mike2", 2, 5, 9, 100, 1564);
                Location locale3 = new Location(0, "mike3", 2, 5, 9, 100, 1564);
                Location locale4 = new Location(0, "mike4", 2, 6, 9, 100, 1564);
                Location locale5 = new Location(0, "mike5", 2, 6, 9, 100, 1564);
                Location locale6 = new Location(0, "mike6", 2, 6, 9, 100, 1564);

                public void add()
                {
                    Space.Add(locale);
                    Space.Add(locale1);
                    Space.Add(locale2);
                    Space.Add(locale3);
                    Space.Add(locale4);
                    Space.Add(locale5);
                    Space.Add(locale6);

                }




                public int EmptySpace(Location ShelfID, int Max, int i)
                {
                    int x = 0;
                    foreach (Location space in Space)
                    {
                        if (ShelfID.shelfNumber == space.shelfNumber)
                        {
                            x = x + space.itemQuantity;
                        }
                    }
                    return x;

                }

                public bool PlaceItem(Item Product, Location ShelfID)
                {
                    if (Product != null)
                    {
                        var NewPlace = new Location(0, Product.Description, ShelfID.shelfUnit, ShelfID.shelfNumber, ShelfID.shelfPosition + Product.Size, ShelfID.itemQuantity, Product.ItemNo);
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                }



                /*    List<location> LocationList = new List<location>();


                        public int EmptySpace(int shelfID)
                        {
                            location
                        }

              *


            public void LoadItemList()
            {
                // data from DB
                ItemList.Add(Item);
                ItemList.Add(Item2);

            }


            public int FinditemNumber(string name)
            {

                foreach (Item number in ItemList)
                {
                    if (name.Equals(number.Description))
                    {
                        //return number.Location;
                    }

                }
                return 0;
            }


            public Item Find_item(string name)
            {

                foreach (Item ite in ItemList)
                {
                    if (name.Equals(ite.Description))
                    {

                        return ite;
                    }
                }
                return null;

                //methoder til at finde list over item eller broken item, return list()
            }
        }

         /*List<location> LocationList = new List<location>();



                public int Find_Place(string name)
                {
                    foreach (location in LocationList)
                    {
                        if (name.Equals(locationList.name))
                        {
                            return Location;
                        }
                    }

                }*/


}

