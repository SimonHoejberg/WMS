using System;
using System.Collections.Generic;
using WMS.Helper;
using WMS.Reference;

namespace WMS.WH
{
    public class Warehouse
    {
        FindFreeSpace freespace = new FindFreeSpace();
        FindItem item = new FindItem();

        List<Item> ItemNotPlaced = new List<Item>();
        

        public List<Item> algorithm(List<Item> Product)
        {
            freespace.add();
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
                }*/
                r = FindShelfNumber(Product[i]);
                f = FindAvaliableSpace(Product[i],freespace.Space, r);
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
            var shelfID = item.FinditemNumber(Product.Description);
            return shelfID;
        }

        /*
        //Reduced: find_item to reduce and update
        public bool reduceItem(item)
        {
                    = FindItem()
               }
        //Waste: find item and remove from system
*/
        public bool FindAvaliableSpace(Item Product, List<Location> x, int i)
        {
            if (Product.Size <= freespace.EmptySpace(x[i], WarehouseLayout.shelfsize, i))
            {
                freespace.PlaceItem(Product, x[i]);
                Console.WriteLine("Yes");
                return true;
            }
            else if (Product.Size > freespace.EmptySpace(x[i], WarehouseLayout.shelfsize, i))
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

        
    }
}
