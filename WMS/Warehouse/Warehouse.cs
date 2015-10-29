using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Warehouse
{
    class Warehouse
    {
        FindClass.FindFreeSpace freespace = new FindClass.FindFreeSpace();
        FindClass.WarehouseLayout Layout = new FindClass.WarehouseLayout();
        FindClass.Find_Item item = new FindClass.Find_Item();

        List<Core.ItemType> ItemNotPlaced = new List<Core.ItemType>();
        

        public List<Core.ItemType> algorithm(List<Core.ItemType> Product)
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
        

        public int FindShelfNumber(Core.ItemType Product)
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
        public bool FindAvaliableSpace(Core.ItemType Product, List<Core.Location> x, int i)
        {
            if (Product.Size <= freespace.EmptySpace(x[i], Layout.shelfsize, i))
            {
                freespace.PlaceItem(Product, x[i]);
                Console.WriteLine("Yes");
                return true;
            }
            else if (Product.Size > freespace.EmptySpace(x[i], Layout.shelfsize, i))
            {
                Console.WriteLine("ok");
                return FindAvaliableSpace(Product, x, i++);
            }
            else if (Layout.racks > 6)
            {
                Console.WriteLine("whyyyyyy");
                return false;
            }
            Console.WriteLine("no");
            return false;
        }

        
    }
}
