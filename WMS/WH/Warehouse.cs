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
            print3();
            LoadWarehouseInventory();
            print2();
            //OptimaleLocation(item);
            print2();
        }


        public void LoadNewItem()
        {
            List<object> objectTemp = new List<object>();
            objectTemp = core.DataHandler.DataToList(WindowTypes.INFO, null);
            foreach (object items in objectTemp)
            {
                string[] temp = items.ToString().Split(':');
                string itemNo = temp[0];
                string description = temp[1];
                int size = int.Parse(temp[2]);
                int inStock = int.Parse(temp[3]);
                int shelf = int.Parse(temp[4]);
                Item newItemTemp = new Item(itemNo, description, inStock, shelf, size);
                item.Add(newItemTemp);
            }
        }


        public int getMaxSize
        {
            set { numberOfShelf = warehouseLayout.Count; }
        }


        public List<Location> LoadWarehouseInventory()
        {
            List<Location> returnList = new List<Location>();
            List<object> local = new List<object>();
            local = core.DataHandler.DataToList("location", null);
            foreach (object tempLocal in local)
            {
                string[] tempLocation = tempLocal.ToString().Split(':');
                string unit = tempLocation[0];
                int shelf = int.Parse(tempLocation[1]);
                int shelfNo = int.Parse(tempLocation[2]);
                string itemNo = tempLocation[3];
                int space = int.Parse(tempLocation[4]);
                int quantity = int.Parse(tempLocation[5]);
                Location temp = new Location(unit, shelf, shelfNo, itemNo, space, quantity);
                returnList.Add(temp);
            }
            return returnList;
        }


        public void aaaaaaa()
        {
            warehouseLayout.Add(1, 100);
            warehouseLayout.Add(2, 100);
            warehouseLayout.Add(3, 100);
            warehouseLayout.Add(4, 100);
            warehouseLayout.Add(1, 100);
            warehouseLayout.Add(1, 100);
            warehouseLayout.Add(1, 100);
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


        public void SaveWarehouseInventory()
        {

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
        /*   public void RecivedNewOrderNo(List<Item> items)
           {
               this.item = items;
           }*/
        
        
        //Lav om så den finder baseret på ?????

       /* 
         public int FindShelfNumber(Item product)
         {
             foreach (Location local in location)
             {
                 if (product.ItemNo.Equals(local.))
                 {
                     return local.;
                 }
             }
             return 0;
         }
         */
         public int EmptySpace(int shelfID)
         {
             int x = 0;
             foreach (Location local in location)
             {
                
                 if (shelfID.Equals(local.ShelfNo))
                 {
                    x = x + local.Quantity;
                 }
             }

             return x;

         }

         public bool PlaceItem(Item item, int shelfID)
         {

             if (item != null)
             {
                 var NewPlace = new Location("k",shelfID, item.Shelf,item.ItemNo, item.Space, item.InStock);
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
         }
     }
    }


